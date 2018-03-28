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

public partial class UserControls_ODC_receipt_PettyVoucherPayment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            btnsave.Visible = false;
            gvPayment.Visible = false;
            // GivenFrom
            
        }

    }
    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }



    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    public void Bind()
    {
        string FromVoc = txtFromorec.Text.Trim();
        string ToVoc = txttorec.Text.Trim();
        DataSet ds = new DataSet();
        ds = PettyCashEntry.GetVoucher_Payment(FromVoc, ToVoc);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvPayment.DataSource = ds;
            gvPayment.DataBind();
            gvPayment.Visible = true;
            btnsave.Visible = true;
        }
        else
        {
            message("NO Record Found");
            gvPayment.Visible = false;
            btnsave.Visible = false;
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gv in gvPayment.Rows)
            {
                TextBox txtBankName = (TextBox)gv.FindControl("txtBankName");
                PettyCashEntry petty = new PettyCashEntry();
                petty.EmpId = Convert.ToInt32(((Label)gv.FindControl("lblEmpId")).Text);
                //petty.UpdatedBy = Session["UserUpdate"].ToString();
                petty.VoucherNo = ((Label)gv.FindControl("lblVoucherNo")).Text;
                petty.PaymentRemar = ((TextBox)gv.FindControl("txtRemark")).Text;
                string BankCode1 = txtBankName.Text.ToString().Split(':')[0].Trim();
                ////modification////////
                DataTable dt = new DataTable();
                dt = DCMaster.Get_Name(BankCode1, "Bank").Tables[0];
                if (dt.Rows.Count != 0)
                {
                    petty.BankCode = BankCode1;
                    petty.ChequeNo = ((TextBox)gv.FindControl("txtCheque")).Text;
                   
                }
                else
                {
                    
                    txtBankName.Text = string.Empty;
                }
                //////end//////
                if ((((TextBox)gv.FindControl("txtPaymentDate")).Text) == "")
                {
                    petty.PaidAmount = Convert.ToDecimal("0");
                    petty.IsPaid = Convert.ToBoolean(false);
                }

                else
                {

                    string strVoucherdate = ((TextBox)gv.FindControl("lblVoucherdate")).Text;
                    string[] strVoucherdateArray = strVoucherdate.Split('/');
                    strVoucherdate = strVoucherdateArray[1].ToString() + '/' + strVoucherdateArray[0].ToString() + '/' + strVoucherdateArray[2].ToString();

                    string strPaymentdate = ((TextBox)gv.FindControl("txtPaymentDate")).Text;
                    string[] strPaymentdateArray = strPaymentdate.Split('/');
                    strPaymentdate = strPaymentdateArray[1].ToString() + '/'
                        + strPaymentdateArray[0].ToString() + '/' + strPaymentdateArray[2].ToString();
                    DateTime Voucherdate = Convert.ToDateTime(strVoucherdate);
                    DateTime Paymentdate = Convert.ToDateTime(strPaymentdate);
                    if (Voucherdate <= Paymentdate)
                    {

                        petty.IsPaid = Convert.ToBoolean(true);
                        petty.PaidAmount = Convert.ToDecimal(((TextBox)gv.FindControl("txtPaidAmount")).Text);
                        petty.PaymentDate = ((TextBox)gv.FindControl("txtPaymentDate")).Text;
                       // petty.GivenFrom = ((DropDownList)gv.FindControl("ddlGivenFrom")).SelectedItem.Text;
                        string ddlSelsct = ((DropDownList)gv.FindControl("ddlGivenFrom")).SelectedItem.Text;
                        if (ddlSelsct.ToLower()== "select")
                        {

                        }
                        else
                        {
                            petty.GivenFrom = ((DropDownList)gv.FindControl("ddlGivenFrom")).SelectedItem.Text;
                            petty.update();
                            Bind();
                            message("Record Saved Successfully");
                            
                            
                        }
                        
                    }
                    else
                    {
                        message("Payment Date should greater than Voucher Date");
                    }
                }

            }
        }
        catch
        {

        }
    }

    protected void txtPaymentDate_TextChanged(object sender, EventArgs e)
    {
        btnsave.Visible = true;

    }
    protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
    {
        // foreach (GridViewRow gv in gvPayment.Rows)
        //{
        //if (lblTotalAmount.text >= txtPaidAmount.text)
        //if ((Convert.ToDecimal((Label)gv.FindControl("lblTotalAmount"))) >= (Convert.ToDecimal((TextBox)gv.FindControl("txtPaidAmount"))))
    }
    //}


    protected void gvPayment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList ddlGivenFrom;// = (DropDownList)sender;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ddlGivenFrom = (DropDownList)e.Row.FindControl("ddlGivenFrom");

            DataView dv = new DataView(Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("GivenFrom", "DropDown").Tables[0]);

            ddlGivenFrom.DataSource = dv;
            ddlGivenFrom.DataBind();
            ddlGivenFrom.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    protected void ddlGivenFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlGivenFrom = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlGivenFrom.NamingContainer;
        TextBox txtBankName = (TextBox)row.FindControl("txtBankName");
        TextBox txtCheque = (TextBox)row.FindControl("txtCheque");
        if (ddlGivenFrom.SelectedItem.Text.ToLower() == "bank")
        {
            txtBankName.Enabled = true;
            txtCheque.Enabled = true;
        }
        else
        {
            txtBankName.Enabled = false;
            txtCheque.Enabled = false;
            txtBankName.Text = "Bank Name";
        }

    }
    protected void btnGetVoc_Click(object sender, EventArgs e)
    {
        Bind();
    }
}