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
using System.Web.Services;
using Idv.Chetana.BAL;

public partial class UserControls_ChequeCashFilter : System.Web.UI.UserControl
{
    #region Variables

    
    string ChequeDate2;
    string BankCode;
    string BankName;
    static string check = "";
    int ClientId;
    decimal Receivable  = 0;
    string ChequeNo;
    int Receiptno;
    int ReturnID;
    static decimal tamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string From;
    string To;
    static decimal minusAmt = 0;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
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
            //Response.Write(strFY);

        }

        if (!IsPostBack)
        {
          pnlchequedate.Visible = false;
            SetView();
            pnlothertext.Visible = false;
            lblReceiptNo123.Visible = false;
            if (Request.QueryString["Date"] != null)
            {
                txtdate.Text = Request.QueryString["Date"].ToString();
                txttodate.Text = Request.QueryString["Date"].ToString();
                btnGet_Click(null, null);
            }

            //GrdViewChequedate.Visible = true;
        }
        //if (IsPostBack)
        //{
           
        //Bind_depositDetails();
        //}
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pnlchequedate.Visible = true;
                pnlcust.Visible = true;
                pnldeposit.Visible = false;
                pnlReturnCheck.Visible = false;

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    txtcustomerid.Focus();
                    pnlchequedate.Visible = false;
                    pnlcust.Visible = false;
                    pnldeposit.Visible = true;
                    pnlothertext.Visible = false;
                    pnlReturnCheck.Visible = false;
                    //view.Visible = false;

                }
        }
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
    //protected void view_Click(object sender, EventArgs e)
    //{
    //    string ChequeDate;
    //    string date = txtdate.Text.Split('/')[0] + "/" + txtdate.Text.Split('/')[1] + "/" + txtdate.Text.Split('/')[2];

    //    ChequeDate = Convert.ToString(date);
    //    DataTable dt = new DataTable();
    //    dt = Cheque_CashDetails.Get_ChequeChashReport(ChequeDate).Tables[0];
    //    lblmessage.Text = "";
    //    if (dt.Rows.Count != 0)
    //    {
    //       // txtdate.Text = date;
    //   // DateTime ChequeDate;
    //    //string date = txtdate.Text.Split('/')[1] + "/" + txtdate.Text.Split('/')[0] + "/" + txtdate.Text.Split('/')[2];

    //   // ChequeDate = Convert.ToDateTime(date);
    //        GrdViewChequedate.DataSource = dt; //Cheque_CashDetails.Get_ChequeChashReport(ChequeDate);
    //        GrdViewChequedate.DataBind();
    //    pnlchequedate.Visible = true;
    //    GrdViewChequedate.Visible = true;
    //    }
    //    else
    //    {

    //        GrdViewChequedate.Visible = false;
    //        lblmessage.Text = "No such ChequeDate";
    //        txtdate.Focus();
    //        txtdate.Text = "";
    //    }

    //}
    //protected void txtcustomer_TextChanged(object sender, EventArgs e)
    //{
    //    string CustCode = txtcustomerid.Text.ToString().Split(':')[0].Trim();
    //    DataTable dt = new DataTable();
    //    dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
    //    if (dt.Rows.Count != 0)
    //    {
    //        txtcustomerid.Text = CustCode;
    //        lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
    //        txtcustomerid.Focus();

    //    }


    //    else
    //    {
    //        lblCustName.Text = "No such Customer code";
    //        txtcustomerid.Focus();
    //        txtcustomerid.Text = "";

    //    }
    //}
   
    protected void txtBankName_TextChanged(object sender, EventArgs e)

    {
        BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();


        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
        if (dt.Rows.Count != 0)
        {
            BankName = Convert.ToString(dt.Rows[0]["BankName"]);
        }


        else
        {
            txtBankName.Focus();
           // txtBankName.Text = "";
        }
        
    }
    public void BindLeadgerDetails()
    {

        DataSet ds2 = new DataSet();
        ds2 = Cheque_CashDetails.UnPaidLedgerDetailForClient(ClientId);
        if (ds2.Tables[0].Rows.Count != 0)
        {
            gvLegder.DataSource = ds2;
            gvLegder.DataBind();
            gvLegder.Visible = true;
            pnlothertext.Visible = true;
        }
        else
        {
            message("NO Record Found");
            gvLegder.Visible = false;
            pnlothertext.Visible = false;
        }


    }

    public void Bind_depositDetails()
    {
        //From = txtFromDate1.Text.Split('/')[0] + "/" + txtFromDate1.Text.Split('/')[1] + "/" + txtFromDate1.Text.Split('/')[2];
        //To = txtToDate2.Text.Split('/')[0] + "/" + txtToDate2.Text.Split('/')[1] + "/" + txtToDate2.Text.Split('/')[2];
        //string FromDate = From;
        //string ToDate = To;
        string CustCode = txtcustomerid.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomerid.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            txtcustomerid.Focus();

            //DataTable dt2 = new DataTable();
            //dt2 = Cheque_CashDetails.get_depositDetails(CustCode, FromDate, ToDate).Tables[0];
            //if (dt2.Rows.Count != 0)
            //{
            //    gvDeposit.DataSource = dt2;
            //    gvDeposit.DataBind();
            //    pnlchequedate.Visible = false;
            //    pnlReturnCheck.Visible = false;
            //    pnldeposit.Visible = true;
            //    gvDeposit.Visible = true;
            //}
            //else
            //{
            //    message("No such Client Records");
            //    // lblCustName.Text = "No such Client Records";
            //    txtcustomerid.Focus();
            //    txtcustomerid.Text = "";
            //    gvDeposit.Visible = false;
            //}

        }


        else
        {
            lblCustName.Text = "No such Client";
            txtcustomerid.Focus();
            txtcustomerid.Text = "";

        }
    }
    public void bindData()
    {
        string Fromdate = txtdate.Text.Split('/')[1].ToString() + "/" + txtdate.Text.Split('/')[0].ToString() + "/" + txtdate.Text.Split('/')[2].ToString();
        string Todate = txttodate.Text.Split('/')[1].ToString() + "/" + txttodate.Text.Split('/')[0].ToString() + "/" + txttodate.Text.Split('/')[2].ToString(); 
        //string date = txtdate.Text.Split('/')[0].ToString() + "/" + txtdate.Text.Split('/')[1].ToString() + "/" + txtdate.Text.Split('/')[2].ToString();

        //  ChequeDate = Convert.ToString(Fromdate);
        DataTable dt = new DataTable();
        dt = Cheque_CashDetails.Get_ChequeChashReport(Fromdate, Todate).Tables[0];

        lblmessage.Text = "";
        if (dt.Rows.Count != 0)
        {

            GrdViewChequedate.DataSource = dt;
            GrdViewChequedate.DataBind();
             minusAmt = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
            lblminusamt.Text = string.Format("{0:0.00}",Convert.ToDecimal(dt.Rows[0]["Amount"].ToString()));
            pnlchequedate.Visible = true;
            GrdViewChequedate.Visible = true;
        }
        else
        {

            if (check != "save")
            {
                message("No such ChequeDate");
            }
            GrdViewChequedate.Visible = false;


            txtdate.Focus();

        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        if (check == "save")
        {
            message("Record Saved Successfully");
        }
        if (sender == null)
        {
            check = "";
        }
            bindData();
        
    }
    protected void lblAction_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lblAction = (ImageButton)sender;
         ClientId = Convert.ToInt32(((Label)lblAction.Parent.FindControl("lblcustid")).Text);
         lblCid.Text = lblAction.CommandArgument.ToString();
         lblReceiptNo123.Visible = true;
        lblReceiptNo123.Text= "Receipt No : "+ lblAction.CommandName.ToString();
      //  lblminusamt.Text  = 
        BindLeadgerDetails();
        pnlothertext.Visible = true;
        pnlReturnCheck.Visible = false;
        
        
    }

    //protected void gvDeposit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        Cheque_CashDetails che = new Cheque_CashDetails();
    //        che.CQ_ID = Convert.ToInt32(((Label)gvDeposit.Rows[e.RowIndex].FindControl("lblcq_id")).Text);
    //        che.EmpID = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbl_emp")).Text;
    //        che.CustId = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lblcust_id")).Text;
    //        che.Deposite_Type = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbldeposit_Type")).Text;
    //        che.ChequeDate = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lblCheque_Date")).Text;
    //        che.ChequeNo = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lblche_no")).Text;
    //        che.ReciptNo = Convert.ToInt32(((Label)gvDeposit.Rows[e.RowIndex].FindControl("lblrec_no")).Text);
    //        che.Amount = Convert.ToDecimal(((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbl_Amount")).Text);
    //        che.BankName = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbl_deposit")).Text;
    //        che.DepositDate = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbl_depositDate")).Text;
    //        che.Description = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbl_Remark")).Text;

    //        che.CancelBy = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("lbl_Remark")).Text;
    //       // che.Payee_Bank = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("Payee_Bank")).Text;
    //        che.ISactive = Convert.ToBoolean(((Label)gvDeposit.Rows[e.RowIndex].FindControl("ISactive")).Text);
    //        //che.BankCode = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("BankID")).Text;
    //       // che.BankCode = ((Label)gvDeposit.Rows[e.RowIndex].FindControl("BankCode")).Text;
    //        che.ChequeReturndate = txtReturnDate.Text.Trim();
    //        che.ReturnAmount = Convert.ToDecimal(txtReturnAmount.Text.Trim());
    //        che.RetunRemark = txttRetRemark.Text.Trim();
    //        che.Save();
    //        message("Record Saved Successfully");
    //    }
    //    catch
    //    { }
    //  }

    protected void lnkBounce_Click(object sender, EventArgs e)
    {
        int ReciptNo;
      LinkButton lnkBounce = (LinkButton)sender;
      lblCheckNoRetun.Text = lnkBounce.CommandName.ToString();
        lblreceiptnoret.Text = lnkBounce.CommandArgument.ToString();
        ReciptNo = Convert.ToInt32(lblreceiptnoret.Text);
         DataTable dt12 = new DataTable();
         dt12 = ChequeBounceDetails.Get_ChequeCashBounceDetails(ReciptNo).Tables[0];
            if (dt12.Rows.Count != 0)
            {
                gvBouncedetails.DataSource = dt12;
                gvBouncedetails.DataBind();
                gvBouncedetails.Visible= true;

                pnlReturnCheck.Visible = true;
                pnlchequedate.Visible = false;
                pnlcust.Visible = false;
                pnlothertext.Visible = false;
                pnldeposit.Visible = false;
                gvDeposit.Visible = false;
                GrdViewChequedate.Visible = false;
                buttonsave.Visible = true;
               
            }
      }
    public void bingcustdata()
    {
        From = txtFromDate1.Text.Split('/')[1] + "/" + txtFromDate1.Text.Split('/')[0] + "/" + txtFromDate1.Text.Split('/')[2];
        To = txtToDate2.Text.Split('/')[1] + "/" + txtToDate2.Text.Split('/')[0] + "/" + txtToDate2.Text.Split('/')[2];
        string FromDate = From;
        string ToDate = To;
        string CustCode = txtcustomerid.Text.ToString().Split(':')[0].Trim(); 
        DataTable dt2 = new DataTable();
        dt2 = Cheque_CashDetails.get_depositDetails(CustCode, FromDate, ToDate).Tables[0];
        if (dt2.Rows.Count != 0)
        {
            gvDeposit.DataSource = dt2;
            gvDeposit.DataBind();
            pnlchequedate.Visible = false;
            pnlReturnCheck.Visible = false;
            pnldeposit.Visible = true;
            gvDeposit.Visible = true;
        }
        else
        {
            message("No such Client Records");
            // lblCustName.Text = "No such Client Records";
            txtcustomerid.Focus();
            txtcustomerid.Text = "";
            txtFromDate1.Text = "";
            txtToDate2.Text = "";
            lblCustName.Text = "";
            gvDeposit.Visible = false;
        }
    }
    protected void buttonsave_Click(object sender, EventArgs e)
    {
        try
        {
            ChequeBounceDetails cb = new ChequeBounceDetails();
            cb.AutoId = Convert.ToInt32("0");
            cb.ReceiptNo = Convert.ToInt32(lblreceiptnoret.Text);
            //Convert.ToInt32(lnkBounce.Text);
            cb.ChequeNo = lblCheckNoRetun.Text;
            cb.ChequeReturnDate = txtReturnDate.Text.Split('/')[1].ToString() + "/" + txtReturnDate.Text.Split('/')[0].ToString() + "/" + txtReturnDate.Text.Split('/')[2].ToString();
            cb.ReturnAmount = Convert.ToDecimal(txtReturnAmount.Text.Trim());
            cb.ReturnRemark = txttRetRemark.Text.Trim();
            DateTime Chequedate = Convert.ToDateTime(txtReturnDate.Text.Split('/')[1].ToString() + "/" + txtReturnDate.Text.Split('/')[0].ToString() + "/" + txtReturnDate.Text.Split('/')[2].ToString());
            foreach (GridViewRow gvBouncedetails2 in gvBouncedetails.Rows)
            {
                cb.Amount = Convert.ToDecimal(((Label)gvBouncedetails2.FindControl("lbl_BounceAmount2")).Text);
                cb.Cq_id = Convert.ToInt32(((Label)gvBouncedetails2.FindControl("lblcq_id2")).Text);
                cb.FYfrom = Convert.ToInt32(((Label)gvBouncedetails2.FindControl("lblFinYearFrom")).Text);
                cb.FYto = Convert.ToInt32(((Label)gvBouncedetails2.FindControl("lblFinYearTo")).Text);
                
                DateTime gvChequeDate = Convert.ToDateTime(((Label)gvBouncedetails2.FindControl("lblCheque_Date2")).Text);
                Cheque_CashDetails isacive = new Cheque_CashDetails();
                isacive.CQ_ID = Convert.ToInt32(((Label)gvBouncedetails2.FindControl("lblcq_id2")).Text);
                //isacive.EmpID = ((Label)gvBouncedetails2.FindControl("lbl_emp2")).Text;
                //isacive.CustId = ((Label)gvBouncedetails2.FindControl("lblcust_id2")).Text;
                //isacive.Deposite_Type = ((Label)gvBouncedetails2.FindControl("lbldeposit_Type2")).Text;
                //isacive.ChequeDate = ((Label)gvBouncedetails2.FindControl("lblCheque_Date2")).Text;
                //isacive.ChequeNo = ((Label)gvBouncedetails2.FindControl("lblche_no2")).Text;
                //isacive.ReciptNo = Convert.ToInt32(((Label)gvBouncedetails2.FindControl("lblrec_no2")).Text);
                //isacive.Amount = Convert.ToDecimal(((Label)gvBouncedetails2.FindControl("lbl_BounceAmount2")).Text);
                //isacive.BankName = ((Label)gvBouncedetails2.FindControl("lbl_deposit2")).Text;
                //isacive.DepositDate = ((Label)gvBouncedetails2.FindControl("lbl_depositDate2")).Text;
                //isacive.Description = ((Label)gvBouncedetails2.FindControl("lbl_Remark2")).Text;
                isacive.ISactive = false;
                if (Chequedate <= gvChequeDate)
                {
                    message("ChequeDate should be less than Date");
                 }
                else
                {

                    cb.Save();
                    isacive.Updatebounce();
                    message("Record Saved Successfully");
                    bingcustdata();
                    txtRemark.Text = "";
                    txtReturnDate.Text = "";
                    txtDepositDate.Text = "";
                    lblreceiptnoret.Text = "";
                    lblCheckNoRetun.Text = "";
                    txttRetRemark.Text = "";
                    txtReturnAmount.Text = "";
                }
            }

            txtRemark.Text = "";
            txtReturnDate.Text = "";
            txtDepositDate.Text = "";
            lblreceiptnoret.Text = "";
            lblCheckNoRetun.Text = "";
            txttRetRemark.Text = "";
            txtReturnAmount.Text = "";
            bingcustdata();
            pnlReturnCheck.Visible = false;
            pnlchequedate.Visible = false;
            pnlcust.Visible = false;
            pnlothertext.Visible = false;
            pnldeposit.Visible = true;
            gvDeposit.Visible = true;
            GrdViewChequedate.Visible = false;
            buttonsave.Visible = false;
           
        }
        catch
        { }
    }
    protected void lblupdate_Click(object sender, EventArgs e)
    {
        try
        {

            Button lnkUpdate = (Button)sender;
            TextBox txtRemark = (TextBox)lnkUpdate.Parent.FindControl("txtRemark");
            TextBox txtDepositDate = (TextBox)lnkUpdate.Parent.FindControl("txtDepositDate");
            TextBox txtBankName = (TextBox)lnkUpdate.Parent.FindControl("txtBankName");

            foreach (GridViewRow gv in GrdViewChequedate.Rows)
            {
               

                if (Convert.ToInt32(lblCid.Text.ToString()) == Convert.ToInt32(((Label)gv.FindControl("lblcqid")).Text))
                {
                    if (txtDepositDate.Text != "" && txtBankName.Text != "")
                    {
                        //ddate = Convert.ToDateTime(txtDepositDate.Text.ToString());
                        DateTime ddate;
                        string date = txtDepositDate.Text.Split('/')[1] + "/" + txtDepositDate.Text.Split('/')[0] + "/" + txtDepositDate.Text.Split('/')[2];
                        ddate = Convert.ToDateTime(date);
                        DateTime Cdate;

                        Cdate = Convert.ToDateTime((((Label)gv.FindControl("lblChequeDate")).Text).ToString());
                        if (ddate < Cdate)
                        {
                            MessageBox("Cheque date should be greater than deposited date ");
                        }
                        else
                        {
                            Cheque_CashDetails chk = new Cheque_CashDetails();
                            chk.CQ_ID = Convert.ToInt32(((Label)gv.FindControl("lblcqid")).Text);
                            //chk.EmpID = (((Label)gv.FindControl("lblEmpId")).Text);
                            //chk.CustId = (((Label)gv.FindControl("lblcustid")).Text);
                            chk.EmpID = (((Label)gv.FindControl("lblEmpCode1")).Text);
                            chk.CustId = (((Label)gv.FindControl("lblCustCode1")).Text);
                            chk.ReciptNo = Convert.ToInt32(((Label)gv.FindControl("lblrec")).Text);
                            //  lblReceiptNo123.Text = 
                            chk.Deposite_Type = (((Label)gv.FindControl("lbldepositType")).Text);
                            chk.ChequeDate = (((Label)gv.FindControl("lblChequeDate")).Text);
                            chk.ChequeNo = (((Label)gv.FindControl("lblChequeNo")).Text);
                            chk.Amount = Convert.ToDecimal(((Label)gv.FindControl("lblAmount")).Text);
                            chk.CreatedBy = ((Label)gv.FindControl("lblcreatedby")).Text;
                            //chk.BankCode = ((Label)lnkUpdate.Parent.FindControl("lblBankCode")).Text;
                            chk.Payee_Bank = ((Label)gv.FindControl("lblPayee_Bank")).Text;
                            ///////////ledger entry/////////
                            Ledgerdetails ldpay = new Ledgerdetails();
                            ldpay.Amount = Convert.ToDecimal(((Label)gv.FindControl("lblAmount")).Text);
                            ldpay.CustId = ((Label)gv.FindControl("lblcustid")).Text;
                            ldpay.OtherId = ((Label)gv.FindControl("lblcqid")).Text;
                            ldpay.FY = Convert.ToInt32(strFY);
                            //////////end/////////////
                            foreach (GridViewRow gv1 in gvLegder.Rows)
                            {
                                if ((((CheckBox)gv1.FindControl("chkclose")).Checked) == true)
                                {
                                    //    ///////////Payment pending ///////////
                                    //  ReceivedAmt = ReceivedAmt +  Convert.ToDecimal(((TextBox)gv1.FindControl("txtreceivable")).Text);
                                    //Convert.ToDecimal(ReceivedAmt);

                                    //}

                                    // ReceivedAmt = Convert.ToDecimal(((TextBox)gv1.FindControl("txtreceivable")).Text);

                                    /////////////Reused code////////////
                                    // Ledgerdetails ldpay = new Ledgerdetails();
                                    //ldpay.Amount = Convert.ToDecimal(((Label)gv.FindControl("lblAmount")).Text);
                                    // ldpay.CustId = ((Label)gv.FindControl("lblcustid")).Text;
                                    // ldpay.OtherId = ((Label)gv.FindControl("lblcqid")).Text;
                                    // ldpay.update();
                                    ///////////end////////////////
                                    Receivable = Convert.ToDecimal(((TextBox)gv1.FindControl("txtreceivable")).Text);


                                    LedgerPaymentdetails ld = new LedgerPaymentdetails();

                                    ld.Autoid = Convert.ToInt32("0");
                                    ld.CQ_ID = Convert.ToInt32(lblCid.Text.Trim());
                                    ld.InvoiceNo = Convert.ToDecimal(((Label)gv1.FindControl("lblotherId")).Text);
                                    ld.debitAmount = Convert.ToDecimal(((Label)gv1.FindControl("lblDebitAmount")).Text);
                                    ld.ReceiptAmount = Convert.ToDecimal(((TextBox)gv1.FindControl("txtreceivable")).Text);
                                    ld.ReceiptNo = Convert.ToInt32(((Label)gv.FindControl("lblrec")).Text);

                                    if (Receivable > 0)
                                    {
                                        ld.save();

                                    }
                                }

                                //  message("Record Saved Successfully");
                                // Response.Redirect(Request.RawUrl.Replace("/Website/", "").ToString());

                            }
                            //chk.BankID = Convert.ToInt32(((Label)lnkUpdate.Parent.FindControl("lblBankID")).Text);
                            if (txtDepositDate.Text == "")
                            { ChequeDate2 = ""; }
                            else
                            {

                                ChequeDate2 = txtDepositDate.Text.Split('/')[0] + "/" + txtDepositDate.Text.Split('/')[1] + "/" + txtDepositDate.Text.Split('/')[2];
                                chk.DepositDate = ChequeDate2;
                                if (((Label)gv.FindControl("lblChequeNo")).Text == "")
                                {
                                    string BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();
                                    DataTable dt = new DataTable();
                                    dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
                                    if (dt.Rows.Count != 0)
                                    {
                                        txtBankName.Text = BankCode;
                                        //lblbank.Text = Convert.ToString(dt.Rows[0]["BankName"]);
                                        chk.BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();
                                        chk.Description = txtRemark.Text.Trim().ToString();
                                        chk.ISactive = true;
                                        chk.FinancialYear = Convert.ToInt32(strFY);
                                        chk.Save(1);
                                        ldpay.update(1);

                                        // ld.save();
                                        message("Record Saved Successfully");
                                        bindData();
                                        pnlothertext.Visible = true;
                                        check = "save";
                                        Response.Redirect(Request.RawUrl.Replace("/Website/", "").ToString());
                                    }
                                    else
                                    {
                                        chk.BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();

                                        chk.Description = txtRemark.Text.Trim().ToString();
                                        chk.ISactive = true;
                                        chk.FinancialYear = Convert.ToInt32(strFY);
                                        chk.Save(1);
                                        ldpay.update(1);

                                        // ld.save();
                                        message("Record Saved Successfully");
                                        bindData();
                                        check = "save";
                                        pnlothertext.Visible = true;
                                        Response.Redirect(Request.RawUrl.Replace("/Website/", "").ToString());
                                    }
                                }
                                else
                                {
                                    string BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();

                                    DataTable dt = new DataTable();
                                    dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
                                    if (dt.Rows.Count != 0)
                                    {
                                        txtBankName.Text = BankCode;
                                        //lblbank.Text = Convert.ToString(dt.Rows[0]["BankName"]);
                                        chk.BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();
                                        chk.Description = txtRemark.Text.Trim().ToString();
                                        chk.ISactive = true;
                                        chk.FinancialYear = Convert.ToInt32(strFY);
                                        chk.Save(1);
                                        ldpay.update(1);
                                  

                                        //  ld.save();
                                        message("Record Saved Successfully");
                                        bindData();
                                        check = "save";
                                        pnlothertext.Visible = true;
                                        Response.Redirect(Request.RawUrl.Replace("/Website/", "").ToString());

                                    }


                                    else
                                    {

                                        message("No such Bank code");
                                        txtBankName.Focus();
                                        txtBankName.Text = "";


                                    }
                                }
                            }


                            // }

                        }
                    }

                    else
                    {
                        message("Kindly enter BankName,Date details");

                    }

                }

            }
        }


        catch
        {


        }
    }
   
    protected void txtreceivable_TextChanged(object sender, EventArgs e)
    
    {
        //GridView gvLegder;
        //TextBox txtreceivable = ((TextBox)((TextBox)sender).FindControl("txtreceivable"));
        //if (txtreceivable.Text != "" && txtreceivable.Text != "0")
        //{
        //    lbltotalamt.Text = Convert.ToString(Convert.ToDecimal(lbltotalamt.Text.Trim()) +  Convert.ToDecimal(txtreceivable.Text.Trim()));
        //}
        
    }
   

    protected void gvLegder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            tamount = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtreceivable = (TextBox)e.Row.FindControl("txtreceivable");
            tamount = tamount + Convert.ToDecimal(txtreceivable.Text.Trim());
            txtreceivable.Attributes.Add("onkeyup", "addamount('" + txtreceivable.ClientID + "')");

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblFTotalamount1");
            lbl1.Text = tamount.ToString().Trim();
            lblTotalamtId.Text = lbl1.ClientID.ToString();
           // decimal TminusAmt = minusAmt - Convert.ToDecimal(lbl1.Text.ToString());
           // lblminusamt.Text = TminusAmt.ToString().Trim();

        }


    }
    protected void btngetdata_Click(object sender, EventArgs e)
    {
        bingcustdata();
    }
    protected void txtcustomerid_TextChanged(object sender, EventArgs e)
    {
        Bind_depositDetails();
    }
}
