#region NameSpace
using System;
using System.Globalization;
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
using Others;
using Idv.Chetana.Common;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using System.Text.RegularExpressions;
#endregion
public partial class Auditlock : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY;
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
        }
        if (!Page.IsPostBack)
        {
            GetDates();
            txtDate.Focus();
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
    public void GetDates()
    {
        if (Session["AuditCutOffDate"] != null)
        {
            try
            {
                lblAditCheckDate.Text = Convert.ToDateTime(Session["AuditCutOffDate"]).ToString("dd/MMM/yyyy");
            }
            catch (Exception)
            {

                lblAditCheckDate.Text = "";
            }

        }
        if (lblAditCheckDate.Text != "")
        {
            //if (DateTime.ParseExact(HttpContext.Current.Session["AuditCutOffDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
            //{  
            //    MessageBox("New Audit lock date should not be less than last set date!");
            //    return;
            //}
            //if (DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(Session["FromDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
            //{
            //    MessageBox("Audit lock date should not be less than " + Session["FromDate"].ToString());
            //    return;

            //}
        }
        //DataSet ds = OtherClass.GetFY(Convert.ToInt32(strFY));
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    int Fyear, Tyear;
        //    string errMsg;
        //    DataRow dr = dt.Rows[0];
        //    Fyear = Convert.ToInt32(dr[0].ToString());
        //    Tyear = Convert.ToInt32(dr[1].ToString());
        //    lblFY.Text = Convert.ToString(Session["FY_Text"]);
        //    RangeValidator1.MinimumValue = "04/01/" + Fyear.ToString();
        //    RangeValidator1.Type = ValidationDataType.Date;

        //    if (Fyear == Convert.ToInt32(DateTime.Now.Year.ToString()))
        //    {
        //        RangeValidator1.MaximumValue = DateTime.Now.ToString("MM/dd/yyyy");
        //        errMsg = "Date should be in between " + "01/04/" + Fyear.ToString() + " and " + DateTime.Now.AddDays(-1).Date.ToString("dd/MM/yyyy");

        //    }
        //    else
        //    {

        //        RangeValidator1.MaximumValue = "03/31/" + Tyear.ToString();
        //        errMsg = "Date should be in between " + "01/04/" + Fyear.ToString() + " and " + "31/03/" + Tyear.ToString();
        //    }
        //    RangeValidator1.ErrorMessage = errMsg;


        //}
    }

    private bool ValidateAud()
    {
        string errMsg = "Please Log in again!";
        if (Session["ToDate"] != null && Session["UserName"] != null)
        {

            DateTime FromDt = DateTime.ParseExact(Session["FromDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ToDt = DateTime.ParseExact(Session["ToDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture); 
            int Fyear = FromDt.Year;
            int Tyear = ToDt.Year;
           
            DateTime adtDate = Convert.ToDateTime(txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2]);
            DateTime auditlock = Convert.ToDateTime(Session["AuditCutOffDate"].ToString());
             if (adtDate <= auditlock)
            {
                errMsg = "New Audit lock date should not be less than last set date!";
            }else
            if (Fyear == Convert.ToInt32(DateTime.Now.Year.ToString()) &&  !(adtDate > FromDt && adtDate < DateTime.Now.AddDays(-1)))
            {
                errMsg = "Date should be in between " + FromDt.ToString("dd-MM-yyyy") + " and " + DateTime.Now.AddDays(-1).Date.ToString("dd/MM/yyyy");
            }
            else if (adtDate < FromDt || adtDate > ToDt)
            {
                errMsg = "Date should be in between " + FromDt.ToString("dd-MM-yyyy") + " and " + ToDt.ToString("dd-MM-yyyy");
            }
            else
            {
                return true;
            }

        }

        MessageBox(errMsg);
        return false;
    }


    protected void btngetset_Click(object sender, EventArgs e)
    {
        if (ValidateAud())
        {
            string str, from = txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2];
            DateTime fdate;
            fdate = Convert.ToDateTime(from);
            str = lblFY.Text.ToString();
            new OtherClass().SaveAudit(str, Convert.ToInt32(strFY), fdate, Session["UserName"].ToString());
            MessageBox("Audit lock date successfully set. It will be in effect post fresh login for each user.");
            txtDate.Text = "";
            txtDate.Focus();
        }
    }



}
