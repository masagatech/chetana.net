using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//
using Other_Z;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using OtherNewClass;
using System.Xml;

public partial class AutoMail_AutoInvoice : System.Web.UI.Page
{
    string strFY;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetInvoice();
    }

    private void GetInvoice()
    {
        StringBuilder objste = new StringBuilder("-");
        try
        {
            DataSet dsMailParams = OtherNewClass.AutoMail.AutoMailParams("customerinv", "", "", "", "", "", "", "", "");
            DataTable dtmaildesc = dsMailParams.Tables[0];
            DataSet ds = OtherBAL.GetInvoiceLog("System", "", "", "");
            DataTable dt = ds.Tables[0];
            DoLog(objste, "Get Mail setting Count >> " + dt.Rows.Count.ToString());
            //DataTable dtmaildesc = ds.Tables[2];
            string FirstPath = string.Empty;
            string SecondPath = string.Empty;
            DoLog(objste, "Generating 1 File");
            FirstPath = "../AutoEmailAttachment/AutoInvoice/" + DateTime.Now.ToString("MM_dd_yyyy_HH_MM") + "/";
            SecondPath = "";
            DirectoryManagement(FirstPath);
            DoLog(objste, "Main Dataset >> ");
            Response.Write(generatefiles(ds,FirstPath, dtmaildesc));
            DoLog(objste, "Wrote Data >> ");
        }
        catch (Exception ex)
        {
            Response.Write("Error >> " + DoLog(objste, "Error >> " + ex.Message).ToString());
        } Response.End();

    }

    #region Create PDF File
    private string generatefiles(DataSet ds,string FirstPath, DataTable mailsetting)
    {
        try
        {
            DataView dvmaster = new DataView(ds.Tables[0]);
            DataView dv = new DataView(ds.Tables[1]);
            string strAttachFirst = string.Empty;
            string strAttachSecond = string.Empty;
            

            bool isSendData = false;
            System.Collections.ArrayList objList = new ArrayList();
            CrystalDecisions.CrystalReports.Engine.ReportDocument crystalReport;
            objList.Add(MailSetting(mailsetting));
            XmlDocument doc = new XmlDocument();
            XmlNode inode = doc.CreateElement("f");
            XmlNode fnode = doc.CreateElement("r");
            
            foreach (DataRow Row in ds.Tables[0].Rows)
            {
                
                MailDetails objMails = new MailDetails();
                dv.RowFilter = "SubDocId = " + Row["subdocno"].ToString();
                dvmaster.RowFilter = "subdocno = " + Row["subdocno"].ToString();
                crystalReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                crystalReport.Load(Server.MapPath("../Report/PrintInvoiceMM.rpt"));
                crystalReport.SetDataSource(dv);
                isSendData = dv.ToTable().Rows.Count > 0 ? true : false;
                strAttachFirst = Server.MapPath(FirstPath + dvmaster[0]["CustCode"]+"-" + dvmaster[0]["subdocno"] + ".pdf");
                crystalReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachFirst);
                crystalReport.Close();
                crystalReport.Dispose();
                crystalReport = null;
                objMails.Attachment = strAttachSecond != "" ? strAttachFirst + "," + strAttachSecond : strAttachFirst;
                objMails.Name = dvmaster[0]["CustName"].ToString();
                objMails.EmailId = Row["EmailID"].ToString();
                string makesubject = dvmaster[0]["subject"].ToString();
                objMails.Subject = makesubject;
                objMails.Desc = Row["msg"].ToString();

                XmlNode element = doc.CreateElement("i");

                inode = doc.CreateElement("subdoc");
                inode.InnerText = Row["subdocno"].ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("fyu");
                inode.InnerText = Row["FY"].ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("mod");
                inode.InnerText = Row["module"].ToString();
                element.AppendChild(inode);

                fnode.AppendChild(element);

                if (isSendData)
                {
                    objList.Add(objMails);
                }
                objMails = null;

            }
            Other_Z.OtherBAL ObjBal = new Other_Z.OtherBAL();
            ObjBal.UpdateEmailLog(fnode.OuterXml,"", "", "");
            return JsonConvert.SerializeObject(objList);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    #endregion

    #region Mail Setting
    private MailSetting MailSetting(DataTable mailset)
    {
        MailSetting objmailset = new MailSetting();
        objmailset.Subject = mailset.Rows[0]["M_Subject"].ToString();
        objmailset.CC = mailset.Rows[0]["M_CC"].ToString();
        objmailset.BCC = mailset.Rows[0]["M_BCC"].ToString();
        objmailset.Body = mailset.Rows[0]["M_Template"].ToString();
        return objmailset;
    }
    #endregion

    #region Create log Details
    private StringBuilder DoLog(StringBuilder strBuilder, string Log)
    {
        strBuilder.Append(DateTime.Now + " ==>> " + Log + Environment.NewLine);
        return strBuilder;
    }
    #endregion

    #region Create Folder Every Day
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
    #endregion
}