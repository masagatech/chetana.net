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

public partial class SendEmail : System.Web.UI.Page
{
    string strChetanaCompanyName = "cppl";
    string strFY;
    string id;
    string mailid;
    string smailid;
    string d;
    string sd;
    public Boolean mFlag = true;
    protected void Page_Load(object sender, EventArgs e)
    {

        mailid = Request.QueryString["mailid"].ToString();
        smailid = Request.QueryString["smailid"].ToString();
        d = Request.QueryString["d"].ToString();
        sd = Request.QueryString["sd"].ToString();
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!IsPostBack)
        {
            BindGridview();
            SendMail();
        }
    }
    protected void BindGridview()
    {

        DataSet ds = new DataSet();
        grdconfirm.DataSource = DCDetails.Idv_Get_DCDetails_By_DocNo(Convert.ToInt32(id), "allbydocno", Convert.ToInt32(strFY)).Tables[0];
        grdconfirm.DataBind();
    }
    public void SendMail()
    {

        string ToId = "n.shah12@gmail.com";
        string CcId = "";
        string Sub = "";
        string Body = "";
        string DocumentNo = "";
        string DocumentDate = "";
        string OrderNo = "";
        string OrderDate = "";
        string Address = "";
        string Transporter = "";
        string PIncharge = "";
        string DeliveryDate = "";
        string SpInstruction = "";
        if (Request.QueryString["d"] != null && Request.QueryString["sd"] != null)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();

            ds = Idv.Chetana.BAL.ActualInvoiceDetails.Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno2(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()),
                Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()));
            ds2 = Idv.Chetana.BAL.ActualInvoiceDetails.Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno1(Convert.ToInt32(Request.QueryString["d"].ToString().Trim()),
                Convert.ToInt32(Request.QueryString["sd"].ToString().Trim()));

            DataView dv = new DataView(ds.Tables[0]);
            DataView dv1 = new DataView(ds2.Tables[0]);
            DocumentNo = ds.Tables[0].Rows[0]["DocumentNo1"].ToString();
            DocumentDate = ds.Tables[0].Rows[0]["DocumentDate"].ToString();
            OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
            OrderDate = ds.Tables[0].Rows[0]["OrderDate"].ToString();
            Address = ds.Tables[0].Rows[0]["Address"].ToString();
            Transporter = ds.Tables[0].Rows[0]["Transporter"].ToString();
            PIncharge = ds.Tables[0].Rows[0]["PIncharge"].ToString();
            DeliveryDate = ds2.Tables[0].Rows[0]["DeliveryDate"].ToString();
            SpInstruction = ds.Tables[0].Rows[0]["SpInstruction"].ToString();
            grdconfirm.DataSource = ds2;
            grdconfirm.DataBind();
        }
        Body = getEmailBody(Address, DocumentNo, DocumentDate, OrderNo, OrderDate, Transporter, PIncharge, DeliveryDate, SpInstruction);
        Body += GetGridviewData(grdconfirm);

        Body = Body + ("<br />Please feel free to contact us if any<br /><br/>");
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
        SendMail(Body);
        lblMessage.Text = DateTime.Now.ToString();
    }
    public static String getEmailBody(string Address, string DocumentNo, string DocumentDate, string OrderNo, string OrderDate, string Transporter, string PIncharge, string DeliveryDate, string SpInstruction)
    {
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
        Body = Body + (" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1>Chetana Book Depot</h1></u>");
        Body = Body + (" 263-C, KHATAUWADI, GOREGAONKAR LANE, BEHIND CENTRAL CINEMA, GIRGAON MUMBAI");
        Body = Body + (" PHONES : 4342 50 00.  DATE OF INCORP-, 5TH OCT.1989 Fax No : 2382 19 10<br/></td></tr> ");
        Body = Body + ("<tr>");
        Body = Body + (" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
        Body = Body + (" <table cellpadding=5 cellspacing=5 >");
        Body = Body + (" <tr>  <td align=left >");
        Body = Body + (" <b>Dear Customer</b>,<br/><br/>");
        Body = Body + ("Thank you for your order. Your D.C. NO. is " + DocumentNo + " <br />");
        Body = Body + ("We will process it shortly & send the same at given destination.<br/><br/>");
        Body = Body + ("For your reference, here are the details of your order<br /><br />  ");


        return Body;
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
    public void SendMail(String Body)
    {
        int result;
        MailMessage Msg = new MailMessage();
        Msg.From = new MailAddress("wecare@chetanapublications.com");
        Msg.To.Add(new MailAddress(mailid));
        Msg.To.Add(new MailAddress(smailid));
        Msg.To.Add(new MailAddress("n.shah12@gmail.com"));

        //Msg.Bcc.Add(new MailAddress("accounts1@chetanapublications.com"));


        Msg.Subject = "Pending DC";
        Msg.Body = Body;
        Msg.IsBodyHtml = true;
        string sSmtpServer = "";
        sSmtpServer = ConfigurationManager.AppSettings["SMTP"].ToString();
        SmtpClient smtp = new SmtpClient();
        smtp.Host = sSmtpServer;
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
        smtp.EnableSsl = false;
        try
        {
            smtp.Send(Msg);
            DCMaster _objDCMaster = new DCMaster();
            if (Convert.ToInt32(d) != 0)
            {
                _objDCMaster.DocNo = Convert.ToInt32(d);
                _objDCMaster.CreatedBy = Convert.ToString(Session["UserName"]);
                _objDCMaster.IsActive = true;
                _objDCMaster.Save_DC_Email();
                MessageBox(Constants.save);
            }
            lblMessage.Text = "Mail Sent";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
}