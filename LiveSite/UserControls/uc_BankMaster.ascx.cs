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

public partial class UserControls_uc_BankMaster : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblBankId.Visible = false;
            Panel1.Visible = true;
            BindGvBankDetails();
            DDLstate.DataSource = Customer_cs.Get_DestinationMaster("state");
            DDLstate.DataBind();
            DDLstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            SetView();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Bank _objbank = new Bank();
            _objbank.BankID = Convert.ToInt32(lblBankId.Text);
            _objbank.BankCode = txtbankCode.Text.Trim();
            _objbank.BankName = txtbankName.Text.Trim();
            _objbank.BankDescription = txtbDesc.Text.Trim();
            _objbank.Country = txtcountry.Text.Trim();
            _objbank.State = Convert.ToInt32(DDLstate.SelectedValue);
            _objbank.City = Convert.ToInt32(DDLCity.SelectedValue);
            _objbank.IsActive = chekactive.Checked;
            _objbank.IsDelete = false;
            _objbank.CreatedBy = "Admin";
            _objbank.Save();

            MessageBox("Record saved successfully");
            BindGvBankDetails();
            Panel1.Visible = true;
            pnlBank.Visible = false;
            filter.Visible = false;

            lblBankId.Text = "";
            txtbankCode.Text = "";
            txtbankName.Text = "";
            txtcountry.Text = "";
            txtbDesc.Text = "";
            chekactive.Checked = false;
            DDLCity.SelectedValue = null;
            DDLstate.SelectedValue = null;


        }
        catch
        {

        }
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
   
   

    #region BindData Method

    public void BindGvBankDetails()
    {
        grdBankDetails.DataSource = Bank.Get_BankMaster("*");
        grdBankDetails.DataBind();
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                    pageName.InnerHtml = "Add Bank";
                    lblBankId.Text = "0";
                    Panel1.Visible = true;
                    pnlBank.Visible = false;
                    filter.Visible = false;
                    txtbankCode.Focus();
            }
          else
            if (Request.QueryString["a"] == "v")
           {
                    pageName.InnerHtml = "View / Edit Bank";
                    Panel1.Visible = false;
                    pnlBank.Visible = true;
                    btnsave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
           }
        }

    }
  
    #endregion

    protected void txtbankCode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Bankcode = txtbankCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool auth = Masters.GetCodeValidation("bankcode", Bankcode);
                if (auth)
                {
                    MessageBox("Bank Code is Already Exist");
                    txtbankCode.Text = "";
                    txtbankCode.Focus();
                }
                else
                {
                    txtbankName.Focus();
                }

            }
            catch
            {

            }
        }
    }

    protected void grdBankDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBankDetails.PageIndex = e.NewPageIndex;
        BindGvBankDetails();
    }

    #region Grid event

    protected void grdBankDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            pnlBank.Visible =false;
            Panel1.Visible = true;
            btnsave.Visible = true;
            filter.Visible = false;

            txtbankCode.Text = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblBnkCode")).Text;
            DDLstate.DataSource = Customer_cs.Get_DestinationMaster("state");
            DDLstate.DataBind();
            DDLstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            DDLstate.Enabled = true;
            //
            pnlBank.Visible = false;
            Panel1.Visible = true;
            lblBankId.Text = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblbankID")).Text;
            txtbankName.Text = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblBnkName")).Text;
            txtbDesc.Text = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblbankdecp")).Text;
            txtcountry.Text = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblcountry")).Text;
            DDLCity.SelectedValue = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblcity")).Text;
            DDLstate.SelectedValue = ((Label)grdBankDetails.Rows[e.NewEditIndex].FindControl("lblstate")).Text;
            DDLCity.DataSource = Customer_cs.Get_DestinationMaster(DDLstate.SelectedValue.ToString());
            DDLCity.DataBind();
            DDLCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            DDLCity.Enabled = true;
            chekactive.Checked = ((CheckBox)grdBankDetails.Rows[e.NewEditIndex].FindControl("chkactive")).Checked;

        }
        catch
        {

        }
    }

    protected void grdBankDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Bank _objBANK = new Bank();
        _objBANK.BankID = Convert.ToInt32(((Label)grdBankDetails.Rows[e.RowIndex].FindControl("lblbankID")).Text);
        _objBANK.BankCode = (((Label)grdBankDetails.Rows[e.RowIndex].FindControl("lblBnkCode")).Text);
        _objBANK.BankName = (((Label)grdBankDetails.Rows[e.RowIndex].FindControl("lblBnkName")).Text);
        _objBANK.IsActive = Convert.ToBoolean(false);
        _objBANK.IsDelete = Convert.ToBoolean(true);
        try
        {
            _objBANK.Save();
            BindGvBankDetails();
            Panel1.Visible = false;
            pnlBank.Visible = true;

        }
        catch
        {
        }
    }

    #endregion

    protected void DDLstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLCity.DataSource = Customer_cs.Get_DestinationMaster(DDLstate.SelectedValue.ToString());
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("--Select City--", "0"));
        DDLCity.Enabled = true;
    }

   
}
