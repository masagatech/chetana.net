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
using Idv.Chetana.CnF;
using Idv.Chetana.Common;
using Other_Z;


public partial class CNFPending : System.Web.UI.Page
{

    #region Goloval Veriable
    Other_Z.OtherBAL ObjDal = new OtherBAL();
    string FY = "";
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            FY = Session["FY"].ToString();
            btnconfirm.Visible = false;
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            GetValidation(4, Convert.ToInt32(Session["Role"]));
            docno.InnerHtml = "Not Selected";
            btnPrint.Visible = false;
            btnDocWice.Visible = false;
            pnlDetails.Visible = false;
            GetSuperZone();
            DDLCnf.Focus();
        }
    }
    #endregion

    #region Dropdown Bind
    public void GetSuperZone()
    {
        DDLCnf.DataSource = BindCnFGrid("ddlCnF", 0).Tables[0];
        DDLCnf.DataBind();
        DDLCnf.Items.Insert(0, new ListItem("-- Select CnF --", "0"));
    }
    #endregion

    #region Dropdown Method
    public DataSet BindCnFGrid(string Flag, int Id)
    {
        DataSet ds = new DataSet();
        CnFCustomer objcs = new CnFCustomer();
        objcs.Remark1 = Flag;
        objcs.CnFID = Id;
        ds = objcs.GetCnF_Master();
        return ds;
        //grdCnFDetails.DataSource = ds.Tables[0];
        //grdCnFDetails.DataBind();
    }
    #endregion

    #region Get Button Click Event And Bind Ripiter Control This Method
    public void BindPanel()
    {
        DataTable dt = ObjDal.C_GetPendingDocNo(Convert.ToInt32(FY), DDLCnf.SelectedValue.ToString()).Tables[0];
        if (dt.Rows.Count > 0)
        {
            //Rptrpending.Visible = true;
            pnlconfirm.Visible = true;
            upOrderNO.Visible = true;
            pnlDetails.Visible = false;
            Rptrpending.DataSource = dt;
            Rptrpending.DataBind();
        }
        else
        {
            MessageBox("There is no pending DC for this CnF ");
            pnlconfirm.Visible = false;
            pnlDetails.Visible = false;
            DDLCnf.Focus();
            return;
        }
        //pnlDetails.Visible = false;
    }
    #endregion

    #region Get Button Click Event
    protected void btnGetData_click(object sender, EventArgs e)
    {
        BindPanel();
    }
    #endregion

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
            
            txtremark.Visible = true;
            DataSet ds6 = new DataSet();
            //ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno");
            ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno", Convert.ToInt32(FY));
            grdconfirm.DataSource = ds6.Tables[0]; //DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno", Convert.ToInt32(strFY)).Tables[0];
            grdconfirm.DataBind();

            // pnlDetails.Visible = true;
            grdconfirm.Visible = true;
            lblempname1.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["FirstName"]) + " " + Convert.ToString(ds6.Tables[1].Rows[0]["LastName"]) + "   ";
            lblcustname.InnerHtml = "  " + Convert.ToString(ds6.Tables[1].Rows[0]["CustName"]);
            lblspinstruction.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["SpInstruction"]);
            lbldcdate.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["DocumentDate"]);
            lblorder.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["OrderDate"]);
            ViewState["EmailID"] = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
            lblemailid.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
            //strEmailID = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
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
                btnconfirm.Visible = false;
                jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='visible';";
            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);
        }
        catch { }

        txtempc.Focus();
    }

    protected void txtempc_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtempc.Text.Split(Constants.splitseperator)[0].ToString().Trim();

        DataTable dt = new DataTable();
        dt = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("Teamdetails", ECode).Tables[0];
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

    #region Events Confirm Button Click Comment By Nilesh Sir 29-01-2016

    //protected void btngetRepiter(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblmessage.InnerHtml = "";
    //        pnlDetails.Visible = true;
    //        docno.InnerHtml = txtdocno.Text.Trim();
    //        // upDetails.Visible = true;
    //        txtempc.Visible = true;
    //        lblemp.Visible = true;
    //        btnPrint.Visible = true;
    //        txtremark.Visible = true;
    //        DataSet ds6 = new DataSet();
    //        //ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno");
    //        ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno", Convert.ToInt32(strFY));
    //        grdconfirm.DataSource = ds6.Tables[0]; //DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno", Convert.ToInt32(strFY)).Tables[0];
    //        grdconfirm.DataBind();

    //        // pnlDetails.Visible = true;
    //        grdconfirm.Visible = true;
    //        lblempname1.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["FirstName"]) + " " + Convert.ToString(ds6.Tables[1].Rows[0]["LastName"]) + "   ";
    //        lblcustname.InnerHtml = "  " + Convert.ToString(ds6.Tables[1].Rows[0]["CustName"]);
    //        lblspinstruction.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["SpInstruction"]);
    //        lbldcdate.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["DocumentDate"]);
    //        lblorder.InnerHtml = Convert.ToString(ds6.Tables[0].Rows[0]["OrderDate"]);
    //        ViewState["EmailID"] = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
    //        lblemailid.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
    //        //strEmailID = Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]);
    //        if (Convert.ToString(ds6.Tables[1].Rows[0]["CUSTEmailID"]) == "")
    //        {
    //            lblEmailAlert.Visible = true;
    //            lblEmailAlert.ForeColor = System.Drawing.Color.Red;
    //            lblEmailAlert.Text = "Add email id";
    //            btnEmail.Enabled = false;
    //        }
    //        else
    //        {
    //            lblEmailAlert.Visible = false;
    //            btnEmail.Enabled = true;
    //        }
    //        string jv = "";
    //        if (grdconfirm.Rows.Count <= 0)
    //        {
    //            btnconfirm.Visible = false;
    //            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='none';";
    //        }
    //        else
    //        {
    //            btnconfirm.Visible = true;
    //            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='visible';";
    //        }
    //        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);
    //    }
    //    catch { }

    //    txtempc.Focus();
    //}

    #endregion

    #region Events

    //protected void btnconfirm_Click(object sender, EventArgs e)
    //{
    //    btnconfirm.Enabled = false;
    //    Auth = DCMaster.Get_DocumentNum_Authentication(Convert.ToInt32(txtdocno.Text), Convert.ToInt32(strFY));
    //    SubDocNo = Convert.ToDecimal(DCConfirmQtyDetails.Get_DCDetails_SubDocNo_ByDocID(Convert.ToInt32(txtdocno.Text), Convert.ToInt32(strFY)).Rows[0][0].ToString());
    //    if (Auth)
    //    {
    //        MessageBox("Document no is not available");
    //        txtdocno.Focus();
    //    }

    //    else
    //    {
    //        DCConfirmQtyDetails _objDCConfirmQtyDetails = new DCConfirmQtyDetails();
    //        DCMaster _objDCMaster = new DCMaster();
    //        DCtoGodown _objDCMastertoGodown = new DCtoGodown();
    //        int DocId = 0;
    //        try
    //        {
    //            foreach (GridViewRow Row in grdconfirm.Rows)
    //            {
    //                _objDCConfirmQtyDetails.DCDetailID = Convert.ToInt32(((Label)Row.FindControl("lblDCdatils")).Text.Trim());
    //                string Qty = ((TextBox)Row.FindControl("lblavailable")).Text.Trim();
    //                _objDCConfirmQtyDetails.AvailableQty = Convert.ToInt32(Qty);
    //                DocId = Convert.ToInt32(((Label)Row.FindControl("lbldocNo")).Text.Trim());
    //                _objDCConfirmQtyDetails.SubDocNo = SubDocNo;
    //                _objDCConfirmQtyDetails.CreatedBy = Convert.ToString(Session["UserName"]);
    //                if (txtBundles.Text == "")
    //                    _objDCConfirmQtyDetails.Bundles = 0;
    //                else
    //                    _objDCConfirmQtyDetails.Bundles = Convert.ToDecimal(txtBundles.Text.Trim());
    //                if (txtParcels.Text == "")
    //                    _objDCConfirmQtyDetails.Parcel = 0;
    //                else
    //                    _objDCConfirmQtyDetails.Parcel = Convert.ToDecimal(txtParcels.Text.Trim());

    //                _objDCConfirmQtyDetails.SaveDCConfirmQtyDetails();
    //                //Godown

    //            }
    //            try
    //            {
    //                _objDCMastertoGodown.SubDocNo = SubDocNo;
    //                _objDCMastertoGodown.DocumentNo = Convert.ToInt32(txtdocno.Text.Trim());
    //                _objDCMastertoGodown.EmpID = txtempc.Text.Trim();
    //                _objDCMastertoGodown.CreatedBy = Convert.ToString(Session["UserName"]);
    //                _objDCMastertoGodown.SaveGodown();
    //            }
    //            catch (Exception ex)
    //            {


    //            }
    //            _objDCMaster.DocNo = DocId;
    //            _objDCMaster.IsConfirm = true;
    //            _objDCMaster.IsApproved = false;
    //            _objDCMaster.IsCanceled = false;
    //            _objDCMaster.Remark = txtremark.Text.Trim();
    //            _objDCMaster.FinancialYearFrom = Convert.ToInt32(strFY);
    //            _objDCMaster.update(1);
    //            grdconfirm.DataBind();
    //            MessageBox("DC Confirm successfully for document no. " + txtdocno.Text);
    //            loder("DC Confirm successfully for document no. " + txtdocno.Text);
    //            lblmessage.InnerHtml = "Last confirm doc no. : " + docno.InnerHtml;
    //            //docno.InnerHtml = "Last confirm doc no. : " + docno.InnerHtml;
    //            //Rptrpending.DataSource = DCMaster.Get_Pending_DocNo(Convert.ToInt32(strFY));
    //            //Rptrpending.DataBind();
    //            BindPanel();
    //            txtempc.Text = "";
    //            lblEmpName.Text = "";
    //            txtempc.Visible = false;
    //            lblEmpName.Visible = false;
    //            lblemp.Visible = false;
    //            btnconfirm.Visible = false;
    //            btnPrint.Visible = false;
    //            txtremark.Visible = false;
    //            docno.InnerHtml = "";
    //            lblempname1.InnerHtml = "";
    //            lblcustname.InnerHtml = "";
    //            txtremark.Text = "";
    //            txtBundles.Text = "0";
    //            txtParcels.Text = "0";
    //            lblemailid.InnerHtml = "";
    //            tblDate.Visible = false;
    //            tblNo.Visible = false;
    //            ModpupConfirmation.Hide();
    //            string jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_PendingDC1_btnconfirm').style.display='none';";
    //            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);


    //        }

    //        catch (Exception ex)
    //        {
    //            MessageBox(ex.Message.ToString());
    //        }
    //    }

    //}

    protected void btnBookWice_Click(object sender, EventArgs e)
    {
        Response.Redirect("PendingDC.aspx?cmode=b");
    }

    protected void btnDocWice_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDC.aspx?d=" + txtdocno.Text.Trim() + "&sd=" + Convert.ToInt32(FY) + "&type=without" + "')", true);
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

    protected void TxtEmpCode_TextChanged(object sender, EventArgs e)
    {
        //string ECode = TxtEmpCode.Text.ToString();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDC.aspx?d=" + txtdocno.Text.Trim() + "&sd=" + Convert.ToInt32(FY) + "&type=with" + "')", true);
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
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintDCPending.aspx?d=" + txtdocno.Text.Trim() + "&sd=" + Convert.ToInt32(FY) + "')", true);
        }
        catch
        {
        }
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        Server.Transfer("SendEmail.aspx?d=" + txtdocno.Text.Trim() + "&mailid=" + ViewState["EmailID"] + "&sd=" + Convert.ToInt32(FY) + "&type=with");
    }
}
