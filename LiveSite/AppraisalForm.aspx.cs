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

public partial class AppraisalForm : System.Web.UI.Page
{
    string strFY;
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
        //Response.Write(strFY);

        if (!Page.IsPostBack)
        {
            ViewState["appraisal"] = null;
            Bind_DDL_SuperZone();
        }
        if (IsPostBack)
        {
            if (ViewState["appraisal"] != null)
            {
                ShowDetails((DataTable)ViewState["appraisal"]);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string from = txtFrom.Text.Split('/')[2] + "/" + txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0];
        string To = txtTo.Text.Split('/')[2] + "/" + txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0];

        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
         
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            appraisareportView.Visible = false;
            txtFrom.Focus();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = Idv.Chetana.BAL.BankPayment.Get_AppraisalForm(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY.ToString()), fdate, tdate, "", 0).Tables[0];
            if (dt.Rows.Count != 0)
            {
                ViewState["appraisal"] = dt;
                ShowDetails(dt);
            }
            else
            {
                MessageBox("No Record Found");

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

    #region BindZone


    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
       // DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    
    #endregion 
    //protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DDLSuperZone.SelectedIndex == 0)
    //    {
    //        DDLSuperZone.Focus();
    //        DDLZone.Items.Clear();
           
    //    }
    //    else
    //    {
    //        Bind_DDL_Zone();
    //        DDLZone.Focus();
    //    }
    //}

    public void ShowDetails(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/AppraisalForm.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            appraisareportView.ReportSource = rd;
            // Cache.Insert("ABC", dt1, new CacheDependency(Server.MapPath("Report/ABCAnalysisrpt.rpt")));

        }
    }
}
