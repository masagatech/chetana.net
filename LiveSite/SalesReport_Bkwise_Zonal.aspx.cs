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

public partial class SalesReport_Bkwise_Zonal : System.Web.UI.Page
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
            BindSuperZone();
            RdbtnSelect.Focus();

            //lblbk.Visible = false;
            //txtbkcod.Visible = false;

            lblbkt.Visible = false;
            txtbktype.Visible = false;

           
        }
        if (IsPostBack)
        {

            if (RdbtnSelect.SelectedValue == "Bookwise")
            {
                DDLsuperzone.Focus();

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
                DDLsuperzone.Focus();

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
        int SupID = Convert.ToInt32(DDLsuperzone.SelectedValue);

        if (DDLsuperzone.SelectedIndex == 0)
        {
            MessageBox("Select SuperZone");
            DDLsuperzone.Focus();
        }
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
                dt = Books.Get_Bookwise_Zonal(Convert.ToInt32(DDLsuperzone.SelectedValue), fdate, tdate, Bookcode, Convert.ToInt32(DDLzone.SelectedValue), Convert.ToInt32(strFY)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/Bookwise_Zonal.rpt"));
                   
                    CR.SetDataSource(dt);
                    CrptBkwiseZonal.ReportSource = CR;
                }
                else
                {
                    MessageBox("No Records Found");
                    DDLsuperzone.Focus();
                }
              //  txtbkcod.Text = "";
              //  txtbktype.Text = "";
              //  DDLsuperzone.SelectedIndex = 0;
              //  DDLzone.Items.Clear();
             //  DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
            }
            if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
                string BookTypecode = txtbktype.Text.ToString().Split(':')[0].Trim();
                DataTable dt1 = new DataTable();
                dt1 = Books.Get_Booktypewise_Zonal(Convert.ToInt32(DDLsuperzone.SelectedValue), fdate, tdate, BookTypecode, Convert.ToInt32(DDLzone.SelectedValue), Convert.ToInt32(strFY)).Tables[0];

                if (dt1.Rows.Count > 0)
                {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/Booktypewise_Zonal.rpt"));
                   
                    CR.SetDataSource(dt1);
                    CrptBkwiseZonal.ReportSource = CR;

                   // txtbkcod.Text = "";
                  //  txtbktype.Text = "";
                  //  DDLsuperzone.SelectedIndex = 0;
                  //  DDLzone.Items.Clear();
                   // DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
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

                     //   txtbkcod.Text = "";
                     //   txtbktype.Text = "";
                    //    DDLsuperzone.SelectedIndex = 0;
                    //    DDLzone.Items.Clear();
                     //   DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
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

    #region Binddata Method
    public void BindSuperZone()
    {
        DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
        DDLsuperzone.DataBind();
        DDLsuperzone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLzone.Items.Clear();
        DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    
    public void BindZone_SuperZone()
    {
        DDLzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLsuperzone.SelectedValue.ToString()), "Zone");
        DDLzone.DataBind();
        DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    #endregion

    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "Bookwise")
        {
            DDLsuperzone.Focus();

            lblbk.Visible = true;
            txtbkcod.Visible = true;

            lblbkt.Visible = false;
            txtbktype.Visible = false;
        }
        if (RdbtnSelect.SelectedValue == "BookTypewise")
        {
            DDLsuperzone.Focus();

            lblbk.Visible = false;
            txtbkcod.Visible = false;

            lblbkt.Visible = true;
            txtbktype.Visible = true;
        }

        txtbkcod.Text = "";
        txtbktype.Text = "";
        txtfromDate.Text = "";
        txttoDate.Text = "";
        DDLsuperzone.SelectedIndex =0;
        DDLzone.Items.Clear();
        DDLzone.Items.Insert(0, new ListItem("-Select Zone-", "0"));                
    }
    protected void DDLzone_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void DDLsuperzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLsuperzone.SelectedIndex == 0)
        {
            DDLsuperzone.Focus();
            BindSuperZone();
        }
        else
        {
            BindZone_SuperZone();
            DDLzone.Focus();
        }
    }
}