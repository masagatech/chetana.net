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

public partial class DCConfirmationReport : System.Web.UI.Page
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
            Session["dcconfirmation"] = null;
            Bind_DDL_SuperZone();
        }
        if (IsPostBack)
        {
            if (Session["dcconfirmation"] != null)
            {
                Bind((DataTable)Session["dcconfirmation"]);
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
            a.Visible = false;
            txtfromDate.Focus();
        }
        else
        {
            a.Visible = true;
            dt = ActualInvoiceDetails.Idv_Chetana_Report_Get_DC_Confiramation(fdate, tdate, Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), Convert.ToInt32(strFY), "report", "", "").Tables[0];
            if (dt.Rows.Count != 0)
            {
                Session["dcconfirmation"] = dt;
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
        rd.Load(Server.MapPath("Report/DCDelayDetails.rpt"));
        rd.SetDataSource(dt1);
        a.ReportSource = rd;
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

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
            Bind_DDL_SuperZone();
        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

}
