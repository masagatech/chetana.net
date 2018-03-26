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
using Idv.Chetana.CnF;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;

public partial class CNF_print_CPrintInvoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindReport();
    }

    public void bindReport()
    {
        if (Request.QueryString["d"] != null)
        {

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = CnFInvoice.GetInvoiceDetails(Convert.ToInt32(Request.QueryString["d"].ToString()), "print", Convert.ToInt32(Request.QueryString["fy"].ToString())).Tables[0];
           
            ReportDocument rd = new ReportDocument();
           
                rd.Load(Server.MapPath("../report/C_PrintInvoice.rpt"));

            rd.Database.Tables[0].SetDataSource(dt);
          //  rd.Database.Tables[1].SetDataSource(dt1);
            //  rd.Database.Tables[2].SetDataSource(ds1.Tables[0]);
            // rd.SetDataSource(dt);
            //   rd.SetDataSource(dt1);
            //   rd.SetParameterValue(1, Convert.ToDecimal(Request.QueryString["sd"].ToString()));
            //  rd.SetParameterValue(0,Convert.ToInt32(Request.QueryString["d"].ToString()));

            CrptInvoice.ReportSource = rd;
            CrptInvoice.DataBind();
        }
    }
}
