#region Name Sapce
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Idv.Chetana.BAL;
using Other_Z;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
#endregion

public partial class PANReport : System.Web.UI.Page
{
    #region Goloval Veriable
    string strChetanaCompanyName = "cppl";
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
            Bind_DDL_SuperZone();
            Bind_DDL_Zone();
            DDLSuperZone.Focus();

        }
        if (Page.IsPostBack)
        {
            if (Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()) != Convert.ToInt32("0"))
            {
                rdbAll.Checked = false;
                rdbAmount.Checked = false;
                txtAmount.Text = "";
                txtAmount.Visible = false;
            }
            else if (rdbAmount.Checked == true)
            {
                if (txtAmount.Text != "")
                {
                    DDLSuperZone.SelectedValue = "0";
                    DDLZone.SelectedValue = "0";
                    BindReport();
                }
                else
                {
                    DDLSuperZone.SelectedValue = "0";
                    DDLZone.SelectedValue = "0";
                }
            }
            else if (Convert.ToInt32(DDLZone.SelectedValue.ToString()) != Convert.ToInt32("0"))
            {
                BindReport();
            }
            else if (rdbAll.Checked == true)
            {
                DDLSuperZone.SelectedValue = "0";
                DDLZone.SelectedValue = "0";
                BindReport();
            }



        }
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

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
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
            rdbAll.Checked = false;
            rdbAmount.Checked = false;
            DDLZone.Focus();
        }
    }
    #endregion

    #region Print Data Method
    private void BindReport()
    {
        string All = "";
        int Amount = 0;
        if (rdbAll.Checked == true)
        {
            All = "All".ToString();
            DDLSuperZone.SelectedValue = "0";
            DDLZone.SelectedValue = "0";
        }
        else if (rdbAmount.Checked == true)
        {
            Amount = Convert.ToInt32(txtAmount.Text == "" ? "0" : txtAmount.Text);
            DDLSuperZone.SelectedValue = "0";
            DDLZone.SelectedValue = "0";
        }
        DataSet ds = OtherBAL.Idv_Chetana_PANReport(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), Convert.ToInt32(Session["FY"]), All, Amount.ToString(), "", "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/PANReport.rpt"));
            rd.SetDataSource(ds.Tables[0]);
            rd.SetParameterValue("SuperZoneName", DDLSuperZone.SelectedValue.ToString() == "0" ? "-" : DDLSuperZone.SelectedItem.Text);
            rd.SetParameterValue("ZoneName", DDLZone.SelectedValue.ToString() == "0" ? "-" : DDLZone.SelectedItem.Text);
            CrystalPanReport.ReportSource = rd;
        }
        else
        {
            MessageBox("No record found");
            DDLSuperZone.Focus();
            return;
        }
    }
    #endregion

    #region Amount Radio Button
    protected void rdbAmount_Selected(object sender, EventArgs e)
    {
        DDLSuperZone.SelectedValue = "0";
        DDLZone.SelectedValue = "0";
        txtAmount.Visible = true;
        txtAmount.Focus();
    }
    #endregion

    protected void rdbAll_Selected(object sender, EventArgs e)
    {
        DDLSuperZone.SelectedValue = "0";
        DDLZone.SelectedValue = "0";
        txtAmount.Text = "";
        txtAmount.Visible = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        rdbAll.Checked = false;
        rdbAmount.Checked = false;
        DDLSuperZone.SelectedValue = "0";
        DDLZone.SelectedValue = "0";
    }

    #region Get Button Click Event
    protected void Get_Click(object sender, EventArgs e)
    {
        BindReport();
    }
    #endregion
}