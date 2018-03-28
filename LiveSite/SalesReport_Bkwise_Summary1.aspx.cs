
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
using Idv.Chetana.Common;
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class SalesReport_Bkwise_Summary : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;

    string strChetanaCompanyName = "cppl";
    string strFY;

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
            RdbtnSelect.Focus();
            //lblbk.Visible = false;
            //txtbkcod.Visible = false;

            lblbkt.Visible = false;
            txtbktype.Visible = false;

            if (RdbtnSelect.SelectedValue == "Bookwise")
            {
                txtbkcod.Focus();

                lblbk.Visible = true;
                txtbkcod.Visible = true;

                lblbkt.Visible = false;
                txtbktype.Visible = false;

                if (txtfromDate.Text != "" || txttoDate.Text != "")
                {
                    getdata();
                }
            }
            if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
                txtbktype.Focus();

                lblbk.Visible = false;
                txtbkcod.Visible = false;

                lblbkt.Visible = true;
                txtbktype.Visible = true;

                if (txtfromDate.Text != "" || txttoDate.Text != "")
                {
                    getdata();
                }
            }
            
        }
        if (IsPostBack)
        {
            if (txtfromDate.Text != "" || txttoDate.Text != "")
            {
                getdata();
            }

        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        getdata();
    }

    public void getdata()
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
            if (RdbtnSelect.SelectedValue == "Bookwise")
            {
                string Bookcode = txtbkcod.Text.ToString().Split(':')[0].Trim();
                DataTable dt = new DataTable();
                dt = Books.Get_Bookwise_summary(fdate, tdate, Bookcode, Convert.ToInt32(strFY)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/Bookwise_Summary.rpt"));
                    CrptBookwiseSummary.SeparatePages = false;
                    CR.SetDataSource(dt);
                    CrptBookwiseSummary.ReportSource = CR;
                }
                else
                {
                    MessageBox("No Records Found");
                    txtfromDate.Focus();
                }

                txtbkcod.Text = "";
                txtbktype.Text = "";
                
            }
            if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
                string BookTypecode = txtbktype.Text.ToString().Split(':')[0].Trim();
                DataTable dt1 = new DataTable();
                dt1 = Books.Get_Booktypewise_summary(BookTypecode, fdate, tdate, Convert.ToInt32(strFY)).Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/Booktypewise_Summary.rpt"));
                    CrptBookwiseSummary.SeparatePages = false;
                    CR.SetDataSource(dt1);
                    CrptBookwiseSummary.ReportSource = CR;

                    txtbkcod.Text = "";
                    txtbktype.Text = "";
                }
                else
                {
                    if (txtbktype.Text == "")
                    {
                        MessageBox("Enter Book Type");
                        txtbktype.Focus();
                    }
                    else
                    {
                        MessageBox("No Records Found");
                        RdbtnSelect.Focus();

                        txtbkcod.Text = "";
                        txtbktype.Text = "";
                    }
                }
            }
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

    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "Bookwise")
        {
            lblbk.Visible = true;
            txtbkcod.Visible = true;

            lblbkt.Visible = false;
            txtbktype.Visible = false;
        }
        if (RdbtnSelect.SelectedValue == "BookTypewise")
        {
            lblbk.Visible = false;
            txtbkcod.Visible = false;

            lblbkt.Visible = true;
            txtbktype.Visible = true;
        }

        txtbkcod.Text = "";
        txtbktype.Text = "";
        txtfromDate.Text = "";
        txttoDate.Text = "";
    }
}