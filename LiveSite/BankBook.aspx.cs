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

public partial class Print_BankBook : System.Web.UI.Page
{
    DataView dv;
    DataTable pettycash;
    int monthno;
    protected void Page_Load(object sender, EventArgs e)
    {
        Show();
    }

    public void Show()
    {
        if (Request.QueryString["d"] != null)
        {
            DataSet ds = new DataSet();
            monthno = Convert.ToInt32(Request.QueryString["d"]);
            if (Request.QueryString["code"].ToString() == "PC36")
            {
                pettycash = (DataTable)Session["pettycash"];
                dv = new DataView(pettycash);
                dv.RowFilter = "(monthno = '"+monthno+"')";

            }
            else
            {
                ds = Bank.Get_Bank_LedgerNew(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"]), Convert.ToInt32(Request.QueryString["FY"]),
                    Convert.ToDecimal(Request.QueryString["OP"]));

                 dv = new DataView(ds.Tables[0]);
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../Report/BankLedgerNew.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            BankLedger.ReportSource = rd;
        }
    }
}
