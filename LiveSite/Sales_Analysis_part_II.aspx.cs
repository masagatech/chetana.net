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

public partial class Sales_Analysis_part_II : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    DateTime fdate, tdate;
    string from, To;
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
        
            if (Session["FY"] != "")
            {
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        
        if (!Page.IsPostBack)
        {
            ddlSDZone.Focus();
            Bind_DDl_SDZone();
            ViewState["partII"] = null;
        }
        if (IsPostBack)
        {
            if (ViewState["partII"] != null)
            {
                ShowDetails((DataTable)ViewState["partII"]);
            }
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }

        else
        {
            //ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate, Convert.ToInt32(DDlZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim());
            ds = Other.Dashboard.Get_SalesAnalysis_PART_II(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate, Convert.ToInt32(DDlZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim(),
                Convert.ToInt32(ddlSDZone.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["partII"] = ds.Tables[0];
                ShowDetails(ds.Tables[0]);

            }
            else
            {
                MessageBox("Records Not Found");
                DDLSuperZone.Focus();
            }
        }



    }
    public void ShowDetails(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            DataView dv = new DataView(dt1);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/SalesAnalysisPart_II.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            SalesanalysisReportview.ReportSource = rd;
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDlZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            Bind_DDL_Zone();
            DDlZone.Focus();

            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {

        }
    }

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");

            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            DDlZone.Items.Clear();
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
    }
    public void Bind_DDL_Zone()
    {
        DDlZone.Items.Clear();
        DDlZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDlZone.DataBind();
        DDlZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

    public void Bind_DDL_SuperZone()
    {
        //Response.Write(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()));
        DDlZone.Items.Clear();
        DDLSuperZone.Items.Clear();
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        DDlZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));

    }
    public void Bind_DDl_SDZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        DDlZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
}
