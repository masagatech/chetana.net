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

public partial class User_Control_us_FacultyDetails : System.Web.UI.UserControl
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
            lblsdzselect.Visible = true;
            lblsdzselect.Text ="Selected : "+ ddlSDZone.SelectedItem.Text.ToString();

            setddl(Session["zoneLevel"].ToString(), Session["zoneId"].ToString());
        }
    }
       

    #region Save Button

    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        _FacultyMaster _fclt = new _FacultyMaster();
        
        _fclt.Fct_ID= Convert.ToInt32(lblfacultyid.Text.Trim());
        _fclt.Name = txtaddname.Text.Trim();
        _fclt.Schl_Name = txtaddschool.Text.Trim();
        _fclt.Res_Add = txtaddaddress.Text.Trim();
        _fclt.Pincode = txtaddpincode.Text.Trim();
        _fclt.Contact = txtaddcontact.Text.Trim();
        _fclt.Res_No = txtaddresno.Text.Trim();
        _fclt.Qualification = txtaddqual.Text.Trim();
        _fclt.Tch_Exp = txtaddtchexp.Text.Trim();
        _fclt.Spec_Sub = txtaddsplsub.Text.Trim();
        _fclt.Sub_Intrs_Wrt = txtaddints.Text.Trim();
        //_fclt.Prvs_Exp_Wrt = Convert.ToBoolean(rdoyesno.Text.Trim());
        if(rdoyesno.Items[0].Selected ==true)
        {
            _fclt.Prvs_Exp_Wrt = "yes";
        }
        else if (rdoyesno.Items[1].Selected == true)
        {
            _fclt.Prvs_Exp_Wrt = "No";
        }

        _fclt.Pls_Mnt_bk_Pub = txtaddplsbooks.Text.Trim();
        _fclt.SDZ = Convert.ToInt32(ddlSDZone.SelectedValue.ToString());
        _fclt.SZ = Convert.ToInt32(DDLSuperZone.SelectedValue.ToString());
        _fclt.Z = Convert.ToInt32(DDLZone.SelectedValue.ToString());
        _fclt.Fy= Convert.ToInt32(strFY);

        try
        {
            
            _fclt.Save();
            MessageBox("Data Saved Successfully.");
            Clear();
        }
        catch
        { throw; }

    }
    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion


    public void Clear()
    {
        txtaddname.Text="";
        txtaddschool.Text = "";
        txtaddaddress.Text = "";
        txtaddpincode.Text = "";
        txtaddcontact.Text = "";
        txtaddresno.Text = "";
        txtaddqual.Text = "";
        txtaddtchexp.Text = "";
        txtaddsplsub.Text = "";
        txtaddints.Text = "";
        txtaddplsbooks.Text = "";
        txtRemarks.Text = "";
        rdoyesno.Items[0].Selected = false;
        rdoyesno.Items[1].Selected = true;
        DDLZone.SelectedIndex = 0;
       // lblszselect.Visible=false;
        //lblzselect.Visible = false;


    }


    protected void btnclear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void txtaddname_TextChanged(object sender, EventArgs e)
    {
        txtaddname.Focus();
    }

    #region ddl dind methods

    public void Bind_DDL_SuperZone()
    {
        //DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        //DDLSuperZone.DataBind();
        //DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
        //DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));

        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        //DDLSuperZone.Focus();
    }

    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
    }

    #endregion

    #region ddlSDZone index changed

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");
            lblsdzselect.Visible = true;
            lblsdzselect.Text = "Selected : " + ddlSDZone.SelectedItem.Text.ToString();
            DDLSuperZone.Items.Clear();
            DDLSuperZone.Items.Insert(0, new ListItem("-Select Super Zone-", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {

            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("-- Select SuperZone --", "0"));
            DDLSuperZone.Focus();
            //lblsdzselect.Visible = true;
            lblsdzselect.Text = "Selected : " + ddlSDZone.SelectedItem.Text.ToString();
        }
    }

    #endregion

    #region SuperZone index change

    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            //lblszselect.Visible = false;
            DDLZone.Items.Clear();
            DDLZone.Items.Insert(0, new ListItem("--Select Zone--", "0"));
            lblsdzselect.Text = "Selected : " + ddlSDZone.SelectedItem.Text.ToString();
        }
        else
        {
            Bind_DDL_Zone();
            //lblszselect.Visible = true;
            lblsdzselect.Text = "Selected : " + ddlSDZone.SelectedItem.Text.ToString() +" : "+ DDLSuperZone.SelectedItem.Text.ToString();
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
            //lblzselect.Visible = false;
            DDLZone.Focus();
            lblsdzselect.Text = "Selected : " + ddlSDZone.SelectedItem.Text.ToString() + " : " + DDLSuperZone.SelectedItem.Text.ToString();
            //  DDLZone.SelectedValue = null;
        }
        else
        {
           // lblzselect.Visible = true;
            lblsdzselect.Text = "Selected : " + ddlSDZone.SelectedItem.Text.ToString() + " : " + DDLSuperZone.SelectedItem.Text.ToString()+" : " + DDLZone.SelectedItem.Text.ToString();
            txtaddname.Focus();
        }
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

}
