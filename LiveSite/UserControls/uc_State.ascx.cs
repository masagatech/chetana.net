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

public partial class UserControls_uc_Sate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            BindGvStateDetail();
        }
    }

    #region Binddata method

    public void BindGvStateDetail()
    {
        GrdStateDetails.DataSource = Destination.GetDestination("adminstate");
        GrdStateDetails.DataBind();
    }
    #endregion

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD State ";
                lblDmID.Text = "0";
                PnlStateDetails.Visible = false;
                PnlAddState.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtDmcode.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit State ";
                    
                    PnlStateDetails.Visible = true;
                    PnlAddState.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                }
        }
    }

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Dmcode = txtDmcode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();

        Destination _objDs = new Destination();
        _objDs.DMID = Convert.ToInt32(lblDmID.Text);
        _objDs.DMCode = txtDmcode.Text.Trim();
        _objDs.Name = txtName.Text.Trim();
        _objDs.IsActive = ChekActive.Checked;
      
        try
        {
            if (txtDmcode.Text != "")
            {
                _objDs.Save();
            }
            MessageBox("Record saved successfully");
            if (btnSave.Text == "Update")
            {
                BindGvStateDetail();
                PnlAddState.Visible = false;
                PnlStateDetails.Visible = true;
                btnSave.Text = "Save";
                txtDmcode.Text = "";
                txtName.Text = "";

            }
            else
            {
                BindGvStateDetail();
                txtDmcode.Text = "";
                txtName.Text = "";
                ChekActive.Checked = false;
                PnlAddState.Visible = true;
                PnlStateDetails.Visible = false;
            }
           

        }
        catch
        {

        }
        
        
    }

 
    protected void GrdStateDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlStateDetails.Visible = false;
        PnlAddState.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtDmcode.Enabled = false;
        try
        {
            lblDmID.Text = ((Label)GrdStateDetails.Rows[e.NewEditIndex].FindControl("lblDMID")).Text;
            txtDmcode.Text = ((Label)GrdStateDetails.Rows[e.NewEditIndex].FindControl("lblDMCode")).Text;
            txtName.Text = ((Label)GrdStateDetails.Rows[e.NewEditIndex].FindControl("lblStateName")).Text;
            ChekActive.Checked = ((CheckBox)GrdStateDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }
    protected void GrdStateDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Destination _objDs2 = new Destination();
        _objDs2.DMID = Convert.ToInt32(((Label)GrdStateDetails.Rows[e.RowIndex].FindControl("lblDMID")).Text);
        _objDs2.DMCode = ((Label)GrdStateDetails.Rows[e.RowIndex].FindControl("lblDMCode")).Text;
        _objDs2.Name = ((Label)GrdStateDetails.Rows[e.RowIndex].FindControl("lblStateName")).Text;

        _objDs2.IsActive = Convert.ToBoolean(false);
        _objDs2.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objDs2.Save();
            MessageBox("Your record is Deleted");
            BindGvStateDetail();

            PnlStateDetails.Visible = true;
            PnlAddState.Visible = false;
        }
        catch
        {

        }
    }
    protected void txtDmcode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Dmcode = txtDmcode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("state", Dmcode);
                if (Auth)
                {
                    MessageBox("State Code is Already Exist");
                    txtDmcode.Text = "";
                    txtDmcode.Focus();

                }
                else
                {
                    txtName.Focus();
                }
            }
            catch
            {

            }
        }
    }
}
