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
using System.Xml;
using Others;

public partial class UserControls_uc_SupplierBill : System.Web.UI.UserControl
{
    #region "Filed And Properties"

    string strCompany = "cppl";
    string strFY = "0";
    string xmlstr;

    public int SBillID
    {
        get
        {
            if (Request.QueryString["SBillID"] == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(Request.QueryString["SBillID"]);
            }
        }
    }

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
            BindSupplierGrid();
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

                supbillm.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text.Trim());
                supbillm.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.Trim());

                supbillm.GSTPer = Convert.ToInt32(ddlGSTPer.SelectedValue.ToString());

                supbillm.IsActive = Convert.ToBoolean(true);
                supbillm.CreatedBy = Session["UserName"].ToString();
                supbillm.FY = Convert.ToInt32(strFY);
                supbillm.SBillDT = SaveSupplierDetails();

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
                        SBillID = Convert.ToInt32(mDSet.Tables[0].Rows[0]["ID"].ToString());
                        message(Msg + " \\r\\n Bill ID:" + SBillID);

                        ResetSupplierBillFields();
                        Session["tempdata"] = null;
                        gvSupplierBill.DataBind();
                    }
                }

                if (Request.QueryString["SBillID"] == null)
                {
                    message("Saved Successfully !!!! \\r\\n Bill ID:" + SBillID);
                    ResetSupplierBillFields();

                    Session["tempdata"] = null;
                    gvSupplierBill.DataBind();
                }
                else
                {
                    message("Updated Successfully !!!! \\r\\n Bill ID:" + SBillID);
                    ResetSupplierBillFields();

                    Session["tempdata"] = null;
                    Response.Redirect("SupplierBill_View.aspx");
                }
            }
            else
            {
                message("Enter Purchase Details");
            }
        }
    }

    protected void btnAddEdit_Click(object sender, EventArgs e)
    {
        AddSupplierDetails();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblSBillDID.Text = ((Label)((Button)sender).FindControl("lblSBillDID")).Text;
        txtAccountName.Text = ((Label)((Button)sender).FindControl("lblAccountName")).Text;
        txtQuantity.Text = ((Label)((Button)sender).FindControl("lblQuantity")).Text;
        txtAmount.Text = ((Label)((Button)sender).FindControl("lblAmount")).Text;
        txtRemark.Text = ((Label)((Button)sender).FindControl("lblRemark")).Text;

        btnAddEdit.Text = "Update";
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

        lblSBillDID.Text = "0";
        txtAccountName.Text = "";
        txtQuantity.Text = "1";
        txtAmount.Text = "";
        txtRemark.Text = "";

        lblTotalAmount.Text = "0";
        lblGSTAmount.Text = "0";
        lblGrandTotal.Text = "0";

        btnAddEdit.Text = "Add";
        divSuppDetails.Attributes["class"] = "hide";
    }

    public void BindGSTPerDropDown(string pACCode)
    {
        ddlGSTPer.DataSource = Common.GetDropDownFields("GSTPer", pACCode);
        ddlGSTPer.DataBind();

        ddlGSTPer.Items.Insert(0, new ListItem("-- Select GST Percentage --", "0"));
    }

    public string SaveSupplierDetails()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            XmlNode inode = doc.CreateElement("f");
            XmlNode fnode = doc.CreateElement("r");

            SupplierBill suppbilld = new SupplierBill();

            foreach (GridViewRow gvrow in gvSupplierBill.Rows)
            {
                XmlNode element = doc.CreateElement("i");

                int _SBillDID = Convert.ToInt32(((Label)gvrow.FindControl("lblSBillDID")).Text);
                string _AccountCode = ((Label)gvrow.FindControl("lblAccountCode")).Text.ToString();
                string _AccountName = ((Label)gvrow.FindControl("lblAccountName")).Text.ToString();
                int _Quantity = Convert.ToInt32(((Label)gvrow.FindControl("lblQuantity")).Text);
                decimal _Amount = Convert.ToDecimal(((Label)gvrow.FindControl("lblAmount")).Text);
                string _Remark = ((Label)gvrow.FindControl("lblRemark")).Text;

                inode = doc.CreateElement("pmdid");
                inode.InnerText = _SBillDID.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("accode");
                inode.InnerText = _AccountCode.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("acname");
                inode.InnerText = _AccountName.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("qty");
                inode.InnerText = _Quantity.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("rate");
                inode.InnerText = _Amount.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("per");
                inode.InnerText = ddlGSTPer.SelectedItem.Text.ToString();
                element.AppendChild(inode);

                decimal amt = _Amount + (_Amount * Convert.ToDecimal(ddlGSTPer.SelectedItem.Text)) / 100;

                inode = doc.CreateElement("amt");
                inode.InnerText = amt.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("remark");
                inode.InnerText = _Remark.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("crby");
                inode.InnerText = Session["UserName"].ToString();
                element.AppendChild(inode);

                fnode.AppendChild(element);
            }

            return xmlstr = fnode.OuterXml.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void AddSupplierDetails()
    {
        DataTable mDTable = new DataTable();

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

        if (SBillID != 0)
        {
            DataRow[] drSuppRow = mDTable.Select("SBillDID = " + lblSBillDID.Text);

            drSuppRow[0]["SBillDID"] = SuppDetailsID;
            drSuppRow[0]["AccountCode"] = AccountCode;
            drSuppRow[0]["AccountName"] = AccountName;
            drSuppRow[0]["Quantity"] = Quantity;
            drSuppRow[0]["Amount"] = Amount;
            drSuppRow[0]["Remark"] = Remark;
        }
        else
        {
            mDTable.Rows.Add(SuppDetailsID, AccountCode, AccountName, Quantity, Amount, Remark);
        }

        Session["tempdata"] = mDTable;

        divSuppDetails.Attributes["class"] = "show";
        GetSupplierDetails();

        txtAccountName.Focus();
        lblSBillDID.Text = "0";
        txtAccountName.Text = "";
        txtQuantity.Text = "1";
        txtAmount.Text = "";
        txtRemark.Text = "";
        btnAddEdit.Text = "Add";
    }

    public void BindSupplierGrid()
    {
        if (SBillID != 0)
        {
            divSuppDetails.Attributes["class"] = "show";

            DataTable mEditDTable = new DataTable();
            DataTable mSuppDTable = new DataTable();
            SupplierBill sbillm = new SupplierBill();

            // Summary

            sbillm.Flag = "Edit";
            sbillm.SBillID = SBillID;

            mEditDTable = sbillm.GetSupplierDetails().Tables[0];
            lblSBillID.Text = mEditDTable.Rows[0]["SBillID"].ToString();
            lblSupplierCode.Text = mEditDTable.Rows[0]["SupplierCode"].ToString();
            txtSupplierName.Text = mEditDTable.Rows[0]["SupplierName"].ToString();
            lblPurchaseCode.Text = mEditDTable.Rows[0]["PurchaseCode"].ToString();
            txtPurchaseName.Text = mEditDTable.Rows[0]["PurchaseName"].ToString();
            txtInvoiceNo.Text = mEditDTable.Rows[0]["InvoiceNo"].ToString();
            txtInvoiceDate.Text = mEditDTable.Rows[0]["InvoiceDate"].ToString();

            BindGSTPerDropDown(lblSupplierCode.Text);
            ddlGSTPer.SelectedValue = mEditDTable.Rows[0]["GSTPer"].ToString();

            // Details

            sbillm.Flag = "Details";
            sbillm.SBillID = SBillID;

            mSuppDTable = sbillm.GetSupplierDetails().Tables[0];
            Session["tempdata"] = mSuppDTable;
        }
    }

    public void GetSupplierDetails()
    {
        DataTable mDTable = new DataTable();
        mDTable = (DataTable)Session["tempdata"];

        gvSupplierBill.DataSource = mDTable;
        gvSupplierBill.DataBind();

        if (lblSBillDID.Text == "0")
        {

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

            Amount = Amount + Convert.ToDecimal(lblAmount.Text);

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