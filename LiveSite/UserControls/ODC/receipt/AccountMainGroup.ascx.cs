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
using System.IO;

public partial class UserControls_ODC_receipt_AccountMain : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lblMainHead.Text = "0";
            SetView();
            
        }
       
        
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pnlcust.Visible = true;
                gvmaincode.Visible = false; 

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pnlcust.Visible = false;
                    gvmaincode.Visible = true;
                    Bind();
                }
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
    protected void view_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            AccountMainGroup ac = new AccountMainGroup();
            ac.AutoId = Convert.ToInt32(lblMainHead.Text);
            ac.MAIN_HEAD = txtmain.Text.Trim();
            ac.Inactive = Convert.ToBoolean(true);
            ac.Createdby = Session["UserName"].ToString();
            ac.Save();
            message("Record Saved Successfully");
            txtmain.Text = "";
            SetView();
        }
    }
    public void Bind()
       {
        DataTable dt = new DataTable();
        dt = AccountGroupSub.Idv_Chetana_Get_main_group().Tables[0];
        if (dt.Rows.Count != 0)
        {
            gvmaincode.DataSource = dt;
            gvmaincode.DataBind();
            gvmaincode.Visible = true;
        }
        else
        {
            MessageBox("No Record Found");
        }
    }


    protected void gvmaincode_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlcust.Visible = true;
        gvmaincode.Visible = false;
        AccountMain ac = new AccountMain();
        try
        {
            lblMainHead.Text = ((Label)gvmaincode.Rows[e.NewEditIndex].FindControl("lblMainCode")).Text;
            txtmain.Text = ((Label)gvmaincode.Rows[e.NewEditIndex].FindControl("lblMainHead")).Text;
        }
        catch
        { 
        
        }
    }
}
