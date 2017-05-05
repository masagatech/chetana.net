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
using System.Globalization;
using Idv.Chetana.BAL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class Godown_Get_Railway : System.Web.UI.UserControl
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    string fdcno = string.Empty;
    string tdcno = string.Empty;
    #endregion

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
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {

            ViewState["DocNoRep"] = null;
           
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();

            //Session["getpasstempdata"] = null;
            //grdTemp.DataSource = null;
            //grdTemp.DataBind();

        }
        else
        {
            fillDataDocNo(0);

        }
    }




    protected void btnget_Click(object sender, EventArgs e)
    {

        fillDataDocNo(1);


    }







    public void fillDataDocNo(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";

        string strReportPath;
        strReportPath = "Godown/reports/RailDateReport.rpt"; 

        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {

            DataSet ds = new DataSet();

            if (rdoview.Items[0].Selected == true)
            {
                fdcno = txtfdocno.Text.Trim();
                tdcno = txttdocno.Text.Trim();
                ds = G_GetPass.Railway_Report("dcno-"+ DDLSuperZone.SelectedValue.ToString() , Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY));
            }
            else if (rdoview.Items[1].Selected == true)
            {
                strReportPath = "Godown/reports/RailDateReport_onlyDate.rpt"; 
                DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
                DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);
                ds = G_GetPass.Railway_Report("-"+ DDLSuperZone.SelectedValue.ToString(), 0, 0, _objfdate, _objtdate, Convert.ToInt32(strFY));

            }
            else if (rdoview.Items[2].Selected == true)
            {
                fdcno = txtfdocno.Text.Trim();
                tdcno = txttdocno.Text.Trim();
                ds = G_GetPass.Railway_Report("orgdcno-" + DDLSuperZone.SelectedValue.ToString(), Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY));
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

            }
            catch
            {


            }
        }
    }

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
            txtfromdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txttodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

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

    //#region Text changed event

    //protected void txtCust_TextChanged(object sender, EventArgs e)
    //{
    //    callTextChange();

    //}

    //protected void btnAddRecords_Click(object sender, EventArgs e)
    //{
    //    grdTemp.DataSource = fillTempBookData(txtCust.Text.ToString().Split(':')[0].Trim());
    //    grdTemp.DataBind();
    //    clearStrip();
    //    txtCust.Focus();
    //}

    //#endregion

    //#region cust Text Change

    //public void callTextChange()
    //{
    //    string CustCode = txtCust.Text.ToString().Split(':')[0].Trim();

    //    DataTable dt = new DataTable();
    //    dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

    //    if (dt.Rows.Count != 0)
    //    {
    //        if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
    //        {
    //            lblCustomer.Text = Convert.ToString(dt.Rows[0]["CustName"]);
    //            txtCust.Text = CustCode;
    //            lblCustID.Text = Convert.ToString(dt.Rows[0]["CustID"]);
    //            txtCust.Focus();

    //        }
    //        else
    //        {
    //            lblCustomer.Text = "Customer is blacklisted";
    //            txtCust.Focus();
    //            txtCust.Text = "";

    //        }
    //    }
    //    else
    //    {
    //        lblCustomer.Text = "No such Customer code";
    //        txtCust.Focus();
    //        txtCust.Text = "";

    //    }
    //}



    //#endregion



    //public void clearStrip()
    //{

    //    txtCust.Text = "";
    //    lblCustomer.Text = "";
    //    lblCustID.Text = "";


    //}

    //protected void btnClearEdit_Click(object sender, EventArgs e)
    //{
    //    clearStrip();

    //}



    //#region TEMP DATA

    //public DataTable fillTempBookData(string Cust)
    //{
    //    DataTable dt1 = new DataTable();
    //    dt1 = DCMaster.Get_Name(Cust, "Customer").Tables[0];
    //    DataTable dt = new DataTable();
    //    if (Session["getpasstempdata"] == null)
    //    {
    //        //CREATE NEW DATATABLE

    //        dt.Columns.Add("SCHL_ID");
    //        dt.Columns.Add("SCHL_NAME");
    //        dt.Columns.Add("SCHL_AREA");
    //        dt.Columns.Add("ID");

    //    }
    //    else
    //    {
    //        dt = (DataTable)Session["getpasstempdata"];
    //    }

    //    dt.Rows.Add(dt1.Rows[0]["CustCode"].ToString(), dt1.Rows[0]["CustName"].ToString(), dt1.Rows[0]["AreaName"].ToString(), dt1.Rows[0]["CustID"].ToString());

    //    Session["getpasstempdata"] = dt;
    //    return dt;

    //}

    //#endregion

    //#region MsgBox

    //public void MessageBox(string msg)
    //{
    //    string jv = "alert('" + msg + "');";
    //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    //}

    //public void loder(string msg, string timetohid)
    //{
    //    string jv = "autosloder('" + msg + "'," + timetohid + ");";
    //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    //}

    //#endregion

    //#region Delete temp data


    //protected void grdTemp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    DataTable dt1 = new DataTable();
    //    dt1 = (DataTable)Session["getpasstempdata"];
    //    dt1.Rows[e.RowIndex].Delete();
    //    grdTemp.DataSource = dt1;
    //    grdTemp.DataBind();
    //    upDetails.Update();
    //    Session["getpasstempdata"] = dt1;
    //    loder("Successfully Deleted...", "3000");


    //}

    //#endregion 


    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
}
