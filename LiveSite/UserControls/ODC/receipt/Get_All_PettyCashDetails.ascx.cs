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

public partial class UserControls_ODC_receipt_Get_All_PettyCashDetails : System.Web.UI.UserControl
{
    string FromDate;
    string Todate;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)

        {
          txtFrom.Focus();
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
    public void BindAllPetty()
    {

        string FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
        //FromDate = Convert.ToString(date);

        string Todate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];
        //Todate = Convert.ToString(Todate2);

        DataSet ds = new DataSet();
        ds = PettyCashEntry.Get_All_PettyCashDetals(FromDate, Todate);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvAllPettyCash.DataSource = ds;
            gvAllPettyCash.DataBind();
            gvAllPettyCash.Visible = true;
        }
        else
        {
            message("Record not found");

        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
       // string From = txtFrom.Text.Trim();
        //string To = txtTo.Text.Trim();
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PrintPattyCash.aspx?d=" + txtFrom.Text.Trim() +"&sd="+txtTo.Text.Trim() + "')", true);
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        BindAllPetty();
        gvAllPettyCash.Visible = true;
    }
}
