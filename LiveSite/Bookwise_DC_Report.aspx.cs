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
using Others;
using Idv.Chetana.Common;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
#endregion
public partial class Bookwise_DC_Report : System.Web.UI.Page
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
        }
             
            if (IsPostBack)
            {
		 if (RdbtnSelect.SelectedValue == "BookTypewise")
            {

		if (Convert.ToInt32(ddlSDZone.SelectedValue) == 0 || txtbktype.Text==""||txtfromDate.Text==""||txttoDate.Text=="")
                {

                }
                else
                {
                    Bind();
                }
	    }
	    else 
	    {
		if (Convert.ToInt32(ddlSDZone.SelectedValue) == 0 || txtbkcod.Text==""||txtfromDate.Text==""||txttoDate.Text=="")
                {

                }
                else
                {
                    Bind();
                }
	    }
                
            }
        
        if (!Page.IsPostBack)
        {
            GetDates();
            ddlSDZone.Focus();
            Bind_DDl_SDZone();
            ViewState["Bkwise"] = null;
            RdbtnSelect.Focus();
            //lblbk.Visible = false;
            //txtbkcod.Visible = false;

            lblbkt.Visible = false;
            txtbktype.Visible = false;
        }
        txtbkcod.Focus();
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
    public void GetDates()
    {
        txtfromDate.Text = Session["FromDate"].ToString();
        txttoDate.Text = Session["ToDate"].ToString();

        //DataSet ds = OtherClass.GetFY(Convert.ToInt32(strFY));
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    int Fyear, Tyear;
        //    DataRow dr = dt.Rows[0];
        //    Fyear = Convert.ToInt32(dr[0].ToString());
        //    Tyear = Convert.ToInt32(dr[1].ToString());
        //    txtfromDate.Text = "01/04/" + Fyear.ToString();
        //    txttoDate.Text = "31/03/" + Tyear.ToString();
        //}
    }

    public void Bind()
    {
	
        //if (Convert.ToInt32(ddlSDZone.SelectedValue) <= 0)
        //{
        //    MessageBox("Super Duper zone");
        //}

        //string Bookcode = txtbkcod.Text.ToString().Split(':')[0].Trim();
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
                DataSet ds = new DataSet();
                ds = OtherClass.Get_Bookwise_DC_Rep1(Bookcode, fdate, tdate, Convert.ToInt32(ddlSDZone.SelectedValue), Convert.ToInt32(DDLSuperZone.SelectedValue));
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    BindReport(dt);
                    //ReportDocument CR = new ReportDocument();
                    //CR.Load(Server.MapPath("Report/Bookwise_DC_Report.rpt"));
                    //CR.SetDataSource(ds.Tables[0]);
                    //cryBookwise.ReportSource = CR;
                }
                else
                {
                    MessageBox("Records Not Found");
                }
            }
            if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
                string BookType = txtbktype.Text.ToString().Split(':')[0].Trim();
                DataTable dt1 = new DataTable();
                DataSet ds = new DataSet();
                ds = OtherClass.Get_Booktypewise_DC_Rep1(BookType, fdate, tdate, Convert.ToInt32(ddlSDZone.SelectedValue), Convert.ToInt32(DDLSuperZone.SelectedValue));
                dt1 = ds.Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    //ViewState["Bkwise"] = dt1;
                    BindReport(dt1);
                }
                else
                {
                    MessageBox("Records Not Found"); 
                }

            }
        }
    }
    public void BindReport(DataTable dt1)
    {
        if (RdbtnSelect.SelectedValue == "Bookwise")
        {
 
            ReportDocument CR = new ReportDocument();
            CR.Load(Server.MapPath("Report/Bookwise_DC_Report.rpt"));
            CR.SetDataSource(dt1);
            cryBookwise.ReportSource = CR;


        }
        else if (RdbtnSelect.SelectedValue == "BookTypewise")
        {

            ReportDocument CR = new ReportDocument();
            CR.Load(Server.MapPath("Report/Booktypewise_DC_Report.rpt"));
            CR.SetDataSource(dt1);
            cryBookwise.ReportSource = CR;

            // txtbkcod.Text = "";
            // txtbktype.Text = "";

        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "Bookwise")
        {
            ViewState["Bkwise"] = null;
            //getdata((DataTable)ViewState["Bkwise"]);
            lblbk.Visible = true;
            txtbkcod.Visible = true;

            lblbkt.Visible = false;
            txtbktype.Visible = false;
            txtbktype.Text = "";

        }
        if (RdbtnSelect.SelectedValue == "BookTypewise")
        {
            ViewState["Bkwise"] = null;
            // getdata((DataTable)ViewState["Bkwise"]);
            lblbk.Visible = false;
            txtbkcod.Visible = false;

            lblbkt.Visible = true;
            txtbktype.Visible = true;
            txtbkcod.Text = "";
            txtbktype.Focus();
        }

        //  txtbkcod.Text = "";
        //  txtbktype.Text = "";
        txtfromDate.Text = Session["FromDate"].ToString();
        txttoDate.Text = Session["ToDate"].ToString();
    }
    #region Bind DropDown

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.Items.Clear();
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));


    }
    public void Bind_DDl_SDZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));

    }

    #endregion 
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
   
        if (ddlSDZone.SelectedIndex == 0)
        {
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
   
    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
