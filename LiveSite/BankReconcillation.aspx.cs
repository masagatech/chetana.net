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

public partial class BankReconcillation : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY;
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
        }
        if (!Page.IsPostBack)
        {
            GetFinancialYear();
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

        DataSet ds = new DataSet();
        ds = Bank.Get_BankBookSummary(Convert.ToInt32(ddlFinancialYear.SelectedValue.ToString()), txtBank.Text.ToString().Trim());
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
        LinkButton link = (LinkButton)sender;
        //Response.Redirect("");
        Response.Redirect("BankRecoDetail.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim());
      //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('BankRecoDetail.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + strFY.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "')", true);

    }
    protected void lnknotreconcile_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        //Response.Redirect("");
        Response.Redirect("BankRecoDetail.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "no");
     
    }
    protected void lnkreconcile_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        //Response.Redirect("");
        Response.Redirect("BankRecoDetail.aspx?d=" + link.CommandArgument.ToString() + "&code=" + txtBank.Text.ToString().Trim() + "&FY=" + ddlFinancialYear.SelectedValue.ToString() + "&OP=" + link.CommandName.ToString().Trim() + "&flag=" + "yes");
     
    }
}

