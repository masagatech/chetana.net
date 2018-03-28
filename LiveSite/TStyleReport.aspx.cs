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

using Idv.Chetana.BAL;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;


public partial class TStyleReport : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
            if (Session["Role"] != null)
            {
                if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
                {
                    //Response.Redirect("dashboard.aspx");
                }

            }
            if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
            {
                if (Session["FY"] != "" || Session["FY"] != null)
                {
                    strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                    strFY = Session["FY"].ToString();
                }
                else
                {
                    Session.Clear();
                }
            }
        }
        if (!Page.IsPostBack)
        {
            Session["tstlData"] = null;
            getDDLdata();
            txtcustomer.Focus();
        }
       // lblMessage.Visible = false;
        //fillReport();
       // ValidateDate();
        MaskedEditExtender2.CultureName = "en-GB";
        if(txtFromdate.Text != "" && txttoDate.Text != "")
        {
            getdata(2);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        getdata(1);
     
    }

    public void getdata(int a)
     {
         string fromdate = txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + "/" + txtFromdate.Text.Split('/')[2];
        string todate = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];

        string custCode = "";
         ReportDocument crystalReport = new ReportDocument();
         if (ddlZone.SelectedIndex != 0)
         {
             txtcustomer.Text = "";
             lblCustName.Text = "";
             custCode = "1";
         }
         else
         {
             custCode = txtcustomer.Text;
         }

         DataSet dt = new DataSet();
         if (a == 1 || Session["tstlData"] == null)
         {
            dt = Customer_cs.Get_TStyle_Report(custCode, Convert.ToInt32(ddlZone.SelectedValue), Convert.ToInt32(strFY), "parent",
                 Convert.ToDateTime(fromdate), Convert.ToDateTime(todate));
             Session["tstlData"] = dt;
         }
         else
         {
             dt = (DataSet)Session["tstlData"];
         }

         crystalReport.Load(Server.MapPath("Report/TStyleReport.rpt"));
         crystalReport.SetDataSource(dt.Tables[0]);
         crystalReport.OpenSubreport("test").SetDataSource(dt.Tables[1]);
         crystalReport.OpenSubreport("tstlCr").SetDataSource(dt.Tables[2]);
         crystalReport.OpenSubreport("monthlysummery").SetDataSource(dt.Tables[3]);
         if (dt.Tables[0].Rows.Count > 0)
         {
             crtcustomer.ReportSource = crystalReport;
         }
         else
         {
             if (a == 1)
             {
                 MessageBox("No Data Found!!!");
             }
         }
         if (txtcustomer.Enabled == true)
         {
             txtcustomer.Focus();
         }
         else
         {
             ddlZone.Focus();
         }
    
    }

    public void Bind_DDL_Customer()
    {

        Cust_AutoCompleteExtender.ContextKey = "custzone_" + ddlZone.SelectedValue.ToString();

        //  grdCustomer.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(ddlZone.SelectedValue.ToString()));
        // grdCustomer.DataBind();
        // grdCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Bind_DDL_Customer();
        if (ddlZone.SelectedIndex == 0)
        {
            txtcustomer.Enabled = true;

        }
        else
        {
            txtcustomer.Enabled = false;
        }

    }

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
          dt = Idv.Chetana.BAL.DCMaster.Get_Name(CustCode, "Customer").Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);

            //txtpIncharge.Focus();
            //  ACExttransporter.ContextKey = CustCode;

            //Get_Employee_By_Customer_Code
            // TextBox1_AutoCompleteExtender.ContextKey = CustCode;
            //    Bind_DDL_Transport();
        }



        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";

        }
    }
    public void getDDLdata()
    {
        ddlZone.DataSource = Other.GetZonemaster(0, 2);
        ddlZone.DataBind();
        ddlZone.Items.Insert(0, new ListItem("--Individual Customer--", "0"));
        ddlZone.Focus();
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

}
