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

public partial class View_Month_Target : System.Web.UI.UserControl
{
    #region Variables

    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;
    DataTable dt;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!IsPostBack)
        {
            GetSuperZone();
         //   GetDDLMonth();
            DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));

        }
    }

    public void GetSuperZone()
    {
        ddlsuperzoneid.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone"); 
        ddlsuperzoneid.DataTextField = "SuperZoneName";
        ddlsuperzoneid.DataValueField = "SuperZoneID";
        ddlsuperzoneid.DataBind();
        ddlsuperzoneid.Items.Insert(0,new ListItem("---Select SuperZone---","0"));
        ddlsuperzoneid.Focus();
    }

    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlsuperzoneid.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        DDLZone.Focus();
        DDLZone.TabIndex = 2;
    }

    //public void GetDDLMonth()
    //{
    //    DataTable dtmonth = GetMonth();
    //    ddlmonth.DataSource = dtmonth;
    //    ddlmonth.DataTextField = "Month";
    //    ddlmonth.DataValueField = "MonthID";
    //    ddlmonth.DataBind();
    //    ddlmonth.Items.Insert(0, new ListItem("--Select Month----","0"));
    //}

    public DataTable GetMonth()
    {
        dt = new DataTable();

        dt.Columns.Add("MonthName");
        dt.Columns.Add("monthno");
        dt.Columns.Add("TargetPercent");
        dt.Columns.Add("TargetAmt");


        dt.Rows.Add("Apr", "4", "0", "0");
        dt.Rows.Add("May", "5", "0", "0");
        dt.Rows.Add("Jun", "6", "0", "0");
        dt.Rows.Add("Jul", "7", "0", "0");
        dt.Rows.Add("Aug", "8", "0", "0");
        dt.Rows.Add("Sep", "9", "0", "0");
        dt.Rows.Add("Oct", "10", "0", "0");
        dt.Rows.Add("Nov", "11", "0", "0");
        dt.Rows.Add("Dec", "12", "0", "0");
        dt.Rows.Add("Jan", "1", "0", "0");
        dt.Rows.Add("Feb", "2", "0", "0");
        dt.Rows.Add("Mar", "3", "0", "0");

        return dt;
    }
    protected void ddlsuperzoneid_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DDL_Zone();
        
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        btnUpdate.Visible = false;

        foreach (GridViewRow row in grdTarget.Rows)
        {
            TextBox txtpercent = (TextBox)row.FindControl("txtTarget");
            txtpercent.Enabled = true;
            TextBox txtTargetAmt = (TextBox)row.FindControl("txtTargetAmt");
            txtTargetAmt.Enabled = true;
             txtpercent.Focus();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (DDLZone.SelectedValue.ToString() != "0")
        {
            Month_Target _objMonth = new Month_Target();
            TextBox txtpercent;
            foreach (GridViewRow row in grdTarget.Rows)
            {
                _objMonth.AutoID = 0;
                _objMonth.SuperZoneID = Convert.ToInt32(ddlsuperzoneid.SelectedValue.ToString());
                _objMonth.MonthName = ((Label)row.FindControl("lblMonth")).Text;

                txtpercent = (TextBox)row.FindControl("txtTarget");
                txtpercent.Enabled = false;
                if (((TextBox)row.FindControl("txtTarget")).Text != "")
                {
                    _objMonth.TargetPercent = Convert.ToDecimal(((TextBox)row.FindControl("txtTarget")).Text);
                }
                else
                {
                    _objMonth.TargetPercent = 0;
                }
                _objMonth.FY = Convert.ToInt32(strFY);
                _objMonth.IsActive = true;
                _objMonth.IsDelete = false;
                _objMonth.CreatedBy = UserName;
                _objMonth.Remark1 = DDLZone.SelectedValue.ToString();
                _objMonth.Remark2 = "";
                _objMonth.Remark3 = "";
                _objMonth.Remark4 = "";
                _objMonth.Remark5 = "";
                if (((TextBox)row.FindControl("txtTargetAmt")).Text != "")
                {
                    _objMonth.TargetAmount = Convert.ToDecimal(((TextBox)row.FindControl("txtTargetAmt")).Text);

                }
                else
                {
                    _objMonth.TargetAmount = 0;
                }
                _objMonth.Save();
                Message("Data Updated Successfully");

            }

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        else
        {
            Message("Select Zone ");
        }
    }

    public void Message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        if (ddlsuperzoneid.SelectedIndex == 0)
        {
            pnlradio.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = false;
        }
        else
        {
            btnUpdate.Visible = true;
            btnSave.Visible = false;
          
            pnlradio.Visible = true;
            DataSet ds = new DataSet();
            ds = Month_Target.Get_CollectionTarget(Convert.ToInt32(ddlsuperzoneid.SelectedValue.ToString()), DDLZone.SelectedValue.ToString(), strFY.ToString(), "");
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdTarget.DataSource = ds ;
                grdTarget.DataBind();
            }
            else
            {
                grdTarget.DataSource = GetMonth();
                grdTarget.DataBind();
            }
            btnUpdate.Focus();
        }
    }
    protected void txtTarget_TextChanged(object sender, EventArgs e)
    {
        TextBox txtTarget = ((TextBox)((TextBox)sender).FindControl("txtTarget"));
        TextBox txtTargetAmt = ((TextBox)((TextBox)sender).FindControl("txtTargetAmt"));
        Label lblmonthno = ((Label)((TextBox)sender).FindControl("lblmonthno"));
        

        DataSet ds =  Month_Target.Get_CollectionTarget_FromPercent(Convert.ToInt32(DDLZone.SelectedValue.ToString()),lblmonthno.Text.ToString() ,Convert.ToInt32(strFY.ToString()),Convert.ToDecimal(txtTarget.Text.ToString()),"","","");
        txtTargetAmt.Text = ds.Tables[0].Rows[0]["TargetAmt"].ToString();
        txtTargetAmt.Focus();
        // Get_CollectionTarget_FromPercent
    }
}
