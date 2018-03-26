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

public partial class BankSummary : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY;
    DataSet ds = new DataSet();


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
            Session["pettycash"] = null;
        }
    }
    private void GetFinancialYear()
    {
        DataTable dt = Yearmaster.GetFinancialYear();

        if (dt.Rows.Count > 0)
        {

            ddlFinancialYear.DataSource = dt;
            ddlFinancialYear.DataBind();
            ddlFinancialYear.Items.Insert(0, new ListItem("-Select Year-", "0"));
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
        if (txtBank.Text.ToString().Trim() == "PC36")
        {
            ds = Bank.Idv_Chetana_Get_PettyCashBook(txtBank.Text.ToString().Trim(), Convert.ToInt32(ddlFinancialYear.SelectedValue.ToString()), "", "", "", "");

            Session["pettycash"] = ds.Tables[1];
        }
        else
        {
            ds = Bank.Get_BankBookSummary(Convert.ToInt32(ddlFinancialYear.SelectedValue.ToString()), txtBank.Text.ToString().Trim());
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdBankbook.DataSource = ds.Tables[0];
            grdBankbook.DataBind();
        }
        else
        {
            MessageBox("Records not Found");
            txtBank.Focus();
        }
        if (txtBank.Text.ToString().Trim() == "PC36")
        {
            // grdBankbook.Columns[5].Visible = false;
            // grdBankbook.Columns[6].Visible = false;

        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void lnknotreconcile_Click(object sender, EventArgs e)
    {
        //code added by me
        LinkButton link = (LinkButton)sender;
        //Response.Redirect("MyReportRecoDetails.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no");
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('MyReportRecoDetails.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no" + "')", true);

    }

    protected void lnkismonthreco_Click(object sender, EventArgs e)
    {
        //code added by me

        LinkButton link = (LinkButton)sender;
        //Response.Redirect("MyReportRecoDetails.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no");
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('MonthwiseReconsiledData.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no" + "&FlagBit=" + "1" + "')", true);

    }
    protected void lnkisnotmonthreco_Click(object sender, EventArgs e)
    {
        //code added by me

        LinkButton link = (LinkButton)sender;
        //Response.Redirect("MyReportRecoDetails.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no");
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('MonthwiseReconsiledData.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no" + "&FlagBit=" + "0" + "')", true);

    }
    protected void lnkyear_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/BankBook.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "')", true);
    }
    protected void lnkmonth_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        //Response.Redirect("ReconsiledReportDetails.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "yes");
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('ReconsiledReportDetails.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "yes" + "')", true);

    }
    protected void grdBankbook_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
