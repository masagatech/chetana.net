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


public partial class UserControls_ODC_uc_TrileBalence : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
       
    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        ds = BankReceiptPayment.idv_Chetana_Get_Trial_Balance();
        gvTrileBlance.DataSource = ds;
            gvTrileBlance.DataBind();
            gvTrileBlance.Visible = true;
            lblGrand.Visible = true;
            lblnetcredit.Visible = true;
            lblnetdebit.Visible = true;
        lblnetdebit.Text= string.Format("{0:0.00}",Convert.ToDecimal(ds.Tables[1].Rows[0]["Net_Debit"].ToString()));
        lblnetcredit.Text=string.Format("{0:0.00}",Convert.ToDecimal(ds.Tables[1].Rows[0]["Net_Credit"].ToString()));
      
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
}
