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

public partial class ReceiptBookReport : System.Web.UI.Page
{
    string  ReceiptBookId;
    string strFY;
    string strChetanaCompanyName = "cppl";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "")
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);
            if (IsPostBack)
            {
                Bind();
            }
            txtReceiptBook.Focus();
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        Bind();
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
    public void Bind()
    {

       ReceiptBookId  =  txtReceiptBook.Text.Trim()+ "," +txttoNo.Text.Trim();

        DataTable dt = new DataTable();
        dt = ReciptBookDetails.Idv_Chetana_Report_ReceiptBook(ReceiptBookId).Tables[0];
        if (dt.Rows.Count != 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/ReceiptBook.rpt"));
            rd.SetDataSource(dt);
            ReceiptReport.ReportSource = rd;

        }


        else
        {
            MessageBox("No Record Found");
            txtReceiptBook.Focus();
            txtReceiptBook.Text = "";
        }

    }
}
