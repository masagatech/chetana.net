
#region Name Spaces

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

#endregion

#region Godown_GetPass_Local

public partial class Godown_GetPass_Local_Speciman : System.Web.UI.UserControl
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
            Session["getSpeciman_passtempdata"] = null;
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
            _obj.DC_No = Convert.ToInt32(txtDocNo.Text==""? "0":txtDocNo.Text);
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
            _obj.Remark2 = "speciman";
            int Doc_No_New = 0;
            if (grdTemp.Rows.Count > 0)
            {

                DocId = _obj.Save(out Doc_No_New);
                SaveSubRecords(DocId, Doc_No_New);
                if (isprint)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Godown/print/LocalGodownPrint.aspx?d=" + Doc_No_New + "&L=" + Localout + "')", true);
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
                obj.Updated_By = "Speciman";
                obj.Save();
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
        DataSet ds = G_GetPass.Local_GetPass_DCNo_BillNo_Validation(Convert.ToDecimal(txtDcNo.Text.Trim()), txtBillNo.Text.Trim(), Convert.ToInt32(strFY), "spec_check");
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
        if (Session["getSpeciman_passtempdata"] == null)
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
            dt = (DataTable)Session["getSpeciman_passtempdata"];
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
        Session["getSpeciman_passtempdata"] = dt;

        return dt;

    }

    #endregion

    #region set todays date

    public void onNotPostback()
    {
        txtDocDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        AutoExtDocno.ContextKey = "Specimen-" + strFY;
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
        dt = DCMaster.Get_Name(CustCode, "Employee").Tables[0];

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
        Session["getSpeciman_passtempdata"] = null;
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
        dt1 = (DataTable)Session["getSpeciman_passtempdata"];
        dt1.Rows[e.RowIndex].Delete();
        DataView dv = new DataView(dt1);
        dv.RowFilter = "DOC_SUB_ID is not null";
        grdTemp.DataSource = dv.ToTable();
        grdTemp.DataBind();
        Session["getSpeciman_passtempdata"] = dv.ToTable();
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
        DataSet ds = G_GetPass.GetpassOnDocNo(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "L", Convert.ToInt32(strFY));
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
        
        Session["getSpeciman_passtempdata"] = dt;
        grdTemp.DataSource = dt;
        grdTemp.DataBind();

    }

    #region Text changed event

    protected void txtCust_TextChanged(object sender, EventArgs e)
    {

        //callTextChange();
        txtArea.Focus();
    }

    protected void txtDcNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = Other_G.getInfoNoForGodown(Convert.ToInt32(strFY), Convert.ToInt32(txtDcNo.Text), "speciman");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCust.Text = "";
            txtCust.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();

            lblCustomer.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblCustID.Text = ds.Tables[0].Rows[0]["EmpID"].ToString();

            //txtArea.Text = txtCust.Text.Trim().Split(':')[4].ToString();
            //callTextChange();
            txtBillNo.Focus();
        }
        else
        {
            txtCust.Text = "";
            lblCustomer.Text = "No such Sales Man code";

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

    protected void btn_Edit_Click(object sender, EventArgs e)
    {

    }
}

#endregion
