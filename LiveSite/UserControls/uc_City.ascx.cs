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

public partial class UserControls_City : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();        
        if (!Page.IsPostBack)
        {
            BindGvCityDetail();
            BindState();
        }
    }

    #region Binddata method

    public void BindGvCityDetail()
    {

        GrdCityDetails.DataSource = Destination.GetDestination("admincity");
        GrdCityDetails.DataBind();
    }
    #endregion

    public void BindState()
    {
        DDLState.DataSource = Destination.GetDestination("adminstate");
        DDLState.DataBind();
        DDLState.Items.Insert(0, new ListItem("-- Select State --", "0"));
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD City ";
                lblDmID.Text = "0";
                PnlCityDetails.Visible = false;
                PnlAddCity.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtDmcode.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit City ";
                    PnlCityDetails.Visible = true;
                    PnlAddCity.Visible = false;
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
        _objDs.ParentID = Convert.ToInt32(DDLState.SelectedValue.ToString());
        _objDs.Name = txtName.Text.Trim();
        _objDs.IsActive = ChekActive.Checked;      
        try
        {
            if (txtDmcode.Text != "")
            {
                _objDs.Save();
            }
            MessageBox(Constants.save);
           
            if (btnSave.Text == "Update")
            {
                BindGvCityDetail();
                txtDmcode.Text = "";
                txtName.Text = "";
                ChekActive.Checked = false;
                DDLState.SelectedValue = null;
                PnlAddCity.Visible = false;
                PnlCityDetails.Visible = true;
                btnSave.Text = "Save";
            }
            else
            {
                BindGvCityDetail();
                txtDmcode.Text = "";
                txtName.Text = "";
                ChekActive.Checked = false;
                DDLState.SelectedValue = null;
                PnlAddCity.Visible = true;
                PnlCityDetails.Visible = false;
            }

        }
        catch
        {

        }
    }

    protected void GrdCityDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlCityDetails.Visible = false;
        PnlAddCity.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtDmcode.Enabled = false;
        try
        {
            lblDmID.Text = ((Label)GrdCityDetails.Rows[e.NewEditIndex].FindControl("lblDMID")).Text;
            txtDmcode.Text = ((Label)GrdCityDetails.Rows[e.NewEditIndex].FindControl("lblDMCode")).Text;
            txtName.Text = ((Label)GrdCityDetails.Rows[e.NewEditIndex].FindControl("lblCityName")).Text;
            ChekActive.Checked = ((CheckBox)GrdCityDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
            BindState();
            DDLState.SelectedValue = ((Label)GrdCityDetails.Rows[e.NewEditIndex].FindControl("lblStateid")).Text;
            
        }
        catch
        {
        }

    }


    protected void GrdCityDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       Destination _objDs1 = new Destination();
       _objDs1.DMID = Convert.ToInt32(((Label)GrdCityDetails.Rows[e.RowIndex].FindControl("lblDMID")).Text);
       _objDs1.DMCode = ((Label)GrdCityDetails.Rows[e.RowIndex].FindControl("lblDMCode")).Text;
       _objDs1.Name = ((Label)GrdCityDetails.Rows[e.RowIndex].FindControl("lblCityName")).Text;

        _objDs1.IsActive = Convert.ToBoolean(false);
        _objDs1.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objDs1.Save();
            MessageBox("Your record is Deleted");
            BindGvCityDetail();

            PnlCityDetails.Visible = true;
            PnlAddCity.Visible = false;
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
                bool Auth = Masters.GetCodeValidation("city", Dmcode);
                if (Auth)
                {
                    MessageBox("City Code is Already Exist");
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
