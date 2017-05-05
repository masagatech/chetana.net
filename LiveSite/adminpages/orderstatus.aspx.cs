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

public partial class adminpages_orderstatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["DcNo"] != null)
        {
            ds = Other.Idv_Chetana_Dc_Status(Request.QueryString["Flag"].ToString(), Request.QueryString["DcNo"].ToString(), Request.QueryString["Flag1"].ToString(), Request.QueryString["Fy"].ToString());
            pnlconfirm.GroupingText ="Details of [ " + Request.QueryString["DcNo"].ToString() + " ]";
        }
        if (ds.Tables.Count > 0)
        {
            rep_DC_Details.DataSource = ds.Tables[0];
            rep_DC_Details.DataBind();
            rep_Confirmed.DataSource = ds.Tables[1];
            rep_Confirmed.DataBind();
            rep_Godown.DataSource = ds.Tables[2];
            rep_Godown.DataBind();
            //rep_Confirmed.DataSource = ds.Tables[3];
            //rep_Confirmed.DataBind();
            rep_Invoice.DataSource = ds.Tables[3];
            rep_Invoice.DataBind();
            rep_Cust_Status.DataSource = ds.Tables[4];
            rep_Cust_Status.DataBind();
            


        }

        //string Flag, string DcNo, string Flag1, string Fy

    }
}
