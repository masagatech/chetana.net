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

public partial class UserControls_uc_Dashboard : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDLDashboard();
       // lblMsg.Visible = false;

    }

    #region Binddata method

    public void BindDLDashboard()
    {
        //try
        {
            DLDashboard.DataSource = Idv.Chetana.BAL.Other.Dashboard.GetDashboard();
            DLDashboard.DataBind();
        }
        //catch (Exception ex)
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = ex.InnerException.ToString();
            
        //}
    }
    #endregion
}
