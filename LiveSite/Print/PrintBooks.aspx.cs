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

#endregion

public partial class Print_PrintBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {
            DataSet ds = new DataSet();
            ds = SetofBooks.GetBooksetdetails_ByBooksetID(Convert.ToInt32(Request.QueryString["d"].ToString()));
            grdBooksetDetails.DataSource = ds.Tables[0];
            grdBooksetDetails.DataBind();
            lblBookSet.Text =  Request.QueryString["sd"].ToString();

        }
    }
}
