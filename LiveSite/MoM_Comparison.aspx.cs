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
using CrystalDecisions.CrystalReports.Engine;
using Others;
using Idv.Chetana.BAL;


public partial class Report_YoY_Monthly_Comparision : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
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
          if (IsPostBack)
        {

            if (Session["MOMCOMP"] != null)
            {
                Bind();
            }
        }
        }
        if (!Page.IsPostBack)
        {
            Session["MOMCOMP"] = null;
            Bind_DDL_SuperDuperZone();
            ddlSDZone.Focus();

        }


    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    #region Bind Data
    public void Bind_DDL_SuperDuperZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
       
        DDLSuperZone.Focus();
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.Items.Clear();
        if (ddlSDZone.SelectedIndex != 0)
        {
            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            DDLSuperZone.Focus();


        }
        DDLZone.Items.Clear();
        ddlCustmore.Items.Clear();
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.Items.Clear();
        if (DDLSuperZone.SelectedIndex != 0)
        {
            DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
            DDLZone.DataBind();
            DDLZone.Items.Insert(0, new ListItem("-All Zone-", "0"));
            DDLZone.Focus();


        }
        ddlCustmore.Items.Clear();
        ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));
    }

    public void Bind_DDL_Customer()
    {
        if (DDLZone.SelectedIndex != 0)
        {
            ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
            ddlCustmore.DataBind();
            ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));
        }
    }
    #endregion

    public void Bind()
    {
        if (ddlSDZone.SelectedIndex == 0 || DDLSuperZone.SelectedIndex == -1 || DDLZone.SelectedIndex == -1 || ddlCustmore.SelectedIndex == -1)
        {
            return;
        }

        DataSet ds = new DataSet();
        int Zone, cust;
        string Months = string.Empty;
        string MonthsVal = string.Empty;
        if (DDLZone.SelectedIndex == 0)
        {
            Zone = 0;
            cust = 0;

        }
        else
        {
            Zone = Convert.ToInt32(DDLZone.SelectedValue.ToString());
            if (ddlCustmore.SelectedIndex == 0 || ddlCustmore.SelectedIndex == -1)
            {
                cust = 0;
            }
            else
            {
                cust = Convert.ToInt32(ddlCustmore.SelectedValue.ToString());
            }
        }

        if (ChkAll.Checked)
        {
            Months = "0";
            MonthsVal = "0";
        }
        else
        {
            if (chkApr.Checked)
            {
                Months += "4" + ",";
                MonthsVal += "apr" + ",";
            }
            if (chkMay.Checked)
            {
                Months += "5" + ",";
                MonthsVal += "may" + ",";
            }
            if (chkJun.Checked)
            {
                Months += "6" + ",";
                MonthsVal += "jun" + ",";
            }
            if (chkJul.Checked)
            {
                Months += "7" + ",";
                MonthsVal += "jul" + ",";
            }
            if (chkAug.Checked)
            {
                Months += "8" + ",";
                MonthsVal += "aug" + ",";
            }
            if (chkSep.Checked)
            {
                Months += "9" + ",";
                MonthsVal += "sep" + ",";
            }
            if (chkOct.Checked)
            {
                Months += "10" + ",";
                MonthsVal += "oct" + ",";
            }
            if (chkNov.Checked)
            {
                Months += "11" + ",";
                MonthsVal += "nov" + ",";
            }
            if (chkDec.Checked)
            {
                Months += "12" + ",";
                MonthsVal += "dec" + ",";
            }
            if (chkJan.Checked)
            {
                Months += "1" + ",";
                MonthsVal += "jan" + ",";
            }
            if (chkFeb.Checked)
            {
                Months += "2" + ",";
                MonthsVal += "feb" + ",";
            }
            if (chkMar.Checked)
            {
                Months += "3" + ",";
                MonthsVal += "mar" + ",";
            }
        }
        if (Months != string.Empty)
        {
            if (Months.EndsWith(","))
            {
                Months = Months.Remove(Months.Length - 1);
            }
        }


        try
        {
            if (Session["MOMCOMP"] != null)
            {
                ds = (DataSet)Session["MOMCOMP"];
            }
            else
            {

                ds = OtherClass.Get_Order_Compare(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Zone, cust, Convert.ToInt32(strFY), Months);
                Session["MOMCOMP"] = ds;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {

                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/YoY_Monthly_Sales_Comparision_Report.rpt"));
                rd.SetDataSource(ds.Tables[0]);
                rd.SetParameterValue("SDZone", ddlSDZone.SelectedItem.Text.ToString());
                rd.SetParameterValue("SuperZone", DDLSuperZone.SelectedItem.Text.ToString());
                rd.SetParameterValue("VisMonths", MonthsVal);
                CrMothlyreport.ReportSource = rd;
            }

            else
            {
                MessageBox("No Records found...");
            }
        }
        catch (Exception ex)
        { }


    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        Session["MOMCOMP"] = null;
        Bind();
    }
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_SuperZone();

    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_Zone();

    }
    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bind_DDL_Customer();

    }
    protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {

        if (chkApr.Checked)
        {
            chkApr.Checked = false;
        }
        if (chkMay.Checked)
        {
            chkMay.Checked = false;
        }
        if (chkMay.Checked)
        {
            chkMay.Checked = false;
        }
        if (chkJun.Checked)
        {
            chkJun.Checked = false;
        }
        if (chkJul.Checked)
        {
            chkJul.Checked = false;
        }
        if (chkAug.Checked)
        {
            chkAug.Checked = false;
        }
        if (chkSep.Checked)
        {
            chkSep.Checked = false;
        }
        if (chkOct.Checked)
        {
            chkOct.Checked = false;
        }
        if (chkNov.Checked)
        {
            chkNov.Checked = false;
        }
        if (chkDec.Checked)
        {
            chkDec.Checked = false;
        }
        if (chkJan.Checked)
        {
            chkJan.Checked = false;
        }
        if (chkFeb.Checked)
        {
            chkFeb.Checked = false;
        }
        if (chkMar.Checked)
        {
            chkMar.Checked = false;
        }





    }

    protected void CrMothlyreport_Init(object sender, EventArgs e)
    {
       
    }
}
