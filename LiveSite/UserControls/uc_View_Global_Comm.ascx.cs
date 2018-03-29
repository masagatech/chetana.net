#region Namespace
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
using System.Xml;
using System.Xml.Linq;
using Idv.Chetana.BAL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Others;
using System.IO;
#endregion

public partial class UserControls_uc_View_Global_Comm : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "cppl";
    string strFY;

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
            Session["tempCommData"] = null;
            GetData();
        }
    }

    public void GetData()
    {
        DataSet ds = new DataSet();
        DataTable tbl;

        ds = OtherClass.Idv_Chetana_Get_Global_Commission(0, 0, 0, Convert.ToInt32(strFY));

        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdComm.DataSource = ds.Tables[0];
            GrdComm.DataBind();

            tbl = ds.Tables[0];
            DataRow dr = tbl.Rows[0];
            txtcnper.Text = dr["CNPer"].ToString() == "" ? "0.00" : Convert.ToDecimal(dr["CNPer"]).ToString("0.00");
        }
        else
        {
            MessageBox("Kindly SET COMMISSION...");
        }
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion
}
