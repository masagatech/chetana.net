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
using System.Text;
using Other_Z;
using Idv.Chetana.BAL;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml;

public partial class G_GetPass_OutstationSpeciman : System.Web.UI.Page
{
    #region Variables
    OtherBAL.Speciman_Property ObjProperty = new OtherBAL.Speciman_Property();
    OtherBAL ObjBAL = new OtherBAL();
    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;
    #endregion

    #region Page Load Event
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
        }
        if (!Page.IsPostBack)
        {
            Session["getSpeciman_Details"] = null;
            onNotPostback();
            if (txtSpecimanNo.Enabled == false)
                txtSpecDate.Focus();
            else
                txtSpecimanNo.Focus();
        }
    }
    #endregion

    //Message Box
    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Clear() All TextBox Method
    private void Clear()
    {
        txtSpecDate.Text = DateTime.Now.ToString();
        txtBranch.Text = "";
        txttransporter.Text = "";
        txtNoOfParcels.Text = "";
        txtRemark.Text = "";
        txtValOfGoods.Text = "";
        txtSentBy.Text = "";
        txtLRNo.Text = "";
        txtLrDate.Text = "";
        chIsDelivery.Checked = false;
        btnDelete.Visible = false;
        grdTemp.Visible = false;
        txtSpecimanNo.Text = "0";
        clearStrip();
        Session["getSpeciman_Details"] = null;
        grdTemp.DataSource = null;
        grdTemp.DataBind();
        btn_Edit.Visible = true;
        btnDelete.Visible = false;

    }
    #endregion

    //Method
    #region Page Load Event Not POSTBACk
    public void onNotPostback()
    {
        txtSpecDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        AutoExtDocno.ContextKey = "Specimen-" + strFY;
        txtSpecimanNo.Text = "---New---";
        txtSpecimanNo.Text = "0";
        //CallButonVisible("new");
    }
    #endregion


    #region Save Speciman Details Method

   
    int SpecPrint = 0;
    private void SaveDetails()
    {
        try
        {

            string OrderDate = txtSpecDate.Text.Split('/')[1] + "/" + txtSpecDate.Text.Split('/')[0] + "/" + txtSpecDate.Text.Split('/')[2];

            if (txtLrDate.Text.Trim() == "")
            {
                txtLrDate.Text = "01/01/1999";
            }
            string LrDate = txtLrDate.Text.Split('/')[1] + "/" + txtLrDate.Text.Split('/')[0] + "/" + txtLrDate.Text.Split('/')[2];

            int SpecNo;
            int SpecMax;
            ObjProperty.SpecId = Convert.ToInt32(lblSpecId.Text);
            ObjProperty.SpecSeqNo = Convert.ToInt32(txtSpecimanNo.Text);
            ObjProperty.SpeDate = Convert.ToDateTime(OrderDate);
            ObjProperty.BranchCode = txtBranch.Text.ToString().Split(':')[0].ToString();
            ObjProperty.BranchName = txtBranch.Text;
            ObjProperty.TranspotCode = txttransporter.Text.ToString().Split(':')[0].ToString();
            ObjProperty.TranspportName = txttransporter.Text;
            ObjProperty.NoOfParcels = Convert.ToInt32(txtNoOfParcels.Text == "" ? "0" : txtNoOfParcels.Text);
            ObjProperty.Remark = txtRemark.Text;
            ObjProperty.valueOfGood = float.Parse(txtValOfGoods.Text);
            ObjProperty.SendBy = txtSentBy.Text;
            ObjProperty.LRNO = txtLRNo.Text;
            ObjProperty.LDDate = Convert.ToDateTime(LrDate);
            ObjProperty.Paid = Convert.ToInt32(rdoPaidStaus.SelectedValue);
            ObjProperty.Delivery = Convert.ToInt32(chIsDelivery.Checked == true ? 1 : 0);
            ObjProperty.FY = Convert.ToInt32(strFY);
            ObjProperty.CreatedBy = UserName;
            ObjProperty.Details = getDetailXml();
            ObjBAL.Idv_Chetana_Save_Godown_Speciman_Head(ObjProperty, out SpecMax, out SpecNo);
            MessageBox("Record save successfully Speciman No is  " + SpecMax.ToString());
            grdTemp.Visible = false;
            txtSpecimanNo.Text = SpecNo.ToString();
            SpecPrint = SpecMax;
            lblSpecId.Text = "0";
        }
        catch (Exception ex)
        {
            MessageBox(ex.ToString());
            throw;
        }

    }

    #endregion

    #region Create Xml Data With String
    private string getDetailXml()
    {
       // StringBuilder sb = new StringBuilder();
        XmlDocument doc = new XmlDocument();
        XmlNode node = doc.CreateElement("rt");
        foreach (GridViewRow row in grdTemp.Rows)
        {
            XmlNode element = doc.CreateElement("item");
            XmlNode nd = doc.CreateElement("sbid");
                nd.InnerText = ((Label)(row.FindControl("lblSubID"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("dc");
            nd.InnerText = ((Label)(row.FindControl("lblDcNo"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("blno");
            nd.InnerText = ((Label)(row.FindControl("lblBillNo"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("empcd");
            nd.InnerText = ((Label)(row.FindControl("lblCustid"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("empnm");
            nd.InnerText = ((Label)(row.FindControl("lblCustName"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("area");
            nd.InnerText = ((Label)(row.FindControl("lblArea"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("nbdl");
            nd.InnerText = ((Label)(row.FindControl("lblNoOfBundles"))).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("del");
            nd.InnerText = Convert.ToInt32(((CheckBox)(row.FindControl("ChkDelivery"))).Checked).ToString();
            element.AppendChild(nd);

            node.AppendChild(element);
        }
      
        return node.OuterXml.ToString();
    }
    #endregion

    #region Button Save Click Event
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        SaveDetails();
        Clear();
        txtSpecDate.Focus();
    }
    #endregion

    #region Save And Print Click Event
    protected void btn_PrintSave_Click(object sender, EventArgs e)
    {
         SaveDetails();
        if (lblEditMode.Text == "edit")
        {
            int SpecNo = Convert.ToInt32(txtDocIdEdit.Text);
            int FY = Convert.ToInt32(strFY);
            //Response.Redirect("GetPassOutStandingSpecimenReport.aspx?SpecNo=" + SpecNo);
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('GetPassOutStandingSpecimenReport.aspx?SpecNo=" + SpecNo + "');", true);
            Clear();
        }
        else
        {
            //int SpecNo = Convert.ToInt32(txtSpecimanNo.Text);
            int FY = Convert.ToInt32(strFY);
            //Response.Redirect("GetPassOutStandingSpecimenReport.aspx?SpecNo=" + SpecNo);
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('GetPassOutStandingSpecimenReport.aspx?SpecNo=" + SpecPrint + "');", true);
            Clear();
        }

    }
    #endregion

    #region Get Edit Data Click Event
    protected void BtnGetDCDetails_Click(Object sender, EventArgs e)
    {
        int SpecNo = Convert.ToInt32(txtDocIdEdit.Text);
        int FY = Convert.ToInt32(strFY);
        DataSet ds = ObjBAL.Idv_Chetana_Get_Godown_Speciman_Head(SpecNo, FY, "SpcimanEdit");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnDelete.Visible = true;
            lblSpecId.Text = dt.Rows[0]["SpecAutoId"].ToString();
            txtSpecimanNo.Text = dt.Rows[0]["SpecSeqNo"].ToString();
            txtSpecDate.Text = dt.Rows[0]["SpeDate"].ToString();
            txtBranch.Text = dt.Rows[0]["BranchName"].ToString();
            txttransporter.Text = dt.Rows[0]["TranspportName"].ToString();
            txtNoOfParcels.Text = dt.Rows[0]["NoOfParcels"].ToString();
            txtRemark.Text = dt.Rows[0]["Remark"].ToString();
            txtValOfGoods.Text = dt.Rows[0]["valueOfGood"].ToString();
            txtSentBy.Text = dt.Rows[0]["SendBy"].ToString();
            txtLRNo.Text = dt.Rows[0]["LRNO"].ToString();
            txtLrDate.Text = dt.Rows[0]["LDDate"].ToString();
            rdoPaidStaus.SelectedValue = Convert.ToInt32(dt.Rows[0]["Paid"]).ToString();
            chIsDelivery.Checked = Convert.ToBoolean(dt.Rows[0]["Delivery"].ToString());
            filltempData(ds.Tables[1]);
            CallButonVisible("edit");
            grdTemp.Visible = true;
            txtSpecDate.Focus();
        }
        else
        {
            MessageBox("Info! : \\r\\n Doc. No. " + txtDocIdEdit.Text.Trim() + " Not Found!!!");
            ModalPopUpDocNum.Show();
            txtDocIdEdit.Text = "";
            txtDocIdEdit.Focus();
        }

    }
    #endregion

    #region Button Delete Click Event
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ObjProperty.SpecId = Convert.ToInt32(txtSpecimanNo.Text);
        ObjProperty.R1 = "Delete";
        int SpecNo;
        int SpecMax;
        ObjProperty.Details = "<tr></tr>";
        ObjBAL.Idv_Chetana_Save_Godown_Speciman_Head(ObjProperty, out SpecMax, out SpecNo);
        MessageBox("Record delete successfully speciman no is " + SpecNo.ToString());
        btnDelete.Visible = false;
        Clear();
        txtSpecimanNo.Text = SpecMax.ToString();
    }
    #endregion

    #region Button Clear Click Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
        txtSpecDate.Focus();
    }
    #endregion

    #region Grid View Edit Clear button click event
    protected void btnClearEdit_Click(object sender, EventArgs e)
    {
        clearStrip();
    }
    #endregion

    #region Get Customer Name With Customer Code Method
    private void GetCustomerName()
    {
        string CustCode = txtCust.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = ObjBAL.Idv_Chetana_Get_CustomerName(CustCode, "Flag").Tables[0];

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
        }
    }
    #endregion

    #region DcNo OnChange Event
    protected void txtDcNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = Other_G.getInfoNoForGodown(Convert.ToInt32(strFY), Convert.ToInt32(txtDcNo.Text), "speciman");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCust.Text = "";
            txtCust.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
            txtArea.Text = ds.Tables[0].Rows[0]["City"].ToString();
            lblCustomer.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblCustID.Text = ds.Tables[0].Rows[0]["EmpID"].ToString();

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

    #region Loader Time Hold
    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    #endregion

    #region Row Delete Event
    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int SpecId = Convert.ToInt32(((Label)(grdTemp.Rows[e.RowIndex].FindControl("lblSubID"))).Text);
        string Bill_No = ((Label)(grdTemp.Rows[e.RowIndex].FindControl("lblBillNo"))).Text;

        ObjProperty.SpecId = SpecId;
        ObjProperty.R1 = "Del";
        int SpecNo;
        int SpecMax;
        ObjProperty.Details = "<tr></tr>";

        try
        {
            ObjBAL.Idv_Chetana_Save_Godown_Speciman_Head(ObjProperty, out SpecMax, out SpecNo);
        }
        catch (Exception ex)
        {

        }

        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["getSpeciman_Details"];
        dt1.Rows[e.RowIndex].Delete();
        DataView dv = new DataView(dt1);
        dv.RowFilter = "SpecAutoId is not null";
        grdTemp.DataSource = dv.ToTable();
        grdTemp.DataBind();
        Session["getSpeciman_Details"] = dv.ToTable();
        loder("Successfully Deleted...", "3000");
        txtDcNo.Focus();
    }
    #endregion

    #region Button Click Add Temp Records

    protected void btnSaveDetails_Click(object sender, EventArgs e)
    {
        DataSet ds = G_GetPass.Local_GetPass_DCNo_BillNo_Validation(Convert.ToDecimal(txtDcNo.Text.Trim()), txtBillNo.Text.Trim(), Convert.ToInt32(strFY), "SpecBill");
        if (lblEditMode.Text != "edit")
        {
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                grdTemp.Visible = true;
                grdTemp.DataSource = fillTempBookData(txtBillNo.Text.Trim(), txtDcNo.Text.Trim());
                grdTemp.DataBind();
                clearStrip();

            }
        }
        else
        {
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    if (ds.Tables[0].Rows[0][1] == "1")
            //    {
            //        MessageBox(ds.Tables[0].Rows[0][0].ToString());

            //    }
            //    else
            //    {
            grdTemp.Visible = true;
            grdTemp.DataSource = fillTempBookData(txtBillNo.Text.Trim(), txtDcNo.Text.Trim());
            grdTemp.DataBind();
            clearStrip();
            // }
            //}
        }

        txtDcNo.Focus();

    }
    #endregion

    public void filltempData(DataTable dt)
    {
        Session["getSpeciman_Details"] = dt;
        grdTemp.DataSource = dt;
        grdTemp.DataBind();

    }

    public void CallButonVisible(string mode)
    {
        if (mode == "edit")
        {
            btnDelete.Visible = true;
            btnClear.Visible = true;
            btn_Save.Visible = true;
            btn_PrintSave.Visible = true;
            lblEditMode.Text = "edit";
        }
        else if (mode == "new")
        {
            btnDelete.Visible = false;
            btnClear.Visible = true;
            btn_Save.Visible = true;
            btn_PrintSave.Visible = true;
            btn_Edit.Visible = true;
            txtSpecDate.Focus();
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
        txtDcNo.Focus();
    }

    #endregion

    #region Row Edit Event
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
    #endregion

    #region TEMP DATA

    public DataTable fillTempBookData(string BillNo, string DcNo)
    {
        DataTable dt = new DataTable();
        if (Session["getSpeciman_Details"] == null)
        {
            //CREATE NEW DATATABLE
            dt.Columns.Add("SpecAutoId");
            dt.Columns.Add("SpecNo");
            dt.Columns.Add("SpeciId");
            dt.Columns.Add("CustId");
            dt.Columns.Add("CustNam");
            dt.Columns.Add("BillNo");
            dt.Columns.Add("Area");
            dt.Columns.Add("Delviery");
            dt.Columns.Add("NoOfBundel");


        }
        else
        {
            //setHistoryView();
            dt = (DataTable)Session["getSpeciman_Details"];
        }


        DataView dv = new DataView(dt);
        dv.RowFilter = "SpeciId = '" + DcNo + "' and BillNo = '" + BillNo + "'";


        //if (lblEditMode.Text == "edit")
        //{
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SpecAutoId"] = lblSubDocId.Text;
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["SpecNo"] = txtDcNo.Text.Trim();
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["BillNo"] = txtBillNo.Text.Trim();
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["CustNam"] = lblCustomer.Text.Trim();
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["Area"] = txtArea.Text.Trim();
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["NoOfbundel"] = txtNoOfBundles.Text.Trim();
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["Delviery"] = chkDelivery.Checked;
        //    dt.Rows[Convert.ToInt32(RowID.Text.Trim())]["CustId"] = lblCustID.Text.Trim();
        //    clearStrip();
        //}
        //else
        //{


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



            dt.Rows.Add(lblSubDocId.Text, txtDcNo.Text.Trim(), 0, lblCustID.Text.Trim(), lblCustomer.Text.Trim(),
                txtBillNo.Text.Trim() == "" ? "0" : txtBillNo.Text.Trim(), txtArea.Text.Trim(), chkDelivery.Checked, txtNoOfBundles.Text.Trim());
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


            //}
        }
        Session["getSpeciman_Details"] = dt;

        return dt;

    }

    #endregion

    protected void txtBranch_TextChanged(object sender, EventArgs e)
    {
        txttransporter.Focus();
    }

    protected void txttransporter_TextChange(object sender, EventArgs e)
    {
        txtNoOfParcels.Focus();
    }
}
