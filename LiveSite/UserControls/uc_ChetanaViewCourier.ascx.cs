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

public partial class UserControls_uc_ChetanaViewCourier : System.Web.UI.UserControl
{
    #region Varables

    static int quantity = 0;
    static decimal APODId = 0;
    static decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    static int docnewno = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    string DocNo;
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
        if (IsPostBack == true) { return; }
        lblMessage.Text = "";
        divLevel2.Visible = true;
        divGeneral.Visible = false;
        Branch();
        Courier();
    }
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
                Ds = CourierDetails.ViewCourierDate(0,"","", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY)).Tables[0];
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
                Ds = CourierDetails.ViewCourierDate(0,"","", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY)).Tables[0];
            
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
        if (rdLevel1.SelectedValue != "Others")
        {
            grdCD.DataSource = Ds;
            grdCD.DataBind();
        }
        else
        {
            gdGeneral.DataSource = Ds;
            gdGeneral.DataBind();
        }
        //txtCourierId.Text = "";
        //txtInvoiceNoGet.Text = "";
       // txtDocNoGet.Text = "";
       // ddlBranchI.SelectedValue = "0";
        //ddlCourierI.SelectedValue = "0";
       // txtFrom.Text = "";
       // txtTo.Text = "";
        //txtGeneralCourierID.Text = "";
      //  ddlBranch.SelectedValue = "0";
       // ddlCourier.SelectedValue = "0";
        //txtFromGeneral.Text = "";
       // txtToGeneral.Text = "";

    }
   
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            APODId = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSCMasterAutoId = (Label)e.Row.Parent.Parent.Parent.FindControl("lblSCMasterAutoId");
            Label lblDocumentNo = (Label)e.Row.Parent.Parent.Parent.FindControl("lblDocumentNo");
            Label lblInvoiceNo = (Label)e.Row.Parent.Parent.Parent.FindControl("lblInvoiceNo");
            TextBox txtPODId = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txtPODId");
            lblSCMasterAutoId = (Label)e.Row.FindControl("lblSCMasterAutoId");
            txtPODId = (TextBox)e.Row.FindControl("txtPODId");
            lblDocumentNo = (Label)e.Row.FindControl("lblDocumentNo");

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
        }



    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
   
    protected void rdLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            //divLevel4.Visible = false;
            divLevel2.Visible = true;
            divGeneral.Visible = false;
            //divLevel3.Visible = true;
            Branch();
            Courier();
            divGridInvoice.Visible = true;
            divGridGeneral.Visible = false;

        }
        else
        {
            //divLevel3.Visible = false;

            divLevel2.Visible = false;
            divGeneral.Visible = true;
            //divLevel4.Visible = true;

            Branch();
            Courier();
            divGridInvoice.Visible = false;
            divGridGeneral.Visible = true;


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
}