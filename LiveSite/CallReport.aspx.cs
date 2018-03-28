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

public partial class CallReport : System.Web.UI.Page
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
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
        if (!Page.IsPostBack)
        {
            DDLSuperZone.Focus();
            
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            Bind_DDL_CC();
            Bind_DDL_Status();
            ViewState["Data"] = null;

        }
       
    }



    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }


    public void ShowDetails()
    {
        DataTable dt = new DataTable();
        if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && ddlStatus.SelectedItem.Text != "-Select Status-")
        {
            dt = Idv.Chetana.BAL.CMS.Idv_Chetana_Rep_CallReport(
                (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]),
               "", "", ddlStatus.SelectedItem.Text.ToString(),
               0,
               "FD&TD&Status").Tables[0];
        }
        else if (txtTicketNoFrom.Text != string.Empty || txtTicketNoTo.Text != string.Empty)
        {
            dt = Idv.Chetana.BAL.CMS.Idv_Chetana_Rep_CallReport(
          "","",  txtTicketNoFrom.Text, txtTicketNoTo.Text, "",0,
          "TicktFrom&TKTto").Tables[0];
        }
        else if (ddlStatus.SelectedItem.Text != "-Select Status-")
        {
            dt = Idv.Chetana.BAL.CMS.Idv_Chetana_Rep_CallReport(
               "","",
               "","", ddlStatus.SelectedItem.Text.ToString(),
             0,
              "Status").Tables[0];
        }
        if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && ddlStatus.SelectedItem.Text == "-Select Status-")
        {

            dt = Idv.Chetana.BAL.CMS.Idv_Chetana_Rep_CallReport(
                (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]),
               "", "", "",
              0,
             "FD&TD").Tables[0];
        }
        if (ddlCustmore.SelectedItem.Text != "-Select Customer-")
        {
            dt = Idv.Chetana.BAL.CMS.Idv_Chetana_Rep_CallReport(
             "","",
               "", "", "",
              Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
              "CustNo").Tables[0];
        }
        ViewState["Data"] = dt;
        BindData(dt);

    }

    public void BindData(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/CR_TicketHistory.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            CrCustLabel.ReportSource = rd;
        }
           
           
    }

    

   
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
            Bind_DDL_SuperZone();
        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLZone.Focus();
            ddlCustmore.Items.Clear();
            //  DDLZone.SelectedValue = null;
            Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_Customer();
            ddlCustmore.Focus();
        }

    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
    public void Bind_DDL_Status()
    {
        ddlStatus.DataSource = CMS.GetStatus();
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("-Select Status-", "0"));
    }
}