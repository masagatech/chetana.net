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




public partial class UserControls_uc_AreaZoneMaster : System.Web.UI.UserControl
{
    #region Variables
    static DataView dv = null;
    #endregion
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetView();
            grdAreaZoneDetails.DataSource = BindAreaZoneDetail();
            grdAreaZoneDetails.DataBind();
            DataView dv = new DataView(BindAreaZoneDetail().Table);
            Session["data"] = dv;
            repAlfabets.DataSource = Customer_cs.GetAlphabets();
            repAlfabets.DataBind();

            Bind_DDL_SuperZone();
       }
        else
        {
        //    PnlAreaZone.Visible = true;
        }
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    #region EditDeleteMethodIn Gridview
    protected void grdAreaZoneDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAreaZoneDetails.PageIndex = e.NewPageIndex;
        grdAreaZoneDetails.DataSource = BindAreaZoneDetail();
        grdAreaZoneDetails.DataBind();
    }

    protected void grdAreaZoneDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlAreaZoneDetails.Visible = false;
        PnlAreaZone.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        txtAreaZoneCode.Enabled = false;
        btnSave.Text = "Update";
        try
        {
            lblID.Text = ((Label)grdAreaZoneDetails.Rows[e.NewEditIndex].FindControl("lblAreaZoneID")).Text;
            txtAreaZoneCode.Text = ((Label)grdAreaZoneDetails.Rows[e.NewEditIndex].FindControl("lblAreaZoneCode")).Text;
            txtAreaZoneName.Text = ((Label)grdAreaZoneDetails.Rows[e.NewEditIndex].FindControl("lblAreaZoneName")).Text;
            DDLSuperZone.SelectedValue = ((Label)grdAreaZoneDetails.Rows[e.NewEditIndex].FindControl("lblSuperzoneName")).Text;
            Bind_DDL_Zone();
            DDLZone.SelectedValue = ((Label)grdAreaZoneDetails.Rows[e.NewEditIndex].FindControl("lblZoneID")).Text;

            Chekacv.Checked = ((CheckBox)grdAreaZoneDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }

    protected void grdAreaZoneDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        AreaZoneMaster _objAZM = new AreaZoneMaster();
        _objAZM.AreaZoneID = Convert.ToInt32(((Label)grdAreaZoneDetails.Rows[e.RowIndex].FindControl("lblAreaZoneID")).Text);
        _objAZM.AreaZoneCode = ((Label)grdAreaZoneDetails.Rows[e.RowIndex].FindControl("lblAreaZoneCode")).Text;
        _objAZM.AreaZoneName = ((Label)grdAreaZoneDetails.Rows[e.RowIndex].FindControl("lblAreaZoneName")).Text;
        _objAZM.IsActive = Convert.ToBoolean(false);
        _objAZM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objAZM.Save();
           // MessageBox("Your Record is deleted");
            grdAreaZoneDetails.DataSource = BindAreaZoneDetail();
            grdAreaZoneDetails.DataBind();
            pnlAreaZoneDetails.Visible = true;
            PnlAreaZone.Visible = false;
        }
        catch
        {

        }
    }

    #endregion

    #region Methods

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add AreaZone ";
                lblID.Text = "0";
                txtAreaZoneCode.Focus();
                pnlAreaZoneDetails.Visible = false;
                PnlAreaZone.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit AreaZone ";                    
                    pnlAreaZoneDetails.Visible = true;
                    PnlAreaZone.Visible = false;
                   // btnAdd.Visible = true;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                }
            }
     }

    public DataView BindAreaZoneDetail()
    {
        DataTable dt = new DataTable();
        dt = AreaZoneMaster.GetAreaZoneMaster();
        DataView dv = new DataView(dt);
        return dv;
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "none"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
    }
   
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
    }

    public void SaveAreaZoneMaster()
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            MessageBox("Select SuperZone");
            DDLSuperZone.Focus();
        }
        if (DDLZone.SelectedIndex == 0)
        {
            MessageBox("Select Zone");
            DDLZone.Focus();
        }
        else
        {
            AreaZoneMaster _ObjAreaZoneMaster = new AreaZoneMaster();
            _ObjAreaZoneMaster.AreaZoneID = Convert.ToInt32(lblID.Text);
            _ObjAreaZoneMaster.AreaZoneCode = txtAreaZoneCode.Text.Trim();
            _ObjAreaZoneMaster.AreaZoneName = txtAreaZoneName.Text.Trim();
            _ObjAreaZoneMaster.ZoneID = Convert.ToInt32(DDLZone.SelectedItem.Value.ToString());
            _ObjAreaZoneMaster.IsActive = Chekacv.Checked;

            try
            {
                _ObjAreaZoneMaster.Save();
                MessageBox("Record saved successfully");
                grdAreaZoneDetails.DataSource = BindAreaZoneDetail();
                grdAreaZoneDetails.DataBind();
                if (btnSave.Text == "Update")
                {
                    pnlAreaZoneDetails.Visible = true;
                    PnlAreaZone.Visible = false;
                    btnSave.Visible = false;
                    btnSave.Text = "Save";
                    txtAreaZoneCode.Enabled = true;
                    filter.Visible = true;
                }
                else
                {
                    PnlAreaZone.Visible = true;
                    pnlAreaZoneDetails.Visible = false;
                    txtAreaZoneCode.Text = "";
                    txtAreaZoneName.Text = "";
                    DDLSuperZone.SelectedValue = null;
                    DDLZone.Items.Clear();
                    //DDLZone.SelectedValue = null;
                    Bind_DDL_SuperZone();
                }
            }
            catch
            {

            }
        }
    }


    #endregion

    #region Events

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveAreaZoneMaster();
    }

    
  
    #region Textbox Validation
       
    protected void txtAreaZoneCode_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("AreaZone", txtAreaZoneCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Area Zone Code is already present");
            txtAreaZoneCode.Text = "";
            txtAreaZoneCode.Focus();
        }
        else
        {
            txtAreaZoneName.Focus();
        }
    }
       
    #endregion

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
           // MessageBox("Select SuperZone");
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
          //  DDLZone.SelectedValue = null;
            Bind_DDL_SuperZone();
        }
        else 
        { 
            Bind_DDL_Zone();
            DDLZone.Focus();
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
            dv.RowFilter = "AreaZoneName like '" + val + "%'";
            grdAreaZoneDetails.DataSource = dv;
            grdAreaZoneDetails.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
    }

}


