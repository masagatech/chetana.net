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


public partial class Delivery_Status_Report : System.Web.UI.Page
{

    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion
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
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
        if (IsPostBack)
        {
            if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            {
                // MessageBox("Select Items");
            }
            else if (txtFrom.Text == "")
            {

            }
            else if (txtTo.Text == "")
            { }
            else
            {
                ShowDetails();
            }
        }
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }
    public void ShowDetails()
    {


        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.InvoiceDeliveryStatus.Idv_Chetana_Get_StatusFor_Report(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToDateTime(txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), Convert.ToDateTime(txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY), rdbselect.SelectedValue.ToString(),Convert.ToInt32(ddlZone.SelectedValue.ToString()),"");
        //DataSet ds2 = new DataSet();
        // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
        DataView dv = new DataView(ds.Tables[0]);

        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("Report/Delivery_Status.rpt"));
        rd.Database.Tables[0].SetDataSource(dv);
        // rd.Database.Tables[1].SetDataSource(dv2);
        //rd.SetDataSource(ds);
        deliverystatus.ReportSource= rd;


    }
    
}
