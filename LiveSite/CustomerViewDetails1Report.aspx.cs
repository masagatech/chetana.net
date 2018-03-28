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
public partial class UserControls_CustomerViewDetails1 : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
          if (Session["ChetanaCompanyName"] != null)
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
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {
            if (ddlCustmore.SelectedValue.ToLower().ToString() == "none" || ddlCustmore.SelectedValue.ToLower().ToString() == "")
            {
                
            }
            else
            {
                ShowDetails();
             
            }
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            btnSave.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "none"));
                
        }
        if (ddlCustmore.SelectedValue.ToLower().ToString() == "none" || ddlCustmore.SelectedValue.ToLower().ToString() == "")
        {

        }
        else
        {
            ShowDetails();
         }
    }
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

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLZone.Focus();
            ddlCustmore.Items.Clear();
            //  DDLZone.SelectedValue = null;
            Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_Customer();
            ddlCustmore.Focus();
        }
        
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "none"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "none"));
    }
    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "none"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }
    public void ShowDetails()
    {

        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Specimen.Idv_Chetana_Customer_ZoneDate_Report(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY));
        DataSet ds2 = new DataSet();
        ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
        DataView dv = new DataView(ds.Tables[0]);
        DataView dv2 = new DataView(ds2.Tables[0]);
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/CustomerZoneReport.rpt"));
        rd.Database.Tables[0].SetDataSource(dv);
        rd.Database.Tables[1].SetDataSource(dv2);
        //rd.SetDataSource(ds);
        CustomerReportView.ReportSource = rd;
    }
}
