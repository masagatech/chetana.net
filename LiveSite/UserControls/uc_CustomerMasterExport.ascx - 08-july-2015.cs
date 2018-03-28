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
            SetView();
            if (!Page.IsPostBack)
            {
                grdCustomerMaster.DataSource = BindCustomerMasterDetail();
                grdCustomerMaster.DataBind();
                //MessageBox("coming1" + grdCustomerMaster.Rows.Count.ToString());
                DataView dv = new DataView(BindCustomerMasterDetail().Table);
                Session["data"] = dv;
                //Bind_DDL_SDZone();
                repAlfabets.DataSource = Customer_cs.GetAlphabets();
                repAlfabets.DataBind();
                pnlCustomerMaster.Visible = true;
            }
            else
            {
                pnlCustomerMaster.Visible = true;
            }

           
        }
        catch(Exception ex)
        {
            MessageBox(ex.ToString());
        }
    }
    #endregion

    #region Binddata method

    public void SetView()
    {
        //if (Request.QueryString["a"] != null)
        //{
        //    if (Request.QueryString["a"] == "a")
        //    {
        //        pageName.InnerHtml = "Add Super Zone ";
        //        lblID.Text = "0";
        //        pnlSuperZoneDetails.Visible = false;
        //        txtSZCode.Focus();
        //        pnlSuperZone.Visible = true;
        //        btnSave.Visible = true;
        //        filter.Visible = false;
        //    }
        //    else
        //    if (Request.QueryString["a"] == "v")
        //    {
        //        pageName.InnerHtml = "View / Edit Super Zone ";               
        //        filter.Focus();
        //        pnlSuperZoneDetails.Visible = true;
        //        pnlSuperZone.Visible = false;
        //        btnSave.Visible = false;
        //        filter.Visible = true;
        //    }
        //}
    }

    public DataView BindCustomerMasterDetail()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Customer_cs.Get_CustList("ExportCustomer", "");            
            DataView dv = new DataView(dt);
            return dv;
        }
        catch( Exception ex)
        {
            DataView dv = new DataView();            
            return dv;
        }
        
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string  ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    #region Events

    #region Methods

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export("CustomerMaster.xls", this.grdCustomerMaster);
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

    

}
    
