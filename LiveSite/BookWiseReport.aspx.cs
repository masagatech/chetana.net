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

public partial class BookWiseReport : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            BindCrist();
        }
        txtfromDate.Focus();
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
        
    }
    public void BindCrist()
    {
        if (txtfromDate.Text != "" || txttoDate.Text != "")
        {
            if (txtBook.Text != "")
            {
                string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
                string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
                string BookCode = txtBook.Text.Split(':')[0].Trim();
                string bookCode2 = "null";
                // bookname = txtBook.Text.Split(':')[2].Trim();
                fdate = Convert.ToDateTime(from);
                tdate = Convert.ToDateTime(To);
                if (fdate > tdate)
                {
                    MessageBox("From Date is Greater than ToDate");
                    txtfromDate.Focus();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = Specimen.Get_SpecimenDetailsForInvoice_Bookwise(bookCode2, BookCode, Convert.ToDateTime(from), Convert.ToDateTime(To)).Tables[0];
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/BookWiseReport.rpt"));
                    cryBookwise.SeparatePages = false;
                    CR.SetDataSource(dt);
                    cryBookwise.ReportSource = CR;
                }
            }
            else
            {
                string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
                string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
                string BookCode = "null";
                //txtBook.Text.Split(':')[0].Trim();
                string bookCode2 = "null";
                // bookname = txtBook.Text.Split(':')[2].Trim();
                fdate = Convert.ToDateTime(from);
                tdate = Convert.ToDateTime(To);
                if (fdate > tdate)
                {
                    MessageBox("From Date is Greater than ToDate");
                    txtfromDate.Focus();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = Specimen.Get_SpecimenDetailsForInvoice_Bookwise(bookCode2, BookCode, Convert.ToDateTime(from), Convert.ToDateTime(To)).Tables[0];
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/BookWiseReport.rpt"));
                    cryBookwise.SeparatePages = false;
                    CR.SetDataSource(dt);
                    cryBookwise.ReportSource = CR;
                }
            }
            
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        BindCrist();
        //string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        //string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
        //string BookCode = txtBook.Text.Split(':')[0].Trim();
        //string bookCode2="";
        //fdate = Convert.ToDateTime(from);
        //tdate = Convert.ToDateTime(To);
        //if (fdate > tdate)
        //{
        //    MessageBox("From Date is Greater than ToDate");
        //    txtfromDate.Focus();
        //}
        //else
        //{

        //    DataTable dt = new DataTable();
        //    dt = Specimen.Get_SpecimenDetailsForInvoice_Bookwise(bookCode2, BookCode, Convert.ToDateTime(from), Convert.ToDateTime(To)).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        ReportDocument CR = new ReportDocument();
        //        CR.Load(Server.MapPath("Report/BookWiseReport.rpt"));
        //        cryBookwise.SeparatePages = false;
        //        CR.SetDataSource(dt);
        //        cryBookwise.ReportSource = CR;
        //    }
        //    else
        //    {
        //        MessageBox("No Records Found");
        //        txtfromDate.Focus();
        //    }
        //}
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


    private void CrystalReportViewer1_Navigate(Object sedner, CrystalDecisions.Web.NavigateEventArgs e){

        
    }

   

    #endregion
    
}
