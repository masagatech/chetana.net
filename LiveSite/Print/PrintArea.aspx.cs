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
using System.IO;
using System.Text;

public partial class Print_PrintArea : System.Web.UI.Page
{
    #region Variables
    static DataView dv = null;
    static string val = "";
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != "")
        {
            DataView dv = new DataView(BindGvAreaDetail().Table);
            Session["data"] = dv;
            if (Session["data"] != null)
            {
                dv = (DataView)Session["data"];
                val = Request.QueryString["d"].ToString().Trim();
                dv.RowFilter = "AreaName like '" + val + "%'";
                grdAreaDetails.DataSource = dv;
                grdAreaDetails.DataBind();
            }
        }
        else
        {
            DataView dv = new DataView(BindGvAreaDetail().Table);
            Session["data"] = dv;
            if (Session["data"] != null)
            {
                dv = (DataView)Session["data"];
                val = "A";
                dv.RowFilter = "AreaName like '" + val + "%'";
                grdAreaDetails.DataSource = dv;
                grdAreaDetails.DataBind();
            }

        }


    }
    public DataView BindGvAreaDetail()
    {
        DataTable dt = new DataTable();
        dt = AreaMaster.GetAreaMaster();
        DataView dv1 = new DataView(dt);
        return dv1;
    }
}
