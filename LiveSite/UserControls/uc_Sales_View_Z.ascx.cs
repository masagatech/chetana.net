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

public partial class UserControls_Salaes_View_Z : System.Web.UI.UserControl
{
    #region Variables

    DateTime fdate;
    DateTime tdate;
    string strChetanaCompanyName = "cppl";
    string strFY;

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
        }
        if (!Page.IsPostBack)
        {
            GetValidation(4, Convert.ToInt32(Session["Role"]));
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            ddlSDZone.Items.Insert(0, new ListItem("-- Select SDZone --", "0"));
            DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
            DDLZone.Items.Insert(0, new ListItem("-- Select Zone --", "0"));
            setddl(Session["zoneLevel"].ToString(), Session["zoneId"].ToString());
        }

    }
    #endregion





    #region MsgBox
    public void MessageBox(string msg)
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

    #region Binddata method



    #endregion


    #region Validation Methods

    #region Variables

    private static bool add = false;
    private static bool view = false;
    private static bool edit = false;
    private static bool delete = false;

    #endregion

    public void GetValidation(int Menuid, int Roleid)
    {
        DataTable dt = new DataTable();
        dt = Mappings.Get_MenuFunctions(Menuid, Roleid).Tables[0];
        add = Convert.ToBoolean(dt.Rows[0]["Add"].ToString());
        view = Convert.ToBoolean(dt.Rows[0]["View"].ToString());
        edit = Convert.ToBoolean(dt.Rows[0]["Edit"].ToString());
        delete = Convert.ToBoolean(dt.Rows[0]["Delete"].ToString());
    }

    #endregion



    #region Datewise

    protected void btnfind_Click(object sender, EventArgs e)
    {
        ShowDetails();
        
    }
    #endregion







    #region ddlSDZone index changed

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {

            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
            DDLSuperZone.Focus();
        }
    }

    #endregion

    #region SuperZone index change

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
            DDLZone.Items.Insert(0, new ListItem("-- Select Zone --", "0"));
        }
    }

    #endregion

    #region Zone index change

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            
             MessageBox("Select SuperZone");
             DDLZone.Focus();
            // SalesanalysisReportview.ReportSource = null;
            //  DDLZone.SelectedValue = null;
        }

    }

    #endregion

    #region enabled ddl

    public void setddl(string level, string ids)
    {
        try
        {
            SetDDLVisibility _obj = new SetDDLVisibility();
            _obj.fillProp(level, ids);
            ddlSDZone.Enabled = _obj.DdlSDZone;
            ddlSDZone.SelectedValue = _obj.DDlSdzIDValue.ToString();
            Bind_DDL_SuperZone();
            DDLSuperZone.Enabled = _obj.DdlSZone;
            DDLSuperZone.SelectedValue = _obj.DDlSzIDValue.ToString();
            Bind_DDL_Zone();
            DDLZone.SelectedValue = _obj.DDlZIDValue.ToString();
            DDLZone.Enabled = _obj.DdlZone;


        }
        catch (Exception ex)
        {


        }
    }

    #endregion

    #region ddl dind methods

    public void Bind_DDL_SuperZone()
    {
        //DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        //DDLSuperZone.DataBind();
        //DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        //DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));

        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        DDLSuperZone.Focus();
    }

    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    #endregion

    public void ShowDetails()
    {
        DataSet ds = new DataSet();
        string from = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtFromDate.Focus();
        }
        else
        {
            //ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate, Convert.ToInt32(DDlZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim());
            ds = Other.Dashboard.Get_SalesAnalysisReport(Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate, Convert.ToInt32(DDLZone.SelectedValue), rdbselect.SelectedValue.ToString().Trim(),
                Convert.ToInt32(ddlSDZone.SelectedValue),"");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                ReportDocument rd = new ReportDocument();

                rd.Load(Server.MapPath("Report/Salesanalysis.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                SalesanalysisReportview.ReportSource = rd;
                //   ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintSalesAnalysis.aspx?d=" + DDLSuperZone.SelectedValue + "&sd=" + strFY + "&fd=" + fdate + "&td=" + tdate + "')", true);
            }
            else
            {
                MessageBox("Records Not Found");
                DDLSuperZone.Focus();
            }
        }
    }

}
