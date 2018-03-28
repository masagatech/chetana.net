using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Web.Services;
using Idv.Chetana.BAL;
using Idv.Chetana.Common;

public partial class tempmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CMSCheck();
    }
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