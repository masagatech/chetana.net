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

public partial class UserControls_uc_GroupMaster : System.Web.UI.UserControl
{
    #region Variables
    static DataView dv = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = GroupMaster.GetGroupmaster("Group");
            GrdDetails.DataSource = GroupMaster.GetGroupmaster("Group");
            GrdDetails.DataBind();
            DataView dv = new DataView(ds.Tables[0]);
            Session["data"] = dv;
            //repAlfabets.DataSource = Customer_cs.GetAlphabets();
           // repAlfabets.DataBind();
        }
        else
        {
            // pnlSuperZone.Visible = true;
        }  
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GroupMaster _objGrp = new GroupMaster();
        _objGrp.GrpID = Convert.ToInt32(lblGrpID.Text);
        _objGrp.GrpCode = txtGrpCode.Text.Trim();
        _objGrp.GrpName = txtGrpName.Text.Trim();
        _objGrp.IsActive = chkActive.Checked;
        try
        {
            _objGrp.Save();
            MessageBox("Record saved successfully");
            GrdDetails.DataSource = GroupMaster.GetGroupmaster("Group"); ;
            GrdDetails.DataBind();
            if (btnSave.Text == "Update")
            {
                pnlgroupdetails.Visible = true;
                pnlgroup.Visible = false;
                btnSave.Visible = false;
                btnSave.Text = "Save";
                txtGrpCode.Enabled = true;
                filter.Visible = true;
            }
            else
            {
                pnlgroupdetails.Visible = false;
                pnlgroup.Visible = true;
                txtGrpCode.Text = "";
                txtGrpName.Text = "";
                txtGrpCode.Focus();

            }
        }
        catch
        {

        }
    }
    protected void txtGrp_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("GroupMaster", txtGrpCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Group Code already exist");
            txtGrpCode.Text = "";
            txtGrpCode.Focus();
        }
        else
        {
            txtGrpName.Focus();
        }
    }
    #region Binddata method

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Group ";
                lblGrpID.Text = "0";
                pnlgroupdetails.Visible = false;
                txtGrpCode.Focus();
                pnlgroup.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Group ";
                    filter.Focus();
                    pnlgroupdetails.Visible = true;
                    pnlgroup.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                }
        }
    }

    //public DataView BindGvGroupDetail()
    //{
    //    DataTable dt = new DataTable();
    //    dt = GroupMaster.GetGroupmaster();
    //    DataView dv = new DataView(dt);
    //    return dv;
    //}
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion


  
    protected void GrdDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlgroupdetails.Visible = false;
        pnlgroup.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtGrpCode.Enabled = false;
        try
        {
            lblGrpID.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblGID")).Text;
            txtGrpCode.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblCode")).Text;
            txtGrpName.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblName")).Text;
            txtRemark.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblRemark")).Text;
            chkActive.Checked = ((CheckBox)GrdDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }
    protected void GrdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
