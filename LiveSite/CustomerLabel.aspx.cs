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

public partial class CustomerLabel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind_DDL_CC();
            Bind_DDL_SuperZone();
            Bind_DDL_Supplier();
            ViewState["Data"] = null;
            pnlcustomer.Visible = true;
            pnlsupplier.Visible = false;
        }
        if (IsPostBack)
        {
           if (ViewState["Data"] != null)
                {
                    BindData((DataTable)ViewState["Data"]);
                }
         }
    }
    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Customer")
        {
            pnlcustomer.Visible = true;
            pnlsupplier.Visible = false;
            ViewState["Data"] = null;
            BindData((DataTable)ViewState["Data"]);
            DDLSuperZone.SelectedIndex = 0;
        }
        else
        {
            pnlcustomer.Visible = false;
            pnlsupplier.Visible = true;
            ViewState["Data"] = null;
            BindData((DataTable)ViewState["Data"]);
            ddlSupplier.SelectedIndex = 0;
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (rdbselect.SelectedValue == "Customer")
        {
            dt = Customer_cs.Get_CustListReport("SuperZone", DDLCC.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), ddlZone.SelectedValue.ToString());
        }
        else
        {
            dt = Customer_cs.Get_CustList("Supplier", ddlSupplier.SelectedValue.ToString());
        }
        ViewState["Data"] = dt;
        BindData(dt);
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        ddlZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
       
    }
    public void Bind_DDL_Zone()
    {
        ddlZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        ddlZone.DataBind();
        ddlZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_Supplier()
    {
        ddlSupplier.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Supplier");
        ddlSupplier.DataBind();
        ddlSupplier.Items.Insert(0, new ListItem("-Select Supplier-", "0"));

    }

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            ddlZone.Items.Clear();
            Bind_DDL_SuperZone();
        }
        else
        {
            Bind_DDL_Zone();
            ddlZone.Focus();
        }
    }
    public void BindData(DataTable dt1)
    {
        if (dt1 != null)
        {
            if (dt1.Rows.Count > 0)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CustomerLabel.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrCustLabel.ReportSource = rd;
            }
        }
        else
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/CustomerLabel.rpt"));
           
            CrCustLabel.ReportSource =null;
        }
    }

    //protected void DDLCC_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (DDLCC.SelectedIndex == 0)
    //    {
    //        DDLCC.Focus();
    //        DDLSuperZone.Items.Clear();
    //        Bind_DDL_CC();
    //    }
    //    else
    //    {
    //        Bind_DDL_SuperZone();
    //        DDLSuperZone.Focus();
    //    }
    //}

    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
}
