#region NameSpaces

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
using System.Threading;

#endregion

public partial class UserControls_RoleMapping : System.Web.UI.UserControl
{
    #region Variables

    public static int countCol = 0;

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            DataView dv = new DataView(Rolemaster.Get_RoleMaster().Tables[0]);
            dv.RowFilter = "Isactive = 1";
            ddlrole.DataSource = dv;
            ddlrole.DataBind();
            ddlrole.Items.Insert(0, new ListItem("--Select Role--", "0"));
            ddlrole.Focus();
        }
    }
    #endregion

    #region Methods

    #region Bind Grid with menu master

    public void BindDataForMenus()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("MenuName");
        foreach (DataRow row in Rolemaster.Get_RoleMaster().Tables[0].Rows)
        {
            dt.Columns.Add(row[1].ToString());

        }
        int aa = 0;
        string a = "";
        foreach (DataRow row in Menumaster.Get_MenuMaster().Tables[0].Rows)
        {
            dt.Rows.Add(row[1]);

        }

        grdMenuRoleMapping.DataSource = dt;
        grdMenuRoleMapping.DataBind();
        DynamicControls(((System.Data.InternalDataCollectionBase)(dt.Columns)).Count);
    }

    #endregion

    #endregion

    protected void btnsave_Click(object sender, EventArgs e)
    {  
        try
        {
            //    //    Mappings _objM = new Mappings();
            //    //    _objM.AutoId = 0;
            //    //    _objM.RoleId = 0;
            //    //    _objM.MenuId = 0;
            //    //    _objM.Save();
            Save_Data();
        }

        catch
        {

        }
    }
    protected void grdMenuRoleMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (GetButton(e.Row) == null)
            {
                //  e.Row.Controls.Add(CreateButton(e.Row));
            }

        }
    }

    private CheckBox CreateButton(GridViewRow row)
    {
        CheckBox button = new CheckBox();
        button.Text = "Dynamic Button";
        button.ID = "DynamicallyCreatedButton_" + row.RowIndex;
        // button.Click += new EventHandler(button_Click);
        return button;
    }
    protected void button_Click(object sender, EventArgs e)
    {
        //Label1.Text = "Text set from dynamic button Click event";
    }
    private CheckBox GetButton(GridViewRow row)
    {
        return row.Cells[0].FindControl("DynamicallyCreatedButton_" + row.RowIndex) as CheckBox;
    }
    protected void grdMenuRoleMapping_DataBound(object sender, EventArgs e)
    {

    }
    public void DynamicControls(int count)
    {
        for (int i = 1; i < count; i++)
        {
            foreach (GridViewRow row in grdMenuRoleMapping.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    row.Cells[i].Controls.Add(CreateButton(row));

                }
            }
        }
    }
    #region Methods

    public void Save_Data()
    {
        Mappings _objmapping = new Mappings();

        foreach (DataListItem item in RepGroup.Items)
        {
            GridView Grdmenurole = (GridView)item.FindControl("Grdmenurole");

            foreach (GridViewRow Rows in Grdmenurole.Rows)
            {
                Label lblmenuId = (Label)Rows.FindControl("lblMID");
                CheckBox chekshow = (CheckBox)Rows.FindControl("Chekshow");
                CheckBox chekall = (CheckBox)Rows.FindControl("Chekall");
                CheckBox chekview = (CheckBox)Rows.FindControl("chekview");
                CheckBox cheksave = (CheckBox)Rows.FindControl("Cheksave");
                CheckBox chekedit = (CheckBox)Rows.FindControl("Chekedit");
                CheckBox chekdelete = (CheckBox)Rows.FindControl("Chekdelete");
                _objmapping.UserMenuMappId = Convert.ToInt32(lblmenuId.Text);
                if (chekall.Checked == true)
                {
                    _objmapping.View = true;
                    _objmapping.Add = true;
                    _objmapping.Edit = true;
                    _objmapping.Delete = true;
                    _objmapping.Show = true;

                }
                else
                {
                    //_objmapping.View = chekview.Checked;
                    //_objmapping.Add = cheksave.Checked;
                    //_objmapping.Edit = chekedit.Checked;

                    //_objmapping.Delete = chekdelete.Checked;
                    _objmapping.View = true;
                    _objmapping.Add = true;
                    _objmapping.Edit = true;
                    _objmapping.Delete = true;

                    _objmapping.Show = chekshow.Checked;

                }

                _objmapping.SaveMenu();
            }
        }
        MessageBox("Saved Successfully!");
    }
    #endregion

    #region Metnods

    private void BindMenuUserMapping(int RoleId)
    {
        // Grdmenurole.DataSource = Mappings.Get_MenuUsermapping(RoleId);
        // Grdmenurole.DataBind();
    }
    #endregion

    protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
    {
        RepGroup.DataSource = Mappings.Get_MenudisplayAndRole(Convert.ToInt32(ddlrole.SelectedValue)).Tables[1];
        RepGroup.DataBind();


    }
    protected void RepGroup_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lbl = (Label)e.Item.FindControl("lblGroupName");
        GridView Grdmenurole = (GridView)e.Item.FindControl("Grdmenurole");
        DataView dv = new DataView(Mappings.Get_MenudisplayAndRole(Convert.ToInt32(ddlrole.SelectedValue)).Tables[0]);
        dv.RowFilter = "groupname = '" + lbl.Text.Trim() + "'";
        Grdmenurole.DataSource = dv;
        Grdmenurole.DataBind();
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", jv, true);
    }
    #endregion
}