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

public partial class UserControls_uc_LoginUserDetails : System.Web.UI.UserControl
{


    #region Page load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack) {
            Session["roleu"] = null;
        }
        if (!Page.IsPostBack)
        {
            BindDataEmployeeDetails();
        }
        

    }
    #endregion

    #region GridEmployee

    public void BindDataEmployeeDetails()
    {
        grdEmployeeDetails.DataSource = Employee.Get_EmpList();
        grdEmployeeDetails.DataBind();
    }

    #endregion

    #region Events

    protected void btnLink_Click(object sender, EventArgs e)
    {
        try
        {

            string empid = ((LinkButton)(sender)).CommandArgument;
            UserLoginDetails _objuserlog = new UserLoginDetails();
            _objuserlog.EmpID = Convert.ToInt32(empid.ToString());

            string Isblock = ((LinkButton)(sender)).Text.ToLower();
            if (Isblock == "block")
            {
                _objuserlog.IsBlocked = true;
                _objuserlog.Update_UserLog();
                _objuserlog.Update_UserLog();
                BindDataEmployeeDetails();
                loder("succcessfully block", "4000");
            }
            else

                if (Isblock == "unblock")
                {
                    _objuserlog.IsBlocked = false;
                    _objuserlog.Update_UserLog();
                    _objuserlog.Update_UserLog();
                    BindDataEmployeeDetails();
                    loder("succcessfully unblock", "4000");
                }
                else
                {

                    lblEID.Text = empid;
                    ddlRolepop.DataSource = Roles();
                    ddlRolepop.DataBind();
                    ddlRolepop.Attributes.Add("style", "display:block;");
                    selrol.Visible = true;
                    ddlRolepop.Items.Insert(0, new ListItem("None", "0"));
                    txtPassword.Focus();
                    txtPassword.Text = "";
                    txtPassword.Attributes.Add("value", "");
                    txtPassword.Text = ((Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblEName")).Text;

                    UpdatePanel1.Update();
                    ModalPopUpExMSG.Show();


                }



        }
        catch (Exception ex)
        {


        }

    }
    #endregion
    protected void grdEmployeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlrole");
            Label lblRoleId = (Label)e.Row.FindControl("lblRoleId");
            Label lblissys = (Label)e.Row.FindControl("lblIsSysadmin");
            CheckBox chksysAdmin = (CheckBox)e.Row.FindControl("IsSystemAdmin");
            Label lblCreateLogin = (Label)e.Row.FindControl("lblCreateLogin");
            LinkButton lnk = (LinkButton)e.Row.FindControl("btnLink");
            LinkButton lnkpwd = (LinkButton)e.Row.FindControl("lnlpassword");

            ddl.DataSource = Roles();
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("None", "0"));
            ddl.SelectedValue = lblRoleId.Text.Trim();
            if (lblCreateLogin.Text == "0")
            {
                lnk.BackColor = System.Drawing.Color.Wheat;
                lnk.Text = "create login";
                ddl.Enabled = false;
                ddl.BorderColor = System.Drawing.Color.Red;
                lnkpwd.Enabled = false;
                lnkpwd.Text = "";
                chksysAdmin.Enabled = false;
            }
            else
                if (lblissys.Text.ToLower() != "true")
                {
                    ddl.Enabled = false;
                }




        }
        //
    }

    protected void btnPasswordsave_Click(object sender, EventArgs e)
    {
        UserLoginDetails _objUsreLoginDetails = new UserLoginDetails();
        _objUsreLoginDetails.EmpID = Convert.ToInt32(lblEID.Text);
        _objUsreLoginDetails.RoleID = Convert.ToInt32(ddlRolepop.SelectedValue);
        _objUsreLoginDetails.Password = txtPassword.Text.Trim();
        _objUsreLoginDetails.IsActive = true;
        _objUsreLoginDetails.Save();
        BindDataEmployeeDetails();
        upPanel.Update();
        ModalPopUpExMSG.Hide();
        if (selrol.Visible == false)
        {
            loder("Password changed succcessfully", "4000");
        }
        else
        {
            loder("Login created succcessfully", "4000");

        }
    }

    protected void ddlrole_changed(object sender, EventArgs e)
    {
        try
        {
            Label lblEmpid = (Label)((System.Web.UI.WebControls.ListControl)(sender)).Parent.FindControl("lblEID");
            Label lblEmpName = (Label)((System.Web.UI.WebControls.ListControl)(sender)).Parent.FindControl("lblEName");
            DropDownList ddl = (DropDownList)((System.Web.UI.WebControls.ListControl)(sender));
            Label lblPassword = (Label)((System.Web.UI.WebControls.ListControl)(sender)).Parent.FindControl("lblPassword");
            UserLoginDetails _objUsreLoginDetails = new UserLoginDetails();
            _objUsreLoginDetails.EmpID = Convert.ToInt32(lblEmpid.Text);
            _objUsreLoginDetails.RoleID = Convert.ToInt32(ddl.SelectedValue);
            _objUsreLoginDetails.Password = lblPassword.Text.Trim();
            _objUsreLoginDetails.IsActive = true;
            _objUsreLoginDetails.Save();
            loder(ddl.SelectedItem.Text + " role succcessfully set to " + lblEmpName.Text, "4000");
        }
        catch (Exception ex)
        {
            loder(ex.Message, "4000");
        }



    }

    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    protected void lnlpassword_Click(object sender, EventArgs e)
    {

        try
        {
            string empid = ((LinkButton)(sender)).CommandArgument;
            lblEID.Text = empid;
            UserLoginDetails _objuserlog = new UserLoginDetails();
            _objuserlog.EmpID = Convert.ToInt32(empid.ToString());
            string Isblock = ((LinkButton)(sender)).Text.ToLower();
            txtPassword.Attributes.Add("value", ((Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblPassword")).Text);
            ddlRolepop.DataSource = Roles();
            ddlRolepop.DataBind();
            ddlRolepop.Items.Insert(0, new ListItem("None", "0"));
            ddlRolepop.SelectedValue = ((DropDownList)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("ddlrole")).SelectedValue;
            ddlRolepop.Attributes.Add("style", "display:none;");
            selrol.Visible = false;
            txtPassword.Focus();
            txtPassword.Text = ((Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblPassword")).Text;
            spnname.InnerHtml = ((Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblEName")).Text;
            UpdatePanel1.Update();
            ModalPopUpExMSG.Show();
        }
        catch
        {

        }

    }

    protected void IsSystemAdmin_CheckedChanged(object sender, EventArgs e)
    {
        Label lblEmpid = (Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblEID");
        Label lblEmpName = (Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblEName");
        DropDownList ddl = (DropDownList)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("ddlrole");
        Label lblPassword = (Label)((System.Web.UI.WebControls.WebControl)(sender)).Parent.FindControl("lblPassword");
        UserLoginDetails _objUsreLoginDetails = new UserLoginDetails();
        _objUsreLoginDetails.EmpID = Convert.ToInt32(lblEmpid.Text);
        _objUsreLoginDetails.RoleID = Convert.ToInt32(ddl.SelectedValue);
        _objUsreLoginDetails.Password = lblPassword.Text.Trim();
        _objUsreLoginDetails.IsActive = true;
        if (((CheckBox)((System.Web.UI.WebControls.WebControl)(sender))).Checked == false)
        {
            _objUsreLoginDetails.IsSysAdmin = false;
        }
        else
        {
            _objUsreLoginDetails.IsSysAdmin = true;
        }
        _objUsreLoginDetails.Save();
        BindDataEmployeeDetails();
        upPanel.Update();
        loder(ddl.SelectedItem.Text + " role succcessfully set to " + lblEmpName.Text, "4000");
    }

    private DataTable Roles()
    {
        DataTable dt = null;
        if (Session["roleu"] == null)
        {
            DataView dv = new DataView(Rolemaster.Get_RoleMaster().Tables[0]);
            dv.RowFilter = "Isactive = 1";
            dt = dv.ToTable();
            Session["roleu"] = dt;
        }
        else
        {
            dt = (DataTable)Session["roleu"];
        }
        return dt;
    }

    protected void grdEmployeeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdEmployeeDetails.PageIndex = e.NewPageIndex;
        BindDataEmployeeDetails();
        upPanel.Update();


    }
}

