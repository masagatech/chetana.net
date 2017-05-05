using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Idv.Chetana.BAL;
using Idv.Chetana.CnF;
using System.Data;
using System.Collections;

public partial class CNF_UserControl_uc_AddCnF : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            grdCnFDetails.DataSource = BindCnFGrid("All", 0).Tables[0];
            grdCnFDetails.DataBind();
            GetSuperZone();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        CnFCustomer objcnf = new CnFCustomer();
        objcnf.CnFID = Convert.ToInt32(lblID.Text.ToString());
        objcnf.CnFCode = TxtCnFCode.Text.Trim();
        objcnf.CnFName = TxtCnFName.Text.Trim();
        objcnf.Address = TxtAddress.Text.Trim();
        objcnf.ContactPerson = Txtcp.Text.Trim();
        objcnf.EmailID = txtEmail.Text.Trim();
        objcnf.Mobile = txtmobile.Text.Trim();
        objcnf.SuperZoneId = FindCheckListBox(); 
        objcnf.IsActive = true;
        objcnf.CreatedBy = Session["UserName"].ToString();
        
        objcnf.Save();
        MessageBox("Record saved successfully");

        grdCnFDetails.DataSource = BindCnFGrid("All", 0).Tables[0];
        grdCnFDetails.DataBind();
    }

 #region MsgBox

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    public string FindCheckListBox()
    {
        string strid;
        strid = "";
        foreach (ListItem lstItem in DDLsuperzone.Items)
        {
            if (lstItem.Selected == true)
            {
                // Add text to label.
                strid += lstItem.Value +"," ;
            }
        }
        return strid.TrimEnd(',');
    }
    protected void DDLsuperzone_SelectedIndexChanged(object sender, EventArgs e)
    {
       //...... getDDLdata();
    }
    public void GetSuperZone()
    {
        DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
        DDLsuperzone.DataBind();
     //   DDLsuperzone.Items.Insert(0, new ListItem("--Select SuperZone--", "0"));
    }

    public DataSet BindCnFGrid(string Flag , int Id)
    {
        DataSet ds = new DataSet(); 
        CnFCustomer objcs = new CnFCustomer();
        objcs.Remark1 = Flag;
        objcs.CnFID = Id;
        ds = objcs.GetCnF_Master();
       return ds;
        //grdCnFDetails.DataSource = ds.Tables[0];
        //grdCnFDetails.DataBind();
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add CnF";
                lblID.Text = "0";
                pnlCnFDetails.Visible = false;
                TxtCnFCode.Focus();
                PnlAdd.Visible = true;
                btnSave.Visible = true;
                
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit CnF ";
                    pnlCnFDetails.Visible = true;
                    PnlAdd.Visible = false;
                    btnSave.Visible = false;
                  
            
                  
                }
        }
    }

    #region Gridview Methods
    
    protected void grdCnFDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlCnFDetails.Visible = false;
        PnlAdd.Visible = true;
        btnSave.Visible = true;
        
        btnSave.Text = "Update";
        TxtCnFCode.Enabled = false;
        try
        {
            lblID.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblCnFID")).Text;
            TxtCnFCode.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblCnFCode")).Text;
            TxtCnFName.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblCnFname")).Text;

            txtmobile.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblmobile")).Text;
            txtEmail.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblemail")).Text;
            Txtcp.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lplcperson")).Text;
            TxtAddress.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lbladdress")).Text;
            //Ch.ekacv.Checked = ((CheckBox)grdCnFDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
            
            //DataTable dt = new DataTable();
            //dt = BindCnFGrid("chkSuperZone", Convert.ToInt32(lblID.Text)).Tables[0];
            //foreach (ListItem item in )
            //{
            //    if (item.Selected)
            //    {
            //        student.FavoriteSubjects.Add(item.Text);
            //    }
            //}

            ArrayList _al = new ArrayList();
            string[] values = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblSZoneId")).Text.Split(new char[] { ',' });
            
            foreach (ListItem item in DDLsuperzone.Items)
            {
                item.Selected = values.Contains(item.Value);
            }

            //DDLsuperzone.SelectedItem.Text = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblSZName")).Text;
            //DDLsuperzone.SelectedValue = ((Label)grdCnFDetails.Rows[e.NewEditIndex].FindControl("lblSZoneId")).Text;
        }
        catch
        {
        }
    }

    protected void grdCnFDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //SuperZone _objSZM = new SuperZone();
        //_objSZM.SuperZoneID = Convert.ToInt32(((Label)grdSuperZoneDetails.Rows[e.RowIndex].FindControl("lblSZID")).Text);
        //_objSZM.SuperZoneCode = ((Label)grdSuperZoneDetails.Rows[e.RowIndex].FindControl("lblSZCode")).Text;
        //_objSZM.SuperZoneName = ((Label)grdSuperZoneDetails.Rows[e.RowIndex].FindControl("lblSZName")).Text;

        //_objSZM.IsActive = Convert.ToBoolean(false);
        //_objSZM.IsDeleted = Convert.ToBoolean(true);
        //try
        //{
        //    _objSZM.Save();
        //    MessageBox("Your record is Deleted");
        //    grdSuperZoneDetails.DataSource = BindGvSuperZoneDetail();
        //    grdSuperZoneDetails.DataBind();
        //    pnlSuperZoneDetails.Visible = true;
        //    pnlSuperZone.Visible = false;
        //}
        //catch
        //{
            
        //}
    }
    #endregion
}