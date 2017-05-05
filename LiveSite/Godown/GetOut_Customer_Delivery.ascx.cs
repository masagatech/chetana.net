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

public partial class Godown_GetOut_Customer_Delivery : System.Web.UI.UserControl
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
            ViewState["OutDateRep"] = null;
            ViewState["OutVehicleRep"] = null;
            ViewState["OutCustomerRep"] = null;
            txtfromdate.Focus();
            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdTransport.DataSource = null;
            grdTransport.DataBind();

        }
        else
        {
            fillDatacustomer(0);
            fillData(0);
            fillDataTransporter(0);

        }
    }




    protected void btnget_Click(object sender, EventArgs e)
    {
        if (rdoview.Items[0].Selected == true)
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
        else if (rdoview.Items[1].Selected == true)
        {

            fillData(1);

        }

        else if (rdoview.Items[2].Selected == true)
        {
            fillDataTransporter(1);

            if (grdTransport.Rows.Count == 0)
            {

                lblCustomer.Text = "Records of all Transporters.";
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
                ds = G_GetPass.Out_Transporter_Report("D", _objfdate, _objtdate, "A", Convert.ToInt32(strFY), "");
            }
            else if (rdodelivery.SelectedIndex == 1)
            {
                ds = G_GetPass.Out_Transporter_Report("D", _objfdate, _objtdate, "P", Convert.ToInt32(strFY), "");
            }
            else if (rdodelivery.SelectedIndex == 2)
            {
                ds = G_GetPass.Out_Transporter_Report("D", _objfdate, _objtdate, "C", Convert.ToInt32(strFY), "");
            }

            ViewState["OutDateRep"] = ds.Tables[0];
        }
        if (ViewState["OutDateRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/Customer_Details.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["OutDateRep"]);
                OutDate.ReportSource = rd;

            }
            catch
            {


            }
        }
    }

    public void fillDataTransporter(int isNew)
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
                if (grdTransport.Rows.Count == 0)
                {
                    ds = G_GetPass.Out_Transporter_Report("T", _objfdate, _objtdate, "A", Convert.ToInt32(strFY), selectedCust);
                }
                else
                {
                    ds = G_GetPass.Out_Transporter_Report("T", _objfdate, _objtdate, "A", Convert.ToInt32(strFY), selectedCust);
                }
            }
            else if (rdodelivery.SelectedIndex == 1)
            {
                if (grdTransport.Rows.Count == 0)
                {
                    ds = G_GetPass.Out_Transporter_Report("T", _objfdate, _objtdate, "P", Convert.ToInt32(strFY), selectedCust);
                }
                else
                {
                    ds = G_GetPass.Out_Transporter_Report("T", _objfdate, _objtdate, "P", Convert.ToInt32(strFY), selectedCust);
                }
            }
            else if (rdodelivery.SelectedIndex == 2)
            {
                if (grdTransport.Rows.Count == 0)
                {
                    ds = G_GetPass.Out_Transporter_Report("T", _objfdate, _objtdate, "C", Convert.ToInt32(strFY), selectedCust);
                }
                else
                {
                    ds = G_GetPass.Out_Transporter_Report("T", _objfdate, _objtdate, "C", Convert.ToInt32(strFY), selectedCust);
                }
            }

            ViewState["OutVehicleRep"] = ds.Tables[0];
        }
        if (ViewState["OutVehicleRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/Customer_T_Details.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["OutVehicleRep"]);
                OutVehicle.ReportSource = rd;

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
                    ds = G_GetPass.Out_Transporter_Report("C", _objfdate, _objtdate, "A", Convert.ToInt32(strFY), selectedCust);
                }
                else
                {
                    ds = G_GetPass.Out_Transporter_Report("C", _objfdate, _objtdate, "A", Convert.ToInt32(strFY), selectedCust);
                }
            }
            else if (rdodelivery.SelectedIndex == 1)
            {
                if (grdTemp.Rows.Count == 0)
                {
                    ds = G_GetPass.Out_Transporter_Report("C", _objfdate, _objtdate, "P", Convert.ToInt32(strFY), selectedCust);
                }
                else
                {
                    ds = G_GetPass.Out_Transporter_Report("C", _objfdate, _objtdate, "P", Convert.ToInt32(strFY), selectedCust);
                }
            }
            else if (rdodelivery.SelectedIndex == 2)
            {
                if (grdTemp.Rows.Count == 0)
                {
                    ds = G_GetPass.Out_Transporter_Report("C", _objfdate, _objtdate, "C", Convert.ToInt32(strFY), selectedCust);
                }
                else
                {
                    ds = G_GetPass.Out_Transporter_Report("C", _objfdate, _objtdate, "C", Convert.ToInt32(strFY), selectedCust);

                }
            }

            ViewState["OutCustomerRep"] = ds.Tables[0];
        }
        if (ViewState["OutCustomerRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/Customer_C_Details.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["OutCustomerRep"]);
                OutCustomer.ReportSource = rd;

            }
            catch
            {


            }
        }
    }


    public string getSelectedCustomer()
    {
        string str = "";
        if (rdoview.Items[0].Selected == true)
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
        else if (rdoview.Items[2].Selected == true)
        {
            foreach (GridViewRow row in grdTransport.Rows)
            {
                str = str + ((Label)row.FindControl("G_lblCustid")).Text + ",";

            }
            if (grdTransport.Rows.Count == 0)
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
            grdTransport.DataSource = null;
            grdTransport.DataBind();

            txtfromdate.Focus();
            txtfromdate.TabIndex = 1;
            txttodate.TabIndex = 2;
            txtCust.TabIndex = 3;
            btnAddRecords.TabIndex = 4;
            btnget.TabIndex = 5;

            lblCustomer.Text = "";
            pnlFormDetail.Visible = true;
            Label9.Text = "Customer";
            txtfromdate.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            OutVehicle.ReportSource = null;
            OutCustomer.ReportSource = null;
            OutDate.ReportSource = null;
        }
        else if (rdoview.Items[1].Selected == true)
        {
            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdTransport.DataSource = null;
            grdTransport.DataBind();

            txtfromdate.Focus();
            lblCustomer.Text = "";
            pnlFormDetail.Visible = false;
            txtfromdate.Text = "";
            txttodate.Text = "";
            OutDate.ReportSource = null;
            OutVehicle.ReportSource = null;
            OutCustomer.ReportSource = null;
        }
        else if (rdoview.Items[2].Selected == true)
        {
            Session["getpasstempdata"] = null;
            grdTemp.DataSource = null;
            grdTemp.DataBind();
            grdTransport.DataSource = null;
            grdTransport.DataBind();

            txtfromdate.Focus();
            txtfromdate.TabIndex = 1;
            txttodate.TabIndex = 2;
            txtCust.TabIndex = 3;
            btnAddRecords.TabIndex = 4;
            btnget.TabIndex = 5;

            lblCustomer.Text = "";
            Cust_AutoCompleteExtender.ContextKey = "transporterg";
            pnlFormDetail.Visible = true;
            Label9.Text = "Transporter";
            txtfromdate.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            OutDate.ReportSource = null;
            OutVehicle.ReportSource = null;
            OutCustomer.ReportSource = null;
        }
    }

    #region Text changed event

    protected void txtCust_TextChanged(object sender, EventArgs e)
    {
        callTextChange();

    }

    protected void btnAddRecords_Click(object sender, EventArgs e)
    {
        if (rdoview.Items[0].Selected == true)
        {
            grdTemp.DataSource = fillTempBookData(txtCust.Text.ToString().Split(':')[0].Trim());
            grdTemp.DataBind();
            clearStrip();
            txtCust.Focus();
        }
        else if (rdoview.Items[2].Selected == true)
        {
            grdTransport.DataSource = fillTempBookData(txtCust.Text.ToString().Split(':')[0].Trim());
            grdTransport.DataBind();
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
        if (rdoview.Items[0].Selected == true)
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
                lblCustomer.Text = "No such record found";
                txtCust.Focus();
                txtCust.Text = "";

            }
        }
        else if (rdoview.Items[2].Selected == true)
        {
            dt = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("Transport", CustCode).Tables[0];

            if (dt.Rows.Count != 0)
            {
                // txttransporter.Text = TransCode;

                lblCustomer.Text = dt.Rows[0]["Key"].ToString() + "::" + dt.Rows[0]["Value"].ToString();
                lblCustID.Text = dt.Rows[0]["AutoID"].ToString();

            }
            else
            {
                lblCustomer.Text = "No such record found";
                txtCust.Focus();
                txtCust.Text = "";
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

        if (rdoview.Items[0].Selected == true)
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
        else if (rdoview.Items[2].Selected == true)
        {

            DataTable dt2 = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("Transport", Cust).Tables[0];
            if (Session["getpasstempdata"] == null)
            {
                //CREATE NEW DATATABLE

                dt.Columns.Add("Transport_ID");
                dt.Columns.Add("Transport_Code");
                dt.Columns.Add("Transport_Name");

            }
            else
            {
                dt = (DataTable)Session["getpasstempdata"];
            }

            dt.Rows.Add(dt2.Rows[0]["AutoID"].ToString(), dt2.Rows[0]["Key"].ToString(), dt2.Rows[0]["Value"].ToString());
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

    protected void grdTransport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["getpasstempdata"];
        dt1.Rows[e.RowIndex].Delete();
        grdTransport.DataSource = dt1;
        grdTransport.DataBind();
        UpdatePanel1.Update();
        Session["getpasstempdata"] = dt1;
        loder("Successfully Deleted...", "3000");


    }

    #endregion
}
