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
using Idv.Chetana.DAL;

public partial class UserControls_uc_TeamMaster : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {

            BindGvCCDetail();

        }
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Team Master ";
                lblTMID.Text = "0";
                PnlCCDetails.Visible = false;
                PnlAddCC.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                txttname.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Team Master ";
                    PnlCCDetails.Visible = true;
                    PnlAddCC.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                    //BindGvCCDetail();
                }
        }
    }
    #region Binddata method
    public void BindGvCCDetail()
    {

        GrdCCDetails.DataSource = TeamMaster.GetTeamMaster("adminCCM");
        GrdCCDetails.DataBind();
    }
    #endregion
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       // string CmCode = txtCustCategoryCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
        TeamMaster _objDs = new TeamMaster();
        _objDs.TMID = Convert.ToInt32(lblTMID.Text);
        _objDs.TNAME = txttname.Text.Trim();
        _objDs.TDESC = txtdesc.Text.Trim();
        _objDs.CIsActive = ChekActive.Checked;
        try
        {
            if (txttname.Text != "")
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
                txttname.Text = "";
                txtdesc.Text = "";

            }
            else
            {
                BindGvCCDetail();
                txttname.Text = "";
                txtdesc.Text = "";
                ChekActive.Checked = true;
                PnlAddCC.Visible = true;
                PnlCCDetails.Visible = false;
            }



        }
        catch
        {

        }
    }

    protected void GrdCCDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TeamMaster _objDs2 = new TeamMaster();
        _objDs2.TMID = Convert.ToInt32(((Label)GrdCCDetails.Rows[e.RowIndex].FindControl("lblTMID")).Text);
        _objDs2.TNAME = ((Label)GrdCCDetails.Rows[e.RowIndex].FindControl("lblTMNAME")).Text;
        _objDs2.TDESC = ((Label)GrdCCDetails.Rows[e.RowIndex].FindControl("lbltdesc")).Text;

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
    protected void GrdCCDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlCCDetails.Visible = false;
        PnlAddCC.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txttname.Enabled = false;
        try
        {
            lblTMID.Text = ((Label)GrdCCDetails.Rows[e.NewEditIndex].FindControl("lblTMID")).Text;
            txttname.Text = ((Label)GrdCCDetails.Rows[e.NewEditIndex].FindControl("lblTMNAME")).Text;
            txtdesc.Text = ((Label)GrdCCDetails.Rows[e.NewEditIndex].FindControl("lbltdesc")).Text;
            ChekActive.Checked = ((CheckBox)GrdCCDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }
    protected void txttname_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Cmcode = txttname.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("TEAMNAME", Cmcode);
                if (Auth)
                {
                    MessageBox("Team Name is Already Exist");
                    txttname.Text = "";
                    txttname.Focus();

                }
                else
                {
                    txttname.Focus();
                }
            }
            catch
            {

            }
        }
    }
}
