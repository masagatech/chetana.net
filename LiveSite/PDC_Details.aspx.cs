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

public partial class PDC_Details : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           ViewState["Data"] = null;
        }
        if (IsPostBack)
        {
              if (ViewState["Data"] != null)
                {
                    BindData((DataTable)ViewState["Data"]);
                }
            
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
         string from = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        DataTable dt = new DataTable();
        dt = Cheque_CashDetails.Get_PDC_Details(fdate, tdate, "").Tables[0];
        ViewState["Data"] = dt;
        BindData(dt);
    }

    public void BindData(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/PDCReport.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            PDCReport.ReportSource = rd;
        }
    }
}
