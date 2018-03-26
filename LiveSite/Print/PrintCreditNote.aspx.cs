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
public partial class Print_PrintCreditNote : System.Web.UI.Page
{
    #region Variables
    static int CNNo = 0;
    static int strFY = 0;
    static int quantity = 0;
    static decimal tamount = 0;
    static decimal tnamount = 0;

    //static decimal amt = 0;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] != null && Request.QueryString["fy"] != null)
        {
            CNNo = (Convert.ToInt32(Request.QueryString["d"].ToString().Trim()));
            strFY = (Convert.ToInt32(Request.QueryString["fy"].ToString().Trim()));
            Todaydate.InnerHtml = DateTime.Now.ToString("dd/MM/yyyy");

            DataSet ds = new DataSet();
            ds = CreditNote.PrintCN(strFY, CNNo);
            if (ds.Tables[1].Rows.Count > 0)
            {
              //  lblCustName.Text = dt.Rows[0]["CustName"].ToString();
               // lblCustAddress.Text = dt.Rows[0]["Address"].ToString();
                CreatedOn.InnerHtml = ds.Tables[1].Rows[0]["CreatedOn"].ToString();
                crnno.InnerHtml = ds.Tables[1].Rows[0]["CNNo"].ToString();
                custname.InnerHtml = ds.Tables[1].Rows[0]["CustName"].ToString() + ",";
                custadd.InnerHtml = ds.Tables[1].Rows[0]["Address"].ToString();
            }
            Bindgrdcn();
        }
    }

    public void Bindgrdcn()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        grdPcn.DataSource = CreditNote.PrintCN(strFY, CNNo);
        grdPcn.DataBind();
    }
    //public void BindPrintCN()
    //{
    //    GrdSpecdetails.DataSource = SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "rtbk");
    //    GrdSpecdetails.DataBind();
    //}


    protected void grdPcn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
            tnamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty1 = (Label)e.Row.FindControl("lblqty");
            quantity = quantity + Convert.ToInt32(lblqty1.Text.Trim());
            Label lblamt1 = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt1.Text.Trim());
            Label lblnamt1 = (Label)e.Row.FindControl("lblnamt");
            tnamount = tnamount + Convert.ToDecimal(lblnamt1.Text.Trim());
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblqty2 = (Label)e.Row.FindControl("lbltqty");
            lblqty2.Text = quantity.ToString().Trim();
            Label lblamt2 = (Label)e.Row.FindControl("lbltamt");
            lblamt2.Text = tamount.ToString().Trim();
            Label lblnamt2 = (Label)e.Row.FindControl("lbltnamt");
            lblnamt2.Text = tnamount.ToString().Trim();
        }
    }
}
