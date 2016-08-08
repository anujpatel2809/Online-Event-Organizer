using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class verifyemail : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["VerifyStatus"].ToString()) == 1)
            {
                Response.Redirect("~/welcome.aspx");
            }
            name.Text = Session["Uname"].ToString();
            buname.Text = Session["Uname"].ToString();
            email.Text = Session["email"].ToString();
            var image = (from d in dc.members
                         where d.UserId == int.Parse(Session["UserId"].ToString())
                         select d).ToList();
            if (image.ToList()[0].DisplayPic == null)
            {
                dp.ImageUrl = "~/Image/boy-512.png";
                udp.ImageUrl = "~/Image/boy-512.png";
                disp.ImageUrl = "~/Image/boy-512.png";
            }
            else
            {
                dp.ImageUrl = "~/ShowImage.ashx?id=" + Encryption_Decryption.security.passwordEncrypt(Session["UserId"].ToString());
                udp.ImageUrl = "~/ShowImage.ashx?id=" + Encryption_Decryption.security.passwordEncrypt(Session["UserId"].ToString());
                disp.ImageUrl = "~/ShowImage.ashx?id=" + Encryption_Decryption.security.passwordEncrypt(Session["UserId"].ToString());
            }
        }
        protected void Logout_Click(Object sender, EventArgs e)
        {

            Session["UserId"] = null;
            Response.Redirect("~/home.aspx");
        }

        protected void resendmail_Click(object sender, EventArgs e)
        {
            string sub = "Verify Email";
            string msg = "Click On below link to Verify Email.<br/>" +
                "<a href=\"http://localhost:50820/validatemail.aspx?id=" + Encryption_Decryption.security.passwordEncrypt(Session["UserId"].ToString()) + "&key=" +
            Encryption_Decryption.security.passwordEncrypt(Session["email"].ToString()) + "\">Click here</a>";

            Mail.MailSend.SendMail(Session["email"].ToString(), sub, msg);

        }

    }
}