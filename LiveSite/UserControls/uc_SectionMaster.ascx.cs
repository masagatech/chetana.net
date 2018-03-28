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

public partial class UserControls_uc_SectionMaster : System.Web.UI.UserControl
{
    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            GetValidation(9, Convert.ToInt32(Session["Role"]));
            if (view)
            {
                grdSectionMasterDetails.DataSource = BindGvSectionDetail();
                grdSectionMasterDetails.DataBind();
            }
            
            pnlSectionMasterDetails.Visible = true;
            PnlAddSection.Visible = false;
            //lblID.Text = "0";
            SetView();
        }
        else
        {
            PnlAddSection.Visible = true;
        }
    }
    #endregion

    #region GridView Events
    protected void grdSectionMasterDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlSectionMasterDetails.Visible = false;
        PnlAddSection.Visible = true;
        lblID.Text = ((Label)grdSectionMasterDetails.Rows[e.NewEditIndex].FindControl("lblSectionID")).Text;
        TxtSectionCode.Text = ((Label)grdSectionMasterDetails.Rows[e.NewEditIndex].FindControl("lblSectioncode")).Text;
        TxtSectionName.Text = ((Label)grdSectionMasterDetails.Rows[e.NewEditIndex].FindControl("lblSectionName")).Text;
        Chekacv.Checked = ((CheckBox)grdSectionMasterDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;

        UPAddSection.Update();

    }
    protected void grdSectionMasterDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SectionMaster _objSM = new SectionMaster();
        _objSM.SectionID = Convert.ToInt32(((Label)grdSectionMasterDetails.Rows[e.RowIndex].FindControl("lblSectionID")).Text);
        _objSM.Sectioncode = ((Label)grdSectionMasterDetails.Rows[e.RowIndex].FindControl("lblSectioncode")).Text;
        _objSM.SectionName = ((Label)grdSectionMasterDetails.Rows[e.RowIndex].FindControl("lblSectionName")).Text;
        _objSM.IsActive = Convert.ToBoolean(false);
        _objSM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objSM.Save();
            MessageBox("Your record is Deleted");
            grdSectionMasterDetails.DataSource = BindGvSectionDetail();
            grdSectionMasterDetails.DataBind();
            pnlSectionMasterDetails.Visible = true;
            PnlAddSection.Visible = false;
        }
        catch
        {

        }
    }
    protected void grdSectionMasterDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSectionMasterDetails.PageIndex = e.NewPageIndex;
        grdSectionMasterDetails.DataSource = BindGvSectionDetail();
        grdSectionMasterDetails.DataBind();
    }
    #endregion

    #region Binddata method

    public DataView BindGvSectionDetail()
    {
        DataTable dt = new DataTable();
        dt = SectionMaster.Get_SectionList();
        DataView dv = new DataView(dt);
        return dv;
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Button click Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SectionMaster _objSM = new SectionMaster();
        _objSM.SectionID = Convert.ToInt32(lblID.Text);
        _objSM.Sectioncode = TxtSectionCode.Text.Trim();
        _objSM.SectionName = TxtSectionName.Text.Trim();
        _objSM.IsActive = true;
        _objSM.IsDeleted = false;

        _objSM.CreatedBy = "Admin";
        try
        {
            _objSM.Save();
            MessageBox("Record saved successfully");
            grdSectionMasterDetails.DataSource = BindGvSectionDetail();
            grdSectionMasterDetails.DataBind();
            pnlSectionMasterDetails.Visible = true;
            PnlAddSection.Visible = false;
        }
        catch
        {

        }
    }
    #region Cancel Events
    protected void btncancel_Click(object sender, EventArgs e)
    {

        PnlAddSection.Visible = false;
        pnlSectionMasterDetails.Visible = true;


    }
    #endregion

    #endregion
    #region Method
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                TxtSectionCode.Focus();
                lblID.Text = "0";
                TxtSectionCode.Text = "";
                TxtSectionName.Text = "";
                UpdatePanel1.Update();
                PnlAddSection.Visible = true;
                pnlSectionMasterDetails.Visible = false;
                btnSave.Visible = true;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    PnlAddSection.Visible = false;
                    pnlSectionMasterDetails.Visible = true;
                    btnSave.Visible = false;
                }
        }
    }
    #region Validation Methods

    #region Variables

    private static bool add = false;
    private static bool view = false;
    private static bool edit = false;
    private static bool delete = false;

    #endregion

    public void GetValidation(int Menuid, int Roleid)
    {
        DataTable dt = new DataTable();
        dt = Mappings.Get_MenuFunctions(Menuid, Roleid).Tables[0];
        add = Convert.ToBoolean(dt.Rows[0]["Add"].ToString());
        view = Convert.ToBoolean(dt.Rows[0]["View"].ToString());
        edit = Convert.ToBoolean(dt.Rows[0]["Edit"].ToString());
        delete = Convert.ToBoolean(dt.Rows[0]["Delete"].ToString());
    }

    #endregion
    #endregion
    protected void grdSectionMasterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgbtnedit = (ImageButton)e.Row.FindControl("lblEdit");
            if (edit)
            {
                imgbtnedit.Visible = true;
            }
            ImageButton imgbtndelete = (ImageButton)e.Row.FindControl("LblDelete");
            if (delete)
            {
                imgbtndelete.Visible = true;
            }
        }
    }
}
