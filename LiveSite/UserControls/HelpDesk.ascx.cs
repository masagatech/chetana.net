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
//using Idv.Chetana.BAL;
//using Idv.Chetana.DAL;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Drawing;



public partial class UserControls_HelpDesk : System.Web.UI.UserControl
{
    #region Variables
    string display = "";
    string customrcode = "";
    static DataSet ds = null;
    private static int quantity = 0;
    private static decimal tamount = 0;
    private static decimal totalamount = 0;
    string strFY;
    string strChetanaCompanyName = "cppl";
    private string TktNumber, UpdTktID;
    // Customer_cs ds = new Customer_cs();

    #endregion

    #region 'Technople Developer'


    Other_Z.InquiryDetail eq = new Other_Z.InquiryDetail();
    Other_Z.InquiryBal InBal = new Other_Z.InquiryBal();
    Other_Z.OtherBAL ObjDAL = new Other_Z.OtherBAL();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            test12.Style.Add("display", "none");
            testRmk.Style.Add("display", "none");
            BindStatus();
            BindSeverity();
            BindInqType();
            Cust_AutoCompleteExtender.ContextKey = "EmpSuper" + "!" + Session["UserName"].ToString();
            string grp = "Ticket";
            ddlExlation.DataSource = ObjDAL.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
            ddlExlation.DataBind();

            cmdUpdate.Visible = false;
            cmdCancel.Visible = false;
        }
        if (IsPostBack)
        {
            string Customer = txtcustomer.Text.Trim();
            customrcode = Customer.Split(':')[0].ToString();
            txtcustomer.Focus();
            TktHistoryBind();
            //RemarksHistoryBind();
            cmdUpdate.Visible = false;
            CmdGenerated.Visible = true;
            CmdGenerated.Attributes.Add("onclick", "return validate()");
            PnlCR.DefaultButton = "btnGetRecords";
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
            }
            else
            {
                Response.Redirect("_auth.aspx");
            }
            //lnkMoreDc.Attributes.Add("Target", "_blank");
            LnkBtn.Attributes.Add("Target", "_blank");

            txtcustomer.Focus();

        }
        clmlest.Style.Add("display", "none");
        if (Convert.ToString(Session["UserName"]).ToLower() == "idvadmin" || Convert.ToString(Session["UserName"]).ToLower() == "emp315" || Convert.ToString(Session["UserName"]).ToLower() == "emp422" || Convert.ToString(Session["UserName"]).ToLower() == "chadmin" || Convert.ToString(Session["UserName"]).ToLower() == "emp859" || Convert.ToString(Session["UserName"]).ToLower() == "emp907" || Convert.ToString(Session["UserName"]).ToLower() == "emp908" || Convert.ToString(Session["UserName"]).ToLower() == "emp909" || Convert.ToString(Session["UserName"]).ToLower() == "emp910" || Convert.ToString(Session["UserName"]).ToLower() == "emp928")

        {
          
            clmlest.Style.Add("display", "block");
        }
        else
        {
            String UserName = "";
            //for (int i = 43; i <= 57; i++)
           // {
               // UserName = "emp8" + i + "";
               // if (Convert.ToString(Session["UserName"]).ToLower() == UserName)
                if (Request.QueryString["tkt"] !=null)
		        {
                   
                    clmlest.Style.Add("display", "block");

                }
            //}
        }
    }
    public void btnGetRecords_Click(object sender, EventArgs e)
    {
        try
        {
            //Bank dd = new Bank();

            string Customer = txtcustomer.Text.Trim();
            customrcode = Customer.Split(':')[0].ToString();
            DataTable dt = new DataTable();
            dt = ObjDAL.Get_Name(customrcode, "Customer").Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblCustomerName.Text = dt.Rows[0]["CustName"].ToString();
                lblCustID.Text = dt.Rows[0]["CustID"].ToString();
                Session["CustID"] = lblCustID.Text;
                Session["CustName"] = lblCustomerName.Text;
                CmdGenerated.Visible = true;

            }
            else
            {
                lblCustomerName.Text = "No such customer found";
                CmdGenerated.Visible = false;

            }
            TktHistoryBind();
            DataSet ds1 = new DataSet();
            ds = ObjDAL.getAllHelpDesk(customrcode, strFY);

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

            //TktHistoryBind();
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
                //lnkMoreDc.Visible = true;
                LnkBtn.Visible = true;
            }
            else
            {
                //lnkMoreDc.Visible = false;
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
            grdconfirm.DataSource = ObjDAL.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(img.CommandArgument.Trim()),
            "helpdesk", Convert.ToInt32(0)).Tables[1];
            grdconfirm.DataBind();
            ModalPopUpDocNum.Show();
            UpdatePanel7.Update();
        }
        else
        {
            stDS = ObjDAL.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(img.CommandArgument.Trim()), "helpdesk",
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
    protected void CmdGenerated_Click(object sender, EventArgs e)
    {
       
        CmdGenerated.Enabled = false;
        InsertReocod();
        CmdGenerated.Enabled = true;

    }
    public string GetDateFormat(string Formate)
    {
        if (string.IsNullOrEmpty(Formate) == false)
        {
            string DateFormate = Formate;
            DateTime DE = DateTime.ParseExact(DateFormate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            String Datetime = DE.ToString("yyyy-MM-dd");
            return Datetime;
        }
        else
        {
            string DateFormate = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime DE = DateTime.ParseExact(DateFormate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            String Datetime = DE.ToString("yyyy-MM-dd");
            return Datetime;
        }
    }
    protected void BindStatus()
    {
        DataSet DS = ObjDAL.GetStatus();
        DataTable dt = new DataTable();
        DS.Tables.Add(dt);
        InqSatatus.DataSource = DS;
        InqSatatus.DataTextField = "Status_Name";
        InqSatatus.DataBind();
        DataSet Ds1 = ObjDAL.GetStatusIsDefault();
        string StaIsDefault = Ds1.Tables[0].Rows[0]["Status_Name"].ToString();
        InqSatatus.Items.FindByValue(StaIsDefault).Selected = true;

    }
    protected void BindSeverity()
    {
        DataSet DS = ObjDAL.GetSeverity();
        InqSeverity.DataSource = DS;
        InqSeverity.DataTextField = "Severity_Name";
        InqSeverity.DataBind();
        DataSet Ds1 = ObjDAL.GetSeverityIsDefault();
        string StaIsDefault = Ds1.Tables[0].Rows[0]["Severity_Name"].ToString();
        InqSeverity.Items.FindByValue(StaIsDefault).Selected = true;

    }
    protected void BindInqType()
    {
        DataSet DS = ObjDAL.GetInqType();
        string InqTypeIsDefault = DS.Tables[0].Rows[0]["IsDefault"].ToString();
        iqnRadioButtonList.DataSource = DS;
        iqnRadioButtonList.DataTextField = "ITM_Name";
        iqnRadioButtonList.DataValueField = "ITM_ID";
        iqnRadioButtonList.DataBind();
        DataSet Ds1 = ObjDAL.GetInqiryIsDefault();
        string StaIsDefault = Ds1.Tables[0].Rows[0]["ITM_Name"].ToString();
        iqnRadioButtonList.Items.FindByText(StaIsDefault).Selected = true;

    }
    protected void TktHistoryBind()
    {
        eq.CustID = customrcode;
        DataSet DS = ObjDAL.Get_Name(customrcode, "GridBind");
        if (DS.Tables[0].Rows.Count > 0)
        {
            gvBind.DataSource = DS;
            gvBind.DataBind();
            gvBind.Visible = true;
            test12.Style.Add("display", "block");

        }
        else
        {
            DS.Tables[0].Rows.Add();
            gvBind.DataSource = DS;
            gvBind.DataBind();
            gvBind.Visible = false;
            test12.Style.Add("display", "none");
            testRmk.Style.Add("display", "none");

        }
    }
    protected void RemarksHistoryBind()
    {
        eq.TKTID = Session["TKTID"].ToString();
        DataSet DSR = ObjDAL.GetGridRemarks(eq.TKTID);
        if (DSR.Tables[0].Rows.Count > 0)
        {
            gvRemarks.DataSource = DSR;
            gvRemarks.DataBind();
            gvRemarks.Visible = true;
            gvRemarks.DataBind();
            testRmk.Style.Add("display", "block");
            lblTicketNumber.Text = ViewState["TktNumber"].ToString();

        }
        else
        {
            DSR.Tables[0].Rows.Add();
            gvRemarks.DataSource = DSR;
            gvRemarks.DataBind();
            gvRemarks.Visible = false;
            testRmk.Style.Add("display", "none");
        }

    }
    private void InsertReocod()
    {
        if (InqSatatus.SelectedValue != null || InqSeverity.SelectedValue != null || txtRemarks.Text != null)
        {
            string SQL = string.Empty;

            eq.EnqType = iqnRadioButtonList.SelectedValue.ToString();
            eq.CustID = lblCustID.Text;
            eq.EnqActionOn = Session["UserName"].ToString();
            eq.EnqDate = Convert.ToDateTime(DateTime.Now.ToString());
            eq.Severity = InqSeverity.SelectedValue.ToString().Trim();
            eq.Status = InqSatatus.SelectedValue.ToString().Trim() + "!" + ddlExlation.SelectedValue.ToString();
            eq.Remarks = txtRemarks.Text;
            
            
                InBal.SaveRecord(eq);
                GetRecord();
                try
                {
                SendEmailCustomer();
                SendActivationEmail();
                 //display = "Record Saved Successfully. Ticket Numener is:" + TktNumber;
            }
            catch (Exception ex)
            {

                display = ex.Message;
            }
            ScriptManager.RegisterStartupScript(UpdatePanel1385, UpdatePanel1385.GetType(), "popup", "alert('" + display + "');", true);
            TktHistoryBind();

            //TktHistoryBind();
            BindSeverity();
            BindStatus();
            BindInqType();
            txtRemarks.Text = "";

        }
        else
        {
            string message = "alert('Please Enter the values..')";
            ScriptManager.RegisterClientScriptBlock((CmdGenerated as Control), this.GetType(), "alert", message, true);

        }
    }
    private void GetRecord()
    {
        try
        {
            DataSet IResult = ObjDAL.GetLastTktNo();
            if (IResult.Tables[0].Rows.Count > 0)
            {
                int x = 0;
                DataRow dd = IResult.Tables[0].Rows[x];
                TktNumber = dd.ItemArray.GetValue(0).ToString();
                Session["TicketGet"] = TktNumber;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateTKTRecord()
    {
        try
        {
            eq.TKTID = Session["TKTID"].ToString(); ;
            DataSet IResult = ObjDAL.UpdateLastTktNo(eq.TKTID);
            if (IResult.Tables[0].Rows.Count > 0)
            {
                int x = 0;
                DataRow dd = IResult.Tables[0].Rows[x];
                UpdTktID = dd.ItemArray.GetValue(0).ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvBind_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Style["display"] = "none";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeff00';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
            e.Row.Attributes["onclick"] = "this.style.textDecoration='hand';this.style.background='#ffffff';";
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvBind, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";

        }
    }
    protected void gvBind_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvBind.SelectedRow;
        row.BackColor = Color.Green;
        gvBind.Rows[gvBind.SelectedIndex].BackColor = Color.Green;
        Label _LabelId = row.FindControl("TKTID") as Label;
        Label _LabelNumber = row.FindControl("txtTktNo") as Label;
        eq.TKTID = _LabelId.Text;
        Session["TKTID"] = eq.TKTID;
        ViewState["TktNumber"] = _LabelNumber.Text;
        CmdGenerated.Visible = false;
        cmdUpdate.Visible = true;
        cmdCancel.Visible = true;
        RemarksHistoryBind();
        BindReset();
        // Rmkls.Visible = true;
        //lblTiktNo.Text = _LabelNumber.Text;
        if (Session["TKTID"] != null)
        {
            DataSet GetTKT = ObjDAL.GetGridTktSelect(eq.TKTID);

            if (GetTKT.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string IResult = GetTKT.Tables[0].Rows[0]["ITM_Name"].ToString();
                    iqnRadioButtonList.SelectedIndex = Convert.ToInt32(iqnRadioButtonList.Items.IndexOf(iqnRadioButtonList.Items.FindByText(IResult)));
                    InqSatatus.SelectedValue = GetTKT.Tables[0].Rows[0]["Status_Name"].ToString();
                    InqSeverity.SelectedValue = GetTKT.Tables[0].Rows[0]["Severity_Name"].ToString();
                    // txtRemarks.Text = GetTKT.Tables[0].Rows[0]["Remarks"].ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alert", "alert('Record not Found')", true);
            }
        }
    }
    protected void BindReset()
    {

        BindSeverity();
        BindStatus();
        BindInqType();
        txtRemarks.Text = "";
        cmdUpdate.Visible = true;

    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        if (Session["TKTID"] != string.Empty)
        {
            try
            {
                
                string GetTID = Session["TKTID"].ToString();
                eq.TKTID = GetTID;
                eq.EnqType = iqnRadioButtonList.SelectedValue.ToString();
                eq.EnqActionOn = Session["UserName"].ToString();
                eq.EnqDate = Convert.ToDateTime(DateTime.Now.ToString());
                eq.Severity = InqSeverity.SelectedValue.ToString().Trim();
                eq.Status = InqSatatus.SelectedValue.ToString().Trim() + "!" + ddlExlation.SelectedValue.ToString();
                eq.Remarks = txtRemarks.Text;

                //Update Method Other_Z
                ObjDAL.InqueryUpdateDetails(GetTID, iqnRadioButtonList.SelectedValue.ToString(), InqSeverity.SelectedValue.ToString().Trim()
                    ,InqSatatus.SelectedValue.ToString().Trim() + "!" + ddlExlation.SelectedValue.ToString(),
                    txtRemarks.Text, Session["UserName"].ToString());

                UpdateTKTRecord();
                TktHistoryBind();

                //SendActivationEmail();

                // SendActivationEmail();
                RemarksHistoryBind();
                string display = "Ticket No " + UpdTktID + " Updated Successfuly...";
                ScriptManager.RegisterStartupScript(UpdatePanel1385, UpdatePanel1385.GetType(), "popup", "alert('" + display + "')", true);
                BindReset();
            }
            catch (Exception ex)
            {

            }
        }
    }


    #region 'Arvind Email Criteria'
    #region 'SendMailToCutomer'
    protected void SendEmailCustomer()
    {
        try
        {

            string CustID = Session["CustID"].ToString();
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime DE = DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            String Datetime = DE.ToString("dd-MMM-yyyy");
            DataSet StrEmailID = ObjDAL.InqTypeEmailID(CustID, "GetCustEmail",0);
            string TO = "";
            string Messgae = string.Empty;

            if (StrEmailID.Tables[0].Rows.Count > 0)
            {
                if(StrEmailID.Tables[0].Rows[0]["EmailID"].ToString() != "")
                TO = StrEmailID.Tables[0].Rows[0]["EmailID"].ToString();
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(TO);
                
                String MFromID = ConfigurationManager.AppSettings["FromMail"].ToString();
                String MPwd = ConfigurationManager.AppSettings["Password"].ToString();
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromMail"].ToString());

                mailMessage.Bcc.Add(new MailAddress("n.shah12@gmail.com"));

                //mailMessage.From = new MailAddress("wecare@chetanapublications.com");
                mailMessage.Subject = "Inquiry Received: " + Datetime;
                string body = "Dear  " + Session["CustName"].ToString() + "," + "\n\n";
                body += "Your inquiry has been successfully received." + "\n\n";
                body += "Inquiry ticket number: " + TktNumber + "\n\n";
                body += "Please use the above ticket number for future reference." + "\n\n\n";
                body += "Regards" + "," + "\n";
                body += "Chetana" + "\n";
                mailMessage.Body = body;
                SmtpClient smtp = new SmtpClient();

                smtp.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(MFromID, MPwd);
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Enablessl"].ToString());

                try
                {
                    smtp.Send(mailMessage);
                    display = "Mail Sent";

                  //  Messgae = "Mail Sent";
                }
                catch (Exception ex)
                {
                    display = ex.Message;
                    //Messgae = ex.Message;
                   // display = ex.Message;
                }
               

               
                Messgae = "Inquiry saved successfully with ticket number " + TktNumber + " " + display;
                ScriptManager.RegisterStartupScript(UpdatePanel1385, UpdatePanel1385.GetType(), "popup", "alert('" + Messgae + "');", true);
            }
            else
            {
               // string Messgae = string.Empty;
                Messgae = "Inquiry saved successfully with ticket number" + TktNumber + " " + display;
                ScriptManager.RegisterStartupScript(UpdatePanel1385, UpdatePanel1385.GetType(), "popup", "alert('" + Messgae + "');", true);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }

    }
    #endregion
    #region 'Email Criteria....'

    protected void SendActivationEmail()
    {
        try
        {

            eq.CustID = Session["CustID"].ToString();
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime DE = DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            String Datetime = DE.ToString("dd-MMM-yyyy");

            string CustID = Session["CustID"].ToString();

            DataTable DT = new DataTable();
            DataSet StrEmailID = ObjDAL.InqTypeEmailID(CustID, "GetEmail",Convert.ToInt32(iqnRadioButtonList.SelectedValue.ToString()));
             string TO ="";
            if (StrEmailID.Tables[0].Rows.Count > 0)
            {
              //  string TO = "minakshi@technople.com";
                 if( StrEmailID.Tables[0].Rows[0]["EmailFrom"].ToString() != "")
                 TO = StrEmailID.Tables[0].Rows[0]["EmailFrom"].ToString();
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(TO);

                String MFromID = ConfigurationManager.AppSettings["FromMail"].ToString();
                String MPwd = ConfigurationManager.AppSettings["Password"].ToString();
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromMail"].ToString());

                mailMessage.Subject = StrEmailID.Tables[0].Rows[0]["EmailSub"].ToString() + ": " + Datetime;
                string body = StrEmailID.Tables[0].Rows[0]["EmailBody"].ToString() + "," + "\n\n";
                //body += "Your inquiry has been successfully received." + "\n\n";
                body += "Inquiry ticket number: " + Session["TicketGet"].ToString() + "\n\n";
                //body += "Please use the above ticket number for future reference." + "\n\n\n";
                body += StrEmailID.Tables[0].Rows[0]["EmailSign"].ToString() + "," + "\n";


                mailMessage.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(MFromID, MPwd);
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Enablessl"].ToString());

                smtp.Send(mailMessage);

                string Messgae = string.Empty;

                Messgae = "Ticket: " + TktNumber + "raised successfully. Email sent to customer.";
                ScriptManager.RegisterStartupScript(UpdatePanel1385, UpdatePanel1385.GetType(), "popup", "alert('" + Messgae + "');", true);
            }
            else
            {
                string Messgae = string.Empty;
                Messgae = "Ticket: " + TktNumber + "raised successfully. Email not sent to customer.";
                ScriptManager.RegisterStartupScript(UpdatePanel1385, UpdatePanel1385.GetType(), "popup", "alert('" + Messgae + "');", true);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
    }
    #endregion
    #endregion


    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        BindReset();
    }
    protected void gvRemarks_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmdCancel.Visible = true;
        cmdUpdate.Visible = true;
        GridViewRow row = gvRemarks.SelectedRow;
        Label _LabelId = row.FindControl("InquiryDate") as Label;
        Label _LabelNumber1 = row.FindControl("Remarks") as Label;
        Label _LabelNumber2 = row.FindControl("EmpName") as Label;

        lblTicket.Text = ViewState["TktNumber"].ToString();
        lblDate.Text = _LabelId.Text;
        lblRemarks.Text = _LabelNumber1.Text;
        lblEmpName.Text = _LabelNumber2.Text;
        ModalPopupExtender2.Show();
        UpdatePanel13.Update();
    }
    protected void gvRemarks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Style["display"] = "none";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeff00';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
            e.Row.Attributes["onclick"] = "this.style.textDecoration='hand';this.style.background='#ffffff';";
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvRemarks, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
            Label lblRemarks = (Label)e.Row.FindControl("Remarks");
            string Tooltips = lblRemarks.Text;
            e.Row.Cells[3].Attributes.Add("title", Tooltips);

        }
    }
    protected void lblTicketNumber_Click(object sender, EventArgs e)
    {
        eq.TKTID = Session["TKTID"].ToString();
        DataSet DSR = ObjDAL.GetGridRmkAll(eq.TKTID);
        if (DSR.Tables[0].Rows.Count > 0)
        {
            popGridview.DataSource = DSR;
            popGridview.DataBind();
            popGridview.Visible = true;
            popGridview.DataBind();
            ModalPopupExtender3.Show();
            UpdatePanel15.Update();
        }
    }
}

