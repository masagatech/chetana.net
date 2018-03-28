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
using CrystalDecisions.CrystalReports.Engine;

public partial class StockLedger : System.Web.UI.Page
{
    #region Variables
    string strFY;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["StockLedger"] = null;

            if (Session["FY"] != null)
            {
                strFY = Session["FY"].ToString();
                txtFromDate.Text = Session["FromDate"].ToString();
                txtTo.Text = Session["ToDate"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (Page.IsPostBack)
        {
            if (Session["StockLedger"] != null)
            {
                ShowDetails(0);
            }
        }
        //Response.Write(strFY);
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails(1);
    }
    public void ShowDetails(int getnew)
    {
        string Bookcode = txtbkcod.Text.ToString().Split(':')[0].Trim();

        if (getnew == 1)
        {
            Session["StockLedger"] = null;
        }

        DataSet ds = new DataSet();
        if (Session["StockLedger"] == null)
        {
         
            Session["StockLedger"] = LoanPartyMaster.Idv_Chetana_Stock_Ledger_Report(Bookcode,
                   Convert.ToDateTime(txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2]),
                   Convert.ToDateTime(txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]),
                   Convert.ToInt32(strFY));
        }
        //DataSet ds2 = new DataSet();
        // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/StockLedger.rpt"));
        rd.Database.Tables[0].SetDataSource(((DataSet)Session["StockLedger"]).Tables[0]);
        // rd.Database.Tables[1].SetDataSource(dv2);
        //rd.SetDataSource(ds);
        crtStLedger.ReportSource = rd;

    }
}
