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

public partial class TokenRegisterPending : System.Web.UI.Page
{

    #region Golovl Veriable
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
                if (!IsPostBack)
                {
                    Rptrpending.DataSource = FillGridView("TokenPending", "");
                    Rptrpending.DataBind();
                }

            }
            
            
        }
        if (txtIsExport.Value == "yes")
        {
            DataTable dt = (DataTable)Session["TokenPendingReport"];
            bindreport(dt);
            txtIsExport.Value = "";
        }
        if (Page.IsPostBack)
        {
            if (Session["TokenPendingReport"] != null)
            {
                DataTable dt = (DataTable)Session["TokenPendingReport"];
                bindreport(dt);
            }
        }
        else {
            Session["TokenPendingReport"] = null;
        }
    }

    #endregion

    #region Get All Data IsTransfer Method
    private DataTable FillGridView(string R3, string PrintId)
    {
        string Id = "";
        string R1 = "";
        string R2 = "";
        string strTemp = "";
        string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
        string ToDate = DateTime.Now.ToString("MM/dd/yyyy");
        int TokenKyc = 0;
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dt = new DataTable();
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, TokenKyc, PrintId,
            R3 == strTemp ? Convert.ToDateTime(FromDate) : Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")),
            R3 == strTemp ? Convert.ToDateTime(ToDate) : Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")));
        dt = ds.Tables[0];
        return dt;
    }
    #endregion

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Print Button Click Event
    protected void btnprint_Click(object sender, EventArgs e)
    {
        ChekedData();
    }
    #endregion

    #region Checked Box Checked And Print
    private void ChekedData()
    {
        Session["TokenPendingReport"] = null;
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        OtherBAL.Token_Register_Property ObjProperty = new OtherBAL.Token_Register_Property();
        int tokenid;
        Session["TokenPendingReport"] = null;
        ObjProperty.R1 = "UpdateTransaction";
        ObjProperty.createdBy = Session["UserName"].ToString();
        ObjProperty.FY = Convert.ToInt32(Session["FY"]);
        string TokenNo = "";
        StringBuilder sb = new StringBuilder("<r>");
        StringBuilder sb1 = new StringBuilder();
        try
        {
            foreach (RepeaterItem i in Rptrpending.Items)
            {
                CheckBox chk = (CheckBox)i.FindControl("chkRepeater");
                if (chk.Checked == true)
                {
                    sb.Append("<i>");
                    TokenNo = Convert.ToInt32(((CheckBox)chk.Parent.FindControl("chkRepeater")).Text).ToString();
                    sb.Append("<x>" + TokenNo + "</x>");
                    sb.Append("</i>");
                    sb1.Append(TokenNo + ",");
                }
            }
            sb.Append("</r>");
            if (TokenNo == "")
            {
                MessageBox("Please Checked The Record");
                return;
            }
            ObjProperty.R2 = sb.ToString();
            ObjBAL.Idv_Chetana_Save_Token_Register(ObjProperty, out tokenid);

            //DataTable dt = FillGridView("TokenTransferReport", sb1.ToString());
            //Session["TokenPendingReport"] = dt;

            Rptrpending.DataSource = FillGridView("TokenPending", "");
            Rptrpending.DataBind();

            DataTable dt = DataPrint("print", sb1.ToString());
            Session["TokenPendingReport"] = dt;
            bindreport(dt);

            //Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Token_Register_Report.aspx');", true);


        }
        catch
        {
            throw;
        }



    }


    #endregion
    ReportDocument rd = null;
    private void bindreport(DataTable dt)
    {
        rd = new ReportDocument();
        rd.Load(Server.MapPath("~/Report/Token_Register_View.rpt"));
        rd.SetDataSource(dt);
        rd.SetParameterValue("ReportHeading", "TRANSFER TOKEN REGISTER");
        TokeRegisterReport.ReportSource = rd;
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

    #region Data Print Method
    public DataTable DataPrint(string R3, string PrintId)
    {
        string Id = "";
        string R1 = "";
        string R2 = "";
        int TokenKyc = 0;
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dtgrid = new DataTable();
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, TokenKyc, PrintId, Convert.ToDateTime(null),
            Convert.ToDateTime(null));
        return dtgrid = ds.Tables[0];
    }
    #endregion
}
