#region NameSpace
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
using Idv.Chetana.Common;
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class SuperZone_WeeklyCollection : System.Web.UI.Page
{
    #region Variables

    string docdate;
    string frdate;
    string todate;
    DateTime ddt;
    DateTime tdt;
    DateTime fdt;
    string strChetanaCompanyName = "cppl";
    string strFY;
    int DocNo;

    #endregion
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
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
            //SetView();
            // BindBankRDetails();
            // DDLCCDD.Items.Insert(0, new ListItem("-Select-", "0"));
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));
            ddlSDZone.Focus();
            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //txtbankcoder.Focus();
            Session["Data"] = null;

        }
        else
        {
            if (Session["Data"] != null)
            {
                FillReport((DataView)Session["Data"]);
            }
        }
    }

    #endregion

    #region Events



    #region Button Click
    protected void btnget_Click(object sender, EventArgs e)
    {

        try
        {
            string BnkCode;//= txtbankcoder.Text.Trim();

            frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
            todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

            tdt = Convert.ToDateTime(todate);
            fdt = Convert.ToDateTime(frdate);

            if (tdt >= fdt)
            {
                DataSet ds = new DataSet();
                ds = Idv.Chetana.BAL.BankPayment.Get_SuperZoneWise_Weekly_Collection(Convert.ToInt32(DDLSuperZone.SelectedValue), fdt, tdt,"abc",Convert.ToInt32(ddlSDZone.SelectedValue));

                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                   
                        DataView dv1 = new DataView(ds.Tables[0]);
                        Session["Data"] = dv1;
                        FillReport(dv1);
                   
                    //string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
                    //if (page != "bankreceipt.aspx")
                    //{
                    //    GrdBankRDetails.Columns[7].Visible = false;
                    //}
                    //GrdBankRDetails.DataBind();

                    PnlBankRDetails.Visible = true;

                }
                else
                {
                    PnlBankRDetails.Visible = false;
                    MessageBox("Records Not Available ");
                }
            }
            else
            {
                PnlBankRDetails.Visible = false;
                MessageBox("From Date is greater than To Date");
            }

            // txtbankcoder.Focus();


        }
        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            //txtbankcoder.Focus();

        }

    }

    public void FillReport(DataView dt)
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/SuperZoneWeekly _Collection.rpt"));
        crystalReport.SetDataSource(dt);
        repBankReceipt.ReportSource = crystalReport;
    }

    #endregion

    #region TextChanged

   


    #endregion
    #endregion
    #region Methods

    

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

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion



    #endregion

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");

            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
           
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
    }

    public void Bind_DDL_SuperZone()
    {
        //Response.Write(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()));
      
        DDLSuperZone.Items.Clear();
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
       

    }
}
