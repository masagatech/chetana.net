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


public partial class Specimen_DashboardDetails : System.Web.UI.Page
{
    string Qstring;
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
        
        if (Request.QueryString["d"] != null)
        {
            Qstring = Request.QueryString["d"];
                  // Get_Reports_SpecimenDashBoard
            lblqstring.Text = Qstring;
                DataView dv = new DataView(SpecimanDetails.Get_Reports_SpecimenDashBoard(Qstring, "xxx").Tables[4]);
                //dv.RowFilter = "RemainQty <>0 ";
                grdEmployeedetails.DataSource = dv;
                grdEmployeedetails.DataBind();
                grdEmployeedetails.Visible = true;
                // PnlDashboard.Visible = false;
                //grdEmployeedetails.Columns[0].Visible = true;
                //grdEmployeedetails.Columns[1].Visible = true;
                //grdEmployeedetails.Columns[2].Visible = false;
                //grdEmployeedetails.Columns[3].Visible = false;
                //grdEmployeedetails.Columns[4].Visible = false;
            
           
        }

    }
}
