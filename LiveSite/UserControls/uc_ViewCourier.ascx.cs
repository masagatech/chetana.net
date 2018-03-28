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
using System.Data.SqlClient;

public partial class UserControls_uc_ViewCourier : System.Web.UI.UserControl
{
    #region Varables

    static int quantity = 0;
    static decimal APODId = 0;
    static decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    static int docnewno = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    string DocNo;
    #endregion
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
        if (IsPostBack == true) { return; }

        lblMessage.Text = "";
    }
    protected void btnget_Click(object sender, EventArgs e)
    {

        ViewState["DocNo"] = ViewState["DocNo"] + "," + txtDocNoGet.Text + ",";
        DataTable Ds = new DataTable();
        if (txtCourierId.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtCourierId.Text), "CourierId", Convert.ToInt32(strFY)).Tables[0];

        }
        else if (txtInvoiceNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY)).Tables[0];

        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY)).Tables[0];

        }

        grdCD.DataSource = Ds;
        grdCD.DataBind();

    }
    protected void btnUpdatePOD_Click(object sender, EventArgs e)
    {

    }
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            APODId = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSCMasterAutoId = (Label)e.Row.Parent.Parent.Parent.FindControl("lblSCMasterAutoId");
            Label lblDocumentNo = (Label)e.Row.Parent.Parent.Parent.FindControl("lblDocumentNo");
            Label lblInvoiceNo = (Label)e.Row.Parent.Parent.Parent.FindControl("lblInvoiceNo");
            TextBox txtPODId = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txtPODId");
            lblSCMasterAutoId = (Label)e.Row.FindControl("lblSCMasterAutoId");
            txtPODId = (TextBox)e.Row.FindControl("txtPODId");
            lblDocumentNo = (Label)e.Row.FindControl("lblDocumentNo");

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
        }



    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

    }
    

}