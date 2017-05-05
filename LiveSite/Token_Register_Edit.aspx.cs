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
using Other_Z;



public partial class Token_Register_Edit : System.Web.UI.Page
{
    #region ALl Veriable Declaretion
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    DataTable dt = new DataTable();
    DataTable newdt = new DataTable();
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
                if (!IsPostBack)
                {
                    rbtnToken.Checked = true;
                    Session["TokenRegsterDataTable"] = null;
                    txtCustomerName.Focus();
                }
            }
        }
        else
        {
            Session.Clear();
        }

    }
    #endregion

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Clear All Textbox
    private void Clear()
    {
        txtKycNo.Text = "";
        txtOrderDate.Text = "";
        txtCustomerName.Text = "";
        txtDeliveryDate.Text = "";
        ddlReceived.Text = "";
        txtHandedOverTo.Text = "";
        txtRemark.Text = "";
        ddlReceived.Text = "-1";
        lblTokenNo.Text = "0";
        txtCustomerName.Focus();
    }
    #endregion

    #region Edit Mode Fill Textbox Image Edit Button Click Event
    protected void btnEdits_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn = ((ImageButton)sender);
        lblTokenNo.Text = Convert.ToInt32(((Label)btn.Parent.FindControl("lblTokenNo")).Text).ToString();
        txtKycNo.Text = Convert.ToInt32(((Label)btn.Parent.FindControl("lblKycNo")).Text == "" ? "0" : ((Label)btn.Parent.FindControl("lblKycNo")).Text).ToString();
        txtOrderDate.Text = ((Label)btn.Parent.FindControl("lblOrderRecDate")).Text.ToString();
        txtCustomerName.Text = Convert.ToString(((Label)btn.Parent.FindControl("lblCustomer")).Text).ToString();
        txtDeliveryDate.Text = ((Label)btn.Parent.FindControl("lblDeliveryDate")).Text.ToString();
        ddlReceived.Text = Convert.ToString(((Label)btn.Parent.FindControl("lblReceived")).Text).ToString();
        txtHandedOverTo.Text = Convert.ToString(((Label)btn.Parent.FindControl("lblHanded")).Text).ToString();
        txtRemark.Text = Convert.ToString(((Label)btn.Parent.FindControl("lblRemarks")).Text).ToString();

        string OrderDate = txtOrderDate.Text.Split('/')[0] + "/" + txtOrderDate.Text.Split('/')[1] + "/" + txtOrderDate.Text.Split('/')[2];
        string DeliveryDate = txtDeliveryDate.Text.Split('/')[0] + "/" + txtDeliveryDate.Text.Split('/')[1] + "/" + txtDeliveryDate.Text.Split('/')[2];
        txtOrderDate.Text = OrderDate;
        txtDeliveryDate.Text = DeliveryDate;

    }
    #endregion

    #region Get Method Data With FY
    private DataTable updateGrid(string R3)
    {
        string Id = "";
        string R1 = txtCustomerName.Text;
        string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
        string ToDate = DateTime.Now.ToString("MM/dd/yyyy");
        string R2 = "";
        string PrintId = "";
        string strTemp="";
        int TokenKyc=0;
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dtgrid = new DataTable();
        if (rbtnToken.Checked)
        {
            TokenKyc = Convert.ToInt32(txtTokenFind.Text.Trim());
            strTemp = "TokenNo";
        }
        else if (rbtnKyc.Checked)
        {
            TokenKyc = Convert.ToInt32(txtKycFind.Text.Trim());
            strTemp = "KycNo";
        }
        else if (rbtDatewise.Checked)
        {
            FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
            ToDate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];

        }
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, TokenKyc,PrintId,
            rbtDatewise.Checked == true ? Convert.ToDateTime(FromDate):Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")),
            rbtDatewise.Checked == true ? Convert.ToDateTime(ToDate): Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"))) ;
        dtgrid = ds.Tables[0];
        if (dtgrid.Rows.Count == 0)
        {
            MessageBox("Record Not Found ");
            txtKycFind.Focus();
        }
        return dtgrid;
    }
    #endregion

    #region Grid Vew Bind
    private void BindGridWithSession(DataTable dt)
    {
        grdTokenRegister.DataSource = dt;
        grdTokenRegister.DataBind();
    }
    #endregion

    #region Get Button Click Event
    protected void Get_Click(object sender, EventArgs e)
    {
        Button rbtn = sender as Button;
        DataTable dt = new DataTable();
        if (rbtn.ID == "kycbtnGet")
        {
            dt = updateGrid("KycNo");
            BindGridWithSession(dt);
        }
        else if (rbtn.ID == "btnToken")
        {
            dt = updateGrid("TokenNo");
            BindGridWithSession(dt);
        }
        else
        {
            txtKycFind.Text = "0";
            dt = updateGrid("");
            BindGridWithSession(dt);
        }
        Session["TokenRegsterDataTable"] = dt as DataTable;

    }
    #endregion

    #region Redio Button On Change Event
    protected void rbtnKyc_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rbtn = sender as RadioButton;
        if (rbtn.ID == "rbtnToken")
        {
            txtTokenFind.Text = "";
            KycNoWise.Visible = false;
            DateWise.Visible = false;
            TokenWise.Visible = true;
            txtTokenFind.Focus();
        }
        else if (rbtn.ID == "rbtnKyc")
        {
            txtTokenFind.Text = "";
            txtKycFind.Text = "";
            KycNoWise.Visible = true;
            TokenWise.Visible = false;
            DateWise.Visible = false;
            txtKycFind.Focus();
        }
        else
        {
            txtTokenFind.Text = "";
            txtKycFind.Text = "";
            txtFromDate.Text = "01/04/201" + Convert.ToInt32(strFY);
            txtToDate.Text = "31/03/201"+Convert.ToInt32(Convert.ToInt32(strFY)+1);
            DateWise.Visible = true;
            KycNoWise.Visible = false;
            TokenWise.Visible = false;
            txtFromDate.Focus();
        }
    }
    #endregion

    #region CustName With Customer Master Get And Insert
    private DataTable updateGridWithCustName(string R3)
    {
        string Id = "";
        string R1 = txtCustomerName.Text;
        string R2 = "";
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dtgrid = new DataTable();
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, 0, "", DateTime.Now, DateTime.Now);
        dtgrid = ds.Tables[0];
        return dtgrid;
    }
    #endregion

    #region Data Save Add Button Click Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //bool flage1 = true;
        //flage1 = DateValidation();
        //if (flage1 == false)
        //{
        //    return;
        //}

        bool flage = true;
        flage = CheckedCustomerExists();
        if (flage == false)
        {
            return;
        }

        if (Session["UserName"] != null)
        {
            string OrderDate = DateTime.Now.ToString("MM/dd/yyyy");
            string DeliveryDate = DateTime.Now.ToString("MM/dd/yyyy");

            OrderDate = txtOrderDate.Text.Split('/')[1] + "/" + txtOrderDate.Text.Split('/')[0] + "/" + txtOrderDate.Text.Split('/')[2];
            DeliveryDate = txtDeliveryDate.Text.Split('/')[1] + "/" + txtDeliveryDate.Text.Split('/')[0] + "/" + txtDeliveryDate.Text.Split('/')[2];

            if (lblTokenNo.Text != "0")
            {
                Session["TokenRegsterDataTable"] = null;
                Other_Z.OtherBAL ObjBAL = new OtherBAL();
                OtherBAL.Token_Register_Property ObjProperty = new OtherBAL.Token_Register_Property();
                ObjProperty.TokenNo = Convert.ToInt32(lblTokenNo.Text.Trim());
                ObjProperty.KYC_No = txtKycNo.Text.Trim() == "" ? "0" : txtKycNo.Text.Trim();
                ObjProperty.CustCode = txtCustomerName.Text.Trim();
                ObjProperty.DeliveryDate = Convert.ToDateTime(DeliveryDate);
                ObjProperty.ReceivedVia = ddlReceived.Text.Trim();
                ObjProperty.HandOver = txtHandedOverTo.Text.Trim();
                ObjProperty.Ord_Rec_Date = Convert.ToDateTime(OrderDate);
                ObjProperty.Remark = txtRemark.Text.Trim();
                ObjProperty.createdBy = Session["UserName"].ToString();
                ObjProperty.FY = Convert.ToInt32(Session["FY"]);
                ObjProperty.R1 = "";
                ObjProperty.R2 = "";
                ObjProperty.R3 = "";
                int tokenid;
                ObjBAL.Idv_Chetana_Save_Token_Register(ObjProperty, out tokenid);
                MessageBox("Record save successfully Token No is " + tokenid.ToString());

                DataTable CustNamedt = updateGridWithCustName("CustName");

                DataTable dt = GetSessionDataTable();
                if (dt != null)
                {
                    bool isedit = false;
                    DataRow[] rows = dt.Select("TokenNo=" + tokenid);

                    DataRow dr = null;
                    if (rows.Length > 0)
                    {
                        dr = rows[0];
                        isedit = true;
                    }
                    else
                    {
                        dr = dt.NewRow();
                    }
                    dr["TokenNo"] = tokenid;
                    dr["KYC_No"] = ObjProperty.KYC_No == "0" ? "" : ObjProperty.KYC_No;
                    dr["Ord_Rec_Date"] = ObjProperty.Ord_Rec_Date.ToString("dd/MM/yyyy");
                    dr["CustCode"] = ObjProperty.CustCode;
                    dr["CustName"] = CustNamedt.Rows[0][0].ToString();
                    dr["DeliveryDate"] = ObjProperty.DeliveryDate.ToString("dd/MM/yyyy");
                    dr["ReceivedVia"] = ObjProperty.ReceivedVia;
                    dr["HandOver"] = ObjProperty.HandOver;
                    dr["Remark"] = ObjProperty.Remark;

                    if (!isedit)
                    {
                        addRow(dr);
                    }
                    else
                    {

                    }

                }
                BindGridWithSession();
                Clear();
                
            }
            else
            {
                MessageBox("Not permission Add New Record");
                txtCustomerName.Focus();
                Clear();
                return;
            }

        }

    }
    #endregion

    #region Add New Row As DataTable
    private void addRow(DataRow dr)
    {
        createTempTable();
        if (Session["TokenRegsterDataTable"] != null)
        {
            DataTable dt = (DataTable)Session["TokenRegsterDataTable"];
            dt.Rows.Add(dr);
            Session["TokenRegsterDataTable"] = dt;

        }
    }
    #endregion

    #region Grid Bind With Session
    private void BindGridWithSession()
    {
        if (Session["TokenRegsterDataTable"] != null)
        {
            newdt = Session["TokenRegsterDataTable"] as DataTable;
            grdTokenRegister.DataSource = newdt;
            grdTokenRegister.DataBind();
        }
    }
    #endregion

    #region Create Temp Table As DataTable
    private void createTempTable()
    {
        if (Session["TokenRegsterDataTable"] == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TokenNo", typeof(Int32));
            dt.Columns.Add("KYC_No", typeof(string));
            dt.Columns.Add("Ord_Rec_Date", typeof(string));
            dt.Columns.Add("CustCode", typeof(string));
            dt.Columns.Add("CustName", typeof(string));
            dt.Columns.Add("DeliveryDate", typeof(string));
            dt.Columns.Add("ReceivedVia", typeof(string));
            dt.Columns.Add("HandOver", typeof(string));
            dt.Columns.Add("Remark", typeof(string));

            Session["TokenRegsterDataTable"] = dt;

        }

    }
    #endregion

    #region Get Seeeion Set Value As DataTable
    private DataTable GetSessionDataTable()
    {
        createTempTable();
        return (DataTable)Session["TokenRegsterDataTable"];
    }
    #endregion

    #region Customer Code Validation If Exists
    private bool CheckedCustomerExists()
    {
        bool flage = false;
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        string CustCode = txtCustomerName.Text.Split(':')[0].ToString().Trim();
        if (CustCode != "")
        {
            DataSet ds = ObjBAL.Token_Register_Validation(CustCode, Convert.ToInt32(txtKycNo.Text == "" ? 0 : Convert.ToInt32(txtKycNo.Text)), Convert.ToInt32(strFY), "", "");
            if (ds.Tables[0].Rows[0][0].ToString() == "BlackList")
            {
                MessageBox("This customer is black list");
                txtCustomerName.Focus();
                flage = false;
                return flage;
            }
            if (ds.Tables[0].Rows[0][0].ToString() == "Kyc no not match this Customer")
            {
                MessageBox("Kyc no not match this Customer");
                txtCustomerName.Focus();
                flage = false;
                return flage;
            }
            if (ds.Tables[0].Rows[0][0].ToString() == "Kyc No is mandatory")
            {
                MessageBox("Kyc No is mandatory");
                txtKycNo.Focus();

                flage = false;
                return flage;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "Invalid Kyc no")
            {
                MessageBox("Invalid Kyc no");
                txtKycNo.Focus();
                txtKycNo.Text = "";
                flage = false;
                return flage;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "Invalid Customer")
            {
                MessageBox("Invalid Customer");
                txtCustomerName.Focus();
                txtCustomerName.Text = "";
                flage = false;
                return flage;
            }
            else
            {
                flage = true;
            }

        }
        return flage;
    }
    #endregion

    //#region Date Validation
    //private bool DateValidation()
    //{
    //    string OrderDate = DateTime.Now.ToString("MM/dd/yyyy");
    //    string DeliveryDate = DateTime.Now.ToString("MM/dd/yyyy");

    //    OrderDate = txtOrderDate.Text.Split('/')[1] + "/" + txtOrderDate.Text.Split('/')[0] + "/" + txtOrderDate.Text.Split('/')[2];
    //    DeliveryDate = txtDeliveryDate.Text.Split('/')[1] + "/" + txtDeliveryDate.Text.Split('/')[0] + "/" + txtDeliveryDate.Text.Split('/')[2];

    //    bool chkDate = true;
    //    if (Convert.ToDateTime(OrderDate) > Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
    //    {
    //        MessageBox("Invalid Order Date");
    //        chkDate = false;
    //        txtOrderDate.Focus();
    //        return chkDate;
    //    }
    //    else if (Convert.ToDateTime(DeliveryDate) < Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
    //    {
    //        MessageBox("Invalid Delivery Date");
    //        chkDate = false;
    //        txtDeliveryDate.Focus();
    //        return chkDate;
    //    }
    //    return chkDate;
    //}

    //#endregion

    protected void grdTokenRegister_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void grdTokenRegister_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnRemove_Click(object sender, ImageClickEventArgs e)
    {
        #region Delete Data 
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        int TokenId = 0;
        OtherBAL.Token_Register_Property ObjProperty = new OtherBAL.Token_Register_Property();
        ImageButton btn = ((ImageButton)sender);
        ObjProperty.TokenNo = Convert.ToInt32(((Label)btn.Parent.FindControl("lblTokenId")).Text);
        ObjProperty.FY = Convert.ToInt32(Session["FY"]);
        ObjProperty.createdBy = Session["UserName"].ToString();
        ObjProperty.R1 = "del";
        ObjBAL.Idv_Chetana_Save_Token_Register(ObjProperty, out TokenId);
        if(TokenId == Convert.ToInt32("-1"))
        {
            MessageBox("Transaction exists in dc master");
            txtCustomerName.Focus();
            return;
        }
        else
        {
            DataTable dt = GetSessionDataTable();
            if (dt != null)
            {
                bool isedit = false;
                DataRow[] rows = dt.Select("TokenNo=" + TokenId);

                DataRow dr = null;
                if (rows.Length > 0)
                {
                    dr = rows[0];
                    dr.Delete();
                    BindGridWithSession();
                    Clear();
                }

            }
        }
        
        #endregion

    }
}
