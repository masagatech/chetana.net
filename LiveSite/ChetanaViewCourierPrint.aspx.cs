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

public partial class ChetanaViewCourierPrint : System.Web.UI.Page
{
    #region Variables
    //int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    #endregion
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
            ViewState["Data"] = null;
        }
        divLevel2.Visible = true;
        divGeneral.Visible = false;
        Branch();
        Courier();
    }
    protected void rdLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            
            divLevel2.Visible = true;
            divGeneral.Visible = false;
            Branch();
            Courier();
            ViewState["Data"] = null;

        }
        else
        {
            divLevel2.Visible = false;
            divGeneral.Visible = true;
            Branch();
            Courier();
            ViewState["Data"] = null;


        }
    }
    public void Courier()
    {
        
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            ddlCourierI.DataSource = CourierDetails.GetCourier("Courier");
            ddlCourierI.DataBind();
            ddlCourierI.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
        }
        else if (rdLevel1.SelectedValue == "Others")
        {
            ddlCourier.DataSource = CourierDetails.GetCourier("Courier");
            ddlCourier.DataBind();
            ddlCourier.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
        }


    }
    public void Branch()
    {
        
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            ddlBranchI.DataSource = CourierDetails.GetCourier("Branch");
            ddlBranchI.DataBind();
            ddlBranchI.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
        }
        else if (rdLevel1.SelectedValue == "Others")
        {
            ddlBranch.DataSource = CourierDetails.GetCourier("Branch");
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
        }

    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
   
    

    protected void btnget_Click(object sender, EventArgs e)
    {

        ViewState["DocNo"] = ViewState["DocNo"] + "," + txtDocNoGet.Text + ",";
        DataTable Ds = new DataTable();
        if (txtCourierId.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtCourierId.Text), "CourierId", Convert.ToInt32(strFY)).Tables[0];

        }
        else if (txtInvoiceNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY)).Tables[0];

        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY)).Tables[0];

        }
        else if (txtGeneralCourierID.Text.ToString() != "")
        {
            Ds = CourierDetails.ViewCourier(float.Parse(txtGeneralCourierID.Text), "GeneralCourierID", Convert.ToInt32(strFY)).Tables[0];

        }

        else if (ddlBranch.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "Others"))
        {
            if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
            {
                Ds = CourierDetails.ViewCourierDate(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY)).Tables[0];
            }
            else
            {
                Ds = CourierDetails.ViewCourierDate(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY)).Tables[0];
            }

        }
        else if ((ddlCourier.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "Others"))
        {
            if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
            {
                Ds = CourierDetails.ViewCourierDate(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY)).Tables[0];
            }
            else
            {
                Ds = CourierDetails.ViewCourierDate(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY)).Tables[0];
            }

        }
        else if (ddlBranchI.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
            {
                Ds = CourierDetails.ViewCourierDate(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY)).Tables[0];
            }
            else
            {
                Ds = CourierDetails.ViewCourierDate(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY)).Tables[0];
            }
        }
        else if ((ddlCourierI.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
            {
                Ds = CourierDetails.ViewCourierDate(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY)).Tables[0];
            }
            else
            {
                Ds = CourierDetails.ViewCourierDate(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY)).Tables[0];

            }

        }
        else if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            Ds = CourierDetails.ViewCourierDate(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "Date", Convert.ToInt32(strFY)).Tables[0];

        }
        else if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
        {
            Ds = CourierDetails.ViewCourierDate(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralDate", Convert.ToInt32(strFY)).Tables[0];

        }
        DataView dv = new DataView(Ds);
        ViewState["Data"] = Ds;
        ReportDocument rd = new ReportDocument();
        if (rdLevel1.SelectedValue != "Others")
        {
           // rd.Load(Server.MapPath("Report/ChetanaViewCourierCR.rpt"));
            rd.Load(Server.MapPath("Report/ChetanaViewCourierPrint1.rpt"));
        }
        else
        {
            //rd.Load(Server.MapPath("Report/ChetanaViewCourierGeneral.rpt"));
           // rd.Load(Server.MapPath("Report/ChetanaViewCourier2.rpt"));
        }
      
        rd.Database.Tables[0].SetDataSource(dv);
        ChetanaViewCourier.ReportSource = rd;
        txtCourierId.Text = "";
        txtInvoiceNoGet.Text = "";
        txtDocNoGet.Text = "";
        ddlBranchI.SelectedValue = "0";
        ddlCourierI.SelectedValue = "0";
        Ds.Dispose();
        //txtFrom.Text = "";
        //txtTo.Text = "";
        //txtGeneralCourierID.Text = "";
        //ddlBranch.SelectedValue = "0";
        //ddlCourier.SelectedValue = "0";
        //txtFromGeneral.Text = "";
        //txtToGeneral.Text = "";

    }
}