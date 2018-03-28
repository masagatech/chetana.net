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


public partial class CashEntry : System.Web.UI.UserControl
{
    #region Variables
    int IDNo;
    int NewDocNo;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string Expense;
    string Expensename;
    static decimal amount;
    string date;
    static decimal amount2;
    static decimal amount3;
    string FromDate;
    string ToDate;
    int VoucherNo;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
      
            if (Session["FY"] != "" || Session["FY"] != null)
            {
               
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
      
        if (!IsPostBack)
        {
            SetView();
            lblID.Text = "0";
            lblID1.Text = "0";

            Session["tempdata"] = null;
        }
        if (IsPostBack)
        {
            lblId3.Text = "";
        }
        txtFromDate.Focus();
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
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                txtEMcode.Focus();
                btn_Save.Visible = true;
                pnlCust.Visible = true;
                gvExpense.Visible = true;
                pnlViewexp.Visible = false;
                pnlViewexp.Visible = false;
                lblget.Visible = false;
                gvExp.Visible = false;

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    btn_Save.Visible = false;
                    pnlCust.Visible = false;
                    gvExpense.Visible = false;
                    pnlViewexp.Visible = true;
                    pnlViewexp.Visible = true;
                    lblget.Visible = true;
                    gvExp.Visible = true;
                }
        }
      
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                if (gvExpense.Rows.Count > 0 || gvExpDelete.Rows.Count > 0)
                {
                    PettyCash pt = new PettyCash();
                    pt.VoucherNo = Convert.ToInt32(lblID.Text);
                    pt.PartyCode = txtEMcode.Text.Trim();
                    pt.PartyName = lblshow.Text.Trim();
                    pt.MainRemark = txtRemark.Text.Trim();
                    string vocdate = txtVocDate.Text.Split('/')[1] + "/" + txtVocDate.Text.Split('/')[0] + "/" + txtVocDate.Text.Split('/')[2];
                    pt.VoucherDate = Convert.ToDateTime(vocdate);
                    pt.Created_By = Session["UserName"].ToString();
                    pt.Is_Active = Convert.ToBoolean(true);
                    //if (gvExpense.Rows.Count > 0)
                    //{
                    //  pt.TotalAmount = Convert.ToDecimal(amount + amount);

                    if (gvExpDelete.Rows.Count > 0)
                    {

                        pt.TotalAmount = Convert.ToDecimal(amount2);
                        if (gvExpense.Rows.Count > 0 && gvExpDelete.Rows.Count > 0)
                        {
                            pt.TotalAmount = Convert.ToDecimal(amount + amount2);
                        }
                    }
                    else if (gvExpense.Rows.Count > 0)
                    {
                        pt.TotalAmount = Convert.ToDecimal(amount);
                        if (gvExpense.Rows.Count > 0 && gvExpDelete.Rows.Count > 0)
                        {
                            pt.TotalAmount = Convert.ToDecimal(amount + amount2);
                        }

                    }

                    pt.FY = Convert.ToInt32(strFY);
                    
                    pt.Save(out IDNo, out NewDocNo);
                    lblId3.Text = Convert.ToString("Voucher No :" + (NewDocNo));
                    SaveDetails(IDNo);
                    // lblID1.Text = Convert.ToString("Voucher No :" + (IDNo));
                    //  SaveDetails(IDNo);
                    message("Record save successfully");
                    lblId3.Visible = true;
                    Session["tempdata"] = null;
                    gvExpense.DataBind();
                    txtEMcode.Text = "";
                    txtRemark.Text = "";
                    lblshow.Text = "";
                    txtVocDate.Text = "";

                    gvExpDelete.Visible = false;
                    if (lblID.Text == "0")
                    {
                        lblId3.Visible = true;
                    }
                    else
                    {
                        lblId3.Text = "";
                        pnlCust.Visible = false;
                        pnlViewexp.Visible = true;
                        btn_Save.Visible = false;
                    }
                }
                message("Enter Expence Details");
            }
        }
        catch
        { }
    }
    public DataTable fillExpense()
    {
        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        if (Session["tempdata"] == null)
        {
            dt.Columns.Add("ExpenseCode");
            dt.Columns.Add("ExpenceName");
            dt.Columns.Add("Remark");
            dt.Columns.Add("Date");
            dt.Columns.Add("Amount");


        }
        else
        {
            dt = (DataTable)Session["tempdata"];
        }
        if (dt.Rows.Count == 0)
        {
            date = (txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2]);

            dt.Rows.Add(txtExpance.Text.Trim().ToString(), lblShowExp.Text.Trim().ToString(), txtRemarks.Text.ToString(), (date), Convert.ToDecimal(txtAmount.Text.Trim()));
        }
        else
        {
            string date = (txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2]);
            dt.Rows.Add(txtExpance.Text.Trim().ToString(), lblShowExp.Text.Trim().ToString(), txtRemarks.Text.ToString(), (date), Convert.ToDecimal(txtAmount.Text.Trim()));
        }

        return dt;
    }

    protected void txtEMcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtEMcode.Text.ToString().Split(':', '[', ']')[0].Trim();
        string flag = txtEMcode.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, flag).Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtEMcode.Text = ECode;
            if (flag == "AC")
            {
                lblshow.Visible = true;
                lblshow.Text = dt.Rows[0]["AC_NAME"].ToString();


            }
            else
            {
                lblshow.Visible = true;
                lblshow.Text = dt.Rows[0]["CustName"].ToString();

            }
            txtRemark.Focus();
        }
        else
        {
            lblshow.Text = "No such Party";
            txtEMcode.Focus();
            txtEMcode.Text = "";
        }
    }
    protected void txtExpance_TextChanged(object sender, EventArgs e)
    {
        string ECode2 = txtExpance.Text.ToString().Split(':')[0].Trim();
        string flag = txtExpance.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode2, flag).Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtExpance.Text = ECode2;
            if (flag == "Exp")
            {

                lblShowExp.Text = dt.Rows[0]["AC_NAME"].ToString();
                lblShowExp.Visible = true;
            }

            txtExpance.Focus();
        }
        else
        {
            lblShowExp.Text = "No such Party";
            txtExpance.Focus();
            txtExpance.Text = "";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Enter();
    }
    public void Enter()
    {

        btn_Save.Visible = true;
        Expense = lblShowExp.Text.Trim().ToString();
        Expensename = txtExpance.Text.Trim().ToString();

        DataTable dt = new DataTable();
        if (Session["tempdata"] != null)
        {
            dt = (DataTable)Session["tempdata"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "ExpenseCode = '" + Expensename + "'";
            //  if (bookcode =
            int i = 0;
            foreach (DataRowView row in dv)
            {
                i++;
            }
            if (i == 0)
            {
                Session["tempdata"] = fillExpense();
                dt = (DataTable)Session["tempdata"];

                loder(Expensename + " add successfully");
                message("add successfully");
                txtExpance.Focus();


            }
            else
            {
                //if (i >= 0)
                //{
                //    Session["tempdata"] = fillExpense();
                //    dt = (DataTable)Session["tempdata"];


                message("already added!");
                txtExpance.Text = "";
                txtAmount.Text = "";
                txtDate.Text = "";
                txtRemarks.Text = "";
                lblShowExp.Text = "";
                //}

            }
        }
        else
        {
            Session["tempdata"] = fillExpense();
            dt = (DataTable)Session["tempdata"];
            loder(Expensename + " add successfully");
            message("add successfully");
            txtExpance.Focus();
        }

        gvExpense.DataSource = dt;
        gvExpense.DataBind();
        gvExpense.Visible = true;
        txtExpance.Text = "";
        txtAmount.Text = "";
        txtDate.Text = "";
        txtRemarks.Text = "";
        lblShowExp.Text = "";
    }
    public void SaveDetails(int IDNo)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                PettyCashExpence pte = new PettyCashExpence();

                pte.VoucherNo = IDNo;
                pte.CreatedBy = Session["UserName"].ToString();
                foreach (GridViewRow gv in gvExpense.Rows)
                {
                    pte.IsActive = Convert.ToBoolean(true);
                    pte.Voucher_Detail = Convert.ToInt32(lblID1.Text);
                    pte.ExpenseCode = ((Label)gv.FindControl("lblExpenseHead")).Text;
                    pte.ExpenceName = ((Label)gv.FindControl("lblExpenseValuesave")).Text;
                    pte.Date = Convert.ToDateTime(((Label)gv.FindControl("lbldatesave")).Text);
                    pte.Remark = ((Label)gv.FindControl("lblRemarksave")).Text;
                    pte.Amount = Convert.ToDecimal(((Label)gv.FindControl("lblAmountsave")).Text);
                    
                    pte.Save();
                }
            }
        }
        catch
        { }
    }
    protected void gvExpense_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["tempdata"];
        dt1.Rows[e.RowIndex].Delete();
        gvExpense.DataSource = dt1;
        gvExpense.DataBind();
        Session["tempdata"] = dt1;
    }
    Label lblAmt;
    Label lbltamount;
    protected void gvExpense_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            amount = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblAmt = (Label)e.Row.FindControl("lblAmountsave");
            amount = amount + Convert.ToDecimal(lblAmt.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            lbltamount = (Label)e.Row.FindControl("lbltotalAmount");
            lbltamount.Text = amount.ToString();
            //DDLExpenseHead.Focus();

        }
    }
    protected void lblget_Click(object sender, EventArgs e)
    {
        try
        {
            FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
            ToDate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
            DataTable dt = new DataTable();
            dt = PettyCash.Idv_Chetana_Get_Petty_Expance_View(FromDate, ToDate, Convert.ToInt32(strFY)).Tables[0];
            if (dt.Rows.Count != 0)
            {
                gvExp.DataSource = dt;
                Visibility();
                gvExp.DataBind();
                gvExp.Visible = true;
            }
            else
            {
                gvExp.Visible = false;
                message("No Record Found");
            }

        }
        catch (Exception ex)
        {
            message(ex.Message.ToString());

        }

    }
    protected void viewexp_Click(object sender, EventArgs e)
    {

        LinkButton viewexp = (LinkButton)sender;
        GridViewRow row = (GridViewRow)viewexp.NamingContainer;
        int VoucherNo = Convert.ToInt32(viewexp.CommandArgument.ToString());

        DataTable dt12 = new DataTable();
        dt12 = PettyCashExpence.Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo(VoucherNo).Tables[0];
        if (dt12.Rows.Count != 0)
        {
            gvVoucher.DataSource = dt12;
            gvVoucher.DataBind();
            gvVoucher.Visible = true;

        }
        else
        {
            gvVoucher.Visible = false;
            message("No Records Found");
        }
    }
    //public void BindEdit()
    //{
    //    //int VoucherNO = Convert.ToInt32(txtVoucher.Text);

    //    DataSet ds4 = new DataSet();
    //    ds4 = PettyBillMaster.Idv_Chetana_Petty_VoucherDetails_Edit(VoucherNO);
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {


    //        PettyCash editpet = new PettyCash();
    //        lblID.Text = ds4.Tables[0].Rows[0]["VoucherNo"].ToString();
    //        txtEMcode.Text = ds4.Tables[0].Rows[0]["PartyCode"].ToString();
    //        lblshow.Text = ds4.Tables[0].Rows[0]["PartyName"].ToString();
    //        txtRemark.Text = ds4.Tables[0].Rows[0]["MainRemark"].ToString();
    //        //txtVoucherBill.Text = ds.Tables[0].Rows[0]["VoucherDate"].ToString();
    //        //txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
    //        //Idtotalamount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
    //        // lblfromdate.Text = ds.Tables[0].Rows[0]["FinancialYearFrom"].ToString();
    //        //lbltodate.Text = ds.Tables[0].Rows[0]["FinancialYearTo"].ToString();
    //        editpet.Updated_By = Session["UserName"].ToString();
    //        editpet.Updated_On = Convert.ToDateTime(DateTime.Now.ToString());
    //        pnlCust.Visible = true;

    //        btn_Save.Visible = true;
    //        lblshow.Visible = true;

    //        DataTable dt12 = new DataTable();
    //        dt12 = PettyCashExpence.Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo(VoucherNo).Tables[0];
    //        if (dt12.Rows.Count != 0)
    //        {
    //            gvExpense.DataSource = dt12;
    //            gvExpense.DataBind();
    //            gvExpense.Visible = true;

    //        }
    //        else
    //        {
    //            gvExpense.Visible = false;
    //            message("No Records Found");
    //        }
    //    }
    //}

    protected void gvExpDelete_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            PettyCashExpence pvdetail = new PettyCashExpence();
            pvdetail.Voucher_Detail = Convert.ToInt32(((Label)gvExpDelete.Rows[e.RowIndex].FindControl("lblvoucher_detail")).Text);
            pvdetail.VoucherNo = Convert.ToInt32(((Label)gvExpDelete.Rows[e.RowIndex].FindControl("lblVoucherNo")).Text);
            pvdetail.ExpenceName = ((Label)gvExpDelete.Rows[e.RowIndex].FindControl("lblExpName")).Text;
            pvdetail.Amount = Convert.ToDecimal(((Label)gvExpDelete.Rows[e.RowIndex].FindControl("lblAmount")).Text);
            pvdetail.Date = Convert.ToDateTime(((Label)gvExpDelete.Rows[e.RowIndex].FindControl("lblDate")).Text);
            pvdetail.Remark = ((Label)gvExpDelete.Rows[e.RowIndex].FindControl("lblRemark")).Text;
            pvdetail.UpdatedBy = Session["UserName"].ToString();
            pvdetail.IsActive = Convert.ToBoolean(false);
            pvdetail.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToString());
            pvdetail.Save();
            bindforedit();

      //   gvExpDelete.BottomPagerRow.Cells.Remove();
            gvExpDelete.Visible = true;
            pnlCust.Visible = true;


        }
        catch (Exception ex)
        {

        }
    }
    //public void BindEdit()
    //{
    //    int VoucherNO = Convert.ToInt32(((Label)gvExpDelete.FindControl("lblvoucher_detail")).Text);
    //    DataSet ds = new DataSet();
    //    ds = PettyCash.Idv_Chetana_Get_PettyCashEnter(VoucherNO);
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        PettyCash chkeEdit = new PettyCash();
    //        lblID.Text = ds.Tables[0].Rows[0]["VoucherNo"].ToString();
    //        txtEMcode.Text = ds.Tables[0].Rows[0]["PartyCode"].ToString();
    //        lblshow.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
    //        txtRemark.Text = ds.Tables[0].Rows[0]["MainRemark"].ToString();
    //        chkeEdit.TotalAmount = amount + amount2;
    //        chkeEdit.Updated_By = Session["UserName"].ToString();
    //        chkeEdit.Updated_On = Convert.ToDateTime(DateTime.Now.ToString());
    //        pnlCust.Visible = true;
    //        btn_Save.Visible = true;


    //    }
    //}
    Label lblAmt2;
    Label lbltamount2;
    protected void gvExpDelete_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            amount2 = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblAmt2 = (Label)e.Row.FindControl("lblAmount");
            amount2 = amount2 + Convert.ToDecimal(lblAmt2.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            lbltamount2 = (Label)e.Row.FindControl("lbltotalAmount");
            lbltamount2.Text = amount2.ToString();
        }
    }
    protected void gvExp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PettyCash chkeEdit = new PettyCash();
        lblID.Text = ((Label)gvExp.Rows[e.NewEditIndex].FindControl("lblVoucherNo")).Text;
        VoucherNo = Convert.ToInt32(lblID.Text);
        txtEMcode.Text = ((Label)gvExp.Rows[e.NewEditIndex].FindControl("lblpartycode")).Text;
        lblshow.Text = ((Label)gvExp.Rows[e.NewEditIndex].FindControl("lblPartyName")).Text;
        txtRemark.Text = ((Label)gvExp.Rows[e.NewEditIndex].FindControl("lblRemarkedit")).Text;
        txtVocDate.Text = ((Label)gvExp.Rows[e.NewEditIndex].FindControl("lbldate")).Text;
        chkeEdit.TotalAmount = amount + amount2;
        chkeEdit.Updated_By = Session["UserName"].ToString();
        chkeEdit.Updated_On = Convert.ToDateTime(DateTime.Now.ToString());
        pnlCust.Visible = true;
        btn_Save.Visible = true;
        gvExp.Visible = false;
        pnlViewexp.Visible = false;
        gvVoucher.Visible = false;
        bindforedit();

    }
    public void bindforedit()
    {
        int VoucherNo = Convert.ToInt32(lblID.Text);
        DataTable dt12 = new DataTable();
        dt12 = PettyCashExpence.Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo(VoucherNo).Tables[0];
        if (dt12.Rows.Count != 0)
        {
            gvExpDelete.DataSource = dt12;
            gvExpDelete.DataBind();
            gvExpDelete.Visible = true;



        }
        else
        {
            amount2 = Convert.ToDecimal(0);
            gvExpDelete.DataSource = dt12;
            gvExpDelete.DataBind();
            gvExpDelete.Visible = true;
            message("No Records Found");

        }

    }
    Label lblAmt3;
    Label lbltamount3;
    protected void gvExp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            amount3 = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblAmt3 = (Label)e.Row.FindControl("lblTotalAmount");
            amount3 = amount3 + Convert.ToDecimal(lblAmt3.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            lbltamount3 = (Label)e.Row.FindControl("lbltotalAmount2");
            lbltamount3.Text = amount3.ToString();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];


        ToDate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintPettyCash.aspx?d=" + FromDate + "&sd=" + ToDate + "')", true);
        }
        catch
        {
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {


            ImageButton imgdelete = (ImageButton)sender;
            PettyCash chkeEdit = new PettyCash();
            lblID.Text = ((Label)imgdelete.Parent.FindControl("lblVoucherNo")).Text;
            VoucherNo = Convert.ToInt32(lblID.Text);
            chkeEdit.VoucherNo = VoucherNo;
            chkeEdit.Updated_By = Session["UserName"].ToString();
            chkeEdit.Updated_On = Convert.ToDateTime(DateTime.Now.ToString());
            chkeEdit.TotalAmount = 0;
            chkeEdit.Is_Active = false;
            int a = 0;
            chkeEdit.Save(out a);
            MessageBox("Record deleted successfully");
            //GridView grd = (GridView)imgdelete.Parent;
            GridViewRow gvr = (GridViewRow)imgdelete.NamingContainer;
            //Get rowindex
            int rowindex = gvr.RowIndex;
            gvr.Visible = false;


        }
        catch (Exception ex)
        {
            MessageBox("Record not delete due to : " + ex.Message.ToString());

        }
    }


    public void Visibility()
    {
        string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();

        if (page == "pettycashentrynew_view.aspx")
        {
            gvExp.Columns[5].Visible = false;
            gvExp.Columns[6].Visible = false;
        }
        else if (page == "pettycashentrynew_edit.aspx")
        {   
            gvExp.Columns[6].Visible = false;
        }
        else if (page == "pettycashentrynew.aspx")
        {
            gvExp.Columns[5].Visible = false;
        }

    }

}

