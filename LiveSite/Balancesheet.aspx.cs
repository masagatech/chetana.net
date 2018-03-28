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

public partial class Balancesheet : System.Web.UI.Page
{
    string strFY;
    string strChetanaCompanyName = "cppl"; 
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
            //Response.Write(strFY); 


       
        txtFromDate.Focus();
        if (!IsPostBack) {
            setdefaultdate();
        }
        if (IsPostBack)
        {
            Bind();
        }
    }

    public void Bind()
    {
        string from = txtFromDate.Text.Split('/')[1].ToString() + "/" + txtFromDate.Text.Split('/')[0].ToString() + "/" + txtFromDate.Text.Split('/')[2];
        string to = txtToDate.Text.Split('/')[1].ToString() + "/" + txtToDate.Text.Split('/')[0].ToString() + "/" + txtToDate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(to);
        DataSet stDS = new DataSet(); 

        stDS = Bank.Get_BalanceSheet(FromDate, ToDate, "detail", Convert.ToInt32(strFY), " ");
        if (stDS.Tables[0].Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/Balancesheet.rpt"));
            rd.SetDataSource(stDS.Tables[0]);
            
            // Subreport of Liabilities
            //DataSet ds = new DataSet();
            //ds = Bank.Get_BalanceSheet(FromDate, ToDate, "detail", Convert.ToInt32(strFY), "L");
            rd.OpenSubreport("liability").SetDataSource(stDS.Tables[1]);

            // Subreport of Assets
            //DataSet ds1 = new DataSet();
            //ds1 = Bank.Get_BalanceSheet(FromDate, ToDate, "detail", Convert.ToInt32(strFY), "A");
            rd.OpenSubreport("asset").SetDataSource(stDS.Tables[2]);

            rd.SetParameterValue("IsPrint", Convert.ToBoolean(IsPrint.Checked));
            BSReport.ReportSource = rd;
        }
        else
        {
            MessageBox("No Record Found");
        }

    }
    protected void btnget_Click(object sender, EventArgs e)
    {
      
       // Bind();
   
    }
    //public void ShowDetails()
    //{

    //    stDS = new DataSet();
    //    stDS = Other.Dashboard.Get_Report_SalesPerformance(0, Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY));
    //    if (stDS.Tables[0].Rows.Count > 0)
    //    {
    //        DataView dv = new DataView(stDS.Tables[0]);
    //        ReportDocument rd = new ReportDocument();
    //        rd.Load(Server.MapPath("Report/SalesPerformance.rpt"));
    //        rd.Database.Tables[0].SetDataSource(dv);
    //        DataSet ds = new DataSet();

    //        ds = Other.Dashboard.Get_Report_SalesPerformance_Customer1(Convert.ToInt32(stDS.Tables[0].Rows[0]["ZoneId"]), Convert.ToInt32(strFY));

    //        rd.OpenSubreport("Customer").SetDataSource(ds.Tables[0]);

    //        salesperformance.ReportSource = rd;

    //    }
    //    else
    //    {
    //        MessageBox("No Record Found");


    //    }

    //}
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    public void setdefaultdate()
    {
        txtFromDate.Text = Session["FromDate"].ToString();
        txtToDate.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }

}
