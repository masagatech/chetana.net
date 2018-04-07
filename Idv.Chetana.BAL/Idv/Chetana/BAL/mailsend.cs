namespace Idv.Chetana.BAL
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;

    public class mailsend
    {
        public static void sendmail(string subject, string tomail, string body)
        {
            SmtpClient client = new SmtpClient {
                Host = ConfigurationManager.AppSettings["SMTP"].ToString(),
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Enablessl"].ToString()),
                Credentials = new NetworkCredential("wecare@chetanapublications.com", "cbdcppl@2014"),
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString())
            };
            MailAddress from = new MailAddress("wecare@chetanapublications.com");
            MailAddress to = new MailAddress("rupeshswain32@gmail.com");
            MailMessage message = new MailMessage(from, to);
            message.Bcc.Add(new MailAddress("rupesh@technople.com"));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            client.Send(message);
        }
    }
}

