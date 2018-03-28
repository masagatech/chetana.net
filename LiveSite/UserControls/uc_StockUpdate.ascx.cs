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


public partial class UserControls_uc_StockUpdate : System.Web.UI.UserControl
{

    #region Variables
    string bookcode;
    string BookCode1;
    string BookCode2;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {
           BindStock();
        } 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StockUpdate objstk = new StockUpdate();
         bookcode = Txtbkcode.Text.Split(':')[0].Trim();
            objstk.BookCode = bookcode ;
            objstk.OldStock = Convert.ToInt32(TxtCStock.Text);
            objstk.NewStock = Convert.ToInt32(TxtNStock.Text);
            objstk.TotalStock = Convert.ToInt32(TxtTStock.Text);
            objstk.Comment = TxtCom.Text.Trim();
            objstk.CreatedBy = Convert.ToString(Session["UserName"]);
        if (LblStockUpdateID.Text == "0")
        {
            objstk.Save(); 
            MessageBox(Constants.save);
           // BindStock();
            PnlAddStock.Visible = true;
          //  PnlStockDetails.Visible = false;
        }
        else
        {
        }
        try
        {
            Txtbkcode.Text = "";
            TxtCStock.Text = "";
            TxtNStock.Text = "";
            TxtTStock.Text = "";
            TxtCom.Text  = "";
            PnlAddStock.Visible = true;
            //PnlStockDetails.Visible = false;
        }
        catch
        {
        }
    }

    #region BindMethods
    public void BindStock()
    {
        BookCode2 = Txtbkcode1.Text.ToString().Split(':')[0].Trim();
       
        // GrdStock.DataSource = StockUpdate.GetStockUpdate();
       // GrdStock.DataBind();

        //DataTable dt = new DataTable();
        //dt = Idv.Chetana.BAL.StockUpdate.GetStockUpdateRep(bookcode).Tables[0];
        //DataView dv = new DataView(dt);
        //return dv;
        GrdStock.DataSource = StockUpdate.GetStockUpdateRep(BookCode2);
        GrdStock.DataBind();
    }
    #endregion

    #region SetView
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Stock ";
                LblStockUpdateID.Text = "0";
                PnlBkCode.Visible = false;
                PnlStockDetails.Visible = false;
                PnlAddStock.Visible = true;
                btnSave.Visible = true;
               // filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Stock ";
                    PnlBkCode.Visible = true;
                    PnlStockDetails.Visible = true;
                    PnlAddStock.Visible = false;
                    btnSave.Visible = false;
                //    filter.Visible = true;
                }
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


    //protected void GrdStock_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    PnlStockDetails.Visible = false;
    //    PnlAddStock.Visible = true;
    //    btnSave.Visible = true;
    //    filter.Visible = false;
    //    btnSave.Text = "Update";
    //    Txtbkcode.Enabled = false;

    //    try
    //    {
    //        LblStockUpdateID.Text = ((Label)GrdStock.Rows[e.NewEditIndex].FindControl("lblStockUpdateID")).Text;
    //        Txtbkcode.Text = ((Label)GrdStock.Rows[e.NewEditIndex].FindControl("lblBkCode")).Text;
    //        TxtCStock.Text = ((Label)GrdStock.Rows[e.NewEditIndex].FindControl("lblCStock")).Text;
    //        TxtNStock.Text = ((Label)GrdStock.Rows[e.NewEditIndex].FindControl("lblNStock")).Text;
    //        TxtTStock.Text = ((Label)GrdStock.Rows[e.NewEditIndex].FindControl("lblTStock")).Text;
    //        TxtCom.Text = ((Label)GrdStock.Rows[e.NewEditIndex].FindControl("lblCom")).Text;
    //    }
    //    catch
    //    {
    //    }

    //}
    protected void Txtbkcode_TextChanged(object sender, EventArgs e)
    {
        BookCode1 = Txtbkcode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BookCode1, "Book").Tables[0];
        if (dt.Rows.Count != 0)
        {
           // Txtbkcode.Text = BookCode;
            TxtCStock.Text = Convert.ToString(dt.Rows[0]["Quantity"]);
            TxtNStock.Focus();
        }
        else
        {
            //LblCustName.Text = "No such Customer code";
            //TxtCustCode.Focus();
            //TxtCustCode.Text = "";
        }
    }

    protected void Txtbkcode1_TextChanged(object sender, EventArgs e)
    {
        BookCode2 = Txtbkcode1.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BookCode2, "Book").Tables[0];
        if (dt.Rows.Count != 0)
        {

        }
        else
        {
            LblCustName.Text = "No such Customer code";
            //TxtCustCode.Focus();
        }
        BindStock();
    }

    protected void TxtNStock_TextChanged(object sender, EventArgs e)
    {
        int OldStock = Convert.ToInt32(TxtCStock.Text);
        int NewStock;
        if (TxtNStock.Text == "")
        {
            TxtTStock.Text = "";
            //NewStock = 0;
        }
        else
        {
            NewStock = Convert.ToInt32(TxtNStock.Text);
            int TotalStock = (OldStock + NewStock);

            if (TxtCStock.Text != "")
            {
                TxtTStock.Text = Convert.ToString(TotalStock);
                TxtCom.Focus();
            }
        }
    }

}
