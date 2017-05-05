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


public partial class Print_PrintDC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindPrintDC();
    }
    public void BindPrintDC()
    {
        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();

            ds = Idv.Chetana.BAL.ActualInvoiceDetails.Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno2(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()),
                Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()));
            ds2 = Idv.Chetana.BAL.ActualInvoiceDetails.Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno1(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()), 
                Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()));
           
            DataView dv = new DataView(ds.Tables[0]);
            DataView dv1 = new DataView(ds2.Tables[0]);
          
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../Report/PrintDCPending.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            rd.Database.Tables[1].SetDataSource(dv1);

            PrintDC.ReportSource = rd;



        }
    }
}
