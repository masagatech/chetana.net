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
using CrystalDecisions.CrystalReports.Engine;
public partial class Additional_Disburse : System.Web.UI.Page
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    Other_Z.OtherBAL ObjDAl = new Other_Z.OtherBAL();
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
        if (!Page.IsPostBack)
        {

            btnUpdate.Visible = false;
            DDLSuperZone.Focus();
            if (ddlCustmore.SelectedValue.ToLower().ToString() == "0" || ddlCustmore.SelectedValue.ToLower().ToString() == "")
            {

            }
            else
            {
                // ShowDetails();
                DataSet ds = new DataSet();
                ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_AdditionalCommission(
                   Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
                   Convert.ToInt32(DDLZone.SelectedValue.ToString()),
                   Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
                   Convert.ToInt32(DDLCC.SelectedValue.ToString()),
                   Convert.ToInt32(strFY));
                DataView dv = new DataView(ds.Tables[0]);
                gdGeneral.DataSource = dv;
                gdGeneral.DataBind();
                btnUpdate.Visible = true;

            }

            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            //btnSave.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            Bind_DDL_CC();

        }
        if (IsPostBack)
        {
            if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            {
                MessageBox("Select Items");
            }

            else
            {

                btnUpdate.Visible = true;
            }
        }

    }
    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();
        btnUpdate.Visible = true;
    }
    public void ShowDetails()
    {
        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_AdditionalCommission(
           Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
           Convert.ToInt32(DDLZone.SelectedValue.ToString()),
           Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
           Convert.ToInt32(DDLCC.SelectedValue.ToString()),
           Convert.ToInt32(strFY));
        DataView dv = new DataView(ds.Tables[0]);
        gdGeneral.DataSource = dv;
        gdGeneral.DataBind();
        //ReportDocument rd = new ReportDocument();
        //rd.Load(Server.MapPath("Report/AdditionalCommission.rpt"));
        //rd.Database.Tables[0].SetDataSource(dv);
        //CustomerWiseAmount.ReportSource = rd;


    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
            Bind_DDL_SuperZone();
        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }
    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLZone.Focus();
            ddlCustmore.Items.Clear();
            //  DDLZone.SelectedValue = null;
            Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_Customer();
            ddlCustmore.Focus();
        }

    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = ObjDAl.Idv_Chetana_Get_ZoneCustomerAdditionalCommissionOtherZ(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int OutNo=0;
        // We were using CustomerDetails but no more using it. 
        //CustomerDetails obj=new CustomerDetails();
        //BankPayment obj = new BankPayment();
        Other_Z.OtherBAL ObjBal = new Other_Z.OtherBAL();
        Other_Z.OtherBAL.SaveBankPay obj = new Other_Z.OtherBAL.SaveBankPay();
        foreach (GridViewRow row in gdGeneral.Rows)
        {
            if (Convert.ToDecimal(((TextBox)row.FindControl("txtAmount")).Text) > 0)
            {
                try
                {
                    obj.BankPaymentID = 0;
                    obj.BankCode = "";
                    obj.Documentno = 0;
                    obj.Serialno = 1;
                    obj.DocumentDate = DateTime.Now;
                    obj.AccountCode = ((Label)row.FindControl("lblCode")).Text;
                    obj.PersonInCharge = "";
                    obj.ReportCode = "";
                    obj.Cash_Cheque_DD = "";
                    obj.Cheque_DD_NO = "";
                    // obj.Type = txtType.Text.Trim();
                    obj.Type = "";
                    obj.Amount = Convert.ToDecimal(((TextBox)row.FindControl("txtAmount")).Text);
                    obj.DrawnOn = "";
                    obj.Remarks = "debit";
                    obj.IsActive = true;
                    obj.CreatedBy = Session["UserName"].ToString();
                    obj.UpdatedBy = "";
                    obj.strFY = Convert.ToInt32(strFY);
                    obj.Paymode = "AddcomisionDebit";
                    obj.IsChequeBounce = false;
                    //When Remarks = "debit", in sp we will insert value in Amount field to AddComDebit column in column
                    ObjBal.SaveBankPayment(obj,out OutNo);
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                
            }
        }
        ShowDetails();
        MessageBox("Record updated sucessfully..." + OutNo.ToString());
    }
}