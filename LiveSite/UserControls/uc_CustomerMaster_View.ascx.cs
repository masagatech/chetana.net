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


public partial class UserControls_uc_CustomerMaster_View : System.Web.UI.UserControl
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack)
        {
            
            DataView dv = new DataView(BindGvCustDetail().Table);
            Session["data"] = dv;
            grdCustDetails.DataSource = dv;
            grdCustDetails.DataBind();
            DdlSection.Enabled = false;
            DdlSection.DataSource = SectionMaster.Get_SectionList();
            DdlSection.DataBind();
            repAlfabets.DataSource = Customer_cs.GetAlphabets();
            repAlfabets.DataBind();
            LblCustId.Text = "0";
            fillzones();
            TxtCustCode.Focus();
            custRating();
            getDDLdata();
            getDDLarezo();
            getDDLarea();
            
            SetView();
            //dv = (DataView)Session["data"];
            ////string val = ((LinkButton)(sender)).Text;
            //dv.RowFilter = "CustName='A'";
            //grdCustDetails.DataSource = dv;
            //grdCustDetails.DataBind();
            //((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            //((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;

        }
    }
    #endregion

    #region Save Customer

    protected void btnSave_Click(object sender, EventArgs e)
    {

        // DdlSection.Text = "----";

        try
        {
            //string Area = TxtArea.Text.Split(':')[0].Trim();
            Customer_cs _objCust = new Customer_cs();
            _objCust.CustID = Convert.ToInt32(LblCustId.Text);
            _objCust.CustCode = TxtCustCode.Text.Trim();
            _objCust.ShortForm = TxtShortForm.Text.Trim();
            _objCust.FamilyCode = TxtFamilyCode.Text.Trim();
            _objCust.Address = TxtAddress.Text.Trim();
            _objCust.Zip = TxtZip.Text.Trim();
            _objCust.Phone1 = TxtPhone1.Text.Trim();
            _objCust.Phone2 = TxtPhone2.Text.Trim();
            _objCust.EmailID = TxtEmailID.Text.Trim();
            _objCust.CUSTOMERTYPE = TxtCustomerType.Text.Trim();
            _objCust.IsDeleted = false;
            _objCust.IsActive = true;
            _objCust.CreatedBy = Convert.ToString(Session["UserName"]); 
            _objCust.CustName = TxtCustName.Text.Trim();
            _objCust.ZoneID = Convert.ToInt32(DDLzone.SelectedValue);
            _objCust.SuperZoneID = Convert.ToInt32(DDLsuperzone.SelectedValue);
            _objCust.AreaZoneID = Convert.ToInt32(DDLareazone.SelectedValue);
            _objCust.AreaID = Convert.ToInt32(DDLarea.SelectedValue);
            _objCust.DMID = Convert.ToInt32(ddLStates.SelectedValue);
            _objCust.City = Convert.ToInt32(ddlCity.SelectedValue);
            _objCust.CustRating = Convert.ToInt32(DdlCustRating.SelectedValue);
            string TxtPrincipalDOB1 = "";
            string TxtKeyPersonDOB1 = "";

            try
            {
                TxtPrincipalDOB1 = TxtPrincipalDOB.Text.Split('/')[1] + "/" + TxtPrincipalDOB.Text.Split('/')[0] + "/" + TxtPrincipalDOB.Text.Split('/')[2];
                TxtKeyPersonDOB1 = TxtKeyPersonDOB.Text.Split('/')[1] + "/" + TxtKeyPersonDOB.Text.Split('/')[0] + "/" + TxtKeyPersonDOB.Text.Split('/')[2];

            }
            catch
            {


            }

            if (LblCustId.Text == "0")
            {
                _objCust.Save(out CID);
                // TxtCustId.Text = Convert.ToString(CID);
                string Medium = TxtMedium.Text.Split(':')[0].Trim();
                CustomerDetails _objCustDetails = new CustomerDetails();
                _objCustDetails.CustId = CID;
                _objCustDetails.CustCode = TxtCustCode.Text.Trim();
                _objCustDetails.CreditLimit = TxtCreditLimit.Text.Trim();
                // _objCustDetails.Creditdays = txtcreditdays.Text.Trim();
                _objCustDetails.BlackList = ChkBlacklist.Checked;
                _objCustDetails.CreatedBy = Convert.ToString(Session["UserName"]); 
                _objCustDetails.PrincipalName = TxtPrincipalName.Text.Trim();
                _objCustDetails.PrincipalMobile = TxtPrincipalMobile.Text.Trim();
                _objCustDetails.PrincipalDOB = TxtPrincipalDOB1;
                _objCustDetails.KeyPersonName = TxtKeyPersonName.Text.Trim();
                _objCustDetails.KeyPersonMobile = TxtKeyPersonMobile.Text.Trim();
                _objCustDetails.KeyPersonDOB = TxtKeyPersonDOB.Text.Trim();
                _objCustDetails.AdditinalDis = TxtAdditinalDis.Text.Trim();
                _objCustDetails.VIPRemark = TxtVIPRemark.Text.Trim();
                _objCustDetails.SectionID = 0;
                //_objCustDetails.SectionID = Convert.ToInt32(DdlSection.SelectedValue);
                _objCustDetails.Medium = Medium;
                _objCustDetails.Save();
                grdCustDetails.Visible = true;
                PnlDetails.Visible = true;
                MessageBox("Record saved successfully");
                if (btnSave.Text == "Update")
                {
                    PnlDetails.Visible = true;
                    PnlAdd.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;


                }
                else
                {
                    PnlDetails.Visible = false;
                    PnlAdd.Visible = true;
                    btnSave.Visible = true;

                }
            }
            else
            {
                string Medium = TxtMedium.Text.Split(':')[0].Trim();
                _objCust.CustID = Convert.ToInt32(LblCustId.Text);
                _objCust.CustDetailID = Convert.ToInt32(LblCustDetailID1.Text);
                if (TxtCreditLimit.Text == "")
                {
                    TxtCreditLimit.Text = "0";
                }
                _objCust.CreditLimit = Convert.ToInt32(TxtCreditLimit.Text.Trim());
                _objCust.CreditDays = txtcreditdays.Text.Trim();
                _objCust.BlackList = ChkBlacklist.Checked;
                _objCust.IsDeleted1 = false;
                _objCust.PrincipalName = TxtPrincipalName.Text.Trim();
                _objCust.PrincipalMobile = TxtPrincipalMobile.Text.Trim();
                _objCust.PrincipalDOB = TxtPrincipalDOB.Text.Trim();
                _objCust.KeyPersonName = TxtKeyPersonName.Text.Trim();
                _objCust.KeyPersonMobile = TxtKeyPersonMobile.Text.Trim();
                _objCust.KeyPersonDOB = TxtKeyPersonDOB.Text.Trim();
                _objCust.AdditinalDis = TxtAdditinalDis.Text.Trim();
                _objCust.VIPRemark = TxtVIPRemark.Text.Trim();
              
                //_objCust.SectionID = Convert.ToInt32(DdlSection.SelectedValue);
                _objCust.SectionID = 0;
                _objCust.Medium = Medium;
                
                _objCust.Update();
                DataView dv1 = new DataView(BindGvCustDetail().Table);
                Session["data"] = dv1;
                grdCustDetails.DataSource = dv1;
                grdCustDetails.DataBind();

                MessageBox("Record updated successfully");
                TxtCustCode.Enabled = true;
                if (btnSave.Text.ToLower() == "update")
                {
                    PnlDetails.Visible = true;
                    PnlAdd.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;

                }
                else
                {
                    PnlDetails.Visible = false;
                    PnlAdd.Visible = true;
                    btnSave.Visible = true;

                }

            }
            TxtCustCode.Text = "";
            TxtShortForm.Text = "";
            TxtFamilyCode.Text = "";
            TxtAddress.Text = "";
            TxtZip.Text = "";
            TxtPhone1.Text = "";
            TxtPhone2.Text = "";
            TxtEmailID.Text = "";
            TxtCustName.Text = "";
            TxtCreditLimit.Text = "";
            TxtPrincipalName.Text = "";
            TxtPrincipalMobile.Text = "";
            TxtPrincipalDOB.Text = "";
            TxtKeyPersonName.Text = "";
            TxtKeyPersonMobile.Text = "";
            TxtKeyPersonDOB.Text = "";
            TxtAdditinalDis.Text = "";
            TxtVIPRemark.Text = "";
            TxtMedium.Text = "";
            TxtCustomerType.Text = "";
            DDLzone.SelectedValue = "0";
            DDLareazone.SelectedValue = "0";
            DDLarea.SelectedValue = "0";
            ddLStates.SelectedValue = "0";
            DDLsuperzone.SelectedValue = "0";
            DdlCustRating.SelectedValue = "0";
        }
        catch(SqlException ex)
        {
            Response.Write(ex.Message.ToString());
        }
        catch (Exception ex1)
        {
            Response.Write(ex1.Message.ToString());
        }





    }

    #endregion

    #region  Button Event
    protected void btncancel_Click(object sender, EventArgs e)
    {
        PnlAdd.Visible = false;
        PnlDetails.Visible = true;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        LblCustId.Text = "0";
        PnlDetails.Visible = false;
        PnlAdd.Visible = true;
    }

    #endregion
   

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

  
    #region Binddata method

    public DataView BindGvCustDetail()
    {
        DataTable dt = new DataTable();
        dt = Customer_cs.Get_CustList();
        DataView dv = new DataView(dt);
        return dv;
    }


    #endregion
 
    
    #region Gridview Events
   
    protected void grdCustDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdCustDetails.PageIndex = e.NewPageIndex;
        grdCustDetails.DataSource = BindGvCustDetail();
        grdCustDetails.DataBind();
    }

    protected void grdCustDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        PnlDetails.Visible = false;
        PnlAdd.Visible = true;
        grdCustDetails.Visible = true;
        PnlDetails.Visible = true;

        LblCustId.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblCustID")).Text;

        TxtCustCode.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblCustCode")).Text;
        TxtShortForm.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblShortForm")).Text;
        TxtFamilyCode.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblFamilyCode")).Text;
        TxtAddress.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblAddress")).Text;
        //TxtCity.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblCity ")).Text;
        TxtZip.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblZip")).Text;
        TxtPhone1.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblPhone1")).Text;
        TxtPhone2.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblPhone2")).Text;
        TxtEmailID.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblEmailID")).Text;
        TxtCustName.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblCustName")).Text;
        TxtCreditLimit.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblCreditLimit")).Text;
        TxtPrincipalName.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblPrincipalName")).Text;
        TxtPrincipalMobile.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblPrincipalMobile")).Text;
        TxtPrincipalDOB.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblPrincipalDOB")).Text;
        TxtKeyPersonName.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblKeyPersonName")).Text;
        TxtKeyPersonMobile.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblKeyPersonMobile")).Text;
        TxtKeyPersonDOB.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblKeyPersonDOB")).Text;
        TxtAdditinalDis.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblAdditinalDis")).Text;
        TxtVIPRemark.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblVIPRemark")).Text;
        //lblcreditdays
        txtcreditdays.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("lblcreditdays")).Text;
        TxtMedium.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblMedium")).Text;
        //TxtBookTypeDetaildis.Text = ((Label)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("LblBookTypeDetaildis")).Text;
        ChkIsActive.Checked = ((CheckBox)grdCustDetails.Rows[e.NewSelectedIndex].FindControl("chkisActive")).Checked;

    }

    

    #endregion

    #region text changed
    protected void TxtCustomerType_TextChanged(object sender, EventArgs e)
    {
        if (TxtCustomerType.Text == "Other")
        {
            DdlSection.Enabled = false;
        }
        else
        {
            DdlSection.Enabled = true;
        }
    }
    protected void TxtCustCode_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("Customer", TxtCustCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Customer Code already exist");
            TxtCustCode.Text = "";
            TxtCustCode.Focus();
        }
        else
        {
            TxtCustName.Focus();
        }
    }
    #endregion

    #region Selected Index Changed
    public void getDDLdata()
    {
        DDLzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLsuperzone.SelectedValue.ToString()), "Zone");
        DDLzone.DataBind();
        DDLzone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        DDLzone.Enabled = true;
        DDLzone.Focus();
    }
    public void getDDLarezo()
    {
        DDLareazone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLzone.SelectedValue.ToString()), "AreaZone");
        DDLareazone.DataBind();
        DDLareazone.Items.Insert(0, new ListItem("--Select AreaZone--", "0"));
        DDLareazone.Enabled = true;
        DDLareazone.Focus();
    }
    public void getDDLarea()
    {
        DDLarea.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLareazone.SelectedValue.ToString()), "Area");
        DDLarea.DataBind();
        DDLarea.Items.Insert(0, new ListItem("--Select Area--", "0"));
        DDLarea.Enabled = true;
        DDLarea.Focus();
    }
    protected void DDLsuperzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDDLdata();
    }

    protected void DDLzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDDLarezo();
    }
    protected void DDLareazone_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDDLarea();
    }

  

    protected void ddLStates_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddLStates.SelectedValue != "0")
        {
            ddlCity.DataSource = Destination.GetDestination(Convert.ToString(ddLStates.SelectedValue));
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            if (ddlCity.Items.Count > 0)
            {
                ddlCity.Focus();
            }
            else
            {
                ddLStates.Focus();
            }
        }
        else
        {
            ddlCity.DataBind();
            ddlCity.Focus();
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
    }
    protected void DDLarea_SelectedIndexChanged(object sender, EventArgs e)
    {
        TxtCreditLimit.Focus();
    }

    public void custRating()
    {
        DataView dv1 = new DataView(Masterofmaster.Get_MasterOfMaster_ByGroup("CustRating").Tables[0]);
        DdlCustRating.DataSource = dv1;
        DdlCustRating.DataBind();
        DdlCustRating.Items.Insert(0, new ListItem("--Select Rating--", "0"));
    }

    #endregion

    #region SetView

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                LblCustId.Text = "0";
                PnlAdd.Visible = true;
                PnlDetails.Visible = false;
                btnSave.Visible = true;
                filter.Visible = false;
                repAlfabets.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    PnlDetails.Visible = true;
                    PnlAdd.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                   

                }
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
            dv.RowFilter = "CustName like '" + val + "%'";
            grdCustDetails.DataSource = dv;
            grdCustDetails.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
        
    }


}


