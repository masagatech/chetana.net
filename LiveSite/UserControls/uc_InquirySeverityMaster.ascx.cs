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


public partial class UserControls_uc_InquirySeverityMaster : System.Web.UI.UserControl
{
    bool Auth;
    CMS objISeverityM = new CMS();
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {

            BindData();

        }

    }
    #region Binddata method
    public void BindData()
    {

        GrdIStatus.DataSource = CMS.GetSeverityMaster("adminCCM");
        GrdIStatus.DataBind();
    }
    #endregion
    protected void GrdIStatus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlISDetails.Visible = false;
        PnlISAdd.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtSeverityType.Enabled = true;

        try
        {
            lblSeverityID.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblSeverityID")).Text;
            txtSeverityType.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblSeverity_Name")).Text;
            ChekIsDefault.Checked = ((CheckBox)GrdIStatus.Rows[e.NewEditIndex].FindControl("chkIsDefault")).Checked;
            //PnlISDetails.Visible = true;
            //PnlISAdd.Visible = false;
        }
        catch
        {
        }
    }
    protected void GrdIStatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        objISeverityM.SeverityID = Convert.ToInt32(((Label)GrdIStatus.Rows[e.RowIndex].FindControl("lblSeverityID")).Text);
        objISeverityM.Severity_Name = ((Label)GrdIStatus.Rows[e.RowIndex].FindControl("lblSeverity_Name")).Text;

        objISeverityM.IsActive = Convert.ToBoolean(false);
        objISeverityM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            objISeverityM.SaveSeverityMaster();
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
        if (Auth != true)
        {
            if (txtSeverityType.Text != "")
            {

                objISeverityM.SeverityID = Convert.ToInt32(lblSeverityID.Text);
                objISeverityM.Severity_Name = txtSeverityType.Text.Trim();
                //objISeverityM.IsActive = ChekActive.Checked;
                objISeverityM.IsDefault = ChekIsDefault.Checked;
                objISeverityM.IsActive = ChekActive.Checked;
                objISeverityM.CreatedBy = Convert.ToString(Session["UserName"]);
                objISeverityM.SaveSeverityMaster();
                PnlISDetails.Visible = true;
                PnlISAdd.Visible = false;
                MessageBox("Severity Type is Saved Successfully");
                if (btnSave.Text == "Update")
                {
                    BindData();
                    PnlISAdd.Visible = false;
                    PnlISDetails.Visible = true;
                    btnSave.Text = "Save";
                    txtSeverityType.Text = "";
                    

                }
                else
                {
                    BindData();
                    txtSeverityType.Text = "";
                    ChekActive.Checked = false;
                    PnlISAdd.Visible = true;
                    PnlISDetails.Visible = false;
                }
               
            }
        }
        else
        {

            MessageBox("Severity Type is Already Exist");
        }


    }
   

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    protected void txtSeverityType_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string ITcode = txtSeverityType.Text.Trim();
                Auth = CMS.GetCMSCodeValidation("Severity", ITcode);
                if (Auth)
                {
                    MessageBox("Severity Type is Already Exist");
                    txtSeverityType.Text = "";
                    txtSeverityType.Focus();

                }
                else
                {
                    txtSeverityType.Focus();
                }
            }
            catch
            {

            }
        }
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Severity";
                lblSeverityID.Text = "0";
                PnlISDetails.Visible = false;
                PnlISAdd.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtSeverityType.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Severity";
                    PnlISDetails.Visible = true;
                    PnlISAdd.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                }
        }
    }
}