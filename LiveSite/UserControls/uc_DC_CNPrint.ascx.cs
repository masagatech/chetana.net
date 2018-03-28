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
#endregion

public partial class UserControls_ODC_uc_DC_CNPrint : System.Web.UI.UserControl
{
    #region Variables
    //string CustCode;
    int CNNo;
    static int quantity = 0;
    static decimal tamount = 0;
    static decimal tnamount = 0;
    string frdate;
    string todate;
    DateTime fdt;
    DateTime tdt;

    string strChetanaCompanyName = "cppl";
    string strFY;
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
            btnPrint.Visible = false;
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            PnlPrint.Visible = false;
           // BindDDlCust();
            txtFromDate.Focus();

            txtFromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            txttoDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            //txtcustomer.Focus();
        }
        else
        {
        }
    }
    #endregion

    #region Events

    #region Button Click
    protected void btnget_Click(object sender, EventArgs e)
    {
        lblviewCNNo.Text = txtCnno.Text.Trim();
        CNNo = Convert.ToInt32(txtCnno.Text.Trim());
        // Bindgrdcn();
        grdcn.DataSource = CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);
        grdcn.DataBind();
        DataSet ds = new DataSet();
        ds = CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);
        if (ds.Tables[1].Rows.Count > 0)
        {
            lblCustName.Text = ds.Tables[1].Rows[0]["CustName"].ToString();
            lblCustAddress.Text = ds.Tables[1].Rows[0]["Address"].ToString();
        }
        PnlPrint.Visible = true;
        btnPrint.Visible = true;
    }
    protected void btngetcust_Click(object sender, EventArgs e)
    {
        Pnl2.Visible = false;
        PnlPrint.Visible = false;
        
            frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
            todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

            tdt = Convert.ToDateTime(todate);
            fdt = Convert.ToDateTime(frdate);

            if (tdt >= fdt)
            {
                if (RdbtnSelect.SelectedValue == "CN")
                {
                    Pnl1.Visible = false;

                    RptrCN.DataSource = CreditNote.GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                    RptrCN.DataBind();

                    RptrCN.Visible = true;
                    // RptrCN2.Visible = true;
                    PnlPrint.Visible = false;
                    Pnl2.Visible = true;

                }
                else if (RdbtnSelect.SelectedValue == "CustomerwiseCN")
                {
                    DataSet ds = new DataSet();
                    ds = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DDLCustomer.DataSource = CreditNote.GetCustlist_Bydt(Convert.ToInt32(strFY), fdt, tdt);
                        DDLCustomer.DataBind();
                        DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintCreditNote.aspx?d=" + txtCnno.Text.Trim() + "&fy=" + strFY + "')", true);
    }
    #endregion

    #region TextChanged

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        btnPrint.Visible = false;
        Pnl1.Visible = false;
        Pnl2.Visible = false;
        PnlPrint.Visible = false;
    }
    protected void txttoDate_TextChanged(object sender, EventArgs e)
    {
        btnPrint.Visible = false;
        Pnl1.Visible = false;
        Pnl2.Visible = false;
        PnlPrint.Visible = false;
    }

    #endregion

    #region IndexChanged
    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        frdate = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
        todate = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];

        tdt = Convert.ToDateTime(todate);
        fdt = Convert.ToDateTime(frdate);

        // Rptrpending.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(DDLCustomer.SelectedValue));
        RptrCN.DataSource = CreditNote.GetCNNo_byCust(Convert.ToInt32(strFY), (DDLCustomer.SelectedValue), "All", fdt, tdt);
        RptrCN.DataBind();

        //RptrCN2.DataSource = CreditNote.GetCNNo_byCust((DDLCustomer.SelectedValue), "Manual");
        //RptrCN2.DataBind();

        RptrCN.Visible = true;
        // RptrCN2.Visible = true;
        PnlPrint.Visible = false;
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
            PnlPrint.Visible = false;
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
    public void Bindgrdcn()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        //grdcn.DataSource = CreditNote.PrintCN(CNNo);
        //grdcn.DataBind();
    }

    #endregion

    # endregion

    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RdbtnSelect.SelectedValue == "CN")
        {
            Pnldate.Visible = true;
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            btnPrint.Visible = false;
            PnlPrint.Visible = false;
            txtFromDate.Focus();
            txtFromDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            txttoDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        else if(RdbtnSelect.SelectedValue == "CustomerwiseCN")
        {
            Pnldate.Visible = true;
            Pnl1.Visible = false;
            Pnl2.Visible = false;
            btnPrint.Visible = false;
            PnlPrint.Visible = false;
            txtFromDate.Focus();
        }

        else if (RdbtnSelect.SelectedValue == "All")
        {
            fdt = Convert.ToDateTime("1900/01/01");
            tdt = Convert.ToDateTime("1900/01/01");
            //Pnldate.Visible = false;
            Pnl1.Visible = false;
            btnPrint.Visible = false;
            PnlPrint.Visible = false;
           
            RptrCN.DataSource = CreditNote.GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
            RptrCN.DataBind();

            RptrCN.Visible = true;
            // RptrCN2.Visible = true;
            Pnl2.Visible = true;
            
        }
        }
}
