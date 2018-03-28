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
using Idv.Chetana.Common;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
#endregion

public partial class UserControls_uc_ExpenseHead : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();

        if (!Page.IsPostBack)
        {
            DDLexpensetype.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("ExpenseType", "DropDown");
            DDLexpensetype.DataBind();
            DDLexpensetype.Items.Insert(0, new ListItem("--Select Type--", "0"));
            ddlexpensegroup.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("ExpenseGroup", "DropDown");
            ddlexpensegroup.DataBind();
            ddlexpensegroup.Items.Insert(0, new ListItem("--Select Group--", "0"));
            BindgrdExpense();
            lblID.Text = "0";

        }
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Expense Head";
                lblID.Text = "0";
                txtexpenseCode.Focus();
                pnlExpensedetails.Visible = false;
                pnlExpense.Visible = true;
                btnSave.Visible = true;
                //filter.Visible = false;
               // btnprint.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Expense Head ";
                    pnlExpensedetails.Visible = true;
                    pnlExpense.Visible = false;
                    btnSave.Visible = false;
                    //filter.Visible = true;
                    //filter.Focus();
                    //btnprint.Visible = true;
                }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ExpenseHead _objExpense = new ExpenseHead();
        try
        {
            _objExpense.AutoId = Convert.ToInt32(lblID.Text.Trim());
            _objExpense.ExpenseCode = txtexpenseCode.Text.Trim();
            _objExpense.ExpenseName = txtexpenseName.Text.Trim();
            _objExpense.ExpenseType = Convert.ToInt32(DDLexpensetype.SelectedValue.ToString());
            _objExpense.ExpenseGroup = Convert.ToInt32(ddlexpensegroup.SelectedValue.ToString());
            _objExpense.Type = DDLexpensetype.SelectedItem.Text.ToString();
            _objExpense.Group = ddlexpensegroup.SelectedItem.Text.ToString();
            _objExpense.Description = txtdescription.Text.ToString().Trim();
            _objExpense.IsActive = Chekacv.Checked;
            _objExpense.IsDelete = false;
            _objExpense.CreatedBy = Convert.ToString(Session["UserName"]);
            _objExpense.Save();
            MessageBox("Record Saved Successfully");

            if (btnSave.Text == "Update")
            {
                BindgrdExpense();
                pnlExpensedetails.Visible = true;
                pnlExpense.Visible = false;
                btnSave.Visible = false;
                btnSave.Text = "Save";
                txtexpenseCode.Enabled = true;
               // filter.Visible = true;
               // btnprint.Visible = true;
            }
            else
            {
                txtdescription.Text = "";
                txtexpenseCode.Text = "";
                txtexpenseName.Text = "";
                DDLexpensetype.SelectedValue = "0";
                ddlexpensegroup.SelectedValue = "0";   
            }
        }
        catch { }



    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    public void ClearFields()
    {
        txtdescription.Text = "";
        txtexpenseCode.Text = "";
        txtexpenseName.Text = "";
        DDLexpensetype.SelectedValue = "0";
        ddlexpensegroup.SelectedValue = "0";

    }

    public void BindgrdExpense()
    {
        grdExpense.DataSource = ExpenseHead.GetExpenseHead();
        grdExpense.DataBind();
    }
    // GetExpenseHead


    protected void grdExpense_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlExpensedetails.Visible = false;
        pnlExpense.Visible = true;
        btnSave.Visible = true;
      //  filter.Visible = false;
       // btnprint.Visible = false;
        btnSave.Text = "Update";
        txtexpenseCode.Enabled = false;
        try
        {
            lblID.Text = ((Label)grdExpense.Rows[e.NewEditIndex].FindControl("lblExpenseid")).Text;
            DDLexpensetype.SelectedValue = ((Label)grdExpense.Rows[e.NewEditIndex].FindControl("lblExpensetypeid")).Text;
          //  Bind_DDL_Zone();
            ddlexpensegroup.SelectedValue = ((Label)grdExpense.Rows[e.NewEditIndex].FindControl("lblExpenseGroupid")).Text;
        //    Bind_DDL_AreaZone();
       
            txtexpenseCode.Text = ((Label)grdExpense.Rows[e.NewEditIndex].FindControl("lblExpenseCode")).Text;
            txtexpenseName.Text = ((Label)grdExpense.Rows[e.NewEditIndex].FindControl("lblExpenseName")).Text;
            Chekacv.Checked = ((CheckBox)grdExpense.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        }
        catch
        {
        }
    }


    protected void grdExpense_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ExpenseHead _objExpense = new ExpenseHead();
        
        try
        {
            _objExpense.AutoId = Convert.ToInt32(((Label)grdExpense.Rows[e.RowIndex].FindControl("lblExpenseid")).Text);
            _objExpense.ExpenseCode = ((Label)grdExpense.Rows[e.RowIndex].FindControl("lblExpenseCode")).Text;
            _objExpense.ExpenseName = ((Label)grdExpense.Rows[e.RowIndex].FindControl("lblExpenseName")).Text;
            _objExpense.IsActive = Convert.ToBoolean(false);
            _objExpense.IsDelete = Convert.ToBoolean(true);
            _objExpense.Save();
             BindgrdExpense();
            pnlExpensedetails.Visible = true;
            pnlExpense.Visible = false;
        }
        catch
        {

        }
    }
    protected void txtexpenseCode_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("Expense", txtexpenseCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Expense Code already exist");
            txtexpenseCode.Text = "";
            txtexpenseCode.Focus();
        }
        else
        {
            txtexpenseName.Focus();
        }
    }
}
