
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
#endregion


public partial class UserControls_uc_MenuesByRoleId : System.Web.UI.UserControl
{
    #region Methods

    private void BindMenuRepeter(int Roleid, int MenuLevel, int ParentId)
    {
        //string pagename = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();

        //if (pagename == "dashboard.aspx")
        //{
        //    RepGetMenu.DataSource = null;
        //    RepGetMenu.DataBind();
        //}
        //else
        //{
        try
        {
            DataSet ds = new DataSet();
            ds = Menumaster.getMenu_By_RoleId(Roleid, MenuLevel, ParentId);
            RepGetMenu.DataSource = ds.Tables[0];
            RepGetMenu.DataBind();
            if (RepGetMenu.Items.Count <= 0)
            {
                showmsg.Visible = true;
            }
            else
            {
                showmsg.Visible = false;
                HeadDetails.InnerHtml = ds.Tables[1].Rows[0][0].ToString().ToUpperInvariant();
            }
        }
        catch
        {


        }

        //}
    }





    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Session["MenuDetails"] != null && Session["Role"] != null)
            //{
            //    string a = Session["MenuDetails"].ToString();
            //    int MenuLevel = Convert.ToInt32(a.Split('~')[0].ToString());
            //    int ParentID = Convert.ToInt32(a.Split('~')[1].ToString());
            //    int Role = Convert.ToInt32(Session["Role"].ToString());
            //    BindMenuRepeter(Role, MenuLevel, ParentID);
            //}
            if (Session["MenuDetails"] != null && Session["Role"] != null)
            {
                if (txtId.Text != "")
                {
                    if (Session["MenuDetails"].ToString() != txtId.Text)
                    {
                        Session["MenuDetails"] = txtId.Text;
                        string a = txtId.Text.ToString();
                        int MenuLevel = Convert.ToInt32(a.Split('~')[0].ToString());
                        int ParentID = Convert.ToInt32(a.Split('~')[1].ToString());
                        int Role = Convert.ToInt32(Session["Role"].ToString());
                        BindMenuRepeter(Role, MenuLevel, ParentID);
                    }
                    else
                    {
                        string a = Session["MenuDetails"].ToString();
                        int MenuLevel = Convert.ToInt32(a.Split('~')[0].ToString());
                        int ParentID = Convert.ToInt32(a.Split('~')[1].ToString());
                        int Role = Convert.ToInt32(Session["Role"].ToString());
                        BindMenuRepeter(Role, MenuLevel, ParentID);
                    }
                }
                else 
                {
                    string a = Session["MenuDetails"].ToString();
                    int MenuLevel = Convert.ToInt32(a.Split('~')[0].ToString());
                    int ParentID = Convert.ToInt32(a.Split('~')[1].ToString());
                    int Role = Convert.ToInt32(Session["Role"].ToString());
                    BindMenuRepeter(Role, MenuLevel, ParentID);
                }
            }
            else
            {
                if (txtId.Text != "" && Session["Role"] != null)
                {
                    Session["MenuDetails"] = txtId.Text;
                    string a = txtId.Text.ToString();
                    int MenuLevel = Convert.ToInt32(a.Split('~')[0].ToString());
                    int ParentID = Convert.ToInt32(a.Split('~')[1].ToString());
                    int Role = Convert.ToInt32(Session["Role"].ToString());
                    BindMenuRepeter(Role, MenuLevel, ParentID);
                }
            }
            string jv = "$('#dash a').focus();";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "nnsc", jv, true);

        }
        catch
        {
            
            
        }
        
    }

    protected void RepGetMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label lblShort = (Label)e.Item.FindControl("lbllink");
            //string jv = "shortcut.add('" + lblShort.Text.Split('~')[1].ToString() + "',function() {window.location = '" + lblShort.Text.Split('~')[0].ToString() + "'});";
           // ScriptManager.RegisterStartupScript(upMenuRoleById, upMenuRoleById.GetType(), lblShort.Text.Split('~')[1].ToString(), jv, true);

        }
    }
    #endregion

}
