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

public partial class UserControls_HelpDesk : System.Web.UI.UserControl
{
    #region Variables

    string customrcode = "";
    static DataSet ds = null;
    private static int quantity = 0;
    private static decimal tamount = 0;
    private static decimal totalamount = 0;
    string strFY;
    string strChetanaCompanyName = "cppl";
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();

            }
            //Response.Write(strFY);

        }
        else
        {
            Response.Redirect("_auth.aspx");
        }
        lnkMoreDc.Attributes.Add("Target", "_blank");
        LnkBtn.Attributes.Add("Target", "_blank");

        txtcustomer.Focus();
    }
    protected void btnGetRecords_Click(object sender, EventArgs e)
    {
        try
        {


            string Customer = txtcustomer.Text.Trim();
            customrcode = Customer.Split(':')[0].ToString();
            DataTable dt = new DataTable();
            dt = DCMaster.Get_Name(customrcode, "Customer").Tables[0];

            if (dt.Rows.Count > 0)
            {
                lblCustomerName.Text = dt.Rows[0]["CustName"].ToString();
                lblCustID.Text = dt.Rows[0]["CustID"].ToString();
            }
            else
            {
                lblCustomerName.Text = "No such customer found";
            }

            DataSet ds1 = new DataSet();
            ds = helpdesk.getAllHelpDesk(customrcode, strFY);


            //ds1 = Customer_cs.Idv_Chetana_Customer_BlackList(0,customrcode,"31-mar-"+DateTime.Now.Year.ToString(),0,1,2,0);

            RepCustomerDetails.DataSource = ds.Tables[0];
            RepCustomerDetails.DataBind();

            REpChetanaForcust.DataSource = ds.Tables[1];
            REpChetanaForcust.DataBind();

            RepChLstOrder.DataSource = ds.Tables[2];
            RepChLstOrder.DataBind();

            RepPayment.DataSource = ds.Tables[3];
            RepPayment.DataBind();


            RepPendingDC.DataSource = ds.Tables[5];
            RepPendingDC.DataBind();

            CustomerDiscount.DataSource = ds.Tables[6];
            CustomerDiscount.DataBind();

            rptConfirmed.DataSource = ds.Tables[7];
            rptConfirmed.DataBind();

            rptPOD.DataSource = ds.Tables[8];
            rptPOD.DataBind();

            if (CustomerDiscount.Items.Count > 0)
            {
                lblDiscMsg.Visible = false;
            }
            else
            {
                lblDiscMsg.Visible = true;
            }



            if (RepPendingDC.Items.Count > 0)
            {
                lnkMoreDc.Visible = true;
                LnkBtn.Visible = true;
            }
            else
            {
                lnkMoreDc.Visible = false;
                LnkBtn.Visible = false;

            }


            //  int custId = 0;
            //  if (ds.Tables[0].Rows.Count > 0)
            // {
            //     custId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            //}
            //ds1 = Customer_cs.Idv_Chetana_Customer_BlackList(custId, "HLPDSK", "31-mar-" + DateTime.Now.Year.ToString(), 0, Convert.ToInt32(strFY), 2, 0);


            //RepOutStanding.DataSource = ds1.Tables[0];
            //RepOutStanding.DataBind();
        }
        catch (Exception ex)
        {


        }


    }

    protected void RepChLstOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblDocNo = (Label)e.Item.FindControl("lblDocId");
            Repeater rep = (Repeater)e.Item.FindControl("RepSubDetails");
            DataView dv = new DataView(ds.Tables[4]);
            dv.RowFilter = "DocumentNo = " + lblDocNo.Text.Trim();
            rep.DataSource = dv;
            rep.DataBind();

        }

    }

    static DataSet stDS;
    protected void img01_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)(sender);
        if (img.CommandName.ToLower() == "p")
        {
            grdconfirm.DataSource = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(img.CommandArgument.Trim()),
            "helpdesk", Convert.ToInt32(0)).Tables[1];
            grdconfirm.DataBind();
            ModalPopUpDocNum.Show();
            UpdatePanel7.Update();
        }
        else
        {
            stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(img.CommandArgument.Trim()), "helpdesk",
            Convert.ToInt32(0));
            RepDetailsApprove.DataSource = stDS.Tables[0];
            RepDetailsApprove.DataBind();
            ModalPopupExtender1.Show();
            UpdatePanel8.Update();
        }


    }


    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        DataView dv = new DataView(stDS.Tables[1]);

        dv.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        //lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]) + "   ";
        //lblcustname.InnerHtml = "  " + Convert.ToString(stDS.Tables[2].Rows[0]["CustDetails"]);
        //lblspinstruction.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["SpInstruction"]);
        int docnewno = Convert.ToInt32(stDS.Tables[2].Rows[0]["DocumentNo"]);
        DataView dv1 = new DataView(stDS.Tables[1]);
        dv1.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        if (dv1.Count > 0)
        {
            ((Label)e.Item.FindControl("lblfright")).Text = dv1[0].Row["Freight"].ToString();
            ((Label)e.Item.FindControl("lbltax")).Text = dv1[0].Row["Tax"].ToString();
            decimal frt = Convert.ToDecimal(dv1[0].Row["Freight"].ToString());
            decimal tx = Convert.ToDecimal(dv1[0].Row["Tax"].ToString());
            decimal tamt = frt + tx + totalamount;
            ((Label)e.Item.FindControl("lbltotalamt")).Text = tamt.ToString();
        }
        else
        {
            ((Label)e.Item.FindControl("lblfright")).Text = "0";
            ((Label)e.Item.FindControl("lbltax")).Text = "0";
            ((Label)e.Item.FindControl("lbltotalamt")).Text = totalamount.ToString();
        }
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
            Label lbl = (Label)e.Row.FindControl("lblAqty");
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

    protected void lnkMoreDc_Click(object sender, EventArgs e)
    {
        string Customer = txtcustomer.Text.Trim();
        LinkButton lnk = (LinkButton)sender;
        if (lnk.CommandArgument == "pendingdc")
        {
            if (Customer != "")
            {
                customrcode = Customer.Split(':')[0].ToString();
                Response.Redirect("pendingDC_view.aspx?c=" + lblCustID.Text.Trim());
            }
        }
        else if (lnk.CommandArgument == "confirmed")
        {

            if (Customer != "")
            {
                customrcode = Customer.Split(':')[0].ToString();
                Response.Redirect("Helpdesk_GenerateInvoice.aspx?c=" + lblCustID.Text.Trim());
            }
        }
        else
        {
            customrcode = Customer.Split(':')[0].ToString();
            Response.Redirect("Helpdesk_GenerateInvoice.aspx?c=" + lblCustID.Text.Trim() + "&d=" + lnk.CommandArgument.ToString());

        }
    }
}
