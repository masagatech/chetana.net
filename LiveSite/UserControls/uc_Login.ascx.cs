#region NameSpaces
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
using Idv.Chetana.BAL;
using Idv.Chetana.Common;
using Others;
#endregion
public partial class UserControls_uc_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtuser.Focus();
        lblErrMsg.Visible = false;
        if (!Page.IsPostBack)
        {
            this.GetFinancialYear();
            dogetSelectYear();
        }

        //if (Request.QueryString["reai"] != null && Request.QueryString["resu"] != null)
        //{
        //    CheckLogin(ED.DecryptData(Request.QueryString["resu"].ToString()),
        //        ED.DecryptData(Request.QueryString["dwsp"].ToString()),
        //        ED.DecryptData(Request.QueryString["cmp"].ToString()),
        //        ED.DecryptData(Request.QueryString["rea"].ToString()),
        //        ED.DecryptData(Request.QueryString["reai"].ToString()));
        //}
        //if (ConfigurationManager.AppSettings["chlogouturl"] != null)
        //{
        //    Response.Redirect(ConfigurationManager.AppSettings["chlogouturl"].ToString());
        //}
    }

    private void GetFinancialYear()
    {
        DataTable dt = Yearmaster.GetFinancialYear();

        if (dt.Rows.Count > 0)
        {
            ddlFinancialYear.DataSource = dt;
            ddlFinancialYear.DataBind();
        }


    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        //try
        {

        if (ddlChetanaCompanyName.SelectedValue.ToLower().Trim() == "cppl")
            {
                Login();
            }
            else if (ddlChetanaCompanyName.SelectedValue.ToLower().Trim() == "cspl")
            {
                Response.Redirect(RedirectLogin(ConfigurationManager.AppSettings["chStationaryUrl"].ToString()));
            }
		else if (ddlChetanaCompanyName.SelectedValue.ToLower().Trim() == "llp")
            {
                Response.Redirect(RedirectLogin(ConfigurationManager.AppSettings		["llpUrl"].ToString()));
            }

        }
        //catch (Exception ex)
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = ex.InnerException.ToString();

        //}
    }

    public string RedirectLogin(string RedirectUrl)
    {
        string userid;
        string Password;
        string Year;
        string companyname;
        string Yearid;
        string Qr = "";
        userid = ED.EncryptData(txtuser.Text.Trim());
        Password = ED.EncryptData(txtpwd.Text.Trim());
        Year = ED.EncryptData(ddlFinancialYear.SelectedItem.Text.Trim());
        Yearid = ED.EncryptData(ddlFinancialYear.SelectedValue.Trim());
        companyname = ED.EncryptData(ddlChetanaCompanyName.SelectedValue.ToLower());
        //userid = txtuser.Text.Trim();
        //Year = ddlFinancialYear.SelectedValue.Trim();
        //Password = txtpwd.Text.Trim();
        Qr = "?resu=" + Server.UrlEncode(userid) + "&dwsp=" + Server.UrlEncode(Password) + "&cmp=" + Server.UrlEncode(companyname) + "&rea=" + Server.UrlEncode(Year) + "&reai=" + Server.UrlEncode(Yearid);
        return RedirectUrl + Qr;

        //txtuser.Text = Request.QueryString["userid"];
    }

    private void SetLogoutTime()
    {
        int outLoginLogId = 0;
        string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
        {
            ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        LoginLog objLoginLog = new LoginLog();
        objLoginLog.LoginLogId = 0;
        objLoginLog.LoginTime = DateTime.Now;
        objLoginLog.LoginPesonId = Session["UserName"].ToString();
        objLoginLog.IpAddress = ipaddress;
        objLoginLog.Save(out outLoginLogId);
        Session["LoginId"] = outLoginLogId.ToString();

    }

    public void Login()
    {
        try
        {
            lblErrMsg.Visible = false;
            string Auth = UserLoginDetails.Get_UserLogin(txtuser.Text.Trim(), txtpwd.Text.Trim());
            if (Auth != "0")
            {
                Session["UserName"] = txtuser.Text.Trim();
                Session["ChetanaCompanyName"] = ddlChetanaCompanyName.SelectedValue.ToLower();
                Session["Role"] = Auth;
                Session["FY_Text"] = ddlFinancialYear.SelectedItem.Text.Trim();
                Session["FY"] = ddlFinancialYear.SelectedValue.Trim();
                Session["FromDate"] = "01/04/" + ddlFinancialYear.SelectedItem.Text.Trim().Substring(0, 4);
                Session["ToDate"] = "31/03/" + ddlFinancialYear.SelectedItem.Text.Trim().Substring(5, 4);
                fillSessionZones(Session["UserName"].ToString());
                SetLogoutTime();
                dostoreSelectYear();
                
                //Get initial data
                Session["AuditCutOffDate"] = null;
                
                DataSet ds = OtherClass.GetInitialData("","","","","","init", Convert.ToInt32(Session["FY"]));
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        Session["AuditCutOffDate"] = Convert.ToDateTime(dr[0].ToString()).ToString("dd-MM-yyyy");
                    }
                }


                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblErrMsg.Visible = true;
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = "Login Failed or User is blocked";
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void CheckLogin(string userid, string Password, string companyname, string Year, string yearId)
    {
        try
        {
            lblErrMsg.Visible = false;
            string Auth = UserLoginDetails.Get_UserLogin(userid, Password);
            if (Auth != "0")
            {
                Session["UserName"] = userid;
                Session["ChetanaCompanyName"] = companyname;
                Session["Role"] = Auth;
                Session["FY_Text"] = Year;
                Session["FY"] = yearId;
                Session["FromDate"] = "01/04/" + Year.Substring(0, 4);
                Session["ToDate"] = "30/03/" + Year.Substring(5, 4);
                SetLogoutTime();
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblErrMsg.Visible = true;
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = "Login Failed or User is blocked";
            }
        }
        catch (Exception ex)
        {

        }

    }

    #region Fill Zone Vicibility session

    public void fillSessionZones(string EmpCode)
    {
        DataTable dt = new DataTable();
        dt = UserLoginDetails.Get_UserLoginDetails(EmpCode);
        if (dt.Rows.Count > 0)
        {
            Session["zoneLevel"] = dt.Rows[0][0].ToString();
            Session["zoneId"] = dt.Rows[0][1].ToString();
        }
    }

    #endregion

    #region default year

    public void dostoreSelectYear()
    {
        try
        {
            HttpCookie cookie = Request.Cookies["FinancialYear"];
            if (cookie == null)
            {
                cookie = new HttpCookie("FinancialYear");
            }
            cookie["year"] = ddlFinancialYear.SelectedValue.ToString();
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
        }
        catch (Exception ex)
        {


        }

    }

    public void dogetSelectYear()
    {
        try
        {
            HttpCookie cookie = Request.Cookies["FinancialYear"];
            if (cookie != null)
            {
                ddlFinancialYear.SelectedValue = cookie["year"].ToString();
            }
        }
        catch (Exception ex)
        {


        }

    }

    #endregion
}
