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

public partial class Trial_Balance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        //{
        //    string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
        //    if (Session["Role"] != null)
        //    {
        //        if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
        //        {
        //            Response.Redirect("dashboard.aspx");
        //        }

        //    }
        //}
        if (!Page.IsPostBack)
        {
            DDLSuperZone.DataSource = Masters.Get_Masters_Code_ID_Name("superzone");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "none"));
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintSalesAnalysis.aspx?d=" + DDLSuperZone.SelectedValue + "')", true);
        }
        else
        {
            MessageBox("Records Not Available");
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
