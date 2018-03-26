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

public partial class Print_PrintInvoiceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindInvoice();
    }
    public void bindInvoice()
    {
        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {


            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            ds = Idv.Chetana.BAL.SpecimanDetails.Idv_Chetana_Get_SpecTransporterAndDetails_Report1(Convert.ToDecimal(Request.QueryString["sd"].ToString().Trim()));
            ds2 = Idv.Chetana.BAL.SpecimanDetails.Idv_Chetana_DC_Get_Details_By_DocNO_Report3(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()));
            ds3 = Idv.Chetana.BAL.SpecimanDetails.Idv_Chetana_Get_SubDocId_And_ItsRecords_By_DocNo_forReport(Convert.ToDecimal(Request.QueryString["sd"].ToString().Trim()));
            DataView dv = new DataView(ds.Tables[0]);
            DataView dv1 = new DataView(ds2.Tables[0]);
            DataView dv2 = new DataView(ds3.Tables[0]);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../Report/PrintInvoiceReport.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            rd.Database.Tables[1].SetDataSource(dv1);
            rd.Database.Tables[2].SetDataSource(dv2);
            PrintInvoice.ReportSource = rd;


           
        }
    }
}
