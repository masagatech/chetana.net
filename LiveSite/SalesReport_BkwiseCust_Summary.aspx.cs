
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
using CrystalDecisions.CrystalReports.Engine;

public partial class SalesReport_BkwiseCust_Summary : System.Web.UI.Page
{
    DateTime fdate;
    DateTime tdate;

    string strChetanaCompanyName = "cppl";
    string strFY;

    protected void Page_Load(object sender, EventArgs e)
    {
        
       
            if (Session["FY"] != null)
            {
               
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            

        if (!Page.IsPostBack)
        {
            RdbtnSelect.Focus();
            ViewState["PendingQty"] = null;
            lblbkt.Visible = false;
            txtbktype.Visible = false;
            Bind_DDL_SuperZone();
        }
        if (IsPostBack)
        {
            //    Bind();
            if (ViewState["PendingQty"] != null)
            {
                getdata((DataTable)ViewState["PendingQty"]);
            }
        }
        
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        string from = txtfromDate.Text.Split('/')[2] + "/" + txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0];
        string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }
        else
        {
            if (RdbtnSelect.SelectedValue == "Bookwise")
            {
                string Bookcode = txtbkcod.Text.ToString().Split(':')[0].Trim();
                DataTable dt = new DataTable();
                dt = Books.Get_BookwiseCust_summary(fdate, tdate, Bookcode, Convert.ToInt32(strFY), Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(DDLZone.SelectedValue)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ViewState["PendingQty"] = dt;
                    getdata(dt);
                }
                else
                {
                    MessageBox("No Records Found");
                    txtfromDate.Focus();
                }

            }
            if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
                string BookTypecode = txtbktype.Text.ToString().Split(':')[0].Trim();
                DataTable dt1 = new DataTable();
                dt1 = Books.Get_BooktypewiseCust_summary(fdate, tdate, BookTypecode, Convert.ToInt32(strFY), Convert.ToInt32(DDLSuperZone.SelectedValue), Convert.ToInt32(DDLZone.SelectedValue)).Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    ViewState["PendingQty"] = dt1;
                    getdata(dt1);

                }
                else
                {
                    if (txtbktype.Text == "")
                    {
                        MessageBox("Enter Book Type");
                        txtbktype.Focus();
                    }
                    else
                    {
                        MessageBox("No Records Found");
                        RdbtnSelect.Focus();

                        txtbkcod.Text = "";
                        txtbktype.Text = "";
                    }
                }
            }
        }
       // getdata();
    }

    public void getdata(DataTable dt1)
    {
       
            if (RdbtnSelect.SelectedValue == "Bookwise")
            {
               
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/BookwiseCust_Summary.rpt"));
                    
                    CR.SetDataSource(dt1);
                    CrptBookwiseSummary.ReportSource = CR;
             }
            else if (RdbtnSelect.SelectedValue == "BookTypewise")
            {
               
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/BooktypewiseCust_Summary.rpt"));
                   
                    CR.SetDataSource(dt1);
                    CrptBookwiseSummary.ReportSource = CR;
  
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

    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "Bookwise")
        {
            lblbk.Visible = true;
            txtbkcod.Visible = true;

            lblbkt.Visible = false;
            txtbktype.Visible = false;
        }
        if (RdbtnSelect.SelectedValue == "BookTypewise")
        {
            lblbk.Visible = false;
            txtbkcod.Visible = false;

            lblbkt.Visible = true;
            txtbktype.Visible = true;
        }

        txtbkcod.Text = "";
        txtbktype.Text = "";
        txtfromDate.Text = "";
        txttoDate.Text = "";
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

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
}