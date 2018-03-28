using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExpReport : System.Web.UI.Page
{
    string BankCode;
    DateTime fdate;
    DateTime tdate;

    string strChetanaCompanyName = "cppl";
    string strFY;
    string Flag = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {
             txtfromDate.Text = "01/04/201" + strFY + "";
             txttoDate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1) + "";
            txtBank.Focus();
            Session["Data"] = null;


        }

        if (txtfromDate.Text == "" || txttoDate.Text == "")
        {

        }
        else
        {

            FillReport((DataView)Session["Data"]);
            ShowDetails();
        }

    }


    public void ShowDetails()
    {
        string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);

        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }
        else
        {


            DataSet ds = new DataSet();
            ds = Bank.Get_Bank_Checklist(txtBank.Text.ToString().Trim(), fdate, tdate, Convert.ToInt32(strFY), "Cash");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (txtsubgroup.Text.Trim() != "")
                //{
                //    DataView dv = new DataView(ds.Tables[0]);
                //    dv.RowFilter = "GR_HEAD = '" + txtsubgroup.Text.Trim() + "'";
                //    Session["Data"] = dv;
                //    FillReport(dv);
                //}
                //else
                //{

                DataView dv1 = new DataView(ds.Tables[0]);
                dv1.RowFilter = "createdby='" + ConfigurationManager.AppSettings["accountEMP"].ToString() + "'";
                if (dv1.Count > 0)
                {
                    Session["Data"] = dv1;
                    FillReport(dv1);
                }
                else
                {

                    MessageBox("Records Not Available ");
                }
                //}

                //DataView dv = new DataView(ds.Tables[0]);

                //ReportDocument rd = new ReportDocument();
                //rd.Load(Server.MapPath("Report/BankCheckList.rpt"));
                //rd.Database.Tables[0].SetDataSource(dv);
                //Bankchecklist.ReportSource = rd;

                //gvBankLedger.DataSource = ActualInvoiceDetails.Get_Bank_Ledger(txtBank.Text.ToString().Trim(), from, To).Tables[0];
                // gvBankLedger.DataBind();
                //if (gvBankLedger.Rows.Count <= 0)
                //{
                //    MessageBox("No Record Found");
                //}
            }
            else
            {

                MessageBox("Records Not Available ");
            }

        }

    }

    public void FillReport(DataView dt)
    {
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("/Report/ExpReport.rpt"));
        rd.Database.Tables[0].SetDataSource(dt);
        Bankchecklist.ReportSource = rd;
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }

    protected void txtBank_TextChanged(object sender, EventArgs e)
    {
        BankCode = txtBank.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();
        dt = Idv.Chetana.BAL.DCMaster.Get_Name(BankCode, "Bank").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtBank.Text = BankCode;
            lblBankName.Text = Convert.ToString(dt.Rows[0]["BankName"]);
            txtfromDate.Focus();

        }
        else
        {
            lblBankName.Text = "All Banks";
            txtBank.Focus();
            txtBank.Text = "";
        }
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Cash")
        {
            pnlbanktext.Visible = false;
        }
        else
        {
            pnlbanktext.Visible = true;
        }
    }
}
