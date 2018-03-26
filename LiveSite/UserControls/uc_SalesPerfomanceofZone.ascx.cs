#region NameSpaces
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
using System.Web.Services;
using Idv.Chetana.BAL;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Text;


#endregion

public partial class UserControls_uc_SalesPerfomanceofZone : System.Web.UI.UserControl
{
    #region Variables
    int Active, twenty, twentyfive, thirty, thirtyfive, forty, zero;
    decimal grossamt;
    int nonActive;
    decimal billamt, cnamt, recdamt, totalbalance, openbalance, otherdebitAmount;
    string strChetanaCompanyName = "cppl";
    string strFY;
    DataSet stDS;
    DateTime fdate;
    DateTime tdate;
    DataTable dtAll;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["FY"] != null)
            {
                
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

       

        if (!Page.IsPostBack)
        {
            ddlSDZone.Focus();

            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Items.Insert(0, new ListItem("-Select Super Duper Zone-", "0"));

            DDLsuperzone.Focus();
            setdefaultdate();
        }
      
    }
    public void setdefaultdate()
    {
        txtfromDate.Text = Session["FromDate"].ToString();
        txtToDate.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }

    protected void grdoutstanding_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string zoneid = ((Label)grdoutstanding.Rows[e.NewEditIndex].FindControl("lblzoneid")).Text;
        grdemployee.Visible = false;
        DataTable dt = new DataTable();
        dt = Other.Dashboard.Get_Report_SalesPerformance_OnEmployee(Convert.ToInt32(zoneid)).Tables[0];
        //grdemployee.DataSource = Other.Dashboard.Get_Report_SalesPerformance_OnEmployee(Convert.ToInt32(zoneid)).Tables[0];
        //grdemployee.DataBind();
        string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);

        grdcustomer.DataBind();
        grdemployee.Visible = false;
        //    lblgrdcustomer.Text = "";
        if (dt.Rows.Count > 0)
        {   // lblname
            string empid = dt.Rows[0]["empid"].ToString();
            DataTable dtcustomer = new DataTable();
            dtcustomer = Other.Dashboard.Get_Report_SalesPerformance_OnCustomer(Convert.ToInt32(zoneid), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
            grdcustomer.DataSource = dtcustomer;
            grdcustomer.DataBind();
            grdcustomer.Focus();
            dtAll.Merge(dtcustomer);
          //  grdzonedetail.DataSource = Other.Dashboard.Get_Report_SalesPerformance_OnCustomer(Convert.ToInt32(empid), Convert.ToInt32(strFY), fdate, tdate).Tables[1];
         //   grdzonedetail.DataBind();
            DataTable dtbookSet = new DataTable();
            dtbookSet = Other.Dashboard.Get_Report_SalesPerformanceForBookSet(Convert.ToInt32(zoneid), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
            GrdBookset.DataSource = dtbookSet;
            GrdBookset.DataBind();
            dtAll.Merge(dtbookSet);
            if (grdcustomer.Rows.Count > 0)
            {
                lblgrdemployee.Text = ((Label)grdoutstanding.Rows[e.NewEditIndex].FindControl("lblzonecode")).Text;
                lblgrdcustomer.Text = dt.Rows[0]["empcode"].ToString();
                lblcustomername.Text = dt.Rows[0]["Empname"].ToString();
            }
            else
            {
                lblgrdcustomer.Text = "";
            }
            lblgrdemployee.Text = ((Label)grdoutstanding.Rows[e.NewEditIndex].FindControl("lblzonecode")).Text + " : ";
        }
        else
        {
            lblgrdemployee.Text = "";
        }

    }
    protected void grdemployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string empid = ((Label)grdemployee.Rows[e.NewEditIndex].FindControl("lblempid")).Text;

        // string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        //string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        //fdate = Convert.ToDateTime(from);
        //tdate = Convert.ToDateTime(To);

        //grdemployee.SelectedRow.BackColor  ;
        //grdcustomer.DataSource = Other.Dashboard.Get_Report_SalesPerformance_OnCustomer(Convert.ToInt32(empid), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
        //grdcustomer.DataBind();
        
        //if (grdcustomer.Rows.Count > 0)
        //{
        //    lblgrdcustomer.Text = ((Label)grdemployee.Rows[e.NewEditIndex].FindControl("lblempcode")).Text;
        //}
        //else
        //{
        //    lblgrdcustomer.Text = "";
        //}
    }
    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");

            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();

            DDLsuperzone.Items.Clear();
            DDLsuperzone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLsuperzone.Focus();
        }
    }
    public void Bind_DDL_SuperZone()
    {
        //DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
        DDLsuperzone.DataSource  = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLsuperzone.DataBind();
        DDLsuperzone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
      
    }

     


    protected void grdcustomer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblbillamt1;
        Label lblopbal1;
        Label lblcnamt1;
        Label lblRecdamt1;
        Label lblbalance1;
        Label lbltarper;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            billamt = openbalance = cnamt = recdamt = totalbalance = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblbillamt1 = (Label)e.Row.FindControl("lblBillamt");
            billamt = billamt + Convert.ToDecimal(lblbillamt1.Text.Trim());
            lblopbal1 = (Label)e.Row.FindControl("lblopeningbalance");
            openbalance = openbalance + Convert.ToDecimal(lblopbal1.Text.Trim());
            lblcnamt1 = (Label)e.Row.FindControl("lblCNamt");
            cnamt = cnamt + Convert.ToDecimal(lblcnamt1.Text.Trim());
            lblRecdamt1 = (Label)e.Row.FindControl("lblRecdamt");
            recdamt = recdamt + Convert.ToDecimal(lblRecdamt1.Text.Trim());
            lblbalance1 = (Label)e.Row.FindControl("lbltotalBalance");
            lbltarper = (Label)e.Row.FindControl("lblTargetAchpercent");
            totalbalance = totalbalance + Convert.ToDecimal(lblbalance1.Text.Trim());
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalbillamt1 = (Label)e.Row.FindControl("lbltotalBillamt");
            lbltotalbillamt1.Text = billamt.ToString().Trim();
            Label lbltotalopbal1 = (Label)e.Row.FindControl("lbltotalopbal");
            lbltotalopbal1.Text = openbalance.ToString().Trim();
            Label lbltotalcnamt1 = (Label)e.Row.FindControl("lbltotalCNamt");
            lbltotalcnamt1.Text = cnamt.ToString().Trim();
            Label lbltotalrecdamt1 = (Label)e.Row.FindControl("lbltotalRecdamt");
            lbltotalrecdamt1.Text = recdamt.ToString().Trim();
            Label lbltotaltotalbalance1 = (Label)e.Row.FindControl("lbltotalbal");
            lbltotaltotalbalance1.Text = totalbalance.ToString().Trim();
        }

    }
    protected void grdemployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    Label lblbillamt;
    Label lblopbal;
    Label lblcnamt;
    Label lblRecdamt;
    Label lblbalance;
    Label lblotherdebitAmt;
    protected void grdoutstanding_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            billamt = openbalance = cnamt = recdamt = totalbalance = otherdebitAmount =  0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblbillamt = (Label)e.Row.FindControl("lblBillamt");
            billamt = billamt + Convert.ToDecimal(lblbillamt.Text.Trim());
            lblopbal = (Label)e.Row.FindControl("lblopeningbalance");
            openbalance = openbalance + Convert.ToDecimal(lblopbal.Text.Trim());
            lblcnamt = (Label)e.Row.FindControl("lblCNamt");
            cnamt = cnamt + Convert.ToDecimal(lblcnamt.Text.Trim());
            lblRecdamt = (Label)e.Row.FindControl("lblRecdamt");
            recdamt = recdamt + Convert.ToDecimal(lblRecdamt.Text.Trim());
            lblbalance = (Label)e.Row.FindControl("lbltotalBalance");
            totalbalance = totalbalance + Convert.ToDecimal(lblbalance.Text.Trim());
            lblotherdebitAmt = (Label)e.Row.FindControl("lblOtherAmount");
            otherdebitAmount = otherdebitAmount + Convert.ToDecimal(lblotherdebitAmt.Text.Trim());
            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalbillamt = (Label)e.Row.FindControl("lbltotalBillamt");
            lbltotalbillamt.Text = billamt.ToString().Trim();
            Label lbltotalopbal = (Label)e.Row.FindControl("lbltotalopbal");
            lbltotalopbal.Text = openbalance.ToString().Trim();
            Label lbltotalcnamt = (Label)e.Row.FindControl("lbltotalCNamt");
            lbltotalcnamt.Text = cnamt.ToString().Trim();
            Label lbltotalrecdamt = (Label)e.Row.FindControl("lbltotalRecdamt");
            lbltotalrecdamt.Text = recdamt.ToString().Trim();
            Label lbltotaltotalbalance = (Label)e.Row.FindControl("lbltotalbal");
            lbltotaltotalbalance.Text = totalbalance.ToString().Trim();

            Label lbltotalOtherAmount = (Label)e.Row.FindControl("lbltotalOtherAmount");
            lbltotalOtherAmount.Text = otherdebitAmount.ToString().Trim();
        }
    }

    //protected void grdtargetdetail_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //    }
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //    }
    //}
    Label lblactive;
    Label lblnonactive;

    protected void grdnoofparty_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Active = 0;
            nonActive = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblactive = (Label)e.Row.FindControl("lblActive");
            lblnonactive = (Label)e.Row.FindControl("lblNonactive");

            Active = Active + Convert.ToInt32(lblactive.Text.Trim());
            nonActive = nonActive + Convert.ToInt32(lblnonactive.Text.Trim());
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalactive = (Label)e.Row.FindControl("lbltotalactive");
            Label lbltotalnonactive = (Label)e.Row.FindControl("lbltotalNonactive");
            lbltotalactive.Text = Active.ToString().Trim();
            lbltotalnonactive.Text = nonActive.ToString().Trim();
        }
    }

    Label lbltwenty, lbltwentyfive, lblthirty, lblthirtyfive, lblforty, lblzero;
    protected void GrdDiscount_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            twenty = twentyfive = thirty = thirtyfive = forty = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lbltwenty = (Label)e.Row.FindControl("lbltwenty");
            lbltwentyfive = (Label)e.Row.FindControl("lbltwentyfive");
            lblthirty = (Label)e.Row.FindControl("lblthirty");
            lblthirtyfive = (Label)e.Row.FindControl("lblthirtyfive");
            lblforty = (Label)e.Row.FindControl("lblforty");
            lblzero = (Label)e.Row.FindControl("lblzero");

            twenty = twenty + Convert.ToInt32(lbltwenty.Text.Trim());
            twentyfive = twentyfive + Convert.ToInt32(lbltwentyfive.Text.Trim());
            thirty = thirty + Convert.ToInt32(lblthirty.Text.Trim());
            thirtyfive = thirtyfive + Convert.ToInt32(lblthirtyfive.Text.Trim());
            forty = forty + Convert.ToInt32(lblforty.Text.Trim());
            zero = zero + Convert.ToInt32(lblzero.Text.Trim());
            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotaltwenty = (Label)e.Row.FindControl("lbltotaltwenty");
            Label lbltotaltwentyfive = (Label)e.Row.FindControl("lbltotaltwentyfive");
            Label lbltotalthirty = (Label)e.Row.FindControl("lbltotalthirty");
            Label lbltotalthirtyfive = (Label)e.Row.FindControl("lbltotalthirtyfive");
            Label lbltotalforty = (Label)e.Row.FindControl("lbltotalforty");
            Label lbltotalzero = (Label)e.Row.FindControl("lbltotalzero");
            
            lbltotaltwenty.Text = twenty.ToString().Trim();
            lbltotaltwentyfive.Text = twentyfive.ToString().Trim();
            lbltotalthirty.Text = thirty.ToString().Trim();
            lbltotalthirtyfive.Text = thirtyfive.ToString().Trim();
            lbltotalforty.Text = forty.ToString().Trim();
            lbltotalzero.Text = zero.ToString().Trim();
            

        }
    }
    Label lblgrossamt;
    protected void GrdBookset_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            grossamt = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblgrossamt = (Label)e.Row.FindControl("lblgrossamt");
            grossamt = grossamt + Convert.ToDecimal(lblgrossamt.Text.Trim());
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalgrossamt = (Label)e.Row.FindControl("lbltotalgrossamt");
            lbltotalgrossamt.Text = grossamt.ToString().Trim();
        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        if (txtfromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
            string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
            fdate = Convert.ToDateTime(from);
            tdate = Convert.ToDateTime(To);
                ShowDetails();
           
        }
        else
        {
            MessageBox("Select Date");
        }
    }
    public void ShowDetails()
    {


        //string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        //string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        //fdate = Convert.ToDateTime(from);
        //tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }
        else
        {
            DataSet ds = new DataSet();
            //ds = Other.Dashboard.Get_Report_SalesPerformance(0, Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate);
            ds = Other.Dashboard.Get_Report_SalesPerformance(Convert.ToInt32(ddlSDZone.SelectedValue), Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate);
            grdoutstanding.DataSource = ds.Tables[0];
            grdoutstanding.DataBind();
            grdnoofparty.DataSource = ds.Tables[0];
            grdnoofparty.DataBind();
            dtAll = ds.Tables[0];

           // grdtargetdetail.DataSource = Other.Dashboard.Get_Report_SalesPerformance(0, Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY));
           // grdtargetdetail.DataBind();


            ds = Other.Dashboard.Get_Report_SalesPerformanceForDiscountParties(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate);
           
            GrdDiscount.DataSource = ds.Tables[0];
            GrdDiscount.DataBind();
            dtAll.Merge(ds.Tables[0]);
            DataTable dt = new DataTable();
            DataSet dsparties = new DataSet();
           // ds = Other.Dashboard.Get_Report_SalesPerformanceForDiscountParties(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate);
            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dt = ds.Tables[1];
                }

                //  DataTable dt = new DataTable();
                int sum = 0;
                DataRow newrow = dt.NewRow();
                foreach (DataColumn dc in dt.Columns)
                {
                    sum = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        sum += (int)dr[dc];
                    }
                    newrow[dc.ColumnName] = sum;
                    //grdadddiscount.FooterRow.Cells.ToString()  = sum;
                }

                dt.Rows.Add(newrow);

                grdadddiscount.DataSource = dt;
                grdadddiscount.DataBind();
                 dtAll.Merge(dt);
            }
            else
            {
                grdadddiscount.DataBind();
            }
          //  grdadddiscount.Columns[0].Visible = false;
           
            grdemployee.DataBind();
            grdcustomer.DataBind();

            lblgrdemployee.Text = "";
            lblgrdcustomer.Text = "";
            lblcustomername.Text = "";

            salesperformance.ReportSource = null;
        }


    }

    #region Summary

    
    public void ShowDetails1()
    {

        stDS = new DataSet();
        stDS = Other.Dashboard.Get_Report_SalesPerformance(0, Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate);
        if (stDS.Tables[0].Rows.Count > 0)
        {
            DataView dv = new DataView(stDS.Tables[0]);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/SalesPerformance.rpt"));
            rd.Database.Tables[0].SetDataSource(dv);
            DataSet ds = new DataSet();

            // ds = Other.Dashboard.Get_Report_SalesPerformance_Customer1(Convert.ToInt32(stDS.Tables[0].Rows[0]["ZoneId"]), Convert.ToInt32(strFY));

            //  rd.OpenSubreport("Customer").SetDataSource(ds.Tables[0]);

            salesperformance.ReportSource = rd;

            grdnoofparty.DataBind();
            grdoutstanding.DataBind();
            GrdDiscount.DataBind();
            GrdBookset.DataBind();
            grdemployee.DataBind();
            grdcustomer.DataBind();
            //grdtargetdetail.DataBind();
           // grdadddiscount.DataSource = null;
            grdadddiscount.DataBind();

        }
        else
        {
            MessageBox("No Record Found");


        }

    }
    #endregion

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    if (txtfromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
    //    {
    //        string from1 = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
    //        string To1 = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
    //        fdate = Convert.ToDateTime(from1);
    //        tdate = Convert.ToDateTime(To1);

    //        DataTable dt = new DataTable();
    //        dt = Other.Dashboard.Get_Report_SalesPerformance(0, Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
    //        DataTable dt1 = new DataTable();
    //        dt1 = Other.Dashboard.Get_Report_SalesPerformanceForDiscountParties(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
    //        DataTable dt3 = new DataTable();
    //        dt3 = Other.Dashboard.Get_Report_SalesPerformanceForDiscountParties(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[1];
    //        DataTable dt2 = new DataTable();
    //        dt2 = Other.Dashboard.Get_Report_SalesPerformanceForBookSet(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[0];



    //        //dt.Merge(dt1);
    //        //dt.Merge(dt2);


    //        //Export("SalesPerformance.xls", this.grdoutstanding);
    //        //Export("SalesPerformance.xls", this.grdnoofparty);
    //        //Export("SalesPerformance.xls", this.GrdDiscount);

    //        //Export("SalesPerformance.xls", this.grdadddiscount);
    //        //Export("SalesPerformance.xls", this.GrdBookset);
    //        //Export("SalesPerformance.xls", this.grdcustomer);


    //        // dt = city.GetAllCity();//your datatable

    //        string attachment = "attachment; filename=SalesPerformance.xls";
    //        Response.ClearContent();
    //        Response.AddHeader("content-disposition", attachment);
    //        Response.ContentType = "application/vnd.ms-excel";
    //        string tab = "";
    //        foreach (DataColumn dc in dt.Columns)
    //        {
    //            Response.Write(tab + dc.ColumnName);
    //            tab = "\t";
    //        }
    //        Response.Write("\n");
    //        int i;
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            tab = "";
    //            for (i = 0; i < dt.Columns.Count; i++)
    //            {
    //                Response.Write(tab + dr[i].ToString());
    //                tab = "\t";
    //            }
    //            Response.Write("\n");
    //        }
    //        Response.Write("\n");
    //        tab = "";
            

    //    }
    //}
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (txtfromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            string from1 = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
            string To1 = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
            fdate = Convert.ToDateTime(from1);
            tdate = Convert.ToDateTime(To1);

            DataTable dt = new DataTable();
            dt = Other.Dashboard.Get_Report_SalesPerformance(0, Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
            DataTable dt1 = new DataTable();
            dt1 = Other.Dashboard.Get_Report_SalesPerformanceForDiscountParties(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[0];
            DataTable dt3 = new DataTable();
            dt3 = Other.Dashboard.Get_Report_SalesPerformanceForDiscountParties(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[1];
            DataTable dt2 = new DataTable();
            dt2 = Other.Dashboard.Get_Report_SalesPerformanceForBookSet(Convert.ToInt32(DDLsuperzone.SelectedValue), Convert.ToInt32(strFY), fdate, tdate).Tables[0];

            //dt.Merge(dt1);
            //dt.Merge(dt2);


            //Export("SalesPerformance.xls", this.grdoutstanding);
            //Export("SalesPerformance.xls", this.grdnoofparty);
            //Export("SalesPerformance.xls", this.GrdDiscount);

            //Export("SalesPerformance.xls", this.grdadddiscount);
            //Export("SalesPerformance.xls", this.GrdBookset);
            //Export("SalesPerformance.xls", this.grdcustomer);


            // dt = city.GetAllCity();//your datatable

            string attachment = "attachment; filename=SalesPerformance.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.Write("\n");
            tab = "";

            foreach (DataColumn dc1 in dt1.Columns)
            {
                Response.Write(tab + dc1.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int j;
            foreach (DataRow dr1 in dt1.Rows)
            {
                tab = "";
                for (j = 0; j < dt1.Columns.Count; j++)
                {
                    Response.Write(tab + dr1[j].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }

            Response.Write("\n");
            tab = "";
            foreach (DataColumn dc3 in dt3.Columns)
            {
                Response.Write(tab + dc3.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int m;
            foreach (DataRow dr3 in dt3.Rows)
            {
                tab = "";
                for (m = 0; m < dt3.Columns.Count; m++)
                {
                    Response.Write(tab + dr3[m].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }

            Response.Write("\n");
            tab = "";
            foreach (DataColumn dc2 in dt2.Columns)
            {
                Response.Write(tab + dc2.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int k;
            foreach (DataRow dr2 in dt2.Rows)
            {
                tab = "";
                for (k = 0; k < dt2.Columns.Count; k++)
                {
                    Response.Write(tab + dr2[k].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }

            Response.End();
        }
    }
    public static void Export(string fileName, GridView gv)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
        "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {

                System.Web.UI.WebControls.Table tbl = new System.Web.UI.WebControls.Table();

                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    tbl.Rows.Add(gv.HeaderRow);
                }

                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);
                    tbl.Rows.Add(row);
                }

                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    tbl.Rows.Add(gv.FooterRow);
                }

                tbl.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }
    protected void grdadddiscount_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}
