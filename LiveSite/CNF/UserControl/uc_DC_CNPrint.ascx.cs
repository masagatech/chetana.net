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
using Idv.Chetana.CnF;
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

    string strFY;
    #endregion

    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
       // CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        //CustCode = Convert.ToInt32(DDLCustomer.SelectedValue)
       
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
            
            btnPrint.Visible = false;
            
            Pnl2.Visible = true;
            PnlPrint.Visible = false;
           // BindDDlCust();
            fdt = Convert.ToDateTime("1900/01/01");
            tdt = Convert.ToDateTime("1900/01/01");
            RptrCN.DataSource = C_CreditNote.C_GetCNNo_Bydt(Convert.ToInt32(strFY), fdt, tdt);
            RptrCN.DataBind();
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
        DataSet ds = new DataSet();
        ds = C_CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);
        // Bindgrdcn();
        grdcn.DataSource = ds.Tables[0];
        grdcn.DataBind();
       
        if (ds.Tables[1].Rows.Count > 0)
        {
            lblCustName.Text = ds.Tables[1].Rows[0]["CustName"].ToString();
            lblCustAddress.Text = ds.Tables[1].Rows[0]["Address"].ToString();
        }
        PnlPrint.Visible = true;
        btnPrint.Visible = true;
    }
   
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('CNF/print/PrintCreditNote.aspx?d=" + txtCnno.Text.Trim() + "&fy=" + strFY + "')", true);
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
            //Label lblamt1 = (Label)e.Row.FindControl("lblamt");
            //tamount = tamount + Convert.ToDecimal(lblamt1.Text.Trim());
            Label lblnamt1 = (Label)e.Row.FindControl("lblnamt");
            tnamount = tnamount + Convert.ToDecimal(lblnamt1.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblqty2 = (Label)e.Row.FindControl("lbltqty");
            lblqty2.Text = quantity.ToString().Trim();
            //Label lblamt2 = (Label)e.Row.FindControl("lbltamt");
            //lblamt2.Text = tamount.ToString().Trim();
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
   
    public void Bindgrdcn()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        //grdcn.DataSource = CreditNote.PrintCN(CNNo);
        //grdcn.DataBind();
    }

    #endregion

    # endregion

   
}
