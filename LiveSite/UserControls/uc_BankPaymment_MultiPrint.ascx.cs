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

public partial class UserControls_uc_BankPaymment_MultiPrint : System.Web.UI.UserControl
{

    #region Variables

    string docdate;
    string frdate;
    string todate;
    DateTime ddt;
    DateTime tdt;
    DateTime fdt;

    string strFY;
    int DocNo;
    ReportDocument rd = new ReportDocument();
    #endregion


    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
            HidFY.Value = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        //Response.Write(strFY);
        if (!Page.IsPostBack)
        {
            SetView();
            // BindBankRDetails();
            Session["MultiBank"] = null;
            Session["RptDoc"] = null;
        }
        else
        {
           
        }
    }
    
    protected override void OnInit(System.EventArgs e)
    {
        base.OnInit(e);


        if ((Request.Form.Keys.Count > 0))
        {
            fillReport(false);

        }

    }
    #endregion

    #region Events
    #region Button Click
    protected void btnget_Click(object sender, EventArgs e)
    {
        try
        {
            string BnkCode = txtbankcoder.Text.Trim();
            DataSet ds = new DataSet();

            ds = Bank.Get_BankPaymentReport_MultiPrint(BnkCode, strFY, rdbmodule.SelectedValue.ToString(), Convert.ToInt32(txtFromno.Text.ToString()), Convert.ToInt32(txttono.Text.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["MultiBank"] = ds.Tables[0];
                Session["selectedflg"] = rdbmodule.SelectedValue.ToString();
                fillReport(true);
            }
            else
            {
                MessageBox("Records Not Available ");
            }

            txtbankcoder.Focus();
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            txtbankcoder.Focus();
        }

    }



    #endregion

    #region TextChanged
    protected void txtbankcoder_TextChanged(object sender, EventArgs e)
    {
        string BankCode1 = txtbankcoder.Text.ToString().Split(':')[0].Trim();

        DataTable dt3 = new DataTable();
        dt3 = DCMaster.Get_Name(BankCode1, "Bank").Tables[0];

        if (dt3.Rows.Count != 0)
        {
            txtbankcoder.Text = BankCode1;
            lblbanknamer.Text = Convert.ToString(dt3.Rows[0]["BankName"]);
            //   PnlBankRDetails.Visible = false;
            txtFromno.Focus();
        }
        else
        {
            lblbanknamer.Text = "No such Bank code";
            txtbankcoder.Focus();
            txtbankcoder.Text = "";
            //  PnlBankRDetails.Visible = false;
        }
    }
    #endregion
    private void fillReport(bool flg)
    {
        if (Session["selectedflg"] != null)
        {
            if (Session["MultiBank"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["MultiBank"];

                if (Session["selectedflg"].ToString() == "Payment")
                {
                    rd.Load(Server.MapPath("Report/BankPayment_MultiPrint.rpt"));
                    rd.SetDataSource(dt);
                }
                else if (Session["selectedflg"].ToString() == "Receipt")
                {
                    rd.Load(Server.MapPath("Report/BankReceipt_Multiprint.rpt"));
                    rd.SetDataSource(dt);
                }
                else if (Session["selectedflg"].ToString() == "JV")
                {
                    rd.Load(Server.MapPath("Report/PrintJV_MultiPrint.rpt"));
                    rd.SetDataSource(dt);
                }
                else if (Session["selectedflg"].ToString() == "DN")
                {
                    rd.Load(Server.MapPath("Report/PrintDN_MultiPrint.rpt"));
                    rd.SetDataSource(dt);
                }
                repmultibank.ReportSource = rd;
                Session["RptDoc"] = rd;
            }
        }

    }



    #endregion

    #region Methods

    #region SetView
    public void SetView()
    {

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


    protected void rdbmodule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbmodule.SelectedValue.ToString() == "JV")
        {
            AllClear();
            txtbankcoder.Text = "ABC";
            pnlfdate.Visible = false;
            txtFromno.Focus();
        }
        else if (rdbmodule.SelectedValue.ToString() == "Payment")
        {
            AllClear();
            txtbankcoder.Focus();
            pnlfdate.Visible = true;
            
        }
        else if (rdbmodule.SelectedValue.ToString() == "Receipt")
        {
            AllClear();
            txtbankcoder.Focus();
        }
        else if (rdbmodule.SelectedValue.ToString() == "DN")
        {
            AllClear();
            txtbankcoder.Text = "ABC";
            pnlfdate.Visible = false;
            txtFromno.Focus();
        }
    }

    public void AllClear()
    {
        txtbankcoder.Text = "";
        lblbanknamer.Text = "";
        txtFromno.Text = "";
        txttono.Text = "";
        repmultibank.ReportSource = null;
    }
    
}

