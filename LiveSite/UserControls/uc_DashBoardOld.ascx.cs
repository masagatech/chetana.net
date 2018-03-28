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
         //CMSCheck();
    }

    #region Binddata method

    public void BindDLDashboard()
    {
        DLDashboard.DataSource = Idv.Chetana.BAL.Other.Dashboard.GetDashboard();
        DLDashboard.DataBind();
    }
    #endregion
 protected void CMSCheck()
    {
        
        DataTable CMSCheck = new DataTable();
        DataRow RCMSCheck;
        CMSCheck = CMS.Idv_Chetana_CMS_Check().Tables[0];
        if (CMSCheck.Rows.Count != 0)
        {
            for (int k = 0; k <= CMSCheck.Rows.Count - 1; k++)
            {
                RCMSCheck = CMSCheck.Rows[k];
                if (RCMSCheck[0].ToString() != RCMSCheck[1].ToString())
                {
                    Server.Transfer("CMSSendEmail.aspx");
                }
            }
        }
    }
}
