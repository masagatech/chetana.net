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
using CrystalDecisions.CrystalReports.Engine;

public partial class SpecimenReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["access"].ToString() != ConfigurationManager.AppSettings["accessok"].ToString())
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString();
            if (Session["Role"] != null)
            {
                if (!Other.Get_UserAccess(page, Session["Role"].ToString()))
                {
                    Response.Redirect("dashboard.aspx");
                }

            }
        }
        txtDocno.Focus();
        specimenfillreport();
        if (!Page.IsPostBack)
        {
            DDLsubconfirmid.Items.Insert(0, new ListItem("-Select Sub Confirm ID-", "0"));
        }
    }
    protected void txtDocno_TextChanged(object sender, EventArgs e)
    {
        try{
        
        DDLsubconfirmid.Items.Clear();
       
        DDLsubconfirmid.DataSource = Specimen.Get_SubConfirmID_onDocumentNo(Convert.ToInt32(txtDocno.Text.ToString()));
        DDLsubconfirmid.DataBind();
        DDLsubconfirmid.Items.Insert(0, new ListItem("-Select Sub Confirm ID-", "0"));
        DDLsubconfirmid.Focus();
        }
    catch{}
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        specimenfillreport();
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    private void specimenfillreport()
    {
        if (txtDocno.Text != "" && DDLsubconfirmid.SelectedItem.Value != "")
        {
            if (txtDocno.Text.ToString() == "")
            {
                MessageBox("Require Document No.");
            }
            try
            {
                DataTable dt = new DataTable();
                dt = Specimen.Get_SpecimenDetailsForInvoice(Convert.ToInt32(txtDocno.Text.ToString()), Convert.ToDecimal(DDLsubconfirmid.SelectedItem.Value.ToString())).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ReportDocument CR = new ReportDocument();
                    CR.Load(Server.MapPath("Report/SpecimenReport.rpt"));
                    CR.SetDataSource(dt);
                    crtspecimen.ReportSource = CR;
                }
                //else
                //{
                //    MessageBox("No Records Found");
                //    txtDocno.Focus();
                //}
            }
            catch { }
        }
    }
}
