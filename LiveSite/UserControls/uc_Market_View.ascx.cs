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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_Market_View : System.Web.UI.UserControl
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
            ViewState["zoneid"] = null;
            ViewState["DocNoRep"] = null;
            ViewState["Rep"] = null;
            Getgridetails();

            ddlSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            ddlSDZone.DataBind();
            ddlSDZone.Focus();

            setddl(Session["zoneLevel"].ToString(), Session["zoneId"].ToString());
        }
        else
        {
            fillDataDocNo(0);
            fillData(0);
        }
    }

    public void Getgridetails()
    {
        //grdView.DataSource = Market_Review.Get_Mark_ReviewDetails("view", "0");
        //grdView.DataBind();
    }

    protected void lblzone_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int zoneid = Convert.ToInt32(((Label)lnk.Parent.FindControl("lblzoneid")).Text);
        ViewState["zoneid"] = zoneid;

        divall.Visible = false;
        pnlgrdDeatils.Visible = true;
        divbutton.Visible = true;
        Pnlgrdview.Visible = false;
        MarketReview.ReportSource = null;
        DataSet ds = new DataSet();
        ds = Market_Review.Get_Mark_ReviewDetails("all", zoneid.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMSDZ.Text = ds.Tables[0].Rows[0][3].ToString() + ",  ";
            lblMSZ.Text = ds.Tables[0].Rows[0][5].ToString() + ",  ";
            lblMZ.Text = ds.Tables[0].Rows[0][6].ToString();
            grdDeatils.DataSource = ds.Tables[0];
            grdDeatils.DataBind();
        }
        else
        {

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlgrdDeatils.Visible = false;
        divbutton.Visible = false;
        Pnlgrdview.Visible = true;
        divall.Visible = true;
        MarketReview.ReportSource = null;
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        fillDataDocNo(1);
    }

    protected void btnAllReport_Click(object sender, EventArgs e)
    {
        fillData(1);
    }

    public string getString()
    {
        string zoneid = string.Empty;
        foreach (GridViewRow row in grdDeatils.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("Chkselect");
            if (check.Checked == true)
            {
                Label lblzone = (Label)row.FindControl("lblmarkid");
                zoneid = zoneid + (lblzone.Text) + ",";
            }

        }
        return zoneid;

    }

    public void fillData(int isNew)
    {
        string Details = string.Empty;
        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {
            DataSet ds = new DataSet();

            if (ddlSummery.SelectedIndex == 0)
            {
                Details = "Summery";


                if (DDLSuperZone.SelectedIndex != 0 && DDLZone.SelectedIndex != 0)
                {
                    ds = Market_Review.Get_Mark_Review_DetailsBy_Zone(Details, "z", ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), DDLZone.SelectedValue.ToString(), Convert.ToInt32(strFY));
                }
                else if (DDLSuperZone.SelectedIndex != 0 && DDLZone.SelectedIndex == 0)
                {
                    ds = Market_Review.Get_Mark_Review_DetailsBy_Zone(Details, "sz", ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), "", Convert.ToInt32(strFY));
                }
                else
                {
                    ds = Market_Review.Get_Mark_Review_DetailsBy_Zone(Details, "sdz", ddlSDZone.SelectedValue.ToString(), "", "", Convert.ToInt32(strFY));
                }

            }
            else
            {
                Details = "Details";


                if (DDLSuperZone.SelectedIndex != 0 && DDLZone.SelectedIndex != 0)
                {
                    ds = Market_Review.Get_Mark_Review_DetailsBy_Zone(Details, "z", ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), DDLZone.SelectedValue.ToString(), Convert.ToInt32(strFY));
                }
                else if (DDLSuperZone.SelectedIndex != 0 && DDLZone.SelectedIndex == 0)
                {
                    ds = Market_Review.Get_Mark_Review_DetailsBy_Zone(Details, "sz", ddlSDZone.SelectedValue.ToString(), DDLSuperZone.SelectedValue.ToString(), "", Convert.ToInt32(strFY));
                }
                else
                {
                    ds = Market_Review.Get_Mark_Review_DetailsBy_Zone(Details, "sdz", ddlSDZone.SelectedValue.ToString(), "", "", Convert.ToInt32(strFY));
                }

            }

            ViewState["Rep"] = ds.Tables[0];

        }
        if (ViewState["Rep"] != null)
        {
            try
            {
                DataTable check=(DataTable)ViewState["Rep"];
                if (ddlSummery.SelectedIndex == 0)
                {
                    
                    if (check.Rows.Count > 0)
                    {
                        rd.Load(Server.MapPath("Report/MarketReviewSummeryReport.rpt"));
                        rd.Database.Tables[0].SetDataSource((DataTable)ViewState["Rep"]);
                        MarketReview.ReportSource = rd;
                    }
                }
                else if (ddlSummery.SelectedIndex == 1)
                {
                    if (check.Rows.Count > 0)
                    {
                        rd.Load(Server.MapPath("Report/MarketReviewDetailsReport.rpt"));
                        rd.Database.Tables[0].SetDataSource((DataTable)ViewState["Rep"]);
                        MarketReview.ReportSource = rd;
                    }

                }

            }
            catch
            {


            }
        }
    }

    public void fillDataDocNo(int isNew)
    {
        int zone = Convert.ToInt32(ViewState["zoneid"]);
        ReportDocument rd = new ReportDocument();
        if (isNew == 1)
        {
            string value = getString();
            DataSet ds = new DataSet();

            if (value == "")
            {

                ds = Market_Review.Get_Mark_ReviewDetails("all", zone.ToString());
                ViewState["DocNoRep"] = ds.Tables[0];
            }
            else
            {
                ds = Market_Review.Get_Mark_ReviewDetails("", value);
                ViewState["DocNoRep"] = ds.Tables[0];
            }
        }
        if (ViewState["DocNoRep"] != null)
        {
            try
            {
                rd.Load(Server.MapPath("Report/MarketReviewReport.rpt"));
                rd.Database.Tables[0].SetDataSource((DataTable)ViewState["DocNoRep"]);
                MarketReview.ReportSource = rd;

            }
            catch
            {


            }
        }
    }

    protected void lblView_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        int mid = Convert.ToInt32(((Label)lnk.FindControl("lblmarkid")).Text);
        GridView1.DataSource = Market_Review.Get_Mark_ReviewDetails("", mid.ToString());
        GridView1.DataBind();
        mdpextender.Show();
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
        DDLSuperZone.Items.Insert(0, new ListItem("--All--", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
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
            DDLSuperZone.Items.Insert(0, new ListItem("--All--", "0"));
            //  DDLZone.SelectedValue = null;
            // Bind_DDL_ZoneCust();
        }
        else
        {

            DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(ddlSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLSuperZone.DataBind();
            DDLSuperZone.Items.Insert(0, new ListItem("--All--", "0"));
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
            DDLZone.Focus();
            Bind_DDL_Zone();

        }
    }

    #endregion

    #region Zone index change

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLZone.SelectedIndex == 0)
        {
            // MessageBox("Select SuperZone");

            ddlSummery.Focus();
            ddlSummery.TabIndex = 0;
            btnAllReport.TabIndex = 1;
            //  DDLZone.SelectedValue = null;
        }
        else
        {

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
