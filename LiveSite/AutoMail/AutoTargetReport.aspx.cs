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
using Newtonsoft.Json;
using OtherNewClass;
using System.Text;

public partial class AutoMail_AutoTargetReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindReport();
    }

    private void BindReport()
    {
        StringBuilder objste = new StringBuilder("-");
        try
        {

            DoLog(objste, "Start");
            DataSet dsSuperZones = OtherNewClass.AutoMail.AutoMailParams("target", "", "", "", "", "", "", "", "");
            DataTable dtsz = dsSuperZones.Tables[0];
            DoLog(objste, "Get Super Zones Count >> " + dtsz.Rows.Count.ToString());
            DataTable dt = dsSuperZones.Tables[1];
            DoLog(objste, "Get Dates Count >> " + dt.Rows.Count.ToString());
            DataTable dtmaildesc = dsSuperZones.Tables[2];
            DoLog(objste, "Get Mail setting Count >> " + dtmaildesc.Rows.Count.ToString());
            string FirstPath = string.Empty;
            string SecondPath = string.Empty;
            DoLog(objste, "Generating 1 File");
            FirstPath = "../AutoEmailAttachment/TargetRpt/" + Convert.ToDateTime(dt.Rows[0]["todate"].ToString()).ToString("MM_dd_yyyy_HH_MM") + "/" + DateTime.Now.ToString("MM_dd_yyyy_HH_MM") + "/";
            SecondPath = "";
            DirectoryManagement(FirstPath);
            DataSet ds = Other.Dashboard.Get_Report_TargetAchievement(0, Convert.ToInt32(dt.Rows[0]["fy"].ToString()), Convert.ToDateTime(dt.Rows[0]["fromdate"].ToString()), Convert.ToDateTime(dt.Rows[0]["todate"].ToString()), "Zone");
            DoLog(objste, "Main Dataset >> ");
            Response.Write(generatefiles(ds, dtsz, dt.Rows[0]["fromdate"].ToString(), dt.Rows[0]["todate"].ToString(), FirstPath, dtmaildesc));
            DoLog(objste, "Wrote Data >> ");

        }
        catch (Exception wex)
        {
            Response.Write("Error >> " + DoLog(objste, "Error >> " + wex.Message).ToString());

        } Response.End();
    }

    private StringBuilder DoLog(StringBuilder strBuilder, string Log)
    {

        strBuilder.Append(DateTime.Now + " ==>> " + Log + Environment.NewLine);
        return strBuilder;
    }

    private string generatefiles(DataSet ds, DataTable dt1, string fromdate, string todate, string FirstPath, DataTable mailsetting)
    {
        try
        {
            DataView dv = new DataView(ds.Tables[0]);
            string strAttachFirst = string.Empty;
            string strAttachSecond = string.Empty;
            bool isSendData = false; 
            System.Collections.ArrayList objList = new ArrayList();
            objList.Add(MailSetting(mailsetting));
            CrystalDecisions.CrystalReports.Engine.ReportDocument crystalReport;
            foreach (DataRow Row in dt1.Rows)
            {
                MailDetails objMails = new MailDetails();
                dv.RowFilter = "SuperZoneID = " + Row["SuperZoneID"].ToString();
                crystalReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                crystalReport.Load(Server.MapPath("../Report/TargetAchievement.rpt"));
                crystalReport.SetDataSource(dv.ToTable());
                isSendData = dv.ToTable().Rows.Count > 0 ? true : false;
                strAttachFirst = Server.MapPath(FirstPath + "Target_" + Convert.ToDateTime(fromdate).ToString("dd-MMM-yyyy") + "_" + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + "_" + Row["SuperZoneID"].ToString() + ".pdf");
                crystalReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachFirst);
                crystalReport.Close();
                crystalReport.Dispose();
                crystalReport = null;
                objMails.Attachment = strAttachSecond != "" ? strAttachFirst + "," + strAttachSecond : strAttachFirst;
                objMails.Name = Row["SuperZoneName"].ToString();
                objMails.EmailId = Row["Email"].ToString();
                string makesubject = "Target from " + Convert.ToDateTime(fromdate).ToString("dd-MMM-yyyy") + " TO " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy");
                objMails.Subject = makesubject;
                objMails.Desc = makesubject;
                if (isSendData)
                {
                    objList.Add(objMails);
                }
                objMails = null;
            }
            return JsonConvert.SerializeObject(objList);
        }
        catch (Exception ex)
        {

            throw;
        }



    }

    private MailSetting MailSetting(DataTable mailset)
    {
        MailSetting objmailset = new MailSetting();
        objmailset.Subject = mailset.Rows[0]["M_Subject"].ToString();
        objmailset.CC = mailset.Rows[0]["M_CC"].ToString();
        objmailset.BCC = mailset.Rows[0]["M_BCC"].ToString();
        objmailset.Body = mailset.Rows[0]["M_Template"].ToString();
        return objmailset;
    }

    private string DirectoryManagement(string path)
    {
        try
        {
            path = Server.MapPath(path);
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }
        catch (Exception ex)
        {


        }
        return path;

    }




}
