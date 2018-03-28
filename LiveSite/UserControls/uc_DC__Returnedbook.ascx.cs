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

#endregion

public partial class UserControls_ODC_uc_DC__Returnedbook : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Pnl1.Visible = true;
            PnlCustDetails.Visible = false;
            Pnl3.Visible = false;
            Pnlview.Visible = false;
            DDLCustomer.Focus();
            BindDDlCust();
        }
    }
    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrd3();
        if (Grd3.Rows.Count > 0)
        {
            Grd3.Focus();
            Pnl3.Visible = true;
            Pnlview.Visible = false;
            DataTable dt = new DataTable();
            dt = DCReturnBook.GetCustAddress((DDLCustomer.SelectedValue), "RtdBkCustlist").Tables[0];

            if(dt.Rows.Count>0)
            {
                lblCustName.Text = dt.Rows[0]["CustName"].ToString();
                lblCustAddress.Text = dt.Rows[0]["Address"].ToString();
            }
        }
        else
        {
            PnlCustDetails.Visible = false;
            Pnl3.Visible = false;
            Pnlview.Visible = false;
            if (DDLCustomer.SelectedIndex == 0)
            {
            }
            else
            {
                MessageBox("Record Not Available");
            }
        }
    }
    //protected void btnview_Click(object sender, EventArgs e)
    //{
    //    BindGrd3();
    //    if (Grd3.Rows.Count > 0)
    //    {
    //        Grd3.Focus();
    //        Panel3.Visible = true;
    //        Panelview.Visible = false;
    //    }
    //    else
    //    {
    //        MessageBox("Record Not Available");
    //    }
    //}

    #region Binddata method
    public void BindGrd3()
    {
        Grd3.DataSource = DCReturnBook.Get_DC_ReturnBook((DDLCustomer.SelectedValue), "DCrtbk").Tables[1];
        Grd3.DataBind();
    }
    public void BindDDlCust()
    {
        DDLCustomer.DataSource = CreditNote.GetCustlist("RtdBkCustlist");
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    #endregion

    protected void Grd3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int rtqty = Convert.ToInt32(((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1rtqty")).Text);
            string BookCode = ((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1bkcode")).Text;
            GrdView.DataSource = DCReturnBook.Get_DC_ReturnBkview((DDLCustomer.SelectedValue), BookCode);
            GrdView.DataBind();
            if (rtqty != 0)
            {
                PnlCustDetails.Visible = true;
                Pnl3.Visible = true;
                PnlBkdetails.Visible = true;
                Pnlview.Visible = true;
                lbbkcode1.Text = ((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1bkcode")).Text;
                lbName1.Text = ((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1Name")).Text;
            }
            else
            {
                PnlCustDetails.Visible = true;
                Pnl3.Visible = true;
                PnlBkdetails.Visible = false;
                Pnlview.Visible = false;
            }
        }
        catch
        {
        }
    }
  
}
