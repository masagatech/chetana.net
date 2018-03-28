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


public partial class UserControls_uc_BookVirtualStock : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Txtbkcode.Focus();
        if (!Page.IsPostBack)
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BookVirtualStock objvstk = new BookVirtualStock();
        string bookcode = Txtbkcode.Text.Split(':')[0].Trim();
        objvstk.BookCode = bookcode;
        objvstk.CurrentStock = Convert.ToInt32(TxtCStock.Text);
        //objvstk.VirtualStock = Convert.ToInt32(TxtCVStock.Text);
        // objvstk.NewStock = Convert.ToInt32(TxtNStock.Text);
        objvstk.VirtualStock = Convert.ToInt32(TxtTStock.Text);
        objvstk.Comment = TxtCom.Text.Trim();
        objvstk.CreatedBy = Convert.ToString(Session["UserName"]);
        if (Txtbkcode.Text != "")
        {
            objvstk.Save();
            MessageBox(Constants.save);
            PnlVAddStock.Visible = true;
        }
        else
        {
        }
        try
        {
            Txtbkcode.Text = "";
            TxtCVStock.Text = "";
            TxtCStock.Text = "";
            TxtNStock.Text = "";
            TxtTStock.Text = "";
            TxtCom.Text = "";
            PnlVAddStock.Visible = true;
        }
        catch
        {
        }
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    protected void Txtbkcode_TextChanged(object sender, EventArgs e)
    {
        string BookCode = Txtbkcode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BookCode, "Book").Tables[0];
        if (dt.Rows.Count != 0)
        {
            TxtCStock.Text = Convert.ToString(dt.Rows[0]["Quantity"]);
            //TxtNStock.Focus();
        }
        dt = DCMaster.Get_Name(BookCode, "VBook").Tables[0];
        if (dt.Rows.Count != 0)
        {
            TxtCVStock.Text = Convert.ToString(dt.Rows[0]["VirtualStock"]);
            TxtNStock.Focus();
        }
        else
        {
           
        }
    }

    protected void TxtNStock_TextChanged(object sender, EventArgs e)
    {
        int OldStock = Convert.ToInt32(TxtCVStock.Text);
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
