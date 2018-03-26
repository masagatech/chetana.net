using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Idv.Chetana.BAL;

public partial class UserTicketMap : System.Web.UI.Page
{
    #region Goloval Veriable
    string username = "";
    string FY = "";
    #endregion

    #region Page Load Even
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                username = Session["username"].ToString();
                FY = Session["FY"].ToString();
            }
        }
        else
        {
            Session.Clear();
        }
        if (!IsPostBack)
        {
            GetSuperZone();
            txtUser.Focus();
        }
    }
    #endregion

    #region Save Button Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUser.Text != "")
        {
            StringBuilder sb = new StringBuilder();
            string SuperzoneId = "";
            string UserName = txtUser.Text.Split(':')[0].ToString();
            foreach (GridViewRow item in usergrid.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("ChkVal");
                if (chk.Checked)
                {
                    SuperzoneId=Convert.ToInt32(((Label)item.FindControl("chkid")).Text).ToString();
                    sb.Append(SuperzoneId + ",");
                }
            }
            if (sb.ToString() != "")
            {
                Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
                ObjDal.Idv_Chetana_UserTicketMap_Save(UserName, sb.ToString(), Convert.ToInt32(FY), Session["Username"].ToString(), "", "", "", "", "", "", "");
                Message("Record save successfully");
                txtUser.Text = "";
                txtUser.Focus();
            }
            else
            {
                Message("Please select super zone ");
                return;
            }
        }
        Message("Please enter user name");
        txtUser.Focus();
        return;
    }
    #endregion

    #region Button Clear Click Evnet
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in usergrid.Rows)
        {
            CheckBox chk = (CheckBox)item.FindControl("ChkVal");
            if (chk.Checked)
            {
                chk.Checked = false;
            }
        }
        txtUser.Focus();
    }
    #endregion

    #region Bind Grid view Method
    public void GetSuperZone()
    {
        usergrid.DataSource = SuperZone.GetSuperzonemaster();
        usergrid.DataBind();
    }
    #endregion

    #region Messaage Box
    public void Message(string str)
    {
        string text="alert('" + str + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", text, true);
    }
    #endregion
}