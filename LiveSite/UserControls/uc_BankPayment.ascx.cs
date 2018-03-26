#region NameSpace
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
using Idv.Chetana.Common;
#endregion

public partial class UserControls_uc_BankPayment : System.Web.UI.UserControl
{
    #region Variables
    string docdate;
    string frdate;
    string todate;
    DateTime ddt;
    DateTime tdt;
    DateTime fdt;
    int DocNo;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string url;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                HidFY.Value = Session["FY"].ToString();
                if (Session["PayMode"] != null)
                {
                    string PayMode = Session["PayMode"].ToString();
                    txtAccode.Text = PayMode.Split('+')[0].ToString();
                    lblaccname.Text = PayMode.Split('+')[1].ToString();
                    txtAmt.Text = PayMode.Split('+')[2].ToString();
                    Session["PayMode"] = null;
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
            SetView();
            //BindBankPDetails();
            DDLCCDD.Items.Insert(0, new ListItem("-Select-", "0"));
            // txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
        }
        Page previousPage = Page.PreviousPage;
        if (previousPage != null && previousPage.IsPostBack)
        {
            Session["url"] = Request.QueryString["a"];
            SetView();
        }
    }

    #endregion

    #region Events

    //delete 
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            //write 
            if (LblBankPID.Text != "" || LblBankPID.Text != "0")
            {
               
                //AuditCutOffDate check
                    int i;
                    i = Global.Check_IsEditable("Bank_Payment", Convert.ToInt32(LblBankPID.Text),Convert.ToInt32(strFY));
                    if (i == 1)
                    {
                        try
                        {
                            DeleteModule objDelete = new DeleteModule();
                            objDelete.ID = LblBankPID.Text.Trim();
                            objDelete.FY = Convert.ToInt32(HidFY.Value);
                            objDelete.Is_Restore = false;
                            objDelete.Created_BY = Session["UserName"].ToString();
                            objDelete.Module = "BankPayment";
                            objDelete.Save();
                            MessageBox("Record successfully deleted");

                            //Reset Form
                            pageName.InnerHtml = "View / Edit Bank Payment";
                            PnlAddBankP.Visible = false;
                            Pnldate.Visible = true;
                            PnlBankPDetails.Visible = false;

                            btn_Save.Visible = false;
                            btnDelete.Visible = false;
                            filter.Visible = true;

                        }

                        catch (Exception ex)
                        {
                            MessageBox("Record not deleted due to : " + ex.Message.ToString());

                        }
                    }
                    else
                    {
                        MessageBox("You cannot delete Bank Payment Entry of Date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString());


                    }

            }
        }
    }

    #region Save
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        docdate = txtdocDate.Text.Split('/')[2] + "/" + txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0];
        ddt = Convert.ToDateTime(docdate);
        string BankCode = txtbankcode.Text.Trim();

        BankPayment obBnkpay = new BankPayment();
        // txtdocno.Text = BankPayment.Get_BankPaymentDocNo(BankCode);

        // txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        if (Session["UserName"] != null)
        {
            try
            {
                obBnkpay.BankPaymentID = Convert.ToInt32(LblBankPID.Text);
                obBnkpay.BankCode = txtbankcode.Text.Trim();
                // obBnkpay.DocumentNo = 0;
                obBnkpay.SerialNo = 1;
                obBnkpay.DocumentDate = ddt;
                obBnkpay.AccountCode = txtAccode.Text.Trim(); ;
                obBnkpay.PersonInCharge = txtperson.Text.Trim();
                obBnkpay.ReportCode = txtreportcode.Text.Trim();
                obBnkpay.Cash_Cheque_DD = DDLCCDD.SelectedItem.Text;
                // obBnkpay.Type = txtType.Text.Trim();
                obBnkpay.Cheque_DD_NO = txtCCDDNo.Text.Trim();
                obBnkpay.Amount = Convert.ToDecimal(txtAmt.Text.Trim());
                obBnkpay.DrawnOn = txtDrawnon.Text.Trim();
                obBnkpay.Remarks = txtRemark.Text.Trim();
                obBnkpay.Isactive = true;
                obBnkpay.IsChequeBounce = CheckActive.Checked;
               
                obBnkpay.CreatedBy = Session["UserName"].ToString();
                obBnkpay.strFY = Convert.ToInt32(strFY);
                if (Session["url"] != null)
                {
                  //obBnkpay.Paymode = "Addcomision";
                }
                else
                {
               // obBnkpay.Paymode = "";
                }

               //Chech Document date against Audit CutOffDate 

                int flag = 1;
                string strMsg = null;
                if (btn_Save.Text == "Save")
                {
                    bool i = Global.ValidateDate(txtdocDate.Text.ToString());
                    if (i == true)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        strMsg = "You cannot Create Bank Payment Entry of Date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString();

                    }
                }
                if (btn_Save.Text == "Update")
                {
                    int i;
                    i = Global.Check_IsEditable("Bank_Payment", Convert.ToInt32(LblBankPID.Text),Convert.ToInt32(strFY));
                    if (i == 1)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        strMsg = "You cannot Edit Bank Payment Entry of Date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString();

                    }
                }

                
                if (flag  == 1)
                {
                    obBnkpay.Save(out DocNo);
                    txtdocno.Text = Convert.ToString(DocNo);
                    // MessageBox("Record saved successfully");
                    MessageBox(Constants.save + "\\r\\n Document No: " + (txtdocno.Text));
                    loder("Last saved Document no. : " + txtdocno.Text);
                    GrdBankPDetails.DataBind();

                    txtbankcode.Text = "";
                    lblbankname.Text = "";
                    txtdocno.Text = "";
                    txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    // txtsrno.Text = "";
                    txtAccode.Text = "";
                    lblaccname.Text = "";
                    txtperson.Text = "";
                    txtreportcode.Text = "";
                    lblacname.Text = "";
                    DDLCCDD.SelectedIndex = 0;
                    //txtType.Text = "";
                    txtCCDDNo.Text = "";
                    txtAmt.Text = "";
                    txtDrawnon.Text = "";
                    lblDrawnonname.Text = "";
                    txtRemark.Text = "";
                    Session["url"] = null;
                    CheckActive.Checked = false;
                    lblCustOS.Text = "";
                    btn_Save.Text = "Save";
                    PnlAddBankP.Visible = true;
                    Pnldate.Visible = false;
                    PnlBankPDetails.Visible = false;
                }
                else
                {
                    MessageBox("You cannot Create/Edit/Delete Bank Payment Entry of Date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString());
                }
            }
            catch
            {
            }
        }
    }
    #endregion

    #region Button Click
    protected void btnget_Click(object sender, EventArgs e)
    {
        string BnkCode = txtbankcodep.Text.Trim();

        frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        tdt = Convert.ToDateTime(todate);
        fdt = Convert.ToDateTime(frdate);

        if (tdt >= fdt)
        {
            DataSet ds = new DataSet();
            ds = BankPayment.GetBankPayment(BnkCode, fdt, tdt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdBankPDetails.DataSource = BankPayment.GetBankPayment(BnkCode, fdt, tdt);
                string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
                if (page != "bankpayment.aspx")
                {
                    GrdBankPDetails.Columns[7].Visible = false;
                }
                GrdBankPDetails.DataBind();


                PnlBankPDetails.Visible = true;
            }
            else
            {
                PnlBankPDetails.Visible = false;
                MessageBox("Records Not Available ");
            }
        }
        else
        {
            PnlBankPDetails.Visible = false;
            MessageBox("From Date is greater than To Date");
        }
    }
    #endregion

    #region TextChanged
    protected void txtbankcode_TextChanged(object sender, EventArgs e)
    {
        string BankCode = txtbankcode.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtbankcode.Text = BankCode;
            lblbankname.Text = Convert.ToString(dt.Rows[0]["BankName"]);
            txtFromDate.Focus();
            //UpPnldate1.Update();

            // txtdocno.Text = BankPayment.Get_BankPaymentDocNo(BankCode);
        }
        else
        {
            lblbankname.Text = "No such Bank code";
            txtbankcode.Focus();
            txtbankcode.Text = "";

            // txtdocno.Text = "";
        }
    }

    protected void txtAccode_TextChanged(object sender, EventArgs e)
    {
        try
        {

        
        string Accode = txtAccode.Text.ToString().Split(':')[0].Trim();
        string flag = txtAccode.Text.ToString().Split(':', '[', ']')[3].Trim();

        DataTable dt1 = new DataTable();
        dt1 = DCMaster.Get_Name(Accode, flag).Tables[0];

        if (dt1.Rows.Count > 0)
        {
            if (flag == "AC")
            {
                txtAccode.Text = Accode;
                lblaccname.Text = Convert.ToString(dt1.Rows[0]["AC_NAME"]);
                lblCustOS.Visible = true;
               lblCustOS.Text = Convert.ToString(DCMaster.Get_Name(Accode, flag).Tables[1].Rows[0]["Closin_Bal"]);
                   
                txtperson.Focus();

            }
            else
                if (flag == "Cust")
                {
                    txtAccode.Text = Accode;
                    lblaccname.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
                   
                        lblCustOS.Visible = true;
                        lblCustOS.Text = Convert.ToString(DCMaster.Get_Name(Accode, flag).Tables[1].Rows[0]["Closin_Bal"]);
                    
                    txtperson.Focus();
                }
        }
        else
        {
            lblaccname.Text = "No such Account code";
            txtAccode.Focus();
            txtAccode.Text = "";
            lblaccname.Text = "";
            lblCustOS.Text = "";
        }
        }
        catch (Exception)
        {
            lblaccname.Text = "Error";
            txtAccode.Focus();
            txtAccode.Text = "";
            //lblaccname.Text = "";
            lblCustOS.Text = "";
   
            
        }
        }

    protected void txtreportcode_TextChanged(object sender, EventArgs e)
    {
        string Reportcode = txtreportcode.Text.ToString().Split(':')[0].Trim();
        string flag = txtreportcode.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt2 = new DataTable();
        dt2 = DCMaster.Get_Name(Reportcode, flag).Tables[0];
        if (dt2.Rows.Count != 0)
        {
            if (flag == "AC")
            {
                txtreportcode.Text = Reportcode;
                lblacname.Text = Convert.ToString(dt2.Rows[0]["AC_NAME"]);
                DDLCCDD.Focus();
            }
            else
                if (flag == "Cust")
                {
                    txtreportcode.Text = Reportcode;
                    lblacname.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
                    DDLCCDD.Focus();
                }
        }
        else
        {
            lblacname.Text = "No such Report code";
            txtreportcode.Focus();
            txtreportcode.Text = "";
        }
    }

    protected void txttoDate_TextChanged(object sender, EventArgs e)
    {
        PnlBankPDetails.Visible = false;
        //btnget.Focus();
    }

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        PnlBankPDetails.Visible = false;
        //txttoDate.Focus();
        //UpPnldate2.Update();
    }

    protected void txtbankcodep_TextChanged(object sender, EventArgs e)
    {
        string BankCode1 = txtbankcodep.Text.ToString().Split(':')[0].Trim();

        DataTable dt3 = new DataTable();
        dt3 = DCMaster.Get_Name(BankCode1, "Bank").Tables[0];

        if (dt3.Rows.Count != 0)
        {
            txtbankcodep.Text = BankCode1;
            lblbanknamep.Text = Convert.ToString(dt3.Rows[0]["BankName"]);
            PnlBankPDetails.Visible = false;
            txtFromDate.Focus();

        }
        else
        {
            lblbanknamep.Text = "No such Bank code";
            txtbankcodep.Focus();
            txtbankcodep.Text = "";
            PnlBankPDetails.Visible = false;
        }
    }

    protected void txtDrawnon_TextChanged(object sender, EventArgs e)
    {
        string BankCode2 = txtDrawnon.Text.ToString().Split(':')[0].Trim();

        DataTable dt4 = new DataTable();
        dt4 = DCMaster.Get_Name(BankCode2, "Bank").Tables[0];
        if (dt4.Rows.Count != 0)
        {
            txtDrawnon.Text = BankCode2;
            lblDrawnonname.Text = Convert.ToString(dt4.Rows[0]["BankName"]);
            txtRemark.Focus();

            //txtDrawnon.Text = BankReceipt.Get_BankPaymentDocNo(BankCode);
        }
        else
        {
            lblDrawnonname.Text = "No such Bank code";
            txtDrawnon.Focus();
            txtDrawnon.Text = "";
        }
    }
    #endregion

    #region IndexChanged
    protected void DDLCCDD_SelectedIndexChanged(object sender, EventArgs e)
    {
        // string CCDD = DDLCCDD.DataTextField;
        if (DDLCCDD.SelectedItem.Text == "Cash")
        {
            txtCCDDNo.Enabled = false;
            
            //txtAmt.Focus();
        }
        else
            if ((DDLCCDD.SelectedItem.Text == "DD") || (DDLCCDD.SelectedItem.Text == "Cheque"))
            {
                txtCCDDNo.Enabled = true;
              //  txtCCDDNo.Focus();
              
            }
        DDLCCDD.Focus();
    }

    #endregion

    #region Grid Events
    protected void GrdBankPDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        btn_Save.Text = "Update";
        btn_Save.Visible = true;
        btnDelete.Visible = true;
        filter.Visible = false;

        PnlAddBankP.Visible = true;
        Pnldate.Visible = false;
        PnlBankPDetails.Visible = false;

        // TxtAccBkCode.Enabled = false;
        // TxtDocNo.Enabled = false;
        //TxtSerialNo.Enabled = false;

        try
        {
            LblBankPID.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblBankPID")).Text;
            txtbankcode.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblBankCode")).Text;
            lblbankname.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblBankName")).Text;
            txtdocno.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblDocNo")).Text;
            txtdocDate.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblDocDt")).Text;
            //  txtsrno.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblSNo")).Text;
            txtAccode.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblAccCode")).Text;
            lblaccname.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblAccName")).Text;
            txtperson.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblPnI")).Text;
            txtreportcode.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblRCode")).Text;
            lblacname.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblRepName")).Text;
            DDLCCDD.SelectedValue = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblCCDD")).Text;
            //  txtType.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblType")).Text;
            txtCCDDNo.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblCCDDNo")).Text;
            txtAmt.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblAmt")).Text;
            txtDrawnon.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblDrawnon")).Text;
            lblDrawnonname.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblDrwnonName")).Text;
            txtRemark.Text = ((Label)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("lblRemark")).Text;
            CheckActive.Checked = ((CheckBox)GrdBankPDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        }
        catch
        {
        }
        //Check agaist CutOffDate
                    bool i = Global.ValidateDate(txtdocDate.Text.ToString());
                    if (i == true)
                    {

                    }
                    else
                    {
                        btnDelete.Visible = false;
                        btn_Save.Visible = false;
                        lblAuditMsg.Text = "You cannot Edit Bank Payment Entry of Date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString();
                    }

    }

    protected void GrdBankPDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    #endregion

    #endregion

    #region Methods

    #region SetView
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
                if (page == "bankpayment.aspx")
                {
                    pageName.InnerHtml = "Add Bank Payment";
                    LblBankPID.Text = "0";
                    PnlAddBankP.Visible = true;
                    Pnldate.Visible = false;
                    PnlBankPDetails.Visible = false;

                    btn_Save.Visible = true;
                    btnDelete.Visible = false;
                    filter.Visible = false;
                    txtbankcode.Focus();
                    txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    pageName.InnerHtml = "Add Bank Payment";
                    LblBankPID.Text = "0";
                    PnlAddBankP.Visible = true;
                    Pnldate.Visible = false;
                    PnlBankPDetails.Visible = false;

                    btn_Save.Visible = true;
                    btnDelete.Visible = false;
                    filter.Visible = false;
                    txtbankcode.Focus();
                    txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                }
            }
            else
                if (Request.QueryString["a"] == "v")
                {

                    pageName.InnerHtml = "View / Edit Bank Payment";
                    txtbankcodep.Focus();
                    PnlAddBankP.Visible = false;
                    Pnldate.Visible = true;
                    PnlBankPDetails.Visible = false;
                    Pnld.Visible = true;
                    pnldoc123.Visible = false; 
                    btn_Save.Visible = false;
                    btnDelete.Visible = false;
                    filter.Visible = true;

                }
        }
        else
        {
            Response.Redirect("~/dashboard.aspx");
        
        }
    }
    #endregion

    #region MessageBox
    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Binddata Method
    public void BindBankPDetails()
    {
        GrdBankPDetails.DataSource = BankPayment.GetBankPayment((txtbankcodep.Text.Trim()), fdt, tdt);
       
         string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
         if (page != "bankpayment.aspx")
         {
             GrdBankPDetails.Columns[7].Visible = false;
         } 
        GrdBankPDetails.DataBind();
    }
    #endregion

    #endregion




    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "DateWise")
        {
            Pnld.Visible = true;
            pnldoc123.Visible = false;
        }
        else
        {
            Pnld.Visible = false;
            pnldoc123.Visible = true;
        }
    }
    protected void btndoc_Click(object sender, EventArgs e)
    {
        string BnkCode = txtbankcodep.Text.Trim();
        DataTable dt = new DataTable();
        dt = Bank.Get_BankPaymentReport(BnkCode, Convert.ToInt32(txtdoc123.Text.Trim().ToString()), strFY).Tables[0];

        if (dt.Rows.Count > 0)
        {
            GrdBankPDetails.DataSource = dt;
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
            if (page != "bankpayment.aspx")
            {
                GrdBankPDetails.Columns[7].Visible = false;
            }
            GrdBankPDetails.DataBind();


            PnlBankPDetails.Visible = true;
        }
        else
        {
            PnlBankPDetails.Visible = false;
            MessageBox("Records Not Available ");
        }
    }
    protected void GrdBankPDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}




