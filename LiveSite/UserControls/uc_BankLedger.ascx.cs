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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class UserControls_uc_BankLedger : System.Web.UI.UserControl
{
    string strFY;
    string BankCode;
    DateTime fdate;
    DateTime tdate;
    static decimal amount;
    static decimal amount2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {

            strFY = Session["FY"].ToString();
        }

        if (!Page.IsPostBack)
        {

            txtBank.Focus();

        }
        if (IsPostBack)
        {
            if (txtBank.Text == "" || txtfromDate.Text == "" || txttoDate.Text == "")
            {
                
            }
            else
            {
                ShowDetails();
            }
            
        }

    }
    public void ShowDetails()
    {
        string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);

        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }
        else
        {
            DataSet dsop = new DataSet();
            dsop = ActualInvoiceDetails.Get_Bank_Ledger(txtBank.Text.ToString().Trim(), "OpeningBalance", from, 0, 0, Convert.ToInt32(strFY));
            decimal ob;
            ob = Convert.ToDecimal(dsop.Tables[1].Rows[0]["OpeningBlance"].ToString());

            DataSet ds = new DataSet();
            ds = ActualInvoiceDetails.Get_Bank_Ledger(txtBank.Text.ToString().Trim(), from, To, ob,0,0);
            
            DataView dv = new DataView(ds.Tables[0]);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/BankLedgerNew.rpt"));
            //rd.Load(Server.MapPath("Report/BankLedger.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            BankLedger.ReportSource = rd;
        
            //gvBankLedger.DataSource = ActualInvoiceDetails.Get_Bank_Ledger(txtBank.Text.ToString().Trim(), from, To).Tables[0];
            // gvBankLedger.DataBind();
            //if (gvBankLedger.Rows.Count <= 0)
            //{
            //    MessageBox("No Record Found");
            //}

        }  
     
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }
    protected void txtBank_TextChanged(object sender, EventArgs e)
    {
        BankCode = txtBank.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtBank.Text = BankCode;
            lblBankName.Text = Convert.ToString(dt.Rows[0]["BankName"]);
           txtfromDate.Focus();

        }


        else
        {
            lblBankName.Text = "No such Bank code";
            txtBank.Focus();
            txtBank.Text = "";
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    
}
