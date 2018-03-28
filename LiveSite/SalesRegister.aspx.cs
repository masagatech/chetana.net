#region Namespace
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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class SalesRegister : System.Web.UI.Page
{
    #region Variables

    string strFY;
    
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
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
            Session["salesReg"] = null;
           
        }

        if (IsPostBack)
        {
            if (Session["salesReg"] != null)
            {
                Bind((DataTable)Session["salesReg"]);
            }
           
        }

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

    protected void btnget_Click(object sender, EventArgs e)
    {

        string from = txtFromDate.Text.Split('/')[1].ToString() + "/" + txtFromDate.Text.Split('/')[0].ToString() + "/" + txtFromDate.Text.Split('/')[2];
        string to = txtToDate.Text.Split('/')[1].ToString() + "/" + txtToDate.Text.Split('/')[0].ToString() + "/" + txtToDate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(to);
        DataSet ds = new DataSet();
        ds = LeadgerDetails.Get_SalesRegister(ddlDetails.SelectedValue.ToString(), FromDate, ToDate, Convert.ToInt32(strFY),"",ddlstate.SelectedValue.ToString());

        Session["salesReg"] = ds.Tables[0];
        Bind(ds.Tables[0]);
        
    }

    public void Bind(DataTable dt)
    {
        ReportDocument rd = new ReportDocument();
        if (dt.Rows.Count > 0)
        {
            if (ddlDetails.SelectedValue == "summary")
            {
               
                rd.Load(Server.MapPath("Report/SalesRegister.rpt"));
                rd.SetDataSource(dt);
            }
            else
            {
               
                rd.Load(Server.MapPath("Report/SalesRegister_Detail.rpt"));
                rd.SetDataSource(dt);
            }
            salesReport.ReportSource = rd;
        }
        else
        {
            MessageBox("No Record Found");
        }

    }




    protected void ddlDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDetails.SelectedValue == "summary")
        {
            ddlstate.Enabled = false;
        }
        else
        {
            ddlstate.Enabled = true;
        }
    }
}
