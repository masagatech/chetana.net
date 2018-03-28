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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
#endregion

public partial class UserControls_TrialBalanceReport : System.Web.UI.Page
{
    #region Variables
    string strFY;
    string Isdebit;
    #endregion

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
        //Response.Write(strFY);
        txtFromDate.Focus();

        if (!Page.IsPostBack)
        {
	     setdefaultdate();	
            //BindData();
        }
        BindData();
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        //  BindData();
    }
    #region MessageBox

    public void message(string msg)
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

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    public void BindData()
    {
        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {

            string FromDate1 = (txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2]);
            string ToDate1 = (txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2]);
            DateTime FromDate = Convert.ToDateTime(FromDate1);
            DateTime ToDate = Convert.ToDateTime(ToDate1);
            Isdebit = ddlDebitCredit.SelectedValue.ToString();
            string srdSorD = DDLCustomer.SelectedValue + "@" + Isdebit;
            DataSet ds = new DataSet();
            if (rdSorD.SelectedValue == "Detail")
            {
                ds = BankReceiptPayment.idv_Chetana_Get_Trial_Balance(FromDate, ToDate, srdSorD, Convert.ToInt32(strFY), txtGroup.Text.Trim().ToString());
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);

                    ReportDocument rd = new ReportDocument();
                    rd.Load(Server.MapPath("Report/TrialBalanceReport.rpt"));
                    rd.Database.Tables[0].SetDataSource(dv);
                    rd.SetParameterValue("IsPrint", Convert.ToBoolean(IsPrint.Checked));
                  
                    cristTrialBalance.ReportSource = rd;
                    //btntransfer.Visible = true;
                }
                else
                {
                    MessageBox("No Record Found");
                }
            }
            else
            {
                ds = BankReceiptPayment.Idv_Chetana_Get_Trial_Balance_Summary(FromDate, ToDate, srdSorD, Convert.ToInt32(strFY), txtGroup.Text.Trim().ToString());
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataView dv = new DataView(ds.Tables[0]);
                   
                    ReportDocument rd = new ReportDocument();
                   
                    rd.Load(Server.MapPath("Report/TrialBalanceReport_Summary.rpt"));
                    rd.Database.Tables[0].SetDataSource(dv);
                    rd.SetParameterValue("IsPrint", Convert.ToBoolean(IsPrint.Checked));
                  //  rd.SetParameterValue("IsDebit_Credit", Isdebit);
                    cristTrialBalance.ReportSource = rd;
                    //	btntransfer.Visible = true;
                }
                else
                {
                    MessageBox("No Record Found");
                }
            }
        }
    }
    //protected void rdSorD_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rdSorD.SelectedValue == "summary")
    //    {
    //        DDLCustomer.Enabled = false;
    //    }
    //    else
    //    {
    //        DDLCustomer.Enabled = true;
    //    }
    //}

public void setdefaultdate()
    {
        txtFromDate.Text = Session["FromDate"].ToString();
        txtToDate.Text = Session["ToDate"].ToString();
        //DateTime.Now.ToString("dd/MM/yyyy");

    }
}
