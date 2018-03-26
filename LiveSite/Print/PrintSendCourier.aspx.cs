using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
public partial class Print_PrintSendCourier : System.Web.UI.Page
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }


        }

        bindReport();

    }
    public void bindReport()
    {
        if (Request.QueryString["d"] != null)
        {
            ReportDocument rd = new ReportDocument();
            DataSet ds = new DataSet();
            if (Request.QueryString["mFlag"] != "GeneralCourierID")
            {
                ds = CourierDetails.SendCourierPrint(float.Parse(Request.QueryString["d"].ToString()), "CourierId", Convert.ToInt32(strFY));
                if (ds.Tables[0].Rows[0]["EmpID"].ToString() != "0")
                {
                    rd.Load(Server.MapPath("../Report/ChetanaSendCourierPrint.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath("../Report/ChetanaSendCourierPrintNoBranch.rpt"));
                }
            }
            else
            {
                ds = CourierDetails.SendCourierPrintGeneral(float.Parse(Request.QueryString["d"].ToString()), "GeneralCourierID", Convert.ToInt32(strFY));
                if (ds.Tables[0].Rows[0]["EmpID"].ToString() != "0")
                {
                    rd.Load(Server.MapPath("../Report/ChetanaSendCourierGeneralPrint.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath("../Report/ChetanaSendCourierGeneralPNB.rpt"));
                }
            }
            // ds = CourierDetails.Get_CourierDetailsCheck(Convert.ToString(Request.QueryString["d"].ToString()), "DocNoGrid", Convert.ToInt32(strFY));
        
           // ds = G_GetPass.Local_Report(Convert.ToInt32(Request.QueryString["d"].ToString()), Request.QueryString["L"].ToString(), Convert.ToInt32(strFY));
           
           
           

            rd.Database.Tables[0].SetDataSource(ds.Tables[0]);


            LocalGodown.ReportSource = rd;
            LocalGodown.DataBind();
        }
    }
   
}