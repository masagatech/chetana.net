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
using System.Data.SqlClient;
#endregion


public partial class UserControls_uc_CustomerMaster_Individual_View : System.Web.UI.UserControl
{
    #region Variables
    int CID;
    string flag = "state";
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        fillzones();
        if (ChkBlacklist.Checked == true)
        {
            lblblkremark.Visible = true;
            LblblkDate.Visible = true;
            TxtblkRemark.Visible = true;
            TxtblkDate.Visible = true;
        }
        else
        {
            lblblkremark.Visible = false;
            LblblkDate.Visible = false;
            TxtblkRemark.Visible = false;
            TxtblkDate.Visible = false;

        }
       
        if (!Page.IsPostBack)
        {
           
        }
        if (ChkBlacklist.Checked == true)
        {
            lblblkremark.Visible = true;
            LblblkDate.Visible = true;
            TxtblkRemark.Visible = true;
            TxtblkDate.Visible = true;
        }
        else
        {
            lblblkremark.Visible = false;
            LblblkDate.Visible = false;
            TxtblkRemark.Visible = false;
            TxtblkDate.Visible = false;

        }
    }
    #endregion
    
    #region Binddata method

    public DataTable BindGvCustDetail(string CustCode)
    {
        DataTable dt = new DataTable();
        dt = Customer_cs.Get_CustList("", CustCode);
        return dt;
    }


    #endregion



    public void FillForm()
    {
        try
        {
            //DDLareazone.Enabled = true;
            //DDLarea.Enabled = true;
            //DDLzone.Enabled = true;
            //btnSave.Visible = true;
            PnlAdd.Visible = true;
            //PnlAdd.Enabled= false;

            //btnSave.Text = "Update";
            //btnSave.Enabled = true;
            LblCustId.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblCustID")).Text;
            TxtCustCode.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblCustCode")).Text;
            TxtShortForm.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblShortForm")).Text;
            TxtFamilyCode.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblFamilyCode")).Text;
            TxtAddress.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblAddress")).Text;
            TxtZip.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblZip")).Text;
            TxtPhone1.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblPhone1")).Text;
            TxtPhone2.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblPhone2")).Text;
            TxtEmailID.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblEmailID")).Text;
            TxtCustName.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblCustName")).Text;
            TxtCreditLimit.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblCreditLimit")).Text;
            TxtPrincipalName.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblPrincipalName")).Text;
            TxtPrincipalMobile.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblPrincipalMobile")).Text;
            TxtPrincipalDOB.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblPrincipalDOB")).Text;
            TxtKeyPersonName.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblKeyPersonName")).Text;
            TxtKeyPersonMobile.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblKeyPersonMobile")).Text;
            TxtKeyPersonDOB.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblKeyPersonDOB")).Text;
            TxtAdditinalDis.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblAdditinalDis")).Text;
            TxtVIPRemark.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblVIPRemark")).Text;
            TxtMedium.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblMedium")).Text;
            ChkIsActive.Checked = ((CheckBox)grdCustDetails.Rows[0].FindControl("chkisActive")).Checked;
            LblSuperzone.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblSuperZoneID")).Text;
            Lblzone.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblZoneID")).Text;
            LblAreazone.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblAreaZoneID")).Text;
            LblArea.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblAreaID")).Text;
            LblCustDetailID1.Text = ((Label)grdCustDetails.Rows[0].FindControl("LblCustDetailID")).Text;
            TxtCustomerType.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblctype")).Text;
            txtcreditdays.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblcreditdays")).Text;
            lblrating.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblcustrating")).Text;
            txtSchAdditionalDis.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblSchAdditionalDis")).Text;
            txtTODValue1.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblTODValue1")).Text;
            txtTODValue2.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblTODValue2")).Text;
            txtTODValue3.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblTODValue3")).Text;
            txtTODDisc1.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblTODDisc1")).Text;
            txtTODDisc2.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblTODDisc2")).Text;
            txtTODDisc3.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblTODDisc3")).Text;
            TxtblkRemark.Text = ((Label)grdCustDetails.Rows[0].FindControl("Lblblkremark")).Text;
            TxtblkDate.Text = ((Label)grdCustDetails.Rows[0].FindControl("Lblblkdate")).Text;
            txtUpperlimit.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblCUL")).Text;
            txtLowerlimit.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblCLL")).Text;
            chk_splitdc.Checked = ((CheckBox)grdCustDetails.Rows[0].FindControl("chk_isSplit")).Checked;
            //ReadMe Comment(Zaid Ansari) Any Problem SBUCode Dropdown Bind Find This Method GetSBUCode()
            lblSBUCodeNone.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblSUBCode")).Text == "" ? "0" : lblSBUCodeNone.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblSUBCode")).Text;   
            txtPANNo.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblPan")).Text;
            try
            {
                //ReadMe Comment(Zaid Ansari)(Dropdown Bind) Super Zone ,State,City,Category Any Problem Find This Method fillzones()
                ddlSbucode.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("SBU", "DropDown");
                ddlSbucode.DataBind();
                ddlSbucode.Items.Insert(0, new ListItem("--Seelct SBU Code--", "0"));
                ddlSbucode.SelectedValue = lblSBUCodeNone.Text;

                DDLsuperzone.SelectedValue = LblSuperzone.Text;
                DDLzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(LblSuperzone.Text), "Zone");
                DDLzone.DataBind();
                DDLzone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
                DDLzone.SelectedValue = Lblzone.Text.Trim();

                DDLareazone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(Lblzone.Text), "AreaZone");
                DDLareazone.DataBind();
                DDLareazone.Items.Insert(0, new ListItem("--Select AreaZone--", "0"));
                DDLareazone.SelectedValue = LblAreazone.Text.Trim();

                DDLarea.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(LblAreazone.Text), "Area");
                DDLarea.DataBind();
                DDLarea.Items.Insert(0, new ListItem("--Select Area--", "0"));
                DDLarea.SelectedValue = LblArea.Text.Trim();
            }
            catch { }
            ddLStates.DataSource = Destination.GetDestination(flag);
            ddLStates.DataBind();
            ddLStates.Items.Insert(0, new ListItem("--Select State--", "0"));
            ddLStates.SelectedValue = ((Label)grdCustDetails.Rows[0].FindControl("lblstate1")).Text.Trim();

            ddlCity.DataSource = Destination.GetDestination(Convert.ToString(ddLStates.SelectedValue));
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            ddlCity.SelectedValue = ((Label)grdCustDetails.Rows[0].FindControl("lblCity")).Text.Trim();

            DataView dv1 = new DataView(Masterofmaster.Get_MasterOfMaster_ByGroup("CustRating").Tables[0]);
            DdlCustRating.DataSource = dv1;
            DdlCustRating.DataBind();
            DdlCustRating.Items.Insert(0, new ListItem("--Select Rating--", "0"));
            DdlCustRating.SelectedValue = lblrating.Text.Trim();
            ChkBlacklist.Checked = ((CheckBox)grdCustDetails.Rows[0].FindControl("ChKBList")).Checked;

            //lblboardid.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblboardid")).Text;
            //DDLBoard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup("Board").Tables[0];
            //DDLBoard.DataBind();
            //DDLBoard.Items.Insert(0, new ListItem("--Select Board--", "0"));
            //DDLBoard.SelectedValue = ((Label)grdCustDetails.Rows[0].FindControl("lblboardid")).Text;
            txtassociation.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblassociation")).Text;
            txtcgp.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblcgp")).Text;
            txtbuisiness.Text = ((Label)grdCustDetails.Rows[0].FindControl("lblbuisiness")).Text;

            DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster(flag);
            DDLCC.DataBind();
            DDLCC.Items.Insert(0, new ListItem("--Select Category--", "0"));
            DDLCC.SelectedValue = ((Label)grdCustDetails.Rows[0].FindControl("lblCMID")).Text.Trim();

            DDLCSC.DataSource = CustCategory.GetCustomerCategoryMaster(Convert.ToString(DDLCC.SelectedValue));
            DDLCSC.DataBind();
            DDLCSC.Items.Insert(0, new ListItem("--Select City--", "0"));
            DDLCSC.SelectedValue = ((Label)grdCustDetails.Rows[0].FindControl("lblCMIDSUB")).Text.Trim();


        }
        catch(Exception ex)
        {


        }
    }
    
    private void fillzones()
    {
        DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
        DDLsuperzone.DataBind();
        DDLsuperzone.Items.Insert(0, new ListItem("--Select SuperZone--", "0"));
        ddLStates.DataSource = Destination.GetDestination(flag);
        ddLStates.DataBind();
        ddLStates.Items.Insert(0, new ListItem("--Select State--", "0"));

        ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster(flag);
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("--Select Category--", "0"));
        DDLCSC.Items.Insert(0, new ListItem("--Select Sub Category--", "0"));

    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        allVisible();
       
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataSet ds = new DataSet();
        ds = DCMaster.Get_Name(CustCode, "Customer!"+Session["FY"].ToString());
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        dt = ds.Tables[0];
        dt1 = ds.Tables[1];     //CustomerTod Table 
        DataTable dtAssorted = ds.Tables[2];    //Customer Assorted Discount
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;    
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);

            grdCustDetails.DataSource = BindGvCustDetail(CustCode);
            grdCustDetails.DataBind();

            if (dtAssorted.Rows.Count > 0)
            {
                AssortedPanel.Visible = true;
                GridAssorted.DataSource = dtAssorted;
                GridAssorted.DataBind();
            }
            else
            {
                GridAssorted.DataSource = dtAssorted;
                GridAssorted.DataBind();
            }

            if (dt1.Rows.Count > 0)
            {
                PanelTod.Visible = true;
                TODGridview.DataSource = dt1;
                TODGridview.DataBind();
            }
            else
            {
                TODGridview.DataSource = dt1;
                TODGridview.DataBind();
            }

            if (grdCustDetails.Rows.Count > 0)
                FillForm();
            if (ChkBlacklist.Checked == true)
            {
                lblblkremark.Visible = true;
                LblblkDate.Visible = true;
                TxtblkRemark.Visible = true;
                TxtblkDate.Visible = true;
            }
            else
            {
                lblblkremark.Visible = false;
                LblblkDate.Visible = false;
                TxtblkRemark.Visible = false;
                TxtblkDate.Visible = false;

            }


        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
            grdCustDetails.DataSource = null;
            grdCustDetails.DataBind();

        }
        
    }

    public void allVisible()
    {
        string pagename = Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower();
        if (pagename == "customer_view_all.aspx")
        {
            RowadditionalDisc.Visible = true;

        }
    }
    protected void DDLCC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLCC.SelectedValue != "0")
        {
            DDLCSC.DataSource = CustCategory.GetCustomerCategoryMaster(Convert.ToString(DDLCC.SelectedValue));
            DDLCSC.DataBind();
            DDLCSC.Items.Insert(0, new ListItem("Select Sub Category", "0"));
            if (DDLCSC.Items.Count > 0)
            {
                DDLCSC.Focus();
            }
            else
            {
                DDLCSC.Focus();
            }
        }
        else
        {
            DDLCSC.DataBind();
            DDLCSC.Focus();
        }
    }
}


