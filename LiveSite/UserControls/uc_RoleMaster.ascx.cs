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
#endregion

public partial class UserControls_RoleMaster : System.Web.UI.UserControl
{
    #region Variables

    public static string Role = "";

    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            grdRoleDetails.DataSource = BindGvRoleDetail();
            grdRoleDetails.DataBind();
            pnlRoleDetails.Visible = true;
            PnlAddRole.Visible = false;
            //lblID.Text = "0";
            SetView();

        }
        else
        {
            PnlAddRole.Visible = true;
        }

    }
    #endregion

    #region Save Method

    protected void btnSave_Click(object sender, EventArgs e)
    {

        Rolemaster _objRm = new Rolemaster();
        _objRm.RoleId = Convert.ToInt32(lblID.Text);
        _objRm.RoleName = txtRname.Text.Trim();
        _objRm.IsActive = Chekacv.Checked;
        try
        {
            _objRm.Save();
                MessageBox("Record saved successfully");
                grdRoleDetails.DataSource = BindGvRoleDetail();
                grdRoleDetails.DataBind();
                pnlRoleDetails.Visible = true;
                PnlAddRole.Visible = false;
                btnSave.Visible = false;

                UPAddRole.Update();
                upAction.Update();
                UpdatePanel1.Update();
        }
        catch
        {

        }
    }

    #endregion

    #region Binddata method

    public DataView BindGvRoleDetail()
    {
        DataTable dt = new DataTable();
        dt = Rolemaster.Get_RoleList();
        DataView dv = new DataView(dt);
        return dv;
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Gidview Methods
    protected void grdRoleDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRoleDetails.PageIndex = e.NewPageIndex;
        grdRoleDetails.DataSource = BindGvRoleDetail();
        grdRoleDetails.DataBind();
    }



    protected void grdRoleDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlRoleDetails.Visible = false;
        PnlAddRole.Visible = true;
        lblID.Text = ((Label)grdRoleDetails.Rows[e.NewEditIndex].FindControl("lblRID")).Text;
        txtRname.Text = ((Label)grdRoleDetails.Rows[e.NewEditIndex].FindControl("lblName")).Text;
        Chekacv.Checked = ((CheckBox)grdRoleDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        UPAddRole.Update();
        upAction.Update();
        btnSave.Visible = true;
        btnSave.Text = "Update";
        Role = txtRname.Text;

    }



    protected void grdRoleDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Rolemaster _objRM = new Rolemaster();
        _objRM.RoleId = Convert.ToInt32(((Label)grdRoleDetails.Rows[e.RowIndex].FindControl("lblRID")).Text);
        _objRM.RoleName = ((Label)grdRoleDetails.Rows[e.RowIndex].FindControl("lblName")).Text;

        _objRM.IsActive = Convert.ToBoolean(false);
        _objRM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objRM.Save();
            MessageBox("Your record is Deleted");
            grdRoleDetails.DataSource = BindGvRoleDetail();
            grdRoleDetails.DataBind();
            pnlRoleDetails.Visible = true;
            PnlAddRole.Visible = false;
        }
        catch
        {

        }
    }
    #endregion

    #region Events
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        lblID.Text = "0";
        txtRname.Text = "";
        UPAddRole.Update();
        PnlAddRole.Visible = true;
        pnlRoleDetails.Visible = false;
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        PnlAddRole.Visible = false;
        pnlRoleDetails.Visible = true;
    }
    #endregion

    #region View
    
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                lblID.Text = "0";
                pnlRoleDetails.Visible = false;
                PnlAddRole.Visible = true;
                btnSave.Visible = true;
                //filter.Visible = false;
                txtRname.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pnlRoleDetails.Visible = true;
                    PnlAddRole.Visible = false;
                    btnSave.Visible = false;
                    //filter.Visible = true;
                }
        }
    }

    #endregion

    protected void txtRname_TextChanged(object sender, EventArgs e)
    {
        if (txtRname.Text.ToLower() != Role.ToLower())
        {
            bool Auth = Masters.GetCodeValidation("Role", txtRname.Text.Trim());
            if (Auth)
            {
                MessageBox("Role is already present");
                txtRname.Text = "";
                txtRname.Focus();
            }
            else
            {
                Chekacv.Focus();
            }
        }
    }
}
