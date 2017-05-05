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
using Others;

public partial class UserControls_Loan_C_I_CommissionReport : System.Web.UI.UserControl
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    string CustCode = "";
    #endregion
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
            //Response.Write(strFY);
            

        }

        if (Session["DataFillCommission"] != null)
        {
            ShowDetails(0);
        }

    }

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

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("< Select SuperZone -", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails(1);
    }

    public void ShowDetails(int Showata)
    {
        

        DataSet ds = new DataSet();

        if (RdbtnSelect.SelectedValue == "Commission_Report")
        {

            if (Showata == 1)
            {
                Session["DataFillCommission"] = null;
            }
            if (Session["DataFillCommission"] == null)
            {
                ds = LoanPartyMaster.Report_Commision(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()),
                          (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY));
                Session["DataFillCommission"] = ds;


            }
            ds = (DataSet)Session["DataFillCommission"];

            //DataSet ds2 = new DataSet();
            // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/CommissionReport.rpt"));
            //if (ds.Tables[1].Rows.Count > 0)
            {
                rd.Database.Tables[0].SetDataSource(ds.Tables[0]);
                rd.Database.Tables[1].SetDataSource(ds.Tables[1]);
                //rd.Database.Tables[1].SetDataSource(ds.Tables[1]);
                // rd.Database.Tables[1].SetDataSource(dv2);
                //rd.SetDataSource(ds);

            }
            //else
           //{
                //if (Showata == 1)
               // {
                   // MessageBox("Target yet not set to selected Zone");
             // }
            //}
            CustomerReportView.ReportSource = rd;
        }
        else
        {
            int szone=0;
            if (DDLSuperZone.SelectedIndex == 0)
            {
                szone = 0;
            }
            else
            {
                szone = Convert.ToInt32(DDLSuperZone.SelectedValue.ToString());
            }


            ds = OtherClass.Idv_Chetana_Report_Comm(szone, 0,
                      (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY));

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Report/CommissionReport_Summary.rpt"));
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                rd.SetDataSource(ds.Tables[0]);
                rd.SetParameterValue("FDate", txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]);
                rd.SetParameterValue("TDate", txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]);
            }
            else
            {
                if (Showata == 1)
                {
                    MessageBox("Target yet not set to selected Zone");
                }
            }
            CustomerReportView.ReportSource = rd;

        }
    }

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
    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "Commission_Report")
        {
            ViewState["Bkwise"] = null;
            DDLZone.Visible = true;
            lblzone.Visible = true;
        }
        if (RdbtnSelect.SelectedValue == "Commission_Summary")
        {
            DDLZone.Visible = false;
            lblzone.Visible = false;
        }
    }
}
