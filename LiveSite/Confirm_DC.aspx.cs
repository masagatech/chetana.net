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

public partial class Confirm_DC : System.Web.UI.Page
{
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
        if (Request.QueryString["cmode"] != null)
        {
            if (Request.QueryString["cmode"].ToLower() == "d")
            {
                uc_ConfirmDC1.Visible = true;
                uc_Get_NotConfirmDcBooks1.Visible = false;
            }
            else
                if (Request.QueryString["cmode"].ToLower() == "b")
                {
                    uc_ConfirmDC1.Visible = false;
                    uc_Get_NotConfirmDcBooks1.Visible = true;
                }
        }

      

    }
}
