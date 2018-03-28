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

public partial class BankPayment_CheckList : System.Web.UI.Page
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
            //SetView();
            // BindBankRDetails();
           // DDLCCDD.Items.Insert(0, new ListItem("-Select-", "0"));
            //
            Session["Data"] = null;
            txtbankcoder.Focus();
	    //FillReport((DataView)Session["Data"]);
        }
        else
        {
            FillReport((DataView)Session["Data"]);
        }
    }

    #endregion

    #region Print Method
    private void PrindFunction()
    {
	Session["Data"] = null;
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
                if (txtsubgroup.Text.Trim() != "")
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "GR_HEAD = '" + txtsubgroup.Text.Trim() + "'";
                    Session["Data"] = dv;
                    FillReport(dv);
                }
                else
                {

                    DataView dv1 = new DataView(ds.Tables[0]);
                    Session["Data"] = dv1;
                    FillReport(dv1);

                }
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

        // txtbankcoder.Focus();
        //Session["Data"] = null;
    }
    #endregion

    #region Events
    #region Button Click
    protected void btnget_Click(object sender, EventArgs e)
    {

        try
        {
            PrindFunction();
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            txtbankcoder.Focus();

        }

    }

    public void FillReport(DataView dt)
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/BankPayment_CheckList.rpt"));
        crystalReport.SetDataSource(dt);
        repBankReceipt.ReportSource = crystalReport;
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

  
    #endregion
    #endregion

    #region Methods

    //#region SetView
    //public void SetView()
    //{
    //    if (Request.QueryString["a"] != null)
    //    {
    //        if (Request.QueryString["a"] == "a")
    //        {
    //            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
    //            if (page == "bankreceipt.aspx")
    //            {
                   
    //                PnlAddBankR.Visible = true;
    //                Pnldate.Visible = false;
    //                PnlBankRDetails.Visible = false;

    //                btn_Save.Visible = true;
    //                btnDelete.Visible = false;
    //                filter.Visible = false;
    //                txtbankcode.Focus();
    //                txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
    //            }
    //        }
    //        else
    //            if (Request.QueryString["a"] == "v")
    //            {
    //                pageName.InnerHtml = "Bank Payment Checklist";
    //                PnlAddBankR.Visible = false;
    //                Pnldate.Visible = true;
    //                PnlBankRDetails.Visible = false;

    //                btn_Save.Visible = false;
    //                btnDelete.Visible = false;
    //                filter.Visible = true;
    //            }
    //    }
    //}
    //#endregion

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

   

    #endregion

}
