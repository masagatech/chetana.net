using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Idv.Chetana.BAL;

public partial class UserControls_uc_Customer_Discount_Transport_Mapping : System.Web.UI.UserControl
{
    #region Variable
    string CustCode;
    #endregion

    #region Form Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindBooktype();
            BindDDlTransport();
            DDlTransport.SelectedIndex = 0;
            pnlCust.Visible = true;
            PnlCustDiscDetails.Visible = false;
            btn_Save.Visible = false;
            lblID.Text = "0";
            txtcustomer.Focus();
        }
    }
    #endregion

    #region Customer Book Type Mapping
    public void BindBooktype()
    {
        string grp = "BookType";
        DDlBooktype.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
        DDlBooktype.DataBind();
        DDlBooktype.Items.Insert(0, new ListItem("-Select book set-", "0"));
    }

    protected void GrdViewCustDisDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        btn_Save.Visible = true;
        PnlCustDiscDetails.Visible = true;
        lblID.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblBKTYPCustDisID")).Text.Trim();
        lblCustName.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblCustName")).Text.Trim();
        BindBooktype();
        DDlBooktype.SelectedValue = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblBookTypeCode")).Text;
        txtdiscount.Text = ((TextBox)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblDiscount")).Text;
        txtAdiscount.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblAdDiscount")).Text;
        txtcustomer.Text = txtcustomer.Text.ToString(); ;
        ChkActive.Checked = ((CheckBox)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
    }
    #endregion
    
    #region Customer Transport Details

    // Bind Dropdown : Transport Details.
    public void BindDDlTransport()
    {
        string grp = "Transport";
        DDlTransport.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
        DDlTransport.DataBind();
        DDlTransport.Items.Insert(0, new ListItem("-Select Transporter-", "none"));
    }

    // Save the Customer transport Details.
    void CustomerTransportSave()
    {
        try
        {
            CustomerToTransport _objCST = new CustomerToTransport();
            _objCST.CustTransportID = 0;
            _objCST.CustCode = txtcustomer.Text.Trim();
            _objCST.TransportID = Convert.ToInt32(DDlTransport.SelectedItem.Value.ToString());
            _objCST.IsActive = true;
            _objCST.Save();
            txtcustomer.Text = "";
            DDlTransport.SelectedValue = null;
            lblCustName.Text = "";
        }
        catch
        {
        }
    }

    // Bindig Grid With Customer Transport Details.
    public DataTable BindgrdTransportDetails()
    {
        DataTable dt = CustomerToTransport.GetCustomerandTransporter1();
        return dt;
    }

    #endregion

    #region Common Method / Events

    void ClearControls()
    {
        foreach (GridViewRow row in GrdViewCustDisDetails.Rows)
        { 
            ((TextBox)row.FindControl("lblDiscount")).Text = "0.00";
        }

        //DDlTransport.SelectedValue = null;
        DDlTransport.SelectedIndex = 0;

        grdget.DataSource = null;
        grdget.Visible = false;
        txtcustomer.Text = "";
        lblCustName.Text = "";

        UpanelGrd.Update();
        UpdatePanel5.Update();
        uptdetail.Update();
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in GrdViewCustDisDetails.Rows)
            {

                booktype_Custmer_discount_Mapping _objCustDiscount = new booktype_Custmer_discount_Mapping();

                if (lblID.Text == "0")
                {
                    _objCustDiscount.Custcode = Convert.ToString(txtcustomer.Text.Trim() + "!"+Session["FY"].ToString());
                }
                else
                {
                    _objCustDiscount.Custcode = Convert.ToString(txtcustomer.Text.Trim() + "!" + Session["FY"].ToString());
                }
                _objCustDiscount.BKTYPCustDisID = Convert.ToInt32(((Label)row.FindControl("lblBKTYPCustDisID")).Text.Trim());
                _objCustDiscount.BookType = Convert.ToInt32(((Label)row.FindControl("lblBookTypeCode")).Text.Trim());
                _objCustDiscount.Discount = Convert.ToDecimal(((TextBox)row.FindControl("lblDiscount")).Text.Trim());
                _objCustDiscount.AdditionalDiscount = Convert.ToDecimal(((Label)row.FindControl("lblAdDiscount")).Text.Trim());
                _objCustDiscount.IsActive = ((CheckBox)row.FindControl("chkisActive")).Checked;
                _objCustDiscount.Save();
            }

            if(DDlTransport.SelectedValue.ToString()!="")
                CustomerTransportSave();

            ClearControls();
            UpanelGrd.Update();
            MessageBox("Record saved successfully");

        }
        catch
        {

        }
    }

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            DataSet ds = booktype_Custmer_discount_Mapping.Get_AddDiscount_On_Cusomer(CustCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAdiscount.Text = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
            }
            //  pnlDisountDetails.Visible = true;

            GrdViewCustDisDetails.DataSource = booktype_Custmer_discount_Mapping.Get_CustomerDiscountBy_BookType(txtcustomer.Text.ToString() + "!" + Session["FY"].ToString());
            GrdViewCustDisDetails.DataBind();
            
            BindgrdTransportDetails();
            // ds.Tables[0].Rows[0][0]
            btn_Save.Visible = true;

            DataSet dsTransport = new DataSet();
            dsTransport = Idv.Chetana.BAL.CustomerToTransport.Get_CustomerandTransporterValueAD(CustCode);
            if (dsTransport.Tables[0].Rows.Count != 0)
            {
                pnlGet_TransDetails.Visible = true;
                grdget.DataSource = dsTransport.Tables[0];
                grdget.DataBind();
                grdget.Visible = true;
            }
            else
            {
                grdget.Visible = false;
                //  MessageBox("No Such Record Found");
            }

            UpanelGrd.Update();
            upSAve.Update();
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    #endregion

    

}
