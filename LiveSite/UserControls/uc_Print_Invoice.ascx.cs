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

public partial class UserControls_ODC_uc_Print_Invoice : System.Web.UI.UserControl
{

    #region Varables
    static DataSet stDS;
    static int quantity = 0; static int tbundle = 0;
    static decimal tamount = 0;
    static decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
     static int docnewno = 0;
     string RdBValue;
     DateTime fdate;
     DateTime tdate;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
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
        }
        if (!Page.IsPostBack)
        {
            txtFromDate.Focus();
            docno.InnerHtml = "Not Selected";
           // Rptrpending.DataSource = DCDetails.Get_DC_Completed_IsApproved(Convert.ToInt32(strFY));
         //   Rptrpending.DataBind();
           // pnlcity.Visible = false;
            RdlView.SelectedValue = "invoiceDate";
            Pnlcust.Visible = true;
            Pnldate.Visible = false;
            pnlDetails.Visible = false;
            BindPanel();
        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        stDS = new DataSet();
        pnlDetails.Visible = true;
        docno.InnerHtml = txtDocno.Text.Trim();
        stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "approved",Convert.ToInt32(strFY));
        RepDetailsApprove.DataSource = stDS.Tables[0];
        RepDetailsApprove.DataBind();
        
        // ((Label)((Button)(sender)).Parent.FindControl("lblfright")).Text = (stDS.Tables[1].Rows[0]["Freight"]).ToString();
        // ((Label)((Button)(sender)).Parent.FindControl("lbltax")).Text = (stDS.Tables[1].Rows[0]["Tax"]).ToString();
        //  ((Label)((Button)(sender)).Parent.FindControl("lbltotalamt")).Text = (stDS.Tables[1].Rows[0]["TotalAmount"]).ToString();
        string jv = "";
        if (RepDetailsApprove.Items.Count <= 0)
        {
            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_Print_Invoice1_btnapproval').style.display='none';";
        }
        else
        {
            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_Print_Invoice1_btnapproval').style.display='block';";

        }
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        loder1("wait..", "4000");

        ((Button)(sender)).Enabled = false;
        DCConfirmQtyDetails _objDCConfirmQtyDetails = new DCConfirmQtyDetails();
        DCMaster _objDCMaster = new DCMaster();


        try
        {
            _objDCConfirmQtyDetails.IsPrintInvoice = true;
            _objDCConfirmQtyDetails.CreatedBy = Convert.ToString(Session["UserName"]); 
            _objDCConfirmQtyDetails.SubDocId = Convert.ToDecimal(((Button)(sender)).CommandArgument.Trim());
            _objDCConfirmQtyDetails.AvailableQty = Convert.ToInt32(strFY);
            _objDCConfirmQtyDetails.Save_DC_PrintInvoiceDetails(1);

            //Rptrpending.DataSource = DCMaster.Get_ApprovedDocNo();
            //Rptrpending.DataBind();
            //Rptrpending.DataSource = DCDetails.Get_DC_Completed_IsApproved(Convert.ToInt32(strFY));
            //Rptrpending.DataBind();

            ((Button)(sender)).BackColor = System.Drawing.Color.Red;
            ((Button)(sender)).ForeColor = System.Drawing.Color.White;
            ((Button)(sender)).Enabled = true;
 ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/ReportInvoicePrint.aspx?d=" + docnewno + "&sd=" + ((Button)(sender)).CommandArgument.Trim() + "&type=with" + "')", true);
           // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/ReportInvoicePrint.aspx?d=" + docnewno + "&sd=" + //((Button)(sender)).CommandArgument.Trim() + "')", true);
        }


        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            ((Button)(sender)).Enabled = true;
        }
        //}
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/ReportInvoicePrint_New.aspx?d=" + docnewno + "&sd=" + ((Button)(sender)).CommandArgument.Trim() + "')", true);
        }


        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            ((Button)(sender)).Enabled = true;
        }
    }

 protected void btnWithoutDisc_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/ReportInvoicePrint.aspx?d=" + docnewno + "&sd=" + ((Button)(sender)).CommandArgument.Trim()+"&type=without" + "')", true);
        }


        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            ((Button)(sender)).Enabled = true;
        }
    }


    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void loder1(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    #endregion

    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
            tbundle = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblAqty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());
            Label lblBundle = (Label)e.Row.FindControl("lblBundles");
            tbundle = tbundle + Convert.ToInt32(lblBundle.Text.Trim().Length - 1);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
            lblamt1.Text = tamount.ToString().Trim();
            totalamount = Convert.ToDecimal(tamount.ToString().Trim());
            Label lblBundle1 = (Label)e.Row.FindControl("lblTotalBundles");
            lblBundle1.Text = tbundle.ToString().Trim() + "P";
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
        lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]) + "   ";
        lblcustname.InnerHtml = "  " + Convert.ToString(stDS.Tables[2].Rows[0]["CustDetails"]);
        lblspinstruction.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["SpInstruction"]);
        docnewno = Convert.ToInt32(stDS.Tables[2].Rows[0]["DocumentNo"]);
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
    protected void RepDetailsApprove_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void RdlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanel();


    }

    #region Bind Customer
    public void BindCustomer()
    {
        DDLCustomer.Items.Clear();
        //DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer");
        DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("printinvoice", Convert.ToInt32(strFY));
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("- Select Customer-", "0"));
    }
    #endregion
   
    protected void btncustomer_Click(object sender, EventArgs e)
    {
        Rptrpending.DataSource = DCMaster.Get_DC_Completed_IsApproved_ONOption(Convert.ToInt32(DDLCustomer.SelectedValue), "Customer",
             Convert.ToInt32(strFY),
             Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"));
        Rptrpending.DataBind();
      //  pnlconfirm.Visible = true;
        Panelrepeater.Visible = true;
        pnlDetails.Visible = false;
        Rptrpending.Visible = true;
        updateapprove.Update();
    }
    protected void btnDate_Click(object sender, EventArgs e)
    {
        string from = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtFromDate.Focus();
        }
        else
        {

            Rptrpending.DataSource = DCMaster.Get_DC_Completed_IsApproved_ONOption(0, "invoicedate", Convert.ToInt32(strFY), Convert.ToDateTime(from), Convert.ToDateTime(To));
            Rptrpending.DataBind();
            pnlradio.Visible = true;
            Panelrepeater.Visible = true;

            Rptrpending.Visible = true;
            updateapprove.Update();
           
            pnlDetails.Visible = false;
        }
    }

    #region Bind Panel 
    public void BindPanel()
    {
        RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Customer")
        {
            BindCustomer();
            Pnldate.Visible = false;
            //  pnlcity.Visible = false;
            Pnlcust.Visible = true;
            pnlDetails.Visible = false;
            Panelrepeater.Visible = false;
            Rptrpending.Visible = true;
            updateapprove.Update();
            //   pnlconfirm.Visible = false;
            //    DDLCustomer.Items.Insert(0, new ListItem("- Select Customer-", "0"));

        }
        if (RdBValue == "invoiceDate")
        {
            Pnldate.Visible = true;
            //  pnlcity.Visible = false;
            Pnlcust.Visible = false;
            pnlDetails.Visible = false;
            Rptrpending.Visible = true;
            Panelrepeater.Visible = false;

            updateapprove.Update();
            //    pnlconfirm.Visible = false;
		 txtFromDate.Text = "01/04/" + DateTime.Now.AddYears(-1).Year + "";
            	 txttoDate.Text = "31/03/" + DateTime.Now.Year + "";
            //txtFromDate.Text = "01/04/2014";
           // txttoDate.Text = "31/03/2015";
            //txtFromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            //txttoDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

        }
        //if (RdBValue == "All")
        //{
        //    Pnldate.Visible = false;
        //    //  pnlcity.Visible = false;
        //    Pnlcust.Visible = false;
        //    Rptrpending.Visible = true;
        //    Panelrepeater.Visible = true;

        //    Rptrpending.DataSource = DCDetails.Get_DC_Completed_IsApproved(Convert.ToInt32(strFY));
        //    Rptrpending.DataBind();
        //    updateapprove.Update();
        //    //  Bind_DDL_SuperZone();  
        //    //     pnlconfirm.Visible = true;
        //    pnlDetails.Visible = false;

        //}
    }
    #endregion
}
