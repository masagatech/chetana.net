using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Add Namespace
using System.Data;
using Other_Z;
using CrystalDecisions.CrystalReports.Engine;

public partial class SpecimanLedger : System.Web.UI.Page
{
    #region ALl Veriable Declaretion
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion

    #region Page Load Session Validation
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
                    txtFromDate.Text = "01/04/201" + Convert.ToInt32(strFY);
                    txtToDate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1);
                }
                txtMRCode.Focus();
            }
        }
        else
        {
            Session.Clear();
        }
        if (Page.IsPostBack)
        {
            if (txtMRCode.Text != "")
            {
                PrintData();
            }
        }
    }
    #endregion

    protected void rbtSalesman_CheckedChanged(object sender, EventArgs e)
    {
        lblbookset.Visible = false;
        DDLSelectSet.Visible = false;
        txtMRCode.Visible = true;
        lblmrcode.Visible = true;
        SalesmanLedger.Visible = false;
        txtMRCode.Focus();
    }

    protected void rbtbookset_CheckedChanged(object sender, EventArgs e)
    {
        txtMRCode.Visible = false;
        lblmrcode.Visible = false;
        lblbookset.Visible = true;
        txtMRCode.Text = "";
        SalesmanLedger.Visible = false;
        DDLSelectSet.Visible = true;
        DDLSelectSet.Focus();
        
    }

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Print Data
    private void PrintData()
    {
        string Fromdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string Todate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        ReportDocument rd = new ReportDocument();
        if (rbtSalesman.Checked == true)
        {
            if (txtMRCode.Text != "")
            {
                DataTable dt = OtherBAL.ReportSpecimanLedger(txtMRCode.Text.Split(':')[0].ToString(), Convert.ToInt32(strFY), "", Fromdate, Todate, chk_AmountWise.Checked == true ? "1" : "0", "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    SalesmanLedger.Visible = true;
                    rd.Load(Server.MapPath("~/Report/SpecimanLedger.rpt"));
                    rd.SetDataSource(dt);
                    if (chk_AmountWise.Checked == true)
                    {
                        rd.SetParameterValue("Header", "Amount Wise Ledger");
                        rd.SetParameterValue("Qty", "Order Amt");
                        rd.SetParameterValue("InvQty", "Inv Amt");
                        rd.SetParameterValue("CNQty", "CN Amt");
                        rd.SetParameterValue("Total", "Speciman Sold");
                    }
                    else
                    {
                        rd.SetParameterValue("Header", "Salesman Ledger");
                        rd.SetParameterValue("Qty", "Ord. Qty");
                        rd.SetParameterValue("InvQty", "Inv. Qty");
                        rd.SetParameterValue("CNQty", "CN Qty");
                        rd.SetParameterValue("Total", "Total Speciman");
                    }
                    rd.SetParameterValue("Saleman", txtMRCode.Text.Split(':')[2]);
                    rd.SetParameterValue("SalemanText", "Saleman Name");
                    rd.SetParameterValue("Fromdate", Fromdate);
                    rd.SetParameterValue("Todate", Todate);
                    SalesmanLedger.ReportSource = rd;
                }
                else
                {
                    MessageBox("Record Not Found");
                    txtMRCode.Focus();
                    return;
                }
            }
        }
        else
        {
            MessageBox("BookSet Wise is in progress");
            rd = null;
            return;
            //Amount Wise
        }
    }
    #endregion

    #region Get Button Click Event
    protected void btn_get_Click(object sender, EventArgs e)
    {
        PrintData();
    }
    #endregion


}