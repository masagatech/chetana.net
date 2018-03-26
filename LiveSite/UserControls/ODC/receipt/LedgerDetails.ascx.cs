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

public partial class UserControls_ODC_receipt_LedgerDetails : System.Web.UI.UserControl
{
    #region Varables

    static decimal cramount = 0;
    static decimal damount = 0;
    static decimal totalamount = 0;
    static decimal cnamount = 0;
    static decimal balamount = 0;
    static decimal temp;
    decimal frieght = 0;
    decimal tax = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    DateTime FromDate;
    DateTime ToDate;
    static string flag4;
    static string flag1;
    static string flag2;
    static string flag3;
    static DateTime flag5 = Convert.ToDateTime(Func.getMonthInNameDate(DateTime.Now.ToString("dd/MM/yyyy")));
    static DateTime flag6=  Convert.ToDateTime(Func.getMonthInNameDate(DateTime.Now.ToString("dd/MM/yyyy")));

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
        if (!IsPostBack)
        {
            txtcustomerid.Focus();
            DataSet ds1 = new DataSet();
             ds1 = LeadgerDetails.Get_LedgerDetails("CustCode", "All", "fromno", "tono", Convert.ToInt32(strFY));
             
             flag1 = "CustCode";
             flag2 = "All";
             flag3 = "fromno";
             flag4 = "tono";

            // ds1 = null;
            gvLedger.DataSource = ds1;
            gvLedger.DataBind();
            pnlfalse.Visible = true;

        }
    }

    protected void txtcustomerid_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomerid.Text.ToString().Split(':')[0].Trim();
        if (CustCode != "")
        {
            DataTable dt = new DataTable();
            dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

            if (dt.Rows.Count != 0)
            {
                txtcustomerid.Text = CustCode;
                lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                txtcustomerid.Focus();
                DataSet ds = new DataSet();
                ds = LeadgerDetails.Get_LedgerDetails(CustCode, "customer", "fromno", "tono", Convert.ToInt32(strFY));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvLedger.DataSource = ds;
                    gvLedger.DataBind();
                    Button1.Visible = true;
                    btnPrint.Visible = true;
                }
                else
                {
                    gvLedger.DataSource = null;
                    gvLedger.DataBind();
                    MessageBox("No Records Found");
                    Button1.Visible = false;
                    btnPrint.Visible = false;
                    lbloutstndamt.Text = "0";
                    lblopbal1.Text = "0";
                }
            }


            else
            {
                lblCustName.Text = "No such Customer code";
                txtcustomerid.Focus();
                txtcustomerid.Text = "";

            }
        }
        else
        {
            lblCustName.Text = "";
            DataSet ds1 = new DataSet();
            ds1 = LeadgerDetails.Get_LedgerDetails("CustCode", "All", "fromno", "tono", Convert.ToInt32(strFY));
            gvLedger.DataSource = ds1;
            gvLedger.DataBind();
        }
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void loder1(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    #endregion

    protected void gvLedger_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            cramount = 0;
            damount = 0;
            cnamount = 0;
            balamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblche_no");
            damount = damount + Convert.ToDecimal(lbl.Text.Trim());
       //     Label lblamt = (Label)e.Row.FindControl("lbl_Amount");
           // if (lblamt.Text == "-")
       //     {
       //         lblamt.Text = "0";
       //     }
        //    cramount = cramount + Convert.ToDecimal(lblamt.Text.Trim());
        //    Label lblcnoteamt = (Label)e.Row.FindControl("lblCNAmount");
         //   cnamount = cnamount + Convert.ToDecimal(lblcnoteamt.Text.Trim());
         //   Label lblopenbal = (Label)e.Row.FindControl("lblopenbal");
         //   balamount = balamount + Convert.ToDecimal(lblopenbal.Text.Trim());

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotaldebitAmt");
            lbl1.Text = damount.ToString().Trim();
          //  Label lblamt1 = (Label)e.Row.FindControl("lblTotalCreditAmt");
          //  lblamt1.Text = cramount.ToString().Trim();
         //   Label lblcnamt = (Label)e.Row.FindControl("lblTotalCNAmt");
         //   lblcnamt.Text = cnamount.ToString().Trim();
         //   Label lblbalamt = (Label)e.Row.FindControl("lblTotalbalance");
        //    lblbalamt.Text = balamount.ToString().Trim();
            //lblopbal.Text = 

        //    temp = Convert.ToDecimal((balamount + damount) - (cramount + cnamount));
        //    lblopbal1.Text = temp.ToString();
       //     lbloutstndamt.Text = temp.ToString();
        }

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
       // CustCode, "All", "fromno", "tono", Convert.ToInt32(strFY), FromDate, ToDate
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintLedger.aspx?flag1=" + flag1.ToString() + "&flag2=" + flag2.ToString() + "&flag3=" + flag3.ToString() + "&flag4=" + flag4 + "&flag41=" + Convert.ToInt32(strFY) + "&flag5=" + flag5 + "&flag6=" + flag6 + "')", true);
    }

    #region Get Button Click event

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        string CustCode = txtcustomerid.Text.ToString().Split(':')[0].Trim();
        FromDate = Convert.ToDateTime(Func.getMonthInNameDate(txtFromDate.Text.Trim()));
        ToDate = Convert.ToDateTime(Func.getMonthInNameDate(txttoDate.Text.Trim()));
        if (CustCode != "")
        {
            try
            {
                

                DataTable dt = new DataTable();
                dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];



                if (dt.Rows.Count != 0)
                {
                    txtcustomerid.Text = CustCode;
                    lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                    txtcustomerid.Focus();
                    DataSet ds = new DataSet();
                    ds = LeadgerDetails.Get_LedgerDetails(CustCode, "customer", "fromno", "tono", Convert.ToInt32(strFY), FromDate, ToDate);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvLedger.DataSource = ds;
                        gvLedger.DataBind();
                        Button1.Visible = true;
                        btnPrint.Visible = true;

                        flag1 = CustCode;
                        flag2 = "customer";
                        flag3 = "fromno";
                        flag4 = "tono";
                        flag5 = FromDate;
                        flag6 = ToDate;

                    }
                    else
                    {
                        gvLedger.DataSource = null;
                        gvLedger.DataBind();
                        MessageBox("No Records Found");
                        Button1.Visible = false;
                        btnPrint.Visible = false;
                        lbloutstndamt.Text = "0";
                        lblopbal1.Text = "0";
                    }
                }


                else
                {
                    lblCustName.Text = "No such Customer code";
                    txtcustomerid.Focus();
                    txtcustomerid.Text = "";

                }
            }
            catch (Exception ex)
            {


            }
        }
        else
        {
            lblCustName.Text = "";
            DataSet ds1 = new DataSet();
            ds1 = LeadgerDetails.Get_LedgerDetails(CustCode, "All", "fromno", "tono", Convert.ToInt32(strFY), FromDate, ToDate);
            gvLedger.DataSource = ds1;
            gvLedger.DataBind();
            flag1 = CustCode;
            flag2 = "All";
            flag3 = "fromno";
            flag4 = "tono";
            flag5 = FromDate;
            flag6 = ToDate;
        }
    }

    #endregion
}
