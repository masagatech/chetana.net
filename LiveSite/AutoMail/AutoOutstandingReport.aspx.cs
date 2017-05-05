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
using System.Text;
using Idv.Chetana.BAL;
using CrystalDecisions.CrystalReports.Engine;
using OtherNewClass;
using Newtonsoft.Json;


public partial class AutoMail_AutoOutstandingReport : System.Web.UI.Page
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
            DataSet dsMailParams = OtherNewClass.AutoMail.AutoMailParams("customeros", "", "", "", "", "", "", "", "");
            DataTable dt = dsMailParams.Tables[0];
            DoLog(objste, "Get Dates Count >> " + dt.Rows.Count.ToString());
            DataTable dtmaildesc = dsMailParams.Tables[1];
            DoLog(objste, "Get Mail setting Count >> " + dtmaildesc.Rows.Count.ToString());
            string FirstPath = string.Empty;
            string SecondPath = string.Empty;
            DoLog(objste, "Generating 1 File");
            FirstPath = "../AutoEmailAttachment/CustomerOSRpt/" + Convert.ToDateTime(dt.Rows[0]["todate"].ToString()).ToString("MM_dd_yyyy_HH_MM") + "/" + DateTime.Now.ToString("MM_dd_yyyy_HH_MM") + "/";
            SecondPath = "";
            DirectoryManagement(FirstPath);
            DataSet ds = OtherNewClass.AutoMailOS.Idv_Chetena_SendOSMail_To_Customer(Convert.ToDateTime(dt.Rows[0]["fromdate"].ToString()), Convert.ToDateTime(dt.Rows[0]["todate"].ToString()), Convert.ToInt32(dt.Rows[0]["fy"].ToString()), "", "", "");
            DoLog(objste, "Main Dataset >> ");
            Response.Write(generatefiles(ds, dt.Rows[0]["fromdate"].ToString(), dt.Rows[0]["todate"].ToString(), FirstPath, dtmaildesc));
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

    private string generatefiles(DataSet ds, string fromdate, string todate, string FirstPath, DataTable mailsetting)
    {
        try
        {
            DataTable dt1 = ds.Tables[0];
            DataView dv = new DataView(ds.Tables[1]);
            string strAttachFirst = string.Empty;
            string strAttachSecond = string.Empty;
            bool isSendData = false;
            System.Collections.ArrayList objList = new ArrayList();
            objList.Add(MailSetting(mailsetting));
            CrystalDecisions.CrystalReports.Engine.ReportDocument crystalReport;
            foreach (DataRow Row in dt1.Rows)
            {
                MailDetails objMails = new MailDetails();
                dv.RowFilter = "CustID = " + Row["custid"].ToString();
                crystalReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                crystalReport.Load(Server.MapPath("../Report/AutoOSMailCustomer.rpt"));
                crystalReport.SetDataSource(dv.ToTable());
                isSendData = dv.ToTable().Rows.Count > 0 ? true : false;
                strAttachFirst = Server.MapPath(FirstPath + "CustomerOS_" + Convert.ToDateTime(fromdate).ToString("dd-MMM-yyyy") + "_" + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + "_" + Row["custid"].ToString() + ".pdf");
                crystalReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachFirst);
                crystalReport.Close();
                crystalReport.Dispose();
                crystalReport = null;
                objMails.Attachment = strAttachSecond != "" ? strAttachFirst + "," + strAttachSecond : strAttachFirst;
                objMails.Name = Row["custName"].ToString();
                objMails.EmailId = Row["EmailID"].ToString();
                string makesubject = "Chetana Publications :: Outstanding Statement :: from " + Convert.ToDateTime(fromdate).ToString("dd-MMM-yyyy") + " to " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy");
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
