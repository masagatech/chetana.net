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


public partial class Godown_GetLocal_Customer_Delivery : System.Web.UI.UserControl
{
    #region Variables
    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;
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
            ViewState["LocalDateRep"] = null;
            ViewState["LocalVehicleRep"] = null;
            ViewState["LocalCustomerRep"] = null;
            txtfromdate.Focus();

            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdvehicle.DataSource = null;
            grdvehicle.DataBind();

        }
        else
        {
            if (rdoview.SelectedIndex == 0)
            {
                ViewState["LocalVehicleRep"] = null;
                ViewState["LocalCustomerRep"] = null;
                fillData(0);
            }
            else if (rdoview.SelectedIndex == 1)
            {
                ViewState["LocalDateRep"] = null;
                ViewState["LocalCustomerRep"] = null;
                fillDatavehicle(0);
            }
            else if (rdoview.SelectedIndex == 2)
            {
                ViewState["LocalDateRep"] = null;
                ViewState["LocalVehicleRep"] = null;
                fillDatacustomer(0);
            }
        }
    }




    protected void btnget_Click(object sender, EventArgs e)
    {
        if (rdoview.Items[0].Selected == true)
        {
            fillData(1);
        }
        else if (rdoview.Items[1].Selected == true)
        {
            fillDatavehicle(1);
            if ( grdvehicle.Rows.Count == 0)
            {

                lblCustomer.Text = "Records of all Vehicles.";
            }
            else
            {
                lblCustomer.Text = "";
            }

        }
        else
        {
            fillDatacustomer(1);
            if (grdTemp.Rows.Count == 0)
            {


                lblCustomer.Text = "Records of all Customers.";
            }
            else
            {
                lblCustomer.Text = "";
            }

        }
    }


    public void fillData(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";
        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {

            DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
            DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);

            DataSet ds = new DataSet();
            if (rdodelivery.SelectedIndex == 0)
            {

                ds = G_GetPass.Local_Date_Report("D", _objfdate, _objtdate, "A", "", Convert.ToInt32(strFY));

            }
            else if (rdodelivery.SelectedIndex == 1)
            {
                ds = G_GetPass.Local_Date_Report("D", _objfdate, _objtdate, "P", "", Convert.ToInt32(strFY));
            }
            else if (rdodelivery.SelectedIndex == 2)
            {
                ds = G_GetPass.Local_Date_Report("D", _objfdate, _objtdate, "C", "", Convert.ToInt32(strFY));
            }

            ViewState["LocalDateRep"] = ds.Tables[0];
        }
        if (ViewState["LocalDateRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/DateReport.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["LocalDateRep"]);
                LocalDate.ReportSource = rd;

            }
            catch
            {


            }
        }
    }

    public void fillDatavehicle(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";


        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {

            DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
            DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);

            DataSet ds = new DataSet();
            string selectedCust = getSelectedCustomer();
            if (rdodelivery.SelectedIndex == 0)
            {
                if (grdvehicle.Rows.Count == 0)
                {
                    ds = G_GetPass.Local_Date_Report("V", _objfdate, _objtdate, "A", selectedCust, Convert.ToInt32(strFY));
                }
                else
                {
                    ds = G_GetPass.Local_Date_Report("V", _objfdate, _objtdate, "A", selectedCust, Convert.ToInt32(strFY));
                }
            }
            else if (rdodelivery.SelectedIndex == 1)
            {
                if (grdvehicle.Rows.Count == 0)
                {
                    ds = G_GetPass.Local_Date_Report("V", _objfdate, _objtdate, "P", selectedCust, Convert.ToInt32(strFY));
                }
                else
                {
                    ds = G_GetPass.Local_Date_Report("V", _objfdate, _objtdate, "P", selectedCust, Convert.ToInt32(strFY));
                }
            }
            else if (rdodelivery.SelectedIndex == 2)
            {
                if (grdvehicle.Rows.Count == 0)
                {
                    ds = G_GetPass.Local_Date_Report("V", _objfdate, _objtdate, "C", selectedCust, Convert.ToInt32(strFY));
                }
                else
                {
                    ds = G_GetPass.Local_Date_Report("V", _objfdate, _objtdate, "C", selectedCust, Convert.ToInt32(strFY));
                }
            }

            ViewState["LocalVehicleRep"] = ds.Tables[0];
        }
        if (ViewState["LocalVehicleRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/VehicleReport.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["LocalVehicleRep"]);
                LocalVehicle.ReportSource = rd;

            }
            catch
            {


            }
        }
    }


    public void fillDatacustomer(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";

        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {
            DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
            DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);

            DataSet ds = new DataSet();
            string selectedCust = getSelectedCustomer();
            if (rdodelivery.SelectedIndex == 0)
            {
                if (grdTemp.Rows.Count == 0)
                {
                    ds = G_GetPass.Local_Date_Report("C", _objfdate, _objtdate, "A", selectedCust, Convert.ToInt32(strFY));
                }
                else
                {
                    ds = G_GetPass.Local_Date_Report("C", _objfdate, _objtdate, "A", selectedCust, Convert.ToInt32(strFY));
                }
            }
            else if (rdodelivery.SelectedIndex == 1)
            {
                if (grdTemp.Rows.Count == 0)
                {
                    ds = G_GetPass.Local_Date_Report("C", _objfdate, _objtdate, "P", selectedCust, Convert.ToInt32(strFY));
                }
                else
                {
                    ds = G_GetPass.Local_Date_Report("C", _objfdate, _objtdate, "P", selectedCust, Convert.ToInt32(strFY));
                }
            }
            else if (rdodelivery.SelectedIndex == 2)
            {
                if (grdTemp.Rows.Count == 0)
                {
                    ds = G_GetPass.Local_Date_Report("C", _objfdate, _objtdate, "C", selectedCust, Convert.ToInt32(strFY));
                }
                else
                {
                    ds = G_GetPass.Local_Date_Report("C", _objfdate, _objtdate, "C", selectedCust, Convert.ToInt32(strFY));
                }
            }

            ViewState["LocalCustomerRep"] = ds.Tables[0];
        }
        if (ViewState["LocalCustomerRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/CustomerReport.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["LocalCustomerRep"]);
                LocalCustomer.ReportSource = rd;

            }
            catch
            {


            }
        }
    }

    public string getSelectedCustomer()
    {
        string str = "";
        if (rdoview.Items[2].Selected == true)
        {

            foreach (GridViewRow row in grdTemp.Rows)
            {
                str = str + ((Label)row.FindControl("lCustid")).Text + ",";

            }
            if (grdTemp.Rows.Count == 0)
            {
                str = "All";
            }
        }
        else if (rdoview.Items[1].Selected == true)
        {
            foreach (GridViewRow row in grdvehicle.Rows)
            {
                str = str + ((Label)row.FindControl("G_lblCustid")).Text + ",";

            }
            if (grdvehicle.Rows.Count == 0)
            {
                str = "All";
            }
        }
        return str;
    }

    protected void rdoview_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoview.Items[0].Selected == true)
        {
            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdvehicle.DataSource = null;
            grdvehicle.DataBind();

            txtfromdate.Focus();
            lblCustomer.Text = "";
            pnlFormDetail.Visible = false;
            txtfromdate.Text = "";
            txttodate.Text = "";
            LocalVehicle.ReportSource = null;
            LocalCustomer.ReportSource = null;
            LocalDate.ReportSource = null;
        }
        else if (rdoview.Items[1].Selected == true)
        {
            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdvehicle.DataSource = null;
            grdvehicle.DataBind();

            txtfromdate.Focus();
            txtfromdate.TabIndex = 1;
            txttodate.TabIndex = 2;
            txtCust.TabIndex = 3;
            btnAddRecords.TabIndex = 4;
            btnget.TabIndex = 5;
            Cust_AutoCompleteExtender.ContextKey = "g_vehicle";
            lblCustomer.Text = "";
            pnlFormDetail.Visible = true;
            Label9.Text = "Vehicle";
            txtfromdate.Text = "";
            txttodate.Text = "";
            LocalDate.ReportSource = null;
            LocalVehicle.ReportSource = null;
            LocalCustomer.ReportSource = null;
        }
        else if (rdoview.Items[2].Selected == true)
        {
            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdvehicle.DataSource = null;
            grdvehicle.DataBind();

            txtfromdate.Focus();
            txtfromdate.TabIndex = 1;
            txttodate.TabIndex = 2;
            txtCust.TabIndex = 3;
            btnAddRecords.TabIndex = 4;
            btnget.TabIndex = 5;
            Cust_AutoCompleteExtender.ContextKey = "customer";
            lblCustomer.Text = "";
            pnlFormDetail.Visible = true;
            Label9.Text = "Customer";
            txtfromdate.Text = "";
            txttodate.Text = "";
            LocalDate.ReportSource = null;
            LocalVehicle.ReportSource = null;
            LocalCustomer.ReportSource = null;
        }
    }

    #region Text changed event

    protected void txtCust_TextChanged(object sender, EventArgs e)
    {
        callTextChange();

    }

    protected void btnAddRecords_Click(object sender, EventArgs e)
    {
        if (rdoview.Items[2].Selected == true)
        {
            grdTemp.DataSource = fillTempBookData(txtCust.Text.ToString().Split(':')[0].Trim());
            grdTemp.DataBind();
            clearStrip();
            txtCust.Focus();
        }
        else if (rdoview.Items[1].Selected == true)
        {
            grdvehicle.DataSource = fillTempBookData(txtCust.Text.ToString());
            grdvehicle.DataBind();
            clearStrip();
            txtCust.Focus();
        }
    }

    #endregion

    #region cust Text Change

    public void callTextChange()
    {
        string CustCode = txtCust.Text.ToString().Split(':')[0].Trim();

        DataTable dt = new DataTable();

        if (rdoview.Items[2].Selected == true)
        {
            dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

            if (dt.Rows.Count != 0)
            {
                if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
                {
                    lblCustomer.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                    txtCust.Text = CustCode;
                    lblCustID.Text = Convert.ToString(dt.Rows[0]["CustID"]);
                    txtCust.Focus();

                }
                else
                {
                    lblCustomer.Text = "Customer is blacklisted";
                    txtCust.Focus();
                    txtCust.Text = "";

                }
            }
            else
            {
                lblCustomer.Text = "No such Record found";
                txtCust.Focus();
                txtCust.Text = "";

            }
        }
        else if (rdoview.Items[1].Selected == true)
        {
            //string Vehicle = txtVehicle.Text.ToString();
            string CustCode1 = txtCust.Text.ToString();
            if (CustCode1.Split(':').Length > 1)
            {
                lblCustID.Text = txtCust.Text.Split(':')[0].ToString();
                lblCustomer.Text = txtCust.Text.Split(':')[1].ToString() + ' ' + txtCust.Text.Split(':')[3].ToString();
                txtCust.Focus();

            }
            else
            {

                lblCustomer.Text = "No such Record found";
                txtCust.Focus();
            }
        }
    }



    #endregion



    public void clearStrip()
    {

        txtCust.Text = "";
        lblCustomer.Text = "";
        lblCustID.Text = "";


    }

    protected void btnClearEdit_Click(object sender, EventArgs e)
    {
        clearStrip();

    }



    #region TEMP DATA

    public DataTable fillTempBookData(string Cust)
    {
        DataTable dt = new DataTable();

        if (rdoview.Items[2].Selected == true)
        {

            DataTable dt1 = DCMaster.Get_Name(Cust, "Customer").Tables[0];

            if (Session["getpasstempdata"] == null)
            {
                //CREATE NEW DATATABLE

                dt.Columns.Add("SCHL_ID");
                dt.Columns.Add("SCHL_NAME");
                dt.Columns.Add("SCHL_AREA");
                dt.Columns.Add("ID");

            }
            else
            {
                dt = (DataTable)Session["getpasstempdata"];
            }

            dt.Rows.Add(dt1.Rows[0]["CustCode"].ToString(), dt1.Rows[0]["CustName"].ToString(), dt1.Rows[0]["AreaName"].ToString(), dt1.Rows[0]["CustID"].ToString());


        }
        else if (rdoview.Items[1].Selected == true)
        {

            if (Session["getpasstempdata"] == null)
            {
                //CREATE NEW DATATABLE

                dt.Columns.Add("VEH_ID");
                dt.Columns.Add("VEH_NO");
                dt.Columns.Add("VEH_TYPE");

            }
            else
            {
                dt = (DataTable)Session["getpasstempdata"];
            }

            dt.Rows.Add(Cust.Split(':')[0].ToString(), Cust.Split(':')[1].ToString(), Cust.Split(':')[3].ToString());

        }
        Session["getpasstempdata"] = dt;
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


    protected void grdTemp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["getpasstempdata"];
        dt1.Rows[e.RowIndex].Delete();
        grdTemp.DataSource = dt1;
        grdTemp.DataBind();
        upDetails.Update();
        Session["getpasstempdata"] = dt1;
        loder("Successfully Deleted...", "3000");


    }


    protected void grdvehicle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["getpasstempdata"];
        dt1.Rows[e.RowIndex].Delete();
        grdvehicle.DataSource = dt1;
        grdvehicle.DataBind();
        UpdatePanel1.Update();
        Session["getpasstempdata"] = dt1;
        loder("Successfully Deleted...", "3000");


    }

    #endregion
}
