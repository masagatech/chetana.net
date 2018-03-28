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
using Other_Z;
#endregion


public partial class DCCNPrintmultiple : System.Web.UI.Page
{
    #region Variables
    //string CustCode;
    int CNNo;
    static int quantity = 0;
    static decimal tamount = 0;
    static decimal tnamount = 0;
    string UserName = "";
    string frdate;
    string todate;
    DateTime fdt;
    DateTime tdt;
    string strChetanaCompanyName = "cppl";
    string strFY;
    Other_Z.OtherBAL ObjotherZ = new OtherBAL();
    #endregion

    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
        // CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        //CustCode = Convert.ToInt32(DDLCustomer.SelectedValue)
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
            Pnldate.Visible = true;
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            Session["Typ"] = null;
            Session["Datacn"] = null;
            BindDDlCust();
            txtFromDate.Focus();

            //txtcustomer.Focus();
        }
        else
        {
           
        }


        if (Session["Typ"] != null)
        {
            if (Session["Typ"].ToString() == "N")
            {
                fillReport();
            }
            else
            {
                GSTPrint();
            }
        }
        else
        {
            Session["Datacn"] = null;
            Session["Typ"] = null;
        }

    }
    #endregion

    #region GST Print Method
    private void GSTPrint()
    {
        
        
        string Selectedcn = "";
        bool checkAll = false;
        if (Chkbxlstcn.Items[0].Selected == true)
        {
            checkAll = true;
        }
        for (int i = 1; i < Chkbxlstcn.Items.Count; i++)
        {

            if (checkAll == true)
            {
                Selectedcn = Selectedcn + Chkbxlstcn.Items[i].Value.ToString() + ",";
            }
            else if (Chkbxlstcn.Items[i].Selected == true)
            {
                Selectedcn = Selectedcn + Chkbxlstcn.Items[i].Value.ToString() + ",";
            }

        }
        // Selectedcn = Selectedcn ;
        DataTable dt = new DataTable();

        dt = CreditNote.Get_PrintCN_multiple(Convert.ToInt32(strFY), Selectedcn).Tables[0];
        Session["Datacn"] = dt;
        if (Session["Datacn"] != null)
        {
            DataTable dt5 = new DataTable();
            dt5 = (DataTable)Session["Datacn"];
            ReportDocument CR = new ReportDocument();
            CR.Load(Server.MapPath("Report/GSTCNPrint1.rpt"));
            CR.SetDataSource(dt5);
            Crptcnprint.ReportSource = CR;
        }
    }

    #endregion

    #region GST Get Button Click Event
    protected void btnGST_Click(object sender, EventArgs e)
    {
        Session["Typ"] = null;
        Session["Typ"] = "G";
        Session["Datacn"] = null;
        GSTPrint();
    }
    #endregion

    #region Events

    #region Button Click
    protected void btnget_Click(object sender, EventArgs e)
    {
        Session["Datacn"] = null;
        Session["Typ"] = null;
        Session["Typ"] = "N";
        string Selectedcn = "";
        bool checkAll = false;
        if (Chkbxlstcn.Items[0].Selected == true)
        {
            checkAll = true;
        }
        for (int i = 1; i < Chkbxlstcn.Items.Count; i++)
        {

            if (checkAll == true)
            {
                Selectedcn = Selectedcn + Chkbxlstcn.Items[i].Value.ToString() + ",";
            }
            else if (Chkbxlstcn.Items[i].Selected == true)
            {
                Selectedcn = Selectedcn + Chkbxlstcn.Items[i].Value.ToString() + ",";
            }

        }
        // Selectedcn = Selectedcn ;
        DataTable dt = new DataTable();

        dt = CreditNote.Get_PrintCN_multiple(Convert.ToInt32(strFY), Selectedcn).Tables[0];
        Session["Datacn"] = dt;
        fillReport();


    }
    protected void btngetcust_Click(object sender, EventArgs e)
    {
        Pnl2.Visible = false;

        frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        tdt = Convert.ToDateTime(todate);
        fdt = Convert.ToDateTime(frdate);

        if (tdt >= fdt)
        {
            if (RdbtnSelect.SelectedValue == "CN")
            {
                Pnl1.Visible = false;

                //RptrCN.DataSource = CreditNote.GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                //RptrCN.DataBind();

                //RptrCN.Visible = true;
                Chkbxlstcn.DataSource = CreditNote.GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                Chkbxlstcn.DataBind();
                Chkbxlstcn.Items.Insert(0, new ListItem("All", "0"));

                Pnl2.Visible = true;

            }
            if (RdbtnSelect.SelectedValue == "CustomerwiseCN")
            {
                DataSet ds = new DataSet();
                // ds = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                ds = ObjotherZ.Idv_Chetana_DC_GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt, UserName, "", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DDLCustomer.DataSource = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                    DDLCustomer.DataBind();
                    DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
                    Chkbxlstcn.Items.Insert(0, new ListItem("All", "0"));

                    Pnl1.Visible = true;
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
        //else
        //if (Convert.ToDateTime(todate) == Convert.ToDateTime(frdate))
        //{
        //    MessageBox("From Date and To Date are similar");
        //}

    }

    #endregion

    #region TextChanged

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        Pnl1.Visible = false;
        Pnl2.Visible = false;
    }
    protected void txttoDate_TextChanged(object sender, EventArgs e)
    {
        Pnl1.Visible = false;
        Pnl2.Visible = false;
    }

    #endregion

    #region IndexChanged
    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

        // frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        //  todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        fdt = Convert.ToDateTime("1900/01/01");
        tdt = Convert.ToDateTime("1900/01/01");
        // Rptrpending.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(DDLCustomer.SelectedValue));
        //RptrCN.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(strFY), (DDLCustomer.SelectedValue), "All", fdt, tdt);
        //RptrCN.DataBind();

        Chkbxlstcn.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(strFY), (DDLCustomer.SelectedValue), "All", fdt, tdt);
        Chkbxlstcn.DataBind();
        Chkbxlstcn.Items.Insert(0, new ListItem("All", "0"));

        //RptrCN2.DataSource = CreditNote.GetCNNo_byCust((DDLCustomer.SelectedValue), "Manual");
        //RptrCN2.DataBind();

        //RptrCN.Visible = true;
        Pnl2.Visible = true;

        //DataTable dt = new DataTable();
        //dt = DCReturnBook.GetCustAddress((DDLCustomer.SelectedValue), "CNCustlist").Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    lblCustName.Text = dt.Rows[0]["CustName"].ToString();
        //    lblCustAddress.Text = dt.Rows[0]["Address"].ToString();
        //}

        if (DDLCustomer.SelectedIndex == 0)
        {
            Pnl2.Visible = false;
        }
    }
    #endregion

    #region RowDataBound
    protected void grdcn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
            tnamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty1 = (Label)e.Row.FindControl("lblqty");
            quantity = quantity + Convert.ToInt32(lblqty1.Text.Trim());
            Label lblamt1 = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt1.Text.Trim());
            Label lblnamt1 = (Label)e.Row.FindControl("lblnamt");
            tnamount = tnamount + Convert.ToDecimal(lblnamt1.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblqty2 = (Label)e.Row.FindControl("lbltqty");
            lblqty2.Text = quantity.ToString().Trim();
            Label lblamt2 = (Label)e.Row.FindControl("lbltamt");
            lblamt2.Text = tamount.ToString().Trim();
            Label lblnamt2 = (Label)e.Row.FindControl("lbltnamt");
            lblnamt2.Text = tnamount.ToString().Trim();
        }
    }
    #endregion

    #endregion

    # region Methods

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    #endregion

    #region Bind Methods

    public void BindGrd2()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        //Grd2.DataSource = DCReturnBook.Get_DC_ReturnBook(CustCode, "DCrtbk");
        //Grd2.DataBind();
    }
    public void BindDDlCust()
    {
        DDLCustomer.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "CNCustlist");
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }

    #endregion

    #endregion

    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "CN")
        {
            Pnldate.Visible = true;
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            txtFromDate.Focus();
        }

        else if (RdbtnSelect.SelectedValue == "CustomerwiseCN")
        {
            Pnldate.Visible = true;
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            CustomerWiseCn();
            //txtFromDate.Focus();
        }
        else if (RdbtnSelect.SelectedValue == "All")
        {
            fdt = Convert.ToDateTime("1900/01/01");
            tdt = Convert.ToDateTime("1900/01/01");
            //Pnldate.Visible = false;
            Pnl1.Visible = false;
            //btnPrint.Visible = false;
            // PnlPrint.Visible = false;

            Chkbxlstcn.DataSource = CreditNote.GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
            Chkbxlstcn.DataBind();
            Chkbxlstcn.Items.Insert(0, new ListItem("All", "0"));

            Chkbxlstcn.Visible = true;
            // RptrCN2.Visible = true;
            Pnl2.Visible = true;

        }
    }

    public void CustomerWiseCn()
    {
        DataSet ds = new DataSet();
        fdt = Convert.ToDateTime("1900/01/01");
        tdt = Convert.ToDateTime("1900/01/01");
        //ds = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
        ds = ObjotherZ.Idv_Chetana_DC_GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt, UserName, "", "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDLCustomer.DataSource = ds.Tables[0];
            DDLCustomer.DataBind();
            DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            Pnl1.Visible = true;
        }
        else
        {
            MessageBox("Records Not Available ");
        }
    }

    public void fillReport()
    {
        if (Session["Datacn"] != null)
        {
            DataTable dt5 = new DataTable();
            dt5 = (DataTable)Session["Datacn"];
            ReportDocument CR = new ReportDocument();
            CR.Load(Server.MapPath("Report/CNPrint.rpt"));
            CR.SetDataSource(dt5);
            Crptcnprint.ReportSource = CR;
        }
    }


    protected override void OnInit(System.EventArgs e)
    {
        base.OnInit(e);



    }

}
