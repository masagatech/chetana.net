#region NameSpace

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

#endregion

public partial class UserControls_CompanyMaster : System.Web.UI.UserControl
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            BindGvCompanyDetail();
            BindSuperZone();
            BindState();         
        }   
    }
    #endregion

    #region Events

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Company objcmpy = new Company();
        objcmpy.CompanyID = Convert.ToInt32(LblCmpID.Text); 
        objcmpy.CompanyCode = TxtCmpyCode.Text.Trim();
        objcmpy.CompanyName = TxtCmpyName.Text.Trim();
        objcmpy.CompanyShortform = TxtShortForm.Text.Trim();
        objcmpy.Address = TxtAddress.Text.Trim();
        objcmpy.AreaID = Convert.ToInt32(DDLarea.SelectedValue);
        objcmpy.CityID = Convert.ToInt32(DDLCity.SelectedValue);

        objcmpy.Zip         = TxtZip.Text.Trim();
        objcmpy.Phone1      = TxtPhone1.Text.Trim();
        objcmpy.Phone2      = TxtPhone2.Text.Trim();
        objcmpy.EmailID     = TxtEmailID.Text.Trim();
        objcmpy.IsActive    = ChekActive.Checked;

        try
        {
            if (TxtCmpyCode.Text != "")
            {
                objcmpy.Save();
            }
            MessageBox("Record saved successfully");
            BindGvCompanyDetail();
            TxtCmpyCode.Text = "";
            TxtCmpyName.Text = "";
            TxtShortForm.Text = "";
            TxtAddress.Text = "";

            TxtZip.Text = "";
            TxtPhone1.Text = "";
            TxtPhone2.Text = "";
            TxtEmailID.Text = "";
            ChekActive.Checked = false;
           
            DDLarea.SelectedValue = null;
            DDLState.SelectedValue = null;
            DDLCity.SelectedValue = null;
            DDLsuperzone.SelectedValue = null;
            DDLzone.SelectedValue = null;
            DDLareazone.SelectedValue = null;


            PnlAddCmpy.Visible = true;
            PnlCmpyDetails.Visible = false;
        }
        catch
        {

        }
    }
    #endregion

    #region SelectedIndexChanged
    protected void DDLsuperzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZone_SuperZone();
    }

    protected void DDLzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAreaZone_Zone();
    }

    protected void DDLareazone_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindArea_AreaZone();
    }

    protected void DDLState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity_State();
    }
    #endregion

    #region Grid Events

    protected void GrdCmpyDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlCmpyDetails.Visible = false;
        PnlAddCmpy.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        TxtCmpyCode.Enabled = false;
        DDLCity.Enabled = true;
        DDLzone.Enabled = true;
        DDLareazone.Enabled = true;
        DDLarea.Enabled=true;
        try
        {
            LblCmpID.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblCmpyID")).Text;
            TxtCmpyCode.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblCmpyCode")).Text;
            TxtCmpyName.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblCmpyName")).Text;
            TxtShortForm.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblShortForm")).Text;
            TxtAddress.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblAddress")).Text;
            TxtZip.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblZip")).Text;
            TxtEmailID.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblEmailID")).Text;
            TxtPhone1.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblPhone1")).Text;
            TxtPhone2.Text = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblPhone2")).Text;
            ChekActive.Checked = ((CheckBox)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;

            DDLsuperzone.SelectedValue = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblSuperZoneID")).Text;
            BindSuperZone();

            BindZone_SuperZone();
            DDLzone.SelectedValue = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblZoneID")).Text;

            BindAreaZone_Zone();
            DDLareazone.SelectedValue = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblAreaZoneID")).Text;

            BindArea_AreaZone();
            DDLarea.SelectedValue = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblAreaID")).Text;

            BindState();
            DDLState.SelectedValue = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblStateID")).Text;

            BindCity_State();
            DDLCity.SelectedValue = ((Label)GrdCmpyDetails.Rows[e.NewEditIndex].FindControl("lblCityID")).Text;
           
        }
        catch
        {
        }
    }

    protected void GrdCmpyDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Company objcmpy1 = new Company();
        objcmpy1.Flag = "CompanyMaster";
        objcmpy1.ID = Convert.ToInt32(((Label)GrdCmpyDetails.Rows[e.RowIndex].FindControl("lblCmpyID")).Text);
       // objcmpy1.CompanyCode = ((Label)GrdCmpyDetails.Rows[e.RowIndex].FindControl("lblDMCode")).Text;
       // objcmpy1.CompanyName = ((Label)GrdCmpyDetails.Rows[e.RowIndex].FindControl("lblCityName")).Text;

        objcmpy1.IsActive = Convert.ToBoolean(false);
        objcmpy1.IsDeleted = Convert.ToBoolean(true);
        try
        {
            objcmpy1.delete();
        
            BindGvCompanyDetail();
            PnlAddCmpy.Visible = false;
            PnlCmpyDetails.Visible = true;
        }
        catch
        {
        }

    }
    #endregion

    protected void TxtCmpyCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string Cmcode = TxtCmpyCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            bool Auth = Masters.GetCodeValidation("Company", Cmcode);
            if (Auth)
            {
                MessageBox("Company Code Already Exist");
                TxtCmpyCode.Text = "";
                TxtCmpyCode.Focus();
            }
            else
            {
                TxtAddress.Focus();
            }
        }
        catch
        {

        }
    }

    #endregion

    #region Methods
    #region Binddata Method
    public void BindGvCompanyDetail()
    {
        GrdCmpyDetails.DataSource = Company.GetCompanyMaster();
        GrdCmpyDetails.DataBind();
    }
   
    public void BindSuperZone()
    {
       DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
            DDLsuperzone.DataBind();
            DDLsuperzone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
            DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
            DDLareazone.Items.Insert(0, new ListItem("-Select AreaZone-", "0"));
            DDLarea.Items.Insert(0, new ListItem("-Select Area-", "0"));
    }  
   
    public void BindState()
    {
        DDLState.DataSource = Destination.GetDestination("adminstate");
        DDLState.DataBind();
        DDLState.Items.Insert(0, new ListItem("-Select State-", "0"));
        DDLCity.Items.Insert(0, new ListItem("-Select City-", "0"));
    }

    public void BindZone_SuperZone()
    {
        DDLzone.Items.Clear();
        DDLzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLsuperzone.SelectedValue.ToString()), "Zone");
        DDLzone.DataBind();
        DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        DDLzone.Enabled = true;
    }

    public void BindAreaZone_Zone()
    {
        DDLareazone.Items.Clear();
        DDLareazone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLzone.SelectedValue.ToString()), "AreaZone");
        DDLareazone.DataBind();
        DDLareazone.Items.Insert(0, new ListItem("-Select AreaZone-", "0"));
        DDLareazone.Enabled = true;
    }

    public void BindArea_AreaZone()
    {
        DDLarea.Items.Clear();
        DDLarea.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLareazone.SelectedValue.ToString()), "Area");
        DDLarea.DataBind();
        DDLarea.Items.Insert(0, new ListItem("-Select AreaZone-", "0"));
        DDLarea.Enabled = true;
    }

    public void BindCity_State()
    {
        DDLCity.Items.Clear();
        DDLCity.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLState.SelectedValue.ToString()), "ListCity");
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("Select City", "0"));
        DDLCity.Enabled = true;
    }

    #endregion

    #region SetView
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Company";                
                LblCmpID.Text = "0";
                PnlCmpyDetails.Visible = false;
                PnlAddCmpy.Visible = true;
                btnSave.Visible = true;
               filter.Visible = false;
               TxtCmpyName.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Company";
                    PnlCmpyDetails.Visible = true;
                    PnlAddCmpy.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();

                }
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

    #endregion


}
