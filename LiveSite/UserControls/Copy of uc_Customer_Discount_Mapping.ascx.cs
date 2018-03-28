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
using System.Web.Services;

public partial class UserControls_uc_Customer_Discount_Mapping : System.Web.UI.UserControl
{
    #region Variable

    string CustCode;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindBooktype();
            pnlCust.Visible = true;
            PnlCustDiscDetails.Visible = false;
           // pnlDisountDetails.Visible = false;
            btn_Save.Visible = false;
            // btnadd.Visible = true;
            // btnview.Visible = true;
            lblID.Text = "0";
            //DDlAdiscount.DataSource = booktype_Custmer_discount_Mapping.Get_AddDiscount_On_Cusomer(CustCode);
            //DDlAdiscount.DataBind();
            //DDlAdiscount.Items.Insert(0, new ListItem("-Select Discount-", "0"));
            //Session["Bookdata"] = null;
            txtcustomer.Focus();
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

            GrdViewCustDisDetails.DataSource = booktype_Custmer_discount_Mapping.Get_CustomerDiscountBy_BookType(txtcustomer.Text.ToString());
            GrdViewCustDisDetails.DataBind();
            // ds.Tables[0].Rows[0][0]
            btn_Save.Visible = true;
            
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
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in GrdViewCustDisDetails.Rows)
            {
                
                booktype_Custmer_discount_Mapping _objCustDiscount = new booktype_Custmer_discount_Mapping();
               
                if (lblID.Text == "0")
                {
                    _objCustDiscount.Custcode = Convert.ToString(txtcustomer.Text.Trim());
                }
                else
                {
                    _objCustDiscount.Custcode = Convert.ToString(txtcustomer.Text.Trim());
                }
                _objCustDiscount.BKTYPCustDisID = Convert.ToInt32(((Label)row.FindControl("lblBKTYPCustDisID")).Text.Trim());
                _objCustDiscount.BookType = Convert.ToInt32(((Label)row.FindControl("lblBookTypeCode")).Text.Trim());
                _objCustDiscount.Discount = Convert.ToDecimal(((TextBox)row.FindControl("lblDiscount")).Text.Trim());
                _objCustDiscount.AdditionalDiscount = Convert.ToDecimal(((Label)row.FindControl("lblAdDiscount")).Text.Trim());
                _objCustDiscount.IsActive = ((CheckBox)row.FindControl("chkisActive")).Checked;
                _objCustDiscount.Save();
               
                //lblID.Text = "0";
                //DDlBooktype.Text = "";
                //txtdiscount.Text = "";
                // pnlDisountDetails.Visible = true;
                //PnlCustDiscDetails.Visible = false;
            }

            MessageBox("Record saved successfully");

        }
        catch
        {

        }
    }

    public void BindBooktype()
    {
        string grp = "BookType";
        DDlBooktype.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
        DDlBooktype.DataBind();
        DDlBooktype.Items.Insert(0, new ListItem("-Select book set-", "0"));
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion
    //protected void btnadd_Click(object sender, EventArgs e)
    //{
    //    PnlCustDiscDetails.Visible = true;
    //    pnlDisountDetails.Visible = false;
    //    btn_Save.Visible = true;
    //    btnview.Visible = true;
    //}
    //protected void btnview_Click(object sender, EventArgs e)
    //{
    //    pnlDisountDetails.Visible = true;
    //    PnlCustDiscDetails.Visible = false;
    //    btnadd.Visible = true;
    //    GrdViewCustDisDetails.DataSource = booktype_Custmer_discount_Mapping.Get_CustomerDiscountBy_BookType(txtcustomer.Text.ToString());
    //    GrdViewCustDisDetails.DataBind();
    //}
    protected void GrdViewCustDisDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // PnlViewDiscountDetails.Visible = false;
        // PnlCustDiscountMapping.Visible = true;
        btn_Save.Visible = true;
        PnlCustDiscDetails.Visible = true;
        //pnlDisountDetails.Visible = false;
        //EmpCode = Convert.ToString(Session["UserName"]);
        lblID.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblBKTYPCustDisID")).Text.Trim();
        // lblCustIdGrd.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("LblCustId")).Text.Trim();
        lblCustName.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblCustName")).Text.Trim();
        BindBooktype();
        DDlBooktype.SelectedValue = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblBookTypeCode")).Text;
        txtdiscount.Text = ((TextBox)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblDiscount")).Text;
        txtAdiscount.Text = ((Label)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("lblAdDiscount")).Text;

        txtcustomer.Text = txtcustomer.Text.ToString(); ;
        ChkActive.Checked = ((CheckBox)GrdViewCustDisDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
    }
}
