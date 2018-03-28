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


public partial class UserControls_uc_PurchaseMaster : System.Web.UI.UserControl
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
        if (!IsPostBack)
        {
            //SetView();
            // BindExpensehead();
            lblID.Text = "0";
            lblID1.Text = "0";
            lbl2ID.Text = "0";
            Session["tempdata"] = null;
            pnlpurch.Visible = true;
            btn_Save.Visible = true;
            gvPurchasing.Visible = true;
            lblDescriptionofGoods.Visible = true;
            SetView();

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
                pnlArea.Visible = false;
                grdpurchaseDetails.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    btn_Save.Visible = false;
                    pnlpurch.Visible = false;
                    btnAdd.Visible = false;
                    gvPurchasing.Visible = false;
                    pnlArea.Visible = true;
                    grdpurchaseDetails.Visible = true;
                }
        }
    }
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
                    pm.CreatedBy = Session["UserName"].ToString();
                    pm.Save(out DocNo);
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
                    pd.PurchaseDetailId = Convert.ToInt32(lblID1.Text);
                    pd.Code = ((Label)gv.FindControl("lblCode")).Text;
                    pd.Description = ((Label)gv.FindControl("lblName")).Text;
                    pd.Quantity = Convert.ToInt32(((Label)gv.FindControl("lblQuantity")).Text);
                    pd.Rate = Convert.ToDecimal(((Label)gv.FindControl("lblRate")).Text);
                    pd.Per = ((Label)gv.FindControl("lblRemarksave")).Text;
                    pd.Standard = ((Label)gv.FindControl("lblstandard")).Text;
                    pd.Discount = Convert.ToDecimal(((Label)gv.FindControl("lblDisc")).Text);
                    pd.Amount = Convert.ToDecimal(((Label)gv.FindControl("lblAmount")).Text);
                    pd.Save();

                }
            }
        }
        catch
        { }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtCode.Text != "" && txtRate.Text != "" && txtQuantity.Text != "")
            {
                Enter();
            }
            else
            {

            }
        }
        catch { }
    }
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
            dv.RowFilter = "Code = '" + PurchaseCode + "'";
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

                loder(PurchaseCode + " add successfully");
                message("add successfully");
                txtCode.Focus();


            }
            else
            {

                message("already added!");
                txtCode.Text = "";
                txtQuantity.Text = "";
                txtRate.Text = "";
                txtper.Text = "";
                txtDisc.Text = "";
                txtAmount.Text = "";
                lblDescriptionofGoods.Text = "";

            }
        }
        else
        {
            Session["tempdata"] = fillExpense();
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

    }
    public DataTable fillExpense()
    {
        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        if (Session["tempdata"] == null)
        {
            dt.Columns.Add("Code");
            dt.Columns.Add("Description");
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

            dt.Rows.Add(txtCode.Text.Trim().ToString(), lblDescriptionofGoods.Text.Trim().ToString(), lblStandard.Text.ToString(), txtQuantity.Text.ToString(), txtRate.Text.ToString().Trim(), txtper.Text.ToString(), string.Format("{0:0.00}", Convert.ToDecimal(txtDisc.Text.ToString().Trim())), Convert.ToDecimal(TotalAmount));
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
            dt.Rows.Add(txtCode.Text.Trim().ToString(), lblDescriptionofGoods.Text.Trim().ToString(), lblStandard.Text.ToString(), txtQuantity.Text.ToString(), txtRate.Text.ToString().Trim(), txtper.Text.ToString(), string.Format("{0:0.00}", Convert.ToDecimal(txtDisc.Text.ToString().Trim())), Convert.ToDecimal(TotalAmount));
        }

        return dt;
    }
    Label lblAmt;
    Label lbltamount;
    Label lblAmt2;
    Label lbltamount2;
    protected void gvPurchasing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            amount = 0;
            amount2 = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblAmt = (Label)e.Row.FindControl("lblQuantity");
            amount = amount + Convert.ToInt32(lblAmt.Text);

            lblAmt2 = (Label)e.Row.FindControl("lblAmount");
            amount2 = amount2 + Convert.ToDecimal(lblAmt2.Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            lbltamount = (Label)e.Row.FindControl("lbltotalQuantity");
            lbltamount.Text = amount.ToString();

            lbltamount2 = (Label)e.Row.FindControl("lblTotalAmount");
            amount2 = Math.Round(amount2, 0);
            lbltamount2.Text = (amount2).ToString();
        }
    }
    protected void gvPurchasing_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["tempdata"];
        dt1.Rows[e.RowIndex].Delete();
        gvPurchasing.DataSource = dt1;
        gvPurchasing.DataBind();
        Session["tempdata"] = dt1;
    }
    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtCode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "BookName").Tables[0];
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
    protected void btnget_Click(object sender, EventArgs e)
    {
        string FromDate1 = txtfromdate.Text.Split('/')[1] + "/" + txtfromdate.Text.Split('/')[0] + "/" + txtfromdate.Text.Split('/')[2];
        string ToDate1 = txttodate.Text.Split('/')[1] + "/" + txttodate.Text.Split('/')[0] + "/" + txttodate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(FromDate1);
        DateTime ToDate = Convert.ToDateTime(ToDate1);
        if (txtinvoice.Text.Trim() == "")
        { txtinvoice.Text = "0"; }

        int InvoiceNo = Convert.ToInt32(txtinvoice.Text.Trim());
        DataSet viewpurchase = new DataSet();
        viewpurchase = PurchaseMaster.Get_PurchaseDetails(InvoiceNo, FromDate, ToDate);
        if (viewpurchase.Tables[0].Rows.Count != 0)
        {
            grdpurchaseDetails.DataSource = viewpurchase;
            grdpurchaseDetails.DataBind();
            grdpurchaseDetails.Visible = true;
        }
        else
        {
            message("No Record found");
            grdpurchaseDetails.Visible = true;
        }
    }
    protected void txtInvoiceNo_TextChanged(object sender, EventArgs e)
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

    protected void txtPurchase_TextChanged(object sender, EventArgs e)
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
            txtInvoiceNo.Focus();
        }
        else
        {
            lblpurchase.Text = "No such Party";
            txtPurchase.Focus();
            txtPurchase.Text = "";
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
}
