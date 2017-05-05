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
using System.Globalization;
using System.Text;
using System.Threading;
using Idv.Chetana.BAL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class Godown_Get_PackingDetails : System.Web.UI.UserControl
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;



    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {

            ViewState["PackingRep"] = null;
            txtfromdate.Text = "";
            txttodate.Text = "";
            txtfromdate.Focus();
            txtfromdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txttodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //Session["getpasstempdata"] = null;
            //grdTemp.DataSource = null;
            //grdTemp.DataBind();

        }
        else
        {
            fillData(0);

        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {

        fillData(1);

    }

    public void fillData(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";



        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {

            DataSet ds = new DataSet();

            DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
            DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);
            //if (rdoview.Items[0].Selected == true)
            //{
            //    ds = G_GetPass.Packing_Report("L", _objfdate, _objtdate, 0, 0, Convert.ToInt32(strFY));
            //}
            //else if (rdoview.Items[1].Selected == true)
            //{
            //    ds = G_GetPass.Packing_Report("O", _objfdate, _objtdate, 0, 0, Convert.ToInt32(strFY));
            //}
            ds = G_GetPass.Report_PackingDetails(_objfdate, _objtdate, 0, "");
            ViewState["PackingRep1"] = ds.Tables[0];

        }
        if (ViewState["PackingRep1"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/ConfirmInvoice.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["PackingRep1"]);
                PackingReport.ReportSource = rd;
                //rd.ParameterFields["@fromdate"].va = DateTime.Now.ToString();

            }
            catch
            {


            }
        }
    }

    protected void rdoview_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoview.Items[0].Selected == true)
        {
            txtfromdate.Focus();
            txtfromdate.Text = "";
            txttodate.Text = "";
            PackingReport.ReportSource = null;


        }
        else if (rdoview.Items[1].Selected == true)
        {
            txtfromdate.Focus();
            txtfromdate.Text = "";
            txttodate.Text = "";
            PackingReport.ReportSource = null;

        }

    }

}
