﻿#region NameSapce

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
using System.IO;
using System.Text;
using System.Web.Services;
#endregion

public partial class UserControls_AddBookMaster : System.Web.UI.UserControl
{
    //pankaj
    #region Variables

    static DataView dv = null;
    static string val = "";
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
        }

        if (!Page.IsPostBack)
        {
            Session["data"] = null;


            //DataView dv = new DataView(BindGvBookDetail().Table);
            DataView dv = new DataView(BindGvBookDetail(strChetanaCompanyName).Table);
            Session["data"] = dv;

            grdBookDetails.DataSource = dv;
            grdBookDetails.DataBind();
            repAlfabets.DataSource = Customer_cs.GetAlphabets();
            repAlfabets.DataBind();
            SetView();
            //txtcode.Focus();
        }
        else
        {

        }
    }

    #endregion

    #region Binddata method

    public DataView BindGvBookDetail()
    {
        DataTable dt = new DataTable();
        dt = Books.GetBookMaster();
        DataView dv = new DataView(dt);
        return dv;
    }

    public DataView BindGvBookDetail(string strChetanaCompanyName)
    {
        DataTable dt = new DataTable();
        dt = Books.GetBookMaster(strChetanaCompanyName);
        DataView dv = new DataView(dt);
        return dv;
    }


    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Book";
                txtcode.Focus();
                lblID.Text = "0";
                Panel1.Visible = true;
                pnlBookDetails.Visible = false;
                btn_Save.Visible = true;
                Label13.Visible = false;
                Label14.Visible = false;
                LblOldqty.Visible = false;
                filter.Visible = false;
                btnprint.Visible = false;
                btnExport.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
            {
                pageName.InnerHtml = "View / Edit Book";
                filter.Focus();
                pnlBookDetails.Visible = true;
                Panel1.Visible = false;
                btn_Save.Visible = false;
                Label13.Visible = true;
                Label14.Visible = true;
                LblOldqty.Visible = true;
                filter.Visible = true;
                btnprint.Visible = true;
                btnExport.Visible = true;
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

    //shweta
    #region Events

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string BookType = txtbktpe.Text.Split(':')[0].Trim();
            string Bookgroup = txtbkgrp.Text.Split(':')[0].Trim();
            string Medium = txtmedm.Text.Split(':')[0].Trim();


            Other_Z.Book_Master.BookMasterProp _objBooks = new Other_Z.Book_Master.BookMasterProp();
            _objBooks.bookID = Convert.ToInt32(lblID.Text);
            _objBooks.BookCode = txtcode.Text.Trim();
            _objBooks.BookName = txtbknam.Text.Trim();
            _objBooks.BookType = BookType;
            _objBooks.Bookgroup = Bookgroup;
            _objBooks.Standard = txtstd.Text.Trim();
            _objBooks.PurchasePrice = Convert.ToDecimal(txtprchse.Text.Trim());
            _objBooks.SellingPrice = Convert.ToDecimal(txtsel.Text.Trim());
            _objBooks.OMPrice = Convert.ToDecimal(txtompce.Text.Trim());
            _objBooks.OIPrice = Convert.ToDecimal(txtOIprice.Text.Trim());
            _objBooks.HSNCode = txtHSNCode.Text.Trim();
            _objBooks.GST = Convert.ToDecimal(txtGST.Text);
            _objBooks.CreatedBy= Convert.ToString(Session["UserName"]).ToString();
            _objBooks.Medium = Medium;
            if (LblOldqty.Text == "")
            {
                LblOldqty.Text = "0";
            }
            if (txtqty.Text.Trim() != "")
            {
                _objBooks.Quantity = (Convert.ToInt32(txtqty.Text.Trim()) + Convert.ToInt32(LblOldqty.Text.Trim()));
            }
            else
            {
                _objBooks.Quantity = 0;
            }
            _objBooks.IsActive = true;

            if (ddlupderte.SelectedItem.Value == "Yes")
            {
                _objBooks.UpdateRate = true;

            }
            else
            {
                _objBooks.UpdateRate = false;

            }
            _objBooks.ChetanaCompanyName = strChetanaCompanyName;
            _objBooks.FY = Convert.ToInt32(strFY);
            if (txtphystock.Text.Trim() != "")
            {
                _objBooks.PhysicalStock = Convert.ToInt32(txtphystock.Text.Trim());
            }
            else
            {
                _objBooks.PhysicalStock = 0;
            }
            if (txtvirtualStock.Text.Trim() != "")
            {
                _objBooks.VirtualStock = Convert.ToInt32(txtvirtualStock.Text.Trim());
            }
            else
            {
                _objBooks.PhysicalStock = 0;
            }
            _objBooks.IsBlock = chekIsactive.Checked;
            Other_Z.Book_Master.Save_BookMaster(_objBooks);
            MessageBox("Record saved successfully");
            grdBookDetails.DataSource = BindGvBookDetail();
            grdBookDetails.DataBind();
            pnlBookDetails.Visible = true;
            Panel1.Visible = false;
            btn_Save.Visible = false;
            filter.Visible = true;
            btnprint.Visible = true;
            chekIsactive.Checked = false;
            lblID.Text = "0";
            txtcode.Text = "";
            txtbknam.Text = "";
            txtbktpe.Text = "";
            txtbkgrp.Text = "";
            txtstd.Text = "";
            txtmedm.Text = "";
            txtqty.Text = "";
            txtprchse.Text = "";
            txtsel.Text = "";
            txtompce.Text = "";
            txtOIprice.Text = "";
            txtHSNCode.Text = "";
            txtGST.Text = "";
        }
        catch
        {

        }
    }
    protected void txtcode_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblID.Text = "0";
        txtbknam.Text = "";
        txtbktpe.Text = "";
        txtbkgrp.Text = "";
        txtstd.Text = "";
        txtmedm.Text = "";
        txtqty.Text = "";
        txtprchse.Text = "";
        txtsel.Text = "";
        txtompce.Text = "";
        txtOIprice.Text = "";
        txtHSNCode.Text = "";
        txtGST.Text = "";
        lblID.Text = "0";
        Panel1.Visible = true;
        pnlBookDetails.Visible = true;
        btnAdd.Visible = false;
        btn_Save.Visible = false;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        pnlBookDetails.Visible = true;
        filter.Visible = true;
        btncancel.Visible = false;
        btn_Save.Visible = false;
    }
    #endregion



    #region BookCode Events

    protected void txtcode_TextChanged1(object sender, EventArgs e)
    {
        string BCode = txtcode.Text.ToString();
        DataTable dt = new DataTable();
        dt = Books.Get_BooksMaster(BCode).Tables[0];
        if (dt.Rows.Count != 0)
        {
            MessageBox("Book Code is Already Exist");
            txtcode.Focus();
            txtcode.Text = "";
        }

    }
    #endregion


    #region Gridview Events

    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Other_Z.Book_Master.BookMasterProp _objBK = new Other_Z.Book_Master.BookMasterProp();
        _objBK.bookID = Convert.ToInt32(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblBkID")).Text);
        _objBK.BookCode = ((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblBkCode")).Text;
        _objBK.BookName = ((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblBkName")).Text;
        _objBK.Standard = ((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblStd")).Text;
        _objBK.Medium = ((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblMdm")).Text;
        _objBK.Quantity = Convert.ToInt32(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblQty")).Text);
        _objBK.PurchasePrice = Convert.ToDecimal(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblPP")).Text);
        _objBK.SellingPrice = Convert.ToDecimal(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblSP")).Text);
        _objBK.OMPrice = Convert.ToDecimal(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblOMP")).Text);
        _objBK.OIPrice = Convert.ToDecimal(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblOIP")).Text);
        _objBK.HSNCode = ((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblHSNCode")).Text;
        _objBK.GST = Convert.ToDecimal(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblGST")).Text);
        _objBK.UpdateRate = Convert.ToBoolean(false);
        _objBK.IsActive = Convert.ToBoolean(false);
        _objBK.IsDeleted = Convert.ToBoolean(true);
        try
        {
            Other_Z.Book_Master.Save_BookMaster(_objBK);
            grdBookDetails.DataSource = BindGvBookDetail();
            grdBookDetails.DataBind();
            pnlBookDetails.Visible = true;
            Panel1.Visible = false;
        }
        catch
        {

        }
    }
    protected void grdBookDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlBookDetails.Visible = false;
        Panel1.Visible = true;
        btn_Save.Visible = true;
        filter.Visible = false;
        btnprint.Visible = false;
        lblID.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblBkID")).Text;
        txtcode.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblBkCode")).Text;
        txtbknam.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblBkName")).Text;
        txtbktpe.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblbktypeId")).Text;
        txtbkgrp.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblbkgroupId")).Text;
        txtstd.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblStd")).Text;
        txtmedm.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblMdm")).Text;
        LblOldqty.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblQty")).Text;
        txtprchse.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblPP")).Text;
        txtsel.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblSP")).Text;
        txtompce.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblOMP")).Text;
        txtOIprice.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblOIP")).Text;
        chekIsactive.Checked = ((CheckBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("chkIsBlock")).Checked;
        txtHSNCode.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblHSnCode")).Text;
        txtGST.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblGST")).Text;
        txtphystock.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblphystk")).Text;
        txtvirtualStock.Text = ((Label)grdBookDetails.Rows[e.NewEditIndex].FindControl("lblvirtstk")).Text;

        bool flg = ((CheckBox)grdBookDetails.Rows[e.NewEditIndex].FindControl("chkUR")).Checked;
        if (flg == false)
        {
            //ddlupderte.Enabled = false;
            ddlupderte.SelectedValue = "No";
        }
        else
        {
            // ddlupderte.Enabled = true;
            ddlupderte.SelectedValue = "Yes";
        }

    }
    protected void grdBookDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBookDetails.PageIndex = e.NewPageIndex;
        grdBookDetails.DataSource = BindGvBookDetail();
        grdBookDetails.DataBind();
    }
    protected void grdBookDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            e.Row.TabIndex = -1;
            e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
            e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
            e.Row.Attributes["onselectstart"] = "javascript:return false;";
        }
    }

    #endregion

    #region Validation Methods

    #region Variables

    private static bool add = false;
    private static bool view = false;
    private static bool edit = false;
    private static bool delete = false;

    #endregion

    public void GetValidation(int Menuid, int Roleid)
    {
        DataTable dt = new DataTable();
        dt = Mappings.Get_MenuFunctions(Menuid, Roleid).Tables[0];
        add = Convert.ToBoolean(dt.Rows[0]["Add"].ToString());
        view = Convert.ToBoolean(dt.Rows[0]["View"].ToString());
        edit = Convert.ToBoolean(dt.Rows[0]["Edit"].ToString());
        delete = Convert.ToBoolean(dt.Rows[0]["Delete"].ToString());
    }

    #endregion

    #region TextChanged Events


    protected void txtbktpe_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string booktypecode = txtbktpe.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            bool Auth = Masters.GetCodeValidation("BookType", booktypecode);
            if (Auth)
            {
                txtbkgrp.Focus();
            }
            else
            {
                MessageBox("Book Type does not Exist");
                txtbktpe.Text = "";
                txtbktpe.Focus();
            }
        }
        catch
        {

        }
    }

    protected void txtbkgrp_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string bookgroupcode = txtbkgrp.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            bool Auth = Masters.GetCodeValidation("BookGroup", bookgroupcode);
            if (Auth)
            {
                txtstd.Focus();
            }
            else
            {
                MessageBox("Book Group does not Exist");
                txtbkgrp.Text = "";
                txtbkgrp.Focus();
            }
        }
        catch
        {

        }
    }

    protected void txtstd_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string standard = txtstd.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            bool Auth = Masters.GetCodeValidation("Standard", standard);
            if (Auth)
            {
                txtmedm.Focus();
            }
            else
            {
                MessageBox("Standard does not Exist");
                txtstd.Text = "";
                txtstd.Focus();
            }
        }
        catch
        {

        }
    }
    protected void txtmedm_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string medium = txtmedm.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            bool Auth = Masters.GetCodeValidation("Medium", medium);
            if (Auth)
            {
                txtprchse.Focus();
            }
            else
            {
                MessageBox("Medium does not Exist");
                txtmedm.Text = "";
                txtmedm.Focus();
            }
        }
        catch
        {

        }
    }
    #endregion

    protected void lnkalfabet_click(object sender, EventArgs e)
    {

        foreach (RepeaterItem item in repAlfabets.Items)
        {
            ((LinkButton)(item.FindControl("lnkalfabet"))).BackColor = System.Drawing.Color.White;
            ((LinkButton)(item.FindControl("lnkalfabet"))).ForeColor = System.Drawing.Color.Black;
        }
        if (Session["data"] != null)
        {
            dv = (DataView)Session["data"];
            val = ((LinkButton)(sender)).Text;
            dv.RowFilter = "BookName like '" + val + "%'";
            grdBookDetails.DataSource = dv;
            grdBookDetails.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintBook.aspx?d=" + val.ToString() + "')", true);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export("BookDetails.xls", this.grdBookDetails);
    }
    public static void Export(string fileName, GridView gv)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
        "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {

                Table table = new Table();

                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                table.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }
}


