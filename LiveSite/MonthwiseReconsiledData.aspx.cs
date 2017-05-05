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
using Others;


public partial class MonthwiseReconsiledData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();   
    }
    public void Bind()
    {
        string strRepHeading = null;
        Decimal OP = Convert.ToDecimal(Request.QueryString["OP"].ToString());
        DataSet ds = new DataSet();
        //ds = Bank.Get_Bank_Reco(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"].ToString()), Convert.ToInt32(Request.QueryString["FY"].ToString()),0);
        ds = OtherClass.Get_Bank_MonthwiseReconsileData(Request.QueryString["code"].ToString(),
                                               Convert.ToInt32(Request.QueryString["d"].ToString()),
                                               Convert.ToInt32(Request.QueryString["FY"].ToString()),
                                               Convert.ToInt32(Request.QueryString["FlagBit"].ToString()));
        //  Response.Write("hello " + ds.Tables[0].Rows.Count.ToString());
        if (Convert.ToInt32(Request.QueryString["FlagBit"].ToString()) == 1)
        {
            strRepHeading = "Reconsile In Same Month Records";
        }
        else
        {
            strRepHeading = "Reconsile In Other Month Records";
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/ReconsiledMonthWise.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            DataTable tbl;
            DataRow dr;
            if (ds.Tables[1].Rows.Count > 0)
            {
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
            
            
            crvReport.ReportSource = rd;
            rd.SetParameterValue("ReportHead",strRepHeading);

        }
        else
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/ReconsiledMonthWise.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            rd.SetParameterValue("CoBallance", OP);
            rd.SetParameterValue("Debit", 0);
            rd.SetParameterValue("credit", 0);
            rd.SetParameterValue("TotalBallance", (OP + 0) - 0);
            crvReport.ReportSource = rd;
        }
    }
}
