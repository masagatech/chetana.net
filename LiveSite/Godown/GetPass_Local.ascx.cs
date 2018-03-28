#region Name Spaces

using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using Idv.Chetana.BAL;
using System.Text;
using System.Net.Mail;

#endregion

#region Godown_GetPass_Local

public partial class Godown_GetPass_Local : System.Web.UI.UserControl
{
    #region Variables
    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;
    #endregion

    #region Page Load

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
            Session["getpasstempdata"] = null;
            onNotPostback();
            if (txtDocNo.Enabled == false)
                txtDocDate.Focus();
            else
                txtDocNo.Focus();
        }

    }

    #endregion

    #region Vehicle

    protected void txtVehicle_TextChanged(object sender, EventArgs e)
    {
        string Vehicle = txtVehicle.Text.ToString();
        if (Vehicle.Split(':').Length > 1)
        {
            lblVehicleNoID.Text = Vehicle.Split(':')[0].ToString();
            lblVehicleNo.Text = Vehicle.Split(':')[1].ToString();
            lblVehicleNo.Visible = true;

        }
        else
        {
            MessageBox("Not Exist");
            txtVehicle.Text = "";
            txtVehicle.Focus();
        }
    }

    #endregion

    #region Driver

    protected void txtDriver_TextChanged(object sender, EventArgs e)
    {
        string Driver = txtDriver.Text;
        if (Driver.Split(':').Length > 1)
        {
            lblDriverID.Text = Driver.Split(':')[0].ToString();
            lblDriver.Text = Driver.Split(':')[2].ToString();
            lblDriver.Visible = true;
        }
        else
        {
            MessageBox("Not Exist");
            txtDriver.Text = "";
            txtDriver.Focus();
        }
    }

    #endregion

    #region Delivery Boy

    protected void txtDiliveryboy_TextChanged(object sender, EventArgs e)
    {
        try
        {

            string DelBoy = txtDiliveryboy.Text;
            if (DelBoy.Split(':').Length > 0)
            {
                lblDeliveryBoyID.Text = DelBoy.Split(':')[0].ToString();
                lblDeliveryBoy.Text = DelBoy.Split(':')[3].ToString();
                lblDeliveryBoy.Visible = true;
            }
            else
            {
                MessageBox("Not Exist");
                txtDiliveryboy.Text = "";
                txtDiliveryboy.Focus();
            }

        }
        catch
        {


        }
    }

    #endregion

    #region  Button save

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        SaveMain(false);
    }

    protected void btn_PrintSave_Click(object sender, EventArgs e)
    {
        SaveMain(true);

    }

    #endregion

    #region Method

    #region Save Main

    int DocId = 0;
    string Localout = string.Empty;
    public void SaveMain(bool isprint)
    {
        try
        {
            string Docdate = txtDocDate.Text.Split('/')[1] + "/" + txtDocDate.Text.Split('/')[0] + "/" + txtDocDate.Text.Split('/')[2];
            G_GetPass _obj = new G_GetPass();
            _obj.Doc_ID = Convert.ToInt32(lblDocNo.Text.Trim());
            _obj.DC_No = Convert.ToInt32(0);
            _obj.Doc_Date = Convert.ToDateTime(Docdate);
            _obj.Veh_ID = Convert.ToInt32(lblVehicleNoID.Text.Trim());
            _obj.Driver_ID = Convert.ToInt32(lblDriverID.Text.Trim());
            _obj.Driver_Name = lblDriver.Text.Trim();
            _obj.Area = ddlArea.SelectedValue.ToString();
            _obj.Deliveruy_Boy_ID = Convert.ToInt32(lblDeliveryBoyID.Text.Trim());
            _obj.Deliveruy_Boy = lblDeliveryBoy.Text.Trim();
            _obj.Fy = Convert.ToInt32(strFY);
            _obj.Amount = 0;
            _obj.Local_Out = "L";
            Localout = "L";
            _obj.Value_Goods = 0;
            _obj.Created_By = UserName;
            _obj.Updated_By = UserName;
            int Doc_No_New = 0;
            if (grdTemp.Rows.Count > 0)
            {

                DocId = _obj.Save(out Doc_No_New);
                SaveSubRecords(DocId, Doc_No_New);
                if (isprint)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Godown/print/LocalGodownPrint.aspx?d=" + DocId + "&L=" + Localout + "')", true);
                }
                Clear();
                CallButonVisible("new");

            }
            else
            {
                MessageBox("Please Enter complete details before saving !!!");
            }



        }
        catch (Exception ex)
        {
            MessageBox("Error! : " + ex.Message.ToString());
        }

    }

    #endregion

    #region Save Sub

    public void SaveSubRecords(int DocId, int DocIdnew)
    {
        try
        {
            G_GetPassSub obj = new G_GetPassSub();
            obj.DOC_ID = DocId;
            int SCD;
            DataSet ds = new DataSet();
            CourierDetails _objCD = new CourierDetails();
            _objCD.SaveDispatchEmailDetails(Convert.ToInt32(DocIdnew), "O", Convert.ToInt32(strFY), Convert.ToString(Session["UserName"]), out SCD);
            foreach (GridViewRow row in grdTemp.Rows)
            {
                obj.DOC_SUB_ID = Convert.ToInt32(((Label)(row.FindControl("lblSubID"))).Text.Trim());
                obj.DC_NO = Convert.ToInt32(((Label)(row.FindControl("lblDcNo"))).Text.Trim());
                obj.BILL_NO = ((Label)(row.FindControl("lblBillNo"))).Text.Trim();
                obj.SCHL_NAME = ((Label)(row.FindControl("lblCustName"))).Text.Trim();
                obj.SCHL_AREA = ((Label)(row.FindControl("lblArea"))).Text.Trim();
                obj.NO_OF_BUNDLES = ((Label)(row.FindControl("lblNoOfBundles"))).Text.Trim();
                obj.DELIVERY = ((CheckBox)(row.FindControl("ChkDelivery"))).Checked;
                obj.Cust_ID = Convert.ToInt32(((Label)(row.FindControl("lblCustid"))).Text.Trim());
                obj.Created_By = UserName;
                obj.Updated_By = UserName;
                obj.Save();
                ds = G_GetPass.CustEMail_LocalEntry(obj.Cust_ID);
                String CustEmailId = "";
                if (ds.Tables.Count != 0)
                {
                    CustEmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();

                    if (CustEmailId.Trim() != "")
                    {

                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress("wecare@chetanapublications.com");
                        msg.To.Add(new MailAddress("accounts1@chetanapublications.com"));
                        msg.To.Add(new MailAddress(CustEmailId));
                        msg.To.Add(new MailAddress("chetanabookdepot1@gmail.com"));
                         
                       
                        msg.Subject = "Chetana Book Depot";
                        msg.Body = MailBodyDesign(obj.SCHL_NAME, obj.DC_NO, obj.NO_OF_BUNDLES).ToString();
                        msg.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "crm.chetanapublications.com";
                        smtp.Port = 25;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
                        smtp.EnableSsl = false;

                        try
                        {
                            smtp.Send(msg);
                            DataSet DsMailLog = new DataSet();
                            string mDocumentNo = obj.DC_NO.ToString();
                            DsMailLog = CourierDetails.SendDispatchEmail(SCD, float.Parse(mDocumentNo), "DispatchEmail", "DispatchId", Convert.ToInt32(strFY), "wecare@chetanapublications.com", "we0504260", Convert.ToString(Session["UserName"]));
                            //MessageBox("Mail Sent successfully");

                        }
                        catch (Exception ex)
                        {
                            //MessageBox(ex.Message);
                        }

                    }
                }

            }

            MessageBox("Data Saved! \\r\\n Documennt no." + DocIdnew);
        }
        catch (Exception ex)
        {
            MessageBox("Error! : " + ex.Message.ToString());
        }

    }

    #endregion

    #region Button Click Add Temp Records

    protected void btnSaveDetails_Click(object sender, EventArgs e)
    {
        DataSet ds = G_GetPass.Local_GetPass_DCNo_BillNo_Validation(Convert.ToDecimal(txtDcNo.Text.Trim()), txtBillNo.Text.Trim(), Convert.ToInt32(strFY), "check");
        if (lblEditMode.Text != "edit")
        {
            if ((ds.Tables[0].Rows.Count > 0))
            {

                MessageBox(ds.Tables[0].Rows[0][0].ToString());
                
            }
            else
            {
                grdTemp.DataSource = fillTempBookData(txtBillNo.Text.Trim(), txtDcNo.Text.Trim());
                grdTemp.DataBind();
                clearStrip();
              
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0][1] == "1")
                {
                    MessageBox(ds.Tables[0].Rows[0][0].ToString());
                    
                }
                else
                {
                    grdTemp.DataSource = fillTempBookData(txtBillNo.Text.Trim(), txtDcNo.Text.Trim());
                    grdTemp.DataBind();
                    clearStrip();
                 
                }

            }

        }

        txtDcNo.Focus();

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

    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        fillEditForm();

    }
    #endregion

    #region TEMP DATA

    public DataTable fillTempBookData(string BillNo, string DcNo)
    {
        DataTable dt = new DataTable();
        if (Session["getpasstempdata"] == null)
        {
            //CREATE NEW DATATABLE
            dt.Columns.Add("DOC_SUB_ID");
            dt.Columns.Add("DC_NO");
            dt.Columns.Add("BILL_NO");
            dt.Columns.Add("SCHL_NAME");
            dt.Columns.Add("SCHL_AREA");
            dt.Columns.Add("NO_OF_BUNDLES");
            dt.Columns.Add("Delivery");
            dt.Columns.Add("SCHL_ID");


        }
        else
        {
            //setHistoryView();
            dt = (DataTable)Session["getpasstempdata"];
        }


        DataView dv = new DataView(dt);
        dv.RowFilter = "DC_NO = '" + DcNo + "' and BILL_NO = '" + BillNo + "'";


        if (lblEditMode.Text == "edit")
        {
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["DOC_SUB_ID"] = lblSubDocId.Text;
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["DC_NO"] = txtDcNo.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["BILL_NO"] = txtBillNo.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SCHL_NAME"] = lblCustomer.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SCHL_AREA"] = txtArea.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["NO_OF_BUNDLES"] = txtNoOfBundles.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["Delivery"] = chkDelivery.Checked;
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SCHL_ID"] = lblCustID.Text.Trim();
            clearStrip();
        }
        else
        {


            if (dv.ToTable().Rows.Count > 0)
            {
                MessageBox("Already Exist!!!");
                txtBillNo.Text = "";
                txtBillNo.Focus();


            }
            else
            {

                //DataTable dt1 = new DataTable();
                //dt1 = AccountMain.ACCodeGet(Accode).Tables[0];
                //if (dt1.Rows.Count > 0)
                //{
                //   if (dt1.Rows.Count > 1)
                //  {
                //      for (int i = 0; i < dt1.Rows.Count; i++)
                //     {
                //    dv.RowFilter = "AccountCode = '" + dt1.Rows[i]["Ac_Code"].ToString() + "'";
                //       if (dv.ToTable().Rows.Count <= 0)
                //      {

                dt.Rows.Add(lblSubDocId.Text, txtDcNo.Text.Trim(), txtBillNo.Text.Trim(), lblCustomer.Text.Trim(),
                    txtArea.Text.Trim(), txtNoOfBundles.Text.Trim(), chkDelivery.Checked, lblCustID.Text.Trim());
                //     }

                //    }

                //                }
                //              else
                //            {
                //              dt.Rows.Add(Accode, dt1.Rows[0]["Ac_Name"].ToString(), dt1.Rows[0]["Ac_int_Rat"].ToString());
                //        }
                //  }
                //  else
                // {
                //     MessageBox("Record not found!!!");
                // }


            }
        }
        Session["getpasstempdata"] = dt;

        return dt;

    }

    #endregion

    #region set todays date

    public void onNotPostback()
    {
        txtDocDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        AutoExtDocno.ContextKey = "g_docNo-" + strFY;
        txtDocNo.Text = "---New---";
        lblDocNo.Text = "0";
        CallButonVisible("new");

    }

    #endregion

    #region cust Text Change

    public void callTextChange()
    {
        string CustCode = txtCust.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

        if (dt.Rows.Count != 0)
        {
            if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
            {
                lblCustomer.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                txtCust.Text = CustCode;
                lblCustID.Text = Convert.ToString(dt.Rows[0]["CustID"]);

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
                txtCust.Focus();
                txtCust.Text = "";
                //srate = "";
            }
        }
        else
        {
            lblCustomer.Text = "No such Customer code";
            txtCust.Focus();
            txtCust.Text = "";
            //srate = "";
        }
    }



    #endregion

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

    #region ClearMethods

    public void clearStrip()
    {
        txtDcNo.Text = "";
        txtBillNo.Text = "";
        txtCust.Text = "";
        txtArea.Text = "";
        txtNoOfBundles.Text = "";
        lblCustomer.Text = "";
        lblEditMode.Text = "add";
        lblSubDocId.Text = "0";
        lblCustID.Text = "";
        btnClearEdit.Visible = false;
    }

    public void Clear()
    {
        lblDocNo.Text = "0";
        txtDocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDcNo.Text = "";
        txtDocNo.Text = "---New---";
        txtDriver.Text = "";
        txtVehicle.Text = "";
        lblDriver.Text = "";
        lblDriverID.Text = "0";
        txtDiliveryboy.Text = "";
        lblDeliveryBoy.Text = "";
        lblDeliveryBoyID.Text = "0";
        lblVehicleNo.Text = "";
        lblVehicleNoID.Text = "";

        clearStrip();
        Session["getpasstempdata"] = null;
        grdTemp.DataSource = null;
        grdTemp.DataBind();

    }

    #endregion

    #endregion

    #region Delete temp data

    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        decimal DC_No = Convert.ToDecimal(((Label)(grdTemp.Rows[e.RowIndex].FindControl("lblDcNo"))).Text);
        string Bill_No = ((Label)(grdTemp.Rows[e.RowIndex].FindControl("lblBillNo"))).Text;

        G_GetPass _objGetPass = new G_GetPass();
        _objGetPass.DC_No = DC_No;
        _objGetPass.Bill_Nos = Bill_No;
        _objGetPass.Fy = Convert.ToInt32(strFY);
        _objGetPass.Created_By = "DeleteUpdate";


        try
        {
            _objGetPass.Delete_Update_DCNo_BillNo();
        }
        catch
        {
        }

        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["getpasstempdata"];
        dt1.Rows[e.RowIndex].Delete();
        DataView dv = new DataView(dt1);
        dv.RowFilter = "DOC_SUB_ID is not null";
        grdTemp.DataSource = dv.ToTable();
        grdTemp.DataBind();
        Session["getpasstempdata"] = dv.ToTable();
        loder("Successfully Deleted...", "3000");
        //if (grdTempgrdTEmpData.Rows.Count > 0)
        //{
        //    getDetails.Enabled = true;
        //}
        //else
        //{
        //    getDetails.Enabled = false;
        //}
        txtDcNo.Focus();
        // upCodeUpdate.Update();

    }

    #endregion

    public void fillEditForm()
    {
        Clear();
        DataSet ds = G_GetPass.GetpassOnDocNo(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "DC", Convert.ToInt32(strFY));
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            string date = (Convert.ToDateTime(dt.Rows[0]["Doc_Date"].ToString())).ToString("dd/MM/yyyy");
            txtDocNo.Text = dt.Rows[0]["Doc_No"].ToString();
            lblDocNo.Text = dt.Rows[0]["Doc_ID"].ToString();
            txtDocDate.Text = date;
            txtDriver.Text = dt.Rows[0]["Driver_Name"].ToString();
            lblDriver.Text = dt.Rows[0]["Driver_Name"].ToString();
            lblDriver.Visible = true;
            lblDriverID.Text = dt.Rows[0]["Driver_ID"].ToString();
            txtVehicle.Text = dt.Rows[0]["Veh_no"].ToString();
            lblVehicleNo.Text = dt.Rows[0]["Veh_no"].ToString();
            lblVehicleNoID.Text = dt.Rows[0]["Veh_ID"].ToString();
            ddlArea.SelectedValue = dt.Rows[0]["Area"].ToString();
            txtDiliveryboy.Text = dt.Rows[0]["Deliveruy_Boy"].ToString();
            lblDeliveryBoy.Text = dt.Rows[0]["Deliveruy_Boy"].ToString();
            lblDeliveryBoy.Visible = true;
            lblDeliveryBoyID.Text = dt.Rows[0]["Deliveruy_Boy_ID"].ToString();
            filltempData(ds.Tables[1]);
            CallButonVisible("edit");
            txtDocDate.Focus();
        }
        else
        {
            MessageBox("Info! : \\r\\n Doc. No. " + txtDocIdEdit.Text.Trim() + " Not Found!!!");
            ModalPopUpDocNum.Show();
            txtDocIdEdit.Text = "";
            txtDocIdEdit.Focus();

        }
    }

    public void filltempData(DataTable dt)
    {
        
        Session["getpasstempdata"] = dt;
        grdTemp.DataSource = dt;
        grdTemp.DataBind();

    }

    #region Text changed event

    protected void txtCust_TextChanged(object sender, EventArgs e)
    {

        callTextChange();
        txtArea.Focus();
    }

    protected void txtDcNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = Other_G.getInfoNoForGodown(Convert.ToInt32(strFY), Convert.ToInt32(txtDcNo.Text), "dcno");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCust.Text = "";
            txtCust.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtArea.Text = txtCust.Text.Trim().Split(':')[4].ToString();
            callTextChange();
            txtBillNo.Focus();
        }
        else
        {
            txtCust.Text = "";
            lblCustomer.Text = "No such Customer code";

        }
        txtBillNo.Focus();
    }

    #endregion
    protected void grdTemp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblSubDocId.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblSubID"))).Text.Trim();
        txtDcNo.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblDcNo"))).Text.Trim();
        txtBillNo.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblBillNo"))).Text.Trim();
        txtCust.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblCustName"))).Text.Trim();
        lblCustomer.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblCustName"))).Text.Trim();
        txtArea.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblArea"))).Text.Trim();
        txtNoOfBundles.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblNoOfBundles"))).Text.Trim();
        chkDelivery.Checked = ((CheckBox)(grdTemp.Rows[e.NewEditIndex].FindControl("ChkDelivery"))).Checked;
        lblCustID.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblCustid"))).Text.Trim();
        lblEditMode.Text = "edit";
        btnClearEdit.Visible = true;
        RowID.Text = e.NewEditIndex.ToString();
        txtDcNo.Focus();
        upCustomerName0.Update();
    }
    protected void btnClearEdit_Click(object sender, EventArgs e)
    {
        clearStrip();

    }
    public StringBuilder MailBodyDesign(string CustName, decimal DCNo, string NO_OF_BUNDLES)
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

        stBody.Append(" 4TH  FLOOR, B WING, “BUILDING E”, TRADE LINK KAMALA CITY, ABOVE BOMBAY 	CANTEEN, LOWER PAREL, MUMBAI - 400013");              
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
        //stBody.Append(" <tr><td><b>Trasporter :</b></td><td>" + Trasporter + "</td></tr> ");
        stBody.Append(" <tr><td><b>No of Parcels :</b></td><td>" + NO_OF_BUNDLES + "</td></tr>");
        // stBody.Append(" <tr><td><b>LR No :</b></td><td>" + LR_No + "</td></tr> ");
        //stBody.Append(" <tr><td><b>LR Date :</b></td><td>" + LR_Date + "</td></tr> ");
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

#endregion
