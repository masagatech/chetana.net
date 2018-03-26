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

public partial class SalesAnalysis_Report : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    DateTime fdate, tdate;
    string from , To ; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
            if (Session["Role"] != null)
            {
                if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
                {
                    Response.Redirect("dashboard.aspx");
                }

            }
        }
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
            Session["salesanalysis"] = null;
            ddlSDZone.Focus();
            
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
            DDLCC.DataBind();
            DDLCC.Items.Insert(0, new ListItem("--Select Category--", "0"));
            DDLCC.Enabled = true;
		
            
        }
        if (IsPostBack)
        {
            
            if (txtfromDate.Text != "" || txtToDate.Text != "")
            {
                ShowDetails("session");
            }
            else if (txtToDate.Text == "")
            { }
            else
            {
              //  ShowDetails();
            }
            txtfromDate.Text = Session["FromDate"].ToString();
            txtToDate.Text = Session["ToDate"].ToString();
           
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails("");
            

        //DataSet ds = new DataSet();
        //if (txtfromDate.Text != "" && txtToDate.Text != "")
        //{
        //    from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        //    To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        //    fdate = Convert.ToDateTime(from);
        //    tdate = Convert.ToDateTime(To);
        //    if (fdate > tdate)
        //    {
        //        MessageBox("From Date is Greater than ToDate");
        //        txtfromDate.Focus();
        //    }

        //    else
        //    {
        //        ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintSalesAnalysis.aspx?d=" + DDLSuperZone.SelectedValue + "&sd=" + strFY + "&fd=" + fdate + "&td="+ tdate +"')", true);
        //        }
        //        else
        //        {
        //            MessageBox("Records Not Found");
        //            DDLSuperZone.Focus();
        //        }
        //    }
        //}
        //else
        //{
        //    ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY));
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintSalesAnalysis.aspx?d=" + DDLSuperZone.SelectedValue + "&sd=" + strFY + "')", true);
        //    }
        //    else
        //    {
        //        MessageBox("Records Not Found");
        //        DDLSuperZone.Focus();
        //    }
        //}

    }
    public void ShowDetails(string session)
    {
        DataSet ds = new DataSet();
        from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }

        else
        {
            //ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate, Convert.ToInt32(DDlZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim());
 	
	if (session == "session"  && Session["salesanalysis"] != null)
            {
                ds = (DataSet)Session["salesanalysis"];
              
            }            

else
{
		ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate, Convert.ToInt32(DDlZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim(),
                Convert.ToInt32(ddlSDZone.SelectedValue), Convert.ToString(DDLCC.SelectedValue));
          }

  if (ds.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                ReportDocument rd = new ReportDocument();
               
                rd.Load(Server.MapPath("Report/Salesanalysis.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                SalesanalysisReportview.ReportSource = rd;
                //   ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintSalesAnalysis.aspx?d=" + DDLSuperZone.SelectedValue + "&sd=" + strFY + "&fd=" + fdate + "&td=" + tdate + "')", true);
            }
            else
            {
                MessageBox("Records Not Found");
                DDLSuperZone.Focus();
            }
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDlZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            Bind_DDL_Zone();
            DDlZone.Focus();
         
            //  DDLZone.SelectedValue = null;
           // Bind_DDL_ZoneCust();
        }
        else
        {
           
        }
    }

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            DDlZone.Items.Clear();
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
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
}
