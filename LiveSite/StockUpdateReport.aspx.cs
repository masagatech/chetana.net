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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;

public partial class StockUpdateReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Txtbkcode.Focus();
        if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
            if (Session["Role"] != null)
            {
                if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
                {
                    Response.Redirect("dashboard.aspx");
                }
            }
        }
        fillStockreport();
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        fillStockreport();  
    }

    private void fillStockreport()
    {
        string bookcode = Txtbkcode.Text.Split(':')[0].Trim();

        if (Txtbkcode.Text != "")
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Idv.Chetana.BAL.StockUpdate.GetStockUpdateRep(bookcode).Tables[0];
                 if (dt.Rows.Count > 0)
                 {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/StockUpdate.rpt"));
                    CR.SetDataSource(dt);
                    crystalreportviewer1.ReportSource = CR;
                 }
                 else
                 {
                     MessageBox("No Records Found");
                     Txtbkcode.Focus();
                 }
            }
            catch { }
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

}
