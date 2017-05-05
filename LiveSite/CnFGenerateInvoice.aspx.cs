using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Add Name Space
using System.Data;
using System.Configuration;
using Idv.Chetana.BAL;
using Chetana_SMS;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text;

public partial class CnFGenerateInvoice : System.Web.UI.Page
{
    #region Goloval Variable
    DataSet stDS;
    int quantity = 0;
    //    decimal tamount = 0;
    decimal totalamount = 0;
    decimal temp;
    decimal frieght = 0;
    decimal tax = 0;
    //string date;
    decimal Finalamount = 0;
    int tabindex = 20;
    string Smailid;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string flag1;
    Label lblAqty;
    TextBox txtrate;
    Label lblAmt;
    TextBox lbldisc;
    //static string SMSSend = string.Empty;
    string sHtml = "SMS Not Sent, Number Not Present";

    string lrno = string.Empty;
    string lrdt = string.Empty;
    string bund = string.Empty;
    string Invno = string.Empty;
    string grdcount = string.Empty;
    string tqty = string.Empty;
    #endregion

    #region Page Load Event
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
            ViewState["cname"] = null;
            SMSSend.Text = "NO";
            if (ConfigurationManager.AppSettings["SMS_INV_SEND"] != null)
            {
                SMSSend.Text = ConfigurationManager.AppSettings["SMS_INV_SEND"].ToString();
            }


            Session["saved"] = null;
            docno.InnerHtml = "Not Selected";
            //Rptrpending.DataSource = DCMaster.Get_ApprovedDocNo(Convert.ToInt32(strFY));
            Rptrpending.DataSource = DCMaster.Get_ApprovedDocNo(Convert.ToInt32(strFY));
            Rptrpending.DataBind();
        }
    }
    #endregion

    #region Message Box
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Text Changed Events

    protected void lbltransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if ((((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text) != "")
            {
                string TransCode = (((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text.ToString().Split(':', '[', ']')[0].Trim());
                flag1 = (((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text.ToString().Split('[', ']')[1].Trim());

                if (flag1 == "Emp")
                {
                    string Empname = (((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text.ToString().Split(':', '[')[2].Trim());
                    (((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text) = Empname;
                }
                else if (flag1 == "Trans")
                {
                    (((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text) = TransCode;
                }
                else
                {
                    (((TextBox)((TextBox)(sender)).Parent.FindControl("lbltransporter")).Text) = "No such record found";
                }

            }
        }

        catch
        {

        }
    }
    protected void txtfrieght_TextChanged(object sender, EventArgs e)
    {
        if ((((TextBox)((TextBox)(sender)).Parent.FindControl("txtfrieght")).Text) != "")
        {
            frieght = Convert.ToDecimal(((TextBox)((TextBox)(sender)).Parent.FindControl("txtfrieght")).Text);
        }
        else
        {
            (((TextBox)((TextBox)(sender)).Parent.FindControl("txtfrieght")).Text) = "0";
        }
        if ((((TextBox)((TextBox)(sender)).Parent.FindControl("txttax")).Text) != "")
        {
            tax = Convert.ToDecimal(((TextBox)((TextBox)(sender)).Parent.FindControl("txttax")).Text);
        }
        if ((((Label)((TextBox)(sender)).Parent.FindControl("lbltotalAmtget")).Text) != "")
        {
            temp = Convert.ToDecimal(((Label)((TextBox)(sender)).Parent.FindControl("lbltotalAmtget")).Text) + frieght + tax;
        }

        totalamount = Convert.ToDecimal(temp);
        ((Label)((TextBox)(sender)).Parent.FindControl("lbltotalamt")).Text = totalamount.ToString();
        ((TextBox)((TextBox)(sender)).Parent.FindControl("txttax")).Focus();
    }
    protected void txttax_TextChanged(object sender, EventArgs e)
    {

        if ((((TextBox)((TextBox)(sender)).Parent.FindControl("txtfrieght")).Text) != "")
        {
            frieght = Convert.ToDecimal(((TextBox)((TextBox)(sender)).Parent.FindControl("txtfrieght")).Text);
        }
        if ((((TextBox)((TextBox)(sender)).Parent.FindControl("txttax")).Text) != "")
        {
            tax = Convert.ToDecimal(((TextBox)((TextBox)(sender)).Parent.FindControl("txttax")).Text);
        }
        if ((((Label)((TextBox)(sender)).Parent.FindControl("lbltotalAmtget")).Text) != "")
        {
            temp = Convert.ToDecimal(((Label)((TextBox)(sender)).Parent.FindControl("lbltotalAmtget")).Text) + frieght + tax;
        }

        totalamount = Convert.ToDecimal(temp);
        ((Label)((TextBox)(sender)).Parent.FindControl("lbltotalamt")).Text = totalamount.ToString();

        ((Button)((TextBox)(sender)).Parent.FindControl("btnConfirmed")).Focus();
    }

    #endregion

    #region Button Repiter Control Click Event
    protected void btnget_Click(object sender, EventArgs e)
    {
        stDS = new DataSet();

        docno.InnerHtml = txtDocno.Text.Trim();
        stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed", Convert.ToInt32(strFY));
        ViewState["staticDS"] = stDS;
        RepDetailsConfirm.DataSource = stDS.Tables[0];
        RepDetailsConfirm.DataBind();
        lblmessage.InnerHtml = "";

    }
    #endregion

    #region Button Confirm Click Event But Hide Button 
    protected void btnapproval_Click(object sender, EventArgs e)
    {

        if (ConfigurationManager.AppSettings["EMAIL_INV_SEND"] != null)
        {
            if (ConfigurationManager.AppSettings["EMAIL_INV_SEND"].ToLower() == "yes")
            {
                try
                {
                    if (lblEmail.Text != "" || lblEmail.Text != "noContact")
                    {
                        Button btn = (Button)sender;
                        GridView grdview = (GridView)btn.Parent.FindControl("grdapproval");
                        grdcount = Convert.ToString(grdview.Rows.Count);
                        tqty = ((Label)grdview.FooterRow.FindControl("lblTotalqty")).Text;
                        Invno = ((Label)btn.Parent.FindControl("SubConfirmID")).Text;
                        lrno = ((TextBox)btn.Parent.FindControl("txtlrno")).Text;
                        lrdt = ((TextBox)btn.Parent.FindControl("txtdateabc")).Text;
                        bund = ((TextBox)btn.Parent.FindControl("txtbundles")).Text;
                        string EmailID = lblEmail.Text.Trim();
                        //EmailTask_Delegate d = null;
                        //d = new EmailTask_Delegate(SendEmail);

                        //IAsyncResult R = null;
                        //R = d.BeginInvoke(EmailID, null, null);
                        //d.EndInvoke(R);    
                        sendmail("Chetana Book Depot", EmailID, MailBodyDesign().ToString());
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
    #endregion

    #region Button Click Confirm And Print But Hide
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        this.btnapproval_Click(sender, e);

    }
    #endregion

    #region Grid and repeater

    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtFright = null;
        TextBox txttax = null;
        Label lbltotalamt = null;
        Label lbltotalAmtget = null;
        txtFright = (TextBox)e.Item.FindControl("txtfrieght");
        txttax = (TextBox)e.Item.FindControl("txttax");
        lbltotalamt = (Label)e.Item.FindControl("lbltotalamt");
        lbltotalAmtJS = (Label)e.Item.FindControl("lbltotalAmtJS");

        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        if (ViewState["staticDS"] != null)
        {
            stDS = (DataSet)ViewState["staticDS"];
        }
        else
        {
            stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed", Convert.ToInt32(strFY));
            ViewState["staticDS"] = stDS;
        }
        DataView dv = new DataView(stDS.Tables[1]);
        dv.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        int ID = Convert.ToInt32(stDS.Tables[2].Rows[0]["CustID"]);
        lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]) + "   ";
        lblcustname.InnerHtml = "  " + Convert.ToString(stDS.Tables[2].Rows[0]["CustDetails"]);
        ViewState["cname"] = Convert.ToString(stDS.Tables[2].Rows[0]["CustDetails"]);
        lblEmail.Text = Convert.ToString(stDS.Tables[2].Rows[0]["Email"]);
        lblMobNo.Text = Convert.ToString(stDS.Tables[2].Rows[0]["mobNo"]);

        ((TextBox)e.Item.FindControl("txtdateabc")).Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtfrieght.Text = "0";
        txttax.Text = "0";
        ((Label)e.Item.FindControl("LblRemark")).Text = stDS.Tables[2].Rows[0]["Remark"].ToString();
        ((Label)e.Item.FindControl("lblCustId1")).Text = stDS.Tables[2].Rows[0]["CustId"].ToString();
        //Updated By Rupesh 17/10/2014
        ((TextBox)e.Item.FindControl("txtbundles")).Text = stDS.Tables[1].Rows[0]["Bundles"].ToString();
        //

        DataSet ds7 = G_GetPass.CustEMail_LocalEntry(ID);
        ViewState["SEmailid"] = Convert.ToString(ds7.Tables[0].Rows[0]["SEmailID"]);
        lbltotalamt.Text = tamount.Text.ToString();

        if (stDS.Tables[2].Rows.Count > 0)
        {
            ((TextBox)e.Item.FindControl("lbltransporter")).Text = stDS.Tables[2].Rows[0]["Transporter"].ToString();
        }
        lbltotalAmtJS.Text = tamount.Text.ToString();
        txtfrieght.Attributes.Add("onkeyup", "sumCharges('" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lbltotalAmtJS.ClientID + "','" + lbltotalamt.ClientID + "')");
        txttax.Attributes.Add("onkeyup", "sumCharges('" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lbltotalAmtJS.ClientID + "','" + lbltotalamt.ClientID + "')");
    }

    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount.Text = "0";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalAmtForFright = (Label)e.Row.Parent.Parent.Parent.FindControl("lbltotalAmtget");
            Label lblTotalAmtForFrightorg = (Label)e.Row.Parent.Parent.Parent.FindControl("lbltotalamt");
            Label lbltotalAmtJS = (Label)e.Row.Parent.Parent.Parent.FindControl("lbltotalAmtJS");

            TextBox txtfrieght = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txtfrieght");
            TextBox txttax = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txttax");


            lblAqty = (Label)e.Row.FindControl("lblAqty");
            txtrate = (TextBox)e.Row.FindControl("txtrate");
            lbldisc = (TextBox)e.Row.FindControl("txtdiscount");
            lblAmt = (Label)e.Row.FindControl("lblamt");
            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + lblAqty.ClientID + "','" + txtrate.ClientID + "','" + lbldisc.ClientID + "','" + lblAmt.ClientID + "','" + ((GridView)(sender)).ClientID + "','" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lblTotalAmtForFright.ClientID + "','" + lblTotalAmtForFrightorg.ClientID + "','" + lbltotalAmtJS.ClientID + "')");
            lbldisc.Attributes.Add("onkeyup", "multiplyQty('" + lblAqty.ClientID + "','" + txtrate.ClientID + "','" + lbldisc.ClientID + "','" + lblAmt.ClientID + "','" + ((GridView)(sender)).ClientID + "','" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lblTotalAmtForFright.ClientID + "','" + lblTotalAmtForFrightorg.ClientID + "','" + lbltotalAmtJS.ClientID + "')");
            Label lbl = (Label)e.Row.FindControl("lblAqty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount.Text = Convert.ToString(Convert.ToDecimal(tamount.Text.Trim()) + Convert.ToDecimal(lblamt.Text.Trim()));

            lblTotalAmtForFright.Text = tamount.Text.ToString().Trim();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            lbl1.Attributes.Add("class", ((GridView)(sender)).ClientID + "qty");
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
            lblamt1.Text = tamount.Text.ToString().Trim();
            lblamt1.Attributes.Add("class", ((GridView)(sender)).ClientID + "amt");
        }
    }

    protected void RepDetailsConfirm_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Session["saved"] == null)
        {
            Session["saved"] = "s";
        }

        if (Session["saved"].ToString() != e.CommandArgument.ToString().Trim())
        {
            //if (e.CommandName == "AddToCart")
            {
                bool Auth = DCMaster.Get_DocumentNum_Authentication(Convert.ToInt32(txtDocno.Text), Convert.ToInt32(strFY));
                if (Auth)
                {
                    MessageBox("Document no is not available");
                    txtDocno.Focus();

                }
                else
                {

                    DCConfirmQtyDetails _objDCConfirmQtyDetails = new DCConfirmQtyDetails();
                    DCMaster _objDCMaster = new DCMaster();
                    DCConfirmQtyDetails _objDCFT = new DCConfirmQtyDetails();
                    ActualInvoiceDetails _objactualinvoice = new ActualInvoiceDetails();

                    try
                    {
                        #region ActulInvoice
                        Repeater objrep = (Repeater)this.FindControl("RepDetailsConfirm");
                        GridView objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdapproval");

                        foreach (GridViewRow row in objgrid.Rows)
                        {
                            _objactualinvoice.DocumentNo = Convert.ToInt32(txtDocno.Text);
                            _objactualinvoice.SubDocId = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                            _objactualinvoice.BookCode = ((Label)row.FindControl("lblbookC")).Text;
                            _objactualinvoice.BookName = ((Label)row.FindControl("lblbookN")).Text;
                            _objactualinvoice.Standard = ((Label)row.FindControl("lblStandard")).Text;
                            _objactualinvoice.Medium = ((Label)row.FindControl("lblMedium")).Text;
                            _objactualinvoice.Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
                            _objactualinvoice.Quantity = Convert.ToInt32(((Label)row.FindControl("lblAqty")).Text);
                            _objactualinvoice.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtdiscount")).Text);
                            _objactualinvoice.Amount = Convert.ToInt32(((Label)row.FindControl("lblAqty")).Text) * (Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) - (Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Convert.ToDecimal(((TextBox)row.FindControl("txtdiscount")).Text) / 100));
                            _objactualinvoice.Freight = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text);
                            _objactualinvoice.Tax = Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                            _objactualinvoice.Transporter = (((TextBox)e.Item.FindControl("lbltransporter")).Text);
                            _objactualinvoice.LRNo = (((TextBox)e.Item.FindControl("txtlrno")).Text);
                            _objactualinvoice.TotalAmount = Convert.ToDecimal(getTotalValues(objgrid).ToString()) + Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text) + Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                            _objactualinvoice.Bundles = (((TextBox)e.Item.FindControl("txtbundles")).Text);
                            _objactualinvoice.CreatedBy = Convert.ToString(Session["UserName"]);
                            _objactualinvoice.FinancialYearFrom = strFY;

                            TextBox txtIdate1 = ((TextBox)e.Item.FindControl("txtdateabc"));
                            TextBox txtLrdate1 = ((TextBox)e.Item.FindControl("txtlrdate"));
                            _objactualinvoice.IsActive = true;
                            _objactualinvoice.IsDeleted = false;
                            string date1;
                            string lrdate;
                            if (txtIdate1.Text == "")
                            {
                                date1 = "1/1/2001";
                            }
                            else
                            {
                                date1 = txtIdate1.Text.Split('/')[2] + "/" + txtIdate1.Text.Split('/')[1] + "/" + txtIdate1.Text.Split('/')[0];
                            }
                            if (txtLrdate1.Text == "")
                            {
                                lrdate = "1/1/2001";
                            }
                            else
                            {
                                lrdate = txtLrdate1.Text.Split('/')[2] + "/" + txtLrdate1.Text.Split('/')[1] + "/" + txtLrdate1.Text.Split('/')[0];
                            }
                            _objactualinvoice.InvoiceDate = Convert.ToDateTime(date1);

                            _objactualinvoice.LRDate = Convert.ToDateTime(lrdate);
                            _objactualinvoice.Remark1 = "";
                            _objactualinvoice.Remark2 = "";
                            _objactualinvoice.Remark3 = "";
                            _objactualinvoice.SaveActual_InvoiceDetails(1);
                            // (TextBox)e.Item.FindControl("txtfrieght");
                        }

                        #endregion

                        #region InvoiceCreate
                        decimal subconfirmdoc = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                        _objDCConfirmQtyDetails.IsCreateInvoice = true;
                        _objDCConfirmQtyDetails.CreatedInvoiceBy = Convert.ToString(Session["UserName"]);
                        _objDCConfirmQtyDetails.SubDocNo = subconfirmdoc;
                        // For financial year
                        _objDCConfirmQtyDetails.AvailableQty = Convert.ToInt32(strFY);
                        _objDCMaster.DocNo = Convert.ToInt32(txtDocno.Text);

                        // Save Freight and tax Details   
                        frieght = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text);
                        tax = Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                        temp = Convert.ToDecimal(tamount.Text) + frieght + tax;
                        totalamount = Convert.ToDecimal(tamount.Text);

                        _objDCFT.DocumentNo = Convert.ToInt32(txtDocno.Text);
                        _objDCFT.SubDocNo = subconfirmdoc;
                        _objDCFT.Freight = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text);
                        _objDCFT.Tax = Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                        decimal TotalAmt = Convert.ToDecimal(getTotalValues(objgrid).ToString()) + Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text) + Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                        _objDCFT.TotalAmount = Convert.ToDecimal(getTotalValues(objgrid).ToString()) + Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text) + Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                        _objDCFT.LRNo = (((TextBox)e.Item.FindControl("txtlrno")).Text);
                        TextBox txtIdate = ((TextBox)e.Item.FindControl("txtdateabc"));
                        string date;
                        if (txtIdate.Text == "")
                        {
                            date = "1/1/2001";
                        }
                        else
                        {
                            date = txtIdate.Text.Split('/')[2] + "/" + txtIdate.Text.Split('/')[1] + "/" + txtIdate.Text.Split('/')[0];
                        }
                        _objDCFT.InvoiceDate = Convert.ToDateTime(date);
                        _objDCFT.AvailableQty = Convert.ToInt32(strFY);
                        _objDCFT.Save_FrightTax_Details(1);


                        _objDCConfirmQtyDetails.SaveConfirmDetails(1);

                        stDS = new DataSet();
                        docno.InnerHtml = txtDocno.Text.Trim();
                        // stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed", Convert.ToInt32(strFY));

                        //if (ViewState["staticDS"] != null)
                        //{
                        //    stDS = (DataSet)ViewState["staticDS"];
                        //}
                        //else
                        //{
                        stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed", Convert.ToInt32(strFY));

                        //}


                        RepDetailsConfirm.DataSource = stDS.Tables[0];
                        RepDetailsConfirm.DataBind();
                        #endregion

                        MessageBox("Invoice created successfully " + subconfirmdoc);

                        lblmessage.InnerHtml = "Last confirm doc no. : " + subconfirmdoc;

                        if (e.CommandName == "PrintInvoice")
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/ReportInvoicePrint.aspx?d=" + txtOrgDocNo.Text + "&sd=" + subconfirmdoc + "&type=with" + "')", true);
                        }


                        if (Rptrpending.Items.Count == 1)
                        {
                            Rptrpending.DataSource = DCMaster.Get_ApprovedDocNo(Convert.ToInt32(strFY));
                            Rptrpending.DataBind();
                            //updateapprove.Update();
                        }
                        if (RepDetailsConfirm.Items.Count == 0)
                        {
                            Rptrpending.DataSource = DCMaster.Get_ApprovedDocNo(Convert.ToInt32(strFY));
                            Rptrpending.DataBind();
                            upDocNo.Update();
                            docno.InnerHtml = "";
                            lblcustname.InnerHtml = "";
                            lblempname1.InnerHtml = "";
                            //updateapprove.Update();
                        }
                        if (SMSSend.Text.ToUpper() == "YES")
                        {
                            sendMsg(lblMobNo.Text.Trim(), subconfirmdoc.ToString(), string.Format("{0:0.00}", TotalAmt).ToString(),
                                (((TextBox)e.Item.FindControl("lbltransporter")).Text),
                                (((TextBox)e.Item.FindControl("txtlrno")).Text),
                                (((TextBox)e.Item.FindControl("txtbundles")).Text),
                                txtIdate.Text.Trim());
                        }

                    }
                    catch (SqlException ex)
                    {
                        Response.Write(ex.Message.ToString());
                    }
                    catch (Exception ex1)
                    {
                        Response.Write(ex1.Message.ToString());
                    }

                }
            }
        }

        ViewState["staticDS"] = null;
        Session["saved"] = e.CommandArgument.ToString().Trim();
        updategenerate.Update();
    }

    #endregion

    #region Get Total Ammount

    public string getTotalValues(GridView grdInvoice)
    {
        int Qty = 0;
        decimal discount = 0;
        decimal rate = 0;
        decimal Totaldiscount = 0;
        decimal Totalrate = 0;
        decimal TotalAmount1 = 0;
        Finalamount = 0;
        foreach (GridViewRow row in grdInvoice.Rows)
        {
            Finalamount = Finalamount + Convert.ToDecimal(((Label)row.FindControl("lblamt")).Text);
            if (((TextBox)row.FindControl("txtrate")).Text != "")
            {
                rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
            }
            else
            {
                rate = 0;
            }
            if (((TextBox)row.FindControl("txtdiscount")).Text != "")
            {
                discount = Convert.ToDecimal(((TextBox)row.FindControl("txtdiscount")).Text);
            }
            else
            {
                discount = 0;
            }


            Qty = Convert.ToInt32(((Label)row.FindControl("lblAqty")).Text);
            TotalAmount1 = TotalAmount1 + Qty * (rate - (rate * discount / 100));
            //    Totalrate = rate;
            //    Totaldiscount = discount;
        }
        // TotalAmount1 = (Totalrate * Qty) - ((Totalrate * Qty) * (Totaldiscount / 100));
        return TotalAmount1.ToString();
    }

    #endregion

    #region  SmsDetails

    public void sendMsg(string MobNo, string InvNo, string Amt, string Trans, string LR, string Bundles, string InDate)
    {
        try
        {

            if (MobNo.ToLower() != "nocontact")
            {
                SMS_Client obj = new SMS_Client();
                obj.MobileNo = MobNo;
                //obj.MobileNo = "9987984488,9762514468";
                obj.Msg = ConfigurationManager.AppSettings["SMS_INV"].ToString().Replace("@1", InvNo).Replace("@2", Amt).Replace("@3", Trans).Replace("@4", LR).Replace("@5", Bundles).Replace("@6", InDate);
                //"Invoice No: 1908.01 of amt 40000.00 has been generated on 09/08/2012.- Chetana publication";
                HttpWebRequest request;
                HttpWebResponse response = null;
                Stream stream = null;
                request = (HttpWebRequest)WebRequest.Create("http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=CHETANAPUB&password=43425045&sendername=chetna&mobileno=" + obj.MobileNo + "&message=" + obj.Msg + "");
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.Default);
                sHtml = sr.ReadToEnd();
                //"Invoice No: 1908.01 of amt 40000.00 has been generated on 09/08/2012.- Chetana publication";
                obj.SendSMS();
                //obj.SendSMS();
            }
        }
        catch (Exception ex)
        {


        }
    }

    public void sendZoalMsg(string cust, string custName, string MobNo, string InvNo, string Amt, string Trans, string LR, string Bundles, string InDate)
    {
        try
        {


            DataTable rd = Other.IdvChetana_EmailSms(Convert.ToInt32(cust), "", "").Tables[0];
            if (rd.Rows.Count > 0)
            {
                if (rd.Rows[0][0].ToString().ToLower() != "nocontact")
                {
                    SMS_Client obj = new SMS_Client();
                    obj.MobileNo = rd.Rows[0][0].ToString();
                    if (custName.Length > 10)
                    {
                        custName = custName.Substring(0, 10);
                    }
                    obj.Msg = ConfigurationManager.AppSettings["SMS_ZONE"].ToString().Replace("@1", custName).Replace("@2", InvNo).Replace("@3", Amt).Replace("@4", Trans).Replace("@5", LR).Replace("@6", Bundles).Replace("@6", InDate);
                    //"Invoice No: 1908.01 of amt 40000.00 has been generated on 09/08/2012.- Chetana publication";
                    obj.SendSMS();
                }
            }
        }
        catch (Exception ex)
        {


        }
    }

    #endregion

    #region sendemail

    public void SendEmail(string email)
    {
        mailsend.sendmail("Chetana Book Depot", email, MailBodyDesign().ToString());
    }


    #endregion

    #region MailBody

    public StringBuilder MailBodyDesign()
    {
        string name = ViewState["cname"].ToString();

        StringBuilder stBody = new StringBuilder();

        stBody.Append(" <HTML>");
        stBody.Append(" <body><table id=body_holder border=0 cellpadding=0 cellspacing=0 width=100%>");
        stBody.Append(" <tbody><tr><td>");
        stBody.Append(" <table bgcolor=#e1e7e8 border=0 cellpadding=0 cellspacing=0 width=100%> ");
        stBody.Append(" <tbody><tr><td><table align=center border=0 cellpadding=0 cellspacing=0 width=600>");
        stBody.Append(" <tbody>");
        stBody.Append(" <tr><td style=margin: 0px; padding: 0px 10px; font-family: Tahoma'; font-size: 11px; color: rgb(70, 83, 85); text-align: left;>  </td>  ");
        stBody.Append(" </tr></tbody></table>");
        stBody.Append(" <table align=center border=0 cellpadding=0 cellspacing=0 width=600> ");
        stBody.Append(" <tbody><tr><td valign=top><table border=0 cellpadding=0 cellspacing=0 width=100%>");
        stBody.Append(" <tbody><tr><td style=padding: 0px 10px; valign=top> ");
        stBody.Append(" <table style=font-family: Tahoma, 'Verdana';  border=0 cellpadding=10 cellspacing=0 width=100%> ");
        stBody.Append(" <tbody>");
        stBody.Append(" <tr><td></td></tr>");
        stBody.Append(" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1>Chetana Invoice Mail</h1></u>");
        stBody.Append(" 263-C, KHATAUWADI, GOREGAONKAR LANE, BEHIND CENTRAL CINEMA, GIRGAON MUMBAI");
        stBody.Append(" PHONES : 2386 70 90.  DATE OF INCORP-, 5TH OCT.1989 Fax No : 2382 19 10<br/></td></tr> ");
        stBody.Append("<tr>");
        stBody.Append(" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
        stBody.Append(" <table cellpadding=5 cellspacing=5 >");
        stBody.Append(" <tr><td><b>Customer Name :</b></td><td>" + name + "</td></tr>");
        stBody.Append(" <tr><td><b>Invoice No :</b></td><td>" + Invno + "</td></tr> ");
        stBody.Append(" <tr><td><b>Total Books :</b></td><td>" + grdcount + "</td></tr> ");
        stBody.Append(" <tr><td><b>Total Qty :</b></td><td>" + tqty + "</td></tr> ");
        stBody.Append(" <tr><td><b>LR No :</b></td><td>" + lrno + "</td></tr>");
        stBody.Append(" <tr><td><b>LR Date :</b></td><td>" + lrdt + "</td></tr>");
        stBody.Append(" <tr><td><b>Bundles :</b></td><td>" + bund + "</td></tr>");
        stBody.Append(" <tr><td><b>Freight :</b></td><td>" + txtfrieght.Text + "</td></tr>");
        stBody.Append(" <tr><td><b>Tax :</b></td><td>" + txttax.Text + "</td></tr>");
        stBody.Append(" <tr><td><b>Total Amount :</b></td><td>" + lbltotalamt.Text + "</td></tr>");
        stBody.Append(" </table>");
        stBody.Append(" </td></tr></tbody></table><br/></td>");
        stBody.Append(" </tr></tbody></table></td>");
        stBody.Append(" </tr></tbody></table></td>");
        stBody.Append(" </tr></tbody></table></td>");
        stBody.Append(" </tr></tbody></table>");
        stBody.Append(" </body>");
        stBody.Append(" </body>");
        stBody.Append(" </html>");

        return stBody;

    }

    #endregion
    public void sendmail(string subject, string tomail, string body)
    {
        string Smailid = ViewState["SEmailid"].ToString();
        SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"].ToString());
        client.UseDefaultCredentials = false;
        client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Enablessl"].ToString());
        client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

        MailAddress from = new MailAddress(ConfigurationManager.AppSettings["FromMail"].ToString());
        MailAddress to = new MailAddress(tomail);
        MailMessage mail = new MailMessage(from, to);

        //mail.Bcc.Add(new MailAddress("n.shah12@gmail.com"));

        // mail.Bcc.Add(new MailAddress("chetanabookdepot1@gmail.com"));

        mail.Bcc.Add(new MailAddress(Smailid));
        mail.Subject = subject;
        mail.IsBodyHtml = true;
        mail.Body = body;
        client.Send(mail);



    }
}