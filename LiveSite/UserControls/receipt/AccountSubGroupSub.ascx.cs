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

public partial class UserControls_ODC_receipt_AccountSubGroupSub : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDl();
            Id.Text = "0";
        }
        Bind();
        SetView();
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
    protected void ddlmaingroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        SubBindDDl();
        ddlSubGroup.Focus();
    }
    public void BindDDl()
    {
        DataView dt = new DataView(AccountMainGroup.Idv_Chetana_Get_AccountMain().Tables[0]);
        ddlmaingroup.DataSource = dt;
        //AccountMainGroup.Idv_Chetana_Get_AccountMain(Convert.ToInt32(ddllist.SelectedValue.ToString()));
        ddlmaingroup.DataBind();
        ddlmaingroup.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        ddlmaingroup.Enabled = true;
        SubBindDDl();
        ddlSubGroup.Focus();
        
    }
    public void SubBindDDl()
    {
        ddlSubGroup.DataSource = (AccountMainGroup.Idv_Chetana_Get_SubGroup(Convert.ToInt32(ddlmaingroup.SelectedValue.ToString())));
        ddlSubGroup.DataBind();
        ddlSubGroup.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        ddlSubGroup.Enabled = true;
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
        AccountGroupSub sub = new AccountGroupSub();
        sub.AutoId = Convert.ToInt32(Id.Text);
        sub.MAIN_Code = Convert.ToInt32(ddlSubGroup.SelectedValue.ToString());
        sub.GR_HEAD = txtsub.Text.ToString();
        sub.Save();
        MessageBox("Record saved successfully");
        txtsub.Text = "";
        ddlSubGroup.SelectedValue = "0";
        ddlmaingroup.SelectedValue = "0";

    }
    protected void ddlSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtsub.Focus();
    }
    public void Bind()
    {
        DataTable dt = new DataTable();
        dt = AccountGroupSub.Idv_Chetana_Get_idv_chetana_main_group_Sub().Tables[0];
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
