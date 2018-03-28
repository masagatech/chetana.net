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
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;

public partial class CustomerWiseReport : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
            if (Session["Role"] != null)
            {
                if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
                {
                    Response.Redirect("dashboard.aspx");
                }

            }
        }
        txtcustomer.Focus();
        fillreport();

    }
    protected void btnget_Click(object sender, EventArgs e)
    {

        fillreport();
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


    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt1 = new DataTable();
        dt1 = Specimen.Get_Name(CustCode, "Customer").Tables[0];
        if (dt1.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
            txtfromDate.Focus();

            //   Bind_DDL_Transport();
        }


        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
    }

    private void fillreport()
    {
        if (txtfromDate.Text != "" && txttoDate.Text != "" && txtcustomer.Text != "")
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
                try
                {
                    DataTable dt = new DataTable();
                    dt = Specimen.Get_SpecimenDetailsForInvoice_Customerwise((txtcustomer.Text), Convert.ToDateTime(from), Convert.ToDateTime(To)).Tables[0];
                    // dt = Specimen.Get_SpecimenDetailsForInvoice().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ReportDocument crystalReport = new ReportDocument();
                        crystalReport.Load(Server.MapPath("Report/CustomerWiseReport.rpt"));
                        crystalReport.SetDataSource(dt);
                        crtcustomer.ReportSource = crystalReport;
                    }
                    else
                    {
                        MessageBox("Records Not Found");
                        txtcustomer.Focus();
                    }
                }
                catch { }
            }
        }
    }
}
