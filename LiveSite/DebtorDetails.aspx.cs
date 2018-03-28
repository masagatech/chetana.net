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
using System.Xml.Linq;
using Idv.Chetana.BAL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
#endregion

public partial class DebtorDetails : System.Web.UI.Page
{
    string strFY;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["FY"] != "" )
            {
                
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        
        if (IsPostBack)
        {
            Bind();
        }
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnget_Click(object sender, EventArgs e)
    {
        Bind();
    }
    public void Bind()
    {
           
        string from = txtFromDate.Text.Split('/')[1].ToString() + "/" + txtFromDate.Text.Split('/')[0].ToString() + "/" + txtFromDate.Text.Split('/')[2];
        string to = txtToDate.Text.Split('/')[1].ToString() + "/" + txtToDate.Text.Split('/')[0].ToString() + "/" + txtToDate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(to);
        DataSet dt = new DataSet();
         
        dt = Idv.Chetana.BAL.Specimen.Idv_Chetana_Customer_Summary_Report(0, from, to, Convert.ToInt32(strFY),
           0, 0, "",0,"-c",ddlselect.SelectedValue.ToString());
        //dt = JVDetail.Idv_Chetana_GetJV_Report(FromDate, ToDate).Tables[0];
        if (dt.Tables[0].Rows.Count != 0)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("Report/DebtorDetailsReport.rpt"));
            rd.SetDataSource(dt.Tables[0]);
            rd.SetParameterValue("IsPrint", Convert.ToBoolean(IsPrint.Checked));
            JVReport.ReportSource = rd;
        }
        else
        {
            MessageBox("No Record Found");
        }

    }
}
