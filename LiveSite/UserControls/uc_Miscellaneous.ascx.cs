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
using System.Collections.Generic;

public partial class UserControls_uc_Miscellaneous : System.Web.UI.UserControl
{
    string strFY;
    string strChetanaCompanyName = "cppl"; string val = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
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
        if (!IsPostBack)
        {
            setdefaultdate();
            //Bind();
        }
        if (!Page.IsPostBack)
        {
            DDLSuperZone.Focus();
            

            Bind_DDL_SuperZone();
            pnlcust.Visible = true;Bind_DDL_CC();

        }
        if (IsPostBack)
        {
            if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            {
                MessageBox("Select Items");
            }

            else
            {
                //Bind();
            }
        }
        if (rdOptions.SelectedIndex == 0)
        { val = "CWE"; }
        else if (rdOptions.SelectedIndex == 1)
        { val = "CWP"; }
        else if (rdOptions.SelectedIndex == 2)
        {
            val = "CWAA";
        }
        else if (rdOptions.SelectedIndex == 3)
        {
            val = "CWAADAC";
        }
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
    #endregion
    protected void btnget_Click(object sender, EventArgs e)
    {
       
       
       
        Bind(val);
    }

    public void Bind(string selectedval)
    {

        DataSet dt = new DataSet();
        if (selectedval != "CWAADAC")
        {
            dt = Miscellaneous.GetMiscellaneous(selectedval, Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
               Convert.ToInt32(DDLZone.SelectedValue.ToString()), 0,
               Convert.ToInt32(DDLCC.SelectedValue.ToString()),
               Convert.ToInt32(strFY));
        }
        else
        {
            dt = Miscellaneous.GetMiscellaneousDAC(selectedval, Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
               Convert.ToInt32(DDLZone.SelectedValue.ToString()), 0,
               Convert.ToInt32(DDLCC.SelectedValue.ToString()),
               Convert.ToInt32(strFY));
            //dt = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_DisburseAdditionalCommission(
            //   Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
            //   Convert.ToInt32(DDLZone.SelectedValue.ToString()),
            //   0,
            //   Convert.ToInt32(DDLCC.SelectedValue.ToString()),
            //   Convert.ToInt32(strFY));
        }
         if (dt.Tables[0].Rows.Count != 0)
        {
            grdDetails.DataSource = dt;
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = dt;
            grdDetails.DataBind();
            MessageBox("No Record Found");
        }

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
    public void setdefaultdate()
    {
        //txtFromDate.Text = Session["FromDate"].ToString();
        //txtToDate.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export("PurchaseRegister.xls", grdDetails);
    }
    List<Array> arr = new List<Array>();
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("align", "right");
            e.Row.Cells[0].Attributes.Add("align", "center");

            //if (ddlSD.SelectedValue.ToString().ToLower() != "summary")
            //{
            //    e.Row.Cells[1].Attributes.Add("align", "center");
            //    e.Row.Cells[2].Attributes.Add("align", "center");
            //    e.Row.Cells[3].Attributes.Add("align", "center");
            //}

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataTable dt = (DataTable)ViewState["Total"];
            //if (ddlSD.SelectedIndex == 0)
            //{
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        if (i != 0)
            //            e.Row.Cells[i].Text = dt.Rows[0][i].ToString();
            //        else
            //            e.Row.Cells[i].Text = "Total";
            //    }

            //}
            //else if (ddlSD.SelectedIndex == 1)
            //{
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        if (i > 3)
            //            e.Row.Cells[i].Text = dt.Rows[0][i].ToString();

            //        if (i == 3)
            //            e.Row.Cells[3].Text = "Total";

            //    }

            //}
        }
    }

    public void grdDesign(int row)
    {
        //grdDetails.Rows[row].Cells[0].Attributes.Add("text-align", "center");
    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
            Bind_DDL_SuperZone();
        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
           DDLZone.Focus();
           
            Bind_DDL_ZoneCust();
        }
       

    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
       // DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        Bind(val);
        
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            e.Row.TabIndex = -1;
            e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
            e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
            e.Row.Attributes["onselectstart"] = "javascript:return false;";
        }
    }

  
}
