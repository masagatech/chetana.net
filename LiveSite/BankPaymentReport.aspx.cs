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

public partial class UserControls_BankPaymentReport : System.Web.UI.Page
{
    string BankCode;
    int DocumentNo;
    string strFY;
    string strChetanaCompanyName = "cppl";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
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
        if (!Page.IsPostBack)
        {

            txtBank.Focus();

        }
        if (IsPostBack)
        {
            if (txtBank.Text == "" || txtDocNo.Text == "")
            {

            }
            else
            {
                Bind();
            }

        }
    }
    protected void txtBank_TextChanged(object sender, EventArgs e)
    {
        BankCode = txtBank.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = Idv.Chetana.BAL.DCMaster.Get_Name(BankCode, "Bank").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtBank.Text = BankCode;
            lblBankName.Text = Convert.ToString(dt.Rows[0]["BankName"]);
            txtDocNo.Focus();

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

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnget_Click(object sender, EventArgs e)
    {
        Bind();
    }
    public void Bind()
    {
        try
        {
            BankCode = txtBank.Text.ToString().Split(':')[0].Trim();
            DocumentNo = Convert.ToInt32(txtDocNo.Text.Trim());
            DataTable dt = new DataTable();
            dt = Bank.Get_BankPaymentReport(BankCode, DocumentNo, strFY).Tables[0];
            if (dt.Rows.Count != 0)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/BankPayment.rpt"));
                rd.SetDataSource(dt);
                BankPaymentReport.ReportSource = rd;
            }
            else
            {
                MessageBox("No Record Found");
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.ToString());

        }
    }
}
