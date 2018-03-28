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
public partial class UserControls_uc_ChetanaViewCourierCR : System.Web.UI.UserControl
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
        BranchEdit();
        CourierEdit();
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
        //txtDocNoGet.Text = "";
        //ddlBranchI.SelectedValue = "0";
        //ddlCourierI.SelectedValue = "0";
        //txtFrom.Text = "";
        //txtTo.Text = "";
        //txtGeneralCourierID.Text = "";
        //ddlBranch.SelectedValue = "0";
        //ddlCourier.SelectedValue = "0";
        //txtFromGeneral.Text = "";
        //txtToGeneral.Text = "";

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
    protected void grdCD_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
        divEdit.Visible = true;
        try
        {
            lblSCDetailAutoId.Text = ((Label)grdCD.Rows[e.NewEditIndex].FindControl("lblSCDetailAutoId")).Text;

            ddlCourierEdit.SelectedValue = ((Label)grdCD.Rows[e.NewEditIndex].FindControl("lblAutoId")).Text;
            ddlBranchEdit.SelectedValue = ((Label)grdCD.Rows[e.NewEditIndex].FindControl("lblEmpID")).Text;
            if (ddlBranchEdit.SelectedValue != "0")
            {
                DataSet Ds = new DataSet();
                Ds = CourierDetails.GetCourierBranch(Convert.ToInt16(ddlBranchEdit.SelectedValue.ToString()), "BranchAddress");


                txtAddressEdit.Text = Ds.Tables[0].Rows[0]["Address"].ToString();
                Ds.Dispose();
                trBranchAddress.Visible = true;
                trAddressGeneralEdit.Visible = false;

            }
            else
            {

                trAddressGeneralEdit.Visible = true;
                trBranchAddress.Visible = false;
            }
        }
        catch
        {
        }

    }
    protected void gdGeneral_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        divEdit.Visible = true;
        try
        {
            lblSCDetailAutoId.Text = ((Label)gdGeneral.Rows[e.NewEditIndex].FindControl("lblSCDetailAutoId")).Text;

            ddlCourierEdit.SelectedValue = ((Label)gdGeneral.Rows[e.NewEditIndex].FindControl("lblAutoId")).Text;
            ddlBranchEdit.SelectedValue = ((Label)gdGeneral.Rows[e.NewEditIndex].FindControl("lblEmpID")).Text;
            txt_remark.Text = ((Label)gdGeneral.Rows[e.NewEditIndex].FindControl("lblRemark1")).Text;
            txtdept.Text = ((Label)gdGeneral.Rows[e.NewEditIndex].FindControl("lblDepartment")).Text;
            if (ddlBranchEdit.SelectedValue != "0")
            {
                DataSet Ds = new DataSet();
                Ds = CourierDetails.GetCourierBranch(Convert.ToInt16(ddlBranchEdit.SelectedValue.ToString()), "BranchAddress");


                txtAddressEdit.Text = Ds.Tables[0].Rows[0]["Address"].ToString();
                Ds.Dispose();
                trBranchAddress.Visible = true;
                trAddressGeneralEdit.Visible = false;
            }
            else {

                trAddressGeneralEdit.Visible = true;
                trBranchAddress.Visible = false;
            }

        }
        catch
        {
        }

    }

    protected void ddlBranchEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranchEdit.SelectedValue.ToString() != "0")
        {
            trBranchAddress.Visible = true;
            DataSet Ds = new DataSet();
            Ds = CourierDetails.GetCourierBranch(Convert.ToInt16(ddlBranchEdit.SelectedValue.ToString()), "BranchAddress");


            txtAddressEdit.Text = Ds.Tables[0].Rows[0]["Address"].ToString();
            Ds.Dispose();
            trAddressGeneralEdit.Visible = false;
            txtAddressGeneralEdit.Text = "";

        }
        else
        {
            trBranchAddress.Visible = false;
            txtAddressEdit.Text = "";
            trAddressGeneralEdit.Visible = true;

        }
    }

    public void CourierEdit()
    {
       
            ddlCourierEdit.DataSource = CourierDetails.GetCourier("Courier");
            ddlCourierEdit.DataBind();
            ddlCourierEdit.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
        

    }
    public void BranchEdit()
    {
            ddlBranchEdit.DataSource = CourierDetails.GetCourier("Branch");
            ddlBranchEdit.DataBind();
            ddlBranchEdit.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
       

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int SCD;
        try 
        { CourierDetails _objCD = new CourierDetails();
        if (ddlBranchEdit.SelectedValue != "0")
        _objCD.Savecourier(Convert.ToString(lblSCDetailAutoId.Text), "Update", Convert.ToInt16(strFY), Convert.ToInt16(ddlCourierEdit.SelectedValue.ToString()), Convert.ToInt16(ddlBranchEdit.SelectedValue.ToString()), txtAddressEdit.Text.ToString(), Convert.ToString(Session["UserName"]), out SCD);
        else
         _objCD.Savecourier(Convert.ToString(lblSCDetailAutoId.Text), "Update", Convert.ToInt16(strFY), Convert.ToInt16(ddlCourierEdit.SelectedValue.ToString()), Convert.ToInt16(ddlBranchEdit.SelectedValue.ToString()), txtAddressGeneralEdit.Text.ToString(), Convert.ToString(Session["UserName"]), out SCD);
       
            MessageBox("Record saved successfully");
            divEdit.Visible = false;
        }
        catch { }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        
            divEdit.Visible = false;
        
    }
    protected void grdCD_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CourierDetails _objCD = new CourierDetails();
            _objCD.UpDateBy = Convert.ToString(Session["UserName"]);
            _objCD.SCMasterAutoId = float.Parse(((Label)grdCD.Rows[e.RowIndex].FindControl("lblSCDetailAutoId")).Text);
            _objCD.IsActive = Convert.ToBoolean(false);
            _objCD.DeleteSendcourier(_objCD.SCMasterAutoId, _objCD.IsActive, _objCD.UpDateBy, Convert.ToInt32(strFY));
            MessageBox("Record Deleted successfully");
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
            txtCourierId.Text = "";
            txtInvoiceNoGet.Text = "";
            txtDocNoGet.Text = "";
            ddlBranchI.SelectedValue = "0";
            ddlCourierI.SelectedValue = "0";
            //txtFrom.Text = "";
            //txtTo.Text = "";
            txtGeneralCourierID.Text = "";
            ddlBranch.SelectedValue = "0";
            ddlCourier.SelectedValue = "0";
        }
        catch
        {

        }
    }
    protected void gdGeneral_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CourierDetails _objCD = new CourierDetails();
            _objCD.UpDateBy = Convert.ToString(Session["UserName"]);
            _objCD.SCMasterAutoId = float.Parse(((Label)gdGeneral.Rows[e.RowIndex].FindControl("lblSCDetailAutoId")).Text);
            _objCD.IsActive = Convert.ToBoolean(false);
            _objCD.DeleteSendcourier(_objCD.SCMasterAutoId, _objCD.IsActive, _objCD.UpDateBy, Convert.ToInt32(strFY));
            MessageBox("Record Deleted successfully");
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
            txtCourierId.Text = "";
            txtInvoiceNoGet.Text = "";
            txtDocNoGet.Text = "";
            ddlBranchI.SelectedValue = "0";
            ddlCourierI.SelectedValue = "0";
            //txtFrom.Text = "";
            //txtTo.Text = "";
            txtGeneralCourierID.Text = "";
            ddlBranch.SelectedValue = "0";
            ddlCourier.SelectedValue = "0";
        }
        catch
        {

        }
    }

}