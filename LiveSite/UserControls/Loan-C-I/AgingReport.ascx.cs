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
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_Loan_C_I_AgingReport : System.Web.UI.UserControl
{
    #region Variables
    string strChetanaCompanyName = "cppl";
    string strFY;
    string CustCode = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind_DDL_SuperZone();
            Session["DataFillAging"] = null;

            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
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

            if (Session["DataFillAging"] != null)
            {
                ShowDetails(0);
            }
            //Response.Write(strFY);


        }

    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        ShowDetails(1);
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-All SuperZone-", "0"));

    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

    public void ShowDetails(int getnew)
    {
        if (getnew == 1)
        {
            Session["DataFillAging"] = null;
        }
        string CustCode = "";
        string Zone = "0";
        if (DDLSuperZone.SelectedIndex == 0)
        {
            CustCode = "2";

        }
        else if (DDLZone.SelectedIndex != 0)
        {
            CustCode = "1";
            Zone = DDLZone.SelectedValue.ToString();
        }


        DataSet ds = new DataSet();
        if (Session["DataFillAging"] == null)
        {
             ds = LoanPartyMaster.Idv_Chetana_Customer_Aging_Report(Convert.ToInt32(Zone),
                //            (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]), 
                     "01/04/2012",
                     (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]),
                     Convert.ToInt32(strFY), CustCode);
            DataView dv = new DataView(ds.Tables[0]);

            if (txtFromAmount.Text.Trim() == "" && txtToAmount.Text.Trim() == "")
            {
                    
            }
            else 
            {
               dv.RowFilter = " Total >=" + Convert.ToInt32(txtFromAmount.Text.Trim()) + " AND Total <=" + Convert.ToInt32(txtToAmount.Text.Trim());          
            }

               //dv.RowFilter = " Total >=" + Convert.ToInt32(txtFromAmount.Text.Trim()) + " AND Total <=" + Convert.ToInt32(txtToAmount.Text.Trim());          


            Session["DataFillAging"] = dv.ToTable();
        }
        //DataSet ds2 = new DataSet();
        // ds2 = Idv.Chetana.BAL.Specimen.Idv_Chetana_Get_CustomerDetailsForReport(Convert.ToInt32(ddlCustmore.SelectedValue.ToString()));
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("~/Report/AgingReport.rpt"));
        rd.Database.Tables[0].SetDataSource(((DataTable)Session["DataFillAging"]));
        // rd.Database.Tables[1].SetDataSource(dv2);
        //rd.SetDataSource(ds);
        crtAgging.ReportSource = rd;

    }

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();

        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }
}
