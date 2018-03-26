using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustOutstanding : System.Web.UI.Page
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    string CustCode = "";
    #endregion

    #region Form Load Event
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
            //Response.Write(strFY);


        }

        if (!Page.IsPostBack)
        {
            txtFrom.Text = "01/04/201" + strFY + "";
            txtTo.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1) + "";
            txtInvoicedate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1) + "";
            if (ddlCustmore.SelectedValue.ToLower().ToString() == "0" || ddlCustmore.SelectedValue.ToLower().ToString() == "")
            {

            }
            else
            {
                // ShowDetails();

            }
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            pnlzone.Visible = false;
            pnlcustomer.Visible = true;
            btnSave.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            txtcustomer.Focus();

        }
        if (IsPostBack)
        {
            ShowDetails();
            if (rdbselect.SelectedValue == "Customer")
            {
               
                // if (txtcustomer.Text.ToString().Trim() != "")
                // {
                //     if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
                //     {
                //         ShowDetails();
                //     }
                // }
                //else
                // {
                //     if (ddlDetails.SelectedValue == "details")
                //     {
                //         MessageBox("Select Customer");
                //     }
                //     else
                //     {
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    ShowDetails();
                }
                // }
                // }
            }
            else
            {
                if (DDLSuperZone.SelectedValue != "0")
                {
                    if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
                    {
                        ShowDetails();
                    }
                }
                else
                {
                    //  MessageBox("Select SuperZone");
                }
            }
        }
    }
    #endregion

    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }


    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

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

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLZone.Focus();
            ddlCustmore.Items.Clear();
            //  DDLZone.SelectedValue = null;
            Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_Customer();
            ddlCustmore.Focus();
        }

    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }

    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Customer")
        {
            //  if (CustCode != "")
            //  {
            if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
            {
                ShowDetails();
            }
            //}
            //else
            //{
            //    if (ddlDetails.SelectedValue == "details")
            //    {
            //        MessageBox("Select Customer");
            //    }
            //    else
            //    {
            //        if (txtFrom.Text != "" && txtTo.Text != "")
            //        {
            //            ShowDetails();
            //        }
            //    }
            //}
        }
        else if (rdbselect.SelectedValue == "Analysis")
        {
            if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
            {
                ShowDetails();
            }
        }
        else
        {
            if (DDLSuperZone.SelectedValue != "0")
            {
                ShowDetails();
            }
            else
            {
                MessageBox("Select SuperZone");
            }
        }
    }

    public void ShowDetails()
    {
        if (ddlDetails.SelectedValue == "details")
        {

            DataSet ds = new DataSet();
            ds = Idv.Chetana.BAL.Specimen.Idv_Chetana_Customer_ZoneDate_Report(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
           Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), txtcustomer.Text.ToString().Split(':')[0].Trim(), rdbselectnull.SelectedValue.ToString() + "!" + (txtInvoicedate.Text.Split('/')[1] + "/" + txtInvoicedate.Text.Split('/')[0] + "/" + txtInvoicedate.Text.Split('/')[2]));
            //DataSet ds2 = new DataSet();
            // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
            DataView dv = new DataView(ds.Tables[0]);

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/CustomerZoneReport.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            // rd.Database.Tables[1].SetDataSource(dv2);
            //rd.SetDataSource(ds);
            CustomerReportView.ReportSource = rd;
        }
        else
        {
            DataSet ds1 = new DataSet();

            if (rdbselect.SelectedValue == "Analysis")
            {
                if (DDLSuperZone.SelectedValue != "0")
                {
                    ds1 = Other_Z.OtherBAL.Idv_Chetana_Customer_Outstanding_Report(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
                            Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), txtcustomer.Text.ToString().Split(':')[0].Trim(), 0, "c", rdbselectnull.SelectedValue.ToString());
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView(ds1.Tables[0]);
                        ReportDocument rd = new ReportDocument();
                        rd.Load(Server.MapPath("Report/OutstandingAnalysisReport.rpt"));
                        rd.Database.Tables[0].SetDataSource(dv);
                        CustomerReportView.ReportSource = rd;
                    }
                    else
                    {
                        message("Record not found");
                        return;
                    }
                }

            }
            else
            {
                //Add Invoice Date  Exmple   outstanding!03/31/2016

                ds1 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Customer_Summary_Report(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()), (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]), (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), Convert.ToInt32(strFY),
                Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), txtcustomer.Text.ToString().Split(':')[0].Trim(), 0, "c", rdbselectnull.SelectedValue.ToString() + "!" + (txtInvoicedate.Text.Split('/')[1] + "/" + txtInvoicedate.Text.Split('/')[0] + "/" + txtInvoicedate.Text.Split('/')[2]));
                DataView dv = new DataView(ds1.Tables[0]);
                // DataView dv2 = new DataView(ds2.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CustomerSummaryReport.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                // rd.Database.Tables[1].SetDataSource(dv2);
                //rd.SetDataSource(ds);
                CustomerReportView.ReportSource = rd;

            }

        }
    }

    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "Analysis")
        {
            pnlzone.Visible = true;
            pnlcustomer.Visible = false;
            DDLSuperZone.SelectedIndex = 0;
            DDLZone.SelectedIndex = 0;
            ddlCustmore.SelectedIndex = 0;
            ddlCustmore.Visible = false;
            lblCustomer.Visible = false;
            CustomerReportView.ReportSource = null;
            txtcustomer.Text = "";
            lblCustName.Text = "";
            DDLSuperZone.Focus();
        }
        else
            if (rdbselect.SelectedValue == "Area")
            {
                pnlzone.Visible = true;
                pnlcustomer.Visible = false;
                ddlCustmore.Visible = true;
                lblCustomer.Visible = true;
                DDLSuperZone.SelectedIndex = 0;
                DDLZone.SelectedIndex = 0;
                ddlCustmore.SelectedIndex = 0;
                CustomerReportView.ReportSource = null;
                txtcustomer.Text = "";
                lblCustName.Text = "";
                DDLSuperZone.Focus();
            }
            else
            {
                pnlzone.Visible = false;
                pnlcustomer.Visible = true;
                ddlCustmore.Visible = true;
                lblCustomer.Visible = true;
                txtcustomer.Text = "";
                lblCustName.Text = "";
                CustomerReportView.ReportSource = null;
                DDLSuperZone.SelectedIndex = 0;
                DDLZone.SelectedIndex = 0;
                ddlCustmore.SelectedIndex = 0;
                txtcustomer.Focus();
            }

    }

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = Idv.Chetana.BAL.DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            txtFrom.Focus();
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";

        }
    }
}