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

public partial class ABC_AnalysisReport : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
  
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
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
            //Response.Write(strFY);


        }

        if (!Page.IsPostBack)
        {
            ViewState["Data"] = null;

            Bind_DDL_SuperZone();
            
           
           
        }
        if (IsPostBack)
        {
            if (ViewState["Data"] != null)
            {
                ShowDetails((DataTable)ViewState["Data"]);
                //DataTable dt = (DataTable)Cache["ABC"];
                
            }
        }
    }

    #region Get Date
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Scheme.Get_Report_ABC_Analysis(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),Convert.ToInt32(DDLZone.SelectedValue.ToString()), Convert.ToInt32(strFY),0);
        ViewState["Data"] = ds.Tables[0];
        ShowDetails(ds.Tables[0]);
   
    }
    #endregion
    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion
    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
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
    #region BindZone

    
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    #endregion 

    public void ShowDetails(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/ABCAnalysisrpt.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            ABCReportView.ReportSource = rd;
           // Cache.Insert("ABC", dt1, new CacheDependency(Server.MapPath("Report/ABCAnalysisrpt.rpt")));
            
        }
    }
}
