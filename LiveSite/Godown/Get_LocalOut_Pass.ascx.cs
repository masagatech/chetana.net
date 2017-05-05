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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;

public partial class Godown_Get_LocalOut_Pass : System.Web.UI.UserControl
{
    #region Variables

    string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;

    string fdcno = string.Empty;
    string tdcno = string.Empty;
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


        }
        if (!Page.IsPostBack)
        {

            ViewState["DocNoRep"] = null;
            txtfdocno.Focus();

        }
        else
        {
            fillDataDocNo(0);

        }
    }




    protected void btnget_Click(object sender, EventArgs e)
    {

        fillDataDocNo(1);


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
            fdcno = txtfdocno.Text.Trim();
            tdcno = txttdocno.Text.Trim();
            if (rdoview.Items[0].Selected == true)
            {


                if (rdoview1.Items[0].Selected == true)
                {
                    fdcno = txtfdocno.Text.Trim();
                    tdcno = txttdocno.Text.Trim();
                    ds = G_GetPass.LocalOut_PassReport("L", "dcno", Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY));
                }
                else if (rdoview1.Items[1].Selected == true)
                {
                    DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
                    DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);
                    ds = G_GetPass.LocalOut_PassReport("L", "", 0, 0, _objfdate, _objtdate, Convert.ToInt32(strFY));

                }
                else if (rdoview1.Items[2].Selected == true)
                {
                    fdcno = txtfdocno.Text.Trim();
                    tdcno = txttdocno.Text.Trim();
                    ds = G_GetPass.LocalOut_PassReport("L", "orgdcno", Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY));

                }
            }
            else if (rdoview.Items[1].Selected == true)
            {



                if (rdoview1.Items[0].Selected == true)
                {
                    fdcno = txtfdocno.Text.Trim();
                    tdcno = txttdocno.Text.Trim();
                    ds = G_GetPass.LocalOut_PassReport("O", "dcno", Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY));
                }
                else if (rdoview1.Items[1].Selected == true)
                {
                    DateTime _objfdate = Convert.ToDateTime(txtfromdate.Text.Trim(), info);
                    DateTime _objtdate = Convert.ToDateTime(txttodate.Text.Trim(), info);
                    ds = G_GetPass.LocalOut_PassReport("O", "", 0, 0, _objfdate, _objtdate, Convert.ToInt32(strFY));

                }
                else if (rdoview1.Items[2].Selected == true)
                {
                    fdcno = txtfdocno.Text.Trim();
                    tdcno = txttdocno.Text.Trim();
                    ds = G_GetPass.LocalOut_PassReport("O", "orgdcno", Convert.ToInt32(fdcno), Convert.ToInt32(tdcno), System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY));

                }

            }

            ViewState["DocNoRep"] = ds.Tables[0];
        }
        if (ViewState["DocNoRep"] != null)
        {
            try
            {

                if (rdoview.Items[0].Selected == true)
                {
                    rd.Load(Server.MapPath("Godown/reports/GetPass_Local_Report.rpt"));
                    rd.Database.Tables[0].SetDataSource((DataTable)ViewState["DocNoRep"]);
                    LocalOutDocNo.ReportSource = rd;
                }
                else if (rdoview.Items[1].Selected == true)
                {
                    rd.Load(Server.MapPath("Godown/reports/GetPass_Out_Report.rpt"));
                    rd.Database.Tables[0].SetDataSource((DataTable)ViewState["DocNoRep"]);
                    LocalOutDocNo.ReportSource = rd;
                }
                
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
            RadioSelect();


        }
        else if (rdoview.Items[1].Selected == true)
        {
            RadioSelect();
        }

    }



    protected void rdoview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioSelect();

    }

    public void RadioSelect()
    {
        if (rdoview1.Items[0].Selected == true)
        {

            txtfdocno.Focus();
            pnldate.Visible = false;
            pnldocno.Visible = true;
            txtfdocno.Text = "";
            txttdocno.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            LocalOutDocNo.ReportSource = null;
            Label1.Text = "From Doc No";
            Label2.Text = "To Doc No";
            pnldocno.GroupingText = "Enter Doc No.";

        }
        else if (rdoview1.Items[1].Selected == true)
        {
            txtfromdate.Focus();
            txtfromdate.TabIndex = 1;
            txttodate.TabIndex = 2;
            //btnget.TabIndex = 3;            
            pnldate.Visible = true;
            pnldocno.Visible = false;
            txtfdocno.Text = "";
            txttdocno.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            LocalOutDocNo.ReportSource = null;

        }
        else if (rdoview1.Items[2].Selected == true)
        {

            txtfdocno.Focus();
            pnldate.Visible = false;
            pnldocno.Visible = true;
            txtfdocno.Text = "";
            txttdocno.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            LocalOutDocNo.ReportSource = null;
            pnldocno.GroupingText = "Enter DC No.";
            Label1.Text = "From DC No";
            Label2.Text = "To Dc No";

        }

    }


}
