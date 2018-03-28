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

public partial class PrintDN : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;
    int DocNo;
    string sdocno;
    string strChetanaCompanyName = "cppl";
    string strFY;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        //{
        //    string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
        //    if (Session["Role"] != null)
        //    {
        //        if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
        //        {
        //            Response.Redirect("dashboard.aspx");
        //        }
        //    }
        //}

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

        Txtdocno.Focus();
        //if (txtfromDate.Text != "" || txttoDate.Text != "")
        //{
        //    getdata();
        //}
        if (Txtdocno.Text != "")
        {
            getdata();
        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        getdata();
    }

   

    public void getdata()
    {
        sdocno = Txtdocno.Text.Trim();
        DocNo = Convert.ToInt32(sdocno);
        //string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        //string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        //fdate = Convert.ToDateTime(from);
        //tdate = Convert.ToDateTime(To);
        //if (fdate > tdate)
        //{
        //    MessageBox("From Date is Greater than ToDate");
        //    txtfromDate.Focus();
        //}
        //else

        DataTable dt = new DataTable();
        //dt = Books.Get_Bookwise_summary(fdate, tdate).Tables[0];
        dt = DNDetail.RepGetDN(DocNo, Convert.ToInt32(strFY)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            ReportDocument CR = new ReportDocument();
            CR.Load(Server.MapPath("Report/PrintDN.rpt"));
            CrptDN.SeparatePages = false;
            CR.SetDataSource(dt);
            CrptDN.ReportSource = CR;
        }
        else
        {
            MessageBox("No Records Found");
            Txtdocno.Focus();
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
    #endregion

    protected void Txtdocno_TextChanged(object sender, EventArgs e)
    {

    }
}
