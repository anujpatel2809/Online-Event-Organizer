using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        int tid;
        String[] taskstatus = { "Not Started", "Just Started", "Half Complete", "Almost Complete", "Complete" };
        protected void Page_Load(object sender, EventArgs e)
        {
            tid =int.Parse(Encryption_Decryption.security.passwordDecrypt(Request.QueryString["i"]));
            
            try
            {
                var q = from tdetails in dc.Tasks
                        where tdetails.TaskId == tid
                        select tdetails;
                foreach (var v in q)
                {
                    task_name.Text = v.TaskName;
                    description.Text = v.Description;
                    status.Text = taskstatus[v.TStatus];
                    deadline.Text = v.Deadline.ToString("dd/MM/yyyy");
                    if (!IsPostBack)
                    {
                        tstatus.SelectedValue = v.TStatus.ToString();
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                Label l = new Label();
                l.Text = "Something Went Wrong Please Try Again Later...";
                message.Attributes["class"] = "alert alert-danger";
                message.Controls.Add(l);
            }
            
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Task t = dc.Tasks.Single(p => p.TaskId == tid);
            t.TStatus =int.Parse(tstatus.SelectedValue);
           
            int count = (from c in dc.Tasks
                         select c.SeqNo).Max();
            count++;
            t.SeqNo = count;
            dc.SubmitChanges();

            Label l = new Label();
            l.Text = "Status is Updated.";
            message.Attributes["class"] = "alert alert-success";
            message.Controls.Add(l);

            if (int.Parse(tstatus.SelectedValue) == 4)
            {
                try
                {
                    var ename = (from m in dc.Managements
                                 join ev in dc.Events on m.EventId equals ev.EventId
                                 join mem in dc.members on m.EventHeadId equals mem.UserId
                                 where m.TaskId == tid
                                 select new
                                 {
                                     ev.EName,
                                     mem.Email
                                 }).Single();
                    String sub = "Notification for task Completion.";
                    String msg = Session["Uname"].ToString() + " has successfully completed " + t.TaskName + " task of " + ename.EName + " event.";

                    Mail.MailSend.SendMail(ename.Email, sub, msg);
                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}