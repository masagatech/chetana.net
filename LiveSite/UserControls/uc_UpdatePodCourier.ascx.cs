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
public partial class UserControls_uc_UpdatePodCourier : System.Web.UI.UserControl
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
    }
    protected void btnget_Click(object sender, EventArgs e)
    {

        ViewState["DocNo"] = ViewState["DocNo"] + "," + txtDocNoGet.Text + ",";
        DataSet Ds = new DataSet();
        if (txtCourierId.Text.ToString() != "")
        {
            Ds = CourierDetails.UpdatePOD(float.Parse(txtCourierId.Text), "CourierId", Convert.ToInt32(strFY));

        }
        else if (txtInvoiceNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.UpdatePOD(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY));

        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.UpdatePOD(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY));

        }

        RepDetailsConfirm.DataSource = Ds.Tables[1];
        RepDetailsConfirm.DataBind();
    }
    protected void grdCD_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void RepDetailsConfirm_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
                CourierDetails _objCD = new CourierDetails();
                try
                {
                    DataSet DS = new DataSet();
                    Repeater objrep = (Repeater)this.FindControl("RepDetailsConfirm");
                    GridView objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdCD");
                    foreach (GridViewRow row in objgrid.Rows)
                    {
                        _objCD.SCMasterAutoId = float.Parse(((Label)row.FindControl("lblSCMasterAutoId")).Text);
                        _objCD.DocumentNo = float.Parse(((Label)row.FindControl("lblDocumentNo")).Text);
                        _objCD.InvoiceNo = float.Parse(((Label)row.FindControl("lblInvoiceNo")).Text);
                        _objCD.POD = Convert.ToInt32(((TextBox)row.FindControl("txtPODId")).Text);
                        _objCD.CreatedBy = Convert.ToString(Session["UserName"]);
                       
                        if (txtCourierId.Text.ToString() != "")
                        {
                            _objCD.UpdatePODNo(_objCD.SCMasterAutoId, _objCD.DocumentNo, _objCD.InvoiceNo, "CourierId", _objCD.POD, Convert.ToInt32(strFY));
                            DS = CourierDetails.UpdatePOD(float.Parse(txtCourierId.Text), "CourierId", Convert.ToInt32(strFY));

                        }
                        else if (txtInvoiceNoGet.Text.ToString() != "")
                        {
                            _objCD.UpdatePODNo(_objCD.SCMasterAutoId, _objCD.DocumentNo, _objCD.InvoiceNo, "Invoice", _objCD.POD, Convert.ToInt32(strFY));
                            DS = CourierDetails.UpdatePOD(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY));

                        }
                        else if (txtDocNoGet.Text.ToString() != "")
                        {
                            _objCD.UpdatePODNo(_objCD.SCMasterAutoId, _objCD.DocumentNo, _objCD.InvoiceNo, "DocNo", _objCD.POD, Convert.ToInt32(strFY));
                            DS = CourierDetails.UpdatePOD(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY));

                        }
                    }
                    RepDetailsConfirm.DataSource = DS.Tables[1];
                    RepDetailsConfirm.DataBind();
                }
                catch (Exception ex)
                {
                    MessageBox(ex.Message.ToString());
                }
    }
    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtPODId = null;
        Label lblSCMasterAutoId = null;
        Label lblDocumentNo = null;
        Label lblInvoiceNo = null;
        txtPODId = (TextBox)e.Item.FindControl("txtPODId");
        lblSCMasterAutoId = (Label)e.Item.FindControl("lblSCMasterAutoId");
        lblDocumentNo = (Label)e.Item.FindControl("lblDocumentNo");
        lblInvoiceNo = (Label)e.Item.FindControl("lblInvoiceNo");

        Label lblCustName = (Label)e.Item.FindControl("lblCustName");
        GridView grdView = (GridView)e.Item.FindControl("grdCD");
        ViewState["DocNo"] = ViewState["DocNo"] + "," + txtDocNoGet.Text + ",";
        DataSet Ds = new DataSet();
        if (txtCourierId.Text.ToString() != "")
        {
            Ds = CourierDetails.UpdatePOD(float.Parse(txtCourierId.Text), "CourierId", Convert.ToInt32(strFY));

        }
        else if (txtInvoiceNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.UpdatePOD(float.Parse(txtInvoiceNoGet.Text), "Invoice", Convert.ToInt32(strFY));

        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            Ds = CourierDetails.UpdatePOD(float.Parse(txtDocNoGet.Text), "DocNo", Convert.ToInt32(strFY));

        }
        DataView dv = new DataView(Ds.Tables[0]);
        grdView.DataSource = dv;
        grdView.DataBind();
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

    }

}