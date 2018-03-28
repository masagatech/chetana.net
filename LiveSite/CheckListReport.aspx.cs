using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
//using System.Web.Caching;
using System.Data;
using System.Web.Security;

public partial class CheckListReport : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfromDate.Focus();
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
            txtfromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            txttoDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Session["list1"] = null;
        }
        if (IsPostBack)
        {
            if (Session["list1"] != null)
            {
                Bind((DataTable)Session["list1"]);
                //Bind();
            }
        }

    }
    public void Bind(DataTable dt1)
    {
        ReportDocument rd = new ReportDocument();
        if (rdbselect.SelectedValue == "SuperZone")
        {
            rd.Load(Server.MapPath("Report/DatewiseChecklist.rpt"));
            rd.SetDataSource(dt1);
            Checklistrpt.ReportSource = rd;
        }
        else
        {
            rd.Load(Server.MapPath("Report/DateWiseChecklistReport_InvoiceNoWise.rpt"));
            rd.SetDataSource(dt1);
            Checklistrpt.ReportSource = rd;
        }
        //ReportDocument rd = new ReportDocument();

        //      // btnPrint.Visible = true;
        //       InvoiceReport.Visible = true;
        //       rd.Load(Server.MapPath("Report/DateWiseInvoiceReport.rpt"));
        //       rd.SetDataSource(dt1);
        //       InvoiceReport.ReportSource = rd;
    }

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

    protected void btnget_Click(object sender, EventArgs e)
    {
        string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            Checklistrpt.Visible = false;
            
            txtfromDate.Focus();
        }
        else
        {

            dt = ActualInvoiceDetails.Get_Invoice_OnDatechecklist(fdate, tdate).Tables[0];
            if (dt.Rows.Count != 0)
            {
                Session["list1"] = dt;
                Bind(dt);
            }
            else
            {
                MessageBox("No Record Found");

            }
        }
        //Bind(0);
    }
}