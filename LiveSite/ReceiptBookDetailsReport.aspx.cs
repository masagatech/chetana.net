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
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using Others;

public partial class ReceiptBookDetailsReport : System.Web.UI.Page
{
    int ActualReceiptNo;
    int IDNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session["StockLedger"] = null;
        }
        if (IsPostBack)
        {
            Bind();
        }
        txtReceiptBook.Focus();
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        Bind();
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
    #endregion
    public void Bind()
    {
        if (rdorecnumwise.Checked)
        {
            if (txtReceiptBook.Text.Trim() != "")
            {
                ActualReceiptNo = Convert.ToInt32(txtReceiptBook.Text.Trim());

                DataTable dt = new DataTable();

                dt = ReciptBookDetails.Idv_Chetana_Get_ReceiptBookDetails_Report(ActualReceiptNo).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Server.MapPath("Report/ReceiptBookDetails.rpt"));
                    rd.SetDataSource(dt);
                    ReceiptDetailsReport.ReportSource = rd;

                }

               else
                {
                    ActualReceiptNo = Convert.ToInt32("0");
                    MessageBox("No Record Found");
                    txtReceiptBook.Focus();
                    // txtReceiptBook.Text = "";
                }
            }
            else
            {
                MessageBox("Enter Receipt BookID");
            }
        }
        else
        {
            if (txtFromDate.Text != ""  && txtTo.Text  != "" )
            {
                //TODO: check whether to Date is bigger than from date or not
                DataSet ds = new DataSet();
                ds = OtherClass.Idv_Chetana_Report_ReceiptDatewise(Convert.ToDateTime(txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2]),
                       Convert.ToDateTime(txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]));

                ReportDocument rd = new ReportDocument();
                //DateTime t=Convert.ToDateTime(txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2]);
                rd.Load(Server.MapPath("Report/ReceiptBookDatewise.rpt"));
                rd.SetDataSource(ds.Tables[0]);
                ReceiptDetailsReport.ReportSource = rd;
            }
            else
            {
                MessageBox("Enter proper From Date / To Date");
            }
                   
        }

    }
     
}
  
