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


public partial class UserControls_uc_Customer_Sub_Category : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            BindGvCustomerSCDetail();
            BindCustomerCategory();
        }
    }

    #region Binddata method

    public void BindGvCustomerSCDetail()
    {

        GrdCSCDetails.DataSource = CustCategory.GetCustomerCategoryMaster("adminSUBCCM");
        GrdCSCDetails.DataBind();
    }
    #endregion

    public void BindCustomerCategory()
    {
        DDLCategory.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCategory.DataBind();
        DDLCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Customer Sub Category";
                lblCMID.Text = "0";
                PnlCSCDetails.Visible = false;
                PnlAddCSC.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtCCmcode.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Customer Sub Category";
                    PnlCSCDetails.Visible = true;
                    PnlAddCSC.Visible = false;
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
        string Dmcode = txtCCmcode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();

        CustCategory _objDs = new CustCategory();
        _objDs.CMID = Convert.ToInt32(lblCMID.Text);
        _objDs.CDMCode = txtCCmcode.Text.Trim();
        _objDs.CParentID = Convert.ToInt32(DDLCategory.SelectedValue.ToString());
        _objDs.CName = txtName.Text.Trim();
        _objDs.CIsActive = ChekActive.Checked;
        try
        {
            if (txtCCmcode.Text != "")
            {
                _objDs.CSave();
            }
            MessageBox(Constants.save);

            if (btnSave.Text == "Update")
            {
                BindGvCustomerSCDetail();
                txtCCmcode.Text = "";
                txtName.Text = "";
                ChekActive.Checked = false;
                DDLCategory.SelectedValue = null;
                PnlAddCSC.Visible = false;
                PnlCSCDetails.Visible = true;
                btnSave.Text = "Save";
            }
            else
            {
                BindGvCustomerSCDetail();
                txtCCmcode.Text = "";
                txtName.Text = "";
                ChekActive.Checked = false;
                DDLCategory.SelectedValue = null;
                PnlAddCSC.Visible = true;
                PnlCSCDetails.Visible = false;
            }

        }
        catch
        {

        }
    }

    protected void GrdCSCDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlCSCDetails.Visible = false;
        PnlAddCSC.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtCCmcode.Enabled = false;
        try
        {
            lblCMID.Text = ((Label)GrdCSCDetails.Rows[e.NewEditIndex].FindControl("lblCMID")).Text;
            txtCCmcode.Text = ((Label)GrdCSCDetails.Rows[e.NewEditIndex].FindControl("lblCMCode")).Text;
            txtName.Text = ((Label)GrdCSCDetails.Rows[e.NewEditIndex].FindControl("lblCSCName")).Text;
            ChekActive.Checked = ((CheckBox)GrdCSCDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
            BindCustomerCategory();
            DDLCategory.SelectedValue = ((Label)GrdCSCDetails.Rows[e.NewEditIndex].FindControl("lblCCid")).Text;

        }
        catch
        {
        }

    }


    protected void GrdCSCDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CustCategory _objDs1 = new CustCategory();
        _objDs1.CMID = Convert.ToInt32(((Label)GrdCSCDetails.Rows[e.RowIndex].FindControl("lblCMID")).Text);
        _objDs1.CDMCode = ((Label)GrdCSCDetails.Rows[e.RowIndex].FindControl("lblCMCode")).Text;
        _objDs1.CName = ((Label)GrdCSCDetails.Rows[e.RowIndex].FindControl("lblCSCName")).Text;

        _objDs1.CIsActive = Convert.ToBoolean(false);
        _objDs1.CIsDeleted = Convert.ToBoolean(true);
        try
        {
            _objDs1.CSave();
            MessageBox("Your record is Deleted");
            BindGvCustomerSCDetail();

            PnlCSCDetails.Visible = true;
            PnlAddCSC.Visible = false;
        }
        catch
        {

        }
    }
    protected void txtCCmcode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Dmcode = txtCCmcode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("CustomerSub", Dmcode);
                if (Auth)
                {
                    MessageBox("Category Sub Code is Already Exist");
                    txtCCmcode.Text = "";
                    txtCCmcode.Focus();

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
