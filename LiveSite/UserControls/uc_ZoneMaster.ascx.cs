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

public partial class UserControls_uc_ZoneMaster : System.Web.UI.UserControl
{
    #region Variables
    static DataView dv = null;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdZoneDetails.DataSource = BindGvZoneDetail();
            grdZoneDetails.DataBind();
            DataView dv = new DataView(BindGvZoneDetail().Table);
            Session["data"] = dv;
            Bind_DDL_SuperZone();
            repAlfabets.DataSource = Customer_cs.GetAlphabets();
            repAlfabets.DataBind();
            SetView();
        }
        else
        {
           // pnlZone.Visible = true;
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
                pageName.InnerHtml = "ADD Zone ";
                lblID.Text = "0";
                txtZoneCode.Focus();
                pnlZoneDetails.Visible = false;
                pnlZone.Visible = true;
                btnSave.Visible=true;
                filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Zone ";
                    pnlZoneDetails.Visible = true;
                    pnlZone.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                }
           }
    }

    public DataView BindGvZoneDetail()
    {
        DataTable dt = new DataTable();
        dt = ZoneMaster.GetZoneMaster();
        DataView dv = new DataView(dt);
        return dv;
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_Masters_Code_ID_Name("superzone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "none"));
    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    #region Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            MessageBox("Select SuperZone");
            DDLSuperZone.Focus();
        }
        else
        {
            ZoneMaster _objZm = new ZoneMaster();
            _objZm.ZoneID = Convert.ToInt32(lblID.Text);
            _objZm.ZoneCode = txtZoneCode.Text.Trim();
            _objZm.ZoneName = txtZoneName.Text.Trim();
            _objZm.SuperZoneID = Convert.ToInt32(DDLSuperZone.SelectedItem.Value.ToString());
            _objZm.IsActive = Chekacv.Checked;
            try
            {
                _objZm.Save();
                MessageBox("Record saved successfully");
                grdZoneDetails.DataSource = BindGvZoneDetail();
                grdZoneDetails.DataBind();
                if (btnSave.Text == "Update")
                {
                    pnlZoneDetails.Visible = true;
                    pnlZone.Visible = false;
                    btnSave.Visible = false;
                    btnSave.Text = "Save";
                    txtZoneCode.Enabled = true;
                    filter.Visible = true;
                }
                else
                {
                    pnlZoneDetails.Visible = false;
                    pnlZone.Visible = true;
                    txtZoneCode.Text = "";
                    txtZoneCode.Focus();
                    txtZoneName.Text = "";
                    DDLSuperZone.SelectedValue = null;
                }
            }
            catch
            {

            }
        }
    }

      #region Gridview Methods
      
    protected void grdZoneDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

        pnlZoneDetails.Visible = false;
        pnlZone.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        txtZoneCode.Enabled = false;
        try
        {
            lblID.Text = ((Label)grdZoneDetails.Rows[e.NewEditIndex].FindControl("lblZID")).Text;
            txtZoneCode.Text = ((Label)grdZoneDetails.Rows[e.NewEditIndex].FindControl("lblZCode")).Text;
            txtZoneName.Text = ((Label)grdZoneDetails.Rows[e.NewEditIndex].FindControl("lblZName")).Text;

            DDLSuperZone.SelectedValue = ((Label)grdZoneDetails.Rows[e.NewEditIndex].FindControl("lblSZID")).Text;
            Chekacv.Checked = ((CheckBox)grdZoneDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }

    protected void grdZoneDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ZoneMaster _objZM = new ZoneMaster();
        _objZM.ZoneID = Convert.ToInt32(((Label)grdZoneDetails.Rows[e.RowIndex].FindControl("lblZID")).Text);
        _objZM.ZoneCode = ((Label)grdZoneDetails.Rows[e.RowIndex].FindControl("lblZCode")).Text;
        _objZM.ZoneName = ((Label)grdZoneDetails.Rows[e.RowIndex].FindControl("lblZName")).Text;
     // _objZM.SuperZoneID = Convert.ToInt32(((Label)grdZoneDetails.Rows[e.RowIndex].FindControl("lblSZName")).Text);
    
        _objZM.IsActive = Convert.ToBoolean(false);
        _objZM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objZM.Save();
            MessageBox("Your record is Deleted");
            grdZoneDetails.DataSource = BindGvZoneDetail();
            grdZoneDetails.DataBind();
            pnlZoneDetails.Visible = true;
            pnlZone.Visible = false;
        }
        catch
        {

        }
    }

    protected void grdZoneDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdZoneDetails.PageIndex = e.NewPageIndex;
        grdZoneDetails.DataSource = BindGvZoneDetail();
        grdZoneDetails.DataBind();
    }
      #endregion

    #region Textbox Validation

    protected void txtZoneCode_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("Zone", txtZoneCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Zone Code is already present");
            txtZoneCode.Text = "";
            txtZoneCode.Focus();
        }
        else
        {
            txtZoneName.Focus();
        }
    }
   
    #endregion

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
            dv.RowFilter = "ZoneName like '" + val + "%'";
            grdZoneDetails.DataSource = dv;
            grdZoneDetails.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
    }

}