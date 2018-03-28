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
public partial class UserControls_uc_LoanPartyMaster : System.Web.UI.UserControl
{
    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            BindGvLoanParty();
            BindState();
        }
    }
    #endregion

    #region Methods

    #region BindMethods
    public void BindGvLoanParty()
    {
        GrdLoanParty.DataSource = LoanPartyMaster.GetLoanPartyMaster();
        GrdLoanParty.DataBind();
    }

    public void BindState()
    {
        DDLState.DataSource = Destination.GetDestination("adminstate");
        DDLState.DataBind();
        DDLState.Items.Insert(0, new ListItem("-Select State-", "0"));
    }

    public void BindCity_State()
    {
        DDLCity.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLState.SelectedValue.ToString()), "ListCity");
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("All", "0"));
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
                LblPartyID.Text = "0";
                PnlLoanPartyDetails.Visible = false;
                PnlAddLoanParty.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    PnlLoanPartyDetails.Visible = true;
                    PnlAddLoanParty.Visible = false;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Irt = TxtIRate.Text;
        LoanPartyMaster objLP = new LoanPartyMaster();

        objLP.PartyID = Convert.ToInt32(LblPartyID.Text);
        objLP.PartyCode = TxtPartyCode.Text.Trim();
        objLP.PartyName = TxtPartyName.Text.Trim();
        objLP.Address = TxtAddress.Text.Trim();
        objLP.Zip = TxtZip.Text.Trim();
        objLP.CityID = Convert.ToInt32(DDLCity.SelectedValue.ToString());
        objLP.Phone1 = TxtPhone1.Text.Trim();
        objLP.Phone2 = TxtPhone2.Text.Trim();
        objLP.LoanReceivedGiven = RdRG.Text.Trim();
        objLP.EmailID = TxtEmailID.Text.Trim();
        objLP.InterestRate = Convert.ToInt32(Irt);
        objLP.CreditLimit = Convert.ToDecimal(TxtCreditLimit.Text.Trim());
        objLP.CreditDays = TxtCreditDays.Text.Trim();
        objLP.IsActive = ChekActive.Checked;

        if (LblPartyID.Text == "0")
        {
            objLP.Save();
            MessageBox("Record saved successfully");
            BindGvLoanParty();
            PnlAddLoanParty.Visible = true;
            PnlLoanPartyDetails.Visible = false;
        }
        else
            if (LblPartyID.Text != "0" || LblPartyID.Text != "")
            {
                objLP.Save();
                MessageBox("Record updated successfully");
                BindGvLoanParty();
                PnlAddLoanParty.Visible = false;
                PnlLoanPartyDetails.Visible = true;
                filter.Visible = false;
            }
        try
        {
            TxtPartyCode.Text = "";
            TxtPartyName.Text = "";
            TxtAddress.Text = "";
            TxtZip.Text = "";
            DDLState.SelectedValue = null;
            DDLCity.Enabled = false;
            TxtPhone1.Text = "";
            TxtPhone2.Text = "";
            RdRG.Text = "";
            TxtEmailID.Text = "";
            TxtIRate.Text = "";
            TxtCreditLimit.Text = "";
            TxtCreditDays.Text = "";
            ChekActive.Checked = false;
        }
        catch
        {

        }
    }
    protected void GrdLoanParty_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlLoanPartyDetails.Visible = false;
        PnlAddLoanParty.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        TxtPartyCode.Enabled = false;

        try
        {
            LblPartyID.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblPartyID")).Text;
            TxtPartyCode.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblPartyCode")).Text;
            TxtIRate.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblIRate")).Text;
            TxtPartyName.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblPartyName")).Text;
            TxtAddress.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblAddress")).Text;
            TxtZip.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblZip")).Text;
            TxtEmailID.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblEmailID")).Text;
            TxtPhone1.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblPhone1")).Text;
            TxtPhone2.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblPhone2")).Text;
            TxtCreditLimit.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblCreditLimit")).Text;
            TxtCreditDays.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblCreditDays")).Text;

            ChekActive.Checked = ((CheckBox)GrdLoanParty.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
            DDLState.SelectedValue = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblStateID")).Text;
            BindState();
            DDLCity.SelectedValue = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblCityID")).Text;
            BindCity_State();

            RdRG.Text = ((Label)GrdLoanParty.Rows[e.NewEditIndex].FindControl("lblLoanRG")).Text;           
        }
        catch
        {
        }
    }

    protected void GrdLoanParty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Company objLP1 = new Company();
        objLP1.Flag = "LoanPartyMaster";
        objLP1.ID = Convert.ToInt32(((Label)GrdLoanParty.Rows[e.RowIndex].FindControl("lblPartyID")).Text);

        objLP1.IsActive = Convert.ToBoolean(false);
        objLP1.IsDeleted = Convert.ToBoolean(true);
        try
        {
            objLP1.delete();

            BindGvLoanParty();
            PnlAddLoanParty.Visible = false;
            PnlLoanPartyDetails.Visible = true;
        }
        catch
        {
        }
    }

    protected void DDLState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity_State();
    }
    protected void TxtPartyCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string PartyCode = TxtPartyCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            bool Auth = Masters.GetCodeValidation("Party", PartyCode);
            if (Auth)
            {
                MessageBox("Party Code Already Exist");
                TxtPartyCode.Text = "";
                TxtPartyCode.Focus();
            }
            else
            {
                TxtPartyName.Focus();
            }
        }
        catch
        {

        }
    }
}
