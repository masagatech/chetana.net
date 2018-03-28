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
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class CustomerSchemeAck : System.Web.UI.Page
{
    #region Variables
    string strFY;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        //Response.Write(strFY);
        if (!Page.IsPostBack)
        {
            Session["customerscheme"] = null;
        }
        if (IsPostBack)
        {
            if (Session["customerscheme"] != null)
            {
                BindDetail((DataTable)Session["customerscheme"]);
                //DataTable dt = (DataTable)Cache["ABC"];

            }
        }

    }

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

        if (dt.Rows.Count > 0)
        {
            if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
            {
                txtcustomer.Text = CustCode;
                lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            }
            else
            {
                lblCustName.Text = "Customer is blacklisted";
                txtcustomer.Focus();
                txtcustomer.Text = "";

            }
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";

        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = Scheme.Get_Scheme_Customer_Mapping("schemereport", txtcustomer.Text.ToString(), Convert.ToInt32(strFY));
        Session["customerscheme"] = ds.Tables[0];
        BindDetail(ds.Tables[0]);
    }

    public void BindDetail(DataTable dt1)
    {
        if (dt1.Rows.Count > 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/CustomerScheme.rpt"));
            rd.Database.Tables[0].SetDataSource(dt1);
            schemeCustomer.ReportSource = rd;
        }
        // GrdDetails.DataSource = (DataTable)Session["schememapping"];
        // GrdDetails.DataBind();
    }
}
