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
using System.Net.Mail;
using System.Text;
using System.IO;
public partial class UserControls_uc_DispatchEmail : System.Web.UI.UserControl
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlDetailsForm.Visible = false;
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }

    }
    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    pnlDetails.Visible = true;
           
        //    DataSet ds6 = new DataSet();
        //    //ds6 = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno");
        //    grdconfirm.DataSource = G_GetPass.GetpassOnDocNo(Convert.ToInt32(txtDC.Text.Trim()), "O", Convert.ToInt32(strFY)).Tables[0];
        //    grdconfirm.DataBind();

        //    // pnlDetails.Visible = true;
        //    grdconfirm.Visible = true;
            
        //}
        //catch { }

        pnlDetailsForm.Visible = true;
        fillEditForm();
        //fillEditGrid();
    }
    public void fillEditGrid()
    {
        pnlDetailsGrid.Visible = true;
        DataTable dt = G_GetPass.GetpassOnDCNo(Convert.ToInt32(txtDC.Text.Trim()), rdoOL.SelectedValue.ToString(), Convert.ToInt32(strFY)).Tables[0];
        grdOL.DataSource = dt;
        grdOL.DataBind();
        grdOL.Visible = true;
    }
    public void fillEditForm()
    {
        Clear();
        DataTable dt = G_GetPass.GetpassOnDCNo(Convert.ToInt32(txtDC.Text.Trim()), rdoOL.SelectedValue.ToString(), Convert.ToInt32(strFY)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            string date = (Convert.ToDateTime(dt.Rows[0]["Doc_Date"].ToString())).ToString("dd/MM/yyyy");
            string LRdate = (Convert.ToDateTime(dt.Rows[0]["LR_Date"].ToString())).ToString("dd/MM/yyyy");
            txtDocNo.Text = dt.Rows[0]["Doc_No"].ToString();
            lblDocNo.Text = dt.Rows[0]["Doc_ID"].ToString();
            txtDcNo.Text = dt.Rows[0]["DC_No"].ToString();
            txtBillNo.Text = dt.Rows[0]["Bill_Nos"].ToString();
            lblclone.Text = dt.Rows[0]["Bill_Nos"].ToString();
            txtcustomer.Text = dt.Rows[0]["CustomerName"].ToString();
            lblCustID.Text = dt.Rows[0]["Cust_ID"].ToString();
            txttransporter.Text = dt.Rows[0]["Trasporter"].ToString();
            lblTransID.Text = dt.Rows[0]["Transporter_ID"].ToString();
            txtNoOfBund.Text = dt.Rows[0]["No_Bundles"].ToString();
            txtValOfGoods.Text = dt.Rows[0]["Value_Goods"].ToString();
            txtSentBy.Text = dt.Rows[0]["Sent_By"].ToString();
            txtLRNo.Text = dt.Rows[0]["LR_No"].ToString();
            txtLrDate.Text = LRdate;
            chIsDelivery.Checked = Convert.ToBoolean(dt.Rows[0]["Delivery"].ToString());
            txtAmt.Text = dt.Rows[0]["Amount"].ToString();
            rdoPaidStaus.SelectedValue = dt.Rows[0]["Pay_Paid"].ToString();
            txtDocDate.Text = date; dt.Rows[0]["Amount"].ToString();
            txtRemark.Text = dt.Rows[0]["Remark1"].ToString();
            txtDocDate.Focus();

        }
        else
        {
            txtDC.Text = "";
            txtDC.Focus();
        }
    }

    public void Clear()
    {
        lblDocNo.Text = "0";
        txtDocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDcNo.Text = "";
        txtBillNo.Text = "";
        txtcustomer.Text = "";
        lblCustomer.Text = "";
        txttransporter.Text = "";
        lbltransporter.Text = "";
        txtNoOfBund.Text = "";
        txtValOfGoods.Text = "";
        txtSentBy.Text = "";
        txtLRNo.Text = "";
        txtLrDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtAmt.Text = "";
        chIsDelivery.Checked = false;
        txtDocNo.Text = "---New---";
    }

    
    protected void  btnEmail_Click(object sender, EventArgs e)
    {
        int dcid = Convert.ToInt32(txtDC.Text.Trim());
        string rdid = rdoOL.SelectedValue.ToString();
        Response.Redirect("SendEmail.aspx?dcid=" + dcid);
    }
}