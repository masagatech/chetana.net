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
using System.Web.Services;
using Idv.Chetana.BAL;

public partial class UserControls_ODC_uc_OCancelDC_ : System.Web.UI.UserControl
{
    #region Variables
    //int DocNo;
    string Qty = "1";
    string rqty = "0";
    static string Cflag = "";
    //string bookname = "";
    public static bool Pflag;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion
    #region Pageload

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
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
        if (!Page.IsPostBack)
        {
            DDLCustomer.Focus();
            SetView();
            Session["tempBookData"] = null;
            //btncancel.Visible = false;
            PnlCancel(false);
            
            
            tabledetails.Visible = false;
        }

    }
    #endregion
    public void PnlCancel(bool Flag)
    {
        if (Flag == true)
        {
            btncancel.Visible = true;
            txtRemark.Visible = true;
            lblremark.Visible = true;
        }
        else
        {
            btncancel.Visible = false;
            txtRemark.Visible = false;
            lblremark.Visible = false;
        }
    }
    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion

    #region Bind Method
    public void ClearData()
    {
        lbldocumentno.Text = "";
        lbldocdate.Text = "";
        lblchalanno.Text = "";
        lblchaldate.Text = "";
        lblorderno.Text = "";
        lblcanceldate.Text = "";
        lblsalesman.Text = "";
        lblCustomer.Text = "";
        lblremarked.Text = "";
        //lblSpInstruction.Text = "";
        // lblBankThrough.Text = "";
        // lblTransporter.Text = "";
        // lblPersonIncharge.Text = "";
        grdOrderDetails.Visible = false;

        Session["tempBookData"] = null;
    }
   
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                Pnlcust.Visible = true;
                pnlconfirm.Visible = false;
                Cflag = "Cancel";
                DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer", Convert.ToInt32(strFY));
                DDLCustomer.DataBind();
                DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
                DDLCustomer.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    //Pnlcust.Visible = false;
                    Cflag = "Canceled";
                    DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Canceled", Convert.ToInt32(strFY));
                    DDLCustomer.DataBind();
                    DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
                    // Rptrpending.DataSource = DCMaster.Get_Customer_PendingDocNo("Pending");
                    // Rptrpending.DataBind();
                    pnlconfirm.Visible = false;
                    Rptrpending.Visible = true;
                }
        }
    }
    #endregion

    #region Events
    protected void BtnGetOrderDetails_Click(object sender, EventArgs e)
    {
        Session["tempBookData"] = null;
        if (txtdocno.Text == "")
        {
            message("Please enter Document no.");
            ClearData();
        }
        else
        {
            int DocNum = Convert.ToInt32(txtdocno.Text.ToString());
            DataTable dt = new DataTable();
            bool condition1 = false;
            bool condition2 = false;

            dt = DCMaster.Get_DCMasterBy_DocNum(DocNum, "CancelDC",Convert.ToInt32(strFY)).Tables[0];
            // dt = DCDetails.Idv_Get_DCDetails_By_DocNo(DocNum, "Canceled").Tables[0];

            if (dt.Rows.Count > 0)
            {
                //    condition1 = Convert.ToBoolean(dt.Rows[0]["IsConfirm"]);
                condition2 = Convert.ToBoolean(dt.Rows[0]["IsCanceled"]);
                Pflag = Convert.ToBoolean(dt.Rows[0]["IsPartialConfirmed"]);

            }
            if (condition2 == true)
            {
                // dt = DCDetails.Idv_Get_DCDetails_By_DocNo(DocNum, "Canceled").Tables[0];

                grdOrderDetails.DataSource = DCDetails.Idv_Get_DCDetails_By_DocNo(DocNum, "Canceled",Convert.ToInt32(strFY)).Tables[0];
                grdOrderDetails.DataBind();
                grdOrderDetails.Visible = true;
                //btncancel.Visible = false;
                PnlCancel(false);
            }
            else
            {
                // dt = DCDetails.Idv_Get_DCDetails_By_DocNo(DocNum, "notCanceled").Tables[0];
                grdOrderDetails.DataSource = DCDetails.Idv_Get_DCDetails_By_DocNo(DocNum, "notCanceled", Convert.ToInt32(strFY)).Tables[0];
                grdOrderDetails.DataBind();
                grdOrderDetails.Visible = true;
                //btncancel.Visible = true;
                PnlCancel(true);
                

            }
            //else if (dt.Rows.Count == 0)
            //{
            //    message("Record not found for document no. " + txtdocno.Text);
            //    btncancel.Visible = false;
            //    txtdocno.Text = "";
            //    txtdocno.Focus();
            //    ClearData();
            //}
            // else

            if (dt.Rows.Count > 0)
            {
                Orderdetails.Visible = true;
                tabledetails.Visible = true;
                lbldocumentno.Text = dt.Rows[0]["DocumentNo"].ToString();
                lblchalanno.Text = dt.Rows[0]["ChallanNo"].ToString();
                lblchaldate.Text = dt.Rows[0]["ChallanDate"].ToString();
                lblorderno.Text = dt.Rows[0]["OrderNo"].ToString();
                //txtsalemanCode.Text = dt.Rows[0]["SalesmanCode"].ToString();
                lblsalesman.Text = dt.Rows[0]["SalesmanName"].ToString();
                lblcanceldate.Text = dt.Rows[0]["CanceledDate"].ToString();
                lbldocdate.Text = dt.Rows[0]["DocumentDate"].ToString();
                lblCustomer.Text = dt.Rows[0]["CustName"].ToString();
                lblremarked.Text = dt.Rows[0]["CanceledRemark"].ToString();
                // lblPersonIncharge.Text = dt.Rows[0]["PIncharge"].ToString();
                // lblSpInstruction.Text = dt.Rows[0]["SpInstruction"].ToString();
                //  lblTransporter.Text = dt.Rows[0]["TransporterCode"].ToString();
                //  lblBankThrough.Text = dt.Rows[0]["BankName"].ToString();


            }
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            DCMaster _objDC = new DCMaster();
            DCDetails _objdetails = new DCDetails();
            if (Pflag == true)
            {
                if (lbldocumentno.Text != "")
                {
                    foreach (GridViewRow row in grdOrderDetails.Rows)
                    {
                        _objdetails.DCDetailID = Convert.ToInt32(((Label)row.FindControl("lbldcdetailid")).Text);
                        _objdetails.CanceledQty = Convert.ToInt32(((Label)row.FindControl("lblavailable")).Text);
                        _objdetails.Cancel = false;
                        _objdetails.PCancel = true;
                        _objdetails.UpdateDCDetails();
                    }

                    _objDC.DocNo = Convert.ToInt32(lbldocumentno.Text.ToString());
                    _objDC.IsCanceled = true;
                    _objDC.FinancialYearFrom = Convert.ToInt32(strFY);
                    _objDC.Remark = txtRemark.Text.ToString();
                    _objDC.update(1);
                    tabledetails.Visible = false;
                }
                // message("Is Partial True");
            }
            else
            {
                // message("Is Partial False");
                if (lbldocumentno.Text != "")
                {
                    foreach (GridViewRow row in grdOrderDetails.Rows)
                    {
                        _objdetails.DCDetailID = Convert.ToInt32(((Label)row.FindControl("lbldcdetailid")).Text);
                         _objdetails.CanceledQty = Convert.ToInt32(((Label)row.FindControl("lblavailable")).Text);
                        _objdetails.Cancel = true;
                        _objdetails.PCancel = false;
                        _objdetails.UpdateDCDetails();
                    }
                    _objDC.DocNo = Convert.ToInt32(lbldocumentno.Text.ToString());
                    _objDC.IsCanceled = true;
                    _objDC.FinancialYearFrom = Convert.ToInt32(strFY);
                    _objDC.Remark = txtRemark.Text.ToString();

                    _objDC.update(1);
                }

            }
            ClearData();
           // btncancel.Visible = false;
            PnlCancel(false);

        }

        catch
        {
        }

    }
   
    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Cflag == "Cancel")
        {
            Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(Convert.ToInt32(DDLCustomer.SelectedValue), "Customer", Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"), Convert.ToInt32(strFY));
            Rptrpending.DataBind();
        }
        if (Cflag == "Canceled")
        {
            Rptrpending.DataSource = DCMaster.GetPendingDocNo_ForView(Convert.ToInt32(DDLCustomer.SelectedValue), "Canceled", Convert.ToDateTime("1/11/2001"), Convert.ToDateTime("1/12/2001"), Convert.ToInt32(strFY));
            Rptrpending.DataBind();
           // Rptrpending.DataSource = DCMaster.Get_Customer_PendingDocNo("Pending");
           // Rptrpending.DataBind();
        }
        pnlconfirm.Visible = true;
        Rptrpending.Visible = true;
        Orderdetails.Visible = false;
        upOrderNO.Update();
       
        // Rptrpending.DataSource = DCMaster.Get_Customer_PendingDocNo("Pending");
        //  Rptrpending.DataBind();
        //  pnlDetails.Visible = false;
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        //grdOrderDetails.DataSource = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(txtdocno.Text), "allbydocno").Tables[0];
        //grdOrderDetails.DataBind();
        //// pnlDetails.Visible = true;
        //grdOrderDetails.Visible = true;

        //string jv = "";
        //if (grdOrderDetails.Rows.Count <= 0)
        //{
        //    btncancel.Visible = false;
        //    jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_OCancelDC1_btnconfirm').style.display='none';";
        //}
        //else
        //{
        //    btncancel.Visible = true;
        //    jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_OCancelDC1_btnconfirm').style.display='visible';";
        //}
        //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);

    }
    
    #endregion

}

