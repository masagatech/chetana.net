using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Idv.Chetana.BAL;
using Idv.Chetana.CnF;
using System.Data;

public partial class CNF_UserControl_uc_CnFCreateLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            BindLoginGrid();
            GetDdlCnF();
            LblCnFId.Text = "0";
        }
    }

    public void GetDdlCnF()
    {
        CnFCustomer objcnf = new CnFCustomer();
        objcnf.Remark1 = "ddlCnF";
        objcnf.Remark2 = "";
        objcnf.Remark3 = "";
        objcnf.CnFID = 0;

        ddlCnF.DataSource = objcnf.GetCnF_Master().Tables[0];
        ddlCnF.DataBind();
        ddlCnF.Items.Insert(0, new ListItem("--Select CnF--", "0"));
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        CnFLogin objlogin = new CnFLogin();
        objlogin.AutoId = Convert.ToInt32(LblCnFId.Text.ToString());
        objlogin.EmpID = txtuserid.Text.Trim();
        objlogin.CnFId = Convert.ToInt32(ddlCnF.SelectedValue.ToString());
        objlogin.Password = Txtpassword.Text.ToString();
        objlogin.IsActive = true;
        objlogin.IsBlocked = false;
        objlogin.IsSysAdmin = false;
        objlogin.SaveCnF_UserLoginDetails();
        BindLoginGrid();
        ClearDetais();
    }
    public void ClearDetais()
    {
        txtuserid.Text = "";
        Txtpassword.Text = "";
        ddlCnF.SelectedValue = "0";
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add CnF Login";
                lblID.Text = "0";
                pnlLoginDetails.Visible = false;
                ddlCnF.Focus();
                PnlAdd.Visible = true;
                btnSave.Visible = true;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Login ";
                    pnlLoginDetails.Visible = true;
                    PnlAdd.Visible = false;
                    btnSave.Visible = false;
                    
                }
        }
    }

    public void BindLoginGrid()
    {
        grdCnFLogin.DataSource = CnFLogin.GetCnF_Login("all", "").Tables[0];
        grdCnFLogin.DataBind();
    }

    #region Gridview Methods

    protected void grdCnFLogin_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlLoginDetails.Visible = false;
        PnlAdd.Visible = true;
        btnSave.Visible = true;

        btnSave.Text = "Update";
        //TxtCnFCode.Enabled = false;
        try
        {
            lblID.Text = ((Label)grdCnFLogin.Rows[e.NewEditIndex].FindControl("lblAutoID")).Text;
            txtuserid.Text = ((Label)grdCnFLogin.Rows[e.NewEditIndex].FindControl("lblUsername")).Text;
            Txtpassword.Text = ((Label)grdCnFLogin.Rows[e.NewEditIndex].FindControl("lblpassword")).Text;
            ddlCnF.SelectedValue = ((Label)grdCnFLogin.Rows[e.NewEditIndex].FindControl("lblCnfid")).Text;
        }
        catch
        {
        }
    }

    protected void grdCnFLogin_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion
}