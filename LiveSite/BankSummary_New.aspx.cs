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

public partial class BankSummary_New : System.Web.UI.Page
{
   
     string strFY ;
     
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (Session["FY"] != null)
            {
               
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
       
        if (!Page.IsPostBack)
        {
            GetFinancialYear();
            Session["expense"] = null;
        }
        if (Page.IsPostBack)
        {

            if (Session["expense"] != null)
            {
                getreport((DataTable)Session["expense"]);
            }
        } 

    }
    private void GetFinancialYear()
    {
        DataTable dt = Bank.Idv_chetana_Get_Month().Tables[0];
      
        if (dt.Rows.Count > 0)
        {
            ddlFinancialYear.DataSource = dt;
            ddlFinancialYear.DataBind();
            ddlFinancialYear.Items.Insert(0, new ListItem("-Select Month-", "0"));
        }


    }

    protected void txtBank_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = Idv.Chetana.BAL.DCMaster.Get_Name(txtBank.Text.ToString().Split(':')[0].Trim(), "Bank").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtBank.Text = txtBank.Text.ToString().Split(':')[0].Trim(); 
            lblBankName.Text = Convert.ToString(dt.Rows[0]["BankName"]);
            ddlFinancialYear.Focus();

        }


        else
        {
            lblBankName.Text = "No such Bank code";
            txtBank.Focus();
            txtBank.Text = "";
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
        //fdate = Convert.ToDateTime(from);
        //tdate = Convert.ToDateTime(To);
       
        DataSet ds =new DataSet();
        ds = Bank.Get_Bank_LedgerNew(txtBank.Text.ToString().Trim(), Convert.ToInt32(ddlFinancialYear.SelectedValue.ToString()), Convert.ToInt32(strFY), Convert.ToDecimal(txtamount.Text.ToString()), "ExpenseRegister", from, To, "");
        
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            getreport(ds.Tables[0]);
            Session["expense"] = ds.Tables[0];
           // grdBankbook.DataSource = ds.Tables[0];
           // grdBankbook.DataBind();
        }
        else
        {
            MessageBox("Records not Found");
            txtBank.Focus();
        }

        //Bank.Get_Bank_LedgerNew(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"]), Convert.ToInt32(Request.QueryString["FY"]),
        //        Convert.ToDecimal(Request.QueryString["OP"]));

        //DataView dv = new DataView(ds.Tables[0]);
        //ReportDocument rd = new ReportDocument();
        //rd.Load(Server.MapPath("../Report/BankLedgerNew.rpt"));
        //rd.Database.Tables[0].SetDataSource(dv);
        //BankLedger.ReportSource = rd;
    }

    private void getreport(DataTable dt1)
    {

        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/BankLedgerNew_Expense.rpt"));
        rd.Database.Tables[0].SetDataSource(dt1);
        Expenseregister.ReportSource = rd;
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void lnkyear_Click(object sender, EventArgs e)
    {
        //LinkButton link = (LinkButton)sender;
        ////Response.Redirect("");
        //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/BankBook.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "')", true);
        
    }
}
