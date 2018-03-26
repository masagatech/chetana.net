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

public partial class Print_PrintApproveDC : System.Web.UI.Page
{
    #region Variables
    static int quantity = 0;
    static decimal tamount = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {
            DataSet ds = new DataSet();
            DataSet dsTransporter = SpecimanDetails.Get_SpecTransporterAndDetails(Convert.ToDecimal(Request.QueryString["sd"].ToString().Trim()), "approved");
            ds = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()), "approved");
            DataView dv = new DataView(ds.Tables[1]);
            dv.RowFilter = "SubConfirmID = " + Request.QueryString["sd"].ToString().Trim();
            DocumentNo.InnerHtml = ds.Tables[1].Rows[0]["DocumentNo"].ToString();
            Todaydate.InnerHtml = DateTime.Now.ToString("dd/MM/yyyy");
            Subconfirmid.InnerHtml = Request.QueryString["sd"].ToString();
            empname.InnerHtml = ds.Tables[2].Rows[0][0].ToString() + " " + ds.Tables[2].Rows[0][1].ToString() + " " + ds.Tables[2].Rows[0][2].ToString();
            spnaddress.InnerHtml = ds.Tables[2].Rows[0]["Address"].ToString().ToUpper() + "</br> " + ds.Tables[2].Rows[0]["City"].ToString().ToUpper() + ", " + ds.Tables[2].Rows[0]["State"].ToString().ToUpper();
            SpInstruction.InnerHtml =  ds.Tables[2].Rows[0]["SpInstruction"].ToString();
            Description.InnerHtml =  ds.Tables[2].Rows[0]["Description"].ToString();

            lbltransporter.InnerHtml = dsTransporter.Tables[0].Rows[0]["Transporter"].ToString();
            lbllrno.InnerHtml = dsTransporter.Tables[0].Rows[0]["LrNo"].ToString();
            lblbundles.InnerHtml = dsTransporter.Tables[0].Rows[0]["Bundles"].ToString();

            grdapproval.DataSource = dv;
            grdapproval.DataBind();
            DataSet ds1 = new DataSet();
            ds1 = ActualInvoiceDetails.GetConvertion_fromnumber(tamount);
            lblrupees.InnerHtml = ds1.Tables[0].Rows[0][0].ToString() + " Only";


        }
    }
    
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblqunty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim()); 
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
          Label lbl1 = (Label)e.Row.FindControl("lblTotalQty");
          lbl1.Text = quantity.ToString().Trim();
          Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
          lblamt1.Text = tamount.ToString().Trim();
        }
    }
}
