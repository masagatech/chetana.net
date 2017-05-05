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
using System.Xml;
using System.Xml.Linq;
using Idv.Chetana.BAL;
using Idv.Chetana.Common;
using Other_Z;
#endregion

public partial class UserControls_uc_ConfirmDC : System.Web.UI.UserControl
{
    #region Variables
    decimal SubDocNo = 0;
    bool Auth = false;
    static int quantity = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    string strChetanaCompanyName = "cppl";
    string strFY;
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
            datewise();
            //GetValidation(4, Convert.ToInt32(Session["Role"]));
            //Rptrpending.DataSource = Specimen.Get_PendingDocNo();
            //Rptrpending.DataBind();
            txtempc.Visible = false;
            lblemp.Visible = false;
        }
        if (add)
        {
            btnconfirm.Enabled = true;
            btnPrint.Enabled = true;
        }

    }
    #endregion

    #region Events

    protected void btnget_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = true;
        btnconfirm.Enabled = true;
        docno.InnerHtml = txtdocno.Text.Trim();
        txtempc.Visible = true;
        lblemp.Visible = true;
        DataSet ds6 = new DataSet();
        ds6 = SpecimanDetails.Idv_Get_SpecimenDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno");
        grdconfirm.DataSource = ds6.Tables[0]; 
        grdconfirm.DataBind();
        lblempname1.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0][0]) + " " + Convert.ToString(ds6.Tables[1].Rows[0][1]);
        lblspinstruct.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["SpInstruction"]);
        lbldescription.InnerHtml = Convert.ToString(ds6.Tables[1].Rows[0]["Description"]);
        string jv = "";
        if (grdconfirm.Rows.Count <= 0)
        {
            btnconfirm.Visible = false;
            btnPrint.Visible = false;

            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmDC1_btnconfirm').style.display='none';";
        }
        else
        {
            btnconfirm.Visible = true;
            btnPrint.Visible = true;
            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmDC1_btnconfirm').style.display='visible';";
        }
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);
        txtempc.Focus();
        
       
    }

    #endregion

    #region Events

    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        btnconfirm.Enabled = false;
        Auth = Specimen.Get_DocumentNum_Authentication(Convert.ToInt32(txtdocno.Text));
        SubDocNo = Convert.ToDecimal(SpecimenConfirmQtyDetails.Get_SpecimenDetails_SubDocNo_ByDocID(Convert.ToInt32(txtdocno.Text)).Rows[0][0].ToString());
        if (Auth)
        {
            MessageBox("Document no is not available");
            txtdocno.Focus();

        }

        else
        {

            SpecimenConfirmQtyDetailsNew _objSpecimenNew = new SpecimenConfirmQtyDetailsNew();


            SpecimenConfirmQtyDetails _objSpecimenConfirmQtyDetails = new SpecimenConfirmQtyDetails();
            //Specimen _objspecimen = new Specimen();
            //SpecimentoGodown _objSpecimentoGodown = new SpecimentoGodown();
            int DocId = 0;
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode objrootnode = doc.CreateElement("rt");
              
                foreach (GridViewRow Row in grdconfirm.Rows)
                {

                    XmlNode surootnode = doc.CreateElement("i");

                    XmlNode sid = doc.CreateElement("sid");
                    sid.InnerText = ((Label)Row.FindControl("lblspecidatils")).Text.Trim();
                    surootnode.AppendChild(sid);


                    string Qty = ((TextBox)Row.FindControl("lblavailable")).Text.Trim();
                    if (Qty == "")
                    {
                        Qty = "0";
                    }
                    XmlNode aq = doc.CreateElement("aq");
                    aq.InnerText = Qty;
                    surootnode.AppendChild(aq);
                    objrootnode.AppendChild(surootnode);
                    _objSpecimenNew.Doc_no = Convert.ToInt32(((Label)Row.FindControl("lbldocNo")).Text.Trim());
                    
                }
                _objSpecimenNew.EmpId = txtempc.Text.Trim();
                _objSpecimenNew.SubDocNo = SubDocNo;
                _objSpecimenNew.XML = objrootnode.OuterXml.ToString();
                _objSpecimenNew.Save();

                //_objSpecimenConfirmQtyDetails.Save();
                //_objSpecimentoGodown.EmpID=
                //_objSpecimentoGodown.CreatedBy = Session["UserName"].ToString();
                //_objSpecimentoGodown.SaveGodown();

                //_objspecimen.DocNo = DocId;
                //_objspecimen.IsConfirm = true;
                //_objspecimen.IsApproved = false;
                //_objspecimen.IsCanceled = false;
                //_objspecimen.update();
                grdconfirm.DataBind();
                MessageBox("DC Confirm successfully for document no. " + txtdocno.Text);
                docno.InnerHtml = "Last confirm doc no. : " + docno.InnerHtml;
                callreseter();
                txtempc.Text = "";
                lblEmpName.Text = "";
                txtempc.Visible = false;
                lblEmpName.Visible = false;
                lblemp.Visible = false;
                btnconfirm.Enabled = true;
                btnPrint.Visible = false;
                string jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmDC1_btnconfirm').style.display='none';";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);

                upOrderNO.Update();
            }

            catch (Exception ex)
            {
                MessageBox(ex.Message.ToString());
            }


        }

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

    //protected void txtdocno_TextChanged(object sender, EventArgs e)
    //{
    //    //bool Auth = Specimen.Get_DocumentNum_Authentication(Convert.ToInt32(txtdocno.Text));
    //    //if (Auth)
    //    //{
    //    //    MessageBox("Document no is not available");
    //    //    txtdocno.Focus();
    //    //    btnget.Enabled = false;
    //    //}
    //    //else
    //    //{
    //    //    btnget.Enabled = true;
    //    //}

    //}btncancel_Click

    protected void btnBookWice_Click(object sender, EventArgs e)
    {
        Response.Redirect("Confirm_DC.aspx?cmode=b");
    }

    protected void btnDocWice_Click(object sender, EventArgs e)
    {
        Response.Redirect("Confirm_DC.aspx?cmode=d");
    }

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


    protected void txtempc_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtempc.Text.Split(Constants.splitseperator)[0].ToString().Trim();

        DataTable dt = new DataTable();
        dt = Employee.Get_EmployeeName(ECode).Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtempc.Text = ECode;
            lblEmpName.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            grdconfirm.Focus();

        }
        else
        {
            lblEmpName.Text = "No Such Salesman Code";
            txtempc.Focus();
            txtempc.Text = "";
        }

    }
    protected void TxtEmpCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = TxtEmpCode.Text.ToString();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PendingDCReport1.aspx?d=" + txtdocno.Text.Trim() + "')", true);
        }
        catch
        {
        }
    }
    protected void grdconfirm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblqty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalQty");
            lbl1.Text = quantity.ToString().Trim();
        }
    }

    protected void RdlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Employee")
        {
            BindEmployee();
            Pnlcust.Visible = true;
            pnlDate.Visible = false;
            pnlDetails.Visible = false;
            Rptrpending.Visible = true;
            Rptrpending.DataBind();
            pnlconfirm.Visible = true;
            btnBookWice.Visible = false;
            DDLEmployee.Focus();
        }
        //else if (RdBValue == "All")
        //{
        //    Pnlcust.Visible = false;
        //    pnlDate.Visible = false;
        //    Rptrpending.Visible = true;
        //    Rptrpending.DataSource = Specimen.Get_PendingDocNo("All", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), "");
        //    Rptrpending.DataBind();
        //    upOrderNO.Update();
        //    pnlconfirm.Visible = true;
        //    pnlDetails.Visible = false;
        //    btnBookWice.Visible = true;
        //}
        else
        {
            datewise();
            Rptrpending.DataBind();
        }

    }
    public void callreseter()
    {
        RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Employee")
        {
            Rptrpending.DataSource = Specimen.Get_PendingDocNo("salesman", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), DDLEmployee.SelectedValue.ToString());
            Rptrpending.DataBind();
        }
        else if (RdBValue == "All")
        {
           
            Rptrpending.DataSource = Specimen.Get_PendingDocNo("All", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), "");
            Rptrpending.DataBind();
           
        }
        else
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
                Rptrpending.DataSource = Specimen.Get_PendingDocNo("datewise", fdate, tdate, Convert.ToInt32(strFY), "");
                Rptrpending.DataBind();
                pnlconfirm.Visible = true;
                pnlDetails.Visible = false;
            }
            upOrderNO.Update();
        }
        pnlDetails.Visible = false;
    
    }
    public void datewise()
    {
        Pnlcust.Visible = false;
        Rptrpending.Visible = true;
        pnlDate.Visible = true;
        upOrderNO.Update();
        pnlconfirm.Visible = true;
        pnlDetails.Visible = false;
        btnBookWice.Visible = false;
        RdlView.SelectedIndex = 0;
        txtFromDate.Focus();
    }

    #region Bind Employee
    public void BindEmployee()
    {
        DDLEmployee.Items.Clear();
        //DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer");
        //DDLEmployee.DataSource = Specimen.Get_PedingDocNo_Employee(Convert.ToInt32(strFY));
        DDLEmployee.DataSource = Specimen.Get_PedingDocNo_Employee(Convert.ToInt32(strFY));
        DDLEmployee.DataBind();
        DDLEmployee.Items.Insert(0, new ListItem("- Select Employee -", "0"));
    }
    #endregion

    protected void btnemployee_Click(object sender, EventArgs e)
    {
        Rptrpending.DataSource = Specimen.Get_PendingDocNo("salesman", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), DDLEmployee.SelectedValue.ToString());
        Rptrpending.DataBind();
        pnlconfirm.Visible = true;
        pnlDetails.Visible = false;
        upOrderNO.Update();
    }
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
            Rptrpending.DataSource = Specimen.Get_PendingDocNo("datewise", fdate, tdate, Convert.ToInt32(strFY), "");
            Rptrpending.DataBind();
            pnlconfirm.Visible = true;
            pnlDetails.Visible = false;
        }
        upOrderNO.Update();
    }
}


