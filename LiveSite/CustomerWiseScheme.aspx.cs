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
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;

public partial class CustomerWiseScheme : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    string CustCode = "";
    #endregion

    #region Page Load
  
    protected void Page_Load(object sender, EventArgs e)
    {
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
            setdefaultdate();
            ViewState["Data"] = null;
            
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            pnlzone.Visible = false;
            pnlcustomer.Visible = true;
            btnSave.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            Bind_DDl_Scheme();
           
            DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
            DDLCC.DataBind();
            DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
        }
        if (IsPostBack)
        {
             if (ViewState["Data"] != null)
                {
                    ShowDetails((DataTable)ViewState["Data"]);
                }
        }      

    }
    #endregion

    #region Get Date
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Scheme")
        {
            
            if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
            {
                DataSet ds = new DataSet();
              //  ds = Idv.Chetana.BAL.Scheme.Get_Rep_Scheme(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
              //0, 0, 0, "scheme", Convert.ToInt32(DDLScheme.SelectedValue.ToString()), Convert.ToString(DDLCC.SelectedValue));
                ds= Other_Z.OtherBAL.Report_scheme(0,(txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
                0, 0, 0, "scheme", Convert.ToInt32(DDLScheme.SelectedValue.ToString()), Convert.ToString(DDLCC.SelectedValue));
                ViewState["Data"] = ds.Tables[0];
                ShowDetails(ds.Tables[0]);
            
            }
            
        }
        //else
        //{
        //    //if (DDLSuperZone.SelectedValue != "0")
        //   // {
        //        DataSet ds = new DataSet();
        //        ds = Idv.Chetana.BAL.Scheme.Get_Rep_Scheme(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
        //        0, Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), "scheme", Convert.ToInt32(DDLScheme.SelectedValue.ToString()), Convert.ToString(DDLCC.SelectedValue));
        //        ViewState["Data"] = ds.Tables[0];
        //        ShowDetails(ds.Tables[0]);
         
        //}
    }
    #endregion

    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion 

    #region Index Changed

   
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

    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Area")
        {
            pnlzone.Visible = true;
            pnlcustomer.Visible = false;
            DDLSuperZone.SelectedIndex = 0;
            DDLZone.SelectedIndex = 0;
            ddlCustmore.SelectedIndex = 0;
            SchemeReportView.ReportSource = null;
            DDLScheme.SelectedIndex = 0;

            DDLSuperZone.Focus();
        }
        else
        {
            pnlzone.Visible = false;
            pnlcustomer.Visible = true;

            SchemeReportView.ReportSource = null;
            DDLSuperZone.SelectedIndex = 0;
            DDLZone.SelectedIndex = 0;
            ddlCustmore.SelectedIndex = 0;
            DDLScheme.SelectedIndex = 0;
            DDLScheme.Focus();
        }

    } 

    #endregion

    #region Bind Methods

    
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
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

    public void Bind_DDl_Scheme()
    {
        DDLScheme.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup("Scheme").Tables[0];
        DDLScheme.DataBind();
        DDLScheme.Items.Insert(0, new ListItem("--Select Scheme--", "0"));
    }
    #endregion 

    public void ShowDetails(DataTable dt1)
    {
       //  if (dt1.Rows.Count > 0)
       // {
           ReportDocument rd = new ReportDocument();

            rd.Load(Server.MapPath("Report/CustomerWise_Scheme.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            SchemeReportView.DisplayGroupTree = false;
            SchemeReportView.ReportSource = rd;
      //  }
    }

    public void setdefaultdate()
    {
        txtFrom.Text = Session["FromDate"].ToString();
        txtTo.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }
}
