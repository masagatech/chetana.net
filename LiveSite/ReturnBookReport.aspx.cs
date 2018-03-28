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


public partial class ReturnBookReport : System.Web.UI.Page
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
            fillReturnBookreport();
        }
    }

    private void fillReturnBookreport()
    {             
            try
            {
                DataTable dt = new DataTable();
                dt = ReturnBook.GetReturnBookR((Convert.ToInt32(DDLSalesman.SelectedItem.Value)),"Getrecords").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/ReturnBook_SalesmanWise_Report.rpt"));
                    CR.SetDataSource(dt);
                    crystalreportviewer1.ReportSource = CR;
                }
                else
                {
                    MessageBox("Records Not Found");
                    DDLSalesman.Focus();
                }
            }
            catch { }
    }

    protected void btngetRec_Click(object sender, EventArgs e)
    {
        fillReturnBookreport();

    }

    #region Get All Salesman

    public void BindSalesman()
    {
        DDLSalesman.DataSource = Employee.GetEmployeeByFlag(2);
        DDLSalesman.DataBind();
        DDLSalesman.Items.Insert(0, new ListItem("-- Select M R --", "0"));
    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

}
