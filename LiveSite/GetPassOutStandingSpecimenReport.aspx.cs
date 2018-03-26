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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;
using Other_Z;

public partial class GetPassOutStandingSpecimenReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            PrintData();
        }
        else
        {
            PrintData();
        }
    }
    private void PrintData()
    {
        if (Request.QueryString["SpecNo"] != "0")
        {
            int FY = Convert.ToInt32(Session["FY"].ToString());
            if (FY != 0)
            {
                OtherBAL ObjBAL = new OtherBAL();
                DataSet ds = ObjBAL.Idv_Chetana_Get_Godown_Speciman_Head(Convert.ToInt32(Request.QueryString["SpecNo"].ToString()), FY, "SpcimanEdit");
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("~/Report/GetPassOutSpecimen.rpt"));
                rd.SetDataSource(ds.Tables[0]);
                GetPassSpecimen.ReportSource = rd;
            }
        }

    }
}
