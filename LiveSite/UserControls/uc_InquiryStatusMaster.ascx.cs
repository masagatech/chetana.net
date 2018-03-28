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


public partial class UserControls_uc_InquiryStatusMaster : System.Web.UI.UserControl
{
    bool Auth;
    CMS objIStatusM = new CMS();
    protected void Page_Load(object sender, EventArgs e)
    {

        SetView();
        if (!Page.IsPostBack)
        {
            if (Page.IsPostBack != true)
            {

                BindData();

            }


        }
    }

    protected void GrdIStatus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlISDetails.Visible = false;
        PnlISAdd.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtInquiryStatus.Enabled = true;

        try
        {
            lblStatus_ID.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblStatus_ID")).Text;
            txtInquiryStatus.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblStatus_Name")).Text;
            ChekIsDefault.Checked = ((CheckBox)GrdIStatus.Rows[e.NewEditIndex].FindControl("chkIsDefault")).Checked;
        }
        catch
        {
        }
    }
    protected void GrdIStatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        objIStatusM.Status_ID = Convert.ToInt32(((Label)GrdIStatus.Rows[e.RowIndex].FindControl("lblStatus_ID")).Text);
        objIStatusM.Status_Name = ((Label)GrdIStatus.Rows[e.RowIndex].FindControl("lblStatus_Name")).Text;

        objIStatusM.IsActive = Convert.ToBoolean(false);
        objIStatusM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            objIStatusM.SaveStatusMaster();
            MessageBox("Your record is Deleted");
            BindData();

            PnlISDetails.Visible = true;
            PnlISAdd.Visible = false;
        }
        catch
        {

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //lblInquiryStatus.Text = "0";
        if (Auth != true)
        {
            if (txtInquiryStatus.Text != "")
            {
                objIStatusM.Status_ID = Convert.ToInt32(lblStatus_ID.Text);
                objIStatusM.Status_Name = txtInquiryStatus.Text.Trim();
                objIStatusM.IsDefault = ChekIsDefault.Checked;

                objIStatusM.IsActive = ChekActive.Checked;
                objIStatusM.CreatedBy = Convert.ToString(Session["UserName"]);
                objIStatusM.SaveStatusMaster();
                PnlISDetails.Visible = true;
                PnlISAdd.Visible = false;
                MessageBox("Status Type is Saved Successfully");
                if (btnSave.Text == "Update")
                {
                    BindData();
                    PnlISAdd.Visible = false;
                    PnlISDetails.Visible = true;
                    btnSave.Text = "Save";
                    txtInquiryStatus.Text = "";

                }
                else
                {
                    BindData();
                    txtInquiryStatus.Text = "";
                    ChekActive.Checked = false;
                    PnlISAdd.Visible = true;
                    PnlISDetails.Visible = false;
                }
               
            }
        }
        else
        {

            MessageBox("Status Type is Already Exist");
        }


    }
    public void BindData()
    {

        GrdIStatus.DataSource = CMS.GetStatusMaster("adminCCM");
        GrdIStatus.DataBind();

    }

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    protected void txtInquiryStatus_TextChanged(object sender, EventArgs e)
    {

        try
        {
            string ITcode = txtInquiryStatus.Text.Trim();
            Auth = CMS.GetCMSCodeValidation("Status", ITcode);
            if (Auth)
            {
                MessageBox("Status Type is Already Exist");
                txtInquiryStatus.Text = "";
                txtInquiryStatus.Focus();

            }
            else
            {
                txtInquiryStatus.Focus();
            }
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
                pageName.InnerHtml = "ADD Status";
                lblStatus_ID.Text = "0";
                PnlISDetails.Visible = false;
                PnlISAdd.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtInquiryStatus.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Status";
                    PnlISDetails.Visible = true;
                    PnlISAdd.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                }
        }
    }
}