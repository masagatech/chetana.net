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

public partial class Print_ReportInvoicePrint_New : System.Web.UI.Page
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
            dt = DCDetails.DC_Get_InvoiceDetails_On_subdocID(Convert.ToDecimal(Request.QueryString["sd"].ToString()), Convert.ToInt32(Request.QueryString["d"].ToString()));
            dt1 = DCDetails.Rep_DC_Get_Datails_OnSubdocno(Convert.ToInt32(Request.QueryString["d"].ToString()));
           // decimal Amount = Convert.ToDecimal(dt.Rows[0]["TotalAmount"]);
           // DataSet ds1 = new DataSet();
         //   ds1 = ActualInvoiceDetails.GetConvertion_fromnumber(Amount);
                      // dv.
            //objds.Tables.Add(dt);
          //  ds.Tables.Add(dt1.Tables[0]);
          //  DataView dv1 = new DataView();
         //    ds.Tables.Add(DCDetails.DC_Get_InvoiceDetails_On_subdocID(Convert.ToDecimal(Request.QueryString["sd"].ToString())).Tables[0]);
         //    ds.Tables.Add(DCDetails.Rep_DC_Get_Datails_OnSubdocno(Convert.ToInt32(Request.QueryString["d"].ToString())).Tables[0]);
           // DataView dv1 = new DataView(ds1.Tables[0]);

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../Report/PrintInvoice.rpt"));
          
            rd.Database.Tables[0].SetDataSource(dt);
            rd.Database.Tables[1].SetDataSource(dt1);
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
