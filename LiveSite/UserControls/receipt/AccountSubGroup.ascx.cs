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

public partial class UserControls_ODC_receipt_AccountSubGroup : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
        if (!IsPostBack)
        {
            BindDDl();
        Id.Text = "0";
        }
        SetView();
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDDl();
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
    public void BindDDl()
    {
       DataView dt = new DataView(AccountMainGroup.Idv_Chetana_Get_AccountMain().Tables[0]);
       ddllist.DataSource = dt;
        //AccountMainGroup.Idv_Chetana_Get_AccountMain(Convert.ToInt32(ddllist.SelectedValue.ToString()));
        ddllist.DataBind();
        ddllist.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        ddllist.Enabled = true;
        txtsub.Focus();
    }
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
            AccountSubGroup sa = new AccountSubGroup();
            sa.AutoId = Convert.ToInt32(Id.Text);
            sa.Main_Code = Convert.ToInt32(ddllist.SelectedValue);
            sa.Sub_HEAD = txtsub.Text.Trim();
            sa.Inactive = Convert.ToBoolean(true);
            sa.Save();
            MessageBox("Record saved successfully");
            txtsub.Text = "";
            ddllist.SelectedValue = "0";
            SetView();
        }
    }
    public void Bind()
    {
        DataTable dt = new DataTable();
        dt = AccountGroupSub.Idv_Chetana_Get_Main_group_sub().Tables[0];
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
   
}
