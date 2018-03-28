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

public partial class Salesman_CustomerWise : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;
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
        DDLSalesman.Focus();
        fillcutomerreport();
        if (!Page.IsPostBack)
        {
            BindSalesman();
        }
    }
    
    protected void btnget_Click(object sender, EventArgs e)
    {
        fillcutomerreport();
        //Get_Customer_SalesmanwiseBooks
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
    #endregion
    protected void DDLSalesman_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    private void fillcutomerreport()
    {
        if (txtfromDate.Text != "" && txttoDate.Text != "" && DDLSalesman.SelectedItem.Value != "")
        {
            string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
            string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
            fdate = Convert.ToDateTime(from);
            tdate = Convert.ToDateTime(To);
            if (fdate > tdate)
            {
                MessageBox("From Date is Greater than ToDate");
                txtfromDate.Focus();
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = Specimen.Get_Customer_SalesmanwiseBooks(DDLSalesman.SelectedItem.Value.ToString(), Convert.ToDateTime(from), Convert.ToDateTime(To)).Tables[0];          
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/Salesmen_Customerwise_Report.rpt"));
                    CR.SetDataSource(dt);
                    crystalreportviewer1.ReportSource = CR;
                }
                catch { }
            }
        }
    }
}
