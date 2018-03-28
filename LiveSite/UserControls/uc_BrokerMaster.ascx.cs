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

public partial class UserControls_uc_BrokerMaster : System.Web.UI.UserControl
{

    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            SetView();
            BindGvBroker();
            BindState();
        }   
    }
    #endregion

    #region Events

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        string brkrt = TxtBrkRate.Text;
        BrokerMaster objBrk = new BrokerMaster();
        
        objBrk.BrokerID         = Convert.ToInt32(LblBrokerID.Text); 
        objBrk.BrokerCode       = TxtBrokerCode.Text.Trim();   
        objBrk.FirstName        = TxtFname.Text.Trim();
        objBrk.MiddleName       = TxtMname.Text.Trim();
        objBrk.LastName         = TxtLname.Text.Trim();       
        objBrk.Address          = TxtAddress.Text.Trim();
        objBrk.Zip              = TxtZip.Text.Trim();
        objBrk.CityID           = Convert.ToInt32(DDLCity.SelectedValue.ToString());
        objBrk.Phone1           = TxtPhone1.Text.Trim();
        objBrk.Phone2           = TxtPhone2.Text.Trim();
        objBrk.Gender           = Rdgender.Text;
        objBrk.DOB              = TxtDob.Text;
        objBrk.EmailID          = TxtEmailID.Text.Trim();
        objBrk.IsActive = ChekActive.Checked;

        if (TxtBrkRate.Text == "")
        {
            objBrk.BrokerageRate = 0;
        }
        else
        {
            objBrk.BrokerageRate = Convert.ToInt32(brkrt);
        }
        if (LblBrokerID.Text == "0")
        {
            objBrk.Save();
            MessageBox("Record saved successfully");
            BindGvBroker();
            PnlAddBroker.Visible = true;
            PnlBrokerDetails.Visible = false;
        }
        else
        if (LblBrokerID.Text != "0" || LblBrokerID.Text != "")
        {
            objBrk.Save();
            MessageBox("Record updated successfully");
            BindGvBroker();
            PnlAddBroker.Visible = false;
            PnlBrokerDetails.Visible = true;
            filter.Visible = false;
        }     
        try
        {              
            TxtBrokerCode.Text = "";
            TxtFname.Text      = "";
            TxtMname.Text      = "";
            TxtLname.Text      = "";
            TxtAddress.Text    = "";
            TxtZip.Text        = "";
            DDLState.SelectedValue = null;
            DDLCity.SelectedValue = null;
            DDLCity.Enabled    = false;          
            TxtPhone1.Text     = "";
            TxtPhone2.Text     = "";
            Rdgender.Text      = "";
            TxtDob.Text        = "";
            TxtEmailID.Text    = "";
            TxtBrkRate.Text    = "";
            ChekActive.Checked = false;
        }
        catch
        {

        }
    }
    #endregion

    protected void GrdBroker_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlBrokerDetails.Visible = false;
        PnlAddBroker.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        TxtBrokerCode.Enabled = false;

        try
        {
            LblBrokerID.Text    = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblBrokerID")).Text;
            TxtBrokerCode.Text  = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblBrokerCode")).Text;
            TxtBrkRate.Text     = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblBrokerageRate")).Text;
            TxtFname.Text       = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblFN")).Text;
            TxtMname.Text       = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblMN")).Text;
            TxtLname.Text       = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblLN")).Text;
            TxtAddress.Text     = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblAddress")).Text;
            TxtZip.Text         = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblZip")).Text;
            TxtEmailID.Text     = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblEmailID")).Text;
            TxtPhone1.Text      = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblPhone1")).Text;
            TxtPhone2.Text      = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblPhone2")).Text;
            TxtDob.Text         = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblDob")).Text;
            Rdgender.Text       = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblGender")).Text;
            ChekActive.Checked  = ((CheckBox)GrdBroker.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
            
            DDLState.SelectedValue = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblStateID")).Text;
            BindState();
            BindCity_State();
            DDLCity.SelectedValue = ((Label)GrdBroker.Rows[e.NewEditIndex].FindControl("lblCityID")).Text;
            
        }
        catch
        {
        }
    }
    protected void GrdBroker_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Company objBrk1 = new Company();
        objBrk1.Flag = "BrokerMaster";
        objBrk1.ID = Convert.ToInt32(((Label)GrdBroker.Rows[e.RowIndex].FindControl("lblBrokerID")).Text);

        objBrk1.IsActive = Convert.ToBoolean(false);
        objBrk1.IsDeleted = Convert.ToBoolean(true);
        try
        {
            objBrk1.delete();

            BindGvBroker();
            PnlAddBroker.Visible = false;
            PnlBrokerDetails.Visible = true;
        }
        catch
        {
        }
    }
    protected void DDLState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity_State();
    }
    protected void TxtBrokerCode_TextChanged(object sender, EventArgs e)
    {
            try
            {
                string BrokerCode = TxtBrokerCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("Broker", BrokerCode);
                if (Auth)
                {
                    MessageBox("Broker Code Already Exist");
                    TxtBrokerCode.Text = "";
                    TxtBrokerCode.Focus();
                }
                else
                {
                    TxtBrkRate.Focus();
                }
            }
            catch
            {

            }
    }
    #endregion

    #region Methods

    #region BindMethods
    public void BindGvBroker()
    {
        GrdBroker.DataSource = BrokerMaster.GetBrokerMaster();
        GrdBroker.DataBind();
    }
   
    public void BindState()
    {
        DDLState.DataSource = Destination.GetDestination("adminstate");
        DDLState.DataBind();
        DDLState.Items.Insert(0, new ListItem("-Select State-", "0"));
        DDLCity.Items.Insert(0, new ListItem("-Select City-", "0"));
    }

    public void BindCity_State()
    {
        DDLCity.Items.Clear();
        DDLCity.Enabled = true;
        DDLCity.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLState.SelectedValue.ToString()), "ListCity");
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("-Select City-", "0"));
       
    }
    #endregion

    #region SetView
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Broker";
                LblBrokerID.Text = "0";
                PnlBrokerDetails.Visible = false;
                PnlAddBroker.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                TxtBrokerCode.Focus();
                DDLCity.Enabled = false;      
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Broker";
                    PnlBrokerDetails.Visible = true;
                    PnlAddBroker.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
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
