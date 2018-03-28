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
public partial class UserControls_uc_Approval : System.Web.UI.UserControl
{
    #region Varables
    static DataSet stDS;
    static int quantity = 0;
    static decimal tamount = 0;
    DateTime fdate;
    DateTime tdate;
    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
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
        }
        if (!Page.IsPostBack)
        {
            ViewState["sales"] = null;
            ViewState["all"] = null;


            //Rptrpending.DataSource = SpecimanDetails.Get_DC_Completed_IsApproved();
            //Rptrpending.DataBind();
        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = true;
        stDS = new DataSet();
        docno.InnerHtml = txtDocno.Text.Trim();
        stDS = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "approved");
        RepDetailsApprove.DataSource = stDS.Tables[0];
        RepDetailsApprove.DataBind();
        string jv = "";
        if (RepDetailsApprove.Items.Count <= 0)
        {
            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmedDC1_btnapproval').style.display='none';";


        }
        else
        {
            jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmedDC1_btnapproval').style.display='block';";

        }
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ((Button)(sender)).Enabled = false;
        SpecimenConfirmQtyDetails _objSpecimenConfirmQtyDetails = new SpecimenConfirmQtyDetails();
        Specimen _objspecimen = new Specimen();


        try
        {
            _objSpecimenConfirmQtyDetails.IsPrintInvoice = true;
            _objSpecimenConfirmQtyDetails.CreatedBy = Session["UserName"].ToString();
            _objSpecimenConfirmQtyDetails.SubDocId = Convert.ToDecimal(((Button)(sender)).CommandArgument.Trim());
            _objSpecimenConfirmQtyDetails.Save_Specimen_PrintInvoiceDetails();
            ((Button)(sender)).BackColor = System.Drawing.Color.Red;
            ((Button)(sender)).ForeColor = System.Drawing.Color.White;
            ((Button)(sender)).Enabled = true;
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintInvoiceReport.aspx?d=" + txtDocno.Text.Trim() + "&sd=" + ((Button)(sender)).CommandArgument.Trim() + "')", true);
        }


        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            ((Button)(sender)).Enabled = true;
        }
        //}
    }

    #region MsgBox
    public void MessageBox(string msg)
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

    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblAqty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
            lblamt1.Text = tamount.ToString().Trim();
        }
    }

    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        DataView dv = new DataView(stDS.Tables[1]);
        dv.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]);
        lblspinstruction.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["SpInstruction"]);
        lbldescription.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["Description"]);

    }
    protected void RdlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDetails.Visible = false;
        string RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Employee")
        {
            Pnlcust.Visible = true;
            pnlDate.Visible = false;
            Rptrpending.Visible = true;
            Rptrpending.DataBind();
            DDLEmployee.Focus();
            BindEmployee();
        }
        else if (RdBValue == "All")
        {
            Pnlcust.Visible = false;
            pnlDate.Visible = false;
            Rptrpending.Visible = true;
            Rptrpending.DataBind();
            bindData();
        }
        else
        {
            pnlDate.Visible = true;
            Pnlcust.Visible = false;
            Rptrpending.DataBind();
        }

    }

    public void bindData()
    {

        string RdBValue = RdlView.SelectedValue.ToString();

        if (RdBValue == "Employee")
        {

            Rptrpending.DataSource = SpecimanDetails.Get_DC_Completed_IsApproved("salesman",
                System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), DDLEmployee.SelectedValue.ToString());
            Rptrpending.DataBind();

        }
        else if (RdBValue == "All")
        {
            Rptrpending.DataSource = SpecimanDetails.Get_DC_Completed_IsApproved("all", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), DDLEmployee.SelectedValue.ToString());
            Rptrpending.DataBind();
        }
        else
        {
            try
            {

                string from = txtFromDate.Text.Split('/')[2] + "/" + txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0];
                string To = txttoDate.Text.Split('/')[2] + "/" + txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0];
                fdate = Convert.ToDateTime(from);
                tdate = Convert.ToDateTime(To);
                if (fdate > tdate)
                {
                    MessageBox("From Date is Greater than ToDate");
                    txtFromDate.Focus();
                }
                else
                {
                    Rptrpending.DataSource = SpecimanDetails.Get_DC_Completed_IsApproved("datewise", fdate, tdate, Convert.ToInt32(strFY), "");
                    Rptrpending.DataBind();
                }

            }
            catch (Exception ex)
            {


            }
        }
    }

    #region Bind Employee
    public void BindEmployee()
    {
        DataSet ds = null;
        if (ViewState["sales"] == null)
        {
            ds = Specimen.Get_ApprovedDocNo_Employee(Convert.ToInt32(strFY));
            ViewState["sales"] = ds;
        }
        else
        {
            ds = (DataSet)ViewState["sales"];
        }

        DDLEmployee.Items.Clear();
        DDLEmployee.DataSource = ds;
        DDLEmployee.DataBind();
        DDLEmployee.Items.Insert(0, new ListItem("- Select Employee -", "0"));
    }
    #endregion

    protected void btnemployee_Click(object sender, EventArgs e)
    {
        bindData();
        updateapprove.Update();
    }
    protected void btnfind_Click(object sender, EventArgs e)
    {
        bindData();
        updateapprove.Update();
    }
}
