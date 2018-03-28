using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Add Name Pace
using Other_Z;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class DebitVsCreditReport : System.Web.UI.Page
{
    #region Goloval Veriable
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion

    #region Page Load Session Validation
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                txtFromDate.Text = "01/04/201" + Convert.ToInt32(strFY);
                txttoDate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1);
                txtcustomerid.Focus();
            }
        }
        else
        {
            Session.Clear();
        }
        if (Page.IsPostBack)
        {
            Print();
        }
        
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Print Method
    private void Print()
    {
        string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
        string ToDate = DateTime.Now.ToString("MM/dd/yyyy");
        FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2].ToString();
        ToDate = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2].ToString();
        DataSet ds = OtherBAL.GetDebitVsCreditReport(txtcustomerid.Text.Split(':')[0].ToString(),Convert.ToDateTime(FromDate),Convert.ToDateTime(ToDate),Convert.ToInt32(Session["FY"]), "", "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/DebitVsCredit.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            DebitCredit.ReportSource = rd;
        }
        else
        {
            MessageBox("Record not found");
            txtcustomerid.Focus();
            return;
        }
    }
    #endregion

    #region Get Button Click Event
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        Print();
    }
    #endregion
}