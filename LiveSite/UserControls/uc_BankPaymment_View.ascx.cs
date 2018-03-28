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
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class UserControls_uc_BankPaymment_View : System.Web.UI.UserControl
{

    #region Variables

    string docdate;
    string frdate;
    string todate;
    DateTime ddt;
    DateTime tdt;
    DateTime fdt;
    string strChetanaCompanyName = "cppl";
    string strFY;
    int DocNo;

    #endregion


    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                HidFY.Value = Session["FY"].ToString();
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
            // BindBankRDetails();
            DDLCCDD.Items.Insert(0, new ListItem("-Select-", "0"));
            txtbankcoder.Focus();
            Session["Data"] = null;

        }
        else
        {
            FillReport((DataTable)Session["Data"]);
        }
    }

    #endregion

    #region Events

    #region Save
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        int srcptno;
        docdate = txtdocDate.Text.Split('/')[2] + "/" + txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0];
        ddt = Convert.ToDateTime(docdate);
        string BankCode = txtbankcode.Text.Trim();
        if (txtSrcptno.Text.Trim() == "")
        {
            txtSrcptno.Text = "0";
        }
        srcptno = Convert.ToInt32(txtSrcptno.Text.Trim());

        BankReceipt obBnkrcpt = new BankReceipt();
        txtdocno.Text = BankReceipt.Get_BankPaymentDocNo(BankCode);
        // txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        if (Session["UserName"] != null)
        {
            try
            {
                obBnkrcpt.BankReceiptID = Convert.ToInt32(LblBankRID.Text);
                obBnkrcpt.BankCode = txtbankcode.Text.Trim();
                obBnkrcpt.DocumentNo = Convert.ToInt32(txtdocno.Text.Trim());
                obBnkrcpt.SerialNo = 1;
                obBnkrcpt.DocumentDate = ddt;
                obBnkrcpt.AccountCode = txtAccode.Text.Trim(); ;
                obBnkrcpt.PersonInCharge = txtperson.Text.Trim();
                obBnkrcpt.ReportCode = txtreportcode.Text.Trim();
                obBnkrcpt.SalesmanReceiptNo = srcptno;
                obBnkrcpt.Cash_Cheque_DD = DDLCCDD.SelectedItem.Text;
                // obBnkrcpt.Type = txtType.Text.Trim();
                obBnkrcpt.Cheque_DD_NO = txtCCDDNo.Text.Trim();
                obBnkrcpt.Amount = Convert.ToDecimal(txtAmt.Text.Trim());
                obBnkrcpt.DrawnOn = txtDrawnon.Text.Trim();
                obBnkrcpt.Remarks = txtRemark.Text.Trim();
                obBnkrcpt.Isactive = CheckActive.Checked;
                obBnkrcpt.CreatedBy = Session["UserName"].ToString();
                obBnkrcpt.strFY = Convert.ToInt32(strFY);
                obBnkrcpt.Save(out DocNo);
                if (DocNo.ToString() == "-3")
                {
                    MessageBox("Receipt No Already Used.");
                }
                else if (DocNo.ToString() == "-2")
                {
                    MessageBox("Receipt No Not allocated to any SalesMan.");
                }
                else
                {
                    txtdocno.Text = Convert.ToString(DocNo);
                    // MessageBox("Record saved successfully");
                    MessageBox(Constants.save + "\\r\\n Document No: " + (txtdocno.Text));
                    loder("Last saved Document no. : " + txtdocno.Text);
                    // GrdBankRDetails.DataBind();


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
                    txtSrcptno.Text = "";
                    DDLCCDD.SelectedIndex = 0;
                    // txtType.Text = "";
                    txtCCDDNo.Text = "";
                    txtAmt.Text = "";
                    txtDrawnon.Text = "";
                    lblDrawnonname.Text = "";
                    txtRemark.Text = "";
                    CheckActive.Checked = true;

                    btn_Save.Text = "Save";
                    PnlAddBankR.Visible = true;
                    Pnldate.Visible = false;
                    PnlBankRDetails.Visible = false;
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

        try
        {
            string BnkCode = txtbankcoder.Text.Trim();

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
                    Session["Data"] = ds.Tables[0];
                    FillReport(ds.Tables[0]);
                    //string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
                    //if (page != "bankreceipt.aspx")
                    //{
                    //    GrdBankRDetails.Columns[7].Visible = false;
                    //}
                    //GrdBankRDetails.DataBind();

                    PnlBankRDetails.Visible = true;

                }
                else
                {
                    PnlBankRDetails.Visible = false;
                    MessageBox("Records Not Available ");
                }
            }
            else
            {
                PnlBankRDetails.Visible = false;
                MessageBox("From Date is greater than To Date");
            }

            txtbankcoder.Focus();


        }
        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            txtbankcoder.Focus();

        }

    }

    public void FillReport(DataTable dt)
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/BankPayment_View.rpt"));
        crystalReport.SetDataSource(dt);
        repBankReceipt.ReportSource = crystalReport;
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
            txtdocDate.Focus();

            //txtdocno.Text = BankReceipt.Get_BankPaymentDocNo(BankCode);
        }
        else
        {
            lblbankname.Text = "No such Bank code";
            txtbankcode.Focus();
            txtbankcode.Text = "";
        }
    }

    protected void txtAccode_TextChanged(object sender, EventArgs e)
    {
        string Accode = txtAccode.Text.ToString().Split(':')[0].Trim();
        string flag = txtAccode.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt1 = new DataTable();
        dt1 = DCMaster.Get_Name(Accode, flag).Tables[0];
        if (dt1.Rows.Count != 0)
        {
            if (flag == "AC")
            {
                txtAccode.Text = Accode;
                lblaccname.Text = Convert.ToString(dt1.Rows[0]["AC_NAME"]);
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
                txtSrcptno.Focus();
            }
            else
                if (flag == "Cust")
                {
                    txtreportcode.Text = Reportcode;
                    lblacname.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
                    txtSrcptno.Focus();
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
        //PnlBankRDetails.Visible = false;
        //txttoDate.ReadOnly = true;
    }

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        //PnlBankRDetails.Visible = false;
        //txtFromDate.ReadOnly = true;
        txttoDate.Focus();
    }

    protected void txtbankcoder_TextChanged(object sender, EventArgs e)
    {
        string BankCode1 = txtbankcoder.Text.ToString().Split(':')[0].Trim();

        DataTable dt3 = new DataTable();
        dt3 = DCMaster.Get_Name(BankCode1, "Bank").Tables[0];

        if (dt3.Rows.Count != 0)
        {
            txtbankcoder.Text = BankCode1;
            lblbanknamer.Text = Convert.ToString(dt3.Rows[0]["BankName"]);
            PnlBankRDetails.Visible = false;
            txtFromDate.Focus();
        }
        else
        {
            lblbanknamer.Text = "No such Bank code";
            txtbankcoder.Focus();
            txtbankcoder.Text = "";
            PnlBankRDetails.Visible = false;
        }
    }

    protected void txtDrawnon_TextChanged(object sender, EventArgs e)
    {
        //string BankCode2 = txtDrawnon.Text.ToString().Split(':')[0].Trim();

        //DataTable dt4 = new DataTable();
        //dt4 = DCMaster.Get_Name(BankCode2, "Bank").Tables[0];
        //if (dt4.Rows.Count != 0)
        //{
        //    txtDrawnon.Text = BankCode2;
        //    lblDrawnonname.Text = Convert.ToString(dt4.Rows[0]["BankName"]);
        //    txtRemark.Focus();

        //    //txtDrawnon.Text = BankReceipt.Get_BankPaymentDocNo(BankCode);
        //}
        //else
        //{
        //    lblDrawnonname.Text = "No such Bank code";
        //    txtDrawnon.Focus();
        //    txtDrawnon.Text = "";
        //}
    }
    #endregion

    #region IndexChanged
    protected void DDLCCDD_SelectedIndexChanged(object sender, EventArgs e)
    {
        // string CCDD = DDLCCDD.DataTextField;
        if (DDLCCDD.SelectedItem.Text == "Cash")
        {
            txtCCDDNo.Enabled = false;
            txtAmt.Focus();
        }
        else
            if ((DDLCCDD.SelectedItem.Text == "DD") || (DDLCCDD.SelectedItem.Text == "Cheque"))
            {
                txtCCDDNo.Enabled = true;
                txtCCDDNo.Focus();
            }
    }

    #endregion

    #region Grid Events
    protected void GrdBankRDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        btn_Save.Visible = true;
        btnDelete.Visible = true;
        filter.Visible = false;
        btn_Save.Text = "Update";

        PnlAddBankR.Visible = true;
        Pnldate.Visible = false;
        PnlBankRDetails.Visible = false;

        // TxtAccBkCode.Enabled = false;
        // TxtDocNo.Enabled = false;
        //TxtSerialNo.Enabled = false;

        try
        {
            //LblBankRID.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblBankPID")).Text;
            //txtbankcode.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblBankCode")).Text;
            //lblbankname.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblBankName")).Text;
            //txtdocno.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblDocNo")).Text;
            //txtdocDate.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblDocDt")).Text;
            //// txtsrno.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblSNo")).Text;
            //txtAccode.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblAccCode")).Text;
            //lblaccname.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblAccName")).Text;
            //txtperson.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblPnI")).Text;
            //txtreportcode.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblRCode")).Text;
            //lblacname.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblRepName")).Text;
            //txtSrcptno.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblSMReceipt")).Text;
            //DDLCCDD.SelectedValue = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblCCDD")).Text;
            //// txtType.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblType")).Text;
            //txtCCDDNo.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblCCDDNo")).Text;
            //txtAmt.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblAmt")).Text;
            //txtDrawnon.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblDrawnon")).Text;
            //lblDrawnonname.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblDrwnonName")).Text;
            //txtRemark.Text = ((Label)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("lblRemark")).Text;
            //CheckActive.Checked = ((CheckBox)GrdBankRDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        }
        catch
        {
        }
    }
    protected void GrdBankRDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            //write 
            if (LblBankRID.Text != "" || LblBankRID.Text != "0")
            {
                try
                {
                    DeleteModule objDelete = new DeleteModule();
                    objDelete.ID = LblBankRID.Text.Trim();
                    objDelete.FY = Convert.ToInt32(HidFY.Value);
                    objDelete.Is_Restore = false;
                    objDelete.Created_BY = Session["UserName"].ToString();
                    objDelete.Module = "BankReciept";
                    objDelete.Save();
                    MessageBox("Record successfully deleted");

                    //Reset Form
                    pageName.InnerHtml = "View / Edit Bank Payment";
                    PnlAddBankR.Visible = false;
                    Pnldate.Visible = true;
                    PnlBankRDetails.Visible = false;
                    btn_Save.Visible = false;
                    btnDelete.Visible = false;
                    btnDelete.Visible = false;
                    filter.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox("Record not deleted due to : " + ex.Message.ToString());

                }

            }
        }
    }

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
                if (page == "bankreceipt.aspx")
                {
                    pageName.InnerHtml = "Add Bank Receipt";
                    LblBankRID.Text = "0";
                    PnlAddBankR.Visible = true;
                    Pnldate.Visible = false;
                    PnlBankRDetails.Visible = false;

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
                    pageName.InnerHtml = "View / Edit Bank Receipt";
                    PnlAddBankR.Visible = false;
                    Pnldate.Visible = true;
                    PnlBankRDetails.Visible = false;

                    btn_Save.Visible = false;
                    btnDelete.Visible = false;
                    filter.Visible = true;
                }
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
    public void BindBankRDetails()
    {
        //string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
        //if (page != "bankreceipt.aspx")
        //{
        //    GrdBankRDetails.DataSource = BankReceipt.GetBankReceipt((txtbankcoder.Text.Trim()), fdt, tdt);
        //    GrdBankRDetails.Columns[7].Visible = false;
        //}
        //GrdBankRDetails.DataBind();
    }
    #endregion

    #endregion

    }

