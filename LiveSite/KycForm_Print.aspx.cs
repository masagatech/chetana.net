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
using Other_Z;
using CrystalDecisions.CrystalReports.Engine;

public partial class KycForm_Print : System.Web.UI.Page
{
    #region Goloval Veriable
    string strFY;
    Other_Z.OtherBAL ObjBal = new OtherBAL();
    ReportDocument rd = new ReportDocument();
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            if (!Page.IsPostBack)
            {
                strFY = Session["FY"].ToString();
                txtFrom.Focus();
            }
        }
        if (txtIsExport.Value == "yes")
        {
            PrintKycForm();
            txtIsExport.Value = "";
        }
    }
    #endregion

    #region Kyc Print Button Click
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        PrintKycForm();

    }
    #endregion

    #region Kyc Form Print
    private void PrintKycForm()
    {
        DataSet ds = ObjBal.Idv_Chetana_Get_KycForm(Convert.ToInt32("0"), Convert.ToInt32(Session["FY"]), Convert.ToInt32(txtFrom.Text),
           Convert.ToInt32(txtTo.Text), "kycviewprint", "", "", "");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            rd.Load(Server.MapPath("Report/KycFormPrint.rpt"));
            rd.SetDataSource(dt);
            KycFormPrint.ReportSource = rd;
        }
    }
    #endregion

    #region Navigation Crystal Report Event
    protected void KycFormPrint_Navigate(object sender, CrystalDecisions.Web.NavigateEventArgs e)
    {
        PrintKycForm();
    }
    #endregion

    protected void KycFormPrint_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
    {
        PrintKycForm();
    }
    protected void KycFormPrint_Search(object source, CrystalDecisions.Web.SearchEventArgs e)
    {
        PrintKycForm();
    }
}
