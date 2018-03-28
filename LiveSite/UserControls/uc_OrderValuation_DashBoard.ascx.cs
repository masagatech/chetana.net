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
using System.Web.Services;
using Idv.Chetana.BAL;

#endregion

public partial class UserControls_uc_OrderValuation_DashBoard : System.Web.UI.UserControl
{
    #region Variables
    static DataSet DS;
    string strChetanaCompanyName = "cppl"; 
    string strFY; 
    static DateTime fdate;
    static DateTime tdate;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( Session["ChetanaCompanyName"] != null)
        {
            if ( Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);
            if (!Page.IsPostBack)
            {
               
                DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
                DDLSuperZone.DataBind();
                DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
                txtfromDate.Focus();
            }
        }

    }
    #region Bind DashBoard

    public void BindDLDashboard()
    {
        DS = new DataSet();
        DS = Idv.Chetana.BAL.Other.Dashboard.Get_Dasboard_ForOrderValuation(fdate, tdate, Convert.ToInt32(DDLSuperZone.SelectedValue),Convert.ToInt32(strFY));
        DLDashboard.DataSource = DS.Tables[3];
        DLDashboard.DataBind();
        lbltotalgross.Text = " Total Gross Amount "+ String.Format("{0:0.00}",Convert.ToDecimal( DS.Tables[0].Rows[0]["TotalGrossAmount"].ToString()));
        lbltotalnet.Text = " Total Net Amount " +  String.Format("{0:0.00}",Convert.ToDecimal( DS.Tables[0].Rows[0]["TotalNetAmount"].ToString()));
        lblactulnet.Text = " Actual Receivable " + String.Format("{0:0.00}", Convert.ToDecimal(DS.Tables[0].Rows[0]["actualnetamount"].ToString()));
    }
    #endregion
    protected void btnget_Click(object sender, EventArgs e)
    {
        string from = txtfromDate.Text.Split('/')[1] + "/" + txtfromDate.Text.Split('/')[0] + "/" + txtfromDate.Text.Split('/')[2];
        string To = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("From Date is Greater than ToDate");
            txtfromDate.Focus();
        }
        else
        {
            BindDLDashboard();
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion
    protected void DLDashboard_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView GrdDashboard = (GridView)e.Item.FindControl("GrdDashboard");
            Label SuperZoneName = (Label)e.Item.FindControl("lblSzname");

            DataView dv = new DataView(DS.Tables[1]);
            dv.RowFilter = "SZoneName = '" + SuperZoneName.Text.ToString().Trim() + "'";

           GrdDashboard.DataSource = dv;
            GrdDashboard.DataBind();
        }
    }
    protected void lnkszname_Click(object sender, EventArgs e)
    {
        
        LinkButton lnkszid = (LinkButton)sender;
        string SZID = lnkszid.CommandArgument.ToString();
        GrdDetails.DataSource = Idv.Chetana.BAL.Other.Dashboard.Get_Dasboard_ForOrderValuation(fdate, tdate, Convert.ToInt32(SZID),Convert.ToInt32(strFY)).Tables[2];
        GrdDetails.DataBind();
        modalPopupForZone.Show();
    }
}
