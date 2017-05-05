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

public partial class Print_PrintInvoice : System.Web.UI.Page
{
    #region Variables
    static int quantity = 0;
    static decimal amt = 0;
    static decimal totalamount = 0;
    static decimal tamt = 0;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {
            DataSet ds = new DataSet();
            ds = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()), "approved");
            DataView dv = new DataView(ds.Tables[1]);
            dv.RowFilter = "SubConfirmID =" + Request.QueryString["sd"].ToString().Trim();
           // DocumentNo.InnerHtml = ds.Tables[1].Rows[0]["DocumentNo"].ToString();


            orderno.InnerHtml = ds.Tables[2].Rows[0]["OrderNo"].ToString();
            Todaydate.InnerHtml = DateTime.Now.ToString("dd/MM/yyyy");
            Subconfirmid.InnerHtml = Request.QueryString["sd"].ToString();
            custname.InnerHtml = ds.Tables[2].Rows[0]["CustName"].ToString()+",";
            custadd.InnerHtml = ds.Tables[2].Rows[0]["Address"].ToString().Replace(",", ",<br/>") + "  </br>  "
                                + ds.Tables[2].Rows[0]["City"].ToString() + ", " + ds.Tables[2].Rows[0]["State1"].ToString();
            spnaddress.InnerHtml = ds.Tables[2].Rows[0]["Zip"].ToString()  ;

            lblpersonincharge.InnerHtml =  ds.Tables[2].Rows[0]["PIncharge"].ToString()  ;
            // lbldate.InnerHtml =          ds.Tables[2].Rows[0]["PIncharge"].ToString()  ;
            LBLBUNDLES.InnerHtml = ds.Tables[1].Rows[0]["Bundles"].ToString();
            lbltransporter.InnerHtml = ds.Tables[1].Rows[0]["Transporter"].ToString();
            lrno.InnerHtml = ds.Tables[1].Rows[0]["LRNo"].ToString();
            grdapproval.DataSource = dv;
            grdapproval.DataBind();

            DataView dv1 = new DataView(ds.Tables[3]);
            dv1.RowFilter = "SubConfirmID = " + Request.QueryString["sd"].ToString().Trim();
            if (dv1.Count > 0)
            {
                lblfreight.InnerHtml = dv1[0].Row["Freight"].ToString();
                lbltax.InnerHtml = dv1[0].Row["Tax"].ToString();
                decimal frt = Convert.ToDecimal(dv1[0].Row["Freight"].ToString());
                decimal tx = Convert.ToDecimal(dv1[0].Row["Tax"].ToString());
                 tamt = frt + tx + totalamount;
                Lbltotalamt.InnerHtml = tamt.ToString(); 
            }
            else
            {
                 lblfreight.InnerHtml = "0";
                 lbltax.InnerHtml = "0";
                 Lbltotalamt.InnerHtml = totalamount.ToString(); 
            }
           DataSet ds1 = new DataSet();
           ds1 = ActualInvoiceDetails.GetConvertion_fromnumber(tamt);
           lblrupees.InnerHtml = ds1.Tables[0].Rows[0][0].ToString() + " Only";



        }
    }
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            amt = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblqunty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt1 = (Label)e.Row.FindControl("lblAmount");
            amt = amt + Convert.ToDecimal(lblamt1.Text.Trim());
            lblamt1.Text = Convert.ToDecimal(lblamt1.Text.Trim()).ToString("0.00");
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalQty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt = (Label)e.Row.FindControl("lblTotalQty12");
            lblamt.Text = amt.ToString("0.00");
            totalamount = Convert.ToDecimal(amt.ToString().Trim());
        }
    }
}
