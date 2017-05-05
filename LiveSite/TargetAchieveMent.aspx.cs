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

public partial class TargetAchieveMent : System.Web.UI.Page
{
   
    string strFY = "0";
    DateTime fdate;
    DateTime tdate;
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
	   setdefaultdate();
            Bind_DDL_SuperZone();
            ViewState["Data"] = null;
        }
        if (IsPostBack)
        {
           
                if (ViewState["Data"] != null)
                {
                    BindData((DataTable)ViewState["Data"]);
                }
           
        }
    }

 public void setdefaultdate()
    {
        txtfromDate.Text = Session["FromDate"].ToString();
        txtToDate.Text = Session["ToDate"].ToString(); 
        //DateTime.Now.ToString("dd/MM/yyyy");
    
    }


    protected void btnget_Click(object sender, EventArgs e)
    {
        string from1 = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        string To1 = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from1);
        tdate = Convert.ToDateTime(To1);

        DataTable dt = new DataTable();
        if (rdbselect.SelectedValue == "Zone")
        {
            dt = Other.Dashboard.Get_Report_TargetAchievement(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(strFY), fdate, tdate,rdbselect.SelectedValue.ToString()).Tables[0];
        }
        else 
        {
            dt = Other.Dashboard.Get_Report_TargetAchievement(0, Convert.ToInt32(strFY), fdate, tdate,rdbselect.SelectedValue.ToString()).Tables[0];
        }
         
       if (dt.Rows.Count > 0)
        {
            ViewState["Data"] = dt;
            BindData(dt);
        }
        else
        {
            UnBindReport();
        }
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
    public void BindData(DataTable dt1)
    {
        ReportDocument rd = new ReportDocument();
        if (dt1.Rows.Count > 0)
        {
            if (rdbselect.SelectedValue == "Zone")
            {
                rd.Load(Server.MapPath("Report/TargetAchievement.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrTargetAchievement.ReportSource = rd;
            }
            else
            {
                rd.Load(Server.MapPath("Report/TargetAchievement_topperformace.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrTargetAchievement.ReportSource = rd;
            }
        }
        else
        {
            UnBindReport();
            //rd.Load(Server.MapPath("Report/TargetAchievement.rpt"));

            //CrTargetAchievement.ReportSource = null;
            //MessageBox("Records Not Available");
            
        }
    }
    public void UnBindReport()
    {
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/TargetAchievement.rpt"));
        CrTargetAchievement.ReportSource = null;
        MessageBox("Records Not Available");
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

    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Zone")
        {
            DDLSuperZone.Visible = true;
        }
        else
        {
            DDLSuperZone.Visible = false;
            DDLSuperZone.SelectedIndex = 0;
        }

    }
}
