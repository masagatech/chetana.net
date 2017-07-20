#region NameSpace
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Idv.Chetana.BAL;
using Idv.Chetana.Common;
using System.Net.Mail;
using System.Text;
using System.IO;

#endregion

public partial class UserControls_ODC_uc_PendingDC : System.Web.UI.UserControl
{
    #region Variables
    decimal SubDocNo = 0;
    bool Auth = false;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string strEmailID;

    #endregion
   
    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["ChetanaCompanyName"] != null)
            {
                if (Session["FY"] != null)
                {
                    strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                    strFY = Session["FY"].ToString();
                }
                else
                {
                    Session.Clear();
                }
            }
        if (!Page.IsPostBack)
        {
            txtFromDate.Focus();
            GetValidation(4, Convert.ToInt32(Session["Role"]));
            docno.InnerHtml = "Not Selected";
            RdlView.SelectedValue = "DeliveryDate";
            //Rptrpending.DataSource = DCMaster.Get_Pending_DocNo();
            // Rptrpending.DataBind();


            Pnldeldate.Visible = false;
            //   txtempc.Visible = false;
            //   lblemp.Visible = false;
            pnlcity.Visible = false;
            Pnlcust.Visible = false;
            pnlDetails.Visible = false;
            pnlDetails.Visible = false;
            BindPanel();
        }
        if (add)
        {
            btnconfirm.Enabled = true;
        }
        if (view)
        {
            btnget.Enabled = true;
        }
        tblNo.Visible = true;
        tblDate.Visible = true;
      
    }
    #endregion

    #region Events

    protected void btnget_Click(object sender, EventArgs e)
    {
        try
        {
            lblmessage.InnerHtml = "";
            pnlDetails.Visible = true;
            docno.InnerHtml = txtdocno.Text.Trim();
            // upDetails.Visible = true;
            txtempc.Visible = true;
            lblemp.Visible = true;
            btnPrint.Visible = true;
            txtremark.Visible = true;
            DataSet ds6 = new DataSet();
            //ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno");
             ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno", Convert.ToInt32(strFY));
            grdconfirm.DataSource = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno", Convert.ToInt32(strFY)).Tables[0];
            grdconfirm.DataBind();
            
            // pnlDetails.Visible = true;
            grdconfirm.Visible = true;
            int id = Convert.ToInt32(ds6.Tables[1].Rows[0]["CustID"]);
            lblempname1.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["FirstName"]) + " " + Convert.ToString(ds6.Tables[1].Rows[0]["LastName"]) + "   ";
            lblcustname.InnerHtml = "  " + Convert.ToString(ds6.Tables[1].Rows[0]["CustName"]);
            lblspinstruction.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["SpInstruction"]);
            lbldcdate.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["DocumentDate"]);
            lblorder.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["OrderDate"]);
            ViewState["EmailID"] = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
            lblemailid.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
            //strEmailID = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
            DataSet ds7 = G_GetPass.CustEMail_LocalEntry(id);
            ViewState["SEmailid"] = Convert.ToString(ds7.Tables[0].Rows[0]["SEmailID"]);
            if (Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]) == "")
            {
                lblEmailAlert.Visible = true;
                lblEmailAlert.ForeColor = System.Drawing.Color.Red;
                lblEmailAlert.Text = "Add email id";
                btnEmail.Enabled = false;
            }
            else
            {
                lblEmailAlert.Visible = false;
                btnEmail.Enabled = true;
            }
            string jv = "";
            if (grdconfirm.Rows.Count <= 0)
            {
                btnconfirm.Visible = false;
                jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='none';";
            }
            else
            {
                btnconfirm.Visible = true;
                jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='visible';";
            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);
        }
        catch { }

        txtempc.Focus();
    }

    #endregion

    #region Events

    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        btnconfirm.Enabled = false;
        Auth = DCMaster.Get_DocumentNum_Authentication(Convert.ToInt32(txtdocno.Text), Convert.ToInt32(strFY));
        SubDocNo = Convert.ToDecimal(DCConfirmQtyDetails.Get_DCDetails_SubDocNo_ByDocID(Convert.ToInt32(txtdocno.Text), Convert.ToInt32(strFY)).Rows[0][0].ToString());
        if (Auth)
        {
            MessageBox("Document no is not available");
            txtdocno.Focus();
        }

        else
        {
            DCConfirmQtyDetails _objDCConfirmQtyDetails = new DCConfirmQtyDetails();
            DCMaster _objDCMaster = new DCMaster();
            DCtoGodown _objDCMastertoGodown = new DCtoGodown();
            int DocId = 0;
            try
            {
                foreach (GridViewRow Row in grdconfirm.Rows)
                {
                    _objDCConfirmQtyDetails.DCDetailID = Convert.ToInt32(((Label)Row.FindControl("lblDCdatils")).Text.Trim());
                    string Qty = ((TextBox)Row.FindControl("lblavailable")).Text.Trim();
                    _objDCConfirmQtyDetails.AvailableQty = Convert.ToInt32(Qty);
                    DocId = Convert.ToInt32(((Label)Row.FindControl("lbldocNo")).Text.Trim());
                    _objDCConfirmQtyDetails.SubDocNo = SubDocNo;
                    _objDCConfirmQtyDetails.CreatedBy = Convert.ToString(Session["UserName"]);
                    if (txtBundles.Text == "")
                        _objDCConfirmQtyDetails.Bundles = 0;
                    else
                        _objDCConfirmQtyDetails.Bundles =Convert.ToDecimal(txtBundles.Text.Trim());
                    if (txtParcels.Text == "")
                        _objDCConfirmQtyDetails.Parcel = 0;
                    else
                        _objDCConfirmQtyDetails.Parcel = Convert.ToDecimal(txtParcels.Text.Trim());

                        _objDCConfirmQtyDetails.SaveDCConfirmQtyDetails();
                    //Godown

                }
                try
                {
                    _objDCMastertoGodown.SubDocNo = SubDocNo;
                    _objDCMastertoGodown.DocumentNo = Convert.ToInt32(txtdocno.Text.Trim());
                    _objDCMastertoGodown.EmpID = txtempc.Text.Trim();
                    _objDCMastertoGodown.CreatedBy = Convert.ToString(Session["UserName"]);
                    _objDCMastertoGodown.SaveGodown();
                }
                catch (Exception ex)
                {


                }
                _objDCMaster.DocNo = DocId;
                _objDCMaster.IsConfirm = true;
                _objDCMaster.IsApproved = false;
                _objDCMaster.IsCanceled = false;
                _objDCMaster.Remark = txtremark.Text.Trim();
                _objDCMaster.FinancialYearFrom = Convert.ToInt32(strFY);
                _objDCMaster.update(1);
                grdconfirm.DataBind();
                MessageBox("DC Confirm successfully for document no. " + txtdocno.Text);
                loder("DC Confirm successfully for document no. " + txtdocno.Text);
                lblmessage.InnerHtml = "Last confirm doc no. : " + docno.InnerHtml;
                //docno.InnerHtml = "Last confirm doc no. : " + docno.InnerHtml;
                //Rptrpending.DataSource = DCMaster.Get_Pending_DocNo(Convert.ToInt32(strFY));
                //Rptrpending.DataBind();
                txtempc.Text = "";
                lblEmpName.Text = "";
                txtempc.Visible = false;
                lblEmpName.Visible = false;
                lblemp.Visible = false;
                btnconfirm.Visible = false;
                btnPrint.Visible = false;
                txtremark.Visible = false;
                docno.InnerHtml = "";
                lblempname1.InnerHtml = "";
                lblcustname.InnerHtml = "";
                txtremark.Text = "";
                txtBundles.Text = "0";
                txtParcels.Text = "0";
                lblemailid.InnerHtml = "";
                tblDate.Visible = false;
                tblNo.Visible = false;
                ModpupConfirmation.Hide();
                string jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='none';";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);

                upOrderNO.Update();
            }

            catch (Exception ex)
            {
                MessageBox(ex.Message.ToString());
            }
        }

    }

    protected void btnBookWice_Click(object sender, EventArgs e)
    {
        Response.Redirect("PendingDC.aspx?cmode=b");
    }

    protected void btnDocWice_Click(object sender, EventArgs e)
    {
  try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDC.aspx?d=" + txtdocno.Text.Trim() + "&sd=" + Convert.ToInt32(strFY) + "&type=without" + "')", true);
        }
        catch
        {
        }
       // Response.Redirect("PendingDC.aspx?cmode=d");
    }


    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #region Binddata method



    #endregion


    #region Validation Methods

    #region Variables

    private static bool add = false;
    private static bool view = false;
    private static bool edit = false;
    private static bool delete = false;

    #endregion

    public void GetValidation(int Menuid, int Roleid)
    {
        DataTable dt = new DataTable();
        dt = Mappings.Get_MenuFunctions(Menuid, Roleid).Tables[0];
        add = Convert.ToBoolean(dt.Rows[0]["Add"].ToString());
        view = Convert.ToBoolean(dt.Rows[0]["View"].ToString());
        edit = Convert.ToBoolean(dt.Rows[0]["Edit"].ToString());
        delete = Convert.ToBoolean(dt.Rows[0]["Delete"].ToString());
    }

    #endregion

    #region ChagedEvent

    protected void txtempc_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtempc.Text.Split(Constants.splitseperator)[0].ToString().Trim();

        DataTable dt = new DataTable();
        dt = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("Teamdetails", "Department").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtempc.Text = ECode;
            lblEmpName.Text = dt.Rows[0]["Value"].ToString();
            txtremark.Focus();

        }
        else
        {
            lblEmpName.Text = "No Such Teamfound";
            txtempc.Focus();
            txtempc.Text = "";
        }

    }
    protected void TxtEmpCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = TxtEmpCode.Text.ToString();
    }
    protected void RdlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanel();

    }
    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #endregion

    #region Datewise
    protected void btnfind_Click(object sender, EventArgs e)
    {

        string from = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtFromDate.Focus();
        }
        else
        {

            Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(0, "deliverydate", Convert.ToDateTime(from), Convert.ToDateTime(To), Convert.ToInt32(strFY));
            Rptrpending.DataBind();
            pnlconfirm.Visible = true;
            Rptrpending.Visible = true;
            upOrderNO.Update();
            pnlDetails.Visible = false;
        }
    }
    #endregion

    #region CustomerWise
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        // pnlconfirm.Visible = true;
        //Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(Convert.ToInt32(DDLCustomer.SelectedValue), "Customer", Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"));
        Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(Convert.ToInt32(DDLCustomer.SelectedValue), "Customer",
            Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"),
            Convert.ToInt32(strFY));
        Rptrpending.DataBind();
        pnlconfirm.Visible = true;
        Rptrpending.Visible = true;

        upOrderNO.Update();
        pnlDetails.Visible = false;
    }
    #endregion

    #region CityWise

    protected void findarea_Click(object sender, EventArgs e)
    {

    }
    protected void DDlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDlstate.SelectedValue != "0")
        {
            DDlCity.Items.Clear();
           // DDlCity.DataSource = Destination.GetDestination(Convert.ToString(DDlstate.SelectedValue));
            DDlCity.DataSource = DCMaster.Get_Customer_PendingDocNo("city@" + DDlstate.SelectedValue.ToString(), Convert.ToInt32(strFY));
            DDlCity.DataBind();
            DDlCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(Convert.ToInt32(DDlstate.SelectedValue), "City", Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"), Convert.ToInt32(strFY));
            Rptrpending.DataBind();
            if (Rptrpending.Items.Count > 0)
            {
                pnlconfirm.Visible = true;
                Rptrpending.Visible = true;

                upOrderNO.Update();
                pnlDetails.Visible = false;
            }
            else
            {
                pnlconfirm.Visible = false;
                Rptrpending.Visible = false;
                upOrderNO.Update();
                pnlDetails.Visible = false;
            }
            if (DDlCity.Items.Count > 0)
            {
                DDlCity.Focus();
            }
            else
            {
                DDlstate.Focus();
            }
        }
        else
        {
            DDlCity.DataBind();
            DDlCity.Focus();

        }
    }
    protected void DDlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(Convert.ToInt32(DDlCity.SelectedValue), "City", Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"), Convert.ToInt32(strFY));
        Rptrpending.DataBind();
        if (Rptrpending.Items.Count > 0)
        {
            pnlconfirm.Visible = true;
            Rptrpending.Visible = true;

            upOrderNO.Update();
            pnlDetails.Visible = false;
        }
        else
        {
            MessageBox("Record not available");
            pnlconfirm.Visible = false;
            Rptrpending.Visible = false;
            upOrderNO.Update();
            pnlDetails.Visible = false;
        }
    }
    #endregion
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDC.aspx?d=" + txtdocno.Text.Trim() + "&sd=" + Convert.ToInt32(strFY) + "&type=with" + "')", true);
          //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDC.aspx?d=" + txtdocno.Text.Trim() + "&sd=" + //Convert.ToInt32(strFY) + "')", true);
        }
        catch
        {
        }
    }
    protected void btnPendingDC_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDCPending.aspx?d=" + txtdocno.Text.Trim() + "&sd="+ Convert.ToInt32("-"+strFY) + "')", true);
        }
        catch
        {
        }
    }
    #region Bind Customer
    public void BindCustomer()
    {
        DDLCustomer.Items.Clear();
        //DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer");
        DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer", Convert.ToInt32(strFY));
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("- Select Customer-", "0"));
    }
    #endregion

    #region BinaPAnel
    public void BindPanel()
    {
        RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Customer")
        {
            BindCustomer();
            Pnldeldate.Visible = false;
            pnlcity.Visible = false;
            Pnlcust.Visible = true;
            pnlDetails.Visible = false;
            Rptrpending.Visible = true;
            upOrderNO.Update();
            pnlconfirm.Visible = false;
            //    DDLCustomer.Items.Insert(0, new ListItem("- Select Customer-", "0"));

        }
        if (RdBValue == "DeliveryDate")
        {
            Pnldeldate.Visible = true;
            pnlcity.Visible = false;
            Pnlcust.Visible = false;
            pnlDetails.Visible = false;
            Rptrpending.Visible = true;
            upOrderNO.Update();
            pnlconfirm.Visible = false;
            txtFromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            txttoDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

        }
        if (RdBValue == "All")
        {
            Pnldeldate.Visible = false;
            pnlcity.Visible = false;
            Pnlcust.Visible = false;
            Rptrpending.Visible = true;
            //Rptrpending.DataSource = DCMaster.Get_Pending_DocNo();
            Rptrpending.DataSource = DCMaster.Get_Pending_DocNo(Convert.ToInt32(strFY));
            Rptrpending.DataBind();
            upOrderNO.Update();
            //  Bind_DDL_SuperZone();  
            pnlconfirm.Visible = true;
            pnlDetails.Visible = false;

        }
        if (RdBValue == "City")
        {
            Pnldeldate.Visible = false;
            pnlcity.Visible = true;
            Pnlcust.Visible = false;
            pnlconfirm.Visible = false;
            pnlDetails.Visible = false;
            Rptrpending.Visible = true;
            upOrderNO.Update();
            DDlstate.DataSource = Destination.GetDestination(Convert.ToString("state"));
            DDlstate.DataBind();
            DDlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            DDlCity.Items.Clear();
            DDlCity.Items.Insert(0, new ListItem("--Select City--", "0"));

        }
    }
    #endregion

    protected void btnEmail_Click(object sender, EventArgs e)
    {
         //Server.Transfer("SendEmail.aspx?id=" + txtdocno.Text + "&mailid=" + ViewState["EmailID"]);
         //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('SendEmail.aspx?d=" + txtdocno.Text.Trim() + "&mailid=" + ViewState["EmailID"] + "&sd=" + Convert.ToInt32(strFY) + "&type=with" + "')", true);
        Server.Transfer("SendEmail.aspx?d=" + txtdocno.Text.Trim() + "&mailid=" + ViewState["EmailID"] + "&sd=" + Convert.ToInt32(strFY) + "&smailid=" + ViewState["SEmailid"] + "&type=with");
      
        
    }




  
}
