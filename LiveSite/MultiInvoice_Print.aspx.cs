using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Idv.Chetana.BAL;
using CrystalDecisions.CrystalReports.Engine;

public partial class MultiInvoice_Print : System.Web.UI.Page
{
    string strFY = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != "" || Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
            AutoCompleteExtender1.ContextKey = "multiinvoice!" + strFY;
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            Session["invoiceData"] = null;
            Session["DATAREPInv"] = null;

        }
        if (Page.IsPostBack)
        {
            if (Session["DATAREPInv"] != null)
            {
                fillReport();
            }
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (txtinvNo.Text.ToString() != "")
        {
            DataTable dt = new DataTable();

            if (Session["invoiceData"] == null)
            {
                dt.Columns.Add("InvoiceNo");
            }
            else
            {
                dt = (DataTable)Session["invoiceData"];
            }
            string invno;
            invno = txtinvNo.Text.ToString();

            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["invoiceData"];
            DataView dv = new DataView(dt1);
            dv.RowFilter = "InvoiceNo = '" + invno.Trim() + "'";
            int i = 0;
            foreach (DataRowView row in dv)
            {
                i++;
            }
            if (i == 0)
            {
                dt.Rows.Add(invno);
                grdinvDetails.DataSource = dt;
                grdinvDetails.DataBind();
                Session["invoiceData"] = dt;
                btnPrint.Visible = true;
            }
            else
            {
                MessageBox("already added"); //already added
            }
            txtinvNo.Focus();
            txtinvNo.Text = "Enter InvoiceNo";
           // upGridInvData.Update();
        }
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void grdinvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["invoiceData"];
        dt1.Rows[e.RowIndex].Delete();
        grdinvDetails.DataSource = dt1;
        grdinvDetails.DataBind();
        Session["invoiceData"] = dt1;
        if (dt1.Rows.Count == 0)
        {
            btnPrint.Visible = false;
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strinvno = "";
        foreach (GridViewRow row in grdinvDetails.Rows)
        {
            strinvno = strinvno + ((Label)row.FindControl("lblInvoiceNo")).Text.Trim() + ",";
        }

        DataTable dt = new DataTable();

        dt = DCDetails.DC_Get_InvoiceDetails_On_subdocID(Convert.ToDecimal(strFY), strinvno,Convert.ToString(Session["UserName"]) );
        Session["DATAREPInv"] = dt;
        fillReport();
    }
    private void fillReport()
    {
        if (Session["DATAREPInv"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["DATAREPInv"];
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/PrintInvoiceMulti.rpt"));
            rd.SetDataSource(dt);
            CrptInvoice.ReportSource = rd;
           // upGridInvData.Update();
        }

    }
}
