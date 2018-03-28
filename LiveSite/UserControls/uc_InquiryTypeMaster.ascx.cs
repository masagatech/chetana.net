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


public partial class UserControls_uc_InquiryTypeMaster : System.Web.UI.UserControl
{
    bool Auth;
    CMS objITypeM = new CMS();
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

        GrdIStatus.DataSource = CMS.GetTypeMaster("adminCCM");
        GrdIStatus.DataBind();
    }
    #endregion


    protected void GrdIStatus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlITDetails.Visible = false;
        PnlITAdd.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
       // txtInquiryType.Enabled = false;

        try
        {
            lblITM_ID.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblITM_ID")).Text;
            txtInquiryType.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblITM_Name")).Text;
            txtEmailTo.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblEmailFrom")).Text;
            txtEmailSubject.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblEmailSub")).Text;
            txtEmailBody.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblEmailBody")).Text;
            txtEmailSignature.Text = ((Label)GrdIStatus.Rows[e.NewEditIndex].FindControl("lblEmailSign")).Text;
            ChekIsDefault.Checked = ((CheckBox)GrdIStatus.Rows[e.NewEditIndex].FindControl("chkIsDefault")).Checked;
            
        }
        catch
        {
        }
    }
    protected void GrdIStatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        objITypeM.ITM_ID = Convert.ToInt32(((Label)GrdIStatus.Rows[e.RowIndex].FindControl("lblITM_ID")).Text);
        objITypeM.ITM_Name = ((Label)GrdIStatus.Rows[e.RowIndex].FindControl("lblITM_Name")).Text;

        objITypeM.IsActive = Convert.ToBoolean(false);
        objITypeM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            objITypeM.SaveTypeMaster();
            MessageBox("Your record is Deleted");
            BindData();

            PnlITDetails.Visible = true;
            PnlITAdd.Visible = false;
        }
        catch
        {

        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Auth != true)
        //lblInquiryStatus.Text = "0";
        {
            if (txtInquiryType.Text != "")
            {
               
                objITypeM.ITM_ID = Convert.ToInt32(lblITM_ID.Text);
                objITypeM.ITM_Name = txtInquiryType.Text.Trim();
                objITypeM.EmailFrom = txtEmailTo.Text.Trim();
                objITypeM.EmailSub = txtEmailSubject.Text.Trim();
                objITypeM.EmailBody = txtEmailBody.Text.Trim();
                objITypeM.EmailSign = txtEmailSignature.Text.Trim();
                objITypeM.IsDefault = ChekIsDefault.Checked;

                objITypeM.IsActive = ChekActive.Checked;
                objITypeM.CreatedBy = Convert.ToString(Session["UserName"]);
                objITypeM.SaveTypeMaster();
                //PnlITDetails.Visible = true;
                //PnlITAdd.Visible = false;
                //pnlEmailTemplate.Visible = false;
                MessageBox("Your record is Saved");
                if (btnSave.Text == "Update")
                {
                    BindData();
                    PnlITAdd.Visible = false;
                    PnlITDetails.Visible = true;
                    btnSave.Text = "Save";
                    txtInquiryType.Text = "";

                }
                else
                {
                    BindData();
                    ClearAll();
                    ChekActive.Checked = false;
                    PnlITAdd.Visible = true;
                    PnlITDetails.Visible = false;
                }

                
               // ClearAll();
            }
        }
        else
        {

            MessageBox("Inquiry Type Code is Already Exist");
        }



    }
    public void BindData()
    {
         GrdIStatus.DataSource = CMS.GetTypeMaster("adminCCM");
        GrdIStatus.DataBind();
       

    }
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    public void ClearAll()
    {
        txtInquiryType.Text = "";
        ChekIsDefault.Checked = false;
        txtEmailTo.Text = "";
        txtEmailSubject.Text = "";
        txtEmailBody.Text = "";
        txtEmailSignature.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearAll();
    }
    protected void txtInquiryType_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string ITcode = txtInquiryType.Text.Trim();
                Auth = CMS.GetCMSCodeValidation("InquiryType", ITcode);
                if (Auth)
                {
                    MessageBox("Inquiry Type Code is Already Exist");
                    txtInquiryType.Text = "";
                    txtInquiryType.Focus();

                }
                else
                {
                    txtInquiryType.Focus();
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
                pageName.InnerHtml = "ADD Inquiry Type";
                lblITM_ID.Text = "0";
                PnlITDetails.Visible = false;
                PnlITAdd.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txtInquiryType.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Inquiry Type";
                    PnlITDetails.Visible = true;
                    PnlITAdd.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                }
        }
    }
}