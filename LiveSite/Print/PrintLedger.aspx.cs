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
using Idv.Chetana.Common;
using System.Data.SqlClient;

public partial class Print_PrintLedger : System.Web.UI.Page
{
    #region Varables

    static decimal cramount = 0;
    static decimal damount = 0;
    static decimal totalamount = 0;
    static decimal cnamount = 0;
    static decimal balamount = 0;
    static decimal temp;
   
    //string date;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(Request.QueryString["flag6"]) != Convert.ToDateTime(Func.getMonthInNameDate(DateTime.Now.ToString("dd/MM/yyyy"))))
        {
            DataSet ds = new DataSet();
                        ds = LeadgerDetails.Get_LedgerDetails(Request.QueryString["flag1"].ToString().Trim(), Request.QueryString["flag2"].ToString().Trim(), Request.QueryString["flag3"].ToString().Trim()
               , Request.QueryString["flag4"].ToString().Trim(), Convert.ToInt32(Request.QueryString["flag41"].ToString().Trim()), Convert.ToDateTime(Request.QueryString["flag5"].ToString().Trim()),
               Convert.ToDateTime(Request.QueryString["flag6"].ToString().Trim()));
            gvLedger.DataSource = ds;
            gvLedger.DataBind();
        }
        else
        {
            DataSet ds1 = new DataSet();
            ds1 = LeadgerDetails.Get_LedgerDetails(Request.QueryString["flag1"].ToString().Trim(), Request.QueryString["flag2"].ToString().Trim(), Request.QueryString["flag3"].ToString().Trim()
               , Request.QueryString["flag4"].ToString().Trim(), Convert.ToInt32(Request.QueryString["flag41"].ToString().Trim()));

           
            gvLedger.DataSource = ds1;
            gvLedger.DataBind();
        }


    }
    protected void gvLedger_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            cramount = 0;
            damount = 0;
            cnamount = 0;
            balamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblche_no");
            damount = damount + Convert.ToDecimal(lbl.Text.Trim());
            //Label lblamt = (Label)e.Row.FindControl("lbl_Amount");
            //if (lblamt.Text == "-")
            //{
            //    lblamt.Text = "0";
            //}
            //cramount = cramount + Convert.ToDecimal(lblamt.Text.Trim());
            //Label lblcnoteamt = (Label)e.Row.FindControl("lblCNAmount");
            //cnamount = cnamount + Convert.ToDecimal(lblcnoteamt.Text.Trim());
            //Label lblopenbal = (Label)e.Row.FindControl("lblopenbal");
            //balamount = balamount + Convert.ToDecimal(lblopenbal.Text.Trim());

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotaldebitAmt");
            lbl1.Text = damount.ToString().Trim();
            //Label lblamt1 = (Label)e.Row.FindControl("lblTotalCreditAmt");
            //lblamt1.Text = cramount.ToString().Trim();
            //Label lblcnamt = (Label)e.Row.FindControl("lblTotalCNAmt");
            //lblcnamt.Text = cnamount.ToString().Trim();
            //Label lblbalamt = (Label)e.Row.FindControl("lblTotalbalance");
            //lblbalamt.Text = balamount.ToString().Trim();
            ////lblopbal.Text = 

            //temp = Convert.ToDecimal((balamount + damount) - (cramount + cnamount));
            //lblopbal1.Text = temp.ToString();
            //lbloutstndamt.Text = temp.ToString();
        }
    }
}
