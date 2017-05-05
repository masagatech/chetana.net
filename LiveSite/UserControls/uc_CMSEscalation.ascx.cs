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
using Other_Z;

public partial class UserControls_CMSEscalation : System.Web.UI.UserControl
{
    #region Goloval Veriable
    Other_Z.InquiryDetail eq = new Other_Z.InquiryDetail();
    Other_Z.OtherBAL ObjDAL = new Other_Z.OtherBAL();
    string flag = "";
    string StrFY = "";
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["For"] != null)
        {
            if (!Page.IsPostBack)
            {
                if (Session["FY"] != null)
                {
                    StrFY = Session["FY"].ToString();
                    //BindDLDashboard();
                    Session["FillGrid"] = null;
                    txtFromDate.Text = "01/04/201"+StrFY;
                    txtTodate.Text = "31/03/201" + Convert.ToInt32(Convert.ToInt32(StrFY) + 1);

                }
            }
        }
    }
    #endregion

   #region Binddata method
    public void BindDLDashboard(DateTime Fromdate,DateTime Todate)
    {
        if (Request.QueryString["For"] == "g")
        {
            //Table Not Found FY But Send Not Use
            DataSet ds = ObjDAL.Get_Pending_Godown("godown", Convert.ToInt32(Session["FY"]),Fromdate,Todate,"","");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DLDashboard1.DataSource = ds.Tables[0];
                DLDashboard1.DataBind();
                DLDashboard1.Visible = true;
                PnlAdd.Visible = false;
            }
            else
            {
                Message("Record not found");
                txtFromDate.Focus();
                return;
            }
        }
        else
        {
            //Table Not Found FY But Send Not Use FY
            DataSet ds1 = ObjDAL.Get_Pending_Godown("billing", Convert.ToInt32(Session["FY"]), Fromdate, Todate, "", "");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DLDashboard1.DataSource = ds1.Tables[0];
                DLDashboard1.DataBind();
                DLDashboard1.Visible = true;
                PnlAdd.Visible=false;
            }
            else
            {
                Message("Record not found");
                txtFromDate.Focus();

                DLDashboard1.Visible = false;
                return;
            }
        }
    }
    #endregion

    #region Grid View Fill Method
    public void filldgrid(string Flag)
    {
        string Fromdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string ToDate = txtTodate.Text.Split('/')[1] + "/" + txtTodate.Text.Split('/')[0] + "/" + txtTodate.Text.Split('/')[2];
        DataTable dt = ObjDAL.Idv_Chetana_Help_PendingCompleted(Flag,Fromdate, ToDate, "", "", "").Tables[0];
        if (dt.Rows.Count > 0)
        {
            grdGodown.DataSource = dt;
            grdGodown.DataBind();
            PnlAdd.Visible = true;
        }
        else
        {
            Message("Record not found");
            PnlAdd.Visible = false;
            return;
        }
    }
    #endregion

    #region GetButton Click Event
    protected void btnGet_click(object sender, EventArgs e)
    {
        string Fromdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string ToDate = txtTodate.Text.Split('/')[1] + "/" + txtTodate.Text.Split('/')[0] + "/" + txtTodate.Text.Split('/')[2];
        BindDLDashboard(Convert.ToDateTime(Fromdate), Convert.ToDateTime(ToDate));

    }
    #endregion

    #region Grid View Page Index Change Event
    protected void grdEnquires_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["FillGrid"] != null)
        {
            grdGodown.PageIndex = e.NewPageIndex;
            filldgrid(Session["FillGrid"].ToString());
        }
    }
    #endregion

    #region View Link Click Event
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
    #endregion

    #region Message Method
    private void Message(string Msg)
    {
        string Javascrip = "alert('" + Msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", Javascrip, true);
    }
    #endregion

    #region Update Remark
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["For"] != null)
        {

            ImageButton btn = ((ImageButton)sender);
            int TktId = Convert.ToInt32(((Label)btn.Parent.FindControl("lblTktId")).Text.ToString());
            string RemarkText = ((TextBox)btn.Parent.FindControl("txtRemark")).Text.ToString();
            string TicketNo = ((Label)btn.Parent.FindControl("lbltktnoTktNumber")).Text.ToString();
            ObjDAL.Idv_Chetana_Update_HelpDesk_Godown(RemarkText, TktId, 0, "update", "", "", "", "", "");
            Message("Record Update Ticket No " + TicketNo);
            filldgrid(Session["FillGrid"].ToString());

            string Fromdate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
            string ToDate = txtTodate.Text.Split('/')[1] + "/" + txtTodate.Text.Split('/')[0] + "/" + txtTodate.Text.Split('/')[2];
            BindDLDashboard(Convert.ToDateTime(Fromdate), Convert.ToDateTime(ToDate));
            
        }
    }
    #endregion

    #region LinkButton Click Event
    protected void btnlink_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["FillGrid"] = null;
        if (Request.QueryString["For"] != null)
        {
            if (Request.QueryString["For"] == "g")
            {
                if (btn.Text == "Pending")
                {
                    filldgrid("pendinggodown");
                    pnlEmployeeDetails.GroupingText = "Recent Open Godown Enquiries (Pending)";
                    Session["FillGrid"] = "pendinggodown";
                }
                else
                {
                    filldgrid("Completedgodown");
                    pnlEmployeeDetails.GroupingText = "Recent Open Godown Enquiries (Completed)";
                    Session["FillGrid"] = "Completedgodown";
                }
            }
            else
            {
                if (btn.Text == "Pending")
                {
                    filldgrid("pendingbilling");
                    pnlEmployeeDetails.GroupingText = "Recent Open Billing Enquiries (Pending)";
                    Session["FillGrid"] = "pendingbilling";
                }
                else
                {
                    filldgrid("Completedbilling");
                    pnlEmployeeDetails.GroupingText = "Recent Open Billing Enquiries (Completed)";
                    Session["FillGrid"] = "Completedbilling";
                }
            }
        }
    }
    #endregion

}
