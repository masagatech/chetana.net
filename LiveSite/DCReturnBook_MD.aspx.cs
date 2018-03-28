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

public partial class DCReturnBook_MD : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            PnlDC.Visible = true;
            PnlM.Visible = false;
        }
    }
    protected void RdbtnSelect1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect1.SelectedValue == "DC")
        {
           
           PnlDC.Visible = true;
           PnlM.Visible = false;
           Response.Redirect(Request.RawUrl);
        }
        if (RdbtnSelect1.SelectedValue == "Manual")
        {
            PnlDC.Visible = false;
            PnlM.Visible = true;
        }
    }
}
