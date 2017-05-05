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
using System.Text;
using OtherNewClass;
using Newtonsoft.Json;

public partial class AutoMail_AutoCollectioReport : System.Web.UI.Page
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
            DataSet dsSuperZones = OtherNewClass.AutoMail.AutoMailParams("collection", "", "", "", "", "", "", "", "");
            DataTable dtsz = dsSuperZones.Tables[0];
            DoLog(objste, "Get Super Zones Count >> " + dtsz.Rows.Count.ToString());
            DataTable dt = dsSuperZones.Tables[1];
            DoLog(objste, "Get Dates Count >> " + dt.Rows.Count.ToString());
            DataTable dtmaildesc = dsSuperZones.Tables[2];
            DoLog(objste, "Get Mail setting Count >> " + dtmaildesc.Rows.Count.ToString());
            string FirstPath = string.Empty;
            string SecondPath = string.Empty;
            if (dt.Rows.Count > 1)
            {
                DoLog(objste, "Generating 2 Files");
                FirstPath = "../AutoEmailAttachment/CollectionWklyRpt/" + Convert.ToDateTime(dt.Rows[0]["todate"].ToString()).ToString("MM_dd_yyyy_HH_MM") + "/" + DateTime.Now.ToString("MM_dd_yyyy_HH_MM") + "/";
                SecondPath = "../AutoEmailAttachment/CollectionWklyRpt/" + Convert.ToDateTime(dt.Rows[1]["todate"].ToString()).ToString("MM_dd_yyyy_HH_MM") + "/" + DateTime.Now.ToString("MM_dd_yyyy_HH_MM") + "/";
                DirectoryManagement(FirstPath);
                DoLog(objste, "First Directory Set >> " + FirstPath);
                DirectoryManagement(SecondPath);
                DoLog(objste, "Second Directory Set >> " + SecondPath);
                DataSet ds = BankReceiptPayment.Idv_Chetana_REP_Collection_Report(Convert.ToInt32(0), Convert.ToInt32(dt.Rows[0]["fy"].ToString()), Convert.ToDateTime(dt.Rows[0]["fromdate"].ToString()), Convert.ToDateTime(dt.Rows[0]["todate"].ToString()), "");
                DoLog(objste, "First Dataset >> ");
                DataSet ds1 = BankReceiptPayment.Idv_Chetana_REP_Collection_Report(Convert.ToInt32(0), Convert.ToInt32(dt.Rows[1]["fy"].ToString()), Convert.ToDateTime(dt.Rows[1]["fromdate"].ToString()), Convert.ToDateTime(dt.Rows[1]["todate"].ToString()), "");
                DoLog(objste, "Second Dataset >> ");
                Response.Write(generatefiles(ds, ds1, dtsz, dt.Rows[0]["fromdate"].ToString(), dt.Rows[0]["todate"].ToString(), dt.Rows[1]["fromdate"].ToString(), dt.Rows[1]["todate"].ToString(), FirstPath, SecondPath, dtmaildesc));
                DoLog(objste, "Wrote Data >> ");

            }
            else
            {
                DoLog(objste, "Generating 1 File");
                FirstPath = "../AutoEmailAttachment/CollectionWklyRpt/" + Convert.ToDateTime(dt.Rows[0]["todate"].ToString()).ToString("MM_dd_yyyy_HH_MM") + "/" + DateTime.Now.ToString("MM_dd_yyyy_HH_MM") + "/";
                SecondPath = "";
                DirectoryManagement(FirstPath);
                DataSet ds = BankReceiptPayment.Idv_Chetana_REP_Collection_Report(Convert.ToInt32(0), Convert.ToInt32(dt.Rows[0]["fy"].ToString()), Convert.ToDateTime(dt.Rows[0]["fromdate"].ToString()), Convert.ToDateTime(dt.Rows[0]["todate"].ToString()), "");
                DoLog(objste, "Main Dataset >> ");
                Response.Write(generatefiles(ds, null, dtsz, dt.Rows[0]["fromdate"].ToString(), dt.Rows[0]["todate"].ToString(), dt.Rows[0]["fromdate"].ToString(), dt.Rows[0]["todate"].ToString(), FirstPath, SecondPath, dtmaildesc));
                DoLog(objste, "Wrote Data >> ");

            }

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

    private string generatefiles(DataSet ds, DataSet ds1, DataTable dt1, string fromdate, string todate, string s_fromdate, string s_todate, string FirstPath, string SecondPath, DataTable mailsetting)
    {
        try
        {

            bool isSecondDataPresent = false;
            DataView dv = new DataView(ds.Tables[0]);
            DataView dv1 = new DataView();
            bool isSendFirstData = false;
            bool isSendSecondata = false;

            if (ds1 != null)
            {
                isSecondDataPresent = true;
                dv1.Table = ds1.Tables[0];
            }

            string strAttachFirst = string.Empty;
            string strAttachSecond = string.Empty;
            System.Collections.ArrayList objList = new ArrayList();
            objList.Add(MailSetting(mailsetting));
            CrystalDecisions.CrystalReports.Engine.ReportDocument crystalReport;
            foreach (DataRow Row in dt1.Rows)
            {
                MailDetails objMails = new MailDetails();

                #region First Data
                dv.RowFilter = "Superzone = " + Row["SuperZoneID"].ToString();
                crystalReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                crystalReport.Load(Server.MapPath("../Report/CollectionReport.rpt"));
                crystalReport.SetDataSource(dv.ToTable());
                isSendFirstData = dv.ToTable().Rows.Count > 0 ? true : false;
                strAttachFirst = Server.MapPath(FirstPath + "Wkly_Col_" + Convert.ToDateTime(fromdate).ToString("dd-MMM-yy") + "_" + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + "_" + Row["SuperZoneID"].ToString() + ".pdf");
                crystalReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachFirst);
                crystalReport.Close();
                crystalReport.Dispose();
                crystalReport = null;
                #endregion

                #region "Second Data"

                if (isSecondDataPresent)
                {

                    dv1.RowFilter = "Superzone = " + Row["SuperZoneID"].ToString();
                    crystalReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    crystalReport.Load(Server.MapPath("../Report/CollectionReport.rpt"));
                    crystalReport.SetDataSource(dv1.ToTable());
                    isSendSecondata = dv1.ToTable().Rows.Count > 0 ? true : false;
                    strAttachSecond = Server.MapPath(SecondPath + "_Wkly_Col_" + Convert.ToDateTime(s_fromdate).ToString("dd-MMM-yy") + "_" + Convert.ToDateTime(s_todate).ToString("dd-MMM-yy") + "_" + Row["SuperZoneID"].ToString() + ".pdf");
                    crystalReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachSecond);
                    crystalReport.Close();
                    crystalReport.Dispose();
                    crystalReport = null;

                }

                #endregion
                objMails.Attachment = strAttachSecond != "" ? strAttachFirst + "," + strAttachSecond : strAttachFirst;
                objMails.Name = Row["SuperZoneName"].ToString();
                objMails.EmailId = Row["Email"].ToString();
                string makesubject = "Collection from " + (isSecondDataPresent == true ? Convert.ToDateTime(fromdate).ToString("dd-MMM-yyyy") + " TO " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + " &  " + Convert.ToDateTime(s_fromdate).ToString("dd-MMM-yyyy") + " TO " + Convert.ToDateTime(s_todate).ToString("dd-MMM-yyyy") : Convert.ToDateTime(fromdate).ToString("dd-MMM-yyyy") + " TO " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy"));
                objMails.Subject = makesubject;
                objMails.Desc = makesubject;
                if (isSendFirstData)
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
