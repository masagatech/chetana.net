using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using Idv.Chetana.BAL;

public partial class HelpdeskDashBoard : System.Web.UI.Page
{
    Other_Z.InquiryDetail eq = new Other_Z.InquiryDetail();
    Other_Z.OtherBAL ObjDAL = new Other_Z.OtherBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            filldgrid();
            BindDLDashboard();
        }
    }
    #region Binddata method

    public void BindDLDashboard()
    {
        DLDashboard1.DataSource = ObjDAL.GetDashboardhelpdesk("status");
        DLDashboard1.DataBind();
        DLDashboard2.DataSource = ObjDAL.GetDashboardhelpdesk2("Severity");
        DLDashboard2.DataBind();
    }
    #endregion
    public void filldgrid()
    {
        grdEnquires.DataSource = ObjDAL.GetDashboardgrid("pending");
        DataTable DT = ObjDAL.GetDashboardgrid("pending").Tables[0];
        DataView DV = new DataView(DT);
        DataTable DTT = DV.ToTable(true, "TktNumber");
        grdEnquires.DataBind();
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        LinkButton LnkSeletedRow = sender as LinkButton;

        if (LnkSeletedRow != null)
        {
            GridViewRow grv = LnkSeletedRow.NamingContainer as GridViewRow;
            if (grv != null)
            {
                Label tktNumber = (Label)grv.FindControl("lbltktnoTktNumber");
                eq.TktNumber = tktNumber.Text;
                DataSet DSR = ObjDAL.GetDashboardRemarks(eq.TktNumber);
                if (DSR.Tables[0].Rows.Count > 0)
                {
                    popGridview.DataSource = DSR;
                    popGridview.DataBind();
                    popGridview.Visible = true;
                    popGridview.DataBind();
                    ModalPopupExtender2.Show();
                    UpdatePanel15.Update();

                }
                else
                {
                    string display = "Remarks is Not Found...";
                    ScriptManager.RegisterStartupScript(UpdatePanel15, UpdatePanel15.GetType(), "popup", "alert('" + display + "');", true);
                }
            }
        }
    }
    protected void grdEnquires_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEnquires.PageIndex = e.NewPageIndex;
        BindDLDashboard();

    }

    protected void grdEnquires_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            e.Row.TabIndex = -1;
            e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
            e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
            e.Row.Attributes["onselectstart"] = "javascript:return false;";
        }
    }
    protected void grdEnquires_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label myHyperLink = e.Row.FindControl("lbltktnoTktNumber") as Label;
            Session["Scarpio"] = myHyperLink.Text;
        }
    }
    protected void grdEnquires_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        grdEnquires.PageIndex = e.NewPageIndex;
        filldgrid();
    }
}