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

public partial class Print_PrintPattyCash : System.Web.UI.Page
{
    #region Variables
    static string val = "", val2 = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request.QueryString["d"] != "" && Request.QueryString["sd"]!="")
        {
            //DataView dv = new DataView(BindGvBookDetail().Table);
        
            //DataView dv = new DataView(BindGvBookDetail().Table);
            //if (Session["data"] != null)
           // {

                val = Request.QueryString["d"].ToString().Trim();
                val2 = Request.QueryString["sd"].ToString().Trim();


                BindGvBookDetail();
                 gvAllPettyCash.Visible = true;
           // }
        }
        else
        {
            //DataView dv = new DataView(BindGvBookDetail().Table);
            //Session["data"] = dv;
            //if (Session["data"] != null)
            //{
            //    dv = (DataView)Session["data"];
            //    val = "";
            //    dv.RowFilter = "PaymentDate like '" + val + "%'";
            //    gvAllPettyCash.DataSource = dv;
            //    gvAllPettyCash.DataBind();
            //    gvAllPettyCash.Visible = true;
            //}
        }

        //DataSet ds = new DataSet();
        //ds = PettyCashEntry.Get_All_PettyCashDetals();
        //gvAllPettyCash.DataSource = ds;
        //gvAllPettyCash.DataBind();
        //gvAllPettyCash.Visible = true;
    }
    public void  BindGvBookDetail()
    {
        DataSet ds = new DataSet(); 
        ds = PettyCashEntry.Get_All_PettyCashDetals(val, val2);
        DataView dv = new DataView(ds.Tables[0]);
        
        // PettyCashEntry.Get_All_PettyCashDetals(FromDate, Todate);
        //DataView dv = new DataView(dt);
        
        gvAllPettyCash.DataSource = dv;
        gvAllPettyCash.DataBind();
       
        gvAllPettyCash.Visible = true;
    }


}
