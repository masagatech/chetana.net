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

using CrystalDecisions.CrystalReports.Engine;


public partial class TestReportInvoice : System.Web.UI.Page
{

    #region Variables
    string EmpCode;
    #endregion

    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
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
        EmpCode = Convert.ToString(Session["UserName"]);
        DataSet ds = new DataSet();
        ds = Customer_cs.GetSchool_Names(EmpCode);
        DdlCustomer.DataSource = ds;
        DdlCustomer.DataBind();
        DdlCustomer.Items.Insert(0, new ListItem("-Select-", "0")); 
    }

    #endregion

    #region SubConfirmIDWise Report
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = Specimen.Get_SpecimenDetailsForInvoice(Convert.ToInt32(TextBox1.Text), Convert.ToDecimal("1.01")).Tables[0];
        // dt = Specimen.Get_SpecimenDetailsForInvoice().Tables[0];
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/SpecimenReport.rpt"));
        crystalReport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalReport;
    }
    #endregion

    #region BookWise Report
    protected void BtnBookwise_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
//        dt = Specimen.Get_SpecimenDetailsForInvoice_Bookwise(Convert.ToInt32(TextBox1.Text)).Tables[0];
        // dt = Specimen.Get_SpecimenDetailsForInvoice().Tables[0];
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/BookWiseReport.rpt"));
        crystalReport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalReport;
    }
    #endregion

    #region CrystalReportViewer Event
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
    #endregion

    #region CustomerWise Report
    protected void BtnCustomerwise_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
//        dt = Specimen.Get_SpecimenDetailsForInvoice_Customerwise(Convert.ToInt32(DdlCustomer.SelectedValue)).Tables[0];
        // dt = Specimen.Get_SpecimenDetailsForInvoice().Tables[0];
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/CustomerWiseReport.rpt"));
        crystalReport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalReport;

    }
    #endregion
    
}
