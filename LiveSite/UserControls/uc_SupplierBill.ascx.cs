using System;
using System.IO;
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
using Others;

public partial class UserControls_uc_SupplierBill : System.Web.UI.UserControl
{
    #region "Filed And Properties"

    string strCompany = "cppl";
    string strFY = "0";

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strCompany = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }

        if (!IsPostBack)
        {
            ResetSupplierBillFields();
            GetSupplierDetails();
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            int MsgID = 0;
            string Msg = "";
            int SBillID = 0;

            if (gvSupplierBill.Rows.Count > 0)
            {
                SupplierBill supbillm = new SupplierBill();
                DataSet mDSet = new DataSet();

                supbillm.SBillID = Convert.ToInt32(lblSBillID.Text.Trim());
                supbillm.SupplierCode = lblSupplierCode.Text.Trim().ToString();
                supbillm.SupplierName = txtSupplierName.Text.Trim().ToString();
                supbillm.PurchaseCode = lblPurchaseCode.Text.Trim().ToString();
                supbillm.PurchaseName = txtPurchaseName.Text.Trim().ToString();

                supbillm.InvoiceNo = txtInvoiceNo.Text.Trim();
                supbillm.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.Trim());

                supbillm.GSTPer = Convert.ToInt32(ddlGSTPer.SelectedValue.ToString());

                supbillm.IsActive = Convert.ToBoolean(true);
                supbillm.CreatedBy = Session["UserName"].ToString();
                supbillm.FY = Convert.ToInt32(strFY);

                mDSet = supbillm.SaveSupplierBill();

                if (mDSet.Tables[0].Rows.Count > 0)
                {
                    MsgID = Convert.ToInt32(mDSet.Tables[0].Rows[0]["MsgID"].ToString());
                    Msg = (mDSet.Tables[0].Rows[0]["Msg"].ToString());

                    if (MsgID == 0)
                    {
                        message(Msg);
                    }
                    else
                    {
                        SBillID = Convert.ToInt32(mDSet.Tables[0].Rows[0]["SBillID"].ToString());
                        SaveSupplierDetails(SBillID);

                        message(Msg + " \\r\\n Bill ID:" + SBillID);
                        Session["tempdata"] = null;

                        ResetSupplierBillFields();

                        Session["tempdata"] = null;
                        gvSupplierBill.DataBind();
                    }
                }
            }
            else
            {
                message("Enter Purchase Details");
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddSupplierDetails();
    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        Session["tempdata"] = null;
        gvSupplierBill.DataBind();
        divSuppDetails.Attributes["class"] = "hide";
    }

    #endregion

    #region "User-Defined Function"

    public void ResetSupplierBillFields()
    {
        lblSBillID.Text = "0";
        lblSupplierCode.Text = "";
        txtSupplierName.Text = "";
        lblPurchaseCode.Text = "";
        txtPurchaseName.Text = "";
        txtInvoiceNo.Text = "";
        txtInvoiceDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        BindGSTPerDropDown("");
        ddlGSTPer.SelectedValue = "0";

        lblSBillDID.Text = "0";
        txtAccountName.Text = "";
        txtQuantity.Text = "1";
        txtAmount.Text = "";
        txtRemark.Text = "";

        lblTotalAmount.Text = "0";
        lblGSTAmount.Text = "0";
        lblGrandTotal.Text = "0";

        divSuppDetails.Attributes["class"] = "hide";
    }

    public void BindGSTPerDropDown(string pACCode)
    {
        ddlGSTPer.DataSource = Common.GetDropDownFields("GSTPer", pACCode);
        ddlGSTPer.DataBind();

        ddlGSTPer.Items.Insert(0, new ListItem("-- Select GST Percentage --", "0"));
    }

    public void SaveSupplierDetails(int _SBillID)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                SupplierBill suppbilld = new SupplierBill();

                foreach (GridViewRow gvrow in gvSupplierBill.Rows)
                {
                    int _SBillDID = Convert.ToInt32(((Label)gvrow.FindControl("lblSBillDID")).Text);
                    string _AccountCode = ((Label)gvrow.FindControl("lblAccountCode")).Text.ToString();
                    int _Quantity = Convert.ToInt32(((Label)gvrow.FindControl("lblQuantity")).Text);
                    decimal _Amount = Convert.ToDecimal(((Label)gvrow.FindControl("lblAmount")).Text);
                    string _Remark = ((Label)gvrow.FindControl("lblRemark")).Text;

                    suppbilld.SBillDID = _SBillDID;
                    suppbilld.SBillID = _SBillID;
                    suppbilld.AccountCode = _AccountCode;
                    suppbilld.Quantity = _Quantity;
                    suppbilld.Amount = _Amount;
                    suppbilld.Remark = _Remark;
                    suppbilld.CreatedBy = Session["UserName"].ToString();
                    suppbilld.UpdatedBy = Session["UserName"].ToString();
                    suppbilld.IsActive = Convert.ToBoolean(true);

                    suppbilld.SaveSupplierBillDetails();
                }
            }
        }
        catch
        {
        }
    }

    public void AddSupplierDetails()
    {
        DataTable mDTable = new DataTable();
        DataTable tempGetData = new DataTable();

        int SuppDetailsID = lblSBillDID.Text == "" ? 0 : Convert.ToInt32(lblSBillDID.Text);
        string AccountCode = txtAccountName.Text.Trim().ToString().Split(':', '[', ']')[0].Trim();
        string AccountName = txtAccountName.Text.Trim().ToString();
        string Quantity = txtQuantity.Text.Trim().ToString();
        string Amount = txtAmount.Text.Trim().ToString();
        string Remark = txtRemark.Text.Trim().ToString();

        if (Session["tempdata"] == null)
        {
            mDTable.Columns.Add("SBillDID");
            mDTable.Columns.Add("AccountCode");
            mDTable.Columns.Add("AccountName");
            mDTable.Columns.Add("Quantity");
            mDTable.Columns.Add("Amount");
            mDTable.Columns.Add("Remark");
        }
        else
        {
            mDTable = (DataTable)Session["tempdata"];
        }

        mDTable.Rows.Add(SuppDetailsID, AccountCode, AccountName, Quantity, Amount, Remark);

        Session["tempdata"] = mDTable;

        divSuppDetails.Attributes["class"] = "show";
        GetSupplierDetails();

        txtAccountName.Focus();
        lblSBillDID.Text = "0";
        txtAccountName.Text = "";
        txtQuantity.Text = "1";
        txtAmount.Text = "";
        txtRemark.Text = "";
    }

    public void GetSupplierDetails()
    {
        DataTable mDTable = new DataTable();
        mDTable = (DataTable)Session["tempdata"];

        gvSupplierBill.DataSource = mDTable;
        gvSupplierBill.DataBind();
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
            }
            else if (Request.QueryString["a"] == "v")
            {
                btn_Save.Visible = false;
                pnlpurch.Visible = false;
                btnAdd.Visible = false;
                gvSupplierBill.Visible = false;
            }
        }
    }

    #endregion

    #region "GridView_Events"

    Decimal Amount = 0;

    protected void gvSupplierBill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblAmount;

        Decimal GSTPer = 0;
        Decimal GrandTotal = 0;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblAmount = (Label)e.Row.FindControl("lblAmount");

            Amount = Amount + Convert.ToInt32(lblAmount.Text);

            lblTotalAmount.Text = Amount.ToString();

            if (ddlGSTPer.SelectedValue == "0")
            {
                GSTPer = Convert.ToDecimal("0");
                lblGSTAmount.Text = "0";

                lblGrandTotal.Text = Amount.ToString();
            }
            else
            {
                GSTPer = Convert.ToDecimal(ddlGSTPer.SelectedItem.Text);
                lblGSTAmount.Text = ((Amount * GSTPer) / 100).ToString();
                GrandTotal = Convert.ToDecimal(Amount) + Convert.ToDecimal(((Amount * GSTPer) / 100));

                lblGrandTotal.Text = GrandTotal.ToString();
            }
        }
    }

    protected void gvSupplierBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["tempdata"];
        dt1.Rows[e.RowIndex].Delete();

        gvSupplierBill.DataSource = dt1;
        gvSupplierBill.DataBind();

        Session["tempdata"] = dt1;

        if (gvSupplierBill.Rows.Count <= 0)
        {
            lblGrandTotal.Text = "0";
            lblGSTAmount.Text = "0";
            lblTotalAmount.Text = "0";
            divSuppDetails.Attributes["class"] = "hide";
        }
    }

    #endregion

    #region "TextChanged"

    protected void txtSupplierName_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtSupplierName.Text.ToString().Split(':', '[', ']')[0].Trim();
        string flag = txtSupplierName.Text.ToString().Split(':', '[', ']')[3].Trim();

        DataTable dt = new DataTable();
        dt = Common.Get_Name(ECode, flag).Tables[0];

        if (dt.Rows.Count != 0)
        {
            lblSupplierCode.Text = ECode;

            BindGSTPerDropDown(ECode);

            if (flag == "AC")
            {
                txtSupplierName.Text = dt.Rows[0]["AC_NAME"].ToString();
            }
            else
            {
                txtSupplierName.Text = dt.Rows[0]["CustName"].ToString();
            }
        }
        else
        {
            lblSupplierCode.Text = "No such Party";
            txtSupplierName.Focus();
            txtSupplierName.Text = "";
        }
    }

    protected void txtPurchaseName_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtPurchaseName.Text.ToString().Split(':', '[', ']')[0].Trim();
        lblPurchaseCode.Text = ECode;
    }

    #endregion

    #region "MessageBox"

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

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion
}