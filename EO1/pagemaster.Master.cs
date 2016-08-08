using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class pagemaster : System.Web.UI.MasterPage
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/home.aspx");
            }
            //Email not Verifyed
            if (int.Parse(Session["VerifyStatus"].ToString()) == 0)
            {
                Response.Redirect("~/verifyemail.aspx");
            }
            
            Image img = (Image)FindControl("Image1");
            img.ImageUrl = "~/Image/users.png";
            name.Text = Session["Uname"].ToString();
            buname.Text = Session["Uname"].ToString();
            email.Text = Session["email"].ToString();

            //Notification No
            var q1 = (from i in dc.Invitations
                     where i.MemberMailId==Session["email"].ToString() && i.status == 0 
                     select i).Count();

            if (q1 == 0)
            {
                invi_no.Text = "";
            }
            else
            {
                invi_no.Text = q1.ToString();
            }

            //Total Notification Value
            var q2 = (from i in dc.Invitations
                     where i.EventHeadId==int.Parse(Session["UserId"].ToString()) && i.status == 20
                     select i).Count();
           /* if (q2 == 0)
            {
                noti_no.Text = "";
            }
            else
            {
                noti_no.Text = q2.ToString();
            }*/

            var q3 = from i in dc.Managements
                      where i.MemberId == int.Parse(Session["UserId"].ToString())
                      select new
                      {
                          num=(from n in dc.Tasks
                              where n.TaskId==i.TaskId && n.NStatus==0
                              select n ).Count()
                      };
            int count =0 ;  //Total Notification Counter
            foreach (var v in q3.ToList())
            {
                if (v.num != 0)
                {
                    count++;
                }
            }
            count += q2;
            if (count == 0)
            {
                noti_no.Text = "";
            }
            else
            {
                noti_no.Text = count.ToString();
                count = 0;
            }
            //For display DP
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

        protected void disp_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/profile.aspx");
        }
        protected void feedbackbutton_Click(object sender, EventArgs e)
        {
            String sub ="Feedback From "+ Session["Uname"].ToString();
            String msg = Session["Uname"].ToString() + "(" + Session["UserId"].ToString() + ") Give feedback about your site.<br>" +
                feedbacktext.Text;

            Mail.MailSend.SendMail("feedback.eventorganizer@gmail.com", sub, msg);
        }

      

       

        
    }
}