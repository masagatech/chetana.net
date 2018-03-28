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
using Idv.Chetana.Common;
public partial class UserControls_uc_TeamMembers : System.Web.UI.UserControl
{
    string EmpCode;
    string code;
    string id;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetView();
        if (!Page.IsPostBack)
        {

            lblCustName.Visible = false;
            Bind_DDL_TeamName();
            view();
            Bindgrid();
        }
        else
        {
            // panel4.Visible = true;
            // pnlArea.Visible = true;
        }
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Team Members ";
                //lblTMID.Text = "0";
                PnlCCDetails.Visible = true;
                Grdteammber.Visible = true;
                panel4.Visible = false;
                PnlAddCC.Visible = true;
                filter.Visible = false;
                lblCustName.Visible = false;
                DDLTeamName.Focus();
                Btnsave.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Team Members ";
                    PnlCCDetails.Visible = true;
                    PnlAddCC.Visible = false;
                    panel4.Visible = true;
                    Btnsave.Visible = false;
                    //view();

                }
        }
    }
    private void view()
    {

        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.DCMaster.Get_Name(EmpCode, "view");
        if (ds.Tables[0].Rows.Count > 0)
        {
           
            Grdteamview.DataSource = ds.Tables[0];
            Grdteamview.DataBind();
            Grdteamview.Visible = true;
            //Pnlteam.Visible = true;
           

        }
    }
    public void Bind_DDL_TeamName()
    {
        DDLTeamName.DataSource = TeamMaster.GetTeamMaster("adminCCM");
        DDLTeamName.DataBind();
        DDLTeamName.Items.Insert(0, new ListItem("---Select Team---", "none"));
    }
    private void Bindgrid()
    {

        EmpCode = txtTeamMember.Text.ToString().Split(':')[0].Trim();
        int i;
        ds = Idv.Chetana.BAL.DCMaster.Get_Name(EmpCode, "textchange");
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            lblEmpName.Text = ds.Tables[0].Rows[i]["name"].ToString();
            empid.Text = ds.Tables[0].Rows[i]["EmpCode"].ToString();
            Lblgrpcode.Text = ds.Tables[0].Rows[i]["key"].ToString();
            Pnlteam.Visible = true;
            Grdteammber.Visible = true;
            Btnsave.Visible = false;

        }
    
    }

    protected void txtTeamMember_TextChanged(object sender, EventArgs e)
    {
        Bindgrid();
    }
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        TeamMember _objDs2 = new TeamMember();
        for (int i = 0; i < Grdteammber.Rows.Count; i++)
        {
            Label lbl = (Label)Grdteammber.Rows[i].FindControl("lblempid");
            Label Employee = (Label)Grdteammber.Rows[i].FindControl("lbltdesc");
            id = lbl.Text;
            _objDs2.EmpID = id.ToString();
            _objDs2.TeamGrpID = Lblgrpcode.Text;
            _objDs2.TNAME = DDLTeamName.SelectedItem.Text;
            try
            {
                if (txtTeamMember.Text != "")
                {
                    _objDs2.CSave();
                }
                MessageBox("Record saved successfully");
            }
            catch
            {

            }
        }
    }

    protected void Grdteammber_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void Grdteammber_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Grdteamview_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TeamMember _objDs2 = new TeamMember();
        _objDs2.EmpID = ((Label)Grdteamview.Rows[e.RowIndex].FindControl("lblempid")).Text;
        _objDs2.TNAME = ((Label)Grdteamview.Rows[e.RowIndex].FindControl("lbltID")).Text;
        _objDs2.TMBID = Convert.ToInt32(((Label)Grdteamview.Rows[e.RowIndex].FindControl("TMemberId")).Text);

        _objDs2.CIsActive = Convert.ToBoolean(false);
        _objDs2.CIsDeleted = Convert.ToBoolean(true);
        try
        {
            _objDs2.CSave();
            MessageBox("Your record is Deleted");
            view();
           // Bindgrid();
        }
        catch
        {

        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        btn_Save.Visible = true;
        Pnlteam.Visible = true;
        ViewState["EmpCode"] = ViewState["EmpCode"] + "," + empid.Text + ",";
        DataTable ds = new DataTable();
        ds = DCMaster.Get_Name(Convert.ToString(ViewState["EmpCode"]), "GRIDADD").Tables[0];
        Grdteammber.DataSource = ds;
        Grdteammber.DataBind();
        Pnlteam.Visible = false;
        panel4.Visible = true;
        Btnsave.Visible = true;
        Grdteamview.Visible = false;
    }
}