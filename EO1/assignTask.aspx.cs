using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm10 : System.Web.UI.Page
    {

        DataClasses1DataContext dc = new DataClasses1DataContext();
        Label l = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            message.Attributes["class"] = "";
            if (!IsPostBack)
            {
                ddate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                try
                {
                    var q = from m in dc.Events
                            where m.UserId.ToString() == Session["UserId"].ToString()
                            select new
                            {
                                m.EName,
                                m.EventId
                            };
                    
                    eventlist.Items.Add(new ListItem("----Select Event---", ""));
                    foreach (var v in q)
                    {
                        eventlist.Items.Add(new ListItem(v.EName, v.EventId.ToString()));
                    }
                    

                }
                catch (Exception ex)
                {

                    l.Text = "Something Went Wrong Please Try Again Later...";
                    message.Attributes["class"] = "alert alert-danger";
                    message.Controls.Add(l);
                }
               
            }
        }
        protected void ddate_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == false)
            {

                Calendar1.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
           
            ddate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }
        protected void eventlist_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (eventlist.SelectedItem.ToString() != "----Select Event---")
            {

                memberlist.Items.Clear();
                try
                {

                    var q = from list in dc.Invitations
                            where list.EventId == int.Parse(eventlist.SelectedValue) && list.EventHeadId == int.Parse(Session["UserId"].ToString()) && (list.status == 20 || list.status == 21)
                            select new
                            {
                                memberName = from name in dc.members
                                             where name.Email == list.MemberMailId
                                             select new
                                             {
                                                 name.Name,
                                                 name.UserId
                                             }
                            };


                    foreach (var v in q)
                    {
                        
                        memberlist.Items.Add(new ListItem((v.memberName.ToList())[0].Name, (v.memberName.ToList())[0].UserId.ToString()));
                    }
                }
                catch (Exception ex)
                {
        
                    l.Text = ex.ToString();
                    message.Attributes["class"] = "alert alert-danger";
                    message.Controls.Add(l);
                }
            }
            else
            {
                memberlist.Items.Clear();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void taskbutton_Click(object sender, EventArgs e)
        {
            int q=0;
            try
            {
                var mailid = (from mail in dc.members
                              where mail.UserId == int.Parse(memberlist.SelectedValue)
                              select mail.Email).Single();
                String sub = "New Task Assignment";
                String body = Session["Uname"].ToString() + " assigned " + taskname.Text + " task to you." + "\n" +
                    "Task Description : \n" +
                    "\t\t" + task.Text + "\n" +
                    "Task Deadline : " + ddate.Text;
                Mail.MailSend.SendMail(mailid, sub, body);

                Task t = new Task();
                t.TaskName = taskname.Text;
                t.Description = task.Text;
                t.TStatus = 0;
                t.Deadline = Calendar1.SelectedDate;
                t.NStatus = 0;
                dc.Tasks.InsertOnSubmit(t);
                dc.SubmitChanges();

                 q = (from taskid in dc.Tasks
                         select taskid.TaskId).Max();
                Management m = new Management();
                m.EventId = int.Parse(eventlist.SelectedValue);
                m.EventHeadId = int.Parse(Session["UserId"].ToString());
                m.MemberId = int.Parse(memberlist.SelectedValue);
                m.TaskId = q;
                dc.Managements.InsertOnSubmit(m);
                dc.SubmitChanges();



                l.Text = "Task Assigned Successfully to " + memberlist.SelectedItem;
                message.Attributes["class"] = "alert alert-success";
                message.Controls.Add(l);
                taskname.Text = "";
                task.Text = "";
                Calendar1.SelectedDate = DateTime.Now;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Task t = new Task();
                t.TaskName = taskname.Text;
                t.Description = task.Text;
                t.TStatus = 0;
                t.Deadline = Calendar1.SelectedDate;
                t.NStatus = 0;
                dc.Tasks.InsertOnSubmit(t);
                dc.SubmitChanges();
                q = (from taskid in dc.Tasks
                     select taskid.TaskId).Max();
                Management m = new Management();
                m.EventId = int.Parse(eventlist.SelectedValue);
                m.EventHeadId = int.Parse(Session["UserId"].ToString());
                m.MemberId = int.Parse(memberlist.SelectedValue);
                m.TaskId = q;
                dc.Managements.InsertOnSubmit(m);
                dc.SubmitChanges();

                l.Text = "Mail was not Sent";// ex.ToString();
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