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
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_Loan_C_I_interestReport : System.Web.UI.UserControl
{
    #region Variables

    string strChetanaCompanyName = "cppl";
    string strFY;


    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtEMcode.Focus();
            Session["loantempdata"] = null;

            if (Session["FY_Text"] != null)
            {
                txtFromDate.Text = "01/04/" + Session["FY_Text"].ToString().Split('-')[0];
                txtToDate.Text = "31/03/" + Session["FY_Text"].ToString().Split('-')[1];
            }
        }
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                //  strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                //  strFY = Session["FY"].ToString();
                strFY = Session["FY"].ToString();

                //FP.InnerHtml = Session["FY_Text"].ToString();
                //spnYear.InnerHtml = Session["FY_Text"].ToString().Split('-')[0];

            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);
            if (Session["DataFill"] != null)
            {
                fillData();
            }
        }

    }

    #region Button Add Event

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string ECode = txtEMcode.Text.ToString().Split(':', '[', ']')[0].Trim();
        // string flag = txtEMcode.Text.ToString().Split(':', '[', ']')[3].Trim();
        string Code = "";
        if (rdoSelection.SelectedValue == "b")
        {
            Code = ECode + "#" + rdoSelection.SelectedValue.ToString();
        }
        else
        {
            Code = ECode;
        }
        grdTEmpData.DataSource = fillTempBookData(Code);
        grdTEmpData.DataBind();
        if (grdTEmpData.Rows.Count > 0)
        {
            getDetails.Enabled = true;
        }
        else
        {
            getDetails.Enabled = false;
        }
        txtEMcode.Text = "";
        txtEMcode.Focus();
        upCodeUpdate.Update();

    }

    #endregion

    #region TEMP DATA


    public DataTable fillTempBookData(string Accode)
    {
        DataTable dt = new DataTable();
        if (Session["loantempdata"] == null)
        {
            //CREATE NEW DATATABLE
            dt.Columns.Add("AccountCode");
            dt.Columns.Add("AccName");
            dt.Columns.Add("Interest");
        }
        else
        {
            setHistoryView();
            dt = (DataTable)Session["loantempdata"];
        }


        DataView dv = new DataView(dt);
        dv.RowFilter = "AccountCode = '" + Accode + "'";
        if (dv.ToTable().Rows.Count > 0)
        {
            MessageBox("Already Exist!!!");
        }
        else
        {

            DataTable dt1 = new DataTable();
            dt1 = AccountMain.ACCodeGet(Accode).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows.Count > 1)
                {
                    for (int i = 0; i < dt1.Rows.Count ; i++)
                    {
                        dv.RowFilter = "AccountCode = '" + dt1.Rows[i]["Ac_Code"].ToString() + "'";
                        if (dv.ToTable().Rows.Count <= 0)
                        {
                            dt.Rows.Add(dt1.Rows[i]["Ac_Code"].ToString(), dt1.Rows[i]["Ac_Name"].ToString(), dt1.Rows[i]["Ac_int_Rat"].ToString());
                        }

                    }

                }
                else
                {
                    dt.Rows.Add(Accode, dt1.Rows[0]["Ac_Name"].ToString(), dt1.Rows[0]["Ac_int_Rat"].ToString());
                }
            }
            else
            {
                MessageBox("Record not found!!!");
            }
        }

        Session["loantempdata"] = dt;

        return dt;
    }


    #endregion

    #region MsgBox

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

    #region Delete temp data

    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["loantempdata"];
        dt1.Rows[e.RowIndex].Delete();
        grdTEmpData.DataSource = dt1;
        grdTEmpData.DataBind();
        Session["loantempdata"] = dt1;
        loder("Successfully Deleted...", "3000");
        if (grdTEmpData.Rows.Count > 0)
        {
            getDetails.Enabled = true;
        }
        else
        {
            getDetails.Enabled = false;
        }
        txtEMcode.Text = "";
        txtEMcode.Focus();
        upCodeUpdate.Update();



    }

    #endregion

    #region Call report

    protected void btnGenerateRep_Click(object sender, EventArgs e)
    {
        if (grdTEmpData.Rows.Count > 0)
        {
            fillData();
        }
        else
        {
            MessageBox("Kindly select party account");
            txtEMcode.Focus();
        }
    }

    public void fillData()
    {
        Session["DataFill"] = null;

        string Fromdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string Todate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        Label lblAccount = null;
        TextBox txt = null;
        string accode = "";
        foreach (GridViewRow row in grdTEmpData.Rows)
        {
            lblAccount = (Label)row.FindControl("lblCode");
            txt = (TextBox)row.FindControl("txtIntRate");

            accode = accode + lblAccount.Text.Trim() + "-" + txt.Text.Trim() + ",";

        }

        if (Session["DataFill"] == null)
        {
            Session["DataFill"] = LoanPartyMaster.Report_LoanInterest(accode,
                Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate), Convert.ToInt32(strFY), txtDays.Text.Trim(), "LG02").Tables[0];
        }

        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("Report/interestCalc.rpt"));

        crystalReport.SetDataSource((DataTable)Session["DataFill"]);
        if (grdTEmpData.Rows.Count > 0)
        {
            crtIntrest.ReportSource = crystalReport;
        }
    }

    public void setHistoryView()
    {
        Label lblAccount = null;
        TextBox txt = null;
        Label lblName = null;

        DataTable dt = new DataTable();
        Session["loantempdata"] = null;
        if (Session["loantempdata"] == null)
        {
            //CREATE NEW DATATABLE
            dt.Columns.Add("AccountCode");
            dt.Columns.Add("AccName");
            dt.Columns.Add("Interest");
        }
        foreach (GridViewRow row in grdTEmpData.Rows)
        {
            lblAccount = (Label)row.FindControl("lblCode");
            lblName = (Label)row.FindControl("lblName");
            txt = (TextBox)row.FindControl("txtIntRate");
            dt.Rows.Add(lblAccount.Text.Trim(), lblName.Text.Trim(), txt.Text.Trim());
        }

        Session["loantempdata"] = dt;

    }

    #endregion
    protected void rdoSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSelection.SelectedIndex == 0)
        { cust_AutoCompleteExtender.ContextKey = "ACCUSL"; }
        else
        { cust_AutoCompleteExtender.ContextKey = "ACCBRK"; }
        txtEMcode.Focus();


    }
}
