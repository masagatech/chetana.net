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

public partial class Godown_Month_Target : System.Web.UI.UserControl
{

    #region Variables
    
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    DataTable dt;

    #endregion
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }            
        }
        if (!IsPostBack)
        {
            DataTable dt=GetMonth();
            grdTarget.DataSource = dt;
            grdTarget.DataBind();
        }

    }

    public DataTable GetMonth()
    {
        dt = new DataTable();

        dt.Columns.Add("Month");
        dt.Columns.Add("Target");

        dt.Rows.Add("Apr", "");
        dt.Rows.Add("May", "");
        dt.Rows.Add("Jun", "");
        dt.Rows.Add("Jul", "");
        dt.Rows.Add("Aug", "");
        dt.Rows.Add("Sep", "");
        dt.Rows.Add("Oct", "");
        dt.Rows.Add("Nov", "");
        dt.Rows.Add("Dec", "");
        dt.Rows.Add("Jan", "");
        dt.Rows.Add("Feb", "");
        dt.Rows.Add("Mar", "");

        return dt;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Month_Target _objMonth = new Month_Target();

        foreach (GridViewRow row in grdTarget.Rows)
        {
            _objMonth.AutoID = 0;
            _objMonth.SuperZoneID = 0;
            _objMonth.MonthName = ((Label)row.FindControl("lblMonth")).Text;
            if (((TextBox)row.FindControl("txtTarget")).Text != "")
            {
                _objMonth.TargetPercent = Convert.ToDecimal(((TextBox)row.FindControl("txtTarget")).Text);
            }
            else
            {
                _objMonth.TargetPercent = 0;
            }
            _objMonth.FY = Convert.ToInt32(strFY);
            _objMonth.IsActive = true;
            _objMonth.IsDelete = false;
            _objMonth.CreatedBy = UserName;
            _objMonth.Remark1 = "";
            _objMonth.Remark2 = "";
            _objMonth.Remark3 = "";
            _objMonth.Remark4 = "";
            _objMonth.Remark5 = "";

            _objMonth.Save();
            Message("Data Saved Successfully");           
            ((TextBox)row.FindControl("txtTarget")).Text = "";
        }
    
    }

    public void Message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page,Page.GetType(),"msg",jv,true);
    }
}
