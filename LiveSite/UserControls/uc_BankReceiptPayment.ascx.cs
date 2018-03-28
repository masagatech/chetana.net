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

public partial class UserControls_uc_BankReceiptPayment : System.Web.UI.UserControl
{
    # region Variables
    int DocNo;
    #endregion

    # region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
            BindBankRPDetail();
            DDLCCDD.Items.Insert(0, new ListItem("-Select-", "0"));

            TxtDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }  
    }
    #endregion
    protected void TxtAccBkCode_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TxtCustCode_TextChanged(object sender, EventArgs e)
    {
        string CustCode = TxtCustCode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            TxtCustCode.Text = CustCode;
            LblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            TxtPnI.Focus();
            //Bind_DDL_Transport();
        }
        else
        {
            LblCustName.Text = "No such Customer code";
            TxtCustCode.Focus();
            TxtCustCode.Text = "";
        }
    }
    protected void TxtPnI_TextChanged(object sender, EventArgs e)
    {
        string PICode = TxtPnI.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = Employee.Get_EmployeeName(PICode).Tables[0];
        if (dt.Rows.Count != 0)
        {
            TxtPnI.Text = PICode;
            LblPnIName.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            TxtSMReceipt.Focus();
        }

        else
        {
            LblPnIName.Text = "No such salesman code";
            TxtPnI.Focus();
            TxtPnI.Text = "";
        }
    }

    protected void TxtSMReceipt_TextChanged(object sender, EventArgs e)
    {

    } 

    # region Events

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string DocumentDate = TxtDt.Text.Split('/')[1] + "/" + TxtDt.Text.Split('/')[0] + "/" + TxtDt.Text.Split('/')[2];
        BankReceiptPaymentMaster objBrpm = new BankReceiptPaymentMaster();
        if (LblBankRPID.Text == "0")
        {
            if (TxtDocNo.Text != "")
            {
                objBrpm.AccDocumentNo = Convert.ToInt32(TxtDocNo.Text);
            }
            else
            {
                objBrpm.AccDocumentNo = 0;
            }
            objBrpm.AccDocumentDate = Convert.ToDateTime(DocumentDate);
            objBrpm.IsActive = true;
            objBrpm.IsDeleted = false;

            objBrpm.Save(out DocNo);
            TxtDocNo.Text = Convert.ToString(DocNo);
            SaveBankReceiptPaymentDetails(DocNo);
            MessageBox("Record saved successfully \\r\\n Documennt no.  " + TxtDocNo.Text);
            loder("Last saved Document no. : " + TxtDocNo.Text);
            BindBankRPDetail();
        }
        else
        {
            UpdateBankReceiptPaymentDetails();
            MessageBox("Record updated successfully \\r\\n Documennt no.  " + TxtDocNo.Text);
            BindBankRPDetail();
        }
        try
        {
            TxtAccBkCode.Text = "";
            TxtDocNo.Text = "";
            TxtSerialNo.Text = "";
            TxtCustCode.Text = "";
            TxtPnI.Text = "";
            TxtSMReceipt.Text = "";

            DDLCCDD.SelectedValue = null;
            TxtCCDDNo.Text = "";
            TxtType.Text = "";
            TxtAmt.Text = "";
            TxtDrawnon.Text = "";
            TxtNar.Text = "";
            ChekActive.Checked = false;

            PnlAddBankRP.Visible = true;
            PnlBankRPDetails.Visible = false;
        }
        catch
        {

        }
    }
    #endregion


    protected void GrdBankRPDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GrdBankRPDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlBankRPDetails.Visible = false;
        PnlAddBankRP.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";
        TxtAccBkCode.Enabled = false;
        TxtDocNo.Enabled = false;
        TxtSerialNo.Enabled = false;

        try
        {
            LblBankRPID.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblBankRPID")).Text;
            TxtAccBkCode.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblAccBookID")).Text;
            TxtDocNo.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblAccDocNo")).Text;
            // TxtDt.Text              = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblAccDocDt")).Text;
            TxtSerialNo.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblAccSNo")).Text;
            TxtCustCode.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblCustID")).Text;
            TxtPnI.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblPnI")).Text;
            TxtSMReceipt.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblSMReceipt")).Text;
            TxtCCDDNo.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblCCDDNo")).Text;
            TxtType.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblType")).Text;
            TxtAmt.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblAmt")).Text;
            TxtDrawnon.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblDrawnon")).Text;

            DDLCCDD.SelectedValue = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblCCDD")).Text;

            //TxtCCDDNo.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblDDCCDDNo")).Text;
            TxtNar.Text = ((Label)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("lblNar")).Text;
            ChekActive.Checked = ((CheckBox)GrdBankRPDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        }

        catch
        {
        }
    }

    #endregion 

    # region Methods

    #region Binddata Method
    public void BindBankRPDetail()
    {
        GrdBankRPDetails.DataSource = BankReceiptPayment.GetBankReceiptPayment();
        GrdBankRPDetails.DataBind();
    }
    #endregion  

    #region SetView
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                LblBankRPID.Text = "0";
                PnlBankRPDetails.Visible = false;
                PnlAddBankRP.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    PnlBankRPDetails.Visible = true;
                    PnlAddBankRP.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                }
        }
    }
    #endregion

    public void SaveBankReceiptPaymentDetails(int DocNo)
    {
        BankReceiptPayment objBrp = new BankReceiptPayment();

        objBrp.Bank_RecPayID = Convert.ToInt32(LblBankRPID.Text);
        objBrp.AccBookID = Convert.ToInt32(TxtAccBkCode.Text.Trim());
        objBrp.AccDocumentNo = DocNo;
        // objBrp.AccDocSerialNo = Convert.ToInt32(TxtSerialNo.Text.Trim());
        objBrp.CustomerCode = TxtCustCode.Text.Trim();
        objBrp.SalesmanCode = TxtPnI.Text.Trim();
        objBrp.SalesmanReceipt = TxtSMReceipt.Text.Trim();

        objBrp.Cash_Cheque_DD = DDLCCDD.SelectedItem.Text;
        //objcmpy.CityID = Convert.ToInt32(DDLCity.SelectedValue.ToString());
        objBrp.Cheque_DDNo = TxtCCDDNo.Text.Trim();
        objBrp.Type = TxtType.Text.Trim();
        objBrp.Amount = Convert.ToDecimal(TxtAmt.Text.Trim());
        objBrp.DrawnOn = TxtDrawnon.Text.Trim();
        objBrp.NarrationID = Convert.ToInt32(TxtNar.Text.Trim());
        objBrp.IsActive = ChekActive.Checked;
        objBrp.Save();

        //if (TxtAccBkCode.Text != "")
        //{
        //}
        MessageBox("Record saved successfully");
    }

    public void UpdateBankReceiptPaymentDetails()
    {
        BankReceiptPayment objBrp = new BankReceiptPayment();

        objBrp.Bank_RecPayID = Convert.ToInt32(LblBankRPID.Text);
        objBrp.AccBookID = Convert.ToInt32(TxtAccBkCode.Text.Trim());
        objBrp.AccDocumentNo = Convert.ToInt32(TxtDocNo.Text);
        // objBrp.AccDocSerialNo = Convert.ToInt32(TxtSerialNo.Text.Trim());
        objBrp.CustomerCode = TxtCustCode.Text.Trim();
        objBrp.SalesmanCode = TxtPnI.Text.Trim();
        objBrp.SalesmanReceipt = TxtSMReceipt.Text.Trim();

        objBrp.Cash_Cheque_DD = DDLCCDD.SelectedItem.Text;
        //objcmpy.CityID = Convert.ToInt32(DDLCity.SelectedValue.ToString());
        objBrp.Cheque_DDNo = TxtCCDDNo.Text.Trim();
        objBrp.Type = TxtType.Text.Trim();
        objBrp.Amount = Convert.ToDecimal(TxtAmt.Text.Trim());
        objBrp.DrawnOn = TxtDrawnon.Text.Trim();
        objBrp.NarrationID = Convert.ToInt32(TxtNar.Text.Trim());
        objBrp.IsActive = ChekActive.Checked;
        objBrp.Save();

        //if (TxtAccBkCode.Text != "")
        //{
        //}
        MessageBox("Record updated successfully");
    }
    #endregion 

    #region MessageBox
    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
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

}
