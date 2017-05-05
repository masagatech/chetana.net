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
using CrystalDecisions.CrystalReports.Engine;

public partial class AdditionalCommissionCal : System.Web.UI.Page
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!Page.IsPostBack)
        {
            Session["CommRpt"] = null;
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            Bind_DDL_CC();

        }
        if (txtIsExport.Value == "yes")
        {
            ShowDetails();
            txtIsExport.Value = "";
        }
    }


    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["CommRpt"] = null;
        ShowDetails();
    }
    public void ShowDetails()
    {
           ReportDocument rd = new ReportDocument();
           DataSet ds = new DataSet();
           DataView dv = null;
           if (Session["CommRpt"] != null)
           {

               ds = (DataSet)Session["CommRpt"];
           }
           else
           {
               ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_AdditionalCommissionCal(
              Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
              Convert.ToInt32(DDLZone.SelectedValue.ToString()),
              Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
              Convert.ToInt32(DDLCC.SelectedValue.ToString()),
              Convert.ToInt32(strFY));
               Session["CommRpt"] = ds;
           }


           if (rdAorI.SelectedValue.ToString() == "All")
           {
              // pnlIndividual.Visible = false;
               pnlGrid.Visible = true;
               btnExport.Visible = true;
               grdAddCommCal.DataSource = ds.Tables[0];
               grdAddCommCal.DataBind();
           }
           else
           {
               pnlGrid.Visible = false;
               pnlIndividual.Visible = true;
               rd.Load(Server.MapPath("Report/AdditionalCommissionNew.rpt"));
               rd.Database.Tables[0].SetDataSource(ds.Tables[0]);
               AdditionalCommission.ReportSource = rd;
           }
         
    }
    //protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DDLSuperZone.SelectedIndex == 0)
    //    {
    //        DDLSuperZone.Focus();
    //        DDLZone.Items.Clear();
    //        Bind_DDL_SuperZone();
    //    }
    //    else
    //    {
    //        Bind_DDL_Zone();
    //        DDLZone.Focus();
    //    }
    //}

    //protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DDLZone.SelectedIndex == 0)
    //    {
    //        // MessageBox("Select SuperZone");
    //        DDLZone.Focus();
    //        ddlCustmore.Items.Clear();
    //        //  DDLZone.SelectedValue = null;
    //        Bind_DDL_ZoneCust();
    //    }
    //    else
    //    {
    //        Bind_DDL_Customer();
    //        ddlCustmore.Focus();
    //    }

    //}
    //public void Bind_DDL_ZoneCust()
    //{
    //    DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
    //    DDLZone.DataBind();
    //    DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    //    ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    //}
    //public void Bind_DDL_Customer()
    //{
    //    ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomerAdditionalCommission(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
    //    ddlCustmore.DataBind();
    //    ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    //}
    //public void Bind_DDL_Zone()
    //{
    //    DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
    //    DDLZone.DataBind();
    //    DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    //}
    
    //public void Bind_DDL_SuperZone()
    //{
    //    DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
    //    DDLSuperZone.DataBind();
    //    DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
    //    DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    //}
    //public void Bind_DDL_CC()
    //{
    //    DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
    //    DDLCC.DataBind();
    //    DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
    //    DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    //}
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export("AdditionalCommissionCalculate.xls", grdAddCommCal);
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

                System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();

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






    ////////////////////////////

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bind_DDL_Zone();


    }

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            DDLZone.Focus();
            ddlCustmore.Items.Clear();
            ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));
        }
        else
        {
            Bind_DDL_Customer();
            ddlCustmore.Focus();
        }

    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-All Zone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = Masters.Idv_Chetana_Get_ZoneCustomer(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));

    }
    public void Bind_DDL_Zone()
    {
        DDLZone.Items.Clear();
        ddlCustmore.Items.Clear();
        if (DDLSuperZone.SelectedIndex > 0)
        {
            DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
            DDLZone.DataBind();
            DDLZone.Focus();
            DDLZone.Items.Insert(0, new ListItem("-All Zone-", "0"));
            ddlCustmore.Items.Insert(0, new ListItem("-All Customer-", "0"));

        }
        else
        {
            DDLZone.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
            ddlCustmore.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));

        }
        customerDisabled();

    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-<Select SuperZone-", "0"));
        customerDisabled();
    }
    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-All Customer Category-", "0"));
    }
    protected void DDLCC_SelectedIndexChanged(object sender, EventArgs e)
    {
        customerDisabled();
    }

    private void customerDisabled()
    {
        if (DDLCC.SelectedIndex > 0)
        {


            ddlCustmore.SelectedIndex = 0;
            ddlCustmore.Enabled = false;
        }
        else
        {
            ddlCustmore.Enabled = true;
        }
    }
    protected void CustomerWiseAmount_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {
        ShowDetails();
    }
    protected void CustomerWiseAmount_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
    {
        ShowDetails();

    }
    protected void CustomerWiseAmount_Search(object source, CrystalDecisions.Web.SearchEventArgs e)
    {
        ShowDetails();

    }

}