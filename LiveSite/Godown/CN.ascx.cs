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

public partial class Godown_CN : System.Web.UI.UserControl
{
    #region Variables
    string UserName = string.Empty;
    string strChetanaCompanyName = string.Empty;
    string strFY = string.Empty;
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
                if (!Page.IsPostBack)
                {
                    onNotPostback();
                }
            }
            else
            {
                Session.Clear();

            }
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {
            Session["getcntempdata"] = null;

        }

    }

    #region Methods

    #region Save Main

    public void SaveMain()
    {
        string newDate = "";
        try
        {

            G_CN _objCN = new G_CN();
            if (lblEditMode.Text == "edit")
            {
                _objCN.GCN_ID = Convert.ToInt32(lblGcnId.Text);
                _objCN.GCN_NO = txtGCNNo.Text.Trim();
                if (txtGCNDate.Text.Trim() == "")
                {
                    newDate = DateTime.Now.ToString("MM/dd/yyyy");
                }
                else
                {
                    newDate = txtGCNDate.Text.Split('/')[1] + "/" + txtGCNDate.Text.Split('/')[0] + "/" + txtGCNDate.Text.Split('/')[2];
                }


                _objCN.GCN_DATE = Convert.ToDateTime(newDate);
                _objCN.SALES_REPRESENTATIVE = txtSalesREp.Text.Trim();
                _objCN.SCHL_NAME = txtSchool.Text.Trim();
                _objCN.SCHL_ID = Convert.ToInt32(lblSchoolID.Text.Trim());
                _objCN.SALESMAN_CN_NO = txtSalesManRecNo.Text.Trim();
                _objCN.AREA =txtArea.Text.Trim();
                _objCN.Created_By = UserName;
                _objCN.Updated_By = UserName;
                _objCN.Narration = txtNarration.Text.Trim();
                _objCN.Fy = Convert.ToInt32(strFY);
                _objCN.Save();
                MessageBox("Record saved successfully");
                Clear();
                txtGCNNo.Text = "";
                Session["getcntempdata"] = null;
                grdTemp.DataSource = null;
                grdTemp.DataBind();

            }
            else
            {
                if (grdTemp.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdTemp.Rows)
                    {
                        _objCN.GCN_ID = Convert.ToInt32(((Label)(row.FindControl("lblnewid"))).Text.Trim());
                        _objCN.GCN_NO = ((Label)(row.FindControl("lblGCN_NO"))).Text.Trim();
                        string GCNDate = ((Label)(row.FindControl("lblGCN_Date"))).Text.Trim();
                        if (GCNDate.ToString() == "")
                        {
                            newDate = DateTime.Now.ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            newDate = GCNDate.Split('/')[1] + "/" + GCNDate.Split('/')[0] + "/" + GCNDate.Split('/')[2];
                        }


                        _objCN.GCN_DATE = Convert.ToDateTime(newDate);
                        _objCN.SALES_REPRESENTATIVE = ((Label)(row.FindControl("lblSALES_REP"))).Text.Trim();
                        _objCN.SCHL_NAME = ((Label)(row.FindControl("lblSCHL_NAME"))).Text.Trim();
                        _objCN.SCHL_ID = Convert.ToInt32(((Label)(row.FindControl("lblSCHL_ID"))).Text.Trim());
                        _objCN.SALESMAN_CN_NO = ((Label)(row.FindControl("lblSALES_CN_NO"))).Text.Trim();
                        _objCN.AREA = ((Label)(row.FindControl("lblSCHL_AREA"))).Text.Trim();
                        _objCN.Created_By = UserName;
                        _objCN.Updated_By = UserName;
                        _objCN.Narration = ((Label)(row.FindControl("lblNAR"))).Text.Trim();
                        _objCN.Fy = Convert.ToInt32(strFY);
                        _objCN.Save();
                        MessageBox("Record saved successfully");

                        Clear();
                        Session["getcntempdata"] = null;
                        grdTemp.DataSource = null;
                        grdTemp.DataBind();

                    }
                }

                else
                {
                    MessageBox("No Record found!!!");
                }
            }
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                MessageBox("Record updated successfully");
            }
            else
            {
                //MessageBox("Record saved successfully");
                //Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox("Error : " + ex.Message.ToString());
        }
    }

    #endregion

    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        SaveMain();
    }

    #region Cust Text Change

    public void callTextChange()
    {
        string CustCode = txtSchool.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

        if (dt.Rows.Count != 0)
        {
            if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
            {
                lblCustomer.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                txtSchool.Text = CustCode;
                lblSchoolID.Text = Convert.ToString(dt.Rows[0]["CustID"]);
                txtArea.Text = lblCustomer.Text.ToString().Split(':')[2].Trim();
                txtSalesManRecNo.Focus();
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
                txtSchool.Focus();
                txtSchool.Text = "";
                //srate = "";
            }
        }
        else
        {
            lblCustomer.Text = "No such Customer code";
            txtSchool.Focus();
            txtSchool.Text = "";
            //srate = "";
        }
    }



    #endregion

    #region On not postback

    public void onNotPostback()
    {

        txtGCNDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        CallButonVisible("new");
        lblID.Text = "0";
        txtGCNNo.Focus();
    }

    #endregion

    #region School text change

    protected void txtSchool_TextChanged(object sender, EventArgs e)
    {
        callTextChange();
        btnSaveDetails.Visible = true;
    }

    #endregion

    #region Delete

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Other_G obj = new Other_G();
        obj.DeleteModule(lblDocNo.Text.Trim(), "cn", "");
        MessageBox("Info ! \\r\\n Record Deleted!!!");
        Clear();
        CallButonVisible("new");
    }

    #endregion

    #region Clear

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
        txtGCNNo.Text = "";

    }

    public void Clear()
    {
        lblDocNo.Text = "0";
        txtGCNDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //txtGCNNo.Text = "";
        txtSchool.Text = "";
        txtSalesREp.Text = "";
        txtArea.Text = "";
        txtSalesManRecNo.Text = "";
        lblCustomer.Text = "";
        lblSchoolID.Text = "";
        lblEditMode.Text = "add";
        lblGcnId.Text = "0";
        txtNarration.Text = "";
        CallButonVisible("new");



    }

    #endregion

    public void CallButonVisible(string mode)
    {
        if (mode == "edit")
        {
            btnDelete.Visible = true;
            btnClear.Visible = true;
            btn_Save.Visible = true;
            btn_Edit.Visible = false;
        }
        else if (mode == "new")
        {
            btnDelete.Visible = false;
            btnClear.Visible = true;
            btn_Save.Visible = true;
            btn_Edit.Visible = true;
            txtGCNNo.Focus();
        }
        else if (mode == "view")
        {
            btnDelete.Visible = false;
            btnClear.Visible = true;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
        }


    }

    #region Fill Edit Form

    public void fillEditForm()
    {
        Clear();
        DataTable dt = G_CN.GetCNOnDocNo(0, txtDocIdEdit.Text.Trim(), Convert.ToInt32(strFY)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataTable dt1 = new DataTable();

            dt1.Columns.Add("GCN_ID");
            dt1.Columns.Add("GCN_NO");
            dt1.Columns.Add("GCN_Date");
            dt1.Columns.Add("SALES_REP");
            dt1.Columns.Add("SCHL_ID");
            dt1.Columns.Add("SCHL_NAME");
            dt1.Columns.Add("SCHL_AREA");
            dt1.Columns.Add("SALES_CN_NO");
            dt1.Columns.Add("NAR");



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt1.Rows.Add(dt.Rows[i]["GCN_ID"].ToString(), dt.Rows[i]["GCN_NO"].ToString(), dt.Rows[i]["GCN_DATE"].ToString(), dt.Rows[i]["SALES_REPRESENTATIVE"].ToString(), dt.Rows[i]["SCHL_ID"].ToString(), dt.Rows[i]["SCHL_NAME"].ToString(), dt.Rows[i]["AREA"].ToString(), dt.Rows[i]["SALESMAN_CN_NO"].ToString(), dt.Rows[i]["Narration"].ToString());
            }
            Session["getcntempdata"] = dt1;
            grdTemp.DataSource = Session["getcntempdata"];
            grdTemp.DataBind();
            //string date = (Convert.ToDateTime(dt.Rows[0]["GCN_DATE"].ToString())).ToString("dd/MM/yyyy");
            //lblDocNo.Text = dt.Rows[0]["GCN_ID"].ToString();
            //lblID.Text = dt.Rows[0]["GCN_ID"].ToString();
            //txtGCNNo.Text = dt.Rows[0]["GCN_NO"].ToString();
            //txtSalesREp.Text = dt.Rows[0]["SALES_REPRESENTATIVE"].ToString();
            //lblCustomer.Text = dt.Rows[0]["CustomerName"].ToString();
            //lblSchoolID.Text = dt.Rows[0]["SCHL_ID"].ToString();
            //txtSchool.Text = dt.Rows[0]["SCHL_NAME"].ToString();
            //txtArea.Text = dt.Rows[0]["AREA"].ToString();
            //txtSalesManRecNo.Text = dt.Rows[0]["SALESMAN_CN_NO"].ToString();
            //txtNarration.Text = dt.Rows[0]["Narration"].ToString();
            //txtGCNDate.Text = date;
            //CallButonVisible("edit");
            //txtGCNNo.Focus();

        }
        else
        {
            MessageBox("Info! : \\r\\n GCN. No. " + txtDocIdEdit.Text.Trim() + " Not Found!!!");
            //txtDocIdEdit.Text = "";
            //txtDocIdEdit.Focus();
            ModalPopUpDocNum.Show();

        }
    }

    #endregion

    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        fillEditForm();
    }
    protected void txtGCNNo_TextChanged(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();
        //ds = G_CN.GetCNOnDocNo(0,txtGCNNo.Text.Trim(),Convert.ToInt32(strFY));

        //if (ds.Tables[0].Rows.Count != 0)
        //{
        //    MessageBox("GCN No already Exist!!!");
        //    txtGCNNo.Text = "";
        //    txtGCNNo.Focus();
        //}

    }

    #region Button Click Add Temp Records

    protected void btnSaveDetails_Click(object sender, EventArgs e)
    {
        grdTemp.DataSource = fillTempBookData(txtGCNNo.Text.Trim());
        grdTemp.DataBind();
        Clear();
        txtGCNNo.Enabled = false;
       //btnSaveDetails.Visible = false;
        txtGCNDate.Focus();

    }
    #endregion


    #region TEMP DATA

    public DataTable fillTempBookData(string gcnno)
    {
        DataTable dt = new DataTable();
        if (Session["getcntempdata"] == null)
        {
            //CREATE NEW DATATABLE
            dt.Columns.Add("GCN_ID");
            dt.Columns.Add("GCN_NO");
            dt.Columns.Add("GCN_Date");
            dt.Columns.Add("SALES_REP");
            dt.Columns.Add("SCHL_ID");
            dt.Columns.Add("SCHL_NAME");
            dt.Columns.Add("SCHL_AREA");
            dt.Columns.Add("SALES_CN_NO");
            dt.Columns.Add("NAR");


        }
        else
        {
            //setHistoryView();

            dt = (DataTable)Session["getcntempdata"];
            txtGCNNo.Text=dt.Rows[0]["GCN_NO"].ToString();
            txtGCNNo.Enabled = false;
        }


        DataView dv = new DataView(dt);
        dv.RowFilter = "GCN_NO = " + gcnno + "";


        if (lblEditMode.Text == "edit")
        {
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["GCN_ID"] = lblGcnId.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["GCN_NO"] = txtGCNNo.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["GCN_Date"] = txtGCNDate.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SALES_REP"] = txtSalesREp.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SCHL_ID"] = lblSchoolID.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SCHL_NAME"] = txtSchool.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SCHL_AREA"] = txtArea.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SALES_CN_NO"] = txtSalesManRecNo.Text.Trim();
            dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["NAR"] = txtNarration.Text.Trim();
            Clear();
        }
        else
        {


            //if (dv.ToTable().Rows.Count > 0)
            //{
            //    MessageBox("Already Exist!!!");
            //    txtBillNo.Text = "";
            //    txtBillNo.Focus();


            //}
            //else
            //{



            dt.Rows.Add(lblGcnId.Text.Trim(), txtGCNNo.Text.Trim(), txtGCNDate.Text.Trim(), txtSalesREp.Text.Trim(), lblSchoolID.Text, txtSchool.Text.Trim(), txtArea.Text,
                        txtSalesManRecNo.Text.Trim(), txtNarration.Text.Trim());



            //}
        }
        Session["getcntempdata"] = dt;

        return dt;

    }

    #endregion

    #region Delete temp data

    protected void grdTemp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblGcnId.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblnewid"))).Text.Trim();
        txtGCNNo.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblGCN_NO"))).Text.Trim();
        txtGCNNo.Enabled = false;
        txtGCNDate.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblGCN_Date"))).Text.Trim();       
        txtSalesREp.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblSALES_REP"))).Text.Trim();
        lblSchoolID.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblSCHL_ID"))).Text.Trim();
        txtSchool.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblSCHL_NAME"))).Text.Trim();
        txtArea.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblSCHL_AREA"))).Text.Trim();
        txtSalesManRecNo.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblSALES_CN_NO"))).Text.Trim();
        txtNarration.Text = ((Label)(grdTemp.Rows[e.NewEditIndex].FindControl("lblNAR"))).Text.Trim();
        lblEditMode.Text = "edit";
        // btnClearEdit.Visible = true;
        RowID.Text = e.NewEditIndex.ToString();
        txtGCNDate.Focus();
        upCustomerName0.Update();
    }

    protected void grdTemp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int gid = Convert.ToInt32(((Label)grdTemp.Rows[e.RowIndex].FindControl("lblnewid")).Text);
        G_CN _obj = new G_CN();

        if (gid != 0)
        {
            _obj.GCN_ID = gid;
            _obj.DeleteCN();
        }
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["getcntempdata"];
        dt1.Rows[e.RowIndex].Delete();
        DataView dv = new DataView(dt1);
        dv.RowFilter = "GCN_ID is not null";
        grdTemp.DataSource = dv.ToTable();
        grdTemp.DataBind();
        Session["getcntempdata"] = dv.ToTable();
        loder("Successfully Deleted...", "3000");
        txtGCNNo.Focus();


    }

    #endregion


}