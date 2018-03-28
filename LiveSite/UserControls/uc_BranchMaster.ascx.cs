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
using Idv.Chetana.Common;
using Idv.Chetana.BAL;
using OtherNewClass;

public partial class UserControls_uc_BranchMaster : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblBranchId.Visible = false;
            Panel1.Visible = true;

            BindGvBranchDetails();

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
             BranchMaster _objbranch = new BranchMaster();
            _objbranch.BranchID = Convert.ToInt32(lblBranchId.Text);
            _objbranch.BranchCode = txtbranchCode.Text.Trim();
            _objbranch.BranchName = txtbranchName.Text.Trim();
            _objbranch.BranchAddress = txtbranchAddress.Text.Trim();
            //_obranchnk.Country = txtcountry.Text.Trim();
            _objbranch.State = Convert.ToInt32(DDLstate.SelectedValue);
            _objbranch.City = Convert.ToInt32(DDLCity.SelectedValue);
            _objbranch.IsActive = chekactive.Checked;
            _objbranch.IsDelete = false;
            _objbranch.CreatedBy = "Admin";
            _objbranch.Remark1 = "";
            _objbranch.Remark2 = "";
            _objbranch.Remark3 = "";

            //Response.Write(_objbranch.BranchCode + "\n" + _objbranch.BranchName + "\n" + _objbranch.BranchAddress + "\n" + _objbranch.State + "\n" + _objbranch.City + "\n" + _objbranch.IsActive + "\n" + _objbranch.IsDelete + "\n");
            
            
            _objbranch.Save(); 

            MessageBox("Record saved successfully");
            BindGvBranchDetails();
            if (btnsave.Text.ToString() == "Update")
            {
                Panel1.Visible = false;
                pnlBranch.Visible = true;
                filter.Visible = true;
                btnsave.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
                pnlBranch.Visible = false;
                filter.Visible = false;
                btnsave.Visible = true;
               
            }

            lblBranchId.Text = "";
            txtbranchCode.Text = "";
            txtbranchName.Text = "";
            //txtcountry.Text = "";
            txtbranchAddress.Text = "";
            chekactive.Checked = false;
            DDLCity.SelectedValue = null;
            DDLstate.SelectedValue = null;

            //UpdatePanel1.Update();
            //UpdatePanel2.Update();
            //UpdatePanel4.Update();

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

    public void BindGvBranchDetails()
    {
        grdBranchDetails.DataSource = OtherNewClass.BranchMaster.Get_BranchMaster("*");
        grdBranchDetails.DataBind();
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                    pageName.InnerHtml = "Add Branch";
                    lblBranchId.Text = "0";
                    Panel1.Visible = true;
                    pnlBranch.Visible = false;
                    filter.Visible = false;
                    //txtbranchCode.Focus();
                    txtbranchName.Focus();
            }
          else
            if (Request.QueryString["a"] == "v")
           {
                    pageName.InnerHtml = "View / Edit Branch";
                    Panel1.Visible = false;
                    pnlBranch.Visible = true;
                    btnsave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                    BindGvBranchDetails();
           }
        }

    }
  
    #endregion

    protected void txtbranchCode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                //string branchCode = txtbranchCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                //bool auth = Masters.GetCodeValidation("branch", branchCode);
                //if (auth)
                //{
                //    MessageBox("Branch Code is Already Exist");
                //    txtbranchCode.Text = "";
                //    txtbranchCode.Focus();
                //}
                //else
                //{
                //    txtbranchName.Focus();
                //}

            }
            catch
            {

            }
        }
    }

    protected void txtbranchName_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                //Response.Write("coming");
                string branchName = txtbranchName.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
    
                bool auth = Masters.GetCodeValidation("branch", branchName);
                if (auth)
                {
                    MessageBox("Branch Name is Already Exist");
                    txtbranchName.Text = "";
                    txtbranchName.Focus();
                }
                else
                {
                    txtbranchAddress.Focus();
                }

            }
            catch
            {

            }
        }
    }

    protected void grdBranchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBranchDetails.PageIndex = e.NewPageIndex;
        BindGvBranchDetails();
    }

    #region Grid event

    protected void grdBranchDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            pnlBranch.Visible = false;
            Panel1.Visible = true;
            btnsave.Visible = true;
            filter.Visible = false;
           
            txtbranchCode.Text = ((Label)grdBranchDetails.Rows[e.NewEditIndex].FindControl("lblBranchCode")).Text;
            DDLstate.DataSource = Customer_cs.Get_DestinationMaster("state");
            DDLstate.DataBind();
            DDLstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            DDLstate.Enabled = true;

            lblBranchId.Text = ((Label)grdBranchDetails.Rows[e.NewEditIndex].FindControl("lblBranchID")).Text;
            txtbranchName.Text = ((Label)grdBranchDetails.Rows[e.NewEditIndex].FindControl("lblBranchName")).Text;
            txtbranchAddress.Text = ((Label)grdBranchDetails.Rows[e.NewEditIndex].FindControl("lblBranchAddress")).Text;
            chekactive.Checked = ((CheckBox)grdBranchDetails.Rows[e.NewEditIndex].FindControl("chkactive")).Checked;

            DDLCity.SelectedValue = ((Label)grdBranchDetails.Rows[e.NewEditIndex].FindControl("lblcity")).Text;
            DDLstate.SelectedValue = ((Label)grdBranchDetails.Rows[e.NewEditIndex].FindControl("lblstate")).Text;
            DDLCity.DataSource = Customer_cs.Get_DestinationMaster(DDLstate.SelectedValue.ToString());
            DDLCity.DataBind();
            DDLCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            DDLCity.Enabled = true;

            btnsave.Text = "Update";            
        }
        catch
        {

        }
    }

    protected void grdBranchDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BranchMaster _objBranch = new BranchMaster();
        _objBranch.BranchID = Convert.ToInt32(((Label)grdBranchDetails.Rows[e.RowIndex].FindControl("lblBranchID")).Text);
        _objBranch.BranchName = (((Label)grdBranchDetails.Rows[e.RowIndex].FindControl("lblBranchName")).Text);
        _objBranch.BranchAddress = (((Label)grdBranchDetails.Rows[e.RowIndex].FindControl("lblBranchAddress")).Text);
        _objBranch.IsActive = Convert.ToBoolean(false);
        _objBranch.IsDelete = Convert.ToBoolean(true);
        try
        {
            _objBranch.Save();
            BindGvBranchDetails();
            Panel1.Visible = false;
            pnlBranch.Visible = true;

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
        DDLCity.Focus();
    }
   
}
