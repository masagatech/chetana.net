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

public partial class UserControls_UC_PurchaseMaster_View : System.Web.UI.UserControl
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }

        if (hidYear.Value != "")
        {
            fillData(false);
        }

    }

    #region BindData

    public void BindDashBoard(string flag)
    {
        gvPurchasingDashBoard.DataSource = PurchaseMaster.Get_PurchaseDetails(0, System.DateTime.Now, System.DateTime.Now
           , Convert.ToInt32(strFY), flag, 0, 0);
        gvPurchasingDashBoard.DataBind();

    }


    #endregion
    DataTable dt;
    int month = 0;
    int year = 0;
    int fyear = 0;
    string a = "";

    protected void lnkSummer_Click(object sender, EventArgs e)
    {
        LinkButton lnksum = (LinkButton)sender;
        if (hidYear.Value == "")
        {
            a = "1";
        }
        hidMonth.Value = lnksum.CommandArgument.ToString();
        hidYear.Value = lnksum.CommandName.ToString();
        hidflag.Value = getReturnSelectedSummeryValue();
        fillData(true);
    }
    protected void lnkDetails_Click(object sender, EventArgs e)
    {
        LinkButton lnkdet = (LinkButton)sender;
        hidMonth.Value = lnkdet.CommandArgument.ToString();
        hidYear.Value = lnkdet.CommandName.ToString();
        hidflag.Value = getReturnSelectedDetailsValue();
        fillData(true);
    }

    public void fillData(bool callNew)
    {
        try
        {
            Report.Visible = true;
            month = Convert.ToInt32(hidMonth.Value);
            year = Convert.ToInt32(hidYear.Value);
            if (Session["FY"] != null)
            {
                fyear = Convert.ToInt32(Session["FY"].ToString());
            }
            else
            {
                Session.Clear();
            }


            dt = new DataTable();
            if (callNew == true)
            {
                dt = PurchaseMaster.Get_PurchaseDetails(0, System.DateTime.Now, System.DateTime.Now
                  , fyear, hidflag.Value, month, year).Tables[0];
                ViewState["purstate"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["purstate"];
            }


            ReportDocument crystalReport = new ReportDocument();
            if (hidflag.Value.ToLower() == "details" || hidflag.Value.ToLower() == "details_b" || hidflag.Value.ToLower() == "details_o")
            {
                if (hidflag.Value.ToLower() == "details_o")
                {
                    crystalReport.Load(Server.MapPath("Report/Purchase_Details_Vat.rpt"));
                }
                else
                {
                    crystalReport.Load(Server.MapPath("Report/Purchase_Details.rpt"));
                
                }
            }

            else
            {
                crystalReport.Load(Server.MapPath("~/Report/Purchase_Summery.rpt"));
            }

            crystalReport.SetDataSource(dt);
            crtcustomer.ReportSource = crystalReport;
        }
        catch (Exception ex)
        {


        }
    }
    protected void rdoGetDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoGetDetails.SelectedIndex == 0)
        {
            BindDashBoard("DASHBOARD_B");
        }
        else if (rdoGetDetails.SelectedIndex == 1)
        {
            BindDashBoard("DASHBOARD_O");
        }
        else
        {
            BindDashBoard("DASHBOARD");
        }
        Report.Visible = false;
      
    }

    public string getReturnSelectedSummeryValue()
    {
        string retval = "";
        if (rdoGetDetails.SelectedIndex == 0)
        {
            retval = "SUMMERY_B";
        }
        else if (rdoGetDetails.SelectedIndex == 1)
        {
            retval = "SUMMERY_O";
        }
        else
        {
            retval = "SUMMERY";
        }
        return retval;
    }

    public string getReturnSelectedDetailsValue()
    {
        string retval = "";
        if (rdoGetDetails.SelectedIndex == 0)
        {
            retval = "DETAILS_B";
        }
        else if (rdoGetDetails.SelectedIndex == 1)
        {
            retval = "DETAILS_O";
        }
        else
        {
            retval = "DETAILS";
        }
        return retval;
    }
}
