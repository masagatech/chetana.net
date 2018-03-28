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

public partial class UserControls_ODC_uc_DC_Returnedbook_MD : System.Web.UI.UserControl
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion

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
            BindGrdCustviewDC();
            BindGrdCustviewM();
            BindGrdCustviewMDC();
            BindGrdCustview();

            PnlCustviewDC.Visible = false;
            PnlCustviewM.Visible = false;
            PnlCustviewMDC.Visible = false;
            PnlCustview.Visible = false;

            PnlCustview.Visible = true;
            Pnl3.Visible = false;
            Pnl4.Visible = false;
            Pnl5.Visible = false;
           // PnlCustDetails.Visible = false;
           // Pnl4CustDetails.Visible = false;
           // PnlBkdetails.Visible = false;
            //Pnl4Bkdetails.Visible = false;
            Pnlview.Visible = false;
            Pnl4view.Visible = false;
        }
    }

    #region Binddata method
    public void BindGrdCustviewDC()
    {
        GrdCustviewDC.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "RtdBkCustlistDC");
        GrdCustviewDC.DataBind();
    }
    public void BindGrdCustviewM()
    {
        GrdCustviewM.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "RtdBkCustlistM");
        GrdCustviewM.DataBind();
    }
    public void BindGrdCustviewMDC()
    {
        GrdCustviewMDC.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "RtdBkCustlistMDC").Tables[1];
        GrdCustviewMDC.DataBind();
    }
    public void BindGrdCustview()
    {
        GrdCustview.DataSource = CreditNote.GetCustlist(Convert.ToInt32(strFY), "RtdBkCustlistMDC").Tables[0];
        GrdCustview.DataBind();
    }

    public void BindGrd3()
    {
      //  Grd3.DataSource = DCReturnBook.Get_DC_ReturnBook((DDLCustomer.SelectedValue), "DCrtbk").Tables[1];
       // Grd3.DataBind();
    }

    #endregion

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
                Grd5.DataSource = DCReturnBook.Get_DC_ReturnBook(CustCode, "DCRTDBookAll").Tables[0]; 
                Grd5.DataBind();

                Pnl5CustDetails.Visible = true;
                Pnl5.Visible = true;
                Pnl4CustDetails.Visible = false;
                Pnl4.Visible = false;
                PnlCustDetails.Visible = false;
                Pnl3.Visible = false;
                Pnlview.Visible = false;
                PnlBkdetails.Visible = false;
                Pnl4view.Visible = false;
                Pnl4Bkdetails.Visible = false;
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

                    Grd4.DataSource = DCReturnBook.Get_DC_ReturnBook(CustCode, "DCRTDBook").Tables[0];
                    Grd4.DataBind();

                    Pnl5CustDetails.Visible = false;
                    Pnl5.Visible = false;
                    Pnl4CustDetails.Visible = true;
                    Pnl4.Visible = true;
                    PnlCustDetails.Visible = false;
                    Pnl3.Visible = false;
                    Pnlview.Visible = false;
                    PnlBkdetails.Visible = false;
                    Pnl4view.Visible = false;
                    Pnl4Bkdetails.Visible = false;
                }
        }
        catch
        {
        }
    }

    protected void Grd3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int rtqty = Convert.ToInt32(((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1rtqty")).Text);
            string BookCode1 = ((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1bkcode")).Text;
            string CustCode1 = ((Label)Grd3.Rows[e.NewEditIndex].FindControl("lbl1custcode")).Text;

            GrdView.DataSource = DCReturnBook.Get_DC_ReturnBkview(CustCode1, BookCode1);
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

    protected void Grd4_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int rtqty4 = Convert.ToInt32(((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4rtqty")).Text);
            string BookCode2 = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4bkcode")).Text;
            string CustCode2 = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4custcode")).Text;

            Grd4View.DataSource = DCReturnBook.Get_DC_ReturnBkview(CustCode2, BookCode2);
            Grd4View.DataBind();
            if (rtqty4 != 0)
            {
                Pnl4CustDetails.Visible = true;
                Pnl4.Visible = true;
                Pnl4Bkdetails.Visible = true;
                Pnl4view.Visible = true;
                lb4bkcode.Text = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4bkcode")).Text;
                lb4Name.Text = ((Label)Grd4.Rows[e.NewEditIndex].FindControl("lbl4Name")).Text;
            }
            else
            {
                Pnl4CustDetails.Visible = true;
                Pnl4.Visible = true;
                Pnl4Bkdetails.Visible = false;
                Pnl4view.Visible = false;
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

            GrdView.DataSource = DCReturnBook.Get_DC_ReturnBkview(CustCode5, BookCode5);
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


    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pnl3.Visible = false;
        Pnl4.Visible = false;
        if (RdbtnSelect.SelectedValue == "DC")
        {
            PnlCustviewDC.Visible = true;
            PnlCustviewM.Visible = false;
            PnlCustviewMDC.Visible = false;
            PnlCustview.Visible = false;

            Pnl3.Visible = false;
            Pnl4.Visible = false;
            Pnl5.Visible = false;

            Pnlview.Visible = false;
            PnlBkdetails.Visible = false;
            Pnl4view.Visible = false;
            Pnl4Bkdetails.Visible = false;
        }
        if (RdbtnSelect.SelectedValue == "Manual")
        {
            PnlCustviewDC.Visible = false;
            PnlCustviewM.Visible = true;
            PnlCustviewMDC.Visible = false;
            PnlCustview.Visible = false;

            Pnl3.Visible = false;
            Pnl4.Visible = false;
            Pnl5.Visible = false;

            Pnlview.Visible = false;
            PnlBkdetails.Visible = false;
            Pnl4view.Visible = false;
            Pnl4Bkdetails.Visible = false;
        }
        if (RdbtnSelect.SelectedValue == "Both")
        {
            PnlCustviewDC.Visible = false;
            PnlCustviewM.Visible = false;
            PnlCustviewMDC.Visible = true;
            PnlCustview.Visible = false;

            Pnl3.Visible = false;
            Pnl4.Visible = false;
            Pnl5.Visible = false;

            Pnlview.Visible = false;
            PnlBkdetails.Visible = false;
            Pnl4view.Visible = false;
            Pnl4Bkdetails.Visible = false;
        }
        if (RdbtnSelect.SelectedValue == "All")
        {
            PnlCustviewDC.Visible = false;
            PnlCustviewM.Visible = false;
            PnlCustviewMDC.Visible = false;
            PnlCustview.Visible = true;

            Pnl3.Visible = false;
            Pnl4.Visible = false;
            Pnl5.Visible = false;

            Pnlview.Visible = false;
            PnlBkdetails.Visible = false;
            Pnl4view.Visible = false;
            Pnl4Bkdetails.Visible = false;
        }
    }

    protected void GrdCustviewDC_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string CustCode = ((Label)GrdCustviewDC.Rows[e.NewEditIndex].FindControl("lblCustCodeDC")).Text;
            //string DC = ((Label)GrdCustviewDC.Rows[e.NewEditIndex].FindControl("lblDC1")).Text;
           
                DataTable dt3 = new DataTable();
                dt3 = DCReturnBook.GetCustAddress(CustCode, "RtdBkCustlist").Tables[0];

                if (dt3.Rows.Count > 0)
                {
                    lblCustName.Text = dt3.Rows[0]["CustName"].ToString();
                    lblCustAddress.Text = dt3.Rows[0]["Address"].ToString();
                }

                Grd3.DataSource = DCReturnBook.Get_DC_ReturnBook(CustCode, "DCrtbkDC").Tables[1];
                Grd3.DataBind();

                PnlCustDetails.Visible = true;
                Pnl3.Visible = true;
                Pnl4CustDetails.Visible = false;
                Pnl4.Visible = false;
                Pnl5CustDetails.Visible = false;
                Pnl5.Visible = false;
                Pnlview.Visible = false;
                PnlBkdetails.Visible = false;
                Pnl4view.Visible = false;
                Pnl4Bkdetails.Visible = false;
        }
        catch
        {
        }
    }
    protected void GrdCustviewM_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string CustCode = ((Label)GrdCustviewM.Rows[e.NewEditIndex].FindControl("lblCustCodeM")).Text;
          //  string DC = ((Label)GrdCustview.Rows[e.NewEditIndex].FindControl("lblDC1")).Text;

        DataTable dt4 = new DataTable();
        dt4 = DCReturnBook.GetCustAddress(CustCode, "RtdBkCustlist").Tables[0];

        if (dt4.Rows.Count > 0)
        {
            lbl4CustName.Text = dt4.Rows[0]["CustName"].ToString();
            lbl4CustAddress.Text = dt4.Rows[0]["Address"].ToString();
        }

        Grd4.DataSource = DCReturnBook.Get_DC_ReturnBook(CustCode, "DCRTDBook").Tables[0];
        Grd4.DataBind();

        Pnl5CustDetails.Visible = false;
        Pnl5.Visible = false;
        Pnl4CustDetails.Visible = true;
        Pnl4.Visible = true;
        PnlCustDetails.Visible = false;
        Pnl3.Visible = false;
        Pnlview.Visible = false;
        PnlBkdetails.Visible = false;
        Pnl4view.Visible = false;
        Pnl4Bkdetails.Visible = false;
        }
        catch
        {
        }
    }
    protected void GrdCustviewMDC_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string CustCode = ((Label)GrdCustviewMDC.Rows[e.NewEditIndex].FindControl("lblCustCodeMDC")).Text;
        //string DC = ((Label)GrdCustview.Rows[e.NewEditIndex].FindControl("lblDC1")).Text;

            DataTable dt3 = new DataTable();
            dt3 = DCReturnBook.GetCustAddress(CustCode, "RtdBkCustlist").Tables[0];

            if (dt3.Rows.Count > 0)
            {
                lblCustName.Text = dt3.Rows[0]["CustName"].ToString();
                lblCustAddress.Text = dt3.Rows[0]["Address"].ToString();
            }

            Grd3.DataSource = DCReturnBook.Get_DC_ReturnBook(CustCode, "DCrtbk").Tables[1];
            Grd3.DataBind();

            PnlCustDetails.Visible = true;
            Pnl3.Visible = true;
            Pnl4CustDetails.Visible = false;
            Pnl4.Visible = false;
            Pnl5CustDetails.Visible = false;
            Pnl5.Visible = false;
            Pnlview.Visible = false;
            PnlBkdetails.Visible = false;
            Pnl4view.Visible = false;
            Pnl4Bkdetails.Visible = false;
        
    }
}
