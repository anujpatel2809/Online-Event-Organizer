using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class MailSend
    {
        const string sender = "devlopers.eventorganizer@gmail.com";
        const string pass = "7405981398";
        public static void SendMail(string to,string subject,string body)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();


           msg.From = new MailAddress(sender);
            
            msg.IsBodyHtml = true;
            msg.To.Add(to);
           
            msg.Body = body;
            msg.Subject = subject;
            SmtpClient smt = new SmtpClient("smtp.gmail.com");
            smt.Port = 587;
            smt.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smt.Credentials = new NetworkCredential(sender, pass);
            smt.EnableSsl = true;
          
            smt.Send(msg);
          
        }
    }
}
