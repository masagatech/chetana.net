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

public partial class UserControls_PurchaseRegisterNew : System.Web.UI.UserControl
{
    string strFY;
    string strChetanaCompanyName = "cppl";
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
        string val = "";
        if (rdOptions.SelectedIndex == 0)
        { val = "_a"; }
        else if (rdOptions.SelectedIndex == 1)
        { val = "_b"; }
        else if (rdOptions.SelectedIndex == 2)
        {
            val = "";
        }
        if (val == "")
        {
            rdOptions.SelectedIndex = 2;
        }
        Bind(val);
    }
    
    public void Bind(string selectedval)
    {
        string from = txtFromDate.Text.Split('/')[1].ToString() + "/" + txtFromDate.Text.Split('/')[0].ToString() + "/" + txtFromDate.Text.Split('/')[2];
        string to = txtToDate.Text.Split('/')[1].ToString() + "/" + txtToDate.Text.Split('/')[0].ToString() + "/" + txtToDate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(to);
        DataSet dt = new DataSet();
        dt = PurchaseDetails.GetPurchaseRegister(FromDate, ToDate, Convert.ToInt32(strFY), txtEMcode.Text.Trim(), ddlSD.SelectedValue.ToString() + selectedval);
        ViewState["Total"] = dt.Tables[1];
        if (dt.Tables[0].Rows.Count != 0)
        {
            grdDetails.DataSource = dt;
            grdDetails.DataBind();
        }
        else
        {
            MessageBox("No Record Found");
        }

    }
    protected void txtEMcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtEMcode.Text.ToString().Split(':', '[', ']')[0].Trim();
        // string flag = txtEMcode.Text.ToString().Split(':', '[', ']')[3].Trim();
        string Code = ECode;
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(Code, "AC").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtEMcode.Text = ECode;

        }
        else
        {
            MessageBox("No such Party");

            txtEMcode.Focus();
            txtEMcode.Text = "";
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
        txtFromDate.Text = Session["FromDate"].ToString();
        txtToDate.Text = Session["ToDate"].ToString();
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

            if (ddlSD.SelectedValue.ToString().ToLower() != "summary")
            {
                e.Row.Cells[1].Attributes.Add("align", "center");
                e.Row.Cells[2].Attributes.Add("align", "center");
                e.Row.Cells[3].Attributes.Add("align", "center");
            }
       
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataTable dt = (DataTable)ViewState["Total"];
            if (ddlSD.SelectedIndex == 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != 0)
                        e.Row.Cells[i].Text = dt.Rows[0][i].ToString();
                    else
                        e.Row.Cells[i].Text = "Total";
                }
                
            }
            else if (ddlSD.SelectedIndex == 1)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 3)
                        e.Row.Cells[i].Text = dt.Rows[0][i].ToString();

                    if (i == 3)
                        e.Row.Cells[3].Text = "Total";

                }

            }
        }
    }

    public void grdDesign(int row)
    {
        //grdDetails.Rows[row].Cells[0].Attributes.Add("text-align", "center");
    }
}
