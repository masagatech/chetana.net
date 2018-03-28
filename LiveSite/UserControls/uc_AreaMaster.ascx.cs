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
using System.IO;
using System.Text; 


public partial class UserControls_uc_AreaMaster : System.Web.UI.UserControl
{
    #region Variables
    static DataView dv = null;
    static string val="";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();

        if (!Page.IsPostBack)
        {
            grdAreaDetails.DataSource = BindGvAreaDetail();
            grdAreaDetails.DataBind();
            DataView dv = new DataView(BindGvAreaDetail().Table);
            Session["data"] = dv;

            Bind_DDL_SuperZone();
            repAlfabets.DataSource = Customer_cs.GetAlphabets();
            repAlfabets.DataBind();
        }
        else
        {
            // pnlArea.Visible = true;
        }
    }
    #endregion

    #region Binddata method

    public void Bind_DDL_AreaZone()
    {
        DDLAreaZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLZone.SelectedValue.ToString()), "AreaZone");
        DDLAreaZone.DataBind();
        DDLAreaZone.Items.Insert(0, new ListItem("-Select Area Zone-", "none"));
    }
    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "none"));
        DDLZone.Items.Clear();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
        DDLAreaZone.Items.Clear();
        DDLAreaZone.Items.Insert(0, new ListItem("-Select Area Zone-", "none"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "none"));
        DDLAreaZone.Items.Clear();
        DDLAreaZone.Items.Insert(0, new ListItem("-Select Area Zone-", "none"));
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Area ";
                lblID.Text = "0";
                txtAreaCode.Focus();
                pnlAreaDetails.Visible = false;
                pnlArea.Visible = true;
                btnSave.Visible = true;
                filter.Visible = false;
                btnprint.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Area ";
                    pnlAreaDetails.Visible = true;
                    pnlArea.Visible = false;
                    btnSave.Visible = false;
                    filter.Visible = true;
                    filter.Focus();
                    btnprint.Visible = true;
                }
        }
    }

    public DataView BindGvAreaDetail()
    {
        DataTable dt = new DataTable();
        dt = AreaMaster.GetAreaMaster();
        DataView dv = new DataView(dt);
        return dv;
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    txtAreaCode.Text = "";
    //    txtAreaName.Text = "";
      

    //    lblID.Text = "0";
    //    pnlArea.Visible = true;
    //    pnlAreaDetails.Visible = false;
    //}
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AreaMaster _objAm = new AreaMaster();
        _objAm.AreaID = Convert.ToInt32(lblID.Text);
        _objAm.AreaCode = txtAreaCode.Text.Trim();
        _objAm.AreaName = txtAreaName.Text.Trim();
        _objAm.AreaZoneID = Convert.ToInt32(DDLAreaZone.SelectedItem.Value.ToString());
        _objAm.IsActive = Chekacv.Checked; 
        try
        {
            _objAm.Save();
            MessageBox("Record saved successfully");
            grdAreaDetails.DataSource = BindGvAreaDetail();
            grdAreaDetails.DataBind();
            if (btnSave.Text == "Update")
            {
                pnlAreaDetails.Visible = true;
                pnlArea.Visible = false;
                btnSave.Visible = false;
                btnSave.Text = "Save";
                txtAreaCode.Enabled = true;
                filter.Visible = true;
                btnprint.Visible = true;
            }
            else
            {
                pnlAreaDetails.Visible = false;
                pnlArea.Visible = true;
                txtAreaCode.Focus();
                txtAreaCode.Text = "";
                txtAreaName.Text = "";
                DDLZone.Items.Clear();
                DDLAreaZone.Items.Clear();
                DDLSuperZone.SelectedValue = null;
                Bind_DDL_SuperZone(); 
            }
        }
        catch
        {

        }
    }

    protected void grdAreaDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

        pnlAreaDetails.Visible = false;
        pnlArea.Visible = true;
        btnSave.Visible = true;
        filter.Visible = false;
        btnprint.Visible = false;
        btnSave.Text = "Update";
        txtAreaCode.Enabled = false;
        try
        {
            lblID.Text = ((Label)grdAreaDetails.Rows[e.NewEditIndex].FindControl("lblAreaID")).Text;
            DDLSuperZone.SelectedValue = ((Label)grdAreaDetails.Rows[e.NewEditIndex].FindControl("lblSuperZoneID")).Text;
            Bind_DDL_Zone();
            DDLZone.SelectedValue = ((Label)grdAreaDetails.Rows[e.NewEditIndex].FindControl("lblZoneID")).Text;
            Bind_DDL_AreaZone();
            DDLAreaZone.SelectedValue = ((Label)grdAreaDetails.Rows[e.NewEditIndex].FindControl("lblAreaZoneID")).Text;
            txtAreaCode.Text = ((Label)grdAreaDetails.Rows[e.NewEditIndex].FindControl("lblAreaCode")).Text;
            txtAreaName.Text = ((Label)grdAreaDetails.Rows[e.NewEditIndex].FindControl("lblAreaName")).Text;
            Chekacv.Checked = ((CheckBox)grdAreaDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
        }
        catch
        {
        }
    }

    protected void grdAreaDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AreaMaster _objAM = new AreaMaster();
        try
        {
        _objAM.AreaID = Convert.ToInt32(((Label)grdAreaDetails.Rows[e.RowIndex].FindControl("lblAreaID")).Text);
        _objAM.AreaCode = ((Label)grdAreaDetails.Rows[e.RowIndex].FindControl("lblAreaCode")).Text;
        _objAM.AreaName = ((Label)grdAreaDetails.Rows[e.RowIndex].FindControl("lblAreaName")).Text;
        //_objAM.AreaZoneID = ((Label)grdAreaDetails.Rows[e.RowIndex].FindControl("lblAreaZoneID")).Text;

        _objAM.IsActive = Convert.ToBoolean(false);
        _objAM.IsDeleted = Convert.ToBoolean(true);
       
            _objAM.Save();
            //      MessageBox("Your record is Deleted");
            grdAreaDetails.DataSource = BindGvAreaDetail();
            grdAreaDetails.DataBind();
            pnlAreaDetails.Visible = true;
            pnlArea.Visible = false;
        }
        catch
        {

        }
    }

    protected void grdAreaDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAreaDetails.PageIndex = e.NewPageIndex;
        grdAreaDetails.DataSource = BindGvAreaDetail();
        grdAreaDetails.DataBind();
    }
    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            DDLZone.Focus();
            Bind_DDL_Zone();
         //   Bind_DDL_SuperZone();
        }
        else 
        {
                Bind_DDL_AreaZone();
                DDLAreaZone.Focus();
        }

    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
        //    DDLZone.Items.Clear();
            Bind_DDL_SuperZone();
         //   DDLAreaZone.Items.Clear();
          
        }
        else 
        { 
            Bind_DDL_Zone();
            DDLZone.Focus();
        }

    }
    protected void txtAreaCode_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("Area", txtAreaCode.Text.Trim());
        if (Auth)
        {
            MessageBox("Area Code already exist");
            txtAreaCode.Text = "";
            txtAreaCode.Focus();
        }
        else
        {
            txtAreaName.Focus();
        }
    }

    protected void grdAreaDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            e.Row.TabIndex = -1;
            e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
            e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
            e.Row.Attributes["onselectstart"] = "javascript:return false;";
        }
    }
    protected void DDLAreaZone_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

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
            dv.RowFilter = "AreaName like '" + val + "%'";
            grdAreaDetails.DataSource = dv;
            grdAreaDetails.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Export("MyExcelfile.xls", this.grdAreaDetails);
       // Response.AddHeader("content-disposition", "Attachment; filename ="+ "Area.xls");
       // Response.Charset = "";
       // Response.ContentType = "application/excel";
       // StringWriter sw = new StringWriter();
       // HtmlTextWriter htw = new HtmlTextWriter(sw);
       // grdAreaDetails.RenderControl(htw);
       //// ctl00_ContentPlaceHolder1_uc_AreaMaster1_grdAreaDetails.RenderControl(htw);
       // Response.Write(sw);
       // Response.End();



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


    protected void btnprint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintArea.aspx?d=" + val.ToString() + "')", true);
    }
    
}

