#region NameSpaces
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
using System.Web.Services;
using Idv.Chetana.BAL;

#endregion

public partial class UserControls_uc_SetOfBook : System.Web.UI.UserControl
{
    int Qty = 1;
    string bookname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetView();
            BindDDL();
            DDLSet.Items.Insert(0, new ListItem("-Select book set-", "0"));
            Session["tempdata"] = null;
            DDLSet.Focus();
        }
    }
    //    int ID = 0;
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                //lblID.Text = "0";
                BindDDL();
                DDLSet.Items.Insert(0, new ListItem("-Select book set-", "0"));
                Session["tempdata"] = null;
                DDLSet.Focus();
                Panel1.Visible = true;
                btnprint.Visible = false;

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    Panel1.Visible = false;
                    btnprint.Visible = false;

                }
        }
    }
    public void BindDDL()
    {
        string grp = "BookSet";
        DDLSet.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
        DDLSet.DataBind();

    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string bookcode = txtbkcod.Text.Split(':')[0].Trim();
        bookname = txtbkcod.Text.Split(':')[2].Trim();

        DataTable dt = new DataTable();
        if (Session["tempdata"] != null)
        {
            dt = (DataTable)Session["tempdata"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "BookCode = '" + bookcode.Trim() + "'";
            //   if (bookcode =
            int i = 0;
            foreach (DataRowView row in dv)
            {
                i++;
            }
            if (i == 0)
            {
                Session["tempdata"] = fillTempBookData(bookcode.Trim(), "");
                dt = (DataTable)Session["tempdata"];
                loder(bookname + " add successfully");
            }
            else
            {
                loder(bookname + " already added!");

            }
        }
        else
        {
            Session["tempdata"] = fillTempBookData(bookcode.Trim(), "");
            dt = (DataTable)Session["tempdata"];
            loder(bookname + " add successfully");
        }

        grdBooksetDetails.DataSource = dt;
        grdBooksetDetails.DataBind();
        //grdBooksetDetails.Visible = true;
        txtbkcod.Text = "";
        txtbkcod.Focus();

    }


    #region Fill grid data for books

    public DataTable fillTempBookData(string bookcode, string flag)
    {
        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        if (Session["tempdata"] == null)
        {
            dt.Columns.Add("BookSetDetailId");
            dt.Columns.Add("BookSet");
            dt.Columns.Add("BooksetID");
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("SellingPrice");
            dt.Columns.Add("OMPrice");
            dt.Columns.Add("Standard");
        }
        else
        {
            dt = (DataTable)Session["tempdata"];
        }

        if (flag == "set")
        {
            tempGetData = SetofBooks.GetBooksetdetails_ByBooksetID(Convert.ToInt32(DDLSet.SelectedItem.Value)).Tables[0];
        }
        else
        {
            tempGetData = Books.Get_BooksMaster(bookcode).Tables[0];

            tempGetData.Columns.Add("BookSetDetailId").DefaultValue = 0;

        }
        foreach (DataRow row in tempGetData.Rows)
        {
            if (dt.Rows.Count != 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "BookCode = '" + row["BookCode"].ToString() + "'";
                int i = 0;
                foreach (DataRowView row1 in dv)
                {
                    i++;
                }
                if (i == 0)
                {
                    if (row["BookSetDetailId"].ToString() == "")
                    {
                        dt.Rows.Add("0", DDLSet.SelectedItem.Text.ToString(), DDLSet.SelectedItem.Value.ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), "1", string.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), string.Format("{0:0.00}", Convert.ToDecimal(row["OMPrice"].ToString())), row["Standard"].ToString());

                    }
                    else
                    {
                        dt.Rows.Add(row["BookSetDetailId"], DDLSet.SelectedItem.Text.ToString(), DDLSet.SelectedItem.Value.ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), "1", string.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), string.Format("{0:0.00}", Convert.ToDecimal(row["OMPrice"].ToString())), row["Standard"].ToString());

                    }

                }
            }
            else
            {
                if (row["BookSetDetailId"].ToString() == "")
                {
                    dt.Rows.Add("0", DDLSet.SelectedItem.Text.ToString(), DDLSet.SelectedItem.Value.ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), "1", string.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), string.Format("{0:0.00}", Convert.ToDecimal(row["OMPrice"].ToString())), row["Standard"].ToString());

                }
                else
                {
                    dt.Rows.Add(row["BookSetDetailId"], DDLSet.SelectedItem.Text.ToString(), DDLSet.SelectedItem.Value.ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), "1", string.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), string.Format("{0:0.00}", Convert.ToDecimal(row["OMPrice"].ToString())), row["Standard"].ToString());

                }
            }
        }

        return dt;
    }

    #endregion
    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        SetofBooks _objBookset = new SetofBooks();
        if (grdBooksetDetails.Rows.Count == 0)
        {
            // BtnSave.Visible = true;
            MessageBox("Kindly fill Details");
        }
        else
        {
            foreach (GridViewRow row in grdBooksetDetails.Rows)
            {
                _objBookset.BooksetDetailID = Convert.ToInt32(((Label)row.FindControl("lblBSDetailId")).Text);
                _objBookset.BookSetCode = Convert.ToInt32(((Label)row.FindControl("lblBooksetid")).Text);
                _objBookset.BookCode = (((Label)row.FindControl("lblBookCode")).Text);
                string _sp = ((TextBox)row.FindControl("txtSellingprice")).Text;
                if (_sp == string.Empty)
                {
                    _objBookset.SellingPrice = Convert.ToDecimal(0);

                }
                else
                {
                    _objBookset.SellingPrice = Convert.ToDecimal(_sp.ToString());

                }
                string _omp = ((TextBox)row.FindControl("txtOMPrice")).Text;
                if (_omp == string.Empty)
                {
                    _objBookset.OMPrice = Convert.ToDecimal(0);

                }
                else
                {
                    _objBookset.OMPrice = Convert.ToDecimal(_omp.ToString());

                }

                _objBookset.Quantity = Qty;
                _objBookset.IsActive = ChekActive.Checked;
                _objBookset.Save();
            }

            MessageBox("Your BookSet saved sucessfully.");
            Session["tempdata"] = null;
            // DDLSet.SelectedValue = null;
            DDLSet.Focus(); ;
            grdBooksetDetails.Visible = false;

            BtnSave.Visible = false;
            DDLSet.Items.Clear();
            BindDDL();
            DDLSet.Items.Insert(0, new ListItem("-Select book set-", "0"));
            txtbkcod.Text = "";

        }
        Session["tempdata"] = null;
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    protected void grdBooksetDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            SetofBooks _objSOBook = new SetofBooks();
            _objSOBook.BooksetDetailID = Convert.ToInt32(((Label)grdBooksetDetails.Rows[e.RowIndex].FindControl("lblBSDetailId")).Text);
            _objSOBook.BookSetCode = Convert.ToInt32(((Label)grdBooksetDetails.Rows[e.RowIndex].FindControl("lblBooksetid")).Text);
            _objSOBook.BookCode = (((Label)grdBooksetDetails.Rows[e.RowIndex].FindControl("lblBookCode")).Text);
            _objSOBook.SellingPrice = Convert.ToDecimal(((TextBox)grdBooksetDetails.Rows[e.RowIndex].FindControl("txtSellingprice")).Text);
            _objSOBook.OMPrice = Convert.ToDecimal(((TextBox)grdBooksetDetails.Rows[e.RowIndex].FindControl("txtOMPrice")).Text);
            _objSOBook.Quantity = Qty;
            _objSOBook.IsActive = Convert.ToBoolean(false);
            _objSOBook.IsDeleted = Convert.ToBoolean(true);
            _objSOBook.Save();

            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["tempdata"];
            dt1.Rows[e.RowIndex].Delete();
            grdBooksetDetails.DataSource = dt1;
            grdBooksetDetails.DataBind();
            Session["tempdata"] = dt1;

        }
        catch
        {

        }
    }

    protected void DDLSet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSet.SelectedValue != "0")
        {
            Session["tempdata"] = null;
            DataTable dt1 = new DataTable();
            Session["tempdata"] = fillTempBookData("", "set");
            dt1 = (DataTable)Session["tempdata"];
            grdBooksetDetails.DataSource = dt1;
            grdBooksetDetails.DataBind();
            grdBooksetDetails.Visible = true;
            if (Request.QueryString["a"] == "v")
            {
                BtnSave.Visible = false;
                grdBooksetDetails.Columns[5].Visible = false;
                btnprint.Visible = true;
            }
            else
            {
                BtnSave.Visible = true;
            }
            UpanelDDL.Update();
            txtbkcod.Focus();
        }
        else
        {
            grdBooksetDetails.DataSource = null;
            grdBooksetDetails.DataBind();
            BtnSave.Visible = false;
            UpanelDDL.Update();
            Session["tempdata"] = null;
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        DDLSet.SelectedValue = null;
        txtbkcod.Text = "";
        DDLSet.Focus();
        grdBooksetDetails.Visible = false;
        Session["tempdata"] = null;

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('Print/PrintBooks.aspx?d=" + DDLSet.SelectedValue + "&sd=" + DDLSet.SelectedItem.Text.Trim() + "')", true);

        }
        catch
        {
        }
    }
}
