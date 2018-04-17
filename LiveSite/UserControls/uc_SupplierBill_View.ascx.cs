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

public partial class UserControls_uc_SupplierBill_View : System.Web.UI.UserControl
{
    #region "Filed And Properties"

    string strCompany = "cppl";
    string strFY = "0";
    string xmlstr;

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
            GetSupplierDetails();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["tempdata"] = null;
        Response.Redirect("SupplierBill.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int SBillID = Convert.ToInt32(((Label)((Button)sender).FindControl("lblSBillID")).Text);
        Session["tempdata"] = null;
        Response.Redirect("SupplierBill.aspx?SBillID=" + SBillID);
    }

    #endregion

    #region "User-Defined Function"

    public void GetSupplierDetails()
    {
        DataSet mDSet = new DataSet();
        SupplierBill sbillm = new SupplierBill();

        sbillm.Flag = "All";
        sbillm.SBillID = 0;
        sbillm.InvoiceNo = 0;
        //sbillm.FromDate = "";
        //sbillm.ToDate = "";

        mDSet = sbillm.GetSupplierDetails();

        gvSupplierBill.DataSource = mDSet.Tables[0];
        gvSupplierBill.DataBind();
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