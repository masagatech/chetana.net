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
using Other_Z;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;

public partial class Token_Transfer_Register : System.Web.UI.Page
{

    #region Goloval Veriable
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                txtFromDate.Text = "01/04/201" + Convert.ToInt32(strFY);
                txtToDate.Text ="31/03/201"+Convert.ToInt32(Convert.ToInt32(strFY) + 1);
            }
        }
        if (txtIsExport.Value == "yes")
        {
            DataTable dt = Session["TokenTransferReport"] as DataTable;
            BindReport(dt);
            txtIsExport.Value = "";
        }
        if (Page.IsPostBack)
        {
            txtFromDate.Focus();
            if (Session["TokenTransferReport"] != null)
            {
                DataTable dt = Session["TokenTransferReport"] as DataTable;
                BindReport(dt);
            }
        }
        else
        {
            Session["TokenTransferReport"] = null;
        }
    }
    #endregion

    #region Fill Gridview Get Method Data With FY
    private DataTable FillGridData(string R3,string PrintId)
    {
        string Id = "";
        string R1 = "";
        string R2 = "";
        int TokenKyc=0;
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dtgrid = new DataTable();

        string FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string ToDate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, TokenKyc, PrintId,
            Convert.ToDateTime(FromDate),
            Convert.ToDateTime(ToDate)
            );
        dtgrid = ds.Tables[0];
        return dtgrid;
    }
    #endregion

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Checked Box Checked And Print
    private void ChekedData()
    {
        Session["TokenTransferReport"] = null;
        string TokenNo = "";
        //StringBuilder sb = new StringBuilder();
        try
        {
            //foreach (RepeaterItem i in Rptrpending.Items)
            //{
            //    CheckBox chk = (CheckBox)i.FindControl("chkRepeater");
            //    if (chk.Checked == true)
            //    {
            //        TokenNo = Convert.ToInt32(((CheckBox)chk.Parent.FindControl("chkRepeater")).Text).ToString();
            //        sb.Append(TokenNo + ",");
            //    }
            //}
            //if (TokenNo == "")
            //{
            //    MessageBox("Please Select The Record");
            //    return;
            //}
            //DataTable dt = FillGridData("print", sb.ToString());
            //DataTable dt = FillGridData("print");
           // Session["TokenTransferReport"] = dt;
            //BindReport(dt);
            //DataTable dt = Session["TokenTransferReport"] as DataTable;
           

            //Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('TokenRegisteTransferReport.aspx');", true);

        }
        catch
        {
            throw;
        }
    }

    #endregion
    ReportDocument rd = null;
    private void BindReport(DataTable dt)
    {
        
        if (dt.Rows.Count > 0)
        {
            rd = new ReportDocument();
            rd.Load(MapPath("~/Report/Token_Register_View.rpt"));
            rd.SetDataSource(dt);
            rd.SetParameterValue("ReportHeading", "TOKEN TRANSFERED");
            TokenTransferReportView.ReportSource = rd;
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {

        if (rd != null)
        {
            rd.Close();
            rd.Dispose();
            rd = null;

        }

    }

    #region Get Button Click Event
    protected void Get_Click(object sender, EventArgs e)
    {
        DataTable dt= FillGridData("TokenGetTransferDateWise", "");
        if (dt.Rows.Count > 0)
        {
            //Rptrpending.DataSource = dt;
            //Rptrpending.DataBind();
            Session["TokenTransferReport"] = dt;
            BindReport(dt);
        }
        else
        {
            MessageBox("Record Not Found this Date From  " + txtFromDate.Text + "  And To  " + txtToDate.Text);
            rd = null;
            TokenTransferReportView.ReportSource = rd;
        }

    }
    #endregion

    #region Print Button Click Event
    protected void btnPrintChecked_Click(object sender, EventArgs e)
    {
        //ChekedData();
    }
    #endregion
}
