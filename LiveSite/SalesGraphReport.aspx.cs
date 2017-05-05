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
using Others;
using CrystalDecisions.CrystalReports.Engine;

public partial class SalesGraphReport : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string strSelectedSD = "0";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["ChetanaCompanyName"] != null && Session["FY"] != null || Session["FromDate"] != null)
        {
            strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
            strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
            Response.Redirect("_auth.aspx");
        }
        if (!Page.IsPostBack)
        {
            Session["reportDocument"] = null;
            Session["RptData"] = null;

            setdefaultdate();
            DdlSpZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
            DdlSpZone.DataBind();
            DdlSpZone.Items.Insert(0, new ListItem("All Super Zone-", "0"));
            //Bind_DDL_SuperDuperZone();
            //ddlSDZone.Focus();
        }
        else
        {
            //if (ViewState["strSelectedSD"] != null && ViewState["strSelectedSD"].ToString() != ddlSDZone.SelectedValue.ToString())
            //{
            //    DDLSuperZone.SelectedIndex = 0;
            //}

        }
        if (txtIsExport.Value == "yes") {
            Bind();
            txtIsExport.Value = "";
        }

    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    #region Bind Data


    public void Bind_DDL_SuperDuperZone()
    {
        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("-ALL Super Duper Zone-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-ALL Super Zone-", "0"));
        DDLSuperZone.Focus();
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.Items.Clear();
        if (ddlSDZone.SelectedIndex != 0)
        {
            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Focus();
        }
        DDLSuperZone.Items.Insert(0, new ListItem("-All Super Zone-", "0"));

    }
    public void Bind_DDL_Zone()
    {
    }

    public void Bind_DDL_Customer()
    {
    }
    #endregion

    public void Bind()
    {

        DateTime frmDate = DateTime.Now;
        DateTime toDate = DateTime.Now;
        if (txtFromDate.Text.Split('/').Length > 1 && txttoDate.Text.Split('/').Length > 1)
        {

            try
            {
                frmDate = Convert.ToDateTime(txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2]);
                toDate = Convert.ToDateTime(txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2]);

            }
            catch (Exception ex)
            {
                txtFromDate.Text = "";
                txttoDate.Text = "";
                MessageBox("Date is incorrect");
                return;
            }
        }


        DataSet ds = new DataSet();
        try
        {

            if (Session["RptData"] == null)
            {
                ds = Others.OtherNewClass.Idv_Chetana_REP_Get_MonthlyGraph(frmDate, toDate, Convert.ToInt32(0), Convert.ToInt32(DdlSpZone.SelectedValue), 0, Convert.ToInt32(strFY), "sales", "", "", "");
                Session["RptData"] = ds;
            }
            else
            {
                ds = (DataSet)Session["RptData"];
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDocument rd;
                if (Session["reportDocument"] == null)
                {
                    rd = new ReportDocument();
                    Session["reportDocument"] = rd;
                }
                else
                {
                    rd = (ReportDocument)Session["reportDocument"];
                }
                if (ddlSDZone.SelectedIndex == 0)
                {
                    rd.Load(Server.MapPath("Report/MonthlyBarGraphSD.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath("Report/MonthlyBarGraph.rpt"));
                }
                rd.SetDataSource(ds.Tables[0]);
                rd.SetParameterValue("ReportType", "Sales(Net) Report for");
                //rd.SetParameterValue("SuperZone", DDLSuperZone.SelectedItem.Text.ToString());
                CrCollectionGraph.ReportSource = rd;
            }

            else
            {
                MessageBox("No Records found...");
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);

        }


    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        Session["RptData"] = null;
        Bind();
    }
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["strSelectedSD"] = ddlSDZone.SelectedValue;
        Bind_DDL_SuperZone();


    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_Zone();

    }
   
    public void setdefaultdate()
    {
        txtFromDate.Text = Session["FromDate"].ToString();
        txttoDate.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }
    private ReportDocument reportDocument;

    protected void CrCollectionGraph_Bind(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {

        Bind();
    }
    protected void CrCollectionGraph_Bind(object source, CrystalDecisions.Web.ViewerEventArgs e)
    {

        Bind();
    }
    protected void CrCollectionGraph_Bind(object source, CrystalDecisions.Web.SearchEventArgs e)
    {
        Bind();

    }
}
