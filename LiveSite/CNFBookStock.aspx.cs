using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.CnF;

public partial class CNFBookStock : System.Web.UI.Page
{
    #region Goloval veriable
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                if (!IsPostBack)
                {
                    GetSuperZone();
                    DDLCnf.Focus();
                }
            }
            else
            {
                Session.Clear();
            }
        }
        else
        {
            Session.Clear();
        }
        if (Page.IsPostBack)
        {
            if (DDLCnf.SelectedValue.ToString() != "0" && txtbook.Text != "")
            {
                GetPrint();
            }
        }
    }
    #region Dropdown Bind
    public void GetSuperZone()
    {
        DDLCnf.DataSource = BindCnFGrid("ddlCnF", 0).Tables[0];
        DDLCnf.DataBind();
        DDLCnf.Items.Insert(0, new ListItem("--Select CnF--", "0"));
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

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Print Method
    private void GetPrint()
    {
        string BookCode = txtbook.Text.Split(':')[0].ToString();
        string from;
        string To;
        from = "04/01/2014";
        To = "04/01/2014";
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(To);
        DataSet ds = Other_Z.OtherBAL.C_IDV_Chetana_REP_STOCK_Get(DDLCnf.SelectedValue.ToString(), FromDate, ToDate, Convert.ToInt32(Session["FY"]), BookCode,"CNFBook");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/BookStockReport.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            rd.SetParameterValue("CNF", DDLCnf.SelectedItem.Text);
            rd.SetParameterValue("Book", txtbook.Text);
            BookStokeReport.ReportSource = rd;
        }
        else
        {
            MessageBox("Record not found");
            DDLCnf.Focus();
            return;
        }
    }
    #endregion

    protected void btnGet_Click(object sender, EventArgs e)
    {
        GetPrint();
    }
}