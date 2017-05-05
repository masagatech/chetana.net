using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Add Name Space
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using Newtonsoft.Json;
using Other_Z;
using OtherNewClass;

public partial class MissingRecieptNo : System.Web.UI.Page
{
    #region Goloval Veriable
    string strChetanaCompanyName = "cppl";
    Other_Z.OtherBAL ObjDal = new OtherBAL();
    string strFY;
    #endregion

    #region Page Load Event
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
        }
        if (!Page.IsPostBack)
        {
            txtFromDate.Text = "01/04/201" + strFY + "";
            txtToDate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1) + "";
            Bind_DDL_SuperZone();
            Bind_DDL_Zone();
            txtFromDate.Focus();
        }
        if (Page.IsPostBack)
        {
            if (Session["GetData"] != null)
            {
                DataTable dt = (DataTable)Session["GetData"];
                GetPrint(dt);
            }
            
            //BindReport();
        }
        else
        {
            Session["GetData"] = null;
        }
        
    }
    #endregion

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Biind SuperZoneName
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        DDLSuperZone.Focus();
    }
    #endregion

    #region BindZoneName
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    #endregion

    #region Super Zone Seleted Change Event
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
    #endregion

    #region GetData
    private void GetdatawithMissingNo()
    {
        
        ReportDocument rd = new ReportDocument();
        string Fromdate = DateTime.Now.ToString("MM/dd/yyyy");
        string Todate=DateTime.Now.ToString("MM/dd/yyyy");
        Fromdate=txtFromDate.Text.Split('/')[1]+"/"+txtFromDate.Text.Split('/')[0]+"/"+txtFromDate.Text.Split('/')[2];
        Todate = txtToDate.Text.Split('/')[1]+"/"+txtToDate.Text.Split('/')[0]+"/"+txtToDate.Text.Split('/')[2];
        DataTable dt = ObjDal.Idv_Chetana_Missing_UnuseReceiptNo(Fromdate, Todate, Convert.ToInt32(Session["FY"]), Convert.ToInt32("0"), Convert.ToInt32("0"),Convert.ToInt32(DDLSuperZone.SelectedValue),Convert.ToInt32(DDLZone.SelectedValue), "", "").Tables[0];
        if (dt.Rows.Count > 0)
        {
            Session["GetData"] = dt;
            GetPrint(dt);
        }
        else
        {
            MessageBox("Record Not Found");
            txtFromDate.Focus();
            return;
        }
    }
    #endregion

    #region Get Buton Click Event
    protected void Get_Click(object sender, EventArgs e)
    {
        GetdatawithMissingNo();
    }
    #endregion

    #region Get And Print Method
    private void GetPrint(DataTable dt)
    {
        ReportDocument rd = new ReportDocument();
        string Fromdate = DateTime.Now.ToString("MM/dd/yyyy");
        string Todate = DateTime.Now.ToString("MM/dd/yyyy");
        Fromdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        Todate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        rd.Load(Server.MapPath("~/Report/MissingRecieptNo.rpt"));
        rd.SetDataSource(dt);
        rd.SetParameterValue("FromDP", Fromdate);
        rd.SetParameterValue("TODp", Todate);
        crystalMissing.ReportSource = rd;
    }
    #endregion
}