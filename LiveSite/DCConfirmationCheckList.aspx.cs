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
using System.Web.Caching;

public partial class DCConfirmationCheckList : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;
    string strFY = "";
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        //{
        //    string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
        //    if (Session["Role"] != null)
        //    {
        //        if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
        //        {
        //            Response.Redirect("dashboard.aspx");
        //        }

        //    }
        //}
        if (Session["FY"] != null)
        {

            strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            // txtfromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            // txttoDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Session["dcconfirmationchecklist"] = null;
           
        }
        if (IsPostBack)
        {
            if (Session["dcconfirmationchecklist"] != null)
            {
                Bind((DataTable)Session["dcconfirmationchecklist"]);
                //Bind();
            }
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            confirmchecklist.Visible = false;
            txtfromDate.Focus();
        }
        else
        {
            confirmchecklist.Visible = true;
            dt = ActualInvoiceDetails.Idv_Chetana_Report_Get_DC_Confiramation(fdate, tdate, 0, 0, Convert.ToInt32(strFY), "checkList", "", "").Tables[0];
            if (dt.Rows.Count != 0)
            {
                Session["dcconfirmationchecklist"] = dt;
                Bind(dt);
            }
            else
            {
                MessageBox("No Record Found");

            }
        }
    }
    public void Bind(DataTable dt1)
    {
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/DCConfirmationCheckList.rpt"));
        rd.SetDataSource(dt1);
        confirmchecklist.ReportSource = rd;
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

}
