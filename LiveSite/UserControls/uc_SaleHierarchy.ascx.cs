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

public partial class UserControls_ODC_SaleHierarchy : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getbind();
    }
    public void getbind()
    {
        DataSet ds = new DataSet();
        ds = Other.GetSalesHierarchy();
        gvdetails.DataSource = ds;
        gvdetails.DataBind();
        pnlbindSale.Visible = true;
        gvdetails.Visible = true;
    }

}
