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


public partial class BalanceConfirmationReport : System.Web.UI.Page
{
    #region Variables

    string strChetanaCompanyName = "cppl";
    string strFY;


    #endregion

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
        }
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                //  strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                //  strFY = Session["FY"].ToString();
                HidFY.Value = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {
            getDDLdata();

        }
        lblMessage.Visible = false;
        //fillReport();
        ValidateDate();
        MaskedEditExtender2.CultureName = "en-GB";
        fillReport(0);
    }
    public void Bind_DDL_Customer()
    {

        Cust_AutoCompleteExtender.ContextKey = "custzone_" + ddlZone.SelectedValue.ToString();

        //  grdCustomer.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(ddlZone.SelectedValue.ToString()));
        // grdCustomer.DataBind();
        // grdCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
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
        ddlZone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        ddlZone.Focus();
    }

    public void fillReport(int ISPRINT)
    {
        if (txtRs.Text.Trim() == "")
        {
            txtRs.Text = "0";
        }

        DataTable dt = new DataTable();
        string date = "";
        if (ISPRINT == 1)
        {
            if (txtcustomer.Text != "")
            {
                if (txttoDate.Text != "")
                {
                    date = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
                    Session["DATAREP"] = Customer_cs.Idv_Chetana_Customer_BlackList(0, "_C$" + txtcustomer.Text, date, Convert.ToDecimal(txtRs.Text.Trim()), Convert.ToInt32(HidFY.Value), 0, 0).Tables[0];
                }
            }
            else
            {

                if (txttoDate.Text != "")
                {
                    date = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
                    Session["DATAREP"] = Customer_cs.Idv_Chetana_Customer_BlackList(0, "_Z$" + txtcustomer.Text, date, Convert.ToDecimal(txtRs.Text.Trim()), Convert.ToInt32(HidFY.Value), 0, Convert.ToInt32(ddlZone.SelectedValue.Trim())).Tables[0];
                }
            }
        }
        if (Session["DATAREP"] != null)
        {
            dt = (DataTable)Session["DATAREP"];
        }
        if (dt.Rows.Count > 0)
        {
            fillReport();

        }
        else
        {
            lblMessage.Visible = true;

        }
        if (ISPRINT == 1)
        {
            //crystalReport.PrintToPrinter(0, false, 0, 0);
        }


    }
    private void fillReport()
    {
        if (Session["DATAREP"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["DATAREP"];
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("Report/BalanceConfirmationReport.rpt"));
            crystalReport.SetDataSource(dt);
            crtcustomer.ReportSource = crystalReport;
            // pnlDetails.Visible = true;
        }

    }

    protected override void OnInit(System.EventArgs e)
    {
        base.OnInit(e);


        if ((Request.Form.Keys.Count > 0))
        {
            fillReport();

        }

    }

    protected void btnget_Click(object sender, EventArgs e)
    {

        // grdCustomer.DataSource = 
        fillReport(1);
        txttoDate.Focus();
        //fillReport();

    }
    protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_Customer();
        txtcustomer.Focus();

    }
    protected void crtcustomer_Load(object sender, EventArgs e)
    {
        if (ddlZone.SelectedIndex > 0)
        {
            fillReport(0);
        }
    }
    protected void crtcustomer_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {
        // fillReport(0);
    }

    public void ValidateDate()
    {
        if (hiddenfildYear.Value == "")
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();

                DataTable dt = Customer_cs.Idv_Chetana_Customer_BlackList(2, "", "", 0, 0, 0, Convert.ToInt32(strFY)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    hiddenfildYear.Value = dt.Rows[0][0].ToString();
                }
                string year = hiddenfildYear.Value;
                MaskedEditValidator1.MinimumValue = "01/04/" + year;
                MaskedEditValidator1.MaximumValue = "31/03/" + (Convert.ToInt32(year) + 1).ToString();
                MaskedEditValidator1.MinimumValueMessage = "Date should be greater than 01/04/" + year;
                MaskedEditValidator1.MaximumValueMessage = "Date should be less than 31/03/" + (Convert.ToInt32(year) + 1).ToString();
            }
            else
            {
                Session.Clear();
            }

        }
    }
}
