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
using Idv.Chetana.Common;

public partial class UserControls_uc_SpecimenrReport_Dashboard : System.Web.UI.UserControl
{
    string name;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            BindDLDashboard();
        }
    }
    #region Binddata method

    public void BindDLDashboard()
    {
        DLDashboard.DataSource = SpecimanDetails.Get_Reports_SpecimenDashBoard("abc","xxx").Tables[0];
        DLDashboard.DataBind();
        DLDashboard1.DataSource = SpecimanDetails.Get_Reports_SpecimenDashBoard("abc","xxx").Tables[2];
        DLDashboard1.DataBind();
    }
    #endregion
    protected void lnkgiven_Click(object sender, EventArgs e)
    {
        
    }
    protected void lnkgiven1_Click(object sender, EventArgs e)
    {

    }
    
}
