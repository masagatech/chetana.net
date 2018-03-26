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
using Other_Z;
using Idv.Chetana.BAL;


public partial class KYCForm : System.Web.UI.Page
{
    #region Variables
    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;
    int KycId, KycMax;


    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                if (!Page.IsPostBack)
                {
                    strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                    strFY = Session["FY"].ToString();
                    UserName = Session["UserName"].ToString();
                    Cust_AutoCompleteExtender.ContextKey = "custz" + "!" + Session["UserName"].ToString();
                    //txtOrderRecdDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    //txtOrderRecdDate.Focus();
                    txtCustCode.Focus();


                    string grp = "Transport";
                    txtTransport.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
                    txtTransport.DataBind();
                    txtTransport.Items.Insert(0, new ListItem("-Select Transporter-", "0"));
                }
            }
            else
            {
                Session.Clear();
            }
        }
    }
    #endregion

    #region Message Method
    private void Message(string Msg)
    {
        string Javascrip = "alert('" + Msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", Javascrip, true);
    }
    #endregion

    #region Kyc Form Save Method
    private void KycFormSave()
    {
        OtherBAL.KycForm_Property ObjProperty = new OtherBAL.KycForm_Property();
        OtherBAL ObjBal = new OtherBAL();
        #region Checkbox Values Get
        string rbtnval = "";
        if (rbtnChr.Checked == true)
        {
            rbtnval = "CH RECD";
        }
        else if (rbtnSch.Checked == true)
        {
            rbtnval = "SCH";
        }
        else if (rbtnWcp.Checked == true)
        {
            rbtnval = "WCP";
        }
        else if (rbtnCod.Checked == true)
        {
            rbtnval = "COD";
        }
        else
        {
            rbtnval = "";
        }
        if (txtDisYear.Text == "")
        {
            txtDisYear.Text = "0";
        }
        if (txtTitlesYear.Text == "")
        {
            txtTitlesYear.Text = "0";
        }
        #endregion
        //string OrderDate = txtOrderRecdDate.Text.Split('/')[1] + "/" + txtOrderRecdDate.Text.Split('/')[0] + "/" + txtOrderRecdDate.Text.Split('/')[2];
        ObjProperty.KycNo = Convert.ToInt32(lblKycId.Text);
        ObjProperty.CustCode = txtCustCode.Text.Split(':')[0].ToString();
        ObjProperty.CustName = txtCustName.Text;
        ObjProperty.CustAdd = txtCustAdd.Text;
        ObjProperty.Area = txtArea.Text;
        ObjProperty.City = txtCity.Text;
        ObjProperty.ZipCode = txtZipCode.Text;
        ObjProperty.ZoneCode = txtZoneCode.Text;
        ObjProperty.Telepone = txtTelephone.Text;
        ObjProperty.MobileNo = txtMobile.Text;
        ObjProperty.IfBookseller = rbtnval;
        ObjProperty.DelAdd = txtDelAdd.Text;
        ObjProperty.Transport = txtTransport.SelectedValue;
        ObjProperty.DisCurrentYear = float.Parse(txtDisYear.Text);
        ObjProperty.TitleCurrentYear = Convert.ToInt32(txtTitlesYear.Text);

        ObjProperty.PrevDic = float.Parse(lblprvyeardisc.Text);
        ObjProperty.PrevTitle = Convert.ToInt32(lblpreyeartitles.Text == "" ? "0" : lblpreyeartitles.Text);

        ObjProperty.ChkSchemeLetter = Convert.ToInt32(ChkScheme.Checked);
        ObjProperty.ChkAddCommFrm = Convert.ToInt32(ChkAddComminsion.Checked);
        ObjProperty.ChkDisForm = Convert.ToInt32(ChkDisForm.Checked);
        ObjProperty.Remark = txtRemrk.Text;
        ObjProperty.FY = Convert.ToInt32(Session["FY"]);
        ObjProperty.CreatedBy = Session["UserName"].ToString();
        ObjProperty.OS = Convert.ToSingle(lblOS.Text);
        ObjProperty.R1 = lblAvg.Text;
        ObjProperty.R2 = "";
        ObjProperty.R3 = "";
        ObjProperty.R4 = "";
        ObjBal.Idv_Chetana_Save_KycForm(ObjProperty, out KycId, out KycMax);
        if (lblEdit.Text == "Edit")
        {
            Message("Record save successfully Kyc Form No is " + KycId.ToString());
            lblKycId.Text = "0";
            lblEdit.Text = "";
            btnDelete.Visible = false;
            Clear();
        }
        else
        {
            Message("Record save successfully Kyc Form No is " + KycMax.ToString());
            lblKycId.Text = "0";
            lblEdit.Text = "";
            btnDelete.Visible = false;
            Clear();
        }

    }
    #endregion


    #region Kyc Form Save
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        lblSaveFlag.Text = "Save";
        if (lblEdit.Text == "Edit")
        {
            KycFormSave();
            lblAutoExtend.Text = "";
            return;
        }
        else
        {
            OtherBAL ObjBal = new OtherBAL();
            DataSet ds = ObjBal.Idv_Chetana_Get_KycForm_GetMasterCust(txtCustCode.Text, Convert.ToInt32(Session["FY"]), "ChkCode");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ModalPopupExtenderNew.Show();
                return;
            }
            else
            {
                KycFormSave();
                lblAutoExtend.Text = "";
            }
        }
    }
    #endregion

    #region Print Button Click Event
    protected void btn_Print_Click(object sender, EventArgs e)
    {
        if (lblAutoExtend.Text != "")
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('KycFormReport.aspx?KycNo=" + Convert.ToInt32(lblAutoExtend.Text) + "');", true);
            lblAutoExtend.Text = "";
        }
        else
        {
            Message("First save before printing");
            return;
        }

    }
    #endregion

    protected void btnbtnExsist_Click(object sender, EventArgs e)
    {
        if (lblSaveFlag.Text == "Save")
        {
            KycFormSave();
            lblAutoExtend.Text = "";
            ModalPopupExtenderNew.Hide();
        }
        else
        {
            KycFormSave();
            ModalPopupExtenderNew.Hide();
            // Response.Redirect("KycFormReport.aspx?KycNo=" + Convert.ToInt32(KycId));
            Page.ClientScript.RegisterStartupScript(
       this.GetType(), "OpenWindow", "window.open('KycFormReport.aspx?KycNo=" + KycMax.ToString() + "');", true);
            lblAutoExtend.Text = "";

        }

    }

    protected void btnExCancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtenderNew.Hide();
        txtCustCode.Focus();
    }

    #region Get Dateils Button Click
    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        OtherBAL ObjBal = new OtherBAL();
        string RadioVal = "";
        DataSet ds = ObjBal.Idv_Chetana_Get_KycForm(Convert.ToInt32(txtDocIdEdit.Text), Convert.ToInt32(Session["FY"]), Convert.ToInt32("0"), Convert.ToInt32("0"), "", "", "", "");
        DataTable dt = ds.Tables[1];
        if (dt.Rows.Count > 0)
        {
            #region Radio Button Checked

            RadioVal = dt.Rows[0]["IfBkseller"].ToString();
            if (RadioVal == "CH RECD")
            {
                rbtnChr.Checked = true;
            }
            else if (RadioVal == "SCH")
            {
                rbtnSch.Checked = true;
            }
            else if (RadioVal == "WCP")
            {
                rbtnWcp.Checked = true;
            }
            else if (RadioVal == "COD")
            {
                rbtnCod.Checked = true;
            }
            else
            {
                RadioVal = "";
            }

            #endregion

            lblKycId.Text = dt.Rows[0]["KycNo"].ToString();
            txtCustCode.Text = dt.Rows[0]["CustCode"].ToString();
            txtCustName.Text = dt.Rows[0]["CustName"].ToString();
            txtCustAdd.Text = dt.Rows[0]["CustAddress"].ToString();
            txtArea.Text = dt.Rows[0]["Area"].ToString();

            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtZipCode.Text = dt.Rows[0]["ZipCode"].ToString();
            txtZoneCode.Text = dt.Rows[0]["ZoneCode"].ToString();
            txtTelephone.Text = dt.Rows[0]["TelNo"].ToString();
            txtMobile.Text = dt.Rows[0]["MobileNo"].ToString();
            txtDelAdd.Text = dt.Rows[0]["DelAddr"].ToString();
            txtTitlesYear.Text = dt.Rows[0]["Titles"].ToString();
            txtDisYear.Text = dt.Rows[0]["Dis"].ToString();

            //Prev Year Dicount And Title
            lblprvyeardisc.Text = dt.Rows[0]["PrevDis"].ToString();
            lblpreyeartitles.Text = dt.Rows[0]["PrevTitle"].ToString();

            ChkScheme.Checked = Convert.ToBoolean(dt.Rows[0]["SchLTR"].ToString());
            ChkAddComminsion.Checked = Convert.ToBoolean(dt.Rows[0]["AddCommFrm"].ToString());
            ChkDisForm.Checked = Convert.ToBoolean(dt.Rows[0]["DisForm"].ToString());
            lblOS.Text = Convert.ToSingle(dt.Rows[0]["OS"]).ToString();
            lblAvg.Text = dt.Rows[0]["TotalAvg"].ToString();
            txtRemrk.Text = dt.Rows[0]["Remark"].ToString();
            // txtPersonInchrg.Text = dt.Rows[0]["PersonInchrg"].ToString();
            txtTransport.SelectedValue = dt.Rows[0]["Transport"].ToString();
            lblAutoExtend.Text = lblKycId.Text;
            txtCustCode.Focus();
            lblEdit.Text = "Edit";
        }
        else
        {
            Message("Info! : \\r\\n Kyc No. " + txtDocIdEdit.Text.Trim() + " Not Found!!!");
            ModalPopUpDocNum.Show();
            txtDocIdEdit.Text = "";
            txtDocIdEdit.Focus();
        }
    }
    #endregion

    #region Edit Button Click

    protected void btn_Edit_Click(object sender, EventArgs e)
    {

    }

    #endregion

    #region Clear Button Method
    private void Clear()
    {
        //txtOrderRecdDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        //txtOrderNo.Text = "";
        txtCustCode.Text = "";
        txtCustName.Text = "";
        txtCustAdd.Text = "";
        txtArea.Text = "";
        txtCity.Text = "";
        txtZipCode.Text = "";
        txtZoneCode.Text = "";
        txtTelephone.Text = "";
        txtMobile.Text = "";
        rbtnChr.Checked = false;
        rbtnSch.Checked = false;
        rbtnWcp.Checked = false;
        rbtnCod.Checked = false;
        txtDelAdd.Text = "";
        txtTransport.SelectedIndex = 0;
        txtDisYear.Text = "";
        txtTitlesYear.Text = "";
        //txtPersonInchrg.Text = "";
        ChkScheme.Checked = false;
        ChkAddComminsion.Checked = false;
        ChkDisForm.Checked = false;
        txtCustCode.Text = "";
        txtRemrk.Text = "";
        lblZoneCode.Text = "";
        lblOS.Text = "0";
        lblAvg.Text = "0";
        lblpreyeartitles.Text = "0";
        lblKycId.Text = "0";

        txtCustCode.Focus();
    }
    #endregion

    #region Delete Button Click
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OtherBAL.KycForm_Property ObjProperty = new OtherBAL.KycForm_Property();
        OtherBAL ObjBal = new OtherBAL();
        int KycId, KycMax;
        ObjProperty.R1 = "Del";
        ObjProperty.KycNo = Convert.ToInt32(lblKycId.Text);
        ObjBal.Idv_Chetana_Save_KycForm(ObjProperty, out KycId, out KycMax);
        Message("Record Delete successfully Kyc Form No is " + KycId.ToString());
        lblAutoExtend.Text = "";
        btnDelete.Visible = false;
        Clear();
    }
    #endregion

    #region Save And Print Button Click Event
    protected void btn_PrintSave_Click(object sender, EventArgs e)
    {
        lblSaveFlag.Text = "SavePrint";
        if (lblEdit.Text == "Edit")
        {
            KycFormSave();
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('KycFormReport.aspx?KycNo=" + lblAutoExtend.Text + "');", true);
            lblAutoExtend.Text = "";
            return;
        }
        else
        {
            OtherBAL ObjBal = new OtherBAL();
            DataSet ds = ObjBal.Idv_Chetana_Get_KycForm_GetMasterCust(txtCustCode.Text, Convert.ToInt32(Session["FY"]), "ChkCode");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ModalPopupExtenderNew.Show();
                return;
            }
            else
            {
                KycFormSave();
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('KycFormReport.aspx?KycNo=" + KycMax.ToString() + "');", true);
                lblAutoExtend.Text = "";
            }
        }
    }
    #endregion

    #region Click Button Click Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
        lblAutoExtend.Text = "";
    }
    #endregion

    #region Customer Code On Change Event
    protected void txtCustCode_TextChanged(object sender, EventArgs e)
    {
        OtherBAL ObjBal = new OtherBAL();
        string CustCode = txtCustCode.Text.ToString().Split(':')[0].Trim() + "!" + Session["UserName"].ToString();

        DataSet ds = ObjBal.Idv_Chetana_Get_KycForm_CusCode(CustCode, Convert.ToInt32(Session["FY"]), "");
        DataTable dt = ds.Tables[1];
        if (dt.Rows.Count > 0)
        {
            Clear();
            if (ds.Tables[1].Columns.Contains("BlackList"))
            {
                Message("This customer is black list");
                txtCustCode.Text = CustCode.Split('!')[0].Trim();
                return;
            }
            else
            {
                txtCustCode.Text = CustCode.Split('!')[0].Trim();
                txtCustName.Text = dt.Rows[0]["CustName"].ToString();
                txtCustAdd.Text = dt.Rows[0]["Address"].ToString();
                txtArea.Text = dt.Rows[0]["AreaCode"].ToString();
                txtCity.Text = dt.Rows[0]["cityname"].ToString();
                txtZipCode.Text = dt.Rows[0]["Zip"].ToString();
                txtZoneCode.Text = dt.Rows[0]["ZoneCode"].ToString();
                lblZoneCode.Text = dt.Rows[0]["ZoneName"].ToString();
                txtTelephone.Text = dt.Rows[0]["telephone_exel"].ToString();
                txtMobile.Text = dt.Rows[0]["Phone1"].ToString();
                lblOS.Text = dt.Rows[0]["OutStanding"].ToString();
                lblAvg.Text = dt.Rows[0]["TotalAvg"].ToString();
                txtDelAdd.Text = dt.Rows[0]["Address"].ToString();
                lblprvyeardisc.Text = dt.Rows[0]["prevdiscount"].ToString();
                lblpreyeartitles.Text = dt.Rows[0]["Titles"].ToString();
                txtCustName.Focus();
            }
        }
        else
        {
            Clear();
        }
    }
    #endregion
}
