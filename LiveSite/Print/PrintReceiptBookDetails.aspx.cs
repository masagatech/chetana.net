#region NameSpace
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

public partial class Print_PrintReceiptBookDetails : System.Web.UI.Page
{
    #region Variables
    static DataView dv = null;
    static string val = "";
    
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != "")
        {
            val = Request.QueryString["d"].ToString().Trim();

            DataView dv = new DataView(BindGvBookDetail().Table);
           // Session["data"] = dv;
           // if (Session["data"] != null)
           // {
               // dv = (DataView)Session["data"];
                
                dv.RowFilter = "EmpCode like '" + val + "%'";
                gvshow.DataSource = dv;
                gvshow.DataBind();
            //}
        }
        else
        {
            message("No record found..");
            //DataView dv = new DataView(BindGvBookDetail().Table);
            //Session["data"] = dv;
            //if (Session["data"] != null)
            //{
            //    dv = (DataView)Session["data"];
            //    val = "";
            //    dv.RowFilter = "EmpCode like '" + val + "%'";
            //    gvshow.DataSource = dv;
            //    gvshow.DataBind();
            //    gvshow.Visible = true;
            //}
        }
    }
    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    public DataView BindGvBookDetail()
    {

        DataTable dt1 = ReciptBookDetails.getReceiptBookDetails(val, "1", "2",0).Tables[1];
        DataView dv = new DataView(dt1);
        return dv;
        gvshow.DataSource = dt1;
        gvshow.DataBind();
        gvshow.Visible = true;
        // Button1.Visible = false;


        //DataTable dt = new DataTable();
        //dt = Books.GetBookMaster();
        //DataView dv = new DataView(dt);
     
    }
}
