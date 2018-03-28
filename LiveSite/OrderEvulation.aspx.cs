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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using Others;

public partial class UserControls_OrderEvulation : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    static DataSet stDS;
    static decimal dbamt;
    static decimal cramt;
    DateTime fdate;
    DateTime tdate;
    string flag = null;
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
        }
        if (IsPostBack)
        {
            if (RdbtnSelect1.SelectedValue == "Summary-Excel")
            {

                Object o = null;

                if (txtfromDate1.Text != "" || txtToDate1.Text != "")
                {
 
                    Pnl2.Visible = false;
                    Pnl1.Visible = false;
                    Pnl3.Visible = true;
                    this.btnget1_Click(o, EventArgs.Empty);
 

                }
            }
            else
            {
                if (txtfromDate.Text != "" || txtToDate.Text != "")
                {
                    ShowDetails();
                }
            }

        }
        if (!Page.IsPostBack)
        {
            
           DDLSuperZone.Focus();
            Pnl2.Visible = true;
            Pnl1.Visible = false;
            Pnl3.Visible = false; 
          
        }
        
    }
    protected void RepDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label ZoneCode = (Label)e.Item.FindControl("ZoneCode");
        GridView grdSalesAnalysis = (GridView)e.Item.FindControl("grdSalesAnalysis");

        DataView dv = new DataView(stDS.Tables[1]);
        dv.RowFilter = " ZoneCode = '" + ZoneCode.Text.ToString().Trim() + "'";
        grdSalesAnalysis.DataSource = dv;
        grdSalesAnalysis.DataBind();
        grdSalesAnalysis.Visible = true;
    }

    
    //Summary excel get button 5 Aug

    protected void btnget1_Click(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            MessageBox("Select SuperDuper Zone");
        }
        else
        {
            string from = txtfromDate1.Text.Split('/')[1] + "/" + txtfromDate1.Text.Split('/')[0] + "/" + txtfromDate1.Text.Split('/')[2];
            string To = txtToDate1.Text.Split('/')[1] + "/" + txtToDate1.Text.Split('/')[0] + "/" + txtToDate1.Text.Split('/')[2];
            fdate = Convert.ToDateTime(from);
            tdate = Convert.ToDateTime(To);
            if (fdate > tdate)
            {
                MessageBox("From Date is Greater than ToDate");
                txtfromDate.Focus();
            }
            else
            {
                int sdz, sz, z;
                sdz =Convert.ToInt32(ddlSDZone.SelectedValue);
                if (DDLSuperZone1.SelectedIndex <=-1)
                {
                    sz = 0;
                }
                else
                {
                    sz = Convert.ToInt32(DDLSuperZone1.SelectedValue);
                }
                if (sz == 0)
                {
                    z = 0;
                }
                else
                {
                    if (DDLZone1.SelectedIndex <= 0)
                    {
                        z = 0;
                    }
                    else
                    {
                        z = Convert.ToInt32(DDLZone1.SelectedValue);
                    }
                }

                stDS = new DataSet();

                //stDS = Idv.Chetana.BAL.Other.Dashboard.Get_Dasboard_ForOrderValuation(fdate, tdate,Convert.ToInt32(ddlSDZone.SelectedValue), Convert.ToInt32(DDLSuperZone1.SelectedValue),Convert.ToInt32(DDLZone1.SelectedValue), Convert.ToInt32(strFY));
                stDS = OtherClass.Get_OrderValuation_SummaryExcel(fdate, tdate, sdz, sz, z, Convert.ToInt32(strFY));
                if (stDS.Tables[2].Rows.Count > 0)
                {
                    DataView dv = new DataView(stDS.Tables[2]);
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Server.MapPath("Report/OrderValutionreport3.rpt"));
                    rd.Database.Tables[0].SetDataSource(dv);
                    CrOrderValuation.ReportSource = rd;
                }
                else
                {
                    MessageBox("No Record Found");
                }
            }
        }
    }

    protected void DDLSuperZone1_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDDLdata1();
    }
    public void getDDLdata1()
    {
        DDLZone1.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone1.SelectedValue.ToString()), "Zone");
        DDLZone1.DataBind();
        DDLZone1.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        DDLZone1.Enabled = true;
        DDLZone1.Focus();
    }
    protected void btnget_Click(object sender, EventArgs e)
    {


        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds = Other.Dashboard.Get_OrderValuation(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), Convert.ToInt32(DDlZone.SelectedValue), fdate, tdate);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/Printordervaluation.aspx?d=" + DDLSuperZone.SelectedValue + "&sd=" + strFY + "&zd=" + DDlZone.SelectedValue + "&fd=" + fdate + "&td=" + tdate + "')", true);
        }
        else
        {
            MessageBox("No Record Found");

        }

    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSDZone.SelectedIndex == 0)
        {
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            DDLSuperZone1.Items.Clear();
            DDLSuperZone1.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));

        }
        else
        {
            Bind_DDL_SuperZone1();
            DDLSuperZone1.Focus();
        }

    }
    public void Bind_DDL_SuperZone1()
    {
        DDLSuperZone1.Items.Clear();
        DDLSuperZone1.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone1.DataBind();
        DDLSuperZone1.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));


    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDDLdata();
    }

    public void getDDLdata()
    {
        DDlZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDlZone.DataBind();
        DDlZone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        DDlZone.Enabled = true;
       // DDlZone.Focus();
    }

    
   
    protected void grdSalesAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //opbal = 0;
            dbamt = 0;
            cramt = 0;
            // cnamt = 0;
            //Balamt = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbldebtamt = (Label)e.Row.FindControl("lbldebtamt");
            dbamt = dbamt + Convert.ToDecimal(lbldebtamt.Text.Trim());

            Label lblcramt = (Label)e.Row.FindControl("lblcramt");
            cramt = cramt + Convert.ToDecimal(lblcramt.Text.Trim());

            //Label lblamt = (Label)e.Row.FindControl("lblamt");
            //tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTRecdAmt = (Label)e.Row.FindControl("lblTRecdAmt");
            lblTRecdAmt.Text = cramt.ToString().Trim();
            Label lblTBillamt = (Label)e.Row.FindControl("lblTBillamt");
            lblTBillamt.Text = dbamt.ToString().Trim();
            //Label lblTbalamt = (Label)e.Row.FindControl("lblTbalamt");
            //lblTbalamt.Text = Balamt.ToString().Trim();
        }

    }

    protected void RdbtnSelect1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect1.SelectedValue == "Summary")
        {
            Pnl2.Visible = true;
            Pnl1.Visible = false;
            Pnl3.Visible = false;
            Response.Redirect(Request.RawUrl);
            
        }
        if (RdbtnSelect1.SelectedValue == "Details")
        {
            Pnl2.Visible = false;
            Pnl3.Visible = false;
            Pnl1.Visible = true;
            DDLSuperZone.Focus();
            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            getDDLdata();
            txtfromDate.Text = Session["FromDate"].ToString();
            txtToDate.Text = Session["ToDate"].ToString();
            DDLCC.DataSource = Idv.Chetana.BAL.CustCategory.GetCustomerCategoryMaster("adminCCM");
            DDLCC.DataBind();
            DDLCC.Items.Insert(0, new ListItem("--Select Category--", "0"));
            DDLCC.Enabled = true;

        }
        if (RdbtnSelect1.SelectedValue == "Summary-Excel")
        {
            Pnl2.Visible = false;
            Pnl1.Visible = false ;
            Pnl3.Visible = true;
            ddlSDZone.Focus();
            Bind_DDl_SDZone();
            //DDLSuperZone1.Focus();
            //DDLSuperZone1.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
            //DDLSuperZone1.DataBind();
            //DDLSuperZone1.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //getDDLdata1();
            txtfromDate1.Text = Session["FromDate"].ToString();
            txtToDate1.Text = Session["ToDate"].ToString();
           
        }
    }

    public void Bind_DDl_SDZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));

    }
    public void ShowDetails()
    {
        //MessageBox("Show Details");
        string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        stDS = new DataSet();
        stDS = Other.Dashboard.Get_OrderValuation(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), Convert.ToInt32(DDlZone.SelectedValue), fdate, tdate, rdbselect.SelectedValue.ToString().Trim(), Convert.ToString(DDLCC.SelectedValue));
        if (stDS.Tables[0].Rows.Count > 0)
        {
            DataView dv = new DataView(stDS.Tables[0]);
            //  DataView dv2 = new DataView(ds2.Tables[0]);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/OrderValutionreport2.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            //rd.
           // rd.PrintToPrinter(1,false,0,0);
            
            // rd.Database.Tables[1].SetDataSource(dv2);
            //rd.SetDataSource(ds);
            CrOrderValuation.ReportSource = rd;


        //    RepDetails.DataSource = stDS.Tables[0];

        //    RepDetails.DataBind();
        //    RepDetails.Visible = true;
        //    lblTotalGrAmount.Text = string.Format("{0:0.00}", Convert.ToDecimal(stDS.Tables[3].Rows[0]["TotalGrossAmount"].ToString()));
        //    lblTotalNtAmount.Text = string.Format("{0:0.00}", Convert.ToDecimal(stDS.Tables[3].Rows[0]["TotalNetAmount"].ToString()));
        //    lblTRecdAmt.Text = "Grand Total:";
        //    btnget.Visible = true;
        }
        else
        {
            MessageBox("No Record Found");
        //    RepDetails.DataSource = "";
        //    RepDetails.DataBind();
        //    RepDetails.Visible = true;
        //    lblTotalGrAmount.Text = "";
        //    lblTotalNtAmount.Text = "";
        //    lblTRecdAmt.Text = "";

        }

    }

    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (rdbselect.SelectedValue == "Without Zero")
        {
            flag = "nonzero";

        }
        if (RdbtnSelect1.SelectedValue == "Zero")
        {
            flag = "zero";

        }
        if (RdbtnSelect1.SelectedValue == "Both")
        {
           flag = "both";
        }
    }
    protected void DDLZone1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
