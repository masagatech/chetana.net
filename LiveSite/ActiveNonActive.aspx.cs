using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using System.Data;

public partial class ActiveNonActive : System.Web.UI.Page
{
    #region Variables
    string strFY;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
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
            ViewState["ActiveNonActive"] = null;

            Bind_DDL_SuperZone();



        }
        if (IsPostBack)
        {
            if (ViewState["ActiveNonActive"] != null)
            {
                ShowDetails((DataTable)ViewState["ActiveNonActive"]);
                //DataTable dt = (DataTable)Cache["ABC"];

            }
        }
    }


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
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = Customer_cs.Get_CustList("ActiveNonActive", strFY.ToString(), DDLSuperZone.SelectedValue.ToString());
        ViewState["ActiveNonActive"] = dt;
        ShowDetails(dt);

    }

    public void ShowDetails(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/ActiveInActiveCustomer.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            ActiveNonActiveReport.ReportSource = rd;
            // Cache.Insert("ABC", dt1, new CacheDependency(Server.MapPath("Report/ABCAnalysisrpt.rpt")));

        }
    }

}
