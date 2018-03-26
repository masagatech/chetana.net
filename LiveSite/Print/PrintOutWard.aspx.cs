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

public partial class Print_PrintOutWard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindOutWard();
    }
    public void BindOutWard()
    {
        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {

            DataTable dt = OutwardDetail.Get_OutwardDetails(Request.QueryString["d"].ToString().Trim(), Request.QueryString["sd"].ToString().Trim(), Request.QueryString["IOD"].ToString().Trim()
                , Convert.ToInt32(Request.QueryString["FY"].ToString().Trim())).Tables[0];
           
            DataView dv = new DataView(dt);
           

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../Report/OutWardReport.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
        
            Printoutward.ReportSource = rd;



        }
    }
}
