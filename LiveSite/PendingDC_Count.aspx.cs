using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using System.Data;

public partial class PendingDC_Count : System.Web.UI.Page
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
            BindSDZone();
        }
        if (Page.IsPostBack)
        {
            ShowDetails();
        }
    }

    

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        }
        else
        {
            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
            DDLSuperZone.Focus();
        }
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }

    #region Message Box
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion
 
    public void ShowDetails()
    {

        if (ddlSDZone.SelectedValue.ToString() != "0")
        {
            DataSet ds = new DataSet();
            ds = Idv.Chetana.BAL.Specimen.Idv_Chetana_DC_Report_Get_PedingDocNo_ForDCConfirmation(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToDateTime("01/01/1900"),
                Convert.ToDateTime("01/01/1900"), Convert.ToInt32(strFY));


            DataView dv = new DataView(ds.Tables[0]);

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/PendingDC_Count.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            // rd.Database.Tables[1].SetDataSource(dv2);
            //rd.SetDataSource(ds);
            pendingdcreport.ReportSource = rd;
        }
       
    }
    public void BindSDZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Focus();
        DDLSuperZone.Items.Clear();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
    }


   
}
