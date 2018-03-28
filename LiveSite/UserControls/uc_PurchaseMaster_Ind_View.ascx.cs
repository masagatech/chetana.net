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

public partial class UserControls_uc_PurchaseMaster_Ind_View : System.Web.UI.UserControl
{
    #region Variables

    string strChetanaCompanyName = "cppl";
    string strFY = "0";


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
       gedData();
            }
            else
            {
                Session.Clear();
            }
        }

    }

    protected void btnget_Click(object sender, EventArgs e)
    {
       gedData();
 
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

public void gedData()
{
  try
        {
            string FromDate1 = "01/01/1999";
            string ToDate1 = "03/31/2099";
            if (txtfromdate.Text == "" || txttodate.Text == "")
            {
                FromDate1 = "01/01/1999";
                ToDate1 = "03/31/2099";
            }
            else
            {
                FromDate1 = txtfromdate.Text.Split('/')[1] + "/" + txtfromdate.Text.Split('/')[0] + "/" + txtfromdate.Text.Split('/')[2];
                ToDate1 = txttodate.Text.Split('/')[1] + "/" + txttodate.Text.Split('/')[0] + "/" + txttodate.Text.Split('/')[2];
            }


            DateTime FromDate = Convert.ToDateTime(FromDate1);
            DateTime ToDate = Convert.ToDateTime(ToDate1);
            if (txtinvoice.Text.Trim() == "")
            { txtinvoice.Text = "0"; }

            int InvoiceNo = Convert.ToInt32(txtinvoice.Text.Trim());
            
            DataTable dt = new DataTable();
            dt = PurchaseMaster.Get_PurchaseDetails(InvoiceNo, FromDate, ToDate
              ,Convert.ToInt32(strFY) , "INDIVIDUAL", 0, 0).Tables[0];
            ReportDocument crystalReport = new ReportDocument();
           
            if (dt.Rows.Count != 0)
            {
                crystalReport.Load(Server.MapPath("Report/Purchase_Details.rpt"));
                crystalReport.SetDataSource(dt);
                repPurchaseMasterView.ReportSource = crystalReport;
                }
            else
            {
                MessageBox("No Record found");
                txtfromdate.Focus();
                txtfromdate.Text = "";
                txttodate.Text = "";

            }
            txtfromdate.Focus();
        }
        catch (Exception ex)
        {

            MessageBox(ex.Message + "(No Record found)");
        }

}

}
