#region NameSpaces
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
using Idv.Chetana.BAL;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Caching;

#endregion

public partial class MultiYear_SalesAnalysis : System.Web.UI.Page
{
    #region Variables
    static DataSet DS;
    string strChetanaCompanyName = "cppl";
    string strFY;
    static DateTime fdate;
    static DateTime tdate;
    #endregion
    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
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
            ViewState["MYSR"] = null;

        }
        if (IsPostBack)
        {
            if (ViewState["MYSR"] != null)
            {
                BindDLDashboard((DataTable)ViewState["MYSR"]);
                //DataTable dt = (DataTable)Cache["ABC"];

            }
        }
    }

    #endregion
    #region Get Data

    protected void btnget_Click(object sender, EventArgs e)
    {
        DS = new DataSet();
        DS = Other.Dashboard.Get_Summary_SalesAnalysis(Convert.ToInt32(ddlSDZone.SelectedValue), Convert.ToInt32(strFY), Convert.ToInt32(DDLSuperZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim()
                );
        BindDLDashboard(DS.Tables[0]);
        ViewState["MYSR"] = DS.Tables[0];
    }

    #endregion
    #region Link Button Events

    protected void lnkszname_Click(object sender, EventArgs e)
    {

    }

    protected void lnkzone_Click(object sender , EventArgs e)
    {
    }

    #endregion
    #region Event

    protected void DLDashboard_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView GrdDashboard = (GridView)e.Item.FindControl("GrdDashboard");
            Label SuperZoneName = (Label)e.Item.FindControl("lblSzname");

            DataView dv = new DataView(DS.Tables[0]);
            dv.RowFilter = "SuperZoneName = '" + SuperZoneName.Text.ToString().Trim() + "'";

            GrdDashboard.DataSource = dv;
            GrdDashboard.DataBind();
        }
    }

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
    }

    #endregion
    #region Bind DropDown

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.Items.Clear();
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
       

    }
    public void Bind_DDl_SDZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));

    }

    #endregion 
    #region Bind Datalist

    public void BindDLDashboard(DataTable dt1)
    {
        
        //DLDashboard.DataSource = DS.Tables[2];
       // DLDashboard.DataBind();

        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/MYSR.rpt"));
        rd.Database.Tables[0].SetDataSource(dt1);
        multiyearReportview.ReportSource = rd;
        
    }
   
    #endregion
}
