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
using CrystalDecisions.Reporting.WebControls;
using Idv.Chetana.BAL;
using CrystalDecisions;
using CrystalDecisions.Web;


public partial class CNProgrammeChart : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    DataSet ds = new DataSet();
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
            DDLSuperZone.Focus();
            if (ddlCustmore.SelectedValue.ToLower().ToString() == "0" || ddlCustmore.SelectedValue.ToLower().ToString() == "")
            {

            }
            else
            {
                // ShowDetails();

            }
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            //btnSave.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));

        }
        if (IsPostBack)
        {
            if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            {

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();


    }
    public void ShowDetails()
    {


       // if (txtFrom.Text.Trim() == "" || txtTo.Text.Trim() == "")
        {
            ds = Idv.Chetana.BAL.Specimen.Idv_Chetana_Rep_CustomerWise_Sales(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2] + "!" + txtfrmNo.Text.Trim()), Convert.ToInt32(strFY),
               Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()));
            //DataSet ds2 = new DataSet();
            // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
            DataView dv = new DataView(ds.Tables[0]);

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/CNProgrammChart.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);


            // rd.Database.Tables[1].SetDataSource(dv2);
            //rd.SetDataSource(ds);
            CustomerWiseAmount.ReportSource = rd;
            txtshowno.Text = (ds.Tables[1].Rows[0]["nvalue"].ToString());
            //if (IsPostBack)
            //{
            //    CreditNote _obcn = new CreditNote();

            //    _obcn.ActualKey = "cn-fromno";
            //    _obcn.GroupKey = "cn-fromno";
            //    _obcn.PreviousCount = Convert.ToInt32(ds.Tables[0].Rows[0]["newno"].ToString());
            //    _obcn.NewCount = Convert.ToInt32(ds.Tables[1].Rows[0]["FRMNO"].ToString());
            //    _obcn.Value = (ds.Tables[1].Rows[0]["nvalue"].ToString());


            //    _obcn.SuperZoneId = Convert.ToInt32(DDLSuperZone.SelectedValue.ToString());

            //    _obcn.CreatedBy = Session["UserName"].ToString();
            //    _obcn.Flag = "update_cn_prog_chart";
            //    _obcn.SaveCNProgrammeChartDetails();

            //}


        }



    }


    //public override void PrintReport()
    //{
    //    //base.PrintReport();
    //    /* Update your datasource to set last printed date = now */
    //}




    //protected void CustomerWiseAmount_PreRender(object sender, EventArgs e)
    //{
    //    Response.Write("hi");
    //}
    //protected void CustomerWiseAmount_Search(object source, CrystalDecisions.Web.SearchEventArgs e)
    //{
    //    
    //}

    //CrystalDecisions.Reporting.WebControls.DatabaseLogOnList
    //    CrystalDecisions.Reporting.WebControls.ParameterList
    //        CrystalDecisions.Web.ViewerToolbar
    //            CrystalDecisions.Web.CrystalReportGroupTree
    //                CrystalDecisions.Web.CrystalReportPageViewer 


    //protected void btnprint_Click(object sender, EventArgs e)
    //{

    //}
    //protected void CustomerWiseAmount_Load(object sender, EventArgs e)
    //{
    //    foreach (Control c in CustomerWiseAmount.Controls)
    //    {
    //       foreach (Control cs in CrystalDecisions.Web.CrystalReportViewer() ;
    //        v.ToolTip
    //        Response.Write(c.ToString()+ "<BR>");
    //    }
    //}
    protected void btnsaveno_Click(object sender, EventArgs e)
    {
        CreditNote _obcn = new CreditNote();

        _obcn.ActualKey = "cn-fromno";
        _obcn.GroupKey = "cn-fromno";
        _obcn.PreviousCount = Convert.ToInt32(ds.Tables[0].Rows[0]["newno"].ToString());
        _obcn.NewCount = Convert.ToInt32(ds.Tables[1].Rows[0]["FRMNO"].ToString());
        _obcn.Value = (ds.Tables[1].Rows[0]["nvalue"].ToString());


        _obcn.SuperZoneId = Convert.ToInt32(DDLSuperZone.SelectedValue.ToString());

        _obcn.CreatedBy = Session["UserName"].ToString();
        _obcn.Flag = "update_cn_prog_chart";
        _obcn.SaveCNProgrammeChartDetails();
        MessageBox("Submit Successfully");
    }
}

