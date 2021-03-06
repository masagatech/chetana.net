﻿using System;
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
public partial class UserControls_Loan_C_I_StockAgeing : System.Web.UI.UserControl
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    string CustCode = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            Session["DataFillAging"] = null;
            
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                txtFromDate.Text = Session["FromDate"].ToString();
            }
            else
            {
                Session.Clear();
            }

            if (Session["DataFillAging"] != null)
            {
                ShowDetails(0);
            }
            //Response.Write(strFY);


        }

    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails(1);
    }

   

    public void ShowDetails(int getnew)
    {
        if (getnew == 1)
        {
            Session["DataFillAging"] = null;
        }
       

        DataSet ds = new DataSet();
        if (Session["DataFillAging"] == null)
        {
            Session["DataFillAging"] = LoanPartyMaster.Idv_Chetana_Stock_Aging_Report(
                //            (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), 
                   Convert.ToDateTime(txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2]),
                   Convert.ToDateTime(txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]),
                    Convert.ToInt32(strFY), "");
        }
        //DataSet ds2 = new DataSet();
        // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("~/Report/StockAgeingReport.rpt"));
        rd.Database.Tables[0].SetDataSource(((DataSet)Session["DataFillAging"]).Tables[0]);
        // rd.Database.Tables[1].SetDataSource(dv2);
        //rd.SetDataSource(ds);
        crtAgging.ReportSource = rd;

    }

}
