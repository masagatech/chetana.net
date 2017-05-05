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

public partial class Print_PrintPendingDC : System.Web.UI.Page
{
    #region Variables
    static int quantity = 0;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["d"] == "b")
        {

            grdpending.DataSource = SpecimanDetails.Get_Specimen_NotConfirmed_Books();
            grdpending.DataBind();
        }
        else if (Request.QueryString["d"] != null)
        {
            DataSet ds = new DataSet();
            ds = SpecimanDetails.Idv_Get_SpecimenDetails_By_DocNo(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()),"allbydocno");
            DataView dv = new DataView(ds.Tables[0]);
            DocumentNo.InnerHtml = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
            Todaydate.InnerHtml = DateTime.Now.ToString("dd/MM/yyyy");
            MRname.InnerHtml = ds.Tables[1].Rows[0]["Name"].ToString();
            spnaddress.InnerHtml = ds.Tables[1].Rows[0]["Address"].ToString();
            spinstruction.InnerHtml =  ds.Tables[1].Rows[0]["SpInstruction"].ToString();
            Description.InnerHtml =  ds.Tables[1].Rows[0]["Description"].ToString();
            grdpending.DataSource = dv;
            grdpending.DataBind();
        }
    }
    protected void grdpending_RowDataBound(object sender, GridViewRowEventArgs e)
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
