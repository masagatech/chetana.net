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

public partial class UserControls_ODC_receipt_InvoiceDeliverStatus : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
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
            Id.Text = "0";
            txtInvoive.Focus();
            chkCheck.Checked = true;
        }

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            InvoiceDeliveryStatus inv = new InvoiceDeliveryStatus();
            inv.AutoId = Convert.ToInt32("0");
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
            MessageBox("Record Save Successfully");
            txtArea.Text = "";
            txtCustcode.Text = "";
            txtCustName.Text = "";
            txtInvoiceDate.Text = "";
            txtInvoive.Text = "";
            txtTotalAmount.Text = "";
            Id.Text = "";
            chkCheck.Checked = true;
        }
    }

    protected void txtInvoive_TextChanged(object sender, EventArgs e)
    {
        decimal InvoiceNo = Convert.ToDecimal(txtInvoive.Text.Trim());
        int Fy = Convert.ToInt32(strFY);
        DataSet ds = new DataSet();
        ds = InvoiceDeliveryStatus.Idv_Chetana_GetInvoiceDeliveryStatusDetails(InvoiceNo, Fy);
        bool Flag;
        if ((ds.Tables[1].Rows[0]["auth"].ToString()) == "1")
        {
            Flag = true;
        }
        else
        {
            Flag = false;
        }
        if (ds.Tables[1].Rows.Count != 0)
        {
            if (Flag)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    txtInvoiceDate.Text = dt.Rows[0]["InvoiceDate"].ToString();
                    txtTotalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                    txtCustName.Text = dt.Rows[0]["CustName"].ToString();
                    txtCustcode.Text = dt.Rows[0]["CustCode"].ToString();
                    txtArea.Text = dt.Rows[0]["AreaName"].ToString();
                    BtnSave.Focus();
                }
                else
                { MessageBox("Invoice No. does not Exists");
                txtInvoive.Focus();
                }
            }
            else
            {
                MessageBox("Invoice No. already Exists");
                txtInvoive.Focus();
                txtInvoiceDate.Text = "";
                txtTotalAmount.Text = "";
                txtCustName.Text = "";
                txtCustcode.Text = "";
                txtArea.Text = "";
            }
        }
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
}
