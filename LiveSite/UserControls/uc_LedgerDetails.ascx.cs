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
using System.IO;

public partial class UserControls_LedgerDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    
    protected void lblSave_Click(object sender, EventArgs e)
    {
        pnlLedgerDetails.Visible =true;
        //string DocumentDate = txtCreatedDate.Text.Split('/')[1] + "/" + txtCreatedDate.Text.Split('/')[0] + "/" + txtCreatedDate.Text.Split('/')[2];
        //Docdate = Convert.ToDateTime(DocumentDate);  
        //LedgerDetails led = new LedgerDetails();
        //led.Particulass = txtperticulas.Text.Trim();
        //led.DebitAmount = Convert.ToDecimal(txtDebitAmount.Text.Trim());
        //led.CreditAmount = Convert.ToDecimal(TxtCreditAmount.Text.Trim());
        //led.balance = Convert.ToDecimal(txtBalance.Text.Trim());
        //led.CreaditDate = Convert.ToDateTime(txtCreatedDate.Text.Split('/')[1] + "/" + txtCreatedDate.Text.Split('/')[0] + "/" + txtCreatedDate.Text.Split('/')[2]);
        //led.FinancialYearFrom = txtFinancialYearsFrom.Text.Trim();
        //led.FinancialYearTo = txtFinancialYearsTo.Text.Trim();
        //led.Save();
        //message("Record Saved Successfully");
        //Clear();
    }
    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
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

    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion
    public void Clear()
    {
        txtperticulas.Text = "";
        txtDebitAmount.Text = "";
        TxtCreditAmount.Text = "";
        txtBalance.Text = "";
        txtCreatedDate.Text = "";
        txtFinancialYearsFrom.Text = "";
        txtFinancialYearsTo.Text = "";

    }
}
