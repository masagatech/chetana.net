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
using Idv.Chetana.CnF;


public partial class CNF_uc_CnFPrintInvoice : System.Web.UI.UserControl
{
    string strFY = "0";
    DataSet stDS;
    int quantity = 0;
    decimal tamount = 0;
    decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";

    int docnewno = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != "" || Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
        }
        if (!Page.IsPostBack)
        {
            BindInvoice();
            pnlDetails.Visible = false;
        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = true;
        stDS = new DataSet();
        docno.InnerHtml = txtDocno.Text.Trim();
        stDS = CnFInvoice.GetInvoiceDetails(Convert.ToInt32(txtDocno.Text), "print", Convert.ToInt32(strFY));

        RepDetailsApprove.DataSource = stDS.Tables[1];
        RepDetailsApprove.DataBind();

    }

    public void BindInvoice()
    {
        Rptrpending.DataSource = CnFInvoice.GetInvoiceNos(Convert.ToInt32(strFY));
        Rptrpending.DataBind();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('CNF/print/CPrintInvoice.aspx?d=" + ((Button)(sender)).CommandArgument.Trim() + "&fy=" + strFY + "&type=with" + "')", true);

    }

    protected void btnform_Click(object sender, EventArgs e)
    {

    }

    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblqunty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
            lblamt1.Text = tamount.ToString().Trim();
            totalamount = Convert.ToDecimal(tamount.ToString().Trim());
        }
    }

    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        DataView dv = new DataView(stDS.Tables[0]);

        dv.RowFilter = "DocumentNo = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        //lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]) + "   ";
        //lblcustname.InnerHtml = "  " + Convert.ToString(stDS.Tables[2].Rows[0]["CustDetails"]);
        //lblspinstruction.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["SpInstruction"]);
        //docnewno = Convert.ToInt32(stDS.Tables[2].Rows[0]["DocumentNo"]);
        //DataView dv1 = new DataView(stDS.Tables[1]);
        //dv1.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        //if (dv1.Count > 0)
        //{
        //    ((Label)e.Item.FindControl("lblfright")).Text = dv1[0].Row["Freight"].ToString();
        //    ((Label)e.Item.FindControl("lbltax")).Text = dv1[0].Row["Tax"].ToString();
        //    decimal frt = Convert.ToDecimal(dv1[0].Row["Freight"].ToString());
        //    decimal tx = Convert.ToDecimal(dv1[0].Row["Tax"].ToString());
        //    decimal tamt = frt + tx + totalamount;
        //    ((Label)e.Item.FindControl("lbltotalamt")).Text = tamt.ToString();
        //}
        //else
        //{
        //    ((Label)e.Item.FindControl("lblfright")).Text = "0";
        //    ((Label)e.Item.FindControl("lbltax")).Text = "0";
        //    ((Label)e.Item.FindControl("lbltotalamt")).Text = totalamount.ToString();
        //}

    }
    protected void RepDetailsApprove_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

}
