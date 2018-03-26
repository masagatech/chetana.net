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
#endregion

public partial class Print_PrintSalesAnalysis : System.Web.UI.Page
{
    #region Varables
    static DataSet stDS;
    static decimal opbal = 0;
    static decimal dbamt = 0;
    static decimal cramt = 0;
    static decimal cnamt = 0;
    static decimal Balamt = 0;

    static decimal topbalamt = 0;
    static decimal tdbamt = 0;
    static decimal tcramt = 0;
    static decimal tcnamt = 0;
    static decimal totalBalamt = 0;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != null)
        { 
            stDS = new DataSet();
            if (Request.QueryString["fd"] != null && Request.QueryString["td"] != null)
            {

                //  docno.InnerHtml = txtDocno.Text.Trim();
                stDS = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()), Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()), Convert.ToDateTime(Request.QueryString["fd"].ToString()), Convert.ToDateTime(Request.QueryString["td"].ToString()));
                RepDetails.DataSource = stDS.Tables[0];
                RepDetails.DataBind();
                lblsuperzone.Text = stDS.Tables[2].Rows[0]["SuperZoneName"].ToString();
            }
            else
            {
                stDS = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()), Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()));
                RepDetails.DataSource = stDS.Tables[0];
                RepDetails.DataBind();
                lblsuperzone.Text = stDS.Tables[2].Rows[0]["SuperZoneName"].ToString();
            }

        }

    }
    protected void RepDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label ZoneCode = (Label)e.Item.FindControl("ZoneCode");
        GridView grdSalesAnalysis = (GridView)e.Item.FindControl("grdSalesAnalysis");

        DataView dv = new DataView(stDS.Tables[1]);
        dv.RowFilter = " ZoneCode = '" + ZoneCode.Text.ToString().Trim()+ "'";
        grdSalesAnalysis.DataSource = dv;
        grdSalesAnalysis.DataBind();
    }

    protected void grdSalesAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            opbal = 0;
            dbamt = 0;
            cramt = 0;
            cnamt = 0;
            Balamt = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblopbal = (Label)e.Row.FindControl("lblopbal");
            opbal = opbal + Convert.ToDecimal(lblopbal.Text.Trim());
            Label lbldebtamt = (Label)e.Row.FindControl("lbldebtamt");
            dbamt = dbamt + Convert.ToDecimal(lbldebtamt.Text.Trim());
            Label lblcramt = (Label)e.Row.FindControl("lblcramt");
            cramt  = cramt + Convert.ToDecimal(lblcramt.Text.Trim());
            Label lblcnamt = (Label)e.Row.FindControl("lblcnamt");
            cnamt = cnamt + Convert.ToDecimal(lblcnamt.Text.Trim());
            Label lblbalamt = (Label)e.Row.FindControl("lblbalamt");
            Balamt = Balamt + Convert.ToDecimal(lblbalamt.Text.Trim());

            //Label lblamt = (Label)e.Row.FindControl("lblamt");
            //tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTopbal = (Label)e.Row.FindControl("lblTopbal");
            lblTopbal.Text = opbal.ToString().Trim();
            Label lblTBillamt = (Label)e.Row.FindControl("lblTBillamt");
            lblTBillamt.Text = dbamt.ToString().Trim();
            Label lblTRecdAmt = (Label)e.Row.FindControl("lblTRecdAmt");
            lblTRecdAmt.Text = cramt.ToString().Trim();
            Label lblTRetamt = (Label)e.Row.FindControl("lblTRetamt");
            lblTRetamt.Text = cnamt.ToString().Trim();
            Label lblTbalamt = (Label)e.Row.FindControl("lblTbalamt");
            lblTbalamt.Text = Balamt.ToString().Trim();

           
        }

    }
}
