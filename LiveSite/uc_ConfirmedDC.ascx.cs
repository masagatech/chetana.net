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

public partial class UserControls_uc_ConfirmedDC : System.Web.UI.UserControl
{
    #region Varables
    static DataSet stDS;

    static int quantity = 0;
    static decimal tamount = 0;
    static decimal totalamount = 0;
    static decimal temp;
    static decimal frieght = 0;
    static decimal tax = 0;
    string flag1;

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Cleardata();
            Rptrpending.DataSource = Specimen.Get_ApprovedDocNo();
            Rptrpending.DataBind();
        }
    }

    #endregion

    protected void btnget_Click(object sender, EventArgs e)
    {
        stDS = new DataSet();
        docno.InnerHtml = txtDocno.Text.Trim();
        stDS = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed");
        RepDetailsConfirm.DataSource = stDS.Tables[0];
        RepDetailsConfirm.DataBind();

        if (txtFisrt != null)
        { txtFisrt.Focus(); }
        // lblfright.Visible = true;
        // txtfrieght.Visible = true;
        //  lbltax.Visible = true;
        //  txttax.Visible = true;
        //string jv = "";
        //if (RepDetailsConfirm.Items.Count <= 0)
        //{
        //    jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmedDC1_btnapproval').style.display='none';";
        //}
        //else
        //{
        //    jv = "document.getElementById('ctl00_ContentPlaceHolder1_uc_ConfirmedDC1_btnapproval').style.display='block';";
        //}
        //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "a", jv, true);
        //ds = SpecimanDetails.Idv_Get_SpecimenDetails_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed");
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count != 0)
        //{
        //    btnapproval.Enabled = true;
        //}
        //else
        //{
        //    bool Auth = Specimen.Get_DocumentNum_Authentication(Convert.ToInt32(txtDocno.Text));
        //    if (Auth)
        //    {
        //        MessageBox("Document no is not available");
        //        txtDocno.Focus();
        //    }
        //    else
        //    {
        //    }
        //}
    }

    protected void btnapproval_Click(object sender, EventArgs e)
    {
        //bool Auth = Specimen.Get_DocumentNum_Authentication(Convert.ToInt32(txtDocno.Text));
        //if (Auth)
        //{
        //    MessageBox("Document no is not available");
        //    txtDocno.Focus();
        //}
        //else
        //{
        //    SpecimenConfirmQtyDetails _objSpecimenConfirmQtyDetails = new SpecimenConfirmQtyDetails();
        //    Specimen _objspecimen = new Specimen();
        //    SpecimenConfirmQtyDetails _objSpecimenFT = new SpecimenConfirmQtyDetails();

        //    try
        //    {
        //        _objSpecimenConfirmQtyDetails.IsCreateInvoice = true;
        //        _objSpecimenConfirmQtyDetails.CreatedInvoiceBy = "admin";
        //        _objSpecimenConfirmQtyDetails.SubDocNo = Convert.ToDecimal(((Button)(sender)).CommandArgument.Trim());
        //        _objspecimen.DocNo = Convert.ToInt32(txtDocno.Text);
        //       // _objSpecimenConfirmQtyDetails.Transporter =


        //        _objSpecimenConfirmQtyDetails.SaveConfirmDetails();
        //        Cleardata();
        //        stDS = new DataSet();
        //        docno.InnerHtml = txtDocno.Text.Trim();
        //        stDS = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed");
        //        if (Rptrpending.Items.Count == 1)
        //        {
        //            Rptrpending.DataSource = Specimen.Get_ApprovedDocNo();
        //            Rptrpending.DataBind();
        //            updateapprove.Update();
        //        }
        //        RepDetailsConfirm.DataSource = stDS.Tables[0];
        //        RepDetailsConfirm.DataBind();
        //        MessageBox("DC approved successfully for document no. " + txtDocno.Text);
        //        docno.InnerHtml = "Last confirm doc no. : " + docno.InnerHtml;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox(ex.Message.ToString());
        //    }
        //}
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lbl = (Label)e.Row.FindControl("lblspecidatils");
        //    GridView grdQtyDetails = (GridView)e.Row.FindControl("grdDetailQty");
        //    grdQtyDetails.DataSource = SpecimanDetails.Get_QtyDetails_By_SpecimenDetailsID(Convert.ToInt32(lbl.Text.Trim()));
        //    grdQtyDetails.DataBind();

        //}
    }
    public void Cleardata()
    {
        txttax.Text = "";
        txtfrieght.Text = "";
        lblfright.Visible = false;
        txtfrieght.Visible = false;
        lbltax.Visible = false;
        txttax.Visible = false;
    }
    TextBox txtFisrt;
    int i = 0;
    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        TextBox txtDate = (TextBox)e.Item.FindControl("txtdateabc");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        DataView dv = new DataView(stDS.Tables[1]);
        dv.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]);
        if (i == 0)
        {
            txtFisrt = (TextBox)e.Item.FindControl("txtTransporter");
            i++;
        }

        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void txtfrieght_TextChanged(object sender, EventArgs e)
    {
        //tamount
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
            SpecimenConfirmQtyDetails _objSpecimenConfirmQtyDetails = new SpecimenConfirmQtyDetails();
            Specimen _objspecimen = new Specimen();
            SpecimenConfirmQtyDetails _objSpecimenFT = new SpecimenConfirmQtyDetails();

            try
            {
                decimal subconfirmdoc = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                _objSpecimenConfirmQtyDetails.IsCreateInvoice = true;
                _objSpecimenConfirmQtyDetails.CreatedInvoiceBy = "admin";
                _objSpecimenConfirmQtyDetails.SubDocNo = Convert.ToDecimal(e.CommandArgument.ToString().Trim());
                _objspecimen.DocNo = Convert.ToInt32(txtDocno.Text);
                _objSpecimenConfirmQtyDetails.Transporter = ((TextBox)e.Item.FindControl("txtTransporter")).Text;
                _objSpecimenConfirmQtyDetails.LrNo = ((TextBox)e.Item.FindControl("txtlrno")).Text;
                _objSpecimenConfirmQtyDetails.Bundles = ((TextBox)e.Item.FindControl("txtbundles")).Text;
                TextBox txtdateabc = (TextBox)e.Item.FindControl("txtdateabc");
                string date1;
                if (txtdateabc.Text == "")
                {
                    date1 = "01/01/2001";
                }
                else
                {
                    date1 = txtdateabc.Text.Split('/')[1] + "/" + txtdateabc.Text.Split('/')[0] + "/" + txtdateabc.Text.Split('/')[2];
                }
                _objSpecimenConfirmQtyDetails.InvoiceDate = Convert.ToDateTime(date1);
                _objSpecimenConfirmQtyDetails.SaveConfirmDetails();
                Cleardata();
                stDS = new DataSet();
                docno.InnerHtml = txtDocno.Text.Trim();
                stDS = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(txtDocno.Text), "confirmed");
                RepDetailsConfirm.DataSource = stDS.Tables[0];
                RepDetailsConfirm.DataBind();

                MessageBox("DC approved successfully for document no. " + subconfirmdoc);
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
                    upDocNo.Update();
                    docno.InnerHtml = "";
                    //lblcustname.InnerHtml = "";
                    lblempname1.InnerHtml = "";
                    //updateapprove.Update();
                }

                updateapprove.Update();
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message.ToString());
            }
        }
    }
}
