#region NameSpace
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
#endregion

public partial class TotalCNbydt : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;

    string strChetanaCompanyName = "cppl";
    string strFY;

    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
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
            txtfromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            txttoDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Session["CNlist"] = null;

        }
        txtfromDate.Focus();
        //if (IsPostBack)
        //{
        //    if (txtfromDate.Text != "" || txttoDate.Text != "")
        //    {
        //        show();
        //    }
        //}
        if (IsPostBack)
        {
            if (Session["CNlist"] != null)
            {
                show((DataTable)Session["CNlist"]);
               
            }
        }
    }
    #endregion   

    #region Event
    #region Click
    protected void btnget_Click(object sender, EventArgs e)
    {
        string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
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
            dt = CreditNote.GetTotalCN_Bydt(Convert.ToInt32(strFY), fdate, tdate).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Session["CNlist"] = dt;
                show(dt);
            }
            else
            {
                MessageBox("No Records Found");
            }
        }
        //show();
    }
    #endregion
    #endregion

    #region Methods

    public void show(DataTable dt1)
    {
       
            
                ReportDocument CR = new ReportDocument();

                if (rdbselect.SelectedValue == "SuperZone")
                {
                    CR.Load(Server.MapPath("Report/TotalCNbydt.rpt"));
                    CrptTotalCN.SeparatePages = true;
                    CR.SetDataSource(dt1);
                    CrptTotalCN.ReportSource = CR;
                }
                else
                {
                    CR.Load(Server.MapPath("Report/TotalCNbydt_invoicewise.rpt"));
                    CrptTotalCN.SeparatePages = true;
                    CR.SetDataSource(dt1);
                    CrptTotalCN.ReportSource = CR;
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
    #endregion
  
   

}