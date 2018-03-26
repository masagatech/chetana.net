#region Namespace
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
#endregion

public partial class UserControls_uc_Scheme_CustomerMapping : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "";
    string strFY;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["FY"] != null)
        {
            // strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
            strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();

        }
        //Response.Write(strFY);


        if (!Page.IsPostBack)
        {
            Session["schememapping"] = null;
            DDLScheme.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup("Scheme").Tables[0];
            DDLScheme.DataBind();
            DDLScheme.Items.Insert(0, new ListItem("--Select Scheme--", "0"));
            SetView();
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //try
        //{
        Scheme objscheme = new Scheme();
        objscheme.SchemeMappingID = Convert.ToInt32(lblID.Text);
        objscheme.SchemeID = Convert.ToInt32(DDLScheme.SelectedValue.ToString());
        objscheme.CustID = txtcustomer.Text.Trim().ToString();
        if (txtamount.Text.Trim() != "")
        {
            objscheme.Amount = Convert.ToDecimal(txtamount.Text.Trim());
        }
        else
        {
            objscheme.Amount = 0;
        }
        if (txtdiscount.Text.Trim() != "")
        {
            objscheme.Discount = Convert.ToDecimal(txtdiscount.Text.Trim().ToString());
        }
        else
        {
            objscheme.Discount = 0;
        }
        objscheme.Years = txtyear.Text.Trim().ToString();
        objscheme.startYear = txtstartYear.Text.Trim().ToString();
        objscheme.ISS = true;
        objscheme.IsActive = true;
        objscheme.IsDeleted = false;
        objscheme.CreatedBy = Convert.ToString(Session["UserName"].ToString());
        objscheme.FinancialYearFrom = Convert.ToInt32(strFY);
        objscheme.IsDelivered = chkIsDelivered.Checked;
        objscheme.IsReceived = chkIsReceived.Checked;
        objscheme.DeliveredDate = Convert.ToDateTime("01/01/1999");
        if (txtdeldate.Text != "")
        {
            objscheme.DeliveredDate = DateTime.ParseExact(txtdeldate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        objscheme.ReceivedDate = Convert.ToDateTime("01/01/1999");
        if (txtrdate.Text != "")
        {
            objscheme.ReceivedDate = DateTime.ParseExact(txtrdate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        Others.OtherNewClass.Save_Scheme_Customer_Mapping(objscheme.SchemeMappingID,
objscheme.SchemeID, objscheme.CustID, objscheme.Years, objscheme.Discount, Convert.ToInt32(strFY), objscheme.ISS, objscheme.IsActive, objscheme.IsDeleted, objscheme.CreatedBy,
objscheme.Remark1, objscheme.Remark2, objscheme.Remark3, objscheme.Amount, objscheme.startYear, objscheme.IsDelivered, objscheme.IsReceived, objscheme.DeliveredDate, objscheme.ReceivedDate);


        if (btn_Save.Text == "Update")
        {
            message("Record Updated Successfully");
            btn_Save.Text = "Save";
            Panel1.Visible = false;
            Panel2.Visible = true;
            BindDetail();
            btn_Save.Visible = false;
        }
        else
        {
            message("Record Saved Successfully");
        }
        // }
        // catch { }
        Clear();

    }
    public void Clear()
    {
        DDLScheme.SelectedIndex = 0;
        txtcustomer.Text = "";
        lblCustName.Text = "";
        txtamount.Text = "";
        txtdiscount.Text = "";
        txtyear.Text = "";
        txtstartYear.Text = "";
        txtdeldate.Text = "";
        txtrdate.Text = "";
    }
    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
    }
    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }



    #endregion
    protected void GrdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Scheme objschemedelete = new Scheme();
            objschemedelete.SchemeMappingID = Convert.ToInt32(((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblAutoID")).Text);
            objschemedelete.SchemeID = Convert.ToInt32(((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblSchemeID")).Text);
            objschemedelete.CustID = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblCustCode")).Text.ToString();
            if (((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblAmount")).Text.Trim() != "")
            {
                objschemedelete.Amount = Convert.ToDecimal(((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblAmount")).Text.Trim());
            }
            else
            {
                objschemedelete.Amount = 0;
            }
            if (((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblDiscount")).Text.Trim() != "")
            {
                objschemedelete.Discount = Convert.ToDecimal(((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblDiscount")).Text.ToString());
            }
            else
            {
                objschemedelete.Discount = 0;
            }
            objschemedelete.Years = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblYears")).Text.ToString();
            objschemedelete.startYear = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblStartYear")).Text.ToString();
            objschemedelete.ISS = ((CheckBox)GrdDetails.Rows[e.RowIndex].FindControl("chkIss")).Checked;
            objschemedelete.IsActive = false;
            objschemedelete.IsDeleted = true;
            objschemedelete.CreatedBy = Convert.ToString(Session["UserName"].ToString());
            objschemedelete.FinancialYearFrom = Convert.ToInt32(strFY);
            objschemedelete.DeliveredDate = Convert.ToDateTime("01/01/1999");
            objschemedelete.ReceivedDate = Convert.ToDateTime("01/01/1999");
            Others.OtherNewClass.Save_Scheme_Customer_Mapping(objschemedelete.SchemeMappingID,
objschemedelete.SchemeID, objschemedelete.CustID, objschemedelete.Years, objschemedelete.Discount, Convert.ToInt32(strFY), objschemedelete.ISS, objschemedelete.IsActive, objschemedelete.IsDeleted, objschemedelete.CreatedBy,
objschemedelete.Remark1, objschemedelete.Remark2, objschemedelete.Remark3, objschemedelete.Amount, objschemedelete.startYear, objschemedelete.IsDelivered, objschemedelete.IsReceived, objschemedelete.DeliveredDate, objschemedelete.ReceivedDate);
            BindDetail();
        }
        catch { }

    }
    protected void GrdDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        btn_Save.Visible = true;

        btn_Save.Text = "Update";

        lblID.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblAutoID")).Text;
        DDLScheme.SelectedValue = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblSchemeID")).Text;
        txtcustomer.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblCustCode")).Text;
        lblCustName.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblCustName")).Text;
        txtamount.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblAmount")).Text;
        txtdiscount.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblDiscount")).Text;
        txtyear.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblYears")).Text;
        txtstartYear.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblStartYear")).Text;
        chkIsReceived.Checked = ((CheckBox)GrdDetails.Rows[e.NewEditIndex].FindControl("chkReceived")).Checked;
        chkIsDelivered.Checked = ((CheckBox)GrdDetails.Rows[e.NewEditIndex].FindControl("chkDelivered")).Checked;
        string strorddt = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lbldeldate")).Text;
        string strrecdt = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblrecdate")).Text;
        DateTime deldt = Convert.ToDateTime("01/01/1999");
        DateTime recdt = Convert.ToDateTime("01/01/1999");
        if (strorddt != "")
        { deldt = Convert.ToDateTime(strorddt); }
        if (strrecdt != "")
        { deldt = Convert.ToDateTime(strrecdt); }

        if (!deldt.Equals(Convert.ToDateTime("01/01/1999")))
        {
            txtdeldate.Text = deldt.ToString("dd/MM/yyyy");
        }
        else
        {
            txtdeldate.Text = "";
        }
        if (!recdt.Equals(Convert.ToDateTime("01/01/1999")))
        {
            txtrdate.Text = recdt.ToString("dd/MM/yyyy");
        }
        else
        {
            txtrdate.Text = "";
        }


    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                DDLScheme.Focus();
                lblID.Text = "0";
                Panel1.Visible = true;
                Panel2.Visible = false;
                btn_Save.Visible = true;

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    btn_Save.Visible = false;
                    BindDetail();
                }
        }
    }

    public void BindDetail()
    {
        Session["schememapping"] = Scheme.Get_Scheme_Customer_Mapping("", "", Convert.ToInt32(strFY)).Tables[0];
        GrdDetails.DataSource = (DataTable)Session["schememapping"];
        GrdDetails.DataBind();
    }
    protected void GrdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDetails.PageIndex = e.NewPageIndex;
        GrdDetails.DataSource = (DataTable)Session["schememapping"];
        GrdDetails.DataBind();
    }
}
