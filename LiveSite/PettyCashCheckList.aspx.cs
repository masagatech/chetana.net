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

public partial class PettyCashCheckList : System.Web.UI.Page
{
    int ReceiptBookId;
    string strFY;
    string strChetanaCompanyName = "cppl";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
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
            txtFromDate.Focus();
            //Bind();
        }
    }
    protected void lblget_Click(object sender, EventArgs e)
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
        string FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string ToDate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        DataSet ds = new DataSet();
        ds = PettyCash.Idv_Chetana_Get_Petty_Expance_CheckList(FromDate, ToDate, Convert.ToInt32(strFY));
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ds2 = PettyCash.Idv_Chetana_Get_Petty_Expance_View(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()),
            //   Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()));

            DataView dv = new DataView(ds.Tables[0]);
            //DataView dv1 = new DataView(ds2.Tables[0]);

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/PettyCashDetailsCheckList.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            //rd.Database.Tables[1].SetDataSource(dv1);

            PettyCashCheckListCR.ReportSource = rd;
        }
        else
        {
            MessageBox("No Record Found");
            txtFromDate.Focus();
        }
    }
}
