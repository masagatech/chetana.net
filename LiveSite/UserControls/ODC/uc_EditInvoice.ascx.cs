#region NameSpaces
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
using System.Web.Services;
using Idv.Chetana.BAL;
using System.Xml;

#endregion

public partial class UserControls_ODC_uc_EditInvoice : System.Web.UI.UserControl
{
    #region Varables
    static DataSet stDS;
    static int quantity = 0;
    static decimal tamount = 0;
    static decimal totalamount = 0;
    static decimal toamount;
    static decimal temp;
    decimal frieght = 0;
    decimal tax = 0;
    //string date;
    static int tabindex = 20;
    int invoiceId;
    static decimal totalamount1;
    static decimal Finalamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string flag1;
    string RdBValue;
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
            DDLCustomer.Focus();
            docno.InnerHtml = "Not Selected";
            RdlView.SelectedValue = "All";
            BindPanel();

            // Rptrpending.DataSource = DCDetails.Get_DC_Completed_IsApproved();
            // Rptrpending.DataBind();
            // Panel1.Visible = false;
            // DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Editinvoice", Convert.ToInt32(strFY));
            //  DDLCustomer.DataBind();
            //  DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            //  DCDetails.Get_DC_Completed_IsApproved(); DCMaster.Get_ApprovedDocNo();
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        stDS = new DataSet();
        docno.InnerHtml = txtDocno.Text.Trim();
        stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "Edit", Convert.ToInt32(strFY));
        RepDetailsConfirm.DataSource = stDS.Tables[0];
        RepDetailsConfirm.DataBind();
        lblmessage.InnerHtml = "";
        //pnldetails.Visible = true;
        // updategenerate.Update();    


    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {

    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtFright = null;
        TextBox txttax = null;
        TextBox txtBundles = null;
        TextBox txtLrno = null;
        TextBox txtLrdate = null;
        TextBox txttransporter = null;
        Label lblallTotalamt = null;
        Label lbltotalAmtget = null;
        Label lblautoid = null;
        TextBox txtLrdateNew = null;
        txtFright = (TextBox)e.Item.FindControl("txtfrieght");
        txttax = (TextBox)e.Item.FindControl("txttax");
        txtBundles = (TextBox)e.Item.FindControl("txtbundles");
        txtLrno = (TextBox)e.Item.FindControl("txtlrno");
        txtLrdate = (TextBox)e.Item.FindControl("txtdateabc");
        txttransporter = (TextBox)e.Item.FindControl("lbltransporter");
        lblallTotalamt = (Label)e.Item.FindControl("lblallTotalamt");
        lbltotalAmtJS = (Label)e.Item.FindControl("lbltotalAmtJS");
        txtLrdateNew = (TextBox)e.Item.FindControl("txtlrdate");

        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        DataView dv = new DataView(stDS.Tables[1]);
        dv.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]) + "   ";
        lblcustname.InnerHtml = "  " + Convert.ToString(stDS.Tables[2].Rows[0]["CustName"]);

        DataView frttax1 = new DataView(stDS.Tables[1]);
        frttax1.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        DataView frttax = new DataView(stDS.Tables[3]);
        frttax.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        ((TextBox)e.Item.FindControl("txtdateabc")).Text = DateTime.Now.ToString("dd/MM/yyyy");
        ((Label)e.Item.FindControl("Lblautoid")).Text = frttax[0].Row["Auto_ID"].ToString();
        txtfrieght.Text = (frttax1[0].Row["Freight"].ToString());
        txttax.Text = (frttax1[0].Row["Tax"].ToString());
        txtBundles.Text = (frttax1[0].Row["Bundles"].ToString());
        txtLrno.Text = (frttax1[0].Row["LRNo"].ToString());
        txtLrdate.Text = (frttax1[0].Row["InvoiceDate"].ToString());
        txttransporter.Text = (frttax1[0].Row["Transporter"].ToString());
        frieght = Convert.ToDecimal(frttax1[0].Row["Freight"].ToString());
        tax = Convert.ToDecimal(frttax1[0].Row["Tax"].ToString());
        txtLrdateNew.Text = (frttax1[0].Row["LRDate"].ToString());
        totalamount1 = frieght + tax + toamount;
        lblallTotalamt.Text = totalamount1.ToString().Trim();
        ((Label)e.Item.FindControl("LblRemark")).Text = stDS.Tables[2].Rows[0]["Remark"].ToString();
        if (stDS.Tables[2].Rows.Count > 0)
        {
            ((TextBox)e.Item.FindControl("lbltransporter")).Text = stDS.Tables[2].Rows[0]["Transporter"].ToString();
        }
        lbltotalAmtJS.Text = tamount.ToString();
        txtfrieght.Attributes.Add("onkeyup", "sumCharges('" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lbltotalAmtJS.ClientID + "','" + lblallTotalamt.ClientID + "')");
        txttax.Attributes.Add("onkeyup", "sumCharges('" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lbltotalAmtJS.ClientID + "','" + lblallTotalamt.ClientID + "')");

    }


    Label lblAqty;
    TextBox txtrate;
    Label lblAmt;
    TextBox lbldisc;
    TextBox txtQty;
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalAmtForFright = (Label)e.Row.Parent.Parent.Parent.FindControl("lbltotalAmtget");
            Label lblTotalAmtForFrightorg = (Label)e.Row.Parent.Parent.Parent.FindControl("lblallTotalamt");
            Label lbltotalAmtJS = (Label)e.Row.Parent.Parent.Parent.FindControl("lbltotalAmtJS");

            TextBox txtfrieght = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txtfrieght");
            TextBox txttax = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txttax");


            lblAqty = (Label)e.Row.FindControl("lblAqty");
            txtrate = (TextBox)e.Row.FindControl("txtrate");
            lbldisc = (TextBox)e.Row.FindControl("txtdiscount");
            lblAmt = (Label)e.Row.FindControl("lblamt");
            txtQty = (TextBox)e.Row.FindControl("lblqunty");

            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + txtQty.ClientID + "','" + txtrate.ClientID + "','" + lbldisc.ClientID + "','" + lblAmt.ClientID + "','" + ((GridView)(sender)).ClientID + "','" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lblTotalAmtForFright.ClientID + "','" + lblTotalAmtForFrightorg.ClientID + "','" + lbltotalAmtJS.ClientID + "')");
            lbldisc.Attributes.Add("onkeyup", "multiplyQty('" + txtQty.ClientID + "','" + txtrate.ClientID + "','" + lbldisc.ClientID + "','" + lblAmt.ClientID + "','" + ((GridView)(sender)).ClientID + "','" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lblTotalAmtForFright.ClientID + "','" + lblTotalAmtForFrightorg.ClientID + "','" + lbltotalAmtJS.ClientID + "')");
            txtQty.Attributes.Add("onkeyup", "multiplyQty('" + txtQty.ClientID + "','" + txtrate.ClientID + "','" + lbldisc.ClientID + "','" + lblAmt.ClientID + "','" + ((GridView)(sender)).ClientID + "','" + txtfrieght.ClientID + "','" + txttax.ClientID + "','" + lblTotalAmtForFright.ClientID + "','" + lblTotalAmtForFrightorg.ClientID + "','" + lbltotalAmtJS.ClientID + "')");
            Label lbl = (Label)e.Row.FindControl("lblAqty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());
            //Label lblTotalAmtForFright = (Label)e.Row.Parent.Parent.Parent.FindControl("lbltotalAmtget");
            lblTotalAmtForFright.Text = tamount.ToString().Trim();
            // MessageBox(tamount.ToString());
            //lblTotalAmtForFrightorg.Text = tamount.ToString().Trim();
            // Finalamount = tamount;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            lbl1.Attributes.Add("class", ((GridView)(sender)).ClientID + "qty");
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
            lblamt1.Text = tamount.ToString().Trim();
            lblamt1.Attributes.Add("class", ((GridView)(sender)).ClientID + "amt");
            toamount = Convert.ToDecimal(tamount.ToString().Trim());


        }



    }

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
        ((Label)((TextBox)(sender)).Parent.FindControl("lblallTotalamt")).Text = totalamount.ToString();
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
        ((Label)((TextBox)(sender)).Parent.FindControl("lblallTotalamt")).Text = totalamount.ToString();

        ((Button)((TextBox)(sender)).Parent.FindControl("btnConfirmed")).Focus();
    }
    protected void grdapproval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Repeater objrep = ((Repeater)this.FindControl("RepDetailsConfirm"));
        // RepeaterCommandEventArgs s = (RepeaterCommandEventArgs)(e);
        // decimal subdoc = Convert.ToDecimal((s.CommandArgument.ToString().Trim()));
        GridView objgrid1 = (GridView)(sender);
        ActualInvoiceDetails _objinvoice = new ActualInvoiceDetails();
        invoiceId = Convert.ToInt32(((Label)objgrid1.Rows[e.RowIndex].FindControl("lblgenerateinvoiceid")).Text);

        try
        {
            if (invoiceId != 0)
            {
                _objinvoice.GanerateinvoiceId = invoiceId;
                _objinvoice.IsActive = false;
                _objinvoice.IsDeleted = true;
                _objinvoice.SubDocId = Convert.ToDecimal(((Label)objgrid1.Parent.FindControl("SubConfirmID")).Text);

                decimal amt1 = Convert.ToDecimal(((Label)objgrid1.Rows[e.RowIndex].FindControl("lblamt")).Text);
                decimal amount1 = Convert.ToDecimal(((Label)objgrid1.Parent.FindControl("lblallTotalamt")).Text);
                decimal tamount1 = amount1 - amt1;
                _objinvoice.TotalAmount = tamount1;
                _objinvoice.FinancialYearFrom = strFY.ToString();
                if (objgrid1.Rows.Count == 1)
                {
                    _objinvoice.flag = "DeleteInvoice" + "!" + Session["UserName"].ToString();
                }
                else { _objinvoice.flag = "invoice"; }
                _objinvoice.DeleteActual_InvoiceDetails(1);

            }

            stDS = new DataSet();
            docno.InnerHtml = txtDocno.Text.Trim();
            stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "Edit", Convert.ToInt32(strFY));
            RepDetailsConfirm.DataSource = stDS.Tables[0];
            RepDetailsConfirm.DataBind();
        }
        catch
        {
        }



    }
    protected void RepDetailsConfirm_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        {
            bool Auth = DCMaster.Get_DocumentNum_Authentication(Convert.ToInt32(txtDocno.Text), Convert.ToInt32(strFY));
            if (Auth)
            {
                MessageBox("Document no is not available");
                txtDocno.Focus();

            }
            else
            {

                //   DCConfirmQtyDetails _objDCConfirmQtyDetails = new DCConfirmQtyDetails();
                //    DCMaster _objDCMaster = new DCMaster();
                DCConfirmQtyDetails _objDCFT = new DCConfirmQtyDetails();
                ActualInvoiceDetails _objactualinvoice = new ActualInvoiceDetails();

                try
                {
                    #region ActulInvoice
                    Repeater objrep = (Repeater)this.FindControl("RepDetailsConfirm");
                    GridView objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdapproval");


                    foreach (GridViewRow row in objgrid.Rows)
                    {
                        _objactualinvoice.GanerateinvoiceId = Convert.ToInt32(((Label)row.FindControl("lblgenerateinvoiceid")).Text);
                        _objactualinvoice.DocumentNo = Convert.ToInt32(txtDocno.Text);
                        _objactualinvoice.SubDocId = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                        _objactualinvoice.BookCode = ((Label)row.FindControl("lblbookC")).Text;
                        _objactualinvoice.BookName = ((Label)row.FindControl("lblbookN")).Text;
                        _objactualinvoice.Standard = ((Label)row.FindControl("lblStandard")).Text;
                        _objactualinvoice.Medium = ((Label)row.FindControl("lblMedium")).Text;
                        _objactualinvoice.Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
                        _objactualinvoice.Quantity = Convert.ToInt32(((TextBox)row.FindControl("lblqunty")).Text);
                        _objactualinvoice.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtdiscount")).Text);

                        _objactualinvoice.Amount = Convert.ToInt32(((Label)row.FindControl("lblAqty")).Text) * (Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) - (Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Convert.ToDecimal(((TextBox)row.FindControl("txtdiscount")).Text) / 100));
                        // _objactualinvoice.Amount = Convert.ToDecimal(((Label)row.FindControl("lblamt")).Text);
                        _objactualinvoice.Freight = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text);
                        _objactualinvoice.Tax = Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                        _objactualinvoice.Transporter = (((TextBox)e.Item.FindControl("lbltransporter")).Text);
                        _objactualinvoice.LRNo = (((TextBox)e.Item.FindControl("txtlrno")).Text);
                        //  _objactualinvoice.TotalAmount = Convert.ToDecimal(((Label)e.Item.FindControl("lbltotalAmtget")).Text);
                        // Finalamount = Convert.ToDecimal(((Label)row.FindControl("lblTotalAmt")).Text);
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
                            date1 = txtIdate1.Text.Split('/')[1] + "/" + txtIdate1.Text.Split('/')[0] + "/" + txtIdate1.Text.Split('/')[2];
                        }
                        if (txtLrdate1.Text == "")
                        {
                            lrdate = "1/1/2001";
                        }
                        else
                        {
                            lrdate = txtLrdate1.Text.Split('/')[1] + "/" + txtLrdate1.Text.Split('/')[0] + "/" + txtLrdate1.Text.Split('/')[2];
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
                    // Save Freight and tax Details   
                    frieght = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text);
                    tax = Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                    temp = tamount + frieght + tax;
                    // totalamount = tamount;
                    _objDCFT.Auto_ID = Convert.ToInt32(((Label)e.Item.FindControl("Lblautoid")).Text);
                    _objDCFT.DocumentNo = Convert.ToInt32(txtDocno.Text);
                    _objDCFT.SubDocNo = subconfirmdoc;
                    _objDCFT.Freight = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtfrieght")).Text);
                    _objDCFT.Tax = Convert.ToDecimal(((TextBox)e.Item.FindControl("txttax")).Text);
                    _objDCFT.TotalAmount = Convert.ToDecimal(((Label)e.Item.FindControl("lblallTotalamt")).Text);
                    _objDCFT.LRNo = (((TextBox)e.Item.FindControl("txtlrno")).Text);
                    TextBox txtIdate = ((TextBox)e.Item.FindControl("txtdateabc"));
                    string date;
                    if (txtIdate.Text == "")
                    {
                        date = "1/1/2001";
                    }
                    else
                    {
                        date = txtIdate.Text.Split('/')[1] + "/" + txtIdate.Text.Split('/')[0] + "/" + txtIdate.Text.Split('/')[2];
                    }
                    _objDCFT.InvoiceDate = Convert.ToDateTime(date);
                    _objDCFT.AvailableQty = Convert.ToInt32(strFY);
                    _objDCFT.Save_FrightTax_Details(1);


                    //  _objDCConfirmQtyDetails.SaveConfirmDetails();

                    stDS = new DataSet();
                    docno.InnerHtml = txtDocno.Text.Trim();
                    // stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed",Convert.ToInt32(strFY));




                    //  RepDetailsConfirm.DataSource = stDS.Tables[0];
                    //   RepDetailsConfirm.DataBind();
                    #endregion

                    MessageBox("Invoice Updated successfully " + subconfirmdoc);

                    lblmessage.InnerHtml = "Last updated Invoice no. : " + subconfirmdoc;


                    stDS = new DataSet();
                    docno.InnerHtml = txtDocno.Text.Trim();
                    stDS = DCDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "Edit", Convert.ToInt32(strFY));
                    RepDetailsConfirm.DataSource = stDS.Tables[0];
                    RepDetailsConfirm.DataBind();



                }
                catch (Exception ex)
                {
                    MessageBox(ex.Message.ToString());
                }
            }
        }
    }

    #region Save Email Log Table
    private void SaveEmailLog()
    {
        XmlDocument doc = new XmlDocument();
        XmlNode inode = doc.CreateElement("f");
        XmlNode fnode = doc.CreateElement("r");
        XmlNode element = doc.CreateElement("i");

        inode = doc.CreateElement("subdoc");
        inode.InnerText = _objDCFT.SubDocNo;
        element.AppendChild(inode);

        inode = doc.CreateElement("dcdoc");
        inode.InnerText = txtDocno.Text.ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("mud");
        inode.InnerText = "invoice".ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("toe");
        inode.InnerText = lblEmail.Text.ToString();
        element.AppendChild(inode);

        if (ConfigurationManager.AppSettings["invoice_cc"].ToString() != "-1")
        {
            inode = doc.CreateElement("cc");
            inode.InnerText = ConfigurationManager.AppSettings["invoice_cc"].ToString();
            element.AppendChild(inode);
        }

        if (ConfigurationManager.AppSettings["invoice_bcc"].ToString() != "-1")
        {
            inode = doc.CreateElement("bcc");
            inode.InnerText = ConfigurationManager.AppSettings["invoice_bcc"].ToString();
            element.AppendChild(inode);
        }

        inode = doc.CreateElement("sub");
        inode.InnerText = ConfigurationManager.AppSettings["invoice_sub"].ToString() + Invno;
        element.AppendChild(inode);

        inode = doc.CreateElement("msg");
        inode.InnerText = "";
        element.AppendChild(inode);

        inode = doc.CreateElement("sndtm");
        inode.InnerText = null;
        element.AppendChild(inode);

        inode = doc.CreateElement("st");
        inode.InnerText = "pending".ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("fp");
        inode.InnerText = "null".ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("fy");
        inode.InnerText = Convert.ToInt32(Session["FY"]).ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("ext");
        inode.InnerText = "Username :" + ConfigurationManager.AppSettings["Username"].ToString().ToString() + "," + "FromMail :" + ConfigurationManager.AppSettings["FromMail"].ToString() + "," + "Password :" + ConfigurationManager.AppSettings["Password"].ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("rem1");
        inode.InnerText = "Insert".ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("rem2");
        inode.InnerText = "".ToString();
        element.AppendChild(inode);

        inode = doc.CreateElement("rem3");
        inode.InnerText = "".ToString();
        element.AppendChild(inode);

        fnode.AppendChild(element);

        Other_Z.OtherBAL ObjBal = new Other_Z.OtherBAL();
        ObjBal.SaveEmailLog(fnode.OuterXml, "invoice", "", "");
    }
    #endregion

    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Rptrpending.DataSource = ActualInvoiceDetails.GetCustomer_OnView(Convert.ToInt32(DDLCustomer.SelectedValue), "EditInvoice", Convert.ToInt32(strFY));
        Rptrpending.DataBind();
        //   Panel1.Visible = true;
        upDocNo.Update();
        Panel1.Visible = true;
        Rptrpending.Visible = true;

        //pnldetails.Visible = false;
        // RepDetailsConfirm.DataSource = null;
        // RepDetailsConfirm.DataBind();
        // updategenerate.Update();

    }

    protected void RdlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanel();


    }
    public void BindCustomer()
    {
        DDLCustomer.Items.Clear();
        DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Editinvoice", Convert.ToInt32(strFY));
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));


    }
    public void BindPanel()
    {
        RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Customer")
        {
            BindCustomer();

            Pnlcust.Visible = true;
            //   pnlDetails.Visible = false;
            Rptrpending.Visible = true;
            // Panel1.Visible = false;
            upDocNo.Update();
            RepDetailsConfirm.DataBind();
            Rptrpending.DataBind();

        }

        if (RdBValue == "All")
        {

            Pnlcust.Visible = false;
            // pnlDetails.Visible = false;
            //   Panel1.Visible = true;
            Rptrpending.Visible = true;
            Rptrpending.DataSource = DCDetails.Get_DC_Completed_IsApproved(Convert.ToInt32(strFY));
            Rptrpending.DataBind();
            upDocNo.Update();
            RepDetailsConfirm.DataBind();


        }
    }
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


            Qty = Convert.ToInt32(((TextBox)row.FindControl("lblqunty")).Text);
            TotalAmount1 = TotalAmount1 + Qty * (rate - (rate * discount / 100));
            //    Totalrate = rate;
            //    Totaldiscount = discount;
        }
        // TotalAmount1 = (Totalrate * Qty) - ((Totalrate * Qty) * (Totaldiscount / 100));
        return TotalAmount1.ToString();
    }

    #endregion

}
