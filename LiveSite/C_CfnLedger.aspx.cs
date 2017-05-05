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
using Other_Z;
using CrystalDecisions.CrystalReports.Engine;

public partial class C_CfnLedger : System.Web.UI.Page
{
    #region Goloval Veriable
    string strFy;
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
                if (!IsPostBack)
                {
                    strFy = Session["FY"].ToString();
                    setdefaultdate();
                    txtcustomerid.Focus();
                }
                if (txtcustomerid.Text != "" && txtFromDate.Text != "" && txttoDate.Text != "")
                {
                    fillReport();

                }
       
    }
    #endregion

    #region Message Box Method
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

   

    #region Click Get Button Print Report
    public void fillReport()
    {
        bool IsCustomer = false;
        Other_Z.OtherBAL Objbal = new OtherBAL();
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
                //dt = DCMaster.Get_Name(CustCode.ToString().Split(':')[0].Trim(), "Customer").Tables[0];
                IsCustomer = true;
            }
            else
            {
                IsCustomer = false;
            }
        }

        txtcustomerid.Focus();
        DataSet ds = new DataSet();

        if (txtFromDate.Text.Split('/').Length > 1 && txttoDate.Text.Split('/').Length > 1)
        {

            try
            {


                //string FROMdate = txtFromDate.Text;
                //string tOdate = txttoDate.Text;
                string FROMdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
                string tOdate = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];

                ds = Objbal.Idv_Chetana_C_AccountingLedger(CustCode.ToString().Split(':')[0].Trim(), Convert.ToDateTime(FROMdate), Convert.ToDateTime(tOdate), "", Convert.ToInt32(Session["FY"]));
                //ds = Objbal.Idv_Chetana_C_AccountingLedger("T05",Convert.ToDateTime("01/04/2015"),Convert.ToDateTime("31/03/2016"), "",Convert.ToInt32(2));
            }
            catch (Exception ex)
            {
                lblCustName.Text = "Date is incorrect";
                txtcustomerid.Text = "";
                txtFromDate.Text = "";
                txttoDate.Text = "";
                totAlAmt1.Visible = false;
                totAlAmt.Visible = false;
            }
        }
        if (ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("~/CNF/report/CNFLedger.rpt"));
                rd.SetDataSource(ds.Tables[0]);
                rd.SetParameterValue("IsPrint", Convert.ToBoolean(IsPrint.Checked));

                Cnfaccountingledger.ReportSource = rd;
                totAlAmt1.Visible = true;
                totAlAmt.Visible = true;
                Button1.Visible = true;
                btnPrint.Visible = true;
                //lbloutstndamt.Text = ds.Tables[1].Rows[0]["Closin_bal"].ToString();
                //lblopbal1.Text = ds.Tables[1].Rows[0]["Closin_bal"].ToString();
            }
            else
            {
                totAlAmt1.Visible = false;
                totAlAmt.Visible = false;
                MessageBox("No Records Found");
                Button1.Visible = false;
                btnPrint.Visible = false;
                lbloutstndamt.Text = "0";
                lblopbal1.Text = "0";
            }
        }
        else
        {
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
    #endregion

    protected void btnPrint_Click(object sender, EventArgs e)
    {
 
    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
 
    }

    #region Set date FromDate To ToDate
    public void setdefaultdate()
    {
        txtFromDate.Text = Session["FromDate"].ToString();
        txttoDate.Text = Session["ToDate"].ToString();
    }
    #endregion
}
