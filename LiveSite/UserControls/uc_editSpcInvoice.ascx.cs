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

public partial class UserControls_uc_editSpcInvoice : System.Web.UI.UserControl
{
    #region Varables
    DataSet stDS;
    static int quantity = 0;
    static decimal tamount = 0;
    DateTime fdate;
    DateTime tdate;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string userName = "";
    string flag1;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                userName = Session["UserName"].ToString();
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
        ViewState["staticDS"] = stDS;
        RepDetailsConfirm.DataSource = stDS.Tables[0];
        RepDetailsConfirm.DataBind();
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

    protected void lbltransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if ((((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text) != "")
            {
                string TransCode = (((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text.ToString().Split(':', '[', ']')[0].Trim());
                flag1 = (((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text.ToString().Split('[', ']')[1].Trim());

                if (flag1 == "Emp")
                {
                    string Empname = (((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text.ToString().Split(':', '[')[2].Trim());
                    (((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text) = Empname;
                }
                else if (flag1 == "Trans")
                {
                    (((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text) = TransCode;
                }
                else
                {
                    (((TextBox)((TextBox)(sender)).Parent.FindControl("txtTransporter")).Text) = "No such record found";
                }

            }
        }

        catch
        {

        }
        ((TextBox)((TextBox)(sender)).Parent.FindControl("txtlrno")).Focus();

    }
    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox lbl = (TextBox)e.Row.FindControl("lblAqty");
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
    public void Cleardata()
    {
        //txttax.Text = "";
        //txtfrieght.Text = "";
        //lblfright.Visible = false;
        //txtfrieght.Visible = false;
        //lbltax.Visible = false;
        //txttax.Visible = false;
    }

    #region repeter Row data bound


    DataView dvGetdata = null;
    Label SubConfirmID = null;
    GridView grdView = null;
    TextBox txTransport = null;
    TextBox txtLrNo = null;
    TextBox txtBundles = null;
    TextBox txtDate = null;
    DataView det = null;
    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        grdView = (GridView)e.Item.FindControl("grdapproval");
        txTransport = (TextBox)e.Item.FindControl("txtTransporter");
        txtLrNo = (TextBox)e.Item.FindControl("txtlrno");
        txtBundles = (TextBox)e.Item.FindControl("txtbundles");
        txtDate = (TextBox)e.Item.FindControl("txtdateabc");
        stDS = (DataSet)ViewState["staticDS"];
        dvGetdata = new DataView(stDS.Tables[1]);
        det = new DataView(stDS.Tables[3]);
        dvGetdata.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dvGetdata;
        grdView.DataBind();
        lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]);
        det.RowFilter = "SubDocId = " + SubConfirmID.Text.Trim();
        txTransport.Text = det.ToTable().Rows[0]["Transporter"].ToString();
        txtBundles.Text = det.ToTable().Rows[0]["Bundles"].ToString();
        txtLrNo.Text = det.ToTable().Rows[0]["LrNo"].ToString();
        txtDate.Text = det.ToTable().Rows[0]["InvoiceDate"].ToString();
    }
    #endregion

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
        // updateapprove.Update();
    }
    protected void btnfind_Click(object sender, EventArgs e)
    {
        bindData();
        //updateapprove.Update();
    }

    protected void RepDetailsConfirm_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        bool Auth = Specimen.Get_DocumentNum_Authentication(Convert.ToInt32(txtDocno.Text));
        if (Auth)
        {
            MessageBox("Document no is not available");
            txtDocno.Focus();
        }
        else
        {
            GridView grd = (GridView)e.Item.FindControl("grdapproval");
            updateRecords(grd, docno.InnerHtml.Trim(), e.CommandArgument.ToString().Trim());
            SpecimenConfirmQtyDetails _objSpecimenConfirmQtyDetails = new SpecimenConfirmQtyDetails();
            Specimen _objspecimen = new Specimen();
            SpecimenConfirmQtyDetails _objSpecimenFT = new SpecimenConfirmQtyDetails();
            try
            {
                decimal subconfirmdoc = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                _objSpecimenConfirmQtyDetails.IsCreateInvoice = true;
                _objSpecimenConfirmQtyDetails.CreatedInvoiceBy = userName;
                _objSpecimenConfirmQtyDetails.SubDocNo = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                _objspecimen.DocNo = Convert.ToInt32(txtDocno.Text);
                _objSpecimenConfirmQtyDetails.Transporter = ((TextBox)e.Item.FindControl("txtTransporter")).Text;
                _objSpecimenConfirmQtyDetails.LrNo = ((TextBox)e.Item.FindControl("txtlrno")).Text;
                _objSpecimenConfirmQtyDetails.Bundles = ((TextBox)e.Item.FindControl("txtbundles")).Text;
                TextBox txtdateabc = (TextBox)e.Item.FindControl("txtdateabc");
                string date1;
                if (txtdateabc.Text == "")
                {
                    date1 = null;
                }
                else
                {
                    date1 = txtdateabc.Text.Split('/')[1] + "/" + txtdateabc.Text.Split('/')[0] + "/" + txtdateabc.Text.Split('/')[2];
                }
                _objSpecimenConfirmQtyDetails.InvoiceDate = Convert.ToDateTime(date1);
                _objSpecimenConfirmQtyDetails.SaveConfirmDetails();
                Cleardata();
                // stDS = new DataSet();
                docno.InnerHtml = txtDocno.Text.Trim();
                // stDS = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "approved");
                // ViewState["staticDS"] = stDS;
                //RepDetailsConfirm.DataSource = stDS.Tables[0];
                // RepDetailsConfirm.DataBind();

                MessageBox("Invoice No. " + subconfirmdoc + " Successfully updated!");
                docno.InnerHtml = "Last confirm doc no. : " + subconfirmdoc;

                if (Rptrpending.Items.Count == 1)
                {
                    Rptrpending.DataSource = Specimen.Get_ApprovedDocNo();
                    Rptrpending.DataBind();
                    //updateapprove.Update();
                }
                if (RepDetailsConfirm.Items.Count == 0)
                {
                    Rptrpending.DataSource = Specimen.Get_ApprovedDocNo();
                    Rptrpending.DataBind();
                    //upDocNo.Update();
                    docno.InnerHtml = "";
                    //lblcustname.InnerHtml = "";
                    lblempname1.InnerHtml = "";
                    //updateapprove.Update();
                }

                //updateapprove.Update();
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message.ToString());
            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        ImageButton img = (ImageButton)sender;


        try
        {

            deleteRecords(img);

        }
        catch
        {


        }
    }

    public void updateRecords(GridView grd, string DocumentNo, string subdocId)
    {
        try
        {
            Label confirmQtyId; Label lblQty; TextBox txtQty; Label lblRate; TextBox txtRate; Label lblAmount; TextBox txtAmount;

            SpecimanDetails obj = new SpecimanDetails();
            obj.DocumentNo = Convert.ToInt32(DocumentNo);
            obj.SubdocID = Convert.ToDecimal(subdocId);
            foreach (GridViewRow row in grd.Rows)
            {
                lblQty = (Label)row.FindControl("lblAvailblQtyOrg"); txtQty = (TextBox)row.FindControl("lblAqty");
                lblRate = (Label)row.FindControl("lblrateOrg"); txtRate = (TextBox)row.FindControl("lblrate");
                confirmQtyId = (Label)row.FindControl("lblCQt");

                if ((lblQty.Text.Trim() != txtQty.Text.Trim()) || lblRate.Text.Trim() != txtRate.Text.Trim())
                {
                    obj.Rate = Convert.ToDecimal(txtRate.Text.Trim());
                    obj.Amount = (Convert.ToDecimal(txtRate.Text.Trim()) * Convert.ToDecimal(txtQty.Text.Trim()));
                    obj.Quantity = Convert.ToInt32(txtQty.Text.Trim());
                    obj.SpecimenDetailID = Convert.ToInt32(confirmQtyId.Text.Trim());
                    obj.UpdateSpecimenInvoice();
                }
            }
        }
        catch (Exception ex)
        {


        }
    }


    public void deleteRecords(ImageButton btn)
    {
        try
        {
            Label confirmQtyId; Label lblQty; TextBox txtQty; Label lblRate; TextBox txtRate; Label lblAmount; TextBox txtAmount;
            Label subdocId;
            confirmQtyId = (Label)btn.Parent.FindControl("lblCQt");
            subdocId = (Label)btn.Parent.Parent.Parent.Parent.Parent.FindControl("SubConfirmID");
            SpecimanDetails obj = new SpecimanDetails();
            obj.DocumentNo = Convert.ToInt32(docno.InnerHtml.Trim());
            obj.SubdocID = Convert.ToDecimal(subdocId.Text);           
            obj.Rate = 0;
            obj.Amount = 0;
            obj.Quantity = 0;
            obj.SpecimenDetailID = Convert.ToInt32(confirmQtyId.Text.Trim());
            obj.UpdateSpecimenInvoice();
            GridViewRow row = (GridViewRow)((btn).NamingContainer);
            row.Visible = false;
        }
        catch (Exception ex)
        {


        }
    }
}
