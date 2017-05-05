using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Idv.Chetana.BAL;
using Idv.Chetana.DAL;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class CmsTicketHistoryExecutiveReports : System.Web.UI.Page
{
    #region Goloval Veriable
    string strChetanaCompanyName = "cppl";
    string strFY;
    InquiryDetail InqBal = new InquiryDetail();
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // BindStatus();
            strFY = Session["FY"].ToString();
            if (Convert.ToString(Session["UserName"]).ToLower() == "idvadmin" || Convert.ToString(Session["UserName"]).ToLower() == "emp315" || Convert.ToString(Session["UserName"]).ToLower() == "emp422" || Convert.ToString(Session["UserName"]).ToLower() == "chadmin" ||Convert.ToString(Session["UserName"]).ToLower() == "emp859")
            {

                pnlcust.Visible = true;
               //divtitle.Visible = true;
                tblReport.Visible = true;
                BindStatus();
                txtFrom.Text = "01/04/201" + Convert.ToInt32(strFY).ToString();
                txtTo.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1);
                txtFrom.Focus();
            }
            
        }
        else
        {
           
            if (Convert.ToString(Session["UserName"]).ToLower() == "idvadmin" || Convert.ToString(Session["UserName"]).ToLower() == "emp315" || Convert.ToString(Session["UserName"]).ToLower() == "emp422" || Convert.ToString(Session["UserName"]).ToLower() == "chadmin" || Convert.ToString(Session["UserName"]).ToLower() == "emp859")
            {
                pnlcust.Visible = true;
               // divtitle.Visible = true;
                tblReport.Visible = true;
                BindAllDate();
            }
           
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
            //Response.Write(strFY);

        }
        if (IsPostBack)
        {
            //if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            //{
            //   // MessageBox("Select Items");
            //}

            //else
            //{
            BindAllDate();
            //}
        }
    }
    #endregion

    #region Bind Status
    protected void BindStatus()
    {
        Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
        string Flag = "Status";
        DataSet DSX = ObjDal.BindStatus(Flag);
        DataTable dt = new DataTable();
        DSX.Tables.Add(dt);
        InqSatatus.DataSource = DSX;
        InqSatatus.DataTextField = "Status_Name";
        InqSatatus.DataBind();
        InqSatatus.Items.Insert(0, new ListItem("Select", "NA"));
        //Flag = "Escalation";
        //DSX = ObjDal.BindStatus(Flag);
        //DDlEscalation.DataSource = DSX;
        //DDlEscalation.DataBind();
        //DDlEscalation.Items.Insert(0, new ListItem("Select", "Na"));
    }
    #endregion

    #region Bind Report Data
    public void BindAllDate()
    {
        #region FromDate And ToDate And Customer And Status And Executive
        if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && txtCutomerName.Text != string.Empty && InqSatatus.SelectedItem.Text
            != "Select" && txtExeutiveName.Text !=string.Empty)
        {
            HelpDeskReports IDS = new HelpDeskReports();
            Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();

            DataSet DS = new DataSet();
            string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            string TODate = DateTime.Now.ToString("MM/dd/yyyy");
            FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
            TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];
            DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0", txtCutomerName.Text.Split(':')[0].ToString(),
                txtExeutiveName.Text, "0", InqSatatus.SelectedValue, "FD&TD&Status&CustCode&EmpCode");
            if (DS.Tables[0].Rows.Count > 0)
            {
                CustomerWiseAmount.Visible = true;
                DataView dv = new DataView(DS.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                CustomerWiseAmount.ReportSource = rd;
                CustomerWiseAmount.RefreshReport();
                CustomerWiseAmount.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record not Found !')", true);
                CustomerWiseAmount.Visible = false;
                txtFrom.Focus();
            }

        }
        #endregion

        #region FromDate And ToDate And Customer And Status
        else if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && txtCutomerName.Text != string.Empty && InqSatatus.SelectedItem.Text != "Select")
        {
            Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
            HelpDeskReports IDS = new HelpDeskReports();
            DataSet DS = new DataSet();

            string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            string TODate = DateTime.Now.ToString("MM/dd/yyyy");
            FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
            TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];

            DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0", txtCutomerName.Text.Split(':')[0].ToString(),
                "0", "0", InqSatatus.SelectedValue, "FD&TD&Status&CustCode");
            if (DS.Tables[0].Rows.Count > 0)
            {
                CustomerWiseAmount.Visible = true;
                DataView dv = new DataView(DS.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                CustomerWiseAmount.ReportSource = rd;
                CustomerWiseAmount.RefreshReport();
                CustomerWiseAmount.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
                CustomerWiseAmount.Visible = false;
                txtFrom.Focus();
            }
        }
        #endregion

        #region FromDate And ToDate And Status
        else if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && InqSatatus.SelectedItem.Text != "Select")
        {
            //if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && InqSatatus.SelectedItem.Text != "Select")
            //{
                Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
                HelpDeskReports IDS = new HelpDeskReports();
                DataSet DS = new DataSet();
                string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
                string TODate = DateTime.Now.ToString("MM/dd/yyyy");
                FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
                TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];
                //InqBal.Fromdate = Convert.ToDateTime(txtFrom.Text.Split('/')[2] + "/" + txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0]);
                //InqBal.ToDate = Convert.ToDateTime(txtTo.Text.Split('/')[2] + "/" + txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0]);
                //InqBal.Status = InqSatatus.SelectedValue;
                //InqBal.Action = "FD&TD&Status";
                DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0", "0", "0", "0", InqSatatus.SelectedValue, "FD&TD&Status");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    CustomerWiseAmount.Visible = true;
                    DataView dv = new DataView(DS.Tables[0]);
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                    rd.Database.Tables[0].SetDataSource(dv);
                    CustomerWiseAmount.ReportSource = rd;
                    CustomerWiseAmount.RefreshReport();
                    CustomerWiseAmount.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
                    CustomerWiseAmount.Visible = false;
                    txtFrom.Focus();
                }

          //  }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Between Date.. !')", true);
            //    txtFrom.Focus();
            //    txtFrom.Text = "";

            //}
        }
        #endregion

        #region FromDate And ToDate And Customer
        else if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && txtCutomerName.Text != string.Empty)
        {
            Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
            HelpDeskReports IDS = new HelpDeskReports();
            DataSet DS = new DataSet();

            string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            string TODate = DateTime.Now.ToString("MM/dd/yyyy");
            FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
            TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];

            DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0", txtCutomerName.Text.Split(':')[0].ToString(),
                "0", "0", "0", "FD&TD&CustCode");
            if (DS.Tables[0].Rows.Count > 0)
            {
                CustomerWiseAmount.Visible = true;
                DataView dv = new DataView(DS.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                CustomerWiseAmount.ReportSource = rd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
                CustomerWiseAmount.Visible = false;
                txtFrom.Focus();
            }

        }
        #endregion

        #region FromDate And ToDate And Exeutive
        else if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && txtExeutiveName.Text != string.Empty)
        {
            Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
            HelpDeskReports IDS = new HelpDeskReports();
            DataSet DS = new DataSet();

            string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            string TODate = DateTime.Now.ToString("MM/dd/yyyy");
            FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
            TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];

            DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0","0",
                txtExeutiveName.Text, "0", "0", "FD&TD&Emp");
            if (DS.Tables[0].Rows.Count > 0)
            {
                CustomerWiseAmount.Visible = true;
                DataView dv = new DataView(DS.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                CustomerWiseAmount.ReportSource = rd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
                CustomerWiseAmount.Visible = false;
                txtFrom.Focus();
            }
        }
        #endregion
        #region FromDate And ToDate And Exeutive And Customer
        else if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty && txtCutomerName.Text!=string.Empty  && txtExeutiveName.Text != string.Empty)
        {
            Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
            HelpDeskReports IDS = new HelpDeskReports();
            DataSet DS = new DataSet();

            string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            string TODate = DateTime.Now.ToString("MM/dd/yyyy");
            FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
            TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];

            DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0", txtCutomerName.Text.Split(':')[0].ToString(),
                txtExeutiveName.Text, "0", "0", "FD&TD&Emp");
            if (DS.Tables[0].Rows.Count > 0)
            {
                CustomerWiseAmount.Visible = true;
                DataView dv = new DataView(DS.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                CustomerWiseAmount.ReportSource = rd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
                CustomerWiseAmount.Visible = false;
                txtFrom.Focus();
            }
        }
        #endregion

        #region From Date And To Date
        else if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty)
        {
            Other_Z.OtherBAL ObjDal = new Other_Z.OtherBAL();
            HelpDeskReports IDS = new HelpDeskReports();
            DataSet DS = new DataSet();
            string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            string TODate = DateTime.Now.ToString("MM/dd/yyyy");
            FromDate = txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2];
            TODate = txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2];

            DS = ObjDal.AllRecordRepordTicketHistory(Convert.ToDateTime(FromDate), Convert.ToDateTime(TODate), "0", "0","0",
                "0", "0", "0", "FD&TD");
            if (DS.Tables[0].Rows.Count > 0)
            {
                CustomerWiseAmount.Visible = true;
                DataView dv = new DataView(DS.Tables[0]);
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/CallReportExecutive.rpt"));
                rd.Database.Tables[0].SetDataSource(dv);
                CustomerWiseAmount.ReportSource = rd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
                CustomerWiseAmount.Visible = false;
                txtFrom.Focus();
            }
        }
        #endregion
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record are not Found !')", true);
            CustomerWiseAmount.Visible = false;
            txtFrom.Focus();
        }

    }
    #endregion

    #region Search Button Click Event
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (txtCutomerName.Text != string.Empty || txtFrom.Text != string.Empty || txtTicketNoFrom.Text != string.Empty || txtTicketNoTo.Text != string.Empty || txtTo.Text != string.Empty || InqSatatus.SelectedItem.Text != "Select")
        {
            BindAllDate();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Atleast One !!..')", true);
            CustomerWiseAmount.Visible = false;
            txtFrom.Focus();
        }
    }
    #endregion

    #region Customer Text Change Event
    protected void txtCutomerName_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtCutomerName.Text.ToString().Split(':')[0].Trim();
        DataTable dt1 = new DataTable();
        dt1 = Specimen.Get_Name(CustCode, "Customer").Tables[0];
        if (dt1.Rows.Count != 0)
        {
            txtCutomerName.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
            txtCutomerName.Focus();
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtCutomerName.Focus();
            txtCutomerName.Text = "";
        }
    }
    #endregion

    #region Clear Button Click Event
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        txtCutomerName.Text = "";
        txtFrom.Text = "";
        txtTicketNoFrom.Text = "";
        txtTicketNoTo.Text = "";
        txtTo.Text = "";
        //DDlEscalation.SelectedIndex=0;
        txtExeutiveName.Text = "";
        InqSatatus.SelectedIndex = 0;
        CustomerWiseAmount.Visible = false;
        txtFrom.Text = "01/04/201" + Convert.ToInt32(strFY).ToString();
        txtTo.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(strFY) + 1);
        txtFrom.Focus();
    }
    #endregion
}