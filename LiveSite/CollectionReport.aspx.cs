#region NameSpace
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
using System.IO;
using System.Drawing;
#endregion

public partial class CollectionReport : System.Web.UI.Page
{
    #region Variables
    string docdate;
    string frdate;
    string todate;
    DateTime ddt;
    DateTime tdt;
    DateTime fdt;
    //string strChetanaCompanyName = "cppl";
    string strFY;
    int DocNo;
    ReportDocument crystalReport = new ReportDocument();
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            // strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
            strFY = Session["FY"].ToString();
            //  HidFY.Value = Session["FY"].ToString();
            //DateTime now = DateTime.Now;
            //now.ToString("dd/MM/yyyy");
            //txtFromDate.Text = new DateTime(now.Year, 1, now.Month).ToShortDateString();
            //txttoDate.Text = new DateTime(now.AddMonths(1).Year, now.AddMonths(1).Month, 1).ToShortDateString();
            //todate = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
            //txttoDate.Text = todate;
            btnexport.Visible = false;
        }
        else
        {
            Session.Clear();
        }

        if (!Page.IsPostBack)
        {
            //SetView();
            // BindBankRDetails();
            // DDLCCDD.Items.Insert(0, new ListItem("-Select-", "0"));

            //txtFromDate.Text = "01/04/201" + Convert.ToInt32(Session["FY"]).ToString();
            //txttoDate.Text = -"31/03/201" + Convert.ToInt32(Convert.ToInt32(Session["FY"]) + 1);


            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("All Super Zone-", "0"));
            //txtbankcoder.Focus();
            Session["Data"] = null;

        }
        else
        {
            if (rdWeek.Checked)
            {
                if (Session["Data"] != null)
                {
                    FillReport((DataView)Session["Data"]);
                }
            }
            else
            {
                collectionReportView.Visible = false;

            }
        }
    }
    #endregion

    #region Gridview Bind Method
    private void BindGrid()
    {
        try
        {
            frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
            todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

            tdt = Convert.ToDateTime(todate);
            fdt = Convert.ToDateTime(frdate);

            if (tdt >= fdt)
            {
                DataSet ds = new DataSet();
                if (rdWeek.Checked == true)
                {
                    ds = BankReceiptPayment.Idv_Chetana_REP_Collection_Report(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(strFY), fdt, tdt, "");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnexport.Visible = false;
                        DataView dv1 = new DataView(ds.Tables[0]);
                        Session["Data"] = dv1;
                        FillReport(dv1);
                    }
                    else
                    {
                        MessageBox("Records Not Available ");
                    }
                }
                else
                {
                    //ds = BankReceiptPayment.Idv_Chetana_REP_Collection_Report(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(strFY), fdt, tdt, "mc");
                    ds = Other_Z.OtherBAL.GetCollectionReport(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(strFY), fdt, tdt, ddlMonth.SelectedItem.Value);
                    Session["month"] = ds;
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        months.DataSource = ds.Tables[1];
                        months.DataBind();
                        btnexport.Visible = true;
                        //DataView dv = new DataView(ds.Tables[0]);
                        //dv.RowFilter = "months=" + 3;

                        //Monthgrid.DataSource = dv;
                        //Monthgrid.DataBind();
                    }
                    else
                    {
                        MessageBox("Records Not Available ");
                    }
                }
            }
            else
            {
                MessageBox("From Date is greater than To Date");
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            //txtbankcoder.Focus();

        }
    }
    #endregion
    protected void rdMonth_CheckedChanged(object sender, EventArgs e)
    {
        ddlMonth.Visible = true;
    }
    protected void rdWeek_CheckedChanged(object sender, EventArgs e)
    {
        ddlMonth.Visible = false;
    }

    #region Get Button Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool Flag = false;
        try
        {
            frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
            todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

            if (Convert.ToDateTime(frdate) >= Convert.ToDateTime("201" + Convert.ToInt32(Session["FY"]) + "/01/04"))
            {
                Flag = true;
            }
            else
            {
                MessageBox("Invalid from date");
                txtFromDate.Focus();
                Flag = false;
                return;
            }
            if (Convert.ToDateTime(todate) <= Convert.ToDateTime("03/31/201" + Convert.ToInt32(Convert.ToInt32(Session["FY"]) + 1)))
            {
                Flag = true;
            }
            else
            {
                MessageBox("Invalid to date");
                txttoDate.Focus();
                Flag = false;
                return;
            }
            if (Flag)
            {
                BindGrid();
            }

        }
        catch (Exception ex)
        {

            throw;
        }

    }
    #endregion

    #region Export Button Click Event
    protected void btnexport_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", txtFromDate.Text + "-" + txttoDate.Text + ".xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //Monthgrid.AllowPaging = false;
        BindGrid();
        //Change the Header Row back to white color
        //Applying stlye to gridview header cells
        //for (int i = 0; i < months.HeaderStyle.BackColor.R i++)
        //{
        //    Monthgrid.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        //}
        months.RenderControl(htw);
        string headerTable = @"<Table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td style=font-size:x-large;color:blue;text-align:center>Collection reced agst Target for the month</td></tr></Table>";
        string Date = @"<Table><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td style=font-size:small;color:red;text-align:center;>" + txtFromDate.Text + " " + "To" + " " + txttoDate.Text + "</td></tr></Table>";
        Response.Write(headerTable);
        Response.Write(Date);
        Response.Write(sw.ToString());
        Response.End();
    }
    #endregion

    #region Export File Saport Method
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    #endregion

    double grQtyTotal = 0;
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlMonth.SelectedItem.Value == "mcSummary" && rdMonth.Checked==true)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //storid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "stor_id").ToString());
                double tmpTotal = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "totaloutstanding").ToString());
                grQtyTotal += tmpTotal;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = grQtyTotal.ToString();
                grQtyTotal = 0;
            }
        }
    }

    #region Report Show
    public void FillReport(DataView dt)
    {
        //if (DDLSuperZone.SelectedValue.ToString() == "0")
        //{
        //    crystalReport.Load(Server.MapPath("Report/CollectionReport_Summary.rpt"));
        //    crystalReport.SetDataSource(dt);
        //}
        //else
        //{
        //    crystalReport.Load(Server.MapPath("Report/CollectionReport.rpt"));
        //    crystalReport.SetDataSource(dt);
        //}
        crystalReport.Load(Server.MapPath("Report/CollectionReport.rpt"));
        crystalReport.SetDataSource(dt);
        collectionReportView.ReportSource = crystalReport;
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion


    protected void collectionReportView_Unload(object sender, EventArgs e)
    {
        crystalReport.Close();
        crystalReport.Dispose();
    }
    protected void months_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        GridView gv = (GridView)e.Item.FindControl("Monthgrid");
        DataView dv = new DataView(((DataSet)Session["month"]).Tables[0]);
        dv.RowFilter = "months = " + ((Label)e.Item.FindControl("lblmonth")).Text;
        gv.DataSource = dv.ToTable();
        gv.DataBind();

    }
}
