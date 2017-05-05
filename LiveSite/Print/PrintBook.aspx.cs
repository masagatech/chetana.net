#region NameSapce

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
#endregion

public partial class Print_PrintBook : System.Web.UI.Page
{
    #region Variables
    static DataView dv = null;
    static string val = "";
    #endregion   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != "")
        {
            DataView dv = new DataView(BindGvBookDetail().Table);
            Session["data"] = dv;
            if (Session["data"] != null)
            {
                dv = (DataView)Session["data"];
                val = Request.QueryString["d"].ToString().Trim();
                dv.RowFilter = "BookName like '" + val + "%'";
                grdBookDetails.DataSource = dv;
                grdBookDetails.DataBind();
            }
        }
        else
        {
            DataView dv = new DataView(BindGvBookDetail().Table);
            Session["data"] = dv;
            if (Session["data"] != null)
            {
                dv = (DataView)Session["data"];
              //  val = "A";
              //  dv.RowFilter = "BookName like '" + val + "%'";
                grdBookDetails.DataSource = dv;
                grdBookDetails.DataBind();
                grdBookDetails.Visible = true;
            }
        }
    }
    public DataView BindGvBookDetail()
    {
        DataTable dt = new DataTable();
        dt = Books.GetBookMaster();
        DataView dv = new DataView(dt);
        return dv;
    }
    
}
