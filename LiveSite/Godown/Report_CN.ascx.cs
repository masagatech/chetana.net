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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using System.Globalization;

public partial class Godown_GetLocalReport : System.Web.UI.UserControl
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
            ViewState["DocNoRep"] = null;
            txtfromdate.Focus();
        }

        else
        {
            fillDataDocNo(0);

        }
    }

    public void fillDataDocNo(int isNew)
    {
        DateTimeFormatInfo info = new DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        info.DateSeparator = "/";



        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {

            DataSet ds = new DataSet();

            if (rdoview.Items[0].Selected == true)
            {
                DateTime _objfrom = Convert.ToDateTime(txtfromdate.Text, info);
                DateTime _objto = Convert.ToDateTime(txttodate.Text, info);

                ds = G_GetPass.Report_Outside_Credit("D", _objfrom, _objto, 0, 0, Convert.ToInt32(strFY));

            }
            else if (rdoview.Items[1].Selected == true)
            {
                ds = G_GetPass.Report_Outside_Credit("G", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(TextBox1.Text.Trim()), Convert.ToInt32(TextBox2.Text.Trim()), Convert.ToInt32(strFY));

            }

            ViewState["DocNoRep"] = ds.Tables[0];
        }
        if (ViewState["DocNoRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Godown/reports/Customer_DateWise_Report.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["DocNoRep"]);
                LocalGodown.ReportSource = rd;

            }
            catch
            {


            }
        }
    }



    protected void rdoview_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoview.SelectedValue == "Date")
        {

            txtfromdate.Focus();
            TextBox1.Text = "";
            TextBox2.Text = "";

            pnldate.Visible = true;
            pnlgcnno.Visible = false;
            LocalGodown.ReportSource = null;

        }
        else if (rdoview.SelectedValue == "GCNNO")
        {

            TextBox1.Focus();
            TextBox1.TabIndex = 1;
            TextBox2.TabIndex = 2;
            btnreport.TabIndex = 3;

            txtfromdate.Text = "";
            txttodate.Text = "";

            pnlgcnno.Visible = true;
            pnldate.Visible = false;
            LocalGodown.ReportSource = null;
        }
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        fillDataDocNo(1);

    }


}
