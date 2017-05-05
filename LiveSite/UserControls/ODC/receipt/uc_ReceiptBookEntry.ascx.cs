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
using System.IO;


public partial class UserControls_ReceiptBookEntry : System.Web.UI.UserControl
{
    #region Variables
    string lnkarg;
    string fromno;
    string Tono;
    int FromEdit;
    int ToEdit;
    int receiptBookId;
    int ActualReceiptNo;
    int IDNo;
    int NewDocNo;
    string ECode;
    int ACId;
    bool Auth;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
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
            txtempcode.Focus();
            SetView();
            lblrecid.Text = "0";
            EmpId();

        }
        Redio();
    }
    public void Redio()
    {
        if (redio.Items[0].Selected)
        {
            Label1.Text = "M R Code";
            txtReceiptBookId.Visible = false;
            txtReceiptBookId.Text = "";
            txtempcode.Visible = true;
            //txtActualrec.Text = "";

            gvshow.Visible = false;

            //if (txtReceiptBookId.Text == "")
            //{ }
            //else
            //{
            //    ReceiptBookIdBind();
            //}


        }
        else
        {
            txtReceiptBookId.Focus();
            Label1.Text = "Receipt BookId";
            txtempcode.Text = "";
            txtReceiptBookId.Visible = true;
            txtempcode.Visible = false;
            lblempname.Text = "";
            lblempname.Visible = false;
            if (txtReceiptBookId.Text == "")
            {
                gvshow.Visible = false;
            }
            // txtempcode.Text = "";
        }
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Receipt Book";
                Receiptsave.Visible = true;
                pnlshow.Visible = false;
                Panel1.Visible = true;
                gvshow.Visible = false;
                upCounts.Visible = false;
                Button1.Visible = false;
                txtmrcode.Focus();
                PnlRedio.Visible = false;
                //lblID.Text = "0";
                //txtAreaCode.Focus();
                //pnlAreaDetails.Visible = false;
                //pnlArea.Visible = true;
                //btnSave.Visible = true;
                //filter.Visible = false;
                pnlreceiptno.Visible = false;
                gvReceiptEdit.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    //if (redio.Items[0].Selected)
                    //{
                    //    Label1.Text = "Receipt BookId";
                    //    txtReceiptBookId.Visible = true;
                    //    txtempcode.Visible = false;
                    //}
                    //else
                    //{
                    //    Label1.Text = "M R Code";
                    //    txtReceiptBookId.Visible = false;
                    //    txtempcode.Visible = true;
                    //}
                    pageName.InnerHtml = "View Receipt Book";
                    pnlshow.Visible = true;
                    Receiptsave.Visible = false;
                    Panel1.Visible = false;
                    pnlusedDetails.Visible = false;
                    PanelCancelDetalis.Visible = false;
                    btnview.Visible = true;
                    btnSave.Visible = false;
                    Button1.Visible = false;
                    btnview.Text = "View";
                    btnprint.Visible = true;
                    PnlRedio.Visible = true;
                    Redio();
                    //pnlAreaDetails.Visible = true;
                    //pnlArea.Visible = false;
                    //btnSave.Visible = false;
                    //filter.Visible = true;
                    pnlreceiptno.Visible = false;
                    gvReceiptEdit.Visible = false;
                }
                else if (Request.QueryString["a"] == "E")
                {
                    pageName.InnerHtml = "Edit Receipt Book";
                    pnlshow.Visible = false;
                    Receiptsave.Visible = false;
                    pnlshow.Visible = false;
                    Panel1.Visible = false;
                    btnSave.Visible = false;

                    pnlusedDetails.Visible = false;
                    PanelCancelDetalis.Visible = false;
                    btnview.Visible = false;
                    gvshow.Visible = false;
                    Button1.Visible = false;
                    btnview.Text = "View";
                    btnprint.Visible = false;
                    //
                    pnlreceiptno.Visible = true;
                    gvReceiptEdit.Visible = true;
                    lblEditRece1.Visible = true;
                    lblEditRece.Visible = true;
                    PnlRedio.Visible = false;
                }
        }
    }

    protected void GrdCityDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdCityDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                if (Convert.ToInt32(txtfrom.Text.Trim()) >= Convert.ToInt32(txtto.Text.Trim()))
                {
                    message("FromNo should be smaller than ToNo");
                }

                else if (lblrecid.Text == "0")
                {
                    try
                    {
                        if (lblrecid.Text == "0")
                        {
                            lblrecid.Text = "0";
                        }
                        receiptBookId = Convert.ToInt32(lblrecid.Text.Trim());
                        int FromNo = Convert.ToInt32(txtfrom.Text.Trim());
                        //
                        string ECode = txtmrcode.Text.ToString().Split(':')[0].Trim();
                        //txtempcode.Text = ECode;
                        //int FromNo = Convert.ToInt32(txtfrom.Text);

                        int ToNo = Convert.ToInt32(txtto.Text);
                        //DataSet ds = new DataSet();
                        // ds = ReciptBookDetails.Get_Multiplecanceldetails(ECode, FromNo, ToNo);
                        //

                        Auth = ReciptBookDetails.getReciptbook_valid1(FromNo, ToNo);
                        if (Auth)
                        {
                            MessageBox(" No. is Already Exist");
                            txtfrom.Text = "";
                            txtto.Text = "";
                            //txtmrcode.Text = "";
                            txtfrom.Focus();

                        }
                        else
                        {

                        }


                    }
                    catch (Exception ex)
                    {
                    }

                    ReciptBookDetails detl = new ReciptBookDetails();
                    if (lblID.Text != "")
                    {
                        detl.ReceiptBookID = Convert.ToInt32(lblID.Text.Trim());
                        gvshow.Visible = false;

                    }
                    else
                    {
                        if (lblrecid.Text == "0")
                        {


                            detl.ReceiptBookID = Convert.ToInt32("0");
                        }
                        else
                        {

                            int receiptBookId = Convert.ToInt32(lblrecid.Text.Trim());

                            detl.ReceiptBookID = receiptBookId;
                            //////Update Receipt /////////


                            ///////END////////

                        }
                    }
                    detl.EmpCode = txtmrcode.Text.Trim();
                    detl.FromNo = Convert.ToInt32(txtfrom.Text.Trim());
                    detl.ToNo = Convert.ToInt32(txtto.Text.Trim());
                    detl.ActualReceiptNo = Convert.ToInt32(txtActualrec.Text.Trim());
                    detl.CreatedBy = Session["UserName"].ToString();
                    detl.FY = Convert.ToInt32(strFY);
                        //Auth = ReciptBookDetails.Idv_Chetana_Get_Validate_ActualReceiptNO(ActualReceiptNo);
                        //if (Auth)
                        //{
                        //    MessageBox(" No. is Already Exist");
                        //    txtActualrec.Text = "";
                        //    txtActualrec.Text = "";
                        // }
                        //else
                        //{

                    //}
                    detl.IsActive = Convert.ToBoolean(true);
                    EmpId();
                    detl.Save(out IDNo);

                    //txtActualrec.Text = Convert.ToInt32(ACId);
                    lblId3.Text = Convert.ToString("Document NO :" + (IDNo));
                    message("Record Saved Successfully");
                    Receiptsave.Visible = true;
                    pnlshow.Visible = false;
                    gvshow.Visible = false;
                    txtmrcode.Text = "";
                    txtActualrec.Text = "";
                    lblmrName.Text = "";
                    txtfrom.Text = "";
                    txtto.Text = "";
                    Receiptsave.Visible = true;
                    if (lblrecid.Text == "0")
                    {
                        lblId3.Visible = true;
                    }
                    else
                    {
                        lblId3.Visible = true;
                    }
                    pnlshow.Visible = false;
                    Panel1.Visible = true;
                }
                else
                {
                    receiptBookId = Convert.ToInt32(lblrecid.Text.Trim());
                    string SalesManId_Old = txtmrcode.Text.Trim();
                    int ReceiptBookID = receiptBookId;
                    string SalesManCode_New = txtmrcode.Text.Trim();
                    int FromNo_New = Convert.ToInt32(txtfrom.Text);
                    int ToNo_New = Convert.ToInt32(txtto.Text);
                    int ToNo_Old = Convert.ToInt32(lblFromNo_Old.Text);
                    int FromNo_Old = Convert.ToInt32(lblToNo_Old.Text);
                    int ActualReceiptNo = Convert.ToInt32(txtActualrec.Text);
                    DataSet dsEdit = new DataSet();
                    dsEdit = ReciptBookDetails.Idv_Chetana_Edit_Receipt_Book(SalesManId_Old, FromNo_Old,
                           ToNo_Old, SalesManCode_New, FromNo_New, ToNo_New, ReceiptBookID, ActualReceiptNo);
                    if (dsEdit.Tables[0].Rows.Count != 0)
                    {

                        lblEditRece1.Text = dsEdit.Tables[0].Rows[0]["FromNo"].ToString();

                        lblEditRece.Text = dsEdit.Tables[0].Rows[0]["ToNo"].ToString();
                        lblStatus.Text = dsEdit.Tables[0].Rows[0]["ReceiptStatus"].ToString();
                        lblStatus.Visible = true;
                        lblEditRece.Visible = true;
                        lblEditRece1.Visible = true;
                    }
                    //
                    // int receiptBookId = Convert.ToInt32(lblrecid.Text.Trim());
                    // ReceiptBookEdit recEdit = new ReceiptBookEdit();


                    //  recEdit.CreatedBy = Session["UserName"].ToString();
                    // recEdit.Update();
                    // message("Record Updated Successfully");
                    Receiptsave.Visible = true;
                    pnlshow.Visible = false;
                    gvshow.Visible = false;
                    txtActualrec.Text = "";
                    txtmrcode.Text = "";
                    lblmrName.Text = "";
                    txtfrom.Text = "";
                    txtto.Text = "";
                    Receiptsave.Visible = true;
                    pnlshow.Visible = false;
                    Panel1.Visible = true;
                }
            }
        }


        catch (Exception ex)
        {
        }

    }
    public void EmpId()
    {
        // DataSet dsEmp = new DataSet();
        ACId = ReciptBookDetails.IDV_CHETANA_Get_ReceiptBookDetails_MaxID(out ActualReceiptNo);

        txtActualrec.Text = Convert.ToString(ACId);

    }

    protected void txtmrcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtmrcode.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "Employee").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtmrcode.Text = ECode;
            lblmrName.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            txtActualrec.Focus();
            DataTable dt1 = ReciptBookDetails.getReceiptBookDetails(ECode, "1", "2", ActualReceiptNo).Tables[1];
            gvshow.DataSource = dt1;
            gvshow.DataBind();
            gvshow.Visible = true;
            txtfrom.Focus();
        }
        else
        {
            lblmrName.Text = "No such salesman code";
            txtmrcode.Focus();
            txtmrcode.Text = "";
        }
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        ReceiptBookIdBind();
        //DataSet ds = new DataSet();
        //ds = ReciptBookDetails.getReceiptBookDetails(string EmpID);
    }

    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void txtfrom_TextChanged(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["receiptBookIncrement"] != null)
        {
            int ireceiptBookIncrement = Convert.ToInt32(ConfigurationManager.AppSettings["receiptBookIncrement"]);
            if (txtfrom.Text != null || txtfrom.Text != "")
                txtto.Text = Convert.ToString(Convert.ToInt32(txtfrom.Text.Trim()) + ireceiptBookIncrement);
            txtto.Focus();
        }



    }
    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {

        btnprint.Visible = true;
        string ECode = txtempcode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "Employee").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtempcode.Text = ECode;
            lblempname.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            DataTable dt1 = ReciptBookDetails.getReceiptBookDetails(ECode, "1", "2", ActualReceiptNo).Tables[1];
            gvshow.DataSource = dt1;
            gvshow.DataBind();
            gvshow.Visible = true;
            Button1.Visible = false;
        }
        else
        {
            lblempname.Text = "No such salesman code";
            txtempcode.Focus();
            txtempcode.Text = "";
            gvshow.Visible = false;
        }
    }
    protected void gvshow_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ReciptBookDetails update = new ReciptBookDetails();
        Receiptsave.Visible = true;
        pnlshow.Visible = false;
        Panel1.Visible = true;
        lblID.Text = ((Label)gvshow.Rows[e.NewEditIndex].FindControl("lblid")).Text;
        txtmrcode.Text = ((Label)gvshow.Rows[e.NewEditIndex].FindControl("lblempid")).Text;
        txtfrom.Text = ((Label)gvshow.Rows[e.NewEditIndex].FindControl("lblFromNo")).Text.Split('-')[0];
        txtto.Text = ((Label)gvshow.Rows[e.NewEditIndex].FindControl("lblFromNo")).Text.Split('-')[1];
        //update.Save();
    }

    protected void gvshow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Used")
        {
            string empid = txtempcode.Text.ToString();
            if (redio.Items[1].Selected)
            {
                ActualReceiptNo = Convert.ToInt32(txtReceiptBookId.Text.Trim());
            }
            lnkarg = e.CommandArgument.ToString();
            fromno = lnkarg.Split('-')[0].ToString();
            Tono = lnkarg.Split('-')[1].ToString();
            DataTable ds = new DataTable();
            ds = (ReciptBookDetails.getReceiptBookDetails(empid, fromno, Tono, ActualReceiptNo).Tables[2]);

            GridViewUsed.DataSource = ds;
            GridViewUsed.DataBind();
            pnlusedDetails.Visible = true;
            PanelCancelDetalis.Visible = false;
            gvshow.Visible = false;
            Button1.Visible = true;
            //upCounts.Visible = false;
            btnSave.Visible = false;
            btnview.Text = "Back";
            upCounts.Update();
            upDetails.Update();

        }
        else if (e.CommandName == "CancelReceipt")
        {
            if (redio.Items[1].Selected)
            {
                ActualReceiptNo = Convert.ToInt32(txtReceiptBookId.Text.Trim());
            }
            string empid = txtempcode.Text.ToString();
            lnkarg = e.CommandArgument.ToString();
            fromno = lnkarg.Split('-')[0].ToString();
            Tono = lnkarg.Split('-')[1].ToString();
            DataTable ds = new DataTable();
            ds = (ReciptBookDetails.getReceiptBookDetails(empid, fromno, Tono, ActualReceiptNo).Tables[3]);
            GridViewCancel.DataSource = ds;
            GridViewCancel.DataBind();
            pnlusedDetails.Visible = false;
            PanelCancelDetalis.Visible = true;
            gvshow.Visible = false;
            btnSave.Visible = false;
            Button1.Visible = true;
            btnview.Text = "Back";
            upCounts.Update();
            upDetails.Update();

        }
        else if (e.CommandName == "Pending")
        {
            if (redio.Items[1].Selected)
            {
                ActualReceiptNo = Convert.ToInt32(txtReceiptBookId.Text.Trim());
            }
            string empid = txtempcode.Text.ToString();
            lnkarg = e.CommandArgument.ToString();
            fromno = lnkarg.Split('-')[0].ToString();
            Tono = lnkarg.Split('-')[1].ToString();
            DataTable ds = new DataTable();
            ds = (ReciptBookDetails.getReceiptBookDetails(empid, fromno, Tono, ActualReceiptNo).Tables[4]);
            GridViewCancel.DataSource = ds;
            GridViewCancel.DataBind();
            pnlusedDetails.Visible = false;
            PanelCancelDetalis.Visible = true;
            gvshow.Visible = false;
            btnSave.Visible = false;
            Button1.Visible = true;
            btnview.Text = "Back";
            upCounts.Update();
            upDetails.Update();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        upDetails.Update();
        gvshow.Visible = true;

        pnlusedDetails.Visible = false;
        PanelCancelDetalis.Visible = false;
        Button1.Visible = false;

        //GridViewUsed.Visible = false;

    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PrintReceiptBookDetails.aspx?d=" + txtempcode.Text.Trim() + "')", true);
    }
    protected void buttonsave_Click(object sender, EventArgs e)
    {
        int ReceiptNo;
        ReceiptNo = Convert.ToInt32(txtReceiptno.Text.Trim());
        DataTable dt12 = new DataTable();
        dt12 = ChequeBounceDetails.Get_ReceiptViewBookDetails(ReceiptNo).Tables[0];
        if (dt12.Rows.Count != 0)
        {
            gvReceiptEdit.DataSource = dt12;
            gvReceiptEdit.DataBind();
            gvReceiptEdit.Visible = true;

        }
        else
        {
            message("No Record Found");
            gvReceiptEdit.Visible = false;
        }
    }
    protected void gvBouncedetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ReciptBookDetails update = new ReciptBookDetails();
        bool isEditable = Convert.ToBoolean(((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblEditable")).Text);
        if (isEditable == false)
        {
            btnSave.Visible = false;
            MessageBox("This Record is locked for Edit");
            lblIsEditable.Visible = true;

        }
        else
        {
            btnSave.Visible = true;
        }
        Receiptsave.Visible = true;
        pnlshow.Visible = false;
        Panel1.Visible = true;
        gvReceiptEdit.Visible = false;
        pnlreceiptno.Visible = false;

        lblrecid.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblcust_id2")).Text;
        txtmrcode.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lbl_emp2")).Text;
        lblFromNo_Old.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblCheque_Date2")).Text.Split('-')[0];
        lblToNo_Old.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblCheque_Date2")).Text.Split('-')[1];
        txtfrom.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblCheque_Date2")).Text.Split('-')[0];
        txtto.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblCheque_Date2")).Text.Split('-')[1];
        lblmrName.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lbl_BounceAmount2")).Text;
        txtActualrec.Text = ((Label)gvReceiptEdit.Rows[e.NewEditIndex].FindControl("lblActualReceiptEdit")).Text;
        if (txtActualrec.Text == "")
        {
            txtActualrec.Enabled = true;
        }
        else
        {
            txtActualrec.Enabled = false;
        }
    }
    protected void txtReceiptBookId_TextChanged(object sender, EventArgs e)
    {
        ReceiptBookIdBind();
    }
    public void ReceiptBookIdBind()
    {
        btnprint.Visible = true;
        if (txtReceiptBookId.Text == "")
        {
        }
        else
        {

            int ActualReceiptNo = Convert.ToInt32(txtReceiptBookId.Text.Trim());
            //txtempcode.Text = ECode;

            DataTable dt1 = ReciptBookDetails.getReceiptBookDetails(ECode, "1", "2", ActualReceiptNo).Tables[1];
            gvshow.DataSource = dt1;
            if (dt1.Rows.Count != 0)
            {
                gvshow.DataBind();
                gvshow.Visible = true;
                Button1.Visible = false;
                gvshow.Visible = true;

            }
            else
            {
                MessageBox("No Data Found");
                lblempname.Text = "";
                lblempname.Visible = false;
                txtReceiptBookId.Focus();
                txtReceiptBookId.Text = "";
                gvshow.DataSource = null;
                gvshow.Visible = false;

            }
        }
    }
    protected void gvshow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sCanceled = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[15].ToString();
            LinkButton lnCan = (LinkButton)e.Row.FindControl("lnkCancel");
            if (sCanceled == "0") lnCan.Enabled = false;

            string sUsed = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[13].ToString();
            LinkButton lnUsed = (LinkButton)e.Row.FindControl("lnkused");
            if (sUsed == "0") lnUsed.Enabled = false;
        }
    }
}


