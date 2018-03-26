using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Idv.Chetana.Common;
using Idv.Chetana.BAL;
using Idv.Chetana.CnF;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using Other_Z;

public partial class CNFRailwayRegister : System.Web.UI.Page
{
    #region Goloval Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    string fdcno = string.Empty;
    string tdcno = string.Empty;
    Other_Z.OtherBAL ObjDAL = new OtherBAL();
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
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!Page.IsPostBack)
        {

            ViewState["DocNoRep"] = null;

            GetSuperZone();
            DDLSuperZone.Focus();
        }
        else
        {
           fillDataDocNo(0);
        }
    }
    #endregion

    #region Fill Data Genrate Click Event
    public void fillDataDocNo(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";

        string strReportPath;
        strReportPath = "Godown/reports/RailDateReportCnF.rpt";

        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {

            DataSet ds = new DataSet();

            if (rdoview.Items[0].Selected == true)
            {
                fdcno = txtfdocno.Text.Trim();
                tdcno = txttdocno.Text.Trim();
                ds = ObjDAL.Idv_Chetana_G_Railway_Report_CnF(Convert.ToInt32(DDLSuperZone.SelectedValue), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), "Doc", Convert.ToInt32(strFY));
            }
            else
            if (rdoview.Items[1].Selected == true)
            {
                strReportPath = "Godown/reports/RailDateReport_onlyDateCnF.rpt";
                DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
                DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);
                ds = ObjDAL.Idv_Chetana_G_Railway_Report_CnF(Convert.ToInt32(DDLSuperZone.SelectedValue), _objfdate, _objtdate, 0, 0, "datewise", Convert.ToInt32(strFY));

            }
            else if (rdoview.Items[2].Selected == true)
            {
                fdcno = txtfdocno.Text.Trim();
                tdcno = txttdocno.Text.Trim();
                ds = ObjDAL.Idv_Chetana_G_Railway_Report_CnF(Convert.ToInt32(DDLSuperZone.SelectedValue), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), "", Convert.ToInt32(strFY));
            }

            ViewState["DocNoRep"] = ds.Tables[0];
        }
        if (ViewState["DocNoRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath(strReportPath));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["DocNoRep"]);
                RailwayDocNo.ReportSource = rd;
                rd.SetParameterValue("@CnfName", DDLSuperZone.SelectedItem.ToString());

            }
            catch
            {


            }
        }
    }
    #endregion

    #region Button Get Click Event
    protected void btnget_Click(object sener, EventArgs e)
    {
        fillDataDocNo(1);
    }
    #endregion
   
    #region Redio Button Seleted Event
    protected void rdoview_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoview.Items[0].Selected == true)
        {

            txtfdocno.Focus();
            //pnlFormDetail.Visible = false;
            pnldate.Visible = false;
            pnldocno.Visible = true;
            txtfdocno.Text = "";
            txttdocno.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            RailwayDocNo.ReportSource = null;
            pnldocno.GroupingText = "Enter Doc No";
            Label1.Text = "From Doc No";
            Label2.Text = "To Doc No";
        }
        else if (rdoview.Items[1].Selected == true)
        {

            txtfromdate.Focus();
            txtfromdate.TabIndex = 1;
            txttodate.TabIndex = 2;
            btnget.TabIndex = 3;
            //pnlFormDetail.Visible = false;
            pnldate.Visible = true;
            pnldocno.Visible = false;
            txtfdocno.Text = "";
            txttdocno.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            RailwayDocNo.ReportSource = null;
            txtfromdate.Text = "01/04/201" + Convert.ToInt32(strFY).ToString(); //System.DateTime.Now.ToString("dd/MM/yyyy");
            txttodate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1); //System.DateTime.Now.ToString("dd/MM/yyyy");

        }
        else
            if (rdoview.Items[2].Selected == true)
            {

                txtfdocno.Focus();
                //pnlFormDetail.Visible = false;
                pnldate.Visible = false;
                pnldocno.Visible = true;
                txtfdocno.Text = "";
                txttdocno.Text = "";
                txtfromdate.Text = "";
                txttodate.Text = "";
                RailwayDocNo.ReportSource = null;
                pnldocno.GroupingText = "Enter DC No";
                Label1.Text = "From DC No";
                Label2.Text = "To DC No";
            }
    }
    #endregion

    #region Dropdown Bind
    public void GetSuperZone()
    {
        DDLSuperZone.DataSource = BindCnFGrid("ddlCnF", 0).Tables[0];
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-- Select CnF --", "0"));
    }
    #endregion

    #region Dropdown Method
    public DataSet BindCnFGrid(string Flag, int Id)
    {
        DataSet ds = new DataSet();
        CnFCustomer objcs = new CnFCustomer();
        objcs.Remark1 = Flag;
        objcs.CnFID = Id;
        ds = objcs.GetCnF_Master();
        return ds;
    }
    #endregion
}