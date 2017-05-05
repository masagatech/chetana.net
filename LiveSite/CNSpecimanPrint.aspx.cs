using CrystalDecisions.CrystalReports.Engine;
using Other_Z;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CNSpecimanPrint : System.Web.UI.Page
{
    #region
    string strFY;
    ReportDocument rd = new ReportDocument();
    #endregion

    #region Form Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            if (!Page.IsPostBack)
            {
                strFY = Session["FY"].ToString();
            }
        }
        if (txtIsExport.Value == "yes")
        {
            Prindata(Convert.ToInt32(txtdocument.Text));
            txtIsExport.Value = "";
        }
        if (txtdocument.Text != "")
        {
            Prindata(Convert.ToInt32(txtdocument.Text));
        }
        else
        {
            txtdocument.Focus();
        }
        
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtdocument.Text != "")
        {
            Prindata(Convert.ToInt32(txtdocument.Text));
        }
        
    }

    #region Message Method
    private void Message(string Msg)
    {
        string Javascrip = "alert('" + Msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", Javascrip, true);
    }
    #endregion

    private void Prindata(int doc)
    {
        if (txtdocument.Text != "")
        {
            //Request.QueryString["docno"].ToString()
            DataSet ds = Other_Z.OtherBAL.SpecimanReturnPrint(Convert.ToInt32(Session["FY"]), Convert.ToInt32(txtdocument.Text), "", "");
            if (ds.Tables[1].Rows.Count > 0)
            {
                CNPrint.Visible = true;
                rd.Load(Server.MapPath("Report/CNSpeciman.rpt"));
                rd.SetDataSource(ds.Tables[0]);
                rd.SetParameterValue("docno", ds.Tables[1].Rows[0][0]);
                rd.SetParameterValue("GCN", ds.Tables[1].Rows[0][1]);
                rd.SetParameterValue("SCN", ds.Tables[1].Rows[0][2]);
                rd.SetParameterValue("CNDate", ds.Tables[1].Rows[0][3]);
                rd.SetParameterValue("MrCode", ds.Tables[1].Rows[0][4]);
                rd.SetParameterValue("LRNo", ds.Tables[1].Rows[0][5]);
                rd.SetParameterValue("TransportCode", ds.Tables[1].Rows[0][6]);
                //rd.SetParameterValue("SpInstruction", ds.Tables[1].Rows[0][7].ToString());
                rd.SetParameterValue("Description", ds.Tables[1].Rows[0][8]);
                CNPrint.ReportSource = rd;
            }
            else
            {
                Message("Record Not Found");
                CNPrint.Visible = false;
                txtdocument.Focus();
                return;
            }
        }

    }

    #endregion
}