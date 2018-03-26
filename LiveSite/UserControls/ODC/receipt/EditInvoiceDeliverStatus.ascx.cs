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

public partial class UserControls_ODC_receipt_EditInvoiceDeliverStatus : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "cppl";
    string strFY ="0";
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
            Session["tempdata"] = null;
            lblID.Text = "0";
            txtInvoive.Focus();
        }

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
            {
        InvoiceDeliveryStatus inv = new InvoiceDeliveryStatus();
        inv.AutoId = Convert.ToInt32(lblID.Text);
        inv.CustCode = txtCustcode.Text.Trim();
        inv.CustName = txtCustName.Text.Trim();
        inv.Area = txtArea.Text.Trim();
        inv.CreatedBy = Session["UserName"].ToString();
        inv.InvoiceNo = Convert.ToDecimal(txtInvoive.Text.Trim());
        inv.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.Trim());
        inv.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());
        inv.Fy = Convert.ToInt32(strFY);
        if (chkCheck.Checked == true)
        {
            inv.DeliveryStatus = "Y";
        }
        else
        {
            inv.DeliveryStatus = "N";
        }
        inv.Save();
        MessageBox("Record Updated Successfully");
        txtArea.Text = "";
        txtCustcode.Text = "";
        txtCustName.Text = "";
        txtInvoiceDate.Text = "";
        txtInvoive.Text = "";
        txtTotalAmount.Text = "";
        lblID.Text = "";
        chkCheck.Checked = false;
        }
    }
    
    protected void txtInvoive_TextChanged(object sender, EventArgs e)
    {
        decimal InvoiceNo = Convert.ToDecimal(txtInvoive.Text.Trim());
        int Fy = Convert.ToInt32(strFY);
        DataTable dt = new DataTable();
        dt = InvoiceDeliveryStatus.Idv_Chetana_EditInvoiceDelivery_Status(InvoiceNo, Fy).Tables[0];
        if (dt.Rows.Count != 0)
        {
            lblID.Text = dt.Rows[0]["AutoId"].ToString();
            txtInvoiceDate.Text = dt.Rows[0]["InvoiceDate"].ToString();
            txtTotalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
            txtCustName.Text = dt.Rows[0]["CustName"].ToString();
            txtCustcode.Text = dt.Rows[0]["CustCode"].ToString();
            txtArea.Text = dt.Rows[0]["Area"].ToString();
           // lblStatus.Text = dt.Rows[0]["DeliveryStatus"].ToString();
            if (dt.Rows[0]["DeliveryStatus"].ToString() == "Y")
            {
                chkCheck.Checked = true;
            }
            else
            {
                chkCheck.Checked = false;
            }
        }
        else
        { MessageBox("Invoice No. does not Exists"); }
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
}
