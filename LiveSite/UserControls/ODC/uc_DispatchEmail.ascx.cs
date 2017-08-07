using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using Idv.Chetana.BAL;
using System.Text;
using System.Net.Mail;

public partial class UserControls_ODC_uc_DispatchEmail : System.Web.UI.UserControl
{
    #region Variables

   string flag1;
    string strChetanaCompanyName = "cppl";
    string strFY;
    string UserName = string.Empty;
    string CustName = string.Empty;
    string DocumentNo = string.Empty;
    string InvoiceNo = string.Empty;
    
    string EmailID = string.Empty;
    string POD = string.Empty;
    string DCNo;
    string PODId;
    string Trasporter;
    string NO_OF_BUNDLES;
    string LR_No;
    string LR_Date;
    int SCD;
    String mToID;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
            else
            {
                Session.Clear();
            }
           

        }

        if (!Page.IsPostBack)
        {
            onNotPostback();
            lblDocNo.Text = "0";
        }

        
    }
    public void fillEditFormO()
    {
        ClearO();
        DataSet ds = G_GetPass.GetDispatchEmail(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "O", Convert.ToInt32(strFY));
        gvOL.DataSource = ds;
        gvOL.DataBind();
        for(int i = 0; i <= ds.Tables[0].Rows.Count - 1;i++)
        {
            if (ds.Tables[0].Rows[i]["EmailID"].ToString() == "")
            {
                Save.Visible = false;
            }
            else
            {
                Save.Visible = true;
            }
        }
    }

    public void fillEditFormL()
    {
        ClearL();
        DataSet ds = G_GetPass.GetDispatchEmail(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "L", Convert.ToInt32(strFY));
        DataTable dt = ds.Tables[0];
            for(int i = 0; i <= ds.Tables[0].Rows.Count - 1;i++)
        {
//changed from table 0 to table 1 
            if (ds.Tables[1].Rows[i]["EmailID"].ToString() == "")
            {
                Save.Visible = false;
            }
            else
            {
                Save.Visible = true;
            }
        }
        filltempData(ds.Tables[1]);
      
    }
    public void filltempData(DataTable dt)
    {

        Session["getpasstempdata"] = dt;
        gvOL.DataSource = dt;
        gvOL.DataBind();

    }
    public void onNotPostback()
    {
    }
    public void ClearO()
    {
        lblDocNo.Text = "0";
    }
    public void ClearL()
    {
        lblDocNo.Text = "0";
        Session["getpasstempdata"] = null;
    }
    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        pnlDetailsGridOL.Visible = true;
        
        if (rdoOL.SelectedValue == "O")
        {
            fillEditFormO();
        }
        else
        {

            fillEditFormL();
        }
    }

    protected void rdoOL_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdoOL.SelectedValue == "O")
        {
        
        }
        else
        {
           
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        
        try
        {
            CourierDetails _objCD = new CourierDetails();
            _objCD.SaveDispatchEmailDetails(Convert.ToInt32(txtDocIdEdit.Text.Trim()), "O", Convert.ToInt32(strFY), Convert.ToString(Session["UserName"]), out SCD);
           
            SendEmailJob();

        }
        catch { }
    }

    public void SendEmailJob()
    { 
     String ToId = "n.shah12@gmail.com";
     for (int i = 0; i <= gvOL.Rows.Count - 1; i++)
     {
        
             System.Web.UI.WebControls.Label Wb1 = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[3].Controls[1];
              mToID = Wb1.Text;
             System.Web.UI.WebControls.Label WBCourierId = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[1].Controls[1];
             String mCourierID = WBCourierId.Text;
             System.Web.UI.WebControls.Label WBDocumentNo = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[1].Controls[1];
             String mDocumentNo = WBDocumentNo.Text;
          
             //DataSet DsMailLog = new DataSet();
             //DsMailLog = CourierDetails.SendDispatchEmail(SCD, float.Parse(mDocumentNo), "DispatchEmail", "DispatchId", Convert.ToInt32(strFY), MFromID, MPwd, Convert.ToString(Session["UserName"]));
             
             if (mToID.Length > 0)
             {
                 SendEmail(mToID,mDocumentNo, i);

             }
        
     }
    
    }
    public void SendEmail(string email, string mDocumentNo, int i)
    {
        
        try
        {
             MailMessage msg = new MailMessage();
           // msg.From = new MailAddress("wecare@chetanapublications.com");
            
            String MFromID = ConfigurationManager.AppSettings["FromMail"].ToString();
             String MPwd = ConfigurationManager.AppSettings["Password"].ToString();

             msg.From = new MailAddress(ConfigurationManager.AppSettings["FromMail"].ToString());
            msg.To.Add(new MailAddress("accounts1@chetanapublications.com"));
            msg.To.Add(new MailAddress(mToID));
           
            msg.Subject = "Chetana Book Depot";
            msg.Body = MailBodyDesign(i).ToString();
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString()); 
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(MFromID, MPwd);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Enablessl"].ToString());
            try
            {
                smtp.Send(msg);
                 DataSet DsMailLog = new DataSet();
                DsMailLog = CourierDetails.SendDispatchEmail(SCD, float.Parse(mDocumentNo), "DispatchEmail", "DispatchId", Convert.ToInt32(strFY),
                    MFromID, MPwd, Convert.ToString(Session["UserName"]));
                MessageBox("Mail Sent successfully");
             
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message);
            }

           
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }
         #region MailBody

         public StringBuilder MailBodyDesign(int j)
         {
             int i = 0;
             i = j;
             System.Web.UI.WebControls.Label WbDocumentNo = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[0].Controls[1];
             DocumentNo = WbDocumentNo.Text;
                 System.Web.UI.WebControls.Label WbCourierID = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[1].Controls[1];
                 DCNo = WbCourierID.Text;
                 
                 System.Web.UI.WebControls.Label WbInvoiceNo = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[3].Controls[1];
                 InvoiceNo = WbInvoiceNo.Text;
                 System.Web.UI.WebControls.Label WbCustName = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[2].Controls[1];
                 CustName = WbCustName.Text;
                 System.Web.UI.WebControls.Label WbEmailID = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[3].Controls[1];
                 EmailID = WbEmailID.Text;
                 System.Web.UI.WebControls.Label WbTrasporter = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[4].Controls[1];
                 Trasporter = WbTrasporter.Text;
                 System.Web.UI.WebControls.Label WbNO_OF_BUNDLES = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[5].Controls[1];
                 NO_OF_BUNDLES = WbNO_OF_BUNDLES.Text;
                 System.Web.UI.WebControls.Label WbLR_No = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[6].Controls[1];
                 LR_No = WbLR_No.Text;
                 System.Web.UI.WebControls.Label WbLR_Date = (System.Web.UI.WebControls.Label)gvOL.Rows[i].Cells[7].Controls[1];
                 LR_Date = WbLR_Date.Text;
             StringBuilder stBody = new StringBuilder();
             stBody.Append(" <HTML>");
             stBody.Append(" <body><table id=body_holder border=0 cellpadding=0 cellspacing=0 width=100%>");
             stBody.Append(" <tbody><tr><td>");
             stBody.Append(" <table bgcolor=#e1e7e8 border=0 cellpadding=0 cellspacing=0 width=100%> ");
             stBody.Append(" <tbody><tr><td><table align=center border=0 cellpadding=0 cellspacing=0 width=600>");
             stBody.Append(" <tbody>");
             stBody.Append(" <tr><td style=margin: 0px; padding: 0px 10px; font-family: Tahoma'; font-size: 11px; color: rgb(70, 83, 85); text-align: left;>  </td>  ");
             stBody.Append(" </tr></tbody></table>");
             stBody.Append(" <table align=center border=0 cellpadding=0 cellspacing=0 width=600> ");
             stBody.Append(" <tbody><tr><td valign=top><table border=0 cellpadding=0 cellspacing=0 width=100%>");
             stBody.Append(" <tbody><tr><td style=padding: 0px 10px; valign=top> ");
             stBody.Append(" <table style=font-family: Tahoma, 'Verdana';  border=0 cellpadding=10 cellspacing=0 width=100%> ");
             stBody.Append(" <tbody>");
             stBody.Append(" <tr><td></td></tr>");
             stBody.Append(" <tr>  <td align=center  style=background-color:#8B7D6B;color:White;><u><h1>Chetana Book Depot</h1></u>");
             stBody.Append(" 263-C, KHATAUWADI, GOREGAONKAR LANE, BEHIND CENTRAL CINEMA, GIRGAON MUMBAI");
             stBody.Append(" PHONES : 4342 50 00.  DATE OF INCORP-, 5TH OCT.1989 Fax No : 2382 19 10<br/></td></tr> ");
             stBody.Append("<tr>");
             stBody.Append(" <td colspan=2 align=center bgcolor=#d1d8db valign=top>");
             stBody.Append(" <table cellpadding=5 cellspacing=5 >");
             stBody.Append(" <tr>  <td align=left >");
             stBody.Append(" <b>Dear Customer</b>,<br/>");
             stBody.Append(" Thank you for your recent purchase.<br/>");
             stBody.Append(" We are delighted to inform you that your order has been processed & dispatched <br/>");
             stBody.Append(" by our team. <br/><br/> ");
             stBody.Append(" Below are the details of dispatch. <br/></td></tr> ");
             stBody.Append(" </table>");
             stBody.Append(" <table cellpadding=5 cellspacing=5 >");
             stBody.Append(" <tr>  <td align=left >");
             stBody.Append(" <tr><td><b>Customer Name :</b></td><td>" + CustName + "</td></tr> ");
             stBody.Append(" <tr><td><b> DC No :</b></td><td>" + DCNo + "</td></tr>");
             //stBody.Append(" <tr><td><b>Document No :</b></td><td>" + DocumentNo + "</td></tr> ");
             stBody.Append(" <tr><td><b>Trasporter :</b></td><td>" + Trasporter + "</td></tr> ");
             stBody.Append(" <tr><td><b>No of Parcels :</b></td><td>" + NO_OF_BUNDLES + "</td></tr>");
             stBody.Append(" <tr><td><b>LR No :</b></td><td>" + LR_No + "</td></tr> ");
             stBody.Append(" <tr><td><b>LR Date :</b></td><td>" + LR_Date + "</td></tr> ");
             stBody.Append(" </table>");
             stBody.Append(" </td></tr></tbody></table><br/></td>");
             stBody.Append(" </tr></tbody></table></td>");
             stBody.Append(" </tr></tbody></table></td>");
             stBody.Append(" </tr></tbody></table></td>");
             stBody.Append(" </tr></tbody></table>");
             stBody.Append(" </body>");
             stBody.Append(" </body>");
             stBody.Append(" </html>");

             return stBody;

         }

         #endregion
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
}