﻿#region NameSpaces
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
using System.IO;
using System.Text;

#endregion

public partial class UserControls_uc_virtualStockreport_ForAdmin : System.Web.UI.UserControl
{
    string strFY;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {

            strFY = Session["FY"].ToString();
            //  HidFY.Value = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            //string 
            //Grdvirtualstockreport.DataSource = DCMaster.REP_Virtual_STOCK("");
            //Grdvirtualstockreport.DataBind();

            //lblTotalBooksInGodown.Text = DCMaster.REP_Virtual_STOCK("").Tables[1].Rows[0][0].ToString();

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export("VirtualStock.xls", this.Grdvirtualstockreport);
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
    protected void Btnget_Click(object sender, EventArgs e)
    {
        //string Booktyype = "";

        //if (txtbktype.Text.Trim() != "")
        //{
        //     Booktyype = txtbktype.Text.ToString().Split(':')[0].Trim();
        //    Grdvirtualstockreport.DataSource = DCMaster.REP_Virtual_STOCK(Booktyype);
        //    Grdvirtualstockreport.DataBind();

        //    lblTotalBooksInGodown.Text = DCMaster.REP_Virtual_STOCK(Booktyype).Tables[1].Rows[0][0].ToString();
        //}
        //else
        //{
        //    Grdvirtualstockreport.DataSource = DCMaster.REP_Virtual_STOCK(Booktyype);
        //    Grdvirtualstockreport.DataBind();

        //    lblTotalBooksInGodown.Text = DCMaster.REP_Virtual_STOCK(Booktyype).Tables[1].Rows[0][0].ToString();
        //}
    }
    protected void btngetdate_Click(object sender, EventArgs e)
    {
         string Booktyype = "";


        if (txtbktype.Text.Trim() != "")
        {
           
                string from = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
                string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
                DateTime FromDate = Convert.ToDateTime(from);
                DateTime ToDate = Convert.ToDateTime(To);
                Booktyype = txtbktype.Text.ToString().Split(':')[0].Trim();
                Grdvirtualstockreport.DataSource = DCMaster.REP_Virtual_STOCK(Booktyype,FromDate,ToDate );
                Grdvirtualstockreport.DataBind();

                lblTotalBooksInGodown.Text = DCMaster.REP_Virtual_STOCK(Booktyype,FromDate ,ToDate,Convert.ToInt32(strFY)).Tables[1].Rows[0][0].ToString();
           
          
        }
        else
        {
            
                string from = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
                string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
                DateTime FromDate = Convert.ToDateTime(from);
                DateTime ToDate = Convert.ToDateTime(To);
                Grdvirtualstockreport.DataSource = DCMaster.REP_Virtual_STOCK(Booktyype, FromDate, ToDate,Convert.ToInt32(strFY));
                Grdvirtualstockreport.DataBind();

                lblTotalBooksInGodown.Text = DCMaster.REP_Virtual_STOCK(Booktyype, FromDate, ToDate, Convert.ToInt32(strFY)).Tables[1].Rows[0][0].ToString();
           
        }
    }
}

