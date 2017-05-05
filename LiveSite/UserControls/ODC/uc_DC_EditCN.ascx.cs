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

#endregion

public partial class UserControls_ODC_uc_DC_EditCN : System.Web.UI.UserControl
{
    #region Variables
    static string CustCode;
    int CNNo;
    //static int quantity = 0;
    //static decimal tamount = 0;
    //static decimal tnamount = 0;
    string cust;
    static decimal tnamount = 0;
    static int quantity = 0;
    static decimal tamount = 0;

    string frdate;
    string todate;
    DateTime fdt;
    DateTime tdt;

    string cndate;
    DateTime cndt;
    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion

    #region Pageload
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
            //Response.Write(strFY);
        }

        if (!Page.IsPostBack)
        {
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            PnlAddbk.Visible = false;
            btn_Save.Visible = false;
            PnlPrint.Visible = false;
            btnPrint.Visible = false;
            txtFromDate.Focus();
            BindDDLstd();
            Session["tempDCData1"] = null;
        }
    }
    #endregion

    #region Events

    #region Click
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        cndate = txtCNDate.Text.Split('/')[2] + "/" + txtCNDate.Text.Split('/')[1] + "/" + txtCNDate.Text.Split('/')[0];
        cndt = Convert.ToDateTime(cndate);

        int r1 = grdBookDetails.Rows.Count;
        int cntr1 = 0;
        if (Session["UserName"] != null)
        {
            CNNo = Convert.ToInt32(txtCnno.Text.Trim());

            CreditNote _obedtcn = new CreditNote();
            LedgerCN _obedtld = new LedgerCN();

            try
            {
                foreach (GridViewRow Row in grdBookDetails.Rows)
                {
                    CheckBox chkBxSelect = (CheckBox)Row.FindControl("chkBxSelect");

                    if (chkBxSelect != null)
                    {
                        if (chkBxSelect.Checked == true)
                        {
                            // bool chkbx = ((CheckBox)Row.FindControl("chkBxSelect")).;

                            string RQty = (((TextBox)Row.FindControl("txtretquty")).Text.Trim());
                            //string DfQty = ((TextBox)Row.FindControl("txtdefquty")).Text;
                            string CrQty = (((TextBox)Row.FindControl("txtquty")).Text.Trim());
                            string AtID = (((Label)Row.FindControl("lblDAutoID")).Text.Trim());

                            _obedtcn.AutoID = Convert.ToInt32(AtID);
                            _obedtcn.CNNo = CNNo;
                            //_obedtcn.CustCode = (DDLCustomer.SelectedValue);
                            _obedtcn.CustCode = CustCode; //txtcustomer.Text.Trim().ToString();
                            _obedtcn.BookCode = (((Label)Row.FindControl("lblBookCode")).Text.Trim());
                            _obedtcn.Rate = Convert.ToDecimal(((TextBox)Row.FindControl("txtrate")).Text.Trim());
                            _obedtcn.Discount = Convert.ToDecimal(((TextBox)Row.FindControl("txtDiscount")).Text.Trim());
                            _obedtcn.ReturnQty = Convert.ToInt32(CrQty);
                            _obedtcn.Comment = (((TextBox)Row.FindControl("txtcmmt")).Text.Trim());
                            _obedtcn.IsActive = true;
                            _obedtcn.UpdatedBy = Session["UserName"].ToString();
                            _obedtcn.Flag = (((Label)Row.FindControl("lblflag")).Text.Trim());
                            _obedtcn.TotReturnQty = Convert.ToInt32(RQty);
                            _obedtcn.DefectQty = 0;
                            _obedtcn.IsDeleted = false;
                            _obedtcn.strFY = Convert.ToInt32(strFY);
                            _obedtcn.CNDate = cndt;
                            _obedtld.CNDate = cndt;
                            if (txtGCN.Text != "")
                            {
                                _obedtcn.GCN = Convert.ToInt32(txtGCN.Text);
                            }
                            else
                            {
                                _obedtcn.GCN = 0;
                            }
                            if (txtSCN.Text != "")
                            {
                                _obedtcn.SCN = Convert.ToInt32(txtSCN.Text);
                            }
                            else { _obedtcn.SCN = 0; }
                            _obedtcn.LrNo = txtlRNO.Text.Trim().ToString();
                            _obedtcn.TransportName = lbltransporter.Text.Trim().ToString();
                            _obedtcn.Update_CN(Convert.ToInt32(strFY));
                            cntr1 = cntr1 + 1;
                        }
                    }
                }
                //_obedtcn.AutoID = Convert.ToInt32(AtID);
                //_obedtcn.CNNo = CNNo;
                //_obedtcn.CustCode = (DDLCustomer.SelectedValue);
                //_obedtcn.BookCode = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblBookCode")).Text;
                //_obedtcn.Rate = Convert.ToDecimal(((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtrate")).Text.Trim());
                //_obedtcn.Discount = Convert.ToDecimal(((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtDiscount")).Text.Trim());
                //_obedtcn.ReturnQty = Convert.ToInt32(CrQty);
                //_obedtcn.Comment = ((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtcmmt")).Text;
                //_obedtcn.IsActive = true;
                //_obedtcn.UpdatedBy = Session["UserName"].ToString();
                //_obedtcn.Flag = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblflag")).Text;
                //_obedtcn.TotReturnQty = Convert.ToInt32(RQty);
                //_obedtcn.DefectQty = 0;
                //_obedtcn.IsDeleted = false;

                //_obedtcn.Update_CN();

                if (cntr1 == 0)
                {
                    MessageBox("Select Record To Update");
                }
                if (cntr1 > 0)
                {
                    _obedtld.CNNo = CNNo;
                    _obedtld.strFY = Convert.ToInt32(Convert.ToInt32(strFY));
                    _obedtld.CNDate = cndt;
                    if (ISExcise.Checked == true)
                    {
                        _obedtld.IsExciseApplicable = "1";
                    }
                    else
                    {
                        _obedtld.IsExciseApplicable = "0";

                    }
                    _obedtld.Ledger_CN("ExiseApply");

                    MessageBox("Record Updated Successfully");
                    CustCode = null;
                    txtcustomer.Text = "";
                    lblCustName.Text = "";
                    Bindgrdcn();

                    quantity = 0;
                    tamount = 0;

                    DataTable dt1 = new DataTable();
                    dt1 = DCReturnBook.GetCustAddress(cust, "CNCustlist").Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        lblCNNo.Text = (txtCnno.Text.Trim());
                        lblCustName1.Text = dt1.Rows[0]["CustName"].ToString();
                        lblCustAddress.Text = dt1.Rows[0]["Address"].ToString();
                    }
                    PnlAddbk.Visible = false;
                    btn_Save.Visible = false;
                    PnlPrint.Visible = true;
                    btnPrint.Visible = true;
                }
            }
            catch
            {
            }
            btnPrint.Focus();
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        lblviewCNNo.Text = txtCnno.Text.Trim();
        CNNo = Convert.ToInt32(txtCnno.Text.Trim());
        // Bindgrdcn();
        //grdcn.DataSource = CreditNote.PrintCN(CNNo);
        //grdcn.DataBind();
        DataSet grid = new DataSet();
        grid = CreditNote.EditCN(Convert.ToInt32(strFY), CNNo);
        grdBookDetails.DataSource = grid;
        grdBookDetails.DataBind();
        Session["tempDCData1"] = grid.Tables[0];
        DataSet ds6 = new DataSet();
        ds6 = CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);

        if (ds6.Tables[1].Rows.Count > 0)
        {
            txtCNDate.Text = ds6.Tables[1].Rows[0]["CNDate"].ToString();
            lblCustN.Text = ds6.Tables[1].Rows[0]["CustName"].ToString();
            lbledit.Text = Convert.ToInt32(ds6.Tables[1].Rows[0]["IsEdit"]).ToString();
            txtGCN.Text = ds6.Tables[1].Rows[0]["GCN"].ToString();
            txtSCN.Text = ds6.Tables[1].Rows[0]["SCN"].ToString();
            txtlRNO.Text = ds6.Tables[1].Rows[0]["LrNo"].ToString();
            lbltransporter.Text = ds6.Tables[1].Rows[0]["TransportName"].ToString();
            lblflagdc.Text = ds6.Tables[1].Rows[0]["Flag"].ToString();
            CustCode = ds6.Tables[1].Rows[0]["CustCode"].ToString();
            if (ds6.Tables[1].Rows[0]["IsExciseApplicable"].ToString() == "1")
            {
                ISExcise.Checked = true;
            }
            else
            {
                ISExcise.Checked = false;
            }
        }

        if (lbledit.Text == "0")
        {
            btn_Save.Enabled = false;
            btn_Save.BorderColor = System.Drawing.Color.Red;
            btn_Save.ToolTip = "Record Editing Locked";
        }
        else
        {
            btn_Save.BorderColor = System.Drawing.Color.Green;
            btn_Save.Enabled = true;
            btn_Save.ToolTip = "";
        }

        btn_Save.Visible = true;
        PnlAddbk.Visible = true;

        PnlPrint.Visible = false;
        btnPrint.Visible = false;

        grdBookDetails.Focus();
        //UpdatePanel1.Update();
    }
    protected void btngetcust_Click(object sender, EventArgs e)
    {
        Pnl2.Visible = false;
        PnlAddbk.Visible = false;
        btn_Save.Visible = false;
        PnlPrint.Visible = false;
        btnPrint.Visible = false;

        frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        fdt = Convert.ToDateTime(frdate);
        tdt = Convert.ToDateTime(todate);

        if (tdt >= fdt)
        {
            if (RdbtnSelect.SelectedValue == "CN")
            {
                Pnl1.Visible = false;

                RptrCN2.DataSource = CreditNote.GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                RptrCN2.DataBind();

                RptrCN2.Visible = true;
                // RptrCN2.Visible = true;
                PnlPrint.Visible = false;
                Pnl2.Visible = true;
                PnlAddbk.Visible = false;
            }
            if (RdbtnSelect.SelectedValue == "CustomerwiseCN")
            {
                DataSet ds = new DataSet();
                ds = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DDLCustomer.DataSource = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                    DDLCustomer.DataBind();
                    DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
                    Pnl1.Visible = true;
                }
                else
                {
                    MessageBox("Records Not Available ");
                }
            }
        }
        else
        {
            MessageBox("From Date is greater than To Date");
        }
        //else
        //if (Convert.ToDateTime(todate) == Convert.ToDateTime(frdate))
        //{
        //    MessageBox("From Date and To Date are similar");

        //}
        DDLCustomer.Focus();
    }
    protected void btnaddBooks_Click(object sender, EventArgs e)
    {
        string bookcode = txtbkcod.Text.Split(':')[0].Trim();
       
        {

            //  bookname = txtbkcod.Text.Split(':')[2].Trim();

            BindGrd2(fillTempBookData(bookcode, CustCode));
            //if (grdBookDetails.Rows.Count > 0)
            //{

            //    btnSave.Visible = true;
            //    Panel2.Visible = true;
            //    PnlPrint.Visible = false;
            //    btnPrint.Visible = false;
            //    txtcustomer.Enabled = false;
            //    txtcustomer.ToolTip = "Remove data first from grid..";
            //}
            //else
            //{
            //    btnSave.Visible = false;
            //    Panel2.Visible = false;
            //    PnlPrint.Visible = false;
            //    btnPrint.Visible = false;
            //    MessageBox("Record Not Available");

            //}
            clearAddBooks();

        }
        txtbkcod.Focus();
    }

    #endregion

    #region TextChanged

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        Pnl1.Visible = false;
        Pnl2.Visible = false;
        PnlAddbk.Visible = false;
        btn_Save.Visible = false;
        PnlPrint.Visible = false;
        btnPrint.Visible = false;
    }
    protected void txttoDate_TextChanged(object sender, EventArgs e)
    {
        Pnl1.Visible = false;
        Pnl2.Visible = false;
        PnlAddbk.Visible = false;
        btn_Save.Visible = false;
        PnlPrint.Visible = false;
        btnPrint.Visible = false;
    }

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        PnlPrint.Visible = false;
        btnPrint.Visible = false;

        CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "CustomerNAC").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustNameCA"]);
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
        // btngetRec.Focus();
    }

    protected void lbltransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (lbltransporter.Text != "")
            {
                string TransCode = (lbltransporter.Text.ToString().Split(':', '[', ']')[0].Trim());
                flag1 = (lbltransporter.Text.ToString().Split('[', ']')[1].Trim());

                if (flag1 == "Emp")
                {
                    string Empname = (lbltransporter.Text.ToString().Split(':', '[')[2].Trim());
                    (lbltransporter.Text) = Empname;
                }
                else if (flag1 == "Trans")
                {
                    (lbltransporter.Text) = TransCode;
                }
                else
                {
                    (lbltransporter.Text) = "No such record found";
                }

            }
        }

        catch
        {

        }
    }
    //protected void txtbkcod_TextChanged(object sender, EventArgs e)
    //{
    //    //txtbookqty.Focus();
    //}
    #endregion

    #region IndexChanged
    protected void DDLstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender123.ContextKey = "book_" + DDLstandard.SelectedItem.Text;
        txtbkcod.Focus();
    }

    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        tdt = Convert.ToDateTime(todate);
        fdt = Convert.ToDateTime(frdate);

        // Rptrpending.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(DDLCustomer.SelectedValue));
        RptrCN2.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(strFY), (DDLCustomer.SelectedValue), "All", fdt, tdt);
        RptrCN2.DataBind();

        //RptrCN2.DataSource = CreditNote.GetCNNo_byCust((DDLCustomer.SelectedValue), "Manual");
        //RptrCN2.DataBind();

        RptrCN2.Visible = true;
        // RptrCN2.Visible = true;
        Pnl2.Visible = true;

        //DataTable dt = new DataTable();
        //dt = DCReturnBook.GetCustAddress((DDLCustomer.SelectedValue), "CNCustlist").Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    lblCustName.Text = dt.Rows[0]["CustName"].ToString();
        //    lblCustAddress.Text = dt.Rows[0]["Address"].ToString();
        //}

        if (DDLCustomer.SelectedIndex == 0)
        {
            Pnl2.Visible = false;
        }
        PnlAddbk.Visible = false;
        btn_Save.Visible = false;
        PnlPrint.Visible = false;
        btnPrint.Visible = false;
        Pnl2.Focus();
    }
    #endregion

    #region Gridevents
    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void txtBookName_TextChanged(object sender, EventArgs e)
    {
        TextBox txtBookName = ((TextBox)((TextBox)sender).FindControl("txtBookName"));
        Label lblBookCode = ((Label)((TextBox)sender).FindControl("lblBookCode"));
        Label lblStandard = ((Label)((TextBox)sender).FindControl("lblStandard"));
        Label lblMedium = ((Label)((TextBox)sender).FindControl("lblMedium"));

        lblBookCode.Text = txtBookName.Text.ToString().Split(':')[0].Trim();

        lblStandard.Text = txtBookName.Text.ToString().Split(':')[4].Trim();
        lblMedium.Text = txtBookName.Text.ToString().Split(':')[6].Trim();
        txtBookName.Text = txtBookName.Text.ToString().Split(':')[2].Trim();
        //string BookName = txtBookName.Text.ToString().Split(':')[1].Trim();

        //txtCN.Text = txtreturn.Text;
    }
    protected void txtretquty_TextChanged(object sender, EventArgs e)
    {
        TextBox txtretquty = ((TextBox)((TextBox)sender).FindControl("txtretquty"));
        TextBox txtquty = ((TextBox)((TextBox)sender).FindControl("txtquty"));
        txtquty.Text = txtretquty.Text;
    }
    protected void txtquty_TextChanged(object sender, EventArgs e)
    {
        TextBox txtretquty1 = ((TextBox)((TextBox)sender).FindControl("txtretquty"));
        TextBox txtquty1 = ((TextBox)((TextBox)sender).FindControl("txtquty"));
        int rqty = Convert.ToInt32(txtretquty1.Text.Trim());
        int cqty = Convert.ToInt32(txtquty1.Text.Trim());
        if (cqty > rqty)
        {
            MessageBox("CN quantity is greater than Return quantity");
            txtquty1.Text = txtretquty1.Text;
            txtquty1.Focus();
        }
    }

    //protected void chkedit_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chkedit = ((CheckBox)((CheckBox)sender).FindControl("chkedit"));

    //    TextBox txtBookName = ((TextBox)((CheckBox)sender).FindControl("txtBookName"));
    //    TextBox txtretquty = ((TextBox)((CheckBox)sender).FindControl("txtretquty"));
    //    TextBox txtquty = ((TextBox)((CheckBox)sender).FindControl("txtquty"));

    //    TextBox txtrate = ((TextBox)((CheckBox)sender).FindControl("txtrate"));
    //    TextBox txtDiscount = ((TextBox)((CheckBox)sender).FindControl("txtDiscount"));
    //    TextBox txtcmmt = ((TextBox)((CheckBox)sender).FindControl("txtcmmt"));

    //    if (chkedit.Checked = true)
    //    {
    //        //chkedit.Enabled = false;

    //        txtBookName.Enabled = true;
    //        txtretquty.Enabled = true;
    //        txtquty.Enabled = true;
    //        txtrate.Enabled = true;
    //        txtDiscount.Enabled = true;
    //        txtcmmt.Enabled = true;
    //    }
    //    else
    //    if (chkedit.Checked = false)
    //    {
    //        //chkedit.Enabled = false;

    //        txtBookName.Enabled = false;
    //        txtretquty.Enabled = false;
    //        txtquty.Enabled = false;
    //        txtrate.Enabled = false;
    //        txtDiscount.Enabled = false;
    //        txtcmmt.Enabled = false;
    //    }
    //}
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    TextBox txtBookName = ((TextBox)((CheckBox)sender).FindControl("txtBookName"));
    //    TextBox txtretquty = ((TextBox)((CheckBox)sender).FindControl("txtretquty"));
    //    TextBox txtquty = ((TextBox)((CheckBox)sender).FindControl("txtquty"));

    //    TextBox txtrate = ((TextBox)((CheckBox)sender).FindControl("txtrate"));
    //    TextBox txtDiscount = ((TextBox)((CheckBox)sender).FindControl("txtDiscount"));
    //    TextBox txtcmmt = ((TextBox)((CheckBox)sender).FindControl("txtcmmt"));

    //}
    protected void grdBookDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //if (Session["UserName"] != null)
        //{
        //    CNNo = Convert.ToInt32(txtCnno.Text.Trim());

        //    string RQty = ((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtretquty")).Text;
        //    //string DfQty = ((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtdefquty")).Text;
        //    string CrQty = ((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtquty")).Text;
        //    string AtID = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblDAutoID")).Text;
        //    CreditNote _obedtcn = new CreditNote();

        //    try
        //    {
        //        _obedtcn.AutoID = Convert.ToInt32(AtID);
        //        _obedtcn.CNNo = CNNo;
        //        _obedtcn.CustCode = (DDLCustomer.SelectedValue);
        //        _obedtcn.BookCode = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblBookCode")).Text;
        //        _obedtcn.Rate = Convert.ToDecimal(((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtrate")).Text.Trim());
        //        _obedtcn.Discount = Convert.ToDecimal(((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtDiscount")).Text.Trim());
        //        _obedtcn.ReturnQty = Convert.ToInt32(CrQty);
        //        _obedtcn.Comment = ((TextBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("txtcmmt")).Text;
        //        _obedtcn.IsActive = true;
        //        _obedtcn.UpdatedBy = Session["UserName"].ToString();
        //        _obedtcn.Flag = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblflag")).Text;
        //        _obedtcn.TotReturnQty = Convert.ToInt32(RQty);
        //        _obedtcn.DefectQty = 0;
        //        _obedtcn.IsDeleted = false;

        //        _obedtcn.Update_CN();
        //        MessageBox("Record Updated Successfully");

        //        Bindgrdcn();

        //        quantity = 0;
        //        tamount = 0;

        //        DataTable dt1 = new DataTable();
        //        dt1 = DCReturnBook.GetCustAddress(DDLCustomer.SelectedValue, "CNCustlist").Tables[0];
        //        if (dt1.Rows.Count > 0)
        //        {
        //            lblCNNo.Text = (txtCnno.Text.Trim());
        //            lblCustName1.Text = dt1.Rows[0]["CustName"].ToString();
        //            lblCustAddress.Text = dt1.Rows[0]["Address"].ToString();
        //        }

        //        PnlPrint.Visible = true;
        //        btnPrint.Visible = true;

        //    }
        //    catch
        //    {
        //    }
        //}

    }
    protected void grdcn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
            tnamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty1 = (Label)e.Row.FindControl("lblqty");
            quantity = quantity + Convert.ToInt32(lblqty1.Text.Trim());
            Label lblamt1 = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt1.Text.Trim());
            Label lblnamt1 = (Label)e.Row.FindControl("lblnamt");
            tnamount = tnamount + Convert.ToDecimal(lblnamt1.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblqty2 = (Label)e.Row.FindControl("lbltqty");
            lblqty2.Text = quantity.ToString().Trim();
            Label lblamt2 = (Label)e.Row.FindControl("lbltamt");
            lblamt2.Text = tamount.ToString().Trim();
            Label lblnamt2 = (Label)e.Row.FindControl("lbltnamt");
            lblnamt2.Text = tnamount.ToString().Trim();
        }
    }

    #endregion

    #endregion

    #region Methods

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    #endregion

    #region Bind Methods
    private void clearAddBooks()
    {
        txtbkcod.Text = "";
        txRetqty.Text = "";

    }
    public void BindGrd2(DataTable dt)
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        grdBookDetails.DataSource = dt;
        grdBookDetails.DataBind();
    }

    public void BindDDLstd()
    {
        string std = "Standard";
        DDLstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(std, "DropDown");
        DDLstandard.DataBind();
        DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
    }
    public void BindDDlCust()
    {
        DDLCustomer.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "CNCustlist");
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }

    public string Bindgrdcn()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataSet dsprint = new DataSet();
        dsprint = CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);
        grdcn.DataSource = dsprint;
        grdcn.DataBind();
        cust = dsprint.Tables[1].Rows[0]["CustCode"].ToString();
        return cust;
    }
    #endregion
    #endregion

    #region Print
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintCreditNote.aspx?d=" + lblCNNo.Text.Trim() + "&fy=" + strFY + "')", true);
    }

    #endregion


    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "CN")
        {
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            PnlAddbk.Visible = false;
            btn_Save.Visible = false;
            PnlPrint.Visible = false;
            btnPrint.Visible = false;
            txtFromDate.Focus();
        }

        if (RdbtnSelect.SelectedValue == "CustomerwiseCN")
        {
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            PnlAddbk.Visible = false;
            btn_Save.Visible = false;
            PnlPrint.Visible = false;
            btnPrint.Visible = false;
            txtFromDate.Focus();
        }
    }
    protected void grdBookDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow &&
   (e.Row.RowState == DataControlRowState.Normal ||
    e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkBxSelect");
            CheckBox chkBxHeader = (CheckBox)this.grdBookDetails.HeaderRow.FindControl("chkBxHeader");
            chkBxSelect.Attributes["onclick"] = string.Format
                                                   (
                                                      "javascript:ChildClick(this,'{0}');",
                                                      chkBxHeader.ClientID
                                                   );
        }
    }

    #region Fill grid data for books

    public DataTable fillTempBookData(string bookcode, string custCode)
    {

        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();
        DataColumn Discount = new DataColumn();
        Discount.DataType = System.Type.GetType("System.String");
        Discount.ColumnName = "Discount";

        DataColumn Amount = new DataColumn();
        Amount.DataType = System.Type.GetType("System.String");
        Amount.ColumnName = "Amount";

        if (Session["tempDCData1"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Medium");
           //dt.Columns.Add("Qty");
            dt.Columns.Add("ReturnedQty");
            dt.Columns.Add("AvailableQty");
          //dt.Columns.Add("CN");
            dt.Columns.Add(Amount);
            dt.Columns.Add(Discount);
           //dt.Columns.Add("AddedrQty");
           //dt.Columns.Add("AddeCnQty");
            dt.Columns.Add("Comment");
            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();
        }
        else
        {
            dt = (DataTable)Session["tempDCData1"];
        }

        if (lblflagdc.Text == "DC")
        {
            tempGetData = CreditNote.Get_DC_CNBook(Convert.ToInt32(strFY), custCode, bookcode).Tables[0];
        }
        else
        {
            tempGetData = Books.Get_BooksMasterForDC(bookcode, "").Tables[0];
        }
        foreach (DataRow row in tempGetData.Rows)
        {
            //string price = row["Amount"].ToString();
            // decimal amt =0.00m;
            // if (price == "")
            // {
            //     price = "0";
            // }
            // amt = Convert.ToDecimal(quantity) * Convert.ToDecimal(price);

            if (dt.Rows.Count != 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "BookCode = '" + row["BookCode"].ToString() + "'";
                int i = 0;
                //price = row["Amount"].ToString();
                //amt = Convert.ToDecimal(quantity) * Convert.ToDecimal(price);
                foreach (DataRowView row1 in dv)
                {
                    i++;
                }

                if (i == 0)
                {
                    //DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                    //    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                    //    Tdiscount = amt * (discount / 100);
                    //    amt = amt - Tdiscount;
                    //}
                    dt.Rows.Add(0,0,0,row["BookCode"].ToString(),
                   row["BookName"].ToString(), row["Medium"].ToString(), row["Standard"].ToString(),
                  // row["Qty"].ToString(),
                   txRetqty.Text.Trim().ToString() , 0,
                    txRetqty.Text.Trim().ToString(),
                   "0.00", "0.00", "0.00", "0.00", txtComment.Text, lblflagdc.Text.ToString(), "true", "true", DateTime.Now.ToString("MM/dd/yyyy"), "false");
                }
            }
            else
            {
                //  DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                //    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                //    //  Totaldiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                //    Tdiscount = amt * (discount / 100);
                //    amt = amt - Tdiscount;
                //}

                dt.Rows.Add(row["BookCode"].ToString(),
                    row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(),
                   // row["Qty"].ToString(),
                    row["ReturnedQty"].ToString(),
                    row["AvailableQty"].ToString(),
                    "0.00", "0.00", "0.00", txRetqty.Text, txRetqty.Text, txtComment.Text);
            }
        }
        Session["tempDCData1"] = dt;
        return dt;
    }

    #endregion
}
