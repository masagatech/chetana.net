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

public partial class UserControls_uc_New_Header : System.Web.UI.UserControl
{

    #region Variables

    public int Level = 0;

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserName"] != null)
            {
            }
            else
            {
                Response.Redirect("_auth.aspx");
            }

            FillHeadMenu();
            ShowLoginLog();
            
        }
        setTitle();
    }


    #endregion

    #region Method

    private void FillHeadMenu()
    {

        LblUserName.Text = Session["UserName"].ToString();
        RepMenuHead.DataSource = MenuHead.Get_All_Active_Menu_Head();
        RepMenuHead.DataBind();


    }

    #endregion

    protected void RepMenuHead_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Label lbl = (Label)e.Item.FindControl("spnMHID");
        Repeater rept = (Repeater)e.Item.FindControl("RepMenuMain");
        rept.DataSource = MainMenu.Get_Main_Menu_By_MenuHead_ID(Convert.ToInt32(lbl.Text.Trim()));
        rept.DataBind();

    }

    protected void RepMenuMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblMainMenuid = (Label)e.Item.FindControl("lblmainmenuid");
        Repeater rept = (Repeater)e.Item.FindControl("RepSubMenu");
        DataSet ds = Menusub.Get_Sub_Menu_By_MainMenu_ID(Convert.ToInt32(lblMainMenuid.Text.Trim()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            rept.DataSource = ds;
            rept.DataBind();
        }
    }

    #region Level Vice Menu

    protected void LnkLevel3Menu_Click(object sender, EventArgs e)
    {

        Level = 3;
        string Id = ((LinkButton)(sender)).CommandArgument.ToString();
        Session["MenuDetails"] = Level + "~" + Id;
        string jv = "dopost();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "as", jv, true);

    }

    protected void LnkLevel2Menu_Click(object sender, EventArgs e)
    {
        string jv = "";
        Level = 2;
        string Id = ((LinkButton)(sender)).CommandArgument.ToString();
        if (((LinkButton)(sender)).Text.ToLower() == "developed by")
        {
            jv = "alert('iDivergence\\r\\n www.idivergence.in')";
        }
        else
            if (((LinkButton)(sender)).Text.ToLower() == "version")
            {
                jv = "alert('version: 1.0')";
            }
            else
            {

                Session["MenuDetails"] = Level + "~" + Id;
                jv = "dopost();";

            }
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "as", jv, true);
    }

    #endregion

    protected void LnkLogOut_Click(object sender, EventArgs e)
    {

        Session["UserName"] = null;
        Session["Role"] = null;
        Session["MenuDetails"] = null;
        if (Session["LoginId"] != null)
        {
            SetLogoutTime(Convert.ToInt32(Session["LoginId"].ToString()));
        }
        Session["LoginId"] = null;
        Session.Clear();

        Response.Redirect("_auth.aspx");
    }

    #region Login Log Insert

    private void SetLogoutTime(int Id)
    {
        int outpar = 0;
        LoginLog objLoginLog = new LoginLog();
        objLoginLog.LoginLogId = Id;
        objLoginLog.LoggOutTime = DateTime.Now;
        objLoginLog.ResonToLoggOut = "Sucssessfully LogOut";
        objLoginLog.Save(out outpar);


    }
    #endregion

    #region Get Login Log Details
    public void ShowLoginLog()
    {
        DataTable dt = new DataTable();

        dt = LoginLog.getLoginLogDetails(Session["UserName"].ToString());
        loginTime.InnerHtml = dt.Rows[0]["LoginTime"].ToString();
        //ipAddress.InnerHtml = dt.Rows[0]["ipAddress"].ToString();
        if(Session["FY_Text"].ToString() != "" && Session["FY_Text"].ToString() !="")
        {FP.InnerHtml = Session["FY_Text"].ToString();
            spnYear.InnerHtml = Session["FY_Text"].ToString().Split('-')[0];
	      int currentyear = DateTime.Now.Year;
            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3)
            {
                currentyear = currentyear - 1;
            }
            if (currentyear.ToString() != Session["FY_Text"].ToString().Split('-')[0])
            {
                FP.Style["background-color"] = "red";
                FP.Attributes.Add("title", "You are not logged in current financial. current financial is : " + currentyear.ToString() + "-" + (currentyear + 1).ToString());
            }   

        }
    }
    #endregion

    #region Javascript Window Title

    public void setTitle()
    {
       // string jv = "document.title = document.title + ' [" + Session["UserName"].ToString() + "]'";
        //ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"sds",jv,true);
    
    }

    #endregion
}
