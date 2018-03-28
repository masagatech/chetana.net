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

public partial class SalesmanWiseBooks : System.Web.UI.Page
{
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
        if (!Page.IsPostBack)
        {
            BindSalesman();
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
//        dt = Specimen.Get_SalesmanWiseBooks(DDLSalesman.SelectedItem.Value.ToString()).Tables[0];
        ReportDocument CR = new ReportDocument();
        CR.Load(Server.MapPath("SalesmanWiseBooks.rpt"));
        CR.SetDataSource(dt);
        crystalreportviewer1.ReportSource = CR;
        
    }
    #region Get All Salesman

    public void BindSalesman()
    {
        DDLSalesman.DataSource = Employee.GetEmployeeByFlag(2);
        DDLSalesman.DataBind();
        DDLSalesman.Items.Insert(0, new ListItem("-- Select Salesman --"));
    }

    #endregion
}
