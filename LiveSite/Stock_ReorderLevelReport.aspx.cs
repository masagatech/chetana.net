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

public partial class Stock_ReorderLevelReport : System.Web.UI.Page
{
    string strFY;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {

            strFY = Session["FY"].ToString();
            //  HidFY.Value = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
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
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(To);

        if (DDLstock.SelectedValue == "physical")
        {
            DataTable dt = new DataTable();
            dt = Idv.Chetana.BAL.DCMaster.REP_Physical_STOCK("reorder", FromDate, ToDate, Convert.ToInt32(strFY)).Tables[0];
            ViewState["Data"] = dt;
            BindData(dt);
        }
        else
        {
            DataTable dtvirt = new DataTable();
            dtvirt = Idv.Chetana.BAL.DCMaster.REP_Virtual_STOCK("reorder", FromDate, ToDate, Convert.ToInt32(strFY)).Tables[0];
            ViewState["Data"] = dtvirt;
            BindData(dtvirt);
        }

    }

    public void BindData(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            if (DDLstock.SelectedValue == "physical")
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/PhysicalStock.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrStock.ReportSource = rd;
            }
            else
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/VirtualStock.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrStock.ReportSource = rd;

            }
        }
    }
}
