using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Idv.Chetana.BAL;
using CrystalDecisions.CrystalReports.Engine;
using Other_Z;

public partial class CommissionBkSeller : System.Web.UI.Page
{

    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    Other_Z.OtherBAL ObjDAL = new OtherBAL();
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind_DDL_SuperZone();
            Session["DataFillCommission"] = null;
            if (Session["FY_Text"] != null)
            {
                txtFrom.Text = "01/04/" + Session["FY_Text"].ToString().Split('-')[0];
                txtTo.Text = "31/03/" + Session["FY_Text"].ToString().Split('-')[1];
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
        if (Page.IsPostBack)
        {
            if (Session["DataFillCommission"] != null)
            {
                DataTable dt = (DataTable)Session["DataFillCommission"];
                GetPrint(dt);
            }
        }
        else
        {
            Session["DataFillCommission"] = null;
        }
    }
    #endregion

    #region Super Zone Seleted Change Event
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();

        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }
    #endregion

    #region Super Zone Dropdown Bind
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("< Select SuperZone -", "0"));
    }
    #endregion

    #region Zone Dropdown Bind
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    #endregion

    #region Button Get Click Event
    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }
    #endregion

    public void ShowDetails()
    {
        Session["DataFillCommission"] = null;
        DataSet ds = new DataSet();
        ReportDocument rd = new ReportDocument();
        string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
        string TODate = DateTime.Now.ToString("MM/dd/yyyy");
        FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
        TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];
        try
        {
            ds = ObjDAL.Idv_Chetana_Commission_BkSeller(Convert.ToInt32(DDLZone.SelectedValue.ToString() == "" ? "0" : DDLZone.SelectedValue.ToString()), Convert.ToInt32(DDLSuperZone.SelectedValue.ToString() == "" ? "0" : DDLSuperZone.SelectedValue.ToString()),
             FromDate, TODate, Convert.ToInt32(strFY), "", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["DataFillCommission"] = ds.Tables[0];
                GetPrint(ds.Tables[0]);
            }
            else
            {
                Session["DataFillCommission"] = null;
                MessageBox("Record Not Found");
                DDLSuperZone.Focus();
                return;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    #region Message Box

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    private void GetPrint(DataTable dt)
    {
        ReportDocument rd = new ReportDocument();
        string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
        string TODate = DateTime.Now.ToString("MM/dd/yyyy");
        FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
        TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];
        rd.Load(Server.MapPath("~/Report/CommissionBKSeller.rpt"));
        rd.Database.Tables[0].SetDataSource(dt);
        rd.SetParameterValue("From", FromDate);
        rd.SetParameterValue("To", TODate);
        
        CustomerReportView.ReportSource = rd;
    }

    //protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (RdbtnSelect.SelectedValue == "Commission_Report")
    //    {
    //        ViewState["Bkwise"] = null;
    //        DDLZone.Visible = true;
    //        lblzone.Visible = true;
    //    }
    //    if (RdbtnSelect.SelectedValue == "Commission_Summary")
    //    {
    //        DDLZone.Visible = false;
    //        lblzone.Visible = false;
    //    }
    //}
}