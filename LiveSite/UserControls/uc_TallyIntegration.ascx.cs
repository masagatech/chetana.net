using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Idv.Chetana.BAL;
using Idv.Chetana.Common;

public partial class UserControls_uc_TallyIntegration : System.Web.UI.UserControl
{
    SqlConnection vSqlCon = null;
    SqlDataAdapter vSqlDA = null;
    DataTable vDTable = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        vSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["idvConString"].ConnectionString);
    }

    // Download Charted Of Account

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];

            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }

    public static void Export(string fileName, GridView gv)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                Table table = new Table();

                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                table.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    public void downloadExcel(string what, string code)
    {
        SqlCommand cmd = new SqlCommand("Idv_Chetana_Tally_Integration", vSqlCon);
        cmd.Parameters.Add("@what", SqlDbType.VarChar).Value = what;
        cmd.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = txtFromDate.Text;
        cmd.Parameters.Add("@todate", SqlDbType.DateTime).Value = txtToDate.Text;
        cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = code;

        cmd.CommandType = CommandType.StoredProcedure;
        vSqlDA = new SqlDataAdapter(cmd);
        vDTable = new DataTable();

        try
        {
            vSqlCon.Open();
            vSqlDA.Fill(vDTable);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (vSqlCon.State == ConnectionState.Open)
                vSqlCon.Close();
        }

        gvExportDetails.DataSource = vDTable;
        gvExportDetails.DataBind();
    }

    protected void btnDLoad_COA_Click(object sender, EventArgs e)
    {
        downloadExcel("ma", "");
        Export("DownloadChartOfAccount.xls", gvExportDetails);
    }

    // Auto Bank Payment

    protected void txtAutoBP_TextChanged(object sender, EventArgs e)
    {
        string BankCode = txtAutoBP.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtAutoBP.Text = BankCode;
            lblAutoBP.Text = Convert.ToString(dt.Rows[0]["BankName"]);
        }
        else
        {
            lblAutoBP.Text = "No such Bank Payment";
            txtAutoBP.Focus();
            txtAutoBP.Text = "";
        }
    }

    // Download Bank Payment

    protected void btnDLoad_BP_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Enter From Date");
        }
        else if (txtToDate.Text == "")
        {
            MessageBox("Enter To Date");
        }
        else if (txtAutoBP.Text == "")
        {
            MessageBox("Enter Bank Payment");
        }
        else
        {
            downloadExcel("bp", txtAutoBP.Text);
            Export("DownloadBankPayment.xls", gvExportDetails);
        }
    }

    // Auto Bank Receivable

    protected void txtAutoBR_TextChanged(object sender, EventArgs e)
    {
        string BankCode = txtAutoBR.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtAutoBR.Text = BankCode;
            lblAutoBR.Text = Convert.ToString(dt.Rows[0]["BankName"]);
        }
        else
        {
            lblAutoBR.Text = "No such Bank Receivable";
            txtAutoBR.Focus();
            txtAutoBR.Text = "";
        }
    }

    // Download Bank Receivable

    protected void btnDLoad_BR_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Enter From Date");
        }
        else if (txtToDate.Text == "")
        {
            MessageBox("Enter To Date");
        }
        else if (txtAutoBR.Text == "")
        {
            MessageBox("Enter Bank Receivable");
        }
        else
        {
            downloadExcel("br", txtAutoBR.Text);
            Export("DownloadBankReceivable.xls", gvExportDetails);
        }
    }

    // Download Invoice

    protected void btnDLoad_Inv_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Enter From Date");
        }
        else if (txtToDate.Text == "")
        {
            MessageBox("Enter To Date");
        }
        else
        {
            downloadExcel("inv", "");
            Export("DownloadInvoices.xls", gvExportDetails);
        }
    }

    // Download Credit Note

    protected void btnDLoad_CN_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Enter From Date");
        }
        else if (txtToDate.Text == "")
        {
            MessageBox("Enter To Date");
        }
        else
        {
            downloadExcel("cn", "");
            Export("DownloadCreditNote.xls", gvExportDetails);
        }
    }

    // Download Journal Voucher

    protected void btnDLoad_JV_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Enter From Date");
        }
        else if (txtToDate.Text == "")
        {
            MessageBox("Enter To Date");
        }
        else
        {
            downloadExcel("jv", "");
            Export("DownloadJounranlVoucher.xls", gvExportDetails);
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
}