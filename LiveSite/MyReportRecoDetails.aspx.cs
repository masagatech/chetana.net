using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;

public partial class MyReportRecoDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();

    }
    public void Bind()
    {
        Decimal OP = Convert.ToDecimal(Request.QueryString["OP"].ToString());
        int imon=Convert.ToInt32(Request.QueryString["d"].ToString());
        DataSet ds = new DataSet();
        ds = Bank.Get_Bank_Reco(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"].ToString()), Convert.ToInt32(Request.QueryString["FY"].ToString()), OP, Request.QueryString["flag"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/MyReport.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            DataTable tbl;
            DataRow dr;
            if (ds.Tables[1].Rows.Count > 0)
            {
                rd.SetParameterValue("mon",imon);
                rd.SetParameterValue("CoBallance", OP);
                tbl = ds.Tables[1];
                dr = tbl.Rows[0];
                Decimal debit = Convert.ToDecimal(dr[0].ToString());
                Decimal credit = Convert.ToDecimal(dr[1].ToString());
                rd.SetParameterValue("Debit", debit);
                rd.SetParameterValue("credit", credit);
                //rd.SetParameterValue("TotalBallance", Math.Abs(OP) - credit + debit);
                rd.SetParameterValue("TotalBallance", (OP + credit) - debit);
            }
            else
            {
                rd.SetParameterValue("CoBallance", "Not Applicable");
            }

            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    DataTable tbl1 = ds.Tables[2];
            //    DataRow dr1 = tbl1.Rows[0];
            //    //double a=Convert.ToDouble(dr1[0].ToString()) - Convert.ToDouble(dr1[1].ToString());
            //   // rd.SetParameterValue("TotalBallance", dr1[2].ToString());


            //}
            //else
            //{
            //    rd.SetParameterValue("CoBallance", "Not Applicable");
            //}
            CRRecoDetails.ReportSource = rd;

        }
        else
        {
//EVEN there are no pending Record. We should still show closing balance
ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/MyReport.rpt"));
rd.SetDataSource(ds.Tables[0]);

 rd.SetParameterValue("CoBallance", OP);

 rd.SetParameterValue("Debit", 0);
                rd.SetParameterValue("credit", 0);

                rd.SetParameterValue("TotalBallance", (OP + 0) - 0);
CRRecoDetails.ReportSource = rd;
            }            



       
    }
    protected void CRRecoDetails_Init(object sender, EventArgs e)
    {

    }
}
