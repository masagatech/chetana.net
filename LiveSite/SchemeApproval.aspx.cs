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

public partial class SchemeApproval : System.Web.UI.Page
{
    #region Variables
    string strFY;
    string CustCode = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            setdefaultdate();
            ViewState["Approval"] = null;

            Bind_DDL_SuperZone();
            //Bind_DDL_CustomerCategory();

            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
           
        }
        if (IsPostBack)
        {
            if (ViewState["Approval"] != null)
            {
                ShowDetails((DataTable)ViewState["Approval"]);
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        //if (DDLSuperZone.SelectedValue != "0")
        //{
        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Scheme.Get_Rep_Scheme(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
0, Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), "Approval", 0);
      
      //  ds = Idv.Chetana.BAL.Scheme.Get_Rep_Scheme(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
      //0, Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), "Approval", 0, Convert.ToString(DDLCC.SelectedValue));
       
        ViewState["Approval"] = ds.Tables[0];
        ShowDetails(ds.Tables[0]);
        //}
        //else
        //{
        //    MessageBox("Select SuperZone");
        //}

    }
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
   


    public void setdefaultdate()
    {
        txtFrom.Text = Session["FromDate"].ToString();
        txtTo.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }

    public void ShowDetails(DataTable dt1)
    {
        //  if (dt1.Rows.Count > 0)
        // {
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/SchemeApproval.rpt"));
        rd.Database.Tables[0].SetDataSource(dt1);
        rptvSchemeApproval.ReportSource = rd;
        //  }
    }
    #endregion
}
