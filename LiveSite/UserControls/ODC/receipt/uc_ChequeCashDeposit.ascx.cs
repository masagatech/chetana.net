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


public partial class UserControls_ChequeCashDeposit : System.Web.UI.UserControl
{
    #region Variables
    DateTime Docdate;
    string ChequeDate1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string From;
    string To;
    int IDNo;
    #endregion
   
    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }

        if (!IsPostBack)
        {
            //UpanelGrd.Visible = false;
            getcheque.Visible = false;
           // lblID.Text = "0";
            
            SetView();

           
        }


    }
    #endregion

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                txtEMcode.Focus();
                pnlCust.Visible = true;
           
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pnlCust.Visible = false;
                
                    getcheque.Visible = true;
                    UpanelGrd.Visible = true;
                    pnlshowdetail.Visible = true;
                   
                    btn_Save.Visible = false;
                 
                }
        }
    }
  

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

    public void cloder()
    {
        string jv = "cloder();";
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

    #region Button Events

    protected void btn_Save_Click(object sender, EventArgs e)
    
    {
      
        if (Session["UserName"] != null)
        {
 
            Cheque_CashDetails che = new Cheque_CashDetails();
            if (lblID.Text == "")
            {
                lblID.Text = "0";
                
            }
            che.CQ_ID = Convert.ToInt32(lblID.Text);
            
            che.EmpID = txtEMcode.Text.Trim();
            che.ChequeNo = txtCheck.Text.Trim();
            //string txtChequeDate= Convert.ToDateTime(txtChequeDate.Text.Split('/')[1] + "/" + txtChequeDate.Text.Split('/')[0] + "/" + txtChequeDate.Text.Split('/')[2]);
            if (txtChequeDate.Text == "")
            {
                ChequeDate1 = "";
            }
            else
            {
                 ChequeDate1 = txtChequeDate.Text.Split('/')[1] + "/" + txtChequeDate.Text.Split('/')[0] + "/" + txtChequeDate.Text.Split('/')[2];
            }
            che.ChequeDate = ChequeDate1;
              
     
            che.CustId = txtcustomerid.Text.Trim();
            che.ReciptNo = Convert.ToInt32(txtReciptNo.Text.Trim());
            che.Payee_Bank = txtBankName.Text.Trim();
            //che.Deposited_By = txtDeposit.Text.Trim();

            che.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
            che.CreatedBy = Session["UserName"].ToString();
            che.Description = txtRemark.Text.Trim();
            che.FinancialYear = Convert.ToInt32(strFY);
            if (Cheque.Items[0].Selected)
            {
                pnlCust.Visible = true;

                che.Deposite_Type = Cheque.SelectedValue;
               
            }
            else
            {
                pnlCust.Visible = true;

                che.Deposite_Type = Cheque.SelectedValue;
            }
            if (lblID.Text == "0")
            {
                che.Save(1, out IDNo);
            }
            else
            {
                che.Update();
            }
            
            lblId3.Text = Convert.ToString("CQ ID :" + (IDNo));
            message("Record Saved Successfully");
            if (lblID.Text == "0")
            {
                lblId3.Visible = true;
            }
            else
            {
                lblId3.Visible = false;
            }
            pnlCust.Visible = true;
            lblempname.Text = "";
            txtEMcode.Text = "";
            txtCheck.Text = "";
            txtChequeDate.Text = "";
            txtcustomerid.Text = "";
            txtReciptNo.Text = "";
            //txtDeposit.Text = "";
            txtAmount.Text = "";
            txtBankName.Text = "";
            lblshow.Text = "";
            lblCustName.Text = "";
            //lblbank.Text = "";
            txtRemark.Text = "";
        }
        else
        {
            Response.Redirect("LoginUserDetails.aspx");
        }
              
    }
   
    protected void Cheque_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Cheque.Items[0].Selected)
        {
            pnlCust.Visible = true;
            pnlCheque.Visible = true;
            lbldate.Text = "Cheque Date";
            
        }
        else
        {
            pnlCust.Visible = true;
            pnlCheque.Visible = false;
            lbldate.Text = "Date";
            txtChequeDate.Text = "";
          

        }
    }
    
    protected void btnview_Click(object sender, EventArgs e)
    {
        //pnlCust.Visible = false;
        //PnlCustDiscDetails.Visible = false;
        //pnlCash.Visible = false;
        //getcheque.Visible = true;
        //UpanelGrd.Visible = true;
        //pnlshowdetail.Visible = true;
    }

    #endregion
    //protected void txtBankName_TextChanged(object sender, EventArgs e)
    //{
    //    string BankCode = txtBankName.Text.ToString().Split(':')[0].Trim();


    //    DataTable dt = new DataTable();
    //    dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
    //    if (dt.Rows.Count != 0)
    //    {
    //        txtBankName.Text = BankCode;
    //        lblbank.Text = Convert.ToString(dt.Rows[0]["BankName"]);
    //        txtCheck.Focus();

    //    }


    //    else
    //    {
    //        lblbank.Text = "No such Bank code";
    //        txtBankName.Focus();
    //        txtBankName.Text = "";
    //    }
    //}
    #region Text Changed
    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomerid.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomerid.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            txtcustomerid.Focus();

        }


        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomerid.Focus();
            txtcustomerid.Text = "";

        }
    }
    protected void txtReciptNo_TextChanged(object sender, EventArgs e)
    
    {
        try
        {
            int receiptNo = Convert.ToInt32(txtReciptNo.Text.Trim());
            DataTable dt = new DataTable();
            dt = ReciptBookDetails.Idv_Chetana_Get_ReceiptView_AT_EntryTime(receiptNo).Tables[0];
            if (dt.Rows.Count != 0)
            {
               // lblempname.Text = dt.Rows[0]["Name"].ToString() + "::Rec No:" + receiptNo;
                lblshow.Text = dt.Rows[0]["Name"].ToString() + "::Rec No:" + receiptNo;
                txtEMcode.Text = dt.Rows[0]["EmpCode"].ToString();
                lblempname.Visible = true;
                pnlCust.Visible = true;
            }
            else
            {

                message("ReceiptNo not allocated");
                txtReciptNo.Focus();
                lblempname.Text = "";
                lblempname.Text = "Rec No:" + receiptNo;
                lblempname.Visible = true;
                txtReciptNo.Text = "";
                txtEMcode.Text = "";
                lblshow.Text = "";
            }
           string Auth = ReciptBookDetails.getReciptbook_valid(receiptNo);
                txtcustomerid.Focus();
                if (Auth!= "enter")
                {
                    MessageBox(Auth);
                    txtReciptNo.Text = "";
                    txtReciptNo.Focus();
                }
                else
                {

                }
          }
        catch (Exception ex)
        {
        }
    }
   
    protected void txtcheque_TextChanged(object sender, EventArgs e)
    {
        string Customer = txtcheque.Text.ToString().Split(':')[0].Trim();


        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(Customer, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcheque.Text = Customer;
            lblcheque.Text =Convert.ToString(dt.Rows[0]["CustName"]);
           
        }
        else
        {

            lblshow.Text = "No such salesman code";
            txtEMcode.Focus();
            txtEMcode.Text = "";
        }
    }

    protected void txtEMcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtEMcode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "Employee").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtEMcode.Text = ECode;
            lblshow.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            txtReciptNo.Focus();
        }
        else
        {

            lblshow.Text = "No such salesman code";
            txtEMcode.Focus();
            txtEMcode.Text = "";
        }

        UpanelGrd.Visible = false;
    }

    #endregion

    #region Grid Events
    protected void gvdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlCust.Visible = true;
        getcheque.Visible = false;
       // btn_Save.Visible = true;
        Cheque_CashDetails chke = new Cheque_CashDetails();
        try
        {

            bool isEditable = Convert.ToBoolean(((Label)gvdetails.Rows[e.NewEditIndex].FindControl("isEditable")).Text);
            if (isEditable == false)
            {
                btn_Save.Visible = false;
                MessageBox("This Record is locked for Edit");
                lblIsEditable.Visible = true;
              
            }
            else
            {
                btn_Save.Visible = true;
            }
           
            lblID.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblid2")).Text;
            txtEMcode.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblempcode")).Text;
            txtCheck.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblchequeno")).Text;
            Cheque.SelectedValue = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblDepositeType")).Text;
            txtChequeDate.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblcheque")).Text;
            txtReciptNo.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblreceipt")).Text;
            txtcustomerid.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblcustomer")).Text;
            txtAmount.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblamount")).Text;
            txtBankName.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblbank")).Text;
            txtRemark.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblremark")).Text;
            lblCustName.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblcustname")).Text;
            lblshow.Text = ((Label)gvdetails.Rows[e.NewEditIndex].FindControl("lblempname")).Text;
        }
        catch (Exception ex)
        {

        }
    }
    #endregion


    protected void btnGetData_Click(object sender, EventArgs e)
    {
        BindDataGet();
    }
    public void BindDataGet()
    {

        string ECode = txtcheque.Text.ToString().Split(':')[0].Trim(); 
        From = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
        string FromDate = From;
        string ToDate = To;

        DataTable dss = new DataTable();
        dss = Cheque_CashDetails.get_ChequeCashDeposit(ECode, FromDate, ToDate).Tables[0];
        if (dss.Rows.Count != 0)
        {
            gvdetails.DataSource = dss;
            gvdetails.DataBind();
            getcheque.Visible = true;

            gvdetails.Visible = true;
        }
        else
        {
            MessageBox("No Record Found");
            gvdetails.DataSource = null;
            gvdetails.Visible = false;
            lblshow.Text = "No Data Found";
            txtEMcode.Focus();
            txtEMcode.Text = "";
            txtFromDate.Text = "";
            txttoDate.Text = "";
            lblshow.Text = "";
        }
    }
}
