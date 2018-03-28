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
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Data.SqlClient;

public partial class CMSSendEmail : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY;
    string id;
    string mailid;
    string d;
    string sd;
    public Boolean mFlag = true;
    //string Body = "";
        DateTime dt = DateTime.Now;
        String strDate;
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {

            CMSCheck();
           
            
            
           
        }
    }
    protected void CMSCheck()
    {
        
        DataTable CMSCheck = new DataTable();
        DataRow RCMSCheck;
        CMSCheck = CMS.Idv_Chetana_CMS_Check().Tables[0];
	
        if (CMSCheck.Rows.Count != 0)
        {
            for (int k = 0; k <= CMSCheck.Rows.Count - 1; k++)
            {
                RCMSCheck = CMSCheck.Rows[k];



                if (RCMSCheck[0].ToString() != RCMSCheck[1].ToString())
                {
			
                    BindGridview1();
                    BindGridview2();
                    BindGridview3();
                }
            }
        }
       
       
       
    }
    protected void BindGridview1()
    {

        DataSet ds = new DataSet();
        grdconfirm.DataSource = CMS.Idv_Chetana_CMS_TKTESCALATE("Level1").Tables[0];
        grdconfirm.DataBind();
	
	        if (CMS.Idv_Chetana_CMS_TKTESCALATE("Level1").Tables[0].Rows.Count != 0)
        	{
           
			SendMailLevel1();

        	}
	 
    }
    protected void BindGridview2()
    {

        DataSet ds = new DataSet();
        gdLevel2.DataSource = CMS.Idv_Chetana_CMS_TKTESCALATE("Level2").Tables[0];
        gdLevel2.DataBind();
        if (CMS.Idv_Chetana_CMS_TKTESCALATE("Level2").Tables[0].Rows.Count != 0)
        {
            SendMailLevel2();
        }
    }
    protected void BindGridview3()
    {

        DataSet ds = new DataSet();
        gdLevel3.DataSource = CMS.Idv_Chetana_CMS_TKTESCALATE("Level3").Tables[0];
        gdLevel3.DataBind();
        if (CMS.Idv_Chetana_CMS_TKTESCALATE("Level3").Tables[0].Rows.Count != 0)
        {
            SendMailLevel3();
        }
    }
    public void SendMailLevel1()
    {
        strDate = dt.ToString("dddd, dd MMMM yyyy h:mm tt");
         String Body = "";
        Body = (" <HTML>");
        Body = Body + ("<style>*{margin:0 auto;padding:0 auto;}.text {color: #444; font-size: 18px;font-family:arial;}</style>");
        Body = Body + (" <body><table id=body_holder border=0 cellpadding=0 cellspacing=0 width=100%>");
        Body = Body + (" <tbody><tr><td>");
        Body = Body + (" <table bgcolor=#e1e7e8 border=0 cellpadding=0 cellspacing=0 width=100%> ");
        Body = Body + (" <tbody><tr><td><table align=center border=0 cellpadding=0 cellspacing=0 width=600>");
        Body = Body + (" <tbody>");
        Body = Body + (" <tr><td style=margin: 0px; padding: 0px 10px; font-family: Tahoma'; font-size: 13px; color: rgb(70, 83, 85); text-align: left;>  </td>  ");
        Body = Body + (" </tr></tbody></table>");
        Body = Body + (" <table align=center border=0 cellpadding=0 cellspacing=0 width=600> ");
        Body = Body + (" <tbody><tr><td valign=top><table border=0 cellpadding=0 cellspacing=0 width=100%>");
        Body = Body + (" <tbody><tr><td style=padding: 0px 10px; valign=top> ");
        Body = Body + (" <table style=font-family: Tahoma, 'Verdana';  border=0 cellpadding=10 cellspacing=0 width=100%> ");
        Body = Body + (" <tbody>");
        Body = Body + (" <tr><td></td></tr>");
        Body = Body + (" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1></h1></u>");
        Body = Body + (" ");
        Body = Body + (" <br/></td></tr> ");
        Body = Body + ("<tr>");
        Body = Body + (" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
        Body = Body + (" <table cellpadding=5 cellspacing=5 >");
        Body = Body + (" <tr>  <td align=left >");
        Body = Body + (" <b>Dear Admin</b>,<br/><br/>");
        Body = Body + (" Following tickets are under escalation as on " + strDate + " <br /><br />");
        Body = Body + (" Kindly view the details below <br /><br />");
        Body += GetGridviewData(grdconfirm);

        Body = Body + ("<br /><br /><br/>");
        Body = Body + ("<div class='text'><b>Thanks & Regards,</b><br />");
        Body = Body + ("Chetana Book Depot<br /></div>");
        Body = Body + (" </table>");
        Body = Body + (" </td></tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table>");
        Body = Body + (" </body>");
        Body = Body + (" </body>");
        Body = Body + (" </html>");
        SendMailLevel1(Body);
        lblMessage.Text = DateTime.Now.ToString();
    }
    public void SendMailLevel2()
    {
        strDate = dt.ToString("dddd, dd MMMM yyyy h:mm tt");
        String Body = "";
        Body = (" <HTML>");
        Body = Body + ("<style>*{margin:0 auto;padding:0 auto;}.text {color: #444; font-size: 18px;font-family:arial;}</style>");
        Body = Body + (" <body><table id=body_holder border=0 cellpadding=0 cellspacing=0 width=100%>");
        Body = Body + (" <tbody><tr><td>");
        Body = Body + (" <table bgcolor=#e1e7e8 border=0 cellpadding=0 cellspacing=0 width=100%> ");
        Body = Body + (" <tbody><tr><td><table align=center border=0 cellpadding=0 cellspacing=0 width=600>");
        Body = Body + (" <tbody>");
        Body = Body + (" <tr><td style=margin: 0px; padding: 0px 10px; font-family: Tahoma'; font-size: 13px; color: rgb(70, 83, 85); text-align: left;>  </td>  ");
        Body = Body + (" </tr></tbody></table>");
        Body = Body + (" <table align=center border=0 cellpadding=0 cellspacing=0 width=600> ");
        Body = Body + (" <tbody><tr><td valign=top><table border=0 cellpadding=0 cellspacing=0 width=100%>");
        Body = Body + (" <tbody><tr><td style=padding: 0px 10px; valign=top> ");
        Body = Body + (" <table style=font-family: Tahoma, 'Verdana';  border=0 cellpadding=10 cellspacing=0 width=100%> ");
        Body = Body + (" <tbody>");
        Body = Body + (" <tr><td></td></tr>");
        Body = Body + (" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1></h1></u>");
        Body = Body + (" ");
        Body = Body + (" <br/></td></tr> ");
        Body = Body + ("<tr>");
        Body = Body + (" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
        Body = Body + (" <table cellpadding=5 cellspacing=5 >");
        Body = Body + (" <tr>  <td align=left >");
        Body = Body + (" <b>Dear Admin</b>,<br/><br/>");
        Body = Body + (" Following tickets are under escalation as on " + strDate + " <br /><br />");
        Body = Body + (" Kindly view the details below <br /><br />");
        Body += GetGridviewData(gdLevel2);

        Body = Body + ("<br /><br /><br/>");
        Body = Body + ("<div class='text'><b>Thanks & Regards,</b><br />");
        Body = Body + ("Chetana Book Depot<br /></div>");
        Body = Body + (" </table>");
        Body = Body + (" </td></tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table>");
        Body = Body + (" </body>");
        Body = Body + (" </body>");
        Body = Body + (" </html>");
        SendMailLevel2(Body);
        lblMessage.Text = DateTime.Now.ToString();
    }
    public void SendMailLevel3()
    {

        strDate = dt.ToString("dddd, dd MMMM yyyy h:mm tt");
        String Body = "";
        Body = (" <HTML>");
        Body = Body + ("<style>*{margin:0 auto;padding:0 auto;}.text {color: #444; font-size: 18px;font-family:arial;}</style>");
        Body = Body + (" <body><table id=body_holder border=0 cellpadding=0 cellspacing=0 width=100%>");
        Body = Body + (" <tbody><tr><td>");
        Body = Body + (" <table bgcolor=#e1e7e8 border=0 cellpadding=0 cellspacing=0 width=100%> ");
        Body = Body + (" <tbody><tr><td><table align=center border=0 cellpadding=0 cellspacing=0 width=600>");
        Body = Body + (" <tbody>");
        Body = Body + (" <tr><td style=margin: 0px; padding: 0px 10px; font-family: Tahoma'; font-size: 13px; color: rgb(70, 83, 85); text-align: left;>  </td>  ");
        Body = Body + (" </tr></tbody></table>");
        Body = Body + (" <table align=center border=0 cellpadding=0 cellspacing=0 width=600> ");
        Body = Body + (" <tbody><tr><td valign=top><table border=0 cellpadding=0 cellspacing=0 width=100%>");
        Body = Body + (" <tbody><tr><td style=padding: 0px 10px; valign=top> ");
        Body = Body + (" <table style=font-family: Tahoma, 'Verdana';  border=0 cellpadding=10 cellspacing=0 width=100%> ");
        Body = Body + (" <tbody>");
        Body = Body + (" <tr><td></td></tr>");
        Body = Body + (" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1></h1></u>");
        Body = Body + (" ");
        Body = Body + (" <br/></td></tr> ");
        Body = Body + ("<tr>");
        Body = Body + (" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
        Body = Body + (" <table cellpadding=5 cellspacing=5 >");
        Body = Body + (" <tr>  <td align=left >");
        Body = Body + (" <b>Dear Admin</b>,<br/><br/>");
        Body = Body + (" Following tickets are under escalation as on " + strDate + " <br /><br />");
        Body = Body + (" Kindly view the details below <br /><br />");
        Body += GetGridviewData(gdLevel3);
        Body = Body + ("<br /><br /><br/>");
        Body = Body + ("<div class='text'><b>Thanks & Regards,</b><br />");
        Body = Body + ("Chetana Book Depot<br /></div>");
        Body = Body + (" </table>");
        Body = Body + (" </td></tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table></td>");
        Body = Body + (" </tr></tbody></table>");
        Body = Body + (" </body>");
        Body = Body + (" </body>");
        Body = Body + (" </html>");
        SendMailLevel3(Body);
        lblMessage.Text = DateTime.Now.ToString();
    }
    public void SendMailLevel1(String Body)
    {
        int result;
        MailMessage Msg = new MailMessage();
        Msg.From = new MailAddress("wecare@chetanapublications.com");
        Msg.To.Add(new MailAddress("accounts1@chetanapublications.com"));
        Msg.To.Add(new MailAddress("hitesh.vashi@chetanapublications.com"));
        Msg.To.Add(new MailAddress("vijaya.desai@chetanapublications.com"));
        Msg.To.Add(new MailAddress("abhishek.pawaskar@chetanapublications.com"));

 Msg.Bcc.Add(new MailAddress("n.shah12@gmail.com"));

        Msg.Subject = "Escalation Level 1";
        Msg.Body = Body;
        Msg.IsBodyHtml = true;
        string sSmtpServer = "";
       sSmtpServer = "mail.chetanapublications.com";
        SmtpClient smtp = new SmtpClient();
        smtp.Host = sSmtpServer;
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("wecare@chetanapublications.com", "we0504260");
        smtp.EnableSsl = false;
        try
        {
            smtp.Send(Msg);
            DataRow R;
            CMS _objCMS = new CMS();
            {
                DataTable DsCmsMail = new DataTable();
                DsCmsMail = CMS.Idv_Chetana_CMS_TKTESCALATE("Level1").Tables[0];
                if (DsCmsMail.Rows.Count != 0)
                {
                    for (int k = 0; k <= DsCmsMail.Rows.Count - 1; k++)
                    {
                        R = DsCmsMail.Rows[k];

                        
                            _objCMS.TktNumber = R[0].ToString();
                            _objCMS.CreatedBy = "Auto Mail";
                            _objCMS.IsActive = true;
                            _objCMS.Save_CMS_Email();
                    }
                }
                MessageBox(Constants.save);
            }
            lblMessage.Text = "Mail Sent";
            //Response.Redirect("Dashboard.aspx");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            //Response.Redirect("Dashboard.aspx");
        }

    }
    public void SendMailLevel2(String Body)
    {
        int result;
        MailMessage Msg = new MailMessage();
        Msg.From = new MailAddress("wecare@chetanapublications.com");
        Msg.To.Add(new MailAddress("accounts1@chetanapublications.com"));
        Msg.To.Add(new MailAddress("hitesh.vashi@chetanapublications.com"));
        Msg.To.Add(new MailAddress("vijaya.desai@chetanapublications.com"));
        Msg.To.Add(new MailAddress("abhishek.pawaskar@chetanapublications.com"));
        Msg.To.Add(new MailAddress("wecare@chetanapublications.com")); 
       
	  Msg.Bcc.Add(new MailAddress("n.shah12@gmail.com"));
        Msg.Subject = "Escalation Level 2";
        Msg.Body = Body;
        Msg.IsBodyHtml = true;
        string sSmtpServer = "";
         sSmtpServer = "mail.chetanapublications.com";
        SmtpClient smtp = new SmtpClient();
        smtp.Host = sSmtpServer;
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("wecare@chetanapublications.com", "we0504260");
        smtp.EnableSsl = false;
        try
        {
            smtp.Send(Msg);
            DataRow R;
            CMS _objCMS = new CMS();
            {
                DataTable DsCmsMail = new DataTable();
                DsCmsMail = CMS.Idv_Chetana_CMS_TKTESCALATE("Level2").Tables[0];
                if (DsCmsMail.Rows.Count != 0)
                {
                    for (int k = 0; k <= DsCmsMail.Rows.Count - 1; k++)
                    {
                        R = DsCmsMail.Rows[k];


                        _objCMS.TktNumber = R[0].ToString();
                        _objCMS.CreatedBy = "Auto Mail";
                        _objCMS.IsActive = true;
                        _objCMS.Save_CMS_Email();
                    }
                }
                MessageBox(Constants.save);
            }
            lblMessage.Text = "Mail Sent";
            //Response.Redirect("Dashboard.aspx");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            //Response.Redirect("Dashboard.aspx");
        }

    }
    public void SendMailLevel3(String Body)
    {
        int result;
        MailMessage Msg = new MailMessage();
        Msg.From = new MailAddress("wecare@chetanapublications.com");
        Msg.To.Add(new MailAddress("accounts1@chetanapublications.com"));
        Msg.To.Add(new MailAddress("hitesh.vashi@chetanapublications.com"));
        Msg.To.Add(new MailAddress("vijaya.desai@chetanapublications.com"));
        Msg.To.Add(new MailAddress("abhishek.pawaskar@chetanapublications.com"));
        Msg.To.Add(new MailAddress("wecare@chetanapublications.com"));
        Msg.To.Add(new MailAddress("rakesh@chetanapublications.com"));
     
 Msg.Bcc.Add(new MailAddress("n.shah12@gmail.com"));

        Msg.Subject = "Escalation Level 3";
        Msg.Body = Body;
        Msg.IsBodyHtml = true;
        string sSmtpServer = "";
        sSmtpServer = "mail.chetanapublications.com";
        SmtpClient smtp = new SmtpClient();
        smtp.Host = sSmtpServer;
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("wecare@chetanapublications.com", "we0504260");
        smtp.EnableSsl = false;
        try
        {
            smtp.Send(Msg);
            DataRow R;
            CMS _objCMS = new CMS();
            {
                DataTable DsCmsMail = new DataTable();
                DsCmsMail = CMS.Idv_Chetana_CMS_TKTESCALATE("Level3").Tables[0];
                if (DsCmsMail.Rows.Count != 0)
                {
                    for (int k = 0; k <= DsCmsMail.Rows.Count - 1; k++)
                    {
                        R = DsCmsMail.Rows[k];


                        _objCMS.TktNumber = R[0].ToString();
                        _objCMS.CreatedBy = "Auto Mail";
                        _objCMS.IsActive = true;
                        _objCMS.Save_CMS_Email();
                    }
                }
                MessageBox(Constants.save);
            }
            lblMessage.Text = "Mail Sent";
            
            //Response.Redirect("Dashboard.aspx");
        }
        catch (Exception ex)
        {
Response.Write( ex.Message);
Response.End();
            lblMessage.Text = ex.Message;
           //Response.Redirect("Dashboard.aspx");
        }

    }
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    public string GetGridviewData(GridView gv)
    {
        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);
        gv.RenderControl(htw);
        return strBuilder.ToString();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}