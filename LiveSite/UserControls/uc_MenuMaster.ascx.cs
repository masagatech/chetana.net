#region Namespace
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


public partial class UserControls_MenuMaster : System.Web.UI.UserControl
{

    #region Pageload

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            grdMenuDetails.DataSource = BindGvMenuDetail();
            grdMenuDetails.DataBind();
            pnlMenu.Visible = true;
            PnlAddMenu.Visible = false;
            //lblID.Text = "0";

        }
        else
        {
            PnlAddMenu.Visible = true;
        }


    }

    #endregion

    #region Binddata method

    public DataView BindGvMenuDetail()
    {
        DataTable dt = new DataTable();
        dt = Menumaster.Get_MenuList();
        DataView dv = new DataView(dt);
        return dv;
    }
    #endregion

    #region Save Method

    protected void btnsav_Click(object sender, EventArgs e)
    {

        Menumaster _objMM = new Menumaster();
        _objMM.MenuId =Convert.ToInt32(lblID.Text);
        _objMM.MenuName = txtMname.Text.Trim();
        _objMM.Link = txtlink.Text.Trim();
        _objMM.IsActive = true;
        try
        {
            _objMM.Save();
            MessageBox("Record saved successfully");
            grdMenuDetails.DataSource = BindGvMenuDetail();
            grdMenuDetails.DataBind();
            pnlMenu.Visible = true;
            PnlAddMenu.Visible = false;
        }
        catch
        {

        }
    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Gidview Methods
    protected void grdMenuDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMenuDetails.PageIndex = e.NewPageIndex;
        grdMenuDetails.DataSource = BindGvMenuDetail();
        grdMenuDetails.DataBind();
    }


    
    protected void grdMenuDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlMenu.Visible = false;
        PnlAddMenu.Visible = true;
        lblID.Text = ((Label)grdMenuDetails.Rows[e.NewEditIndex].FindControl("lblMID")).Text;
        txtMname.Text = ((Label)grdMenuDetails.Rows[e.NewEditIndex].FindControl("lblName")).Text;
        txtlink.Text = ((Label)grdMenuDetails.Rows[e.NewEditIndex].FindControl("lblLink")).Text;
        chekactive.Checked = ((CheckBox)grdMenuDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        UpdatePanel2.Update();
    }



    protected void grdMenuDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Menumaster _objMM = new Menumaster();
        _objMM.MenuId = Convert.ToInt32(((Label)grdMenuDetails.Rows[e.RowIndex].FindControl("lblMID")).Text);
        _objMM.MenuName = ((Label)grdMenuDetails.Rows[e.RowIndex].FindControl("lblName")).Text;
        _objMM.Link = ((Label)grdMenuDetails.Rows[e.RowIndex].FindControl("lblLink")).Text;
        _objMM.IsActive = Convert.ToBoolean(false);
        _objMM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objMM.Save();
            MessageBox("Your record is Deleted");
            grdMenuDetails.DataSource = BindGvMenuDetail();
            grdMenuDetails.DataBind();
            pnlMenu.Visible = true;
            PnlAddMenu.Visible = false;
        }
        catch
        {

        }
    }
    #endregion

   
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        lblID.Text = "0";
        txtMname.Text = "";
        txtlink.Text = "";
        UpdatePanel2.Update();
        PnlAddMenu.Visible = true;
        pnlMenu.Visible = false;

    }


    protected void btncancel_Click(object sender, EventArgs e)
    {
        pnlMenu.Visible = true;
        PnlAddMenu.Visible = false;
    }
}
