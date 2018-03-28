
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
using Others;
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
            ViewState["Bkwise"] = null;
            RdbtnSelect.Focus();
            //lblbk.Visible = false;
            //txtbkcod.Visible = false;
            lblbkt.Visible = false;
            txtbktype.Visible = false;
            pnlZone.Visible = false;
            rdobtn.Visible = false;
            //txtfromDate.Text = Session["FromDate"].ToString();
            //txttoDate.Text = Session["ToDate"].ToString();
            Bind_DDL_SuperDuperZone();
           

                        
        }
        if (IsPostBack)
        {
            if (ViewState["Bkwise"] != null && rdobtn.SelectedValue == "Quantitywise")
            {
                getdata((DataTable)ViewState["Bkwise"]);
            }
            if (ViewState["Bkwise"] != null && rdobtn.SelectedValue == "AmountWise")
            {
                BindData();
            }
            //txtfromDate.Text = Session["FromDate"].ToString();
            //txttoDate.Text = Session["ToDate"].ToString();
        }
    }
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
            if (RdbtnSelect.SelectedValue == "Bookwise")
            {
                string Bookcode = txtbkcod.Text.ToString().Split(':')[0].Trim();
                DataTable dt = new DataTable();
                dt = Books.Get_Bookwise_summary(fdate, tdate, Bookcode, Convert.ToInt32(strFY)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ViewState["Bkwise"] = dt;
                    getdata(dt);
                    //ReportDocument CR = new ReportDocument();
                    //CR.Load(Server.MapPath("Report/Bookwise_Summary.rpt"));
                    //CrptBookwiseSummary.SeparatePages = false;
                    //CR.SetDataSource(dt);
                    //CrptBookwiseSummary.ReportSource = CR;
                }
                else
                {
                    MessageBox("No Records Found");
                    txtfromDate.Focus();
                }

                // txtbkcod.Text = "";
                // txtbktype.Text = "";

            }
            if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
                string BookTypecode = txtbktype.Text.ToString().Split(':')[0].Trim();
                DataTable dt1 = new DataTable();
                dt1 = Books.Get_Booktypewise_summary(BookTypecode, fdate, tdate, Convert.ToInt32(strFY)).Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    ViewState["Bkwise"] = dt1;
                    getdata(dt1);
                    //ReportDocument CR = new ReportDocument();
                    //CR.Load(Server.MapPath("Report/Booktypewise_Summary.rpt"));
                    //CrptBookwiseSummary.SeparatePages = false;
                    //CR.SetDataSource(dt1);
                    //CrptBookwiseSummary.ReportSource = CR;

                    //txtbkcod.Text = "";
                    //txtbktype.Text = "";
                }
                else
                {
                    MessageBox("No Records Found");
                    RdbtnSelect.Focus();
                    //  txtbkcod.Text = "";
                    //   txtbktype.Text = "";

                }
            }
        }
       
    }

    public void getdata(DataTable dt1)
    {
        //string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        //string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        //fdate = Convert.ToDateTime(from);
        //tdate = Convert.ToDateTime(To);
        //if (fdate > tdate)
        //{
        //    MessageBox("From Date is Greater than ToDate");
        //    txtfromDate.Focus();
        //}
        if (RdbtnSelect.SelectedValue == "Bookwise")
        {
         
                ReportDocument CR = new ReportDocument();
                CR.Load(Server.MapPath("Report/Bookwise_Summary.rpt"));
                CrptBookwiseSummary.SeparatePages = false;
                CR.SetDataSource(dt1);
                CrptBookwiseSummary.ReportSource = CR;
           

        }
        else if (RdbtnSelect.SelectedValue == "BookTypewise")
        {
            
                ReportDocument CR = new ReportDocument();
                CR.Load(Server.MapPath("Report/Booktypewise_Summary.rpt"));
                CrptBookwiseSummary.SeparatePages = false;
                CR.SetDataSource(dt1);
                CrptBookwiseSummary.ReportSource = CR;

                // txtbkcod.Text = "";
                // txtbktype.Text = "";
            
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
            ViewState["Bkwise"] = null;
            //getdata((DataTable)ViewState["Bkwise"]);
            lblbk.Visible = true;
            txtbkcod.Visible = true;

            lblbkt.Visible = false;
            txtbktype.Visible = false;
            txtbktype.Text = "";
            pnlZone.Visible = false;
            rdobtn.Visible = false;

        }
        if (RdbtnSelect.SelectedValue == "BookTypewise")
        {
            rdobtn.Visible = true;
            lblbkt.Visible = true;
            txtbktype.Visible = true;
            lblbk.Visible = false;
            txtbkcod.Visible = false;
        }

      //  txtbkcod.Text = "";
      //  txtbktype.Text = "";
        //txtfromDate.Text = "";
       // txttoDate.Text = "";
    }
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_SuperZone();
    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_Zone();
    }
    
    #region Bind Data
    public void Bind_DDL_SuperDuperZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));

        DDLSuperZone.Focus();
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.Items.Clear();
        if (ddlSDZone.SelectedIndex != 0)
        {
            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            DDLSuperZone.Focus();


        }
        DDLZone.Items.Clear();
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.Items.Clear();
        if (DDLSuperZone.SelectedIndex != 0)
        {
            DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
            DDLZone.DataBind();
            DDLZone.Items.Insert(0, new ListItem("-All Zone-", "0"));
            DDLZone.Focus();

        }
        
    }


    #endregion

    protected void rdobtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdobtn.SelectedValue == "QuantityWise")
        {
            ViewState["Bkwise"] = null;
            // getdata((DataTable)ViewState["Bkwise"]);
            pnlZone.Visible = false;
            btnget.Visible = true;
     
        }
        if (rdobtn.SelectedValue == "AmountWise")
        {
            ViewState["Bkwise"] = null;
            // getdata((DataTable)ViewState["Bkwise"]);
            ViewState["Bkwise"] = null;
            // getdata((DataTable)ViewState["Bkwise"]);
            btnget.Visible = false;
            pnlZone.Visible = true;
        }
    }

    protected void btnAmoutWise_Click(object sender, EventArgs e)
     {
         BindData();
     }
    public void BindData()
    {
        string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        int szone, zone;
        if (ddlSDZone.SelectedIndex == 0)
        {
            szone = zone = 0;
        }
        else
            if (DDLSuperZone.SelectedIndex == 0)
            {
                szone = Convert.ToInt32(DDLSuperZone.SelectedValue.ToString());
                zone = 0;
            }
            else
            {
                if (DDLSuperZone.SelectedIndex == -1)
                {
                    szone = 0;
                }
                else
                {
                    szone = Convert.ToInt32(DDLSuperZone.SelectedValue.ToString());
                    
                }
                
                if (DDLZone.SelectedIndex == -1)
                {
                    zone = 0;
                    
                }
                else
                {
                    zone = Convert.ToInt32(DDLZone.SelectedValue.ToString());
                }
            }

        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }
        else
        {
            string BookTypecode = txtbktype.Text.ToString().Split(':')[0].Trim();
            DataSet ds = new DataSet();
            ds = OtherClass.Idv_Chetana_Rep_Booktypewise_A_Report(BookTypecode, fdate, tdate, Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), szone, zone, Convert.ToInt32(strFY));

            //ds = OtherClass.Idv_Chetana_Rep_Booktypewise_A_Report(BookTypecode, fdate, tdate, ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), DDLZone.SelectedValue.ToString(), Convert.ToInt32(strFY));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["Bkwise"] = ds.Tables[0];
                ReportDocument CR = new ReportDocument();
                CR.Load(Server.MapPath("Report/Booktypewise_Amt_Summary.rpt"));
                CrptBookwiseSummary.SeparatePages = true;
                CR.SetDataSource(ds.Tables[0]);
                CrptBookwiseSummary.ReportSource = CR;

                //                txtbkcod.Text = "";
                // txtbktype.Text = "";
            }
            else
            {
                MessageBox("No Records Found");
                RdbtnSelect.Focus();
                //  txtbkcod.Text = "";
                //   txtbktype.Text = "";

            }

        }
 
    }
}