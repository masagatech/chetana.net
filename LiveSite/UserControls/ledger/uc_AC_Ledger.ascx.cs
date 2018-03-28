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
using Idv.Chetana.BAL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_ODC_ledger_uc_AC_Ledger : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            setdefaultdate();
            txtcustomerid.Focus();
            

        }

        if (txtcustomerid.Text != "" && txtFromDate.Text != "" && txttoDate.Text != "")
        {
            fillReport();
        
        }
    }
    bool IsCustomer = false;
    protected void txtcustomerid_TextChanged(object sender, EventArgs e)
    {

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

    public void fillReport()
    {
        string CustCode = txtcustomerid.Text.ToString();

        DataTable dt = new DataTable();

        if (lblCustName.Text.ToString().Split(':')[0].Trim().ToLower() == CustCode.ToLower())
        {
            CustCode = lblCustName.Text;

        }

        lblCustName.Text = CustCode;



        txtcustomerid.Text = CustCode.ToString().Split(':')[0].Trim();
        if (CustCode.Split('[').Length > 1)
        {
            if (CustCode.Split('[')[1].ToString().Split(']')[0].ToLower() == "cust")
            {
                dt = DCMaster.Get_Name(CustCode.ToString().Split(':')[0].Trim(), "Customer").Tables[0];
                IsCustomer = true;
            }
            else
            {
                IsCustomer = false;
            }
        }

        //= Convert.ToString(dt.Rows[0]["CustName"]);
        txtcustomerid.Focus();
        DataSet ds = new DataSet();

        if (txtFromDate.Text.Split('/').Length > 1 && txttoDate.Text.Split('/').Length > 1)
        {

            try
            {
                string FROMdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
                string tOdate = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];

                ds = AccountLeadgerDetails.Get_Trial_Balance_Individual(CustCode.ToString().Split(':')[0].Trim(), IsCustomer, Convert.ToDateTime(FROMdate), Convert.ToDateTime(tOdate));

          }
            catch (Exception ex)
            {
                lblCustName.Text = "Date is incorrect";
                txtcustomerid.Text = "";
                txtFromDate.Text = "";
                txttoDate.Text = "";
                totAlAmt1.Visible = false;
                totAlAmt.Visible = false;
                //  gvLedger.DataSource = null;
                //  gvLedger.DataBind();
            }
        }
        if (ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDocument rd = new ReportDocument();
                 rd.Load(Server.MapPath("~/Report/AccountLedger.rpt"));
                rd.SetDataSource(ds.Tables[0]);
                rd.SetParameterValue("IsPrint", Convert.ToBoolean(IsPrint.Checked));
               
                accountingledger.ReportSource = rd;
                // gvLedger.DataSource = ds;
                totAlAmt1.Visible = true;
                totAlAmt.Visible = true;
                Button1.Visible = true;
                btnPrint.Visible = true;
                lbloutstndamt.Text = ds.Tables[1].Rows[0]["Closin_bal"].ToString();
                lblopbal1.Text = ds.Tables[1].Rows[0]["Closin_bal"].ToString();



            }
            else
            {
                //gvLedger.DataSource = null;
                totAlAmt1.Visible = false;
                totAlAmt.Visible = false;
                MessageBox("No Records Found");
                Button1.Visible = false;
                btnPrint.Visible = false;
                lbloutstndamt.Text = "0";
                lblopbal1.Text = "0";
            }







            //{
            //    lblCustName.Text = "";
            //    DataSet ds1 = new DataSet();
            //    ds1 = AccountLeadgerDetails.Get_Trial_Balance_Individual(CustCode, IsCustomer, Convert.ToDateTime(txtFromDate.Text.Trim()), Convert.ToDateTime(txttoDate.Text.Trim()));
            //    gvLedger.DataSource = ds1;
            //    gvLedger.DataBind();
            //}
        }


        else
        {
            // gvLedger.DataSource = null;
            totAlAmt1.Visible = false;
            totAlAmt.Visible = false;
            MessageBox("No Records Found");
            Button1.Visible = false;
            btnPrint.Visible = false;
            lbloutstndamt.Text = "0";
            lblopbal1.Text = "0";
            txtcustomerid.Focus();

        }
    
    }



    #region Get Button Click event

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        
       // gvLedger.DataBind();
    }

    #endregion

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintAccountingLedger.aspx?d=" + txtcustomerid.Text.Trim() + "&f=" + txtFromDate.Text + "&t=" + txttoDate.Text + "')", true);
    }
    public void setdefaultdate()
    {
        txtFromDate.Text = Session["FromDate"].ToString();
        txttoDate.Text = Session["ToDate"].ToString(); 
        //DateTime.Now.ToString("dd/MM/yyyy");
    
    }

}