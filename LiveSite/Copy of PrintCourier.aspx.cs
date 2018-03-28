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

public partial class PrintCourier : System.Web.UI.Page
{
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
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
        } 
        if (!Page.IsPostBack)
        {
            
            Bind_BranchI();
            Bind_CourierI();
            Bind_Branch();
            Bind_Courier();
            ViewState["Data"] = null;
            pnlcustomer.Visible = true;
            pnlsupplier.Visible = false;
        }
        if (IsPostBack)
        {
            //if (ViewState["Data"] != null)
            //{
            //    BindData((DataTable)ViewState["Data"]);
            //}
        }
    }
    protected void rdbselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbselect.SelectedValue == "InvoiceNo")
        {
            pnlcustomer.Visible = true;
            pnlsupplier.Visible = false;
            ViewState["Data"] = null;
            BindData((DataTable)ViewState["Data"]);
            ddlBranchI.SelectedIndex = 0;
            ddlCourierI.SelectedIndex = 0;

        }

        else
        {
            pnlcustomer.Visible = false;
            pnlsupplier.Visible = true;
            ViewState["Data"] = null;
            BindData((DataTable)ViewState["Data"]);
            ddlBranch.SelectedIndex = 0;
            ddlCourier.SelectedIndex = 0;


            
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (rdbselect.SelectedValue == "InvoiceNo")
        {
            if ( txtCourierId.Text.ToString() != "CourierId")
            {
                dt = CourierDetails.ViewCourier(float.Parse(txtCourierId.Text), "CourierId", Convert.ToInt32(strFY)).Tables[0];

            }
            else if (txtInvoiceNoGet.Text.ToString() != "Invoice")
            {
                dt = CourierDetails.ViewCourier(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY)).Tables[0];

            }
            else if (txtDocNoGet.Text.ToString() != "Doc")
            {
                dt = CourierDetails.ViewCourier(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY)).Tables[0];

            }
            else if (ddlBranchI.SelectedValue.ToString() != "0" && (rdbselect.SelectedValue == "InvoiceNo"))
            {
                if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdbselect.SelectedValue == "InvoiceNo"))
                {
                    dt = CourierDetails.ViewCourierDate(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY)).Tables[0];
                }
                else
                {
                    dt = CourierDetails.ViewCourierDate(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY)).Tables[0];
                }
            }
            else if ((ddlCourierI.SelectedValue.ToString() != "0") && (rdbselect.SelectedValue == "InvoiceNo"))
            {
                if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdbselect.SelectedValue == "InvoiceNo"))
                {
                    dt = CourierDetails.ViewCourierDate(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY)).Tables[0];
                }
                else
                {
                    dt = CourierDetails.ViewCourierDate(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY)).Tables[0];

                }

            }
            else if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdbselect.SelectedValue == "InvoiceNo"))
            {
                dt = CourierDetails.ViewCourierDate(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "Date", Convert.ToInt32(strFY)).Tables[0];

            }
        }
        else
        {
            if (txtGeneralCourierID.Text.ToString()  != "CourierId")
            {
                dt = CourierDetails.ViewCourier(float.Parse(txtGeneralCourierID.Text), "GeneralCourierID", Convert.ToInt32(strFY)).Tables[0];

            }

            else if (ddlBranch.SelectedValue.ToString() != "0" && (rdbselect.SelectedValue == "Others"))
            {
                if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdbselect.SelectedValue == "Others")))
                {
                    dt = CourierDetails.ViewCourierDate(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY)).Tables[0];
                }
                else
                {
                    dt = CourierDetails.ViewCourierDate(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY)).Tables[0];
                }

            }
            else if ((ddlCourier.SelectedValue.ToString() != "0") && (rdbselect.SelectedValue == "Others"))
            {
                if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdbselect.SelectedValue == "Others")))
                {
                    dt = CourierDetails.ViewCourierDate(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY)).Tables[0];
                }
                else
                {
                    dt = CourierDetails.ViewCourierDate(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY)).Tables[0];
                }

            }


            else if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdbselect.SelectedValue == "Others")))
            {
                dt = CourierDetails.ViewCourierDate(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralDate", Convert.ToInt32(strFY)).Tables[0];

            }
        }
        ViewState["Data"] = dt;
        BindData(dt);
        txtCourierId.Text = "CourierId";
        txtInvoiceNoGet.Text = "Invoice";
        txtDocNoGet.Text = "Doc";
        ddlBranchI.SelectedValue = "0";
        ddlCourierI.SelectedValue = "0";
        txtGeneralCourierID.Text = "CourierId";
        ddlBranch.SelectedValue = "0";
        ddlCourier.SelectedValue = "0";
        txtFrom.Text = "";
        txtTo.Text = "";
        txtFromGeneral.Text = "";
        txtToGeneral.Text = "";
    }
    public void Bind_BranchI()
    {
        ddlBranchI.DataSource = CourierDetails.GetCourier("Branch");
        ddlBranchI.DataBind();
        ddlBranchI.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
    }
    public void Bind_CourierI()
    {
        ddlCourierI.DataSource = CourierDetails.GetCourier("Courier");
        ddlCourierI.DataBind();
        ddlCourierI.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
    }
    public void Bind_Branch()
    {
        ddlBranch.DataSource = CourierDetails.GetCourier("Branch");
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
    }
    public void Bind_Courier()
    {
        ddlCourier.DataSource = CourierDetails.GetCourier("Courier");
        ddlCourier.DataBind();
        ddlCourier.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
    }
  
   
    public void BindData(DataTable dt1)
    {
        if (rdbselect.SelectedValue == "InvoiceNo")
        {
            if (dt1.Rows.Count > 0)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/ChetanaViewCourierCR.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrCustLabel.ReportSource = rd;
            }
        }
        else
        {
            if (dt1 != null)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/ChetanaViewCourierGeneralCR.rpt"));
                rd.Database.Tables[0].SetDataSource(dt1);
                CrCustLabel.ReportSource = rd;
            }
           
        }
    }

    

   
}