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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;

public partial class Godown_print_LocalGodownPrint : System.Web.UI.Page
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
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


        }
        
            bindReport();
       
    }
    public void bindReport()
    {
        if (Request.QueryString["d"] != null && Request.QueryString["L"] != null)
        {

            DataSet ds = new DataSet();
            ds = G_GetPass.Local_Report(Convert.ToInt32(Request.QueryString["d"].ToString()), Request.QueryString["L"].ToString(), Convert.ToInt32(strFY));


            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../reports/LocalGodownReport.rpt"));

            rd.Database.Tables[0].SetDataSource(ds.Tables[0]);         


            LocalGodown.ReportSource = rd;
            LocalGodown.DataBind();
        }
    }
}
