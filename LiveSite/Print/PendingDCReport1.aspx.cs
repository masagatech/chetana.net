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
using CrystalDecisions.CrystalReports.Engine;
using Idv.Chetana.BAL;

public partial class Print_PendingDCReport1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindPendingDC();
    }
    public void bindPendingDC()
    {
        //int DocNo = Convert.ToInt32(txtDocno.Text.Split(':')[0].Trim());
        //if (txtDocno.Text != "")
        //{
        //     if (Request.QueryString["d"] == "b")
        //{

        //    grdpending.DataSource = SpecimanDetails.Get_Specimen_NotConfirmed_Books();
        //    grdpending.DataBind();
        //}
        //else
        if (Request.QueryString["d"] != null)
        {

            DataSet ds = new DataSet();
	    //ds = SpecimanDetails.Get_SubDocId_And_ItsRecords_By_DocNo(Convert.ToInt32(Request.QueryString["d"].ToString()),"confirmed");
            ds = Idv.Chetana.BAL.SpecimanDetails.Idv_Chetana_Get_SpecimenDetails_By_DocNo_Report(Convert.ToInt32(Request.QueryString["d"].ToString()));
            DataView dv = new DataView(ds.Tables[0]);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("../Report/SpecimenPendingDC.rpt"));
            rd.SetDataSource(dv);
            PendingDC.ReportSource = rd;
        }


    }
}
