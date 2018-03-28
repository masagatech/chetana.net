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
using System.Net.Mail;

using System.Text;

public partial class Godown_GetPass_OutSide : System.Web.UI.UserControl
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }

        if (!Page.IsPostBack)
        {
            onNotPostback();
            txtDocDate.Focus();
            lblDocNo.Text = "0";
            txtDocNo.Text = "---New---";
        }

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        saveMaster(false);
    }
    protected void btn_PrintSave_Click(object sender, EventArgs e)
    {
        saveMaster(true);

    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        callTextChange();
    }

    #region cust Text Change

    public void callTextChange()
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

        if (dt.Rows.Count != 0)
        {
            if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
            {
                lblCustomer.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                txtcustomer.Text = CustCode;
                lblCustID.Text = Convert.ToString(dt.Rows[0]["CustID"]);
                txttransporter.Focus();
                //if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra" || dt.Rows[0]["State"].ToString().ToLower() == "")
                //{
                //    srate = "l";
                //}
                //else
                //{
                //    srate = "m";
                //}
                //txtpIncharge.Focus();
                //  ACExttransporter.ContextKey = CustCode;
                //Get_Employee_By_Customer_Code
                // TextBox1_AutoCompleteExtender.ContextKey = CustCode;
                //    Bind_DDL_Transport();
            }
            else
            {
                lblCustomer.Text = "Customer is blacklisted";
                txtcustomer.Focus();
                txtcustomer.Text = "";
                //srate = "";
            }
        }
        else
        {
            lblCustomer.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
            //srate = "";
        }
    }



    #endregion

    protected void txtTransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txttransporter.Text != "")
            {
                string TransCode = txttransporter.Text.ToString().Split(':', '[', ']')[0].Trim();
                flag1 = txttransporter.Text.ToString().Split('[', ']')[1].Trim();
                txttransporter.Text = TransCode;
               // ACExttransporter.ContextKey = TransCode;

                if (flag1 == "Trans")
                {
                    lbltransporter.Visible = true;
                    DataTable dt = new DataTable();
                    dt = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("Transport", TransCode).Tables[0];

                    if (dt.Rows.Count != 0)
                    {
                        // txttransporter.Text = TransCode;
                        if (flag1 == "Trans")
                        {
                            lbltransporter.Text = dt.Rows[0]["Value"].ToString();
                            lblTransID.Text = dt.Rows[0]["AutoID"].ToString();
                            txtNoOfBund.Focus();
                        }
                    }
                    else
                    {
                        lbltransporter.Text = "No such record found";
                        txttransporter.Focus();
                        txttransporter.Text = "";
                    }
                    //   Bind_DDL_Transport();
                }
                else
                {
                    lbltransporter.Visible = false;
                    lbltransporter.Text = flag1;
                    //lbltransporter.Text = "";
                }
            }
            else
            {

                lbltransporter.Text = "No such record found";
                txttransporter.Text = "";

            }

        }
        catch (Exception ex)
        {
            txttransporter.Text = ex.Message.ToString();
            //lbltransporter.Text = "No such record found";
        }

    }

    public void saveMaster(bool isprint)
    {
        int DocId = 0;
        string Localout = string.Empty;
        try
        {
            string date = txtDocDate.Text.Split('/')[1] + "/" + txtDocDate.Text.Split('/')[0] + "/" + txtDocDate.Text.Split('/')[2];
            string LRdate = txtLrDate.Text.Split('/')[1] + "/" + txtLrDate.Text.Split('/')[0] + "/" + txtLrDate.Text.Split('/')[2];
            G_GetPass obj = new G_GetPass();
            obj.Doc_ID = Convert.ToInt32(lblDocNo.Text.Trim());
            obj.Local_Out = "O";
            Localout = "O";
            obj.Doc_Date = Convert.ToDateTime(date);
            obj.DC_No = Convert.ToDecimal(txtDcNo.Text.Trim());
            obj.Cust_ID = Convert.ToInt32(lblCustID.Text.Trim());
            obj.Transporter_ID = Convert.ToInt32(lblTransID.Text.Trim());
            obj.No_Bundles = txtNoOfBund.Text.Trim();
            obj.Bill_Nos = txtBillNo.Text.Trim();
            if (txtValOfGoods.Text.Trim() == "")
            {
                obj.Value_Goods = 0;
            }
            else
            {
                obj.Value_Goods = Convert.ToDecimal(txtValOfGoods.Text.Trim());
            }

            obj.Sent_By = txtSentBy.Text.Trim();
            obj.LR_No = txtLRNo.Text.Trim();
            obj.LR_Date = Convert.ToDateTime(LRdate);
            obj.Pay_Paid = rdoPaidStaus.SelectedValue.ToString();
            if (txtAmt.Text.Trim() == "")
            {
                obj.Amount = 0;
            }
            else
            {
                obj.Amount = Convert.ToDecimal(txtAmt.Text.Trim());
            }
            obj.Delivery = chIsDelivery.Checked;
            obj.Fy = Convert.ToInt32(strFY);
            obj.Created_By = UserName;
            obj.Updated_By = UserName;
            obj.Remark1 = txtRemark.Text;
            int Doc_No_New = 0;
            DocId = obj.Save(out Doc_No_New);
            MessageBox("Data Saved! \\r\\n Documennt no." + Doc_No_New.ToString());
            int SCD;
            CourierDetails _objCD = new CourierDetails();
            _objCD.SaveDispatchEmailDetails(Convert.ToInt32(DocId), "O", Convert.ToInt32(strFY), Convert.ToString(Session["UserName"]), out SCD);

            DataSet ds = new DataSet();
            ds = G_GetPass.CustEMail_LocalEntry(obj.Cust_ID);
            String CustEmailId = "";
            if (ds.Tables.Count != 0)
            {
                CustEmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
                string SZEmailid = ds.Tables[0].Rows[0]["SEmailID"].ToString();

                if (CustEmailId.Trim() != "")
                {

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("wecare@chetanapublications.com");
                    msg.To.Add(new MailAddress(CustEmailId));
                    msg.To.Add(new MailAddress("chetanabookdepot1@gmail.com"));
                    msg.Bcc.Add(new MailAddress(SZEmailid));
                    msg.Subject = "Chetana Book Depot";

                    string CustomerName = "";
                    if (lblCustomer.Text.Trim() != "")
                    {
                        string[] tokens = lblCustomer.Text.Split(new string[] { "::" }, StringSplitOptions.None);
                        CustomerName = tokens[0].Trim();
                    }
                    if (CustomerName == "")
                    {
                        CustomerName = txtcustomer.Text;
                    }
                    string TransporterName = "";
                    TransporterName = lbltransporter.Text;
                    if (TransporterName == "")
                    {
                        TransporterName = txttransporter.Text;
                    }

                    msg.Body = MailBodyDesign(CustomerName, obj.DC_No, obj.No_Bundles, TransporterName, obj.LR_No, obj.LR_Date.ToString()).ToString();
                    msg.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "crm.chetanapublications.com";
                    smtp.Port = 25;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("wecare@chetanapublications.com", "we0504260");
                    smtp.EnableSsl = false;

                    try
                    {
                        smtp.Send(msg);
                        DataSet DsMailLog = new DataSet();
                        string mDocumentNo = obj.DC_No.ToString();
                        DsMailLog = CourierDetails.SendDispatchEmail(SCD, float.Parse(mDocumentNo), "DispatchEmail", "DispatchId", Convert.ToInt32(strFY), "wecare@chetanapublications.com", "we0504260", Convert.ToString(Session["UserName"]));
                        //MessageBox("Mail Sent successfully");

                    }
                    catch (Exception ex)
                    {
                        //MessageBox(ex.Message);
                    }

                }
            }
            ds.Dispose();
            if (isprint)
            {

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Godown/print/OutGodownPrint.aspx?d=" + DocId + "&L=" + Localout + "')", true);
            }
            Clear();
            CallButonVisible("new");
        }
        catch (Exception ex)
        {
            MessageBox("Error! : " + ex.Message.ToString());

        }

    }

    public void onNotPostback()
    {

        txtDocDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtLrDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        AutoExtDocno.ContextKey = "g_docNo-" + strFY;
        CallButonVisible("new");
    }

    public void fillEditForm()
    {
        Clear();
        DataTable dt = G_GetPass.GetpassOnDocNo(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "O", Convert.ToInt32(strFY)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            string date = (Convert.ToDateTime(dt.Rows[0]["Doc_Date"].ToString())).ToString("dd/MM/yyyy");
            string LRdate = (Convert.ToDateTime(dt.Rows[0]["LR_Date"].ToString())).ToString("dd/MM/yyyy");
            txtDocNo.Text = dt.Rows[0]["Doc_No"].ToString();
            lblDocNo.Text = dt.Rows[0]["Doc_ID"].ToString();
            txtDcNo.Text = dt.Rows[0]["DC_No"].ToString();
            txtBillNo.Text = dt.Rows[0]["Bill_Nos"].ToString();
            lblclone.Text = dt.Rows[0]["Bill_Nos"].ToString();
            txtcustomer.Text = dt.Rows[0]["CustomerName"].ToString();
            lblCustID.Text = dt.Rows[0]["Cust_ID"].ToString();
            txttransporter.Text = dt.Rows[0]["Trasporter"].ToString();
            lblTransID.Text = dt.Rows[0]["Transporter_ID"].ToString();
            txtNoOfBund.Text = dt.Rows[0]["No_Bundles"].ToString();
            txtValOfGoods.Text = dt.Rows[0]["Value_Goods"].ToString();
            txtSentBy.Text = dt.Rows[0]["Sent_By"].ToString();
            txtLRNo.Text = dt.Rows[0]["LR_No"].ToString();
            txtLrDate.Text = LRdate;
            chIsDelivery.Checked = Convert.ToBoolean(dt.Rows[0]["Delivery"].ToString());
            txtAmt.Text = dt.Rows[0]["Amount"].ToString();
            rdoPaidStaus.SelectedValue = dt.Rows[0]["Pay_Paid"].ToString();
            txtDocDate.Text = date;dt.Rows[0]["Amount"].ToString();
            txtRemark.Text = dt.Rows[0]["Remark1"].ToString();
            CallButonVisible("edit");
            txtDocDate.Focus();

        }
        else
        {
            MessageBox("Info! : \\r\\n Doc. No. " + txtDocIdEdit.Text.Trim() + " Not Found!!!");
            txtDocIdEdit.Text = "";
            txtDocIdEdit.Focus();
            ModalPopUpDocNum.Show();

        }
    }

    protected void txtDcNo_TextChanged(object sender, EventArgs e)
    {

        DataSet ds = Other_G.getInfoNoForGodown(Convert.ToInt32(strFY), Convert.ToInt32(txtDcNo.Text), "dcno");
        if (ds.Tables[0].Rows.Count > 0)
        {
            try
            {

                txtcustomer.Text = "";
                txtcustomer.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lbltransporter.Visible = true;
                lbltransporter.Text = ds.Tables[0].Rows[0]["Transporter"].ToString();
                lblTransID.Text = ds.Tables[0].Rows[0]["AutoID"].ToString();
                txttransporter.Text = ds.Tables[0].Rows[0]["trans"].ToString();    
                upCustomerName.Update();
                callTextChange();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtBillNo.Text = string.Format("{0:0.00}", Convert.ToDouble(ds.Tables[1].Rows[0][0].ToString()));
                    UpdatePanel2.Update();
                }
                else
                {
                    if (txtDcNo.Text != "")
                    {
                        txtBillNo.Text = string.Format("{0:0.00}", (Convert.ToDouble(txtDcNo.Text.Trim()) + 0.01));
                        UpdatePanel2.Update();
                    }
                }
            }
            catch (Exception EX)
            {

                MessageBox("Error: Record not found");
            }
        }
        else
        {
            txtBillNo.Text = "";
            UpdatePanel2.Update();
            txtcustomer.Text = "";
            lblCustomer.Text = "No such Customer code";
            upCustomerName.Update();
        }
        txtBillNo.Focus();
    }

    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        fillEditForm();

    }

    public void Clear()
    {
        lblDocNo.Text = "0";
        txtDocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDcNo.Text = "";
        txtBillNo.Text = "";
        txtcustomer.Text = "";
        lblCustomer.Text = "";
        txttransporter.Text = "";
        lbltransporter.Text = "";
        txtNoOfBund.Text = "";
        txtValOfGoods.Text = "";
        txtSentBy.Text = "";
        txtLRNo.Text = "";
        txtLrDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtAmt.Text = "";
        chIsDelivery.Checked = false;
        txtDocNo.Text = "---New---";
    }

    public void CallButonVisible(string mode)
    {
        if (mode == "edit")
        {
            btnDelete.Visible = true;
            btnClear.Visible = true;
            btn_Save.Visible = true;
            btn_PrintSave.Visible = true;
            btn_Edit.Visible = false;
        }
        else if (mode == "new")
        {
            btnDelete.Visible = false;
            btnClear.Visible = true;
            btn_Save.Visible = true;
            btn_PrintSave.Visible = true;
            btn_Edit.Visible = true;
            txtDocDate.Focus();
        }
        else if (mode == "view")
        {
            btnDelete.Visible = false;
            btnClear.Visible = true;
            btn_Save.Visible = false;
            btn_PrintSave.Visible = false;
            btn_Edit.Visible = false;
        }


    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Other_G obj = new Other_G();
        obj.DeleteModule(lblDocNo.Text.Trim(), "getPass", "");
        MessageBox("Info ! \\r\\n Record Deleted!!!");
        Clear();
        CallButonVisible("new");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
        CallButonVisible("new");
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    protected void txtBillNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = G_GetPass.Local_GetPass_DCNo_BillNo_Validation(Convert.ToDecimal(txtDcNo.Text.Trim()), txtBillNo.Text.Trim(), Convert.ToInt32(strFY), "checkoutstation");

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (txtBillNo.Text.Trim() != lblclone.Text)
            {
                MessageBox(ds.Tables[0].Rows[0][0].ToString());
                txtDcNo.Text = "";
                txtBillNo.Text = "";
                txtcustomer.Text = "";
                lblCustomer.Text = "";
            }
        }
        else
        {
            txttransporter.Focus();
        }
    }
    public StringBuilder MailBodyDesign(string CustName, decimal DCNo, string NO_OF_BUNDLES, string Trasporter, string LR_No, string LR_Date)
    {
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
        stBody.Append(" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1>Chetana Book Depot</h1></u>");
         
stBody.Append(" 4TH  FLOOR, B WING, “BUILDING E”, TRADE LINK KAMALA CITY, ABOVE BOMBAY CANTEEN, LOWER PAREL, MUMBAI - 400013");              
	stBody.Append("<br/></td></tr> ");

        stBody.Append("<tr>");
        stBody.Append(" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
        stBody.Append(" <table cellpadding=5 cellspacing=5 >");
        stBody.Append(" <tr>  <td align=left >");
        stBody.Append(" <b>Dear Customer</b>,<br/>");
        stBody.Append(" Thank you for your recent purchase.<br/>");
        stBody.Append(" We are delighted to inform you that your order has been processed & dispatched <br/>");
        stBody.Append(" by our team. <br/><br/> ");
        stBody.Append(" Below are the details of dispatch. <br/></td></tr> ");
        stBody.Append(" </table>");
        stBody.Append(" <table cellpadding=5 cellspacing=5 >");
        stBody.Append(" <tr>  <td align=left >");
        stBody.Append(" <tr><td><b>Customer Name :</b></td><td>" + CustName + "</td></tr> ");
        stBody.Append(" <tr><td><b> DC No :</b></td><td>" + DCNo + "</td></tr>");
        stBody.Append(" <tr><td><b>Trasporter :</b></td><td>" + Trasporter + "</td></tr> ");
        stBody.Append(" <tr><td><b>No of Parcels :</b></td><td>" + NO_OF_BUNDLES + "</td></tr>");
        stBody.Append(" <tr><td><b>LR No :</b></td><td>" + LR_No + "</td></tr> ");
        stBody.Append(" <tr><td><b>LR Date :</b></td><td>" + LR_Date + "</td></tr> ");
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
}
