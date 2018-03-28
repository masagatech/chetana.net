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

public partial class UserControls_uc_SDZoneMaster : System.Web.UI.UserControl
{
    #region Variables
    static DataView dv = null;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            grdSuperZoneDetails.DataSource = BindGvSuperZoneDetail();
            grdSuperZoneDetails.DataBind();
            DataView dv = new DataView(BindGvSuperZoneDetail().Table);
            Session["data"] = dv;
            repAlfabets.DataSource = Customer_cs.GetAlphabets();
            repAlfabets.DataBind();
        }
        else
        {
           // pnlSuperZone.Visible = true;
        }  
    }
    #endregion

    #region Binddata method

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Super Duper Zone ";
                lblID.Text = "0";
                pnlSuperZoneDetails.Visible = false;
                txtSZCode.Focus();
                pnlSuperZone.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
            }
            else
            if (Request.QueryString["a"] == "v")
            {
                pageName.InnerHtml = "View / Edit Super Duper Zone";               
                filter.Focus();
                pnlSuperZoneDetails.Visible = true;
                pnlSuperZone.Visible = false;
                btnSave.Visible = false;
                filter.Visible = true;
            }
        }
    }

    public DataView BindGvSuperZoneDetail()
    {
        DataTable dt = new DataTable();
        dt = SDZone.GetSDZonemaster();
        DataView dv = new DataView(dt);
        return dv;
    }
    #endregion
     
    #region MsgBox
    public void MessageBox(string msg)
    {
        string  ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    #region Events

    #region Gridview Methods
    protected void grdSuperZoneDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSuperZoneDetails.PageIndex = e.NewPageIndex;
        grdSuperZoneDetails.DataSource = BindGvSuperZoneDetail();
        grdSuperZoneDetails.DataBind();
    }
    
    protected void grdSuperZoneDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlSuperZoneDetails.Visible = false;
        pnlSuperZone.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtSZCode.Enabled = false;
        try
        {
            lblID.Text = ((Label)grdSuperZoneDetails.Rows[e.NewEditIndex].FindControl("lblSZID")).Text;
            txtSZCode.Text = ((Label)grdSuperZoneDetails.Rows[e.NewEditIndex].FindControl("lblSZCode")).Text;
            txtSZName.Text = ((Label)grdSuperZoneDetails.Rows[e.NewEditIndex].FindControl("lblSZName")).Text;
            Chekacv.Checked = ((CheckBox)grdSuperZoneDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        }
        catch
        {
        }
   }

    protected void grdSuperZoneDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SDZone _objSZM = new SDZone();
        _objSZM.SDZoneID = Convert.ToInt32(((Label)grdSuperZoneDetails.Rows[e.RowIndex].FindControl("lblSZID")).Text);
        _objSZM.SDZoneCode = ((Label)grdSuperZoneDetails.Rows[e.RowIndex].FindControl("lblSZCode")).Text;
        _objSZM.SDZoneName = ((Label)grdSuperZoneDetails.Rows[e.RowIndex].FindControl("lblSZName")).Text;
        _objSZM.IsActive = Convert.ToBoolean(false);
        _objSZM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objSZM.Save();
            MessageBox("Your record is Deleted");
            grdSuperZoneDetails.DataSource = BindGvSuperZoneDetail();
            grdSuperZoneDetails.DataBind();
            pnlSuperZoneDetails.Visible = true;
            pnlSuperZone.Visible = false;
        }
        catch
        {

        }
    }
    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        txtSZCode.Text = "";
        txtSZName.Text = "";
                  
        lblID.Text = "0";
        pnlSuperZone.Visible = true;
        pnlSuperZoneDetails.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSuperZone.Visible = false;
        pnlSuperZoneDetails.Visible = true;
    }

    #region Save Method

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SDZone _objSzm = new SDZone();
        _objSzm.SDZoneID   = Convert.ToInt32(lblID.Text);
        _objSzm.SDZoneCode = txtSZCode.Text.Trim();
        _objSzm.SDZoneName = txtSZName.Text.Trim();
        _objSzm.IsActive = Chekacv.Checked;
        _objSzm.CreatedBy = Session["UserName"].ToString();
        try
        {
            _objSzm.Save();
            MessageBox("Record saved successfully");
            grdSuperZoneDetails.DataSource = BindGvSuperZoneDetail();
            grdSuperZoneDetails.DataBind();
            if (btnSave.Text == "Update")
            {
                pnlSuperZoneDetails.Visible = true;
                pnlSuperZone.Visible = false;
                btnSave.Visible = false;
                btnSave.Text = "Save";
                txtSZCode.Enabled = true;
                filter.Visible = true;
            }
            else
            {
                pnlSuperZoneDetails.Visible = false;
                pnlSuperZone.Visible = true;
                txtSZCode.Text = "";
                txtSZName.Text = "";
                txtSZCode.Focus();

            }
        }
        catch
        {

        }
    }

    #endregion

    protected void txtSZCode_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("SDZone", txtSZCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Super Duper Zone Code already exist");
            txtSZCode.Text = "";
            txtSZCode.Focus();
        }
        else
        {
            txtSZName.Focus();
        }
    }

    #endregion

    protected void lnkalfabet_click(object sender, EventArgs e)
    {

        foreach (RepeaterItem item in repAlfabets.Items)
        {
            ((LinkButton)(item.FindControl("lnkalfabet"))).BackColor = System.Drawing.Color.White;
            ((LinkButton)(item.FindControl("lnkalfabet"))).ForeColor = System.Drawing.Color.Black;
        }
        if (Session["data"] != null)
        {
            dv = (DataView)Session["data"];
            string val = ((LinkButton)(sender)).Text;
            dv.RowFilter = "SDZoneName like '" + val + "%'";
            grdSuperZoneDetails.DataSource = dv;
            grdSuperZoneDetails.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
    }

}
    
