
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
        //txtLrDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        
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

string LRdate = txtLrDate.Text.Split('/')[1] + "/" + txtLrDate.Text.Split('/')[0] + "/" + txtLrDate.Text.Split('/')[2];

            G_GetPass _obj = new G_GetPass();
            _obj.Doc_ID = Convert.ToInt32(lblDocNo.Text.Trim());
            _obj.DC_No = Convert.ToInt32(0);            
            _obj.Doc_Date = Convert.ToDateTime(Docdate);
            _obj.Transporter_ID = Convert.ToInt32(lblTransID.Text.Trim());
            _obj.Cust_ID = Convert.ToInt32(lblBranchID.Text.Trim());
            _obj.No_Bundles = txtNoOfBund.Text.Trim().ToString();

            if (txtValOfGoods.Text.Trim() == "")
            {
                _obj.Value_Goods = 0;
            }
            else
            {
                _obj.Value_Goods = Convert.ToDecimal(txtValOfGoods.Text.Trim());
            }

            _obj.Remark1 = txtRemark.Text.Trim();
            _obj.Sent_By = txtSentBy.Text.Trim();
            _obj.LR_No = txtLRNo.Text.Trim();
            _obj.LR_Date = Convert.ToDateTime(LRdate);

            _obj.Pay_Paid = rdoPaidStaus.SelectedValue.ToString();
            if (txtAmt.Text.Trim() == "")
            {
                _obj.Amount = 0;
            }
            else
            {
                _obj.Amount = Convert.ToDecimal(txtAmt.Text.Trim());
            }

            _obj.Delivery = chIsDelivery.Checked; 

            _obj.Fy = Convert.ToInt32(strFY);
            //_obj.Amount = 0;
            _obj.Local_Out = "O";
                Localout = "O";
            _obj.Remark2 = "B";
            //_obj.Value_Goods = 0;

            _obj.Created_By = UserName;
            _obj.Updated_By = UserName;
            int Doc_No_New = 0;
            if (grdTemp.Rows.Count > 0)
            {

                DocId = _obj.Save(out Doc_No_New);
                SaveSubRecords(DocId, Doc_No_New);
                if (isprint)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Godown/print/OutGodownPrint.aspx?d=" + DocId + "&L=" + Localout + "')", true);
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
                obj.Updated_By = UserName;
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
        DataSet ds = G_GetPass.Local_GetPass_DCNo_BillNo_Validation(Convert.ToDecimal(txtDcNo.Text.Trim()), txtBillNo.Text.Trim(), Convert.ToInt32(strFY), "check");
        if (lblEditMode.Text != "edit")
        {
          //  if ((ds.Tables[0].Rows.Count > 0))
          //  {

            //    MessageBox(ds.Tables[0].Rows[0][0].ToString());
                
          //  }
          //  else
            {
                grdTemp.DataSource = fillTempBookData(txtBillNo.Text.Trim(), txtDcNo.Text.Trim());
                grdTemp.DataBind();
                clearStrip();
              
            }
        }
        else
        {
          //  if (ds.Tables[0].Rows.Count > 0)
           // {

            //    if (ds.Tables[0].Rows[0][1] == "1")
             //   {
              //      MessageBox(ds.Tables[0].Rows[0][0].ToString());
                    
             //   }
            //    else
             //   {
                    grdTemp.DataSource = fillTempBookData(txtBillNo.Text.Trim(), txtDcNo.Text.Trim());
                    grdTemp.DataBind();
                    clearStrip();
                 
             //   }

           // }

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
        dt = DCMaster.Get_Name(CustCode, "customer").Tables[0];

        if (dt.Rows.Count != 0)
        {
                lblCustomer.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                txtCust.Text = CustCode;
                lblCustID.Text = Convert.ToString(dt.Rows[0]["CustID"]);
            
        }
        else
        {
            lblCustomer.Text = "No such Customer exist";
            txtCust.Focus();
            txtCust.Text = "";
            //srate = "";
        }
    }



    #endregion

    #region cust Text Change

    public void callTextChangeBranch()
    {
        string branchCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(branchCode, "branch").Tables[0];

        if (dt.Rows.Count != 0)
        {
            lblBranchName.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
            lblBranchID.Text = Convert.ToString(dt.Rows[0]["BranchID"]);
        }
        else
        {
            lblBranchName.Text = "No such Branch exist";
            txtcustomer.Focus();
            txtcustomer.Text = "";
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

        
        lblDocNo.Text = "0";
        txtDocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDcNo.Text = "";
     
        txtcustomer.Text = "";
        lblBranchID.Text = "";
        lblBranchName.Text = "";
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
        txtRemark.Text = "";

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
        DataSet ds = G_GetPass.GetpassOnDocNo(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "O", Convert.ToInt32(strFY));
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            string date = (Convert.ToDateTime(dt.Rows[0]["Doc_Date"].ToString())).ToString("dd/MM/yyyy");
            txtDocNo.Text = dt.Rows[0]["Doc_No"].ToString();
            lblDocNo.Text = dt.Rows[0]["Doc_ID"].ToString();
            txtDocDate.Text = date;
            fillTopGrid(ds.Tables[0]);
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

public void fillTopGrid(DataTable dt)
{
  string date = (Convert.ToDateTime(dt.Rows[0]["Doc_Date"].ToString())).ToString("dd/MM/yyyy");
            string LRdate = (Convert.ToDateTime(dt.Rows[0]["LR_Date"].ToString())).ToString("dd/MM/yyyy");
            txtDocNo.Text = dt.Rows[0]["Doc_No"].ToString();
            lblDocNo.Text = dt.Rows[0]["Doc_ID"].ToString();
            txtDcNo.Text = dt.Rows[0]["DC_No"].ToString();
            //txtBillNo.Text = dt.Rows[0]["Bill_Nos"].ToString();
            //lblclone.Text = dt.Rows[0]["Bill_Nos"].ToString();
            txtcustomer.Text = dt.Rows[0]["CustomerName"].ToString();
            lblBranchID.Text = dt.Rows[0]["Cust_ID"].ToString();
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

    #region cust Text Change

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        callTextChangeBranch();
        txttransporter.Focus();
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
                //  ACExttransporter.ContextKey = TransCode;

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
}


#endregion


