using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class forgotpass : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reset_Click(object sender, EventArgs e)
        {
            Label l = new Label();
            try
            {
                var exsistancemail = (from m in dc.ForgotPasses
                                      where m.Email == email.Text
                                      select m).Single();
                string sub = "Reset Password";
                string msg = "Click On below link to reset Password<br/>" +
                    "<a href=\"http://localhost:50820/resetpass.aspx?id=" + Encryption_Decryption.security.passwordEncrypt(exsistancemail.UserId.ToString()) + "&key=" +
                Encryption_Decryption.security.passwordEncrypt(exsistancemail.Pass.ToString()) + "\">Click here</a>";

                Mail.MailSend.SendMail(email.Text, sub, msg);

                l.Text = "Reset Mail is sent.";
                panel.Controls.Add(l);
            }
            catch (Exception ex)
            {
                try
                {
                    var exsistance = (from m in dc.members
                                      where m.Email == email.Text
                                      select m.UserId).Single();

                    Random r = new Random();
                    int re = r.Next(100000, 1000000000);

                    string sub = "Reset Password";
                    string msg = "Click On below link to reset Password<br/>" +
                        "<a href=\"http://localhost:50820/resetpass.aspx?id=" + Encryption_Decryption.security.passwordEncrypt(exsistance.ToString()) + "&key=" +
                    Encryption_Decryption.security.passwordEncrypt(re.ToString()) + "\">Click here</a>";

                    Mail.MailSend.SendMail(email.Text, sub, msg);

                    ForgotPass f = new ForgotPass();
                    f.Email = email.Text;
                    f.UserId = exsistance;
                    f.Pass = re;
                    dc.ForgotPasses.InsertOnSubmit(f);
                    dc.SubmitChanges();

                    l.Text = "Reset Mail is sent.";
                    panel.Controls.Add(l);
                }
                catch (System.Net.Mail.SmtpException ex1)
                {
                    l.Text = "Mail not sent,Check Your Internet Connection.";
                    panel.Controls.Add(l);
                }
                catch (Exception ex1)
                {
                    l.Text = "Account is not registered";
                    panel.Controls.Add(l);
                    //email is not registered
                }
            }
        }
        
    }
}