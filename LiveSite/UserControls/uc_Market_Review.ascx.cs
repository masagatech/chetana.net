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

public partial class UserControls_uc_Market_Reviewl : System.Web.UI.UserControl
{

    #region Variables

    string strChetanaCompanyName = "cppl";
    string strFY;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!Page.IsPostBack)
        {

           
            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();
            
            setddl(Session["zoneLevel"].ToString(), Session["zoneId"].ToString());
        }
    }

    #region ddlSDZone index changed

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("--Select Super Zone--", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {

            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("--Select SuperZone--", "0"));
            DDLSuperZone.Focus();
        }
    }

    #endregion

    #region SuperZone index change

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }

    #endregion

    #region Zone index change

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            DDLZone.Focus();

            //  DDLZone.SelectedValue = null;
        }
        else
        {
            txtmarketreview.Focus();
        }

    }

    #endregion

    #region ddl dind methods

    public void Bind_DDL_SuperZone()
    {
        //DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        //DDLSuperZone.DataBind();
        //DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        //DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));

        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("--Select SuperZone--", "0"));
        DDLZone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
        //DDLSuperZone.Focus();
    }

    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
    }

    #endregion


    #region enabled ddl

    public void setddl(string level, string ids)
    {
        try
        {
            SetDDLVisibility _obj = new SetDDLVisibility();
            _obj.fillProp(level, ids);
            ddlSDZone.Enabled = _obj.DdlSDZone;
            ddlSDZone.SelectedValue = _obj.DDlSdzIDValue.ToString();
            Bind_DDL_SuperZone();
            DDLSuperZone.Enabled = _obj.DdlSZone;
            DDLSuperZone.SelectedValue = _obj.DDlSzIDValue.ToString();
            Bind_DDL_Zone();
            DDLZone.SelectedValue = _obj.DDlZIDValue.ToString();
            DDLZone.Enabled = _obj.DdlZone;
            //DDLZone.Focus();

        }
        catch 
        {


        }
    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txtmarketreview.Text != "" && txtmarketreview.Text != null) || (txtcompreview.Text != "" && txtcompreview.Text != null))
            {
                Market_Review _objMarView = new Market_Review();
                _objMarView.Super_Duper_Zone = ddlSDZone.SelectedValue.ToString();
                _objMarView.Super_Zone = DDLSuperZone.SelectedValue.ToString();
                _objMarView.Zone = DDLZone.SelectedValue.ToString();
                _objMarView.Market_View = txtmarketreview.Text.Trim();
                _objMarView.Competitor_View = txtcompreview.Text.Trim();
                _objMarView.Fyfrom = Convert.ToInt32(strFY);

                _objMarView.Save();

                MessageBox("Data Saved Successfully.");
                Clear();
            }
            else
            {
                MessageBox("Either Market Review or Competitor Review is Required!!!");
            }
        }
        catch 
        {


        }

    }

    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Market_View.aspx");
    //}

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion

    #region Clear

    public void Clear()
    {
        ddlSDZone.SelectedIndex = 0;
        DDLSuperZone.SelectedIndex = 0;
        DDLZone.SelectedIndex = 0;
        txtmarketreview.Text = "";
        txtcompreview.Text = "";
    }

    #endregion

}
