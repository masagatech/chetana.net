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

public partial class UserControls_uc_Financial_YearMaster : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdyearDetails.DataSource = BindGVFy();
            grdyearDetails.DataBind();
            SetView();
        }
        else
        {
           
        }
    }
    #region Methods
    
   
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Year";
                lblID.Text = "0";
                pnlFinYearDetails.Visible = false;
                PnlYear.Visible = true;
                btnSave.Visible = true;
                txtfrmyr.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View Year";
                    pnlFinYearDetails.Visible = true;
                    PnlYear.Visible = false;
                    btnSave.Visible = false;
                }
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    #region BindFyGd

    public DataTable BindGVFy()
    {
        DataTable dt = Yearmaster.GetFinancialYear();
        return dt;
    }

    #endregion

    #endregion

    #region Events

 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
         
            Yearmaster _objYm = new Yearmaster();
            _objYm.yearAutoId = Convert.ToInt32(lblID.Text);
            _objYm.FromYear = txtfrmyr.Text.Trim();
            _objYm.ToYear = txttoyr.Text.Trim();
            _objYm.IsActive = Chekacv.Checked;
            _objYm.Save();
            MessageBox("Record saved successfully");
            txtfrmyr.Text = "";
            txttoyr.Text = "";
        }
        catch
        {
        }

    }


    protected void grdyearDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlFinYearDetails.Visible = false;
        PnlYear.Visible = true;
        btnSave.Visible = true;
       
       
       try
        {
            lblID.Text = ((Label)grdyearDetails.Rows[e.NewEditIndex].FindControl("lblYearID")).Text;
            txtfrmyr.Text = ((Label)grdyearDetails.Rows[e.NewEditIndex].FindControl("lblfrmyr")).Text;
            txttoyr.Text = ((Label)grdyearDetails.Rows[e.NewEditIndex].FindControl("lbltoyr")).Text;
            Chekacv.Checked = ((CheckBox)grdyearDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        }
        catch
        {
        }
    }
    protected void grdyearDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdyearDetails.PageIndex = e.NewPageIndex;
        grdyearDetails.DataSource = BindGVFy();
        grdyearDetails.DataBind();
    }
    #endregion
}
