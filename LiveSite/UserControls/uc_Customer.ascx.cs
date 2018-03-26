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


public partial class UserControls_uc_Customer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
           
           BindGvCCDetail();

        }

    }
    #region Binddata method
    public void BindGvCCDetail()
    {
        
        GrdCCDetails.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        GrdCCDetails.DataBind();
    }
    #endregion

    protected void GrdCCDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlCCDetails.Visible = false;
        PnlAddCC.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtCustCategoryCode.Enabled = false;
        try
        {
           lblCmID.Text = ((Label)GrdCCDetails.Rows[e.NewEditIndex].FindControl("lblCMID")).Text;
        txtCustCategoryCode.Text = ((Label)GrdCCDetails.Rows[e.NewEditIndex].FindControl("lblCMCode")).Text;
        txtCustCategoryName.Text = ((Label)GrdCCDetails.Rows[e.NewEditIndex].FindControl("lblCCName")).Text;
            ChekActive.Checked = ((CheckBox)GrdCCDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }
    protected void GrdCCDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CustCategory _objDs2 = new CustCategory();
        _objDs2.CMID = Convert.ToInt32(((Label)GrdCCDetails.Rows[e.RowIndex].FindControl("lblCMID")).Text);
        _objDs2.CDMCode = ((Label)GrdCCDetails.Rows[e.RowIndex].FindControl("lblCMCode")).Text;
        _objDs2.CName = ((Label)GrdCCDetails.Rows[e.RowIndex].FindControl("lblCCName")).Text;

        _objDs2.CIsActive = Convert.ToBoolean(false);
        _objDs2.CIsDeleted = Convert.ToBoolean(true);
        try
        {
            _objDs2.CSave();
            MessageBox("Your record is Deleted");
            BindGvCCDetail();

            PnlCCDetails.Visible = true;
            PnlAddCC.Visible = false;
        }
        catch
        {

        }
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Customer Category ";
                lblCmID.Text = "0";
                PnlCCDetails.Visible = false;
                PnlAddCC.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtCustCategoryCode.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Customer Category ";
                    PnlCCDetails.Visible = true;
                    PnlAddCC.Visible = false;
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
        string CmCode = txtCustCategoryCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
        CustCategory _objDs = new CustCategory();
        _objDs.CMID = Convert.ToInt32(lblCmID.Text);
        _objDs.CDMCode = txtCustCategoryCode.Text.Trim();
        _objDs.CName = txtCustCategoryName.Text.Trim();
        _objDs.CIsActive = ChekActive.Checked;
        try
        {
            if (txtCustCategoryName.Text != "")
            {
                _objDs.CSave();
            }
            MessageBox("Record saved successfully");
            if (btnSave.Text == "Update")
            {
                BindGvCCDetail();
                PnlAddCC.Visible = false;
                PnlCCDetails.Visible = true;
                btnSave.Text = "Save";
                txtCustCategoryCode.Text = "";
                txtCustCategoryName.Text = "";

            }
            else
            {
                BindGvCCDetail();
                txtCustCategoryCode.Text = "";
                txtCustCategoryName.Text = "";
                ChekActive.Checked = false;
                PnlAddCC.Visible = true;
                PnlCCDetails.Visible = false;
            }



        }
        catch
        {

        }
    }
    protected void txtCustCategoryCode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Cmcode = txtCustCategoryCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("CustomerMain", Cmcode);
                if (Auth)
                {
                    MessageBox("Customer Category Code is Already Exist");
                    txtCustCategoryCode.Text = "";
                    txtCustCategoryCode.Focus();

                }
                else
                {
                   txtCustCategoryName.Focus();
                }
            }
            catch
            {

            }
        }
    }
}