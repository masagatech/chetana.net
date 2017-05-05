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

public partial class CustomerTODReport : System.Web.UI.Page
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!Page.IsPostBack)
        {
            Session["TodRpt"] = null;
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            Bind_DDL_CC();

        }
        if (txtIsExport.Value == "yes")
        {
            ShowDetails();
            txtIsExport.Value = "";
        }
    }



    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["TodRpt"] = null;
        ShowDetails();
    }
    public void ShowDetails()
    {
        DataSet ds = new DataSet();

        if (Session["TodRpt"] != null)
        {

            ds = (DataSet)Session["TodRpt"];
        }
        else
        {
            ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_TODReport(
               Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
               Convert.ToInt32(DDLZone.SelectedValue.ToString()),
               Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
               Convert.ToInt32(DDLCC.SelectedValue.ToString()),
               Convert.ToInt32(strFY));
        }
        DataView dv = new DataView(ds.Tables[0]);
        ReportDocument rd = new ReportDocument();
        if (rdAorI.SelectedValue.ToString() == "All")
        {
            rd.Load(Server.MapPath("Report/TODReport.rpt"));
        }
        else
        {
            rd.Load(Server.MapPath("Report/TODReportNew.rpt"));
            //rd.Load(Server.MapPath("Report/TODTest.rpt"));
        }

        rd.Database.Tables[0].SetDataSource(dv);
        CustomerWiseAmount.ReportSource = rd;
    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bind_DDL_Zone();


    }

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            DDLZone.Focus();
            ddlCustmore.Items.Clear();
            ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));
        }
        else
        {
            Bind_DDL_Customer();
            ddlCustmore.Focus();
        }

    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-All Zone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));

    }
    public void Bind_DDL_Zone()
    {
        DDLZone.Items.Clear();
        ddlCustmore.Items.Clear();
        if (DDLSuperZone.SelectedIndex > 0)
        {
            DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
            DDLZone.DataBind();
            DDLZone.Focus();
            DDLZone.Items.Insert(0, new ListItem("-All Zone-", "0"));
            ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));
        
        }
        else {
            DDLZone.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
            ddlCustmore.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
        
        }
        customerDisabled();

    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
        customerDisabled();
    }
    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-All Customer Category-", "0"));
    }
    protected void CrystalReportPartsViewer1_Init(object sender, EventArgs e)
    {

    }
    protected void DDLCC_SelectedIndexChanged(object sender, EventArgs e)
    {
        customerDisabled();
    }

    private void customerDisabled()
    {
        if (DDLCC.SelectedIndex > 0)
        {


            ddlCustmore.SelectedIndex = 0;
            ddlCustmore.Enabled = false;
        }
        else
        {
            ddlCustmore.Enabled = true;
        }
    }
    protected void CustomerWiseAmount_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {
        ShowDetails();
    }
    protected void CustomerWiseAmount_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
    {
        ShowDetails();

    }
    protected void CustomerWiseAmount_Search(object source, CrystalDecisions.Web.SearchEventArgs e)
    {
        ShowDetails();

    }
}




