﻿using System;
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

public partial class UserControls_uc_FacultyApprovs : System.Web.UI.UserControl
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
        DDLZone.Items.Insert(0, new ListItem("--All--", "0"));
        //DDLSuperZone.Focus();
    }

    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("--All--", "0"));
    }

    #endregion

    #region ddlSDZone index changed

    protected void ddlSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSDZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");

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
            DDLZone.Items.Insert(0, new ListItem("--All--", "0"));
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

    #region Get Details

    protected void btnGet_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (DDLSuperZone.SelectedIndex != 0 && DDLZone.SelectedIndex != 0)
        {
            ds = _FacultyMaster.Get_FacultyApproval("approve", "z", ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), DDLZone.SelectedValue.ToString(), Convert.ToInt32(strFY));

        }
        else if (DDLSuperZone.SelectedIndex != 0 && DDLZone.SelectedIndex == 0)
        {
            ds = _FacultyMaster.Get_FacultyApproval("approve", "sz", ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), "", Convert.ToInt32(strFY));
        }
        else
        {
            ds = _FacultyMaster.Get_FacultyApproval("approve", "sdz", ddlSDZone.SelectedValue.ToString(), "", "", Convert.ToInt32(strFY));
        }

        btnApprove.Visible = true;
        btndisapprove.Visible = true;
        Pnlfacultyapproves.Visible = true;
        grdfacultyapproves.DataSource = ds.Tables[0];
        grdfacultyapproves.DataBind();

    }
    #endregion

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string value = getString();
        _FacultyMaster _obj = new _FacultyMaster();

        if (value == "0")
        {
             _obj.Name =value;
        }
        else
        {
            _obj.Name = value;
        }
        _obj.Update();
        btnGet_Click(null, null);
    }

    protected void btndisapprove_Click(object sender, EventArgs e)
    {
        string value = getString();
        _FacultyMaster _obj = new _FacultyMaster();

        if (value == "0")
        {
            _obj.Name = value;
        }
        else
        {
            _obj.Name = value;
        }
        _obj.Reject();
        btnGet_Click(null, null);
    }

    

    public string getString()
    {
        string factid = string.Empty;

        CheckBox chkAll =
       (CheckBox)grdfacultyapproves.HeaderRow.FindControl("chkSelectAll");
        if (chkAll.Checked == true)
        {

            factid = "0";
        }
        else
        {
            foreach (GridViewRow row in grdfacultyapproves.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkselect");
                if (check.Checked == true)
                {
                    Label lblfact = (Label)row.FindControl("lbltid");
                    factid = factid + (lblfact.Text) + ",";
                }

            }
        }
        return factid;

    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll =
        (CheckBox)grdfacultyapproves.HeaderRow.FindControl("chkSelectAll");
        if (chkAll.Checked == true)
        {
            foreach (GridViewRow gvRow in grdfacultyapproves.Rows)
            {
                CheckBox chkSel = (CheckBox)gvRow.FindControl("chkSelect");
                chkSel.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow gvRow in grdfacultyapproves.Rows)
            {
                CheckBox chkSel = (CheckBox)gvRow.FindControl("chkSelect");
                chkSel.Checked = false;
            }
        }
    }


}
