#region Namespace
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
using System.Data.SqlClient;
#endregion

public partial class UserControls_uc_SendCourier : System.Web.UI.UserControl
{
    #region Varables
   
    static int quantity = 0;
    static decimal tamount = 0;
    static decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    static int docnewno = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    string DocNo;
    #endregion
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
        if (IsPostBack == true) { return; }
        
        lblMessage.Text = "";
    }
    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnget_Click(object sender, EventArgs e)
    {   Int32 count = 0;
        DataTable Ds = new DataTable();
        DataRow R;
        if (txtInvoiceNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.Get_CourierDetails(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY)).Tables[0];
            if (Ds.Rows.Count == 0)
                lblMessage.Text = "Invoice Is Not Created.";
        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.Get_CourierDetails(float.Parse(txtDocNoGet.Text), "DocNoCheck", Convert.ToInt32(strFY)).Tables[0];
            if (Ds.Rows.Count != 0)
            {
                message_error.Visible = true;
                lblMessage.Text = "Invoice Is Already Created.";
                 count = Ds.Rows.Count;
            }

            else
            {
                Ds = CourierDetails.Get_CourierDetails(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY)).Tables[0];
            }
        }
        if (count == 0){
            if (Ds.Rows.Count != 0)
            {
                PnlSendCourier.Visible = true;

                for (int k = 0; k <= Ds.Rows.Count - 1; k++)
                {
                    R = Ds.Rows[k];

                    for (int i = 0; i <= Ds.Columns.Count - 1; i++)
                    {
                        if (txtInvoiceNoGet.Text.ToString() != "")
                        {
                            lblInvoiceNoH.Visible = true;
                            lblInvoiceNo.Visible = true;
                            lblInvoiceNo.Text = R[3].ToString();
                        }
                        else
                        {
                            lblInvoiceNoH.Visible = false;
                            lblInvoiceNo.Visible = false;
                        }
                        lblDocumentNo.Text = R[2].ToString();
                        lblAddress.Text = R[13].ToString();
                        lblPhone1.Text = R[14].ToString();
                        lblCustomerName.Text = R[6].ToString();
                        lblPersonIncharge.Text = R[15].ToString();
                    }

                }
            }
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        PnlSendCourier.Visible = false;
        ViewState["DocNo"] = ViewState["DocNo"] +"," + lblDocumentNo.Text + ",";
        DataTable Ds = new DataTable();
        Ds = CourierDetails.Get_CourierDetailsCheck(Convert.ToString(ViewState["DocNo"]), "DocNoGrid", Convert.ToInt32(strFY)).Tables[0];
        grdCD.DataSource = Ds;
        grdCD.DataBind();
       }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int SCD;
        try 
        {
            CourierDetails _objCD = new CourierDetails();
            _objCD.Save(Convert.ToString(ViewState["DocNo"]), "DocNoGrid", Convert.ToInt32(strFY), Convert.ToString(Session["UserName"]), out SCD);
            MessageBox("Record saved successfully");
            //Response.Redirect("Print/PrintSendCourier.aspx?d=" + SCD + "");
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PrintSendCourier.aspx?d=" + SCD + "')", true);

            grdCD.Visible = false;
            btnSave.Visible = false;
            txtInvoiceNoGet.Text = "";
            txtDocNoGet.Text = "";
           
        }
        catch { }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void txtInvoiceNoGet_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Invoice = txtInvoiceNoGet.Text;
                DataSet Ds = new DataSet();
                Ds = CourierDetails.GetCourierValidation("InvoiceCourier", Invoice);

                if (Ds.Tables[0].Rows.Count != 0)
                {
                    MessageBox("Courier Id is Already Created   " + Ds.Tables[0].Rows[0]["SCMasterAutoId"].ToString());
                    txtInvoiceNoGet.Text = "";
                    txtInvoiceNoGet.Focus();

                }
                else
                {
                    txtInvoiceNoGet.Focus();
                }
            }
            catch
            {

            }
        }
    }
    protected void txtDocNoGet_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string DocNo = txtDocNoGet.Text;
                DataSet Ds = new DataSet();
                Ds = CourierDetails.GetCourierValidation("DocNoCourier", DocNo);

                if (Ds.Tables[0].Rows.Count != 0)
                {
                    MessageBox("Courier Id is Already Created   " + Ds.Tables[0].Rows[0]["SCMasterAutoId"].ToString());
                    txtDocNoGet.Text = "";
                    txtDocNoGet.Focus();

                }
                else
                {
                    txtDocNoGet.Focus();
                }
            }
            catch
            {

            }
        }
    }
}