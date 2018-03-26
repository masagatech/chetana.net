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

public partial class Token_Pending_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = Session["TokenPendingReport"] as DataTable;
        if (dt.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(MapPath("~/Report/TokenRegisterPending.rpt"));
            rd.SetDataSource(dt);
            TokenPendingReportView.ReportSource = rd;
        }
        
    }
}
