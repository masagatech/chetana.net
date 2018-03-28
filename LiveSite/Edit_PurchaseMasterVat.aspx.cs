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


public partial class Edit_PurchaseMasterVat : System.Web.UI.Page
{
    int IDNo;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string Description;
    string PurchaseCode;
    static decimal amount;
    string date;
    static decimal amount2;
    int VoucherNo;
    int DocNo;
    int purchaseDid;

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
        if (!IsPostBack)
        {
            //SetView();
            // BindExpensehead(); 
            ModalPopUpDocNum.Show();
            
            lblID.Text = "0";
            lblID1.Text = "0";
            lbl2ID.Text = "0";
            Session["tempdata"] = null;
            pnlpurch.Visible = true;
            btn_Save.Visible = true;
            gvPurchasing.Visible = true;
            lblDescriptionofGoods.Visible = true;
            SetView();
            fillddlVat();
          //  txtPurchase.Focus();
            
            try
            {
                txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch
            {


            }
            if (gvPurchasing.Rows.Count <= 0)
            {
                lblGrandTot.Text = "0";
                lblVatAmt.Text = "0";
                lblSubTotal.Text = "0";
            }
            TxtDocNo.Focus();

        }
    }

    #region Button Events

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        {
            if (Session["UserName"] != null)
            {
                if (gvPurchasing.Rows.Count > 0)
                {
                    PurchaseMaster pm = new PurchaseMaster();
                    pm.PurchaseMasterID = Convert.ToInt32(lblID.Text.Trim());
                    pm.PurchaseCode = txtPurchase.Text.Trim().ToString();
                    pm.PurchaseName = lblpurchase.Text.Trim().ToString();
                    pm.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text.Trim());
                    pm.SuppliersRef = lblshow.Text.Trim().ToString();
                    pm.SuppliersRefCode = txtSupplier.Text.Trim();
                    string date = txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2];
                    pm.InvoiceDate = Convert.ToDateTime(date);
                    //pm.SuppliersRefCode = txtRefCode.Text.Trim().ToString();
                    pm.IsActive = Convert.ToBoolean(true);
                    pm.CreatedBy = Session["UserName"].ToString() + "~" + txtInvAlfa.Text.Trim();
                    pm.FY = Convert.ToInt32(strFY);
                    pm.Oms = ddlmsoms.SelectedValue.ToString();
                    decimal vat = 0;
                    //if (txtPercentage.Text.ToString() == "") { vat = 0; } else { vat = Convert.ToDecimal(txtPercentage.Text.ToString()); }
                    vat = Convert.ToDecimal(txtVatAmt.Text.ToString());
                    pm.Ms = vat;
                   // pm.Remark = txtremark.Text.Trim();
                    pm.Save(out DocNo, "");
                    SaveDetails(DocNo);
                    message("Record save successfully \\r\\n InvoiceNo:" + DocNo);
                    Session["tempdata"] = null;
                    gvPurchasing.DataBind();
                    txtDate.Text = "";
                    txtInvoiceNo.Text = "";
                    txtSupplier.Text = "";
                    txtPurchase.Text = "";
                    lblshow.Text = "";
                    lblpurchase.Text = "";
                    lblDescriptionofGoods.Text = "";
                }
                else
                {
                    message("Enter Purchase Details");
                }
            }
        }
    }
    public void SaveDetails(int DocNo)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                PurchaseDetails pd = new PurchaseDetails();

                pd.PurchaseMasterID = DocNo;
                pd.CreatedBy = Session["UserName"].ToString();
                foreach (GridViewRow gv in gvPurchasing.Rows)
                {
                    pd.IsActive = Convert.ToBoolean(true);
                    pd.PurchaseDetailId = Convert.ToInt32(((Label)gv.FindControl("lblpdetailid")).Text);
                    pd.Code = ((Label)gv.FindControl("lblCode")).Text;
                    pd.Description = ((Label)gv.FindControl("lblName")).Text;
                    pd.Quantity = Convert.ToInt32(((TextBox)gv.FindControl("lblQuantity")).Text);
                    pd.Rate = Convert.ToDecimal(((TextBox)gv.FindControl("lblRate")).Text);
                    pd.Per = ((Label)gv.FindControl("lblRemarksave")).Text;
                    pd.Standard = ((Label)gv.FindControl("lblstandard")).Text;
                    pd.Discount = Convert.ToDecimal(((TextBox)gv.FindControl("lblDisc")).Text);
                    pd.Amount = Convert.ToDecimal(((Label)gv.FindControl("lblAmount")).Text);
                    pd.OriQuantity = Convert.ToInt32(((Label)gv.FindControl("lblqtyactual")).Text);
                    pd.Save(1);

                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtCode.Text != "" && txtRate.Text != "" && txtQuantity.Text != "")
            {
                setStateGridview();
                Enter();
            }
            else
            {

            }
        }
        catch { }
    }

    #endregion

    #region Methods


    public void Enter()
    {

        btn_Save.Visible = true;
        Description = lblDescriptionofGoods.Text.Trim().ToString();
        PurchaseCode = txtCode.Text.Trim().ToString();

        DataTable dt = new DataTable();
        if (Session["tempdata"] != null)
        {
            dt = (DataTable)Session["tempdata"];
            DataView dv = new DataView(dt);
            if (PurchaseCode.ToUpper() != "MIS")
            {
                dv.RowFilter = "Code = '" + PurchaseCode + "'";
            }
            else
            {
                dv.RowFilter = "Code = 'accelatorwodssd'";
            }
            //  if (bookcode =
            int i = 0;
            foreach (DataRowView row in dv)
            {
                i++;
            }
            if (i == 0)
            {
                Session["tempdata"] = fillExpense();
                this.SetVatAmount();

                dt = (DataTable)Session["tempdata"];

                loder(PurchaseCode + " add successfully");
                message("add successfully");
                txtCode.Focus();


            }
            else
            {
                message("already added!");
            }
        }
        else
        {
            Session["tempdata"] = fillExpense();
            this.SetVatAmount();
            dt = (DataTable)Session["tempdata"];
            loder(PurchaseCode + " add successfully");
            message("add successfully");
            txtCode.Focus();
        }

        gvPurchasing.DataSource = dt;
        gvPurchasing.DataBind();
        gvPurchasing.Visible = true;
        txtCode.Text = "";
        txtQuantity.Text = "";
        txtRate.Text = "";
        txtper.Text = "No.";
        txtDisc.Text = "";
        txtAmount.Text = "";
        lblDescriptionofGoods.Text = "";
        txtCode.Focus();

    }

    public DataTable fillExpense()
    {
        string remark= "";
        if (txtCode.Text.Trim().ToUpper() != "MIS")
        { remark = lblDescriptionofGoods.Text.Trim(); }
        else
        { remark = txtremark.Text.Trim(); }
        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        if (Session["tempdata"] == null)
        {
            dt.Columns.Add("PurchaseDetailId");
            dt.Columns.Add("Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity1");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Per");
            dt.Columns.Add("Discount");
            dt.Columns.Add("Amount");
        }
        else
        {
            dt = (DataTable)Session["tempdata"];
        }


        if (dt.Rows.Count == 0)
        {
            int Qty = Convert.ToInt32(txtQuantity.Text);
            decimal rate = Convert.ToDecimal(txtRate.Text);
            if (txtDisc.Text.ToString() == "")
            {
                txtDisc.Text = "0";
            }
            decimal discount = Convert.ToDecimal(txtDisc.Text);

            decimal TotalAmount = Qty * (rate - (rate * discount / 100));

            dt.Rows.Add(0, txtCode.Text.Trim().ToString(), lblDescriptionofGoods.Text.Trim().ToString(), txtQuantity.Text.ToString(), lblStandard.Text.ToString(), txtQuantity.Text.ToString(), txtRate.Text.ToString().Trim(), txtper.Text.ToString(), string.Format("{0:0.00}", Convert.ToDecimal(txtDisc.Text.ToString().Trim())), Convert.ToDecimal(TotalAmount));
        }
        else
        {
            int Qty = Convert.ToInt32(txtQuantity.Text);
            decimal rate = Convert.ToDecimal(txtRate.Text);
            if (txtDisc.Text.ToString() == "")
            {
                txtDisc.Text = "0";
            }
            decimal discount = Convert.ToDecimal(txtDisc.Text);
            decimal TotalAmount = Qty * (rate - (rate * discount / 100));
            dt.Rows.Add(0, txtCode.Text.Trim().ToString(), lblDescriptionofGoods.Text.Trim().ToString(), txtQuantity.Text.ToString(), lblStandard.Text.ToString(), txtQuantity.Text.ToString(), txtRate.Text.ToString().Trim(), txtper.Text.ToString(), string.Format("{0:0.00}", Convert.ToDecimal(txtDisc.Text.ToString().Trim())), Convert.ToDecimal(TotalAmount));
        }

        return dt;
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                btn_Save.Visible = true;
                pnlpurch.Visible = true;
                btnAdd.Visible = true;
                // gvPurchasing.Visible = true;

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    btn_Save.Visible = false;
                    pnlpurch.Visible = false;
                    btnAdd.Visible = false;
                    gvPurchasing.Visible = false;

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
    #endregion

    #region TextChanged

    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtCode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = Idv.Chetana.BAL.DCMaster.Get_Name(ECode, "BookName").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtCode.Text = ECode;
            lblDescriptionofGoods.Text = dt.Rows[0]["BookName"].ToString();
            txtRate.Text = String.Format("{0:0.00}", Convert.ToDecimal(dt.Rows[0]["SellingPrice"].ToString()));
            lblStandard.Text = dt.Rows[0]["Standard"].ToString();
            txtQuantity.Focus();
            lblDescriptionofGoods.Visible = true;
        }
        else
        {

            lblDescriptionofGoods.Text = "No such Book code";
            txtCode.Focus();
            txtCode.Text = "";
        }

    }
    protected void txtInvoiceNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int Invoice = Convert.ToInt32(txtInvoiceNo.Text.Trim());
            bool Auth = PurchaseMaster.Idv_Chetana_Get_Validate_PurchaseInvoice(Invoice);
            if (Auth)
            {
                MessageBox(" No. is Already Exist");
                txtInvoiceNo.Text = "";
                txtInvoiceNo.Focus();

            }
            else
            {
                txtSupplier.Focus();
            }

        }
        catch (Exception ex)
        {

            txtInvoiceNo.Text = "";
            txtInvoiceNo.Focus();
        }
    }

    protected void txtPurchase_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string ECode = txtPurchase.Text.ToString().Split(':', '[', ']')[0].Trim();
            string flag = txtPurchase.Text.ToString().Split(':', '[', ']')[3].Trim();
            DataTable dt = new DataTable();
            dt = DCMaster.Get_Name(ECode, flag).Tables[0];
            if (dt.Rows.Count != 0)
            {
                txtPurchase.Text = ECode;
                if (flag == "AC")
                {
                    lblpurchase.Visible = true;
                    lblpurchase.Text = dt.Rows[0]["AC_NAME"].ToString();


                }
                else
                {
                    lblpurchase.Visible = true;
                    lblpurchase.Text = dt.Rows[0]["CustName"].ToString();

                }
                txtInvAlfa.Focus();
            }
            else
            {
                lblpurchase.Text = "No such Party found";
                txtPurchase.Focus();
                txtPurchase.Text = "";
            }

        }
        catch
        {
            txtPurchase.Text = "";
            txtPurchase.Focus();
            lblpurchase.Text = "No such Party found";
        }

    }

    protected void txtSupplier_TextChanged1(object sender, EventArgs e)
    {
        string ECode = txtSupplier.Text.ToString().Split(':', '[', ']')[0].Trim();
        string flag = txtSupplier.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, flag).Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtSupplier.Text = ECode;
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
            txtDate.Focus();
        }
        else
        {
            lblshow.Text = "No such Party";
            txtSupplier.Focus();
            txtSupplier.Text = "";
        }
    }
    #endregion

    #region GridView_Events


    TextBox lblqty;
    Label lbltamount;
    Label lblAmt2;
    Label lbltamount2;
    TextBox txtrate;
    TextBox txtdisc;

    protected void gvPurchasing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            amount = 0;
            amount2 = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblqty = (TextBox)e.Row.FindControl("lblQuantity");
            amount = amount + Convert.ToInt32(lblqty.Text);
            txtrate = (TextBox)e.Row.FindControl("lblRate");
            txtdisc = (TextBox)e.Row.FindControl("lblDisc");

            lblAmt2 = (Label)e.Row.FindControl("lblAmount");
            amount2 = amount2 + Convert.ToDecimal(lblAmt2.Text);

            lblqty.Attributes.Add("onkeyup", "multiplyQty('" + lblqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt2.ClientID + "','" + txtdisc.ClientID + "')");
            // tabindex = tabindex + 1;
            // lblqty.Attributes.Add("TabIndex", tabindex.ToString());

            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + lblqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt2.ClientID + "','" + txtdisc.ClientID + "')");
            // tabindex = tabindex + 1;
            //  txtrate.Attributes.Add("TabIndex", tabindex.ToString());

            txtdisc.Attributes.Add("onkeyup", "multiplyQty('" + lblqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt2.ClientID + "','" + txtdisc.ClientID + "')");
            // tabindex = tabindex + 1;
            //  txtdisc.Attributes.Add("TabIndex", tabindex.ToString());


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            lbltamount = (Label)e.Row.FindControl("lbltotalQuantity");
            lbltamount.Text = amount.ToString();

            lbltamount2 = (Label)e.Row.FindControl("lblTotalAmount");
            amount2 = Math.Round(amount2, 0);
            lbltamount2.Text = (amount2).ToString();

           // lblVatper.Text = "VAT " + ddlVat.SelectedItem.Text.ToString() + "(%)";
            if (txtPercentage.Text == "")
            {
                txtPercentage.Text = ddlVat.SelectedItem.Text.ToString();
            }
            lblSubTotal.Text = (amount2).ToString();
            
            if (txtPercentage.Text != "")
            {
                decimal calCulatedAmt = (amount2 * Convert.ToDecimal(txtPercentage.Text.ToString()) / 100);
                lblVatAmt.Text = Math.Round(calCulatedAmt,0).ToString();
                txtAmount.Text = Math.Round(calCulatedAmt, 0).ToString();
            }
            else
            { 
                lblVatAmt.Text = "0";
                txtVatAmt.Text = "0"; 

            }
            //lblGrandTot.Text = (amount2 + Convert.ToDecimal(lblVatAmt.Text)).ToString();
            lblGrandTot.Text = (amount2 + Convert.ToDecimal(txtVatAmt.Text)).ToString();
        }
    }

    protected void gvPurchasing_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PurchaseDetails _objdcd = new PurchaseDetails();

        purchaseDid = Convert.ToInt32(((Label)gvPurchasing.Rows[e.RowIndex].FindControl("lblpdetailid")).Text);

        try
        {

            if (purchaseDid != 0)
            {
                _objdcd.PurchaseDetailId = purchaseDid;
                _objdcd.IsActive = false;
                _objdcd.Isdeleted = true;
                _objdcd.Amount = 0;
                _objdcd.Rate = 0;
                _objdcd.Discount = 0;
                _objdcd.Quantity = Convert.ToInt32(((TextBox)gvPurchasing.Rows[e.RowIndex].FindControl("lblQuantity")).Text);
                _objdcd.UpdatedBy = Session["UserName"].ToString();
                _objdcd.Delete();
            }
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["tempdata"];
            dt1.Rows[e.RowIndex].Delete();
            gvPurchasing.DataSource = dt1;
            gvPurchasing.DataBind();
            Session["tempdata"] = dt1;
        }
        catch
        {


        }
        if (gvPurchasing.Rows.Count <= 0)
        {
            lblGrandTot.Text = "0";
            lblVatAmt.Text = "0";
            lblSubTotal.Text = "0";
        }
    }


    #endregion

    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {


        //ModalPopUpDocNum.Hide();
        //Session["tempDCData"] = null;

        int DocNum = Convert.ToInt32(TxtDocNo.Text.Trim());


        DataTable dt = new DataTable();
        dt = PurchaseMaster.Get_PurchaseDetails(DocNum, Convert.ToDateTime("2011/01/01"), Convert.ToDateTime("2011/01/01")
          , Convert.ToInt32(strFY), "ACEDIT", 0, 0).Tables[0];

        if (dt.Rows.Count > 0)
        {
            lblshow.Text = dt.Rows[0]["SuppliersRef"].ToString();
            txtSupplier.Text = dt.Rows[0]["SuppliersRefCode"].ToString();
            txtPurchase.Text = dt.Rows[0]["PurchaseCode"].ToString();
            lblpurchase.Text = dt.Rows[0]["PurchaseName"].ToString();
            txtDate.Text = dt.Rows[0]["InvoiceDate"].ToString();
            txtInvoiceNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
            lblID.Text = dt.Rows[0]["PurchaseMasterID"].ToString();

            try
            {
                //txtPercentage.Text = dt.Rows[0]["vat"].ToString();
                txtVatAmt.Text = dt.Rows[0]["vat"].ToString();
                ddlmsoms.SelectedValue = dt.Rows[0]["ms_oms"].ToString();
                ddlVat.SelectedValue = dt.Rows[0]["vat"].ToString();
                txtremark.Text  = dt.Rows[0]["remark"].ToString();
                
                
            }
            catch (Exception ex)
            {


            }
            gvPurchasing.DataSource = dt;
            gvPurchasing.DataBind();
            Session["tempdata"] = dt;
            btn_Save.Visible = true;
            txtCode.Text = "MIS";
            txtQuantity.Text = "1";
            txtRate.Focus();


        }
        else
        {
            message("Record not found for document no. " + TxtDocNo.Text);
            ModalPopUpDocNum.Show();
            TxtDocNo.Text = "";
            TxtDocNo.Focus();
            btn_Save.Visible = false;
        }
    }

    private void setStateGridview()
    {
        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataTable _d = new DataTable();
        _d.Columns.Add("PurchaseDetailId");
        _d.Columns.Add("Code");
        _d.Columns.Add("Description");
        //dt.Columns.Add("BookType");
        _d.Columns.Add("Quantity1");
        _d.Columns.Add("Standard");

        _d.Columns.Add("Quantity");

        _d.Columns.Add(colTax);
        _d.Columns.Add("Per");
        _d.Columns.Add("Discount");
        _d.Columns.Add("Amount");


        foreach (GridViewRow row in gvPurchasing.Rows)
        {
            decimal amt1, rate1, qty1;
            decimal discount1;
            decimal Tdiscount1;
            string amt;
            if (((TextBox)row.FindControl("lblDisc")).Text != "")
            {
                discount1 = Convert.ToDecimal(((TextBox)row.FindControl("lblDisc")).Text);
            }
            else
            {
                discount1 = 0;
            }
            if (((Label)row.FindControl("lblAmount")).Text != "")
            {
                rate1 = Convert.ToDecimal(((TextBox)row.FindControl("lblRate")).Text);
                qty1 = Convert.ToDecimal(((TextBox)row.FindControl("lblQuantity")).Text);
                amt1 = rate1 * qty1;
                Tdiscount1 = amt1 * (discount1 / 100);
                amt1 = amt1 - Tdiscount1;
            }
            else
            {
                amt1 = 0;
            }

            _d.Rows.Add(Convert.ToInt32(((Label)row.FindControl("lblpdetailid")).Text),
            ((Label)row.FindControl("lblCode")).Text,
            ((Label)row.FindControl("lblName")).Text,
            ((Label)row.FindControl("lblqtyactual")).Text,
            ((Label)row.FindControl("lblstandard")).Text,
            ((TextBox)row.FindControl("lblQuantity")).Text,
            ((TextBox)row.FindControl("lblRate")).Text,
            ((Label)row.FindControl("lblRemarksave")).Text,
            ((TextBox)row.FindControl("lblDisc")).Text,
            String.Format("{0:0.00}", amt1));
        }
        Session["tempdata"] = null;
        Session["tempdata"] = _d;
    }
    public void fillddlVat()
    {
        DataSet ds = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("pvm", ddlmsoms.SelectedValue.ToString());
        ddlVat.DataSource = ds;
        ddlVat.DataBind();
        //ddlvatText.DataSource = ds;
        //ddlvatText.DataBind();
    }
    protected void ddlmsoms_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlVat();
        if (Session["tempdata"] != null)
        {
            DataTable dt = (DataTable)Session["tempdata"];
            gvPurchasing.DataSource = dt;
            gvPurchasing.DataBind();
        }
    }
    protected void ddlVat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["tempdata"] != null)
        {
            DataTable dt = (DataTable)Session["tempdata"];
            txtPercentage.Text = ddlVat.SelectedItem.Text.ToString();
            gvPurchasing.DataSource = dt;
            gvPurchasing.DataBind();
        }
    }

    protected void txtPercentage_TextChanged(object sender, EventArgs e)
    {
        this.SetVatAmount();
    }

    private void SetVatAmount()
    {
        //message(txtVatAmt.Text.ToString());
        decimal calCulatedAmt = 0;
        if (txtVatAmt.Text != "")
        {
            calCulatedAmt = (Convert.ToDecimal(lblSubTotal.Text.ToString()) + Convert.ToDecimal(txtVatAmt.Text.ToString()));
            //lblVatAmt.Text = Math.Round(calCulatedAmt, 0).ToString();
            //txtVatAmt.Text = Math.Round(calCulatedAmt, 0).ToString();
        }
        else
        {
            lblVatAmt.Text = "0";
            calCulatedAmt = (Convert.ToDecimal(lblSubTotal.Text.ToString()) + Convert.ToDecimal(txtVatAmt.Text.ToString()));
        }
        //lblGrandTot.Text = (amount2 + Convert.ToDecimal(lblVatAmt.Text)).ToString();
        lblGrandTot.Text = calCulatedAmt.ToString();

    }

    protected void txtVatAmt_TextChanged(object sender, EventArgs e)
    {
        this.SetVatAmount();

    }

}
