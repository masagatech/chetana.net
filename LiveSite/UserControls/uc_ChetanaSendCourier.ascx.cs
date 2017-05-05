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

public partial class UserControls_uc_ChetanaSendCourier : System.Web.UI.UserControl
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
        divLevel4.Visible = false;
        divLevel2.Visible = true;
        divLevel3.Visible = true;
        Courier();
        Branch();
        
    }
    public void Courier()
    {
        ddlCourier.DataSource = CourierDetails.GetCourier("Courier");
        ddlCourier.DataBind();
        ddlCourier.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
       
    
    }
    public void Branch()
    {
        ddlBranch.DataSource = CourierDetails.GetCourier("Branch");
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
        

    }
    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        
        Int32 count = 0;
        DataTable Ds = new DataTable();
        DataRow R;
        if (txtInvoiceNoGet.Text.ToString() != "")
        {
            String mInv = "";
            Ds = CourierDetails.Get_CourierDetails(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY)).Tables[0];
            if (Ds.Rows.Count == 0)
            {
                mInv = txtInvoiceNoGet.Text;
                if (mInv != null)
                {
                    mInv = mInv.Substring(0, mInv.IndexOf("."));

                }
                //Ds = CourierDetails.Get_CourierDetails(float.Parse(txtInvoiceNoGet.Text.Remove(txtInvoiceNoGet.Text.Length - 3, 3)), "DocNoCheck", Convert.ToInt32(strFY)).Tables[0];
                Ds = CourierDetails.Get_CourierDetails(float.Parse(mInv), "DocNoCheck", Convert.ToInt32(strFY)).Tables[0];
                if (Ds.Rows.Count == 0)
                    MessageBox("Invoice is not created, type correct invoice no.");
            } 
            //if (Ds.Rows.Count == 0)
            //    MessageBox("Invoice is not created, type correct invoice no.");
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
               divgrdCD.Visible = true;

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
                        //lblDocumentNo.Text = R[2].ToString();
                        lblDocumentNo.Text = R[3].ToString();
                        lblAddress.Text = R[13].ToString();
                        lblPhone1.Text = R[14].ToString();
                        lblCustomerName.Text = R[6].ToString();
                        lblPersonIncharge.Text = R[15].ToString();
                    }

                }
                 divData.Visible = true;
            }
        }
       
        txtInvoiceNoGet.Text = "";
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        PnlSendCourier.Visible = true;
        divgrdCD.Visible = true;
        grdCD.Visible = true;
        ViewState["DocNo"] = ViewState["DocNo"] +"," + lblDocumentNo.Text + ",";
        DataTable Ds = new DataTable();
        Ds = CourierDetails.Get_CourierDetailsCheck(Convert.ToString(ViewState["DocNo"]), "InvoiceNoGrid",Convert.ToInt32(strFY)).Tables[0];
        //Ds = CourierDetails.Get_CourierDetailsCheckSave(Convert.ToString(ViewState["DocNo"]), "InvoiceNoGrid", Convert.ToInt16(ddlCourier.SelectedValue.ToString()), Convert.ToInt16(ddlBranch.SelectedValue.ToString()), Convert.ToInt32(strFY)).Tables[0];
        
        grdCD.DataSource = Ds;
        grdCD.DataBind();
       }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int SCD;
        try 
        {
            CourierDetails _objCD = new CourierDetails();
              _objCD.Save(Convert.ToString(ViewState["DocNo"]), "InvoiceNoGrid", Convert.ToInt16(strFY), Convert.ToInt16(ddlCourier.SelectedValue.ToString()), Convert.ToInt16(ddlBranch.SelectedValue.ToString()), txtAddress.Text.ToString(), txtDepartment.Text.ToString(), txtAddressGeneral.Text.ToString(), txtRemark.Text.ToString(), Convert.ToString(Session["UserName"]), txtweight.Text.ToString(),Convert.ToDateTime(DateTime.Now.ToString()), out SCD);
            MessageBox("Record saved successfully");
             ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PrintSendCourier.aspx?d=" + SCD + "')", true);
            grdCD.Visible = false;
            btnSave.Visible = false;
            divData.Visible = false;
            txtInvoiceNoGet.Text = "";
            txtDocNoGet.Text = "";
            txtAddress.Text = "";
            ddlBranch.SelectedValue = "0";
            ddlCourier.SelectedValue = "0";
            ViewState["DocNo"] = "";

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
                    MessageBox("Courier is already generated for this invoce no is  " + Ds.Tables[0].Rows[0]["SCMasterAutoId"].ToString() + " Do you want to create it again ?");
                    //txtInvoiceNoGet.Text = "";
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
    protected void rdLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            divLevel4.Visible = false;
            divLevel2.Visible = true;
            divLevel3.Visible = true;
           
        }
        else {
            txtInvoiceNoGet.Text = "";
           PnlSendCourier.Visible = false;
            divgrdCD.Visible = false;
            divLevel3.Visible = false;
           
            divLevel2.Visible = true;
            divLevel4.Visible = true;
           
            
          
            
        }
    }
    protected void btnGeneralSave_Click(object sender, EventArgs e)
    {
        int SCD;
        try
        {
 string date = txtsdate.Text.Split('/')[1] + "/" + txtsdate.Text.Split('/')[0] + "/" + txtsdate.Text.Split('/')[2];
            CourierDetails _objCD = new CourierDetails();
            _objCD.Save(Convert.ToString(ViewState["DocNo"]), "General", Convert.ToInt16(strFY), Convert.ToInt16(ddlCourier.SelectedValue.ToString()), Convert.ToInt16(ddlBranch.SelectedValue.ToString()), txtAddress.Text.ToString(), txtDepartment.Text.ToString(), txtAddressGeneral.Text.ToString(), txtRemark.Text.ToString(), Convert.ToString(Session["UserName"]), txtweight.Text.ToString(),Convert.ToDateTime(date), out SCD);
            MessageBox("Record saved successfully");
            ViewState["SCD"] = ViewState["SCD"] + "," + SCD + ",";
            string mSCD = ViewState["SCD"].ToString();
            //if (mSCD != null)
            //{
            //    mSCD = mSCD.Substring(0, mSCD.Length - 1);
               
            //}

            DataTable Ds = new DataTable();
            Ds = CourierDetails.Get_CourierDetailsGeneral(mSCD, "GeneralGrid", Convert.ToInt32(strFY)).Tables[0];
            //Ds = CourierDetails.Get_CourierDetailsCheckSave(Convert.ToString(ViewState["DocNo"]), "InvoiceNoGrid", Convert.ToInt16(ddlCourier.SelectedValue.ToString()), Convert.ToInt16(ddlBranch.SelectedValue.ToString()), Convert.ToInt32(strFY)).Tables[0];

            grdGeneral.DataSource = Ds;
            grdGeneral.DataBind();
            SaveGeneral.Visible = true;
            txtDepartment.Text = "";
            txtRemark.Text = "";
            //txtAddress.Text = "";
            txtAddressGeneral.Text = "";
            //Branch();
            //Courier();
            divLevel4.Visible = true;
            divgrdGeneral.Visible = true;

        }
        catch { }
    }
    protected void SaveGeneral_Click(object sender, EventArgs e)
    {

        DataSet Ds = new DataSet();
        Ds = CourierDetails.Get_CourierDetailsGeneral(Convert.ToString(ViewState["SCD"]), "GeneralGridSave", Convert.ToInt32(strFY));
        MessageBox("Record saved successfully");
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PrintSendCourier.aspx?mFlag=GeneralCourierID&d=" + Ds.Tables[0].Rows[0]["GeneralCourierID"].ToString() + "')", true);
        //divLevel4.Visible = false;
        //divLevel2.Visible = true;
        //divLevel3.Visible = true;
        divgrdGeneral.Visible = false;
        txtAddress.Text = "";
        Courier();
        Branch();
        ViewState["SCD"] = "";
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedValue.ToString() != "0")
        {
            trBranchAddress.Visible = true;
            DataSet Ds = new DataSet();
            Ds = CourierDetails.GetCourierBranch(Convert.ToInt16(ddlBranch.SelectedValue.ToString()), "BranchAddress");

            if (Ds.Tables[0].Rows[0]["Address"].ToString() != "")
            {
                txtAddress.Text = Ds.Tables[0].Rows[0]["Address"].ToString();
                trAddressGeneral.Visible = false;
                txtAddressGeneral.Text = "";
            }
            else
            {
                trAddressGeneral.Visible = false;
                txtAddressGeneral.Text = "";
                MessageBox("Address not specified for " + ddlBranch.SelectedItem.Text.ToString() + " branch");
            }

        }
        else
        {
            trBranchAddress.Visible = false;
            txtAddress.Text = "";
            trAddressGeneral.Visible = true;

        }
    }
   
}