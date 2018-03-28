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

public partial class UserControls_ODC_uc_DC__Returnedbook_MDC : System.Web.UI.UserControl
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion

    #region PageLoad
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
            BindGrdCustview();
            PnlCustview.Visible = true;
            Pnl4.Visible = false;
            Pnl5.Visible = false;
            Pnlview.Visible = false;
            //Pnl4view.Visible = false;
        }
    }
    #endregion

    #region Grid Events
    protected void Grdcustview_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string CustCode = ((Label)GrdCustview.Rows[e.NewEditIndex].FindControl("lblCustCode1")).Text;
            string DC = ((Label)GrdCustview.Rows[e.NewEditIndex].FindControl("lblDC1")).Text;

            if (DC == "Y")
            {
                DataTable dt5 = new DataTable();
                dt5 = DCReturnBook.GetCustAddress(CustCode, "RtdBkCustlist").Tables[0];

                if (dt5.Rows.Count > 0)
                {
                    lbl5CustName.Text = dt5.Rows[0]["CustName"].ToString();
                    lbl5CustAddress.Text = dt5.Rows[0]["Address"].ToString();
                }
                Grd5.DataSource = CreditNote.Get_DC_CNBook(Convert.ToInt32(strFY), CustCode, "DCRTDBookAll").Tables[0];
                Grd5.DataBind();

                PnlCustview.Visible = false;
                Pnl5CustDetails.Visible = true;
                Pnl5.Visible = true;
                Pnl4CustDetails.Visible = false;
                Pnl4.Visible = false;
            }
            else
                if (DC == "N")
                {
                    DataTable dt4 = new DataTable();
                    dt4 = DCReturnBook.GetCustAddress(CustCode, "RtdBkCustlist").Tables[0];

                    if (dt4.Rows.Count > 0)
                    {
                        lbl4CustName.Text = dt4.Rows[0]["CustName"].ToString();
                        lbl4CustAddress.Text = dt4.Rows[0]["Address"].ToString();
                    }

                    Grd4.DataSource = CreditNote.Get_DC_CNBook(Convert.ToInt32(strFY), CustCode, "DCRTDBook").Tables[0];
                    Grd4.DataBind();

                    PnlCustview.Visible = false;
                    Pnl5CustDetails.Visible = false;
                    Pnl5.Visible = false;
                    Pnl4CustDetails.Visible = true;
                    Pnl4.Visible = true;
                }
        }
        catch
        {
        }
    }

    protected void Grd4_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int rtqty4 = Convert.ToInt32(((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4rtqty")).Text);
            string BookCode2 = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4bkcode")).Text;
            string CustCode2 = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4custcode")).Text;

            GrdView.DataSource = CreditNote.Get_DC_CNBkview(Convert.ToInt32(strFY), CustCode2, BookCode2);
            GrdView.DataBind();
            if (rtqty4 != 0)
            {
                Pnl4CustDetails.Visible = true;
                Pnl4.Visible = true;
                PnlBkdetails.Visible = true;
                Pnlview.Visible = true;
                //Pnl4Bkdetails.Visible = true;
                //Pnl4view.Visible = true;
                lbbkcode1.Text = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4bkcode")).Text;
                lbName1.Text = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4Name")).Text;
            }
            else
            {
                Pnl4CustDetails.Visible = true;
                Pnl4.Visible = true;
                PnlBkdetails.Visible = false;
                Pnlview.Visible = false;
                //Pnl4Bkdetails.Visible = false;
                //Pnl4view.Visible = false;
            }
        }
        catch
        {
        }
    }

    protected void Grd5_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int rtqty5 = Convert.ToInt32(((Label)Grd5.Rows[e.NewEditIndex].FindControl("lbl5rtqty")).Text);
            string BookCode5 = ((Label)Grd5.Rows[e.NewEditIndex].FindControl("lbl5bkcode")).Text;
            string CustCode5 = ((Label)Grd5.Rows[e.NewEditIndex].FindControl("lbl5custcode")).Text;

            GrdView.DataSource = CreditNote.Get_DC_CNBkview(Convert.ToInt32(strFY), CustCode5, BookCode5);
            GrdView.DataBind();
            if (rtqty5 != 0)
            {
                Pnl5CustDetails.Visible = true;
                Pnl5.Visible = true;
                PnlBkdetails.Visible = true;
                Pnlview.Visible = true;
                lbbkcode1.Text = ((Label)Grd5.Rows[e.NewEditIndex].FindControl("lbl5bkcode")).Text;
                lbName1.Text = ((Label)Grd5.Rows[e.NewEditIndex].FindControl("lbl5Name")).Text;
            }
            else
            {
                Pnl5CustDetails.Visible = true;
                Pnl5.Visible = true;
                PnlBkdetails.Visible = false;
                Pnlview.Visible = false;
            }
        }
        catch
        {
        }
    }
    #endregion

    # region Methods
    public void BindGrdCustview()
    {
        GrdCustview.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "RtdBkCustlistMDC").Tables[0];
        GrdCustview.DataBind();
        if (GrdCustview.Rows.Count == 0)
        {
            MessageBox("There is no Returned Book Record ");
        }
        else
        {
        }

    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    #endregion
}
