﻿using System;
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

public partial class Pendingadddisbursal : System.Web.UI.Page
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string url;
    Other_Z.OtherBAL ObjDAl = new Other_Z.OtherBAL();

    
    #endregion
    protected void Page_Load(object sender, EventArgs e)

    {
        url = Request.QueryString["a"];
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

           // btnUpdate.Visible = false;
            DDLSuperZone.Focus();
            if (ddlCustmore.SelectedValue.ToLower().ToString() == "0" || ddlCustmore.SelectedValue.ToLower().ToString() == "")
            {

            }
            else
            {
                // ShowDetails();
                DataSet ds = new DataSet();
                ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_AdditionalCommission(
                   Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
                   Convert.ToInt32(DDLZone.SelectedValue.ToString()),
                   Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
                   Convert.ToInt32(DDLCC.SelectedValue.ToString()),
                   Convert.ToInt32(strFY));
                DataView dv = new DataView(ds.Tables[0]);
                gdGeneral.DataSource = dv;
                gdGeneral.DataBind();
                //btnUpdate.Visible = true;

            }

            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            //btnSave.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            Bind_DDL_CC();

        }
        if (IsPostBack)
        {
            if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            {
                MessageBox("Select Items");
            }

            else
            {
               // ShowDetails();
                //btnUpdate.Visible = true;
            }
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
        //btnUpdate.Visible = true;
    }
    public void ShowDetails()
    {
        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_AdditionalCommissionamount(
           Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
           Convert.ToInt32(DDLZone.SelectedValue.ToString()),
           Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
           Convert.ToInt32(DDLCC.SelectedValue.ToString()),
           Convert.ToInt32(strFY));
        DataView dv = new DataView(ds.Tables[0]);
        gdGeneral.DataSource = dv;
        gdGeneral.DataBind();
        //ReportDocument rd = new ReportDocument();
        //rd.Load(Server.MapPath("Report/AdditionalCommission.rpt"));
        //rd.Database.Tables[0].SetDataSource(dv);
        //CustomerWiseAmount.ReportSource = rd;


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
        ddlCustmore.DataSource = ObjDAl.Idv_Chetana_Get_ZoneCustomerAdditionalCommissionOtherZ(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
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
    protected void OpenExternalLink(object sender, EventArgs e)
    {
        
        CustomerDetails obj = new CustomerDetails();
        Session["PayMode"] = null;
        foreach (GridViewRow row in gdGeneral.Rows)
        {
             Label code = (Label)row.FindControl("lblCode");
             Label Firstname = (Label)row.FindControl("lblname");
             TextBox Amount = (TextBox)row.FindControl("txtAmount");
             Session["PayMode"] = code.Text + "+" + Firstname.Text + "+" + Amount.Text;
        }
        Server.Transfer("BankPayment.aspx?a=a&");
    }
    protected void gdGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label btn = (Label)e.Row.FindControl("lblMode");
            Button btnpay=(Button)e.Row.FindControl("btnLink");

            if (btn.Text == "Addcomision")
            {
                btnpay.Enabled = false;
            }
           
        }
    }
}