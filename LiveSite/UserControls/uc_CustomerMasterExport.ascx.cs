#region NameSapce
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
using Others;
#endregion

public partial class UserControls_uc_CustomerMasterExport : System.Web.UI.UserControl
{
    #region Variables
    static DataView dv = null;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["data"] = null;
                this.GetSuperDuperZoneData();
                this.BindCustCategory();
                //this.GetCustomerData();
            }
            else
            {
                pnlCustomerMaster.Visible = true;
            }


        }
        catch (Exception ex)
        {
            MessageBox(ex.ToString());
        }
    }

    public void BindCustCategory()
    {
        DDLCC.DataSource = Others.CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("All Category", "0"));
        DDLCC.Enabled = true;
    }

    private void GetSuperDuperZoneData()
    {

        ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
        ddlSDZone.DataBind();
        ddlSDZone.Items.Insert(0, new ListItem("All Super Duper Zone-", "0"));
        ddlSDZone.Focus();
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("All Super Zone", "0"));
    }
    private void GetCustomerData()
    {
        //MessageBox("coming1" + grdCustomerMaster.Rows.Count.ToString());
        DataView dv = new DataView(BindCustomerMasterDetail().Table);

        if (ddlAtoZ.SelectedIndex == 0)
        {
            Session["data"] = dv;

        }
        else
        {
            dv.RowFilter = "CustName like '%" + ddlAtoZ.Text + "'";
            Session["data"] = dv;
        }


        //grdCustomerMaster.DataSource = this.BindCustomerMasterDetail();
        grdCustomerMaster.DataSource = dv.ToTable();
        grdCustomerMaster.DataBind();

        if (dv.Count > 0)
            btnExport.Visible = true;
        btnnewexport.Visible = true;

        //repAlfabets.DataSource = Customer_cs.GetAlphabets();
        //repAlfabets.DataBind();

        pnlCustomerMaster.Visible = true;
    }
    #endregion

    #region Binddata method


    public DataView BindCustomerMasterDetail()
    {
        try
        {
            DataTable dt = new DataTable();
            //dt = Customer_cs.Get_CustList("ExportCustomerNew", "");
            //Response.Write("Before");
            dt = OtherClass.Get_CustomerData_For_Export("ExportCustomerNew", DDLCC.SelectedValue.ToString(), ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString());
            //Response.Write("After");
            DataView dv = new DataView(dt);

            return dv;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
            DataView dv = new DataView();
            return dv;
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

    #region
    protected void btnnewexport_Click(object sender, EventArgs e)
    {
        DataTable dt = OtherClass.Get_CustomerData_For_Export("ExportCustInvAmt", DDLCC.SelectedValue.ToString(), ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString());
        if (dt.Rows.Count > 0)
        {
            ExportToExcel(dt);
        }
        else
        {
            MessageBox("Record Not Found");
        }
    }
    #endregion

    #region Events

    #region Methods

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (Session["data"] != null)
        {
            ExportToExcel(((DataView)Session["data"]).ToTable());
        }

        //Export("CustomerMaster.xls", this.grdCustomerMaster);
        //Export("CustomerMaster.xls",  (GridView) Session["data"] );
    }

    #region Export to Excel - In use

    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string filename = "CustomerMasterExport.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();

            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
    }

    #endregion


    #region Export to Excel - Old - Not in use


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

    #endregion

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
            string val = ((LinkButton)(sender)).Text;
            dv.RowFilter = "CustName like '" + val + "%'";
            grdCustomerMaster.DataSource = dv;
            grdCustomerMaster.DataBind();
            ((LinkButton)(sender)).BackColor = System.Drawing.Color.Red;
            ((LinkButton)(sender)).ForeColor = System.Drawing.Color.White;
        }
    }
    #endregion

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");

            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();

            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("All", "0"));
        }
        else
        {
            Bind_DDL_SuperZone();
            DDLSuperZone.Focus();
        }
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.Items.Clear();
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        Session["data"] = null;
        ddlAtoZ.SelectedIndex = 0;

        this.GetCustomerData();
    }

    protected void ddlAtoZ_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["data"] != null)
        {
            DataView dv = (DataView)Session["data"];
            if (ddlAtoZ.SelectedIndex == 0)
            {
                Session["data"] = dv;
            }
            else
            {
                dv.RowFilter = "CustName like '" + ddlAtoZ.Text + "%'";
                Session["data"] = dv;
            }
            grdCustomerMaster.DataSource = dv.ToTable();
            grdCustomerMaster.DataBind();
        }
    }
}

