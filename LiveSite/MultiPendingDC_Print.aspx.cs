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
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;

public partial class MultiPendingDC_Print : System.Web.UI.Page
{
    string strFY = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != "" || Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
            AutoCompleteExtender1.ContextKey = "multipendingdc!" + strFY;
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            Session["PendingDCData"] = null;
            Session["DATAREPPendingDC"] = null;

        }
        if (Page.IsPostBack)
        {
            if (Session["DATAREPPendingDC"] != null)
            {
                fillReport();
            }
        }
    }



    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (txtPendingDCNo.Text.ToString() != "")
        {
            DataTable dt = new DataTable();

            if (Session["PendingDCData"] == null)
            {
                dt.Columns.Add("PendingDCNo");
            }
            else
            {
                dt = (DataTable)Session["PendingDCData"];
            }
            string invno;
            invno = txtPendingDCNo.Text.ToString();

            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["PendingDCData"];
            DataView dv = new DataView(dt1);
            dv.RowFilter = "PendingDCNo = '" + invno.Trim() + "'";
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
                Session["PendingDCData"] = dt;
                btnPrint.Visible = true;
            }
            else
            {
                MessageBox("already added"); //already added
            }
            txtPendingDCNo.Focus();
            txtPendingDCNo.Text = "Enter PendingDC.No";
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
        dt1 = (DataTable)Session["PendingDCData"];
        dt1.Rows[e.RowIndex].Delete();
        grdinvDetails.DataSource = dt1;
        grdinvDetails.DataBind();
        Session["PendingDCData"] = dt1;
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

            if (strinvno == string.Empty)
            {
                strinvno = ((Label)row.FindControl("lblPendingDCNo")).Text.Trim() ;
            }
            else
            {
                strinvno = strinvno + "," + ((Label)row.FindControl("lblPendingDCNo")).Text.Trim() ;
            }
        }

        DataTable dt = new DataTable();

        dt = DCDetails.DC_Get_DCDetails_for_MultiPrint(Convert.ToInt32(strFY), strinvno);
        Session["DATAREPPendingDC"] = dt;
        fillReport();


    }
    private void fillReport()
    {
        if (Session["DATAREPPendingDC"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["DATAREPPendingDC"];
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/PrintDCMulti.rpt"));
            rd.SetDataSource(dt);
            CrptPendingDC.ReportSource = rd;

        }

    }


}