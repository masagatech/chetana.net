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

public partial class UserControls_myMenu_keybordmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RepMenuHead.DataSource = MenuHead.Get_All_Active_Menu_Head();
        RepMenuHead.DataBind();

    }
    protected void RepMenuHead_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label lbl = (Label)e.Item.FindControl("spnMHID");
            Repeater rept = (Repeater)e.Item.FindControl("RepMenuMain");
            rept.DataSource = MainMenu.Get_Main_Menu_By_MenuHead_ID(Convert.ToInt32(lbl.Text.Trim()));
            rept.DataBind();
        }
    }

   protected void RepMenuMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label lblMainMenuid = (Label)e.Item.FindControl("lblmainmenuid");
            Repeater rept = (Repeater)e.Item.FindControl("RepSubMenu");
            rept.DataSource = Menusub.Get_Sub_Menu_By_MainMenu_ID(Convert.ToInt32(lblMainMenuid.Text.Trim()));
            rept.DataBind();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        string value = TextBox1.Text;
        Session["MenuDetails"] = value.Split('~')[0] + "~" + value.Split('~')[1];
        string jv = "dopost();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "as", jv, true);
    }
}
