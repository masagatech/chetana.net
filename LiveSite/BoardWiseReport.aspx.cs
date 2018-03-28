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

public partial class BoardWiseReport : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName;
    string strFY;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "")
        {
            if (Session["FY"] != "")
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
            ViewState["Board"] = null;
            ddlSDZone.Focus();
            Bind_DDl_SDZone();
            Bind_DDl_Board();
        }

        if (IsPostBack)
        {
            if (ViewState["Board"] != null)
            {
                ShowDetails((DataTable)ViewState["Board"]);
            }
        }  
    }

  
    #region GetData

    protected void btnget_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Scheme.Get_Report_BoardWise(Convert.ToInt32(ddlBoard.SelectedValue.ToString()), Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDlZone.SelectedValue.ToString()),
            Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), Convert.ToInt32(strFY));
        ViewState["Board"] = ds.Tables[0];
        ShowDetails(ds.Tables[0]);
       
    }
    #endregion
    #region Selected Index Changed
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDlZone.SelectedIndex == 0)
        {
            Bind_DDL_Zone();
            DDlZone.Focus();
        }
        else
        {

        }
    }
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            DDlZone.Items.Clear();
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
    }
    #endregion
    #region Bind Data
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    public void Bind_DDl_Board()
    {
        ddlBoard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup("Board").Tables[0];
        ddlBoard.DataBind();
        ddlBoard.Items.Insert(0, new ListItem("--Select Board--", "0"));
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

    #endregion

    public void ShowDetails(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/BoardWise.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            BoardReportview.ReportSource = rd;
        }
    }
}
