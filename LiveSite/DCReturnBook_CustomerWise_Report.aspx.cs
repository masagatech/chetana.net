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

public partial class DCReturnBook_CustomerWise_Report : System.Web.UI.Page
{
    #region Variables
    string CustCode;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
            if (Session["Role"] != null)
            {
                if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
                {
                    Response.Redirect("dashboard.aspx");
                }

            }
        }
        CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        if (!Page.IsPostBack)
        {
            txtcustomer.Focus();
            fillDCReturnBkR();
        }
    }
    protected void btngetRec_Click(object sender, EventArgs e)
    {
        fillDCReturnBkR();
        //if (Grd2.Rows.Count > 0)
        //{
        //}
        //else
        //{
        //    MessageBox("Records Not Available");
        //}
    }
    #region TextChanged Events

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = Idv.Chetana.BAL.DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            btngetRec.Focus();
            //ACExttransporter.ContextKey = CustCode;

            //   Bind_DDL_Transport();
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
    }
  
    #endregion

    private void fillDCReturnBkR()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Idv.Chetana.BAL.DCReturnBook.Get_DC_ReturnBookR(CustCode, "DCrtbkView2").Tables[0];

            if (dt.Rows.Count > 0)
            {
                ReportDocument CR = new ReportDocument();
                CR.Load(Server.MapPath("Report/DCReturnBook_CustomerWise_Report.rpt"));
                CR.SetDataSource(dt);
                crystalreportviewer2.ReportSource = CR;
             }
            else
            {
                MessageBox("No Records Found");
            }
        }
        catch { }
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
