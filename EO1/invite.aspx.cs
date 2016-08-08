using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        Label l = new Label();
        DataClasses1DataContext dc=new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
           if(!IsPostBack)
           {
            try
            {
                var q = from m in dc.Events
                        where m.UserId.ToString() == Session["UserId"].ToString()
                        select new
                        {
                            m.EName,
                            m.EventId
                        };
                foreach (var v in q)
                {
                    event_list.Items.Add(new ListItem(v.EName, v.EventId.ToString()));
                }

            }
            catch(Exception ex)
            {
                
                l.Text = "Something Went Wrong Please Try Again Later...";
                message.Attributes["class"] = "alert alert-danger";
                message.Controls.Add(l);
            }
           }
        }

        protected void invite_Click(object sender, EventArgs e)
        {
             DataClasses1DataContext dc = new DataClasses1DataContext();
             try
             {
                 string q = (from I in dc.Invitations
                             where I.MemberMailId == email.Text && I.EventId==int.Parse(event_list.SelectedValue)
                             select I.Id.ToString()).Single();



                 l.Text = "You Already Send invitation to this member.";
                 message.Attributes["class"] = "alert alert-danger";
                 message.Controls.Add(l);

             }
             catch (InvalidOperationException i)
             {

                 String mess = null;
               
                 String sub = Session["Uname"] + " invites you to join an event named " + event_list.SelectedItem + ".";
                 try
                 {

                     var q = (from ev in dc.Events
                              where ev.EventId == int.Parse(event_list.SelectedValue)
                              select ev);
                     foreach (var v in q)
                     {
                         mess = "<style></style>" + "<h2>Dear User,</h2><br/><p>" +
                              Session["Uname"] + " invites you to join " + event_list.SelectedItem + " event.</p><br>" +
                              "<p>" + desc.Text + "</p><br>" +
                                                                 "<b>Event Details<b><br>" +
                                                              "<table border=\"1\">" +
                                          "<tr>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  "Event Name" +
                                              "</td >" +
                                              "<td style=\"padding-right:50px\">" +
                                                  v.EName +
                                              "</td >" +
                                          "</tr>" +
                                          "<tr>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  "Starting Date" +
                                              "</td>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  v.SDate.ToString("dd/MM/yyyy") +
                                              "</td>" +

                                          "</tr>" +
                                          "<tr>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  "Ending Date" +
                                              "</td>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  v.Edate.ToString("dd/MM/yyyy") +
                                              "</td>" +
                                          "</tr>" +
                                          "<tr>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  "Venue" +
                                              "</td>" +
                                              "<td style=\"padding-right:50px\">" +
                                                  v.Venue +
                                              "</td>" +
                                          "</tr>" +
                                          "<tr>" +
                                              "<td style=\"padding-right:20px;text-align:match-parent\">" +
                                                  "Description" +
                                              "</td>" +
                                              "<td>" +
                                                  v.Description +
                                              "</td>" +
                                          "</tr>" +
                                      "</table>" +
                                         "<br>" +
                          "To Join Event <a href=\"http://localhost:50820/home.aspx\">Click Here</a>";
                     }
                     Mail.MailSend.SendMail(email.Text, sub, mess);
                     l.Text = "Your invitation is sent.";
                     message.Attributes["class"] = "alert alert-success";
                     message.Controls.Add(l);


                     Invitation invitation = new Invitation();
                     invitation.EventId = int.Parse(event_list.SelectedValue);
                     invitation.EventHeadId = int.Parse(Session["UserId"].ToString());
                     invitation.MemberMailId = email.Text;
                     dc.Invitations.InsertOnSubmit(invitation);
                     dc.SubmitChanges();

                     email.Text = "";
                     desc.Text = "";


                 }
                 catch (System.Net.Mail.SmtpException ex)
                 {
                     l.Text = "Invitation Is Not Sent.";
                     message.Attributes["class"] = "alert alert-danger";
                     message.Controls.Add(l);
                 }
                 catch (Exception ex)
                 {
                     l.Text = ex.ToString();
                     message.Attributes["class"] = "alert alert-danger";
                     message.Controls.Add(l);
                 }
             }
        }
    }
}