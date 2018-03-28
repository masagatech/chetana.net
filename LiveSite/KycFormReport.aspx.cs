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
using Other_Z;

public partial class KycFormReport : System.Web.UI.Page
{
    #region Goloval Veriable
    string strFy;
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            KycFormPrintDocument();
        }
	if (txtIsExport.Value == "yes")
        {
            KycFormPrintDocument();
            txtIsExport.Value = "";
        }
    }
    #endregion

    #region Kyc Form Print Method

    public void KycFormPrintDocument()
    {
        if (Request.QueryString["KycNo"] != null)
        {
            int KycNo = Convert.ToInt32(Request.QueryString["KycNo"].ToString());
            Other_Z.OtherBAL ObjBAL = new OtherBAL();
            string strFy = Session["FY"].ToString();
            DataSet ds = ObjBAL.Idv_Chetana_Report_KycForm(KycNo,Convert.ToInt32(strFy),"kycprint");
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/KycForm.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            KycFormReportDoc.ReportSource = rd;
        
        }
    }
    #endregion
}
