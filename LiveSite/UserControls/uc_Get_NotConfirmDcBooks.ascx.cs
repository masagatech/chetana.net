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

public partial class UserControls_uc_Get_NotConfirmDcBooks : System.Web.UI.UserControl
{

    static int quantity = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillGridData();
        }
    }

    #region Methods

    public void fillGridData()
    {

        grdGetNotConfirmedBooks.DataSource = SpecimanDetails.Get_Specimen_NotConfirmed_Books();
        grdGetNotConfirmedBooks.DataBind();
    }


    #endregion

    #region Events

    protected void btnBookWice_Click(object sender, EventArgs e)
    {
        Response.Redirect("Confirm_DC.aspx?cmode=b");
    }
    protected void btnDocWice_Click(object sender, EventArgs e)
    {
        Response.Redirect("Confirm_DC.aspx?cmode=d");
    }

    #endregion

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintPendingDC.aspx?d=b')", true);
        }
        catch { }
    }
    protected void grdGetNotConfirmedBooks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblqunty");
            quantity = quantity + Convert.ToInt32(lbl.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalQty");
            lbl1.Text = quantity.ToString().Trim();
        } 
    }
}
