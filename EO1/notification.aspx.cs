using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm9 : System.Web.UI.Page
    {
       DataClasses1DataContext dc = new DataClasses1DataContext();
        String[] col = { "alert alert-success", "alert alert-info", "alert alert-warning", "alert alert-danger" };
        protected void Page_Load(object sender, EventArgs e)
        {
            var unread2read = dc.Invitations.Where(p => p.EventHeadId== int.Parse(Session["UserId"].ToString()) && p.status == 20);
            foreach (var v in unread2read)
            {
                v.status = 21;
            }
            var taskid = dc.Managements.Where(p => p.MemberId == int.Parse(Session["UserId"].ToString()));
            foreach (var v in taskid.ToList())
            {
                var invi = dc.Tasks.Where(p => v.TaskId == p.TaskId && p.NStatus == 0);
                foreach (var v1 in invi)
                {
                    v1.NStatus = 1;
                }
            }
           
            dc.SubmitChanges();
            
           var q = (from i in dc.Invitations
                    where i.EventHeadId == int.Parse(Session["UserId"].ToString()) && i.status == 21 
                    orderby i.SequenceNo descending
                    select new
                    {
                       EventName = (from name in dc.Events
                                     where name.EventId == i.EventId
                                     select name.EName).Single(),
                        InviteeName = (from name in dc.members
                                       where name.Email == i.MemberMailId
                                       select name.Name).Single()
                    });
            int counter = 0;
             
            foreach (var v in q.ToList())
            {
                Label l = new Label();
                HtmlGenericControl div = new HtmlGenericControl("DIV");
               
                div.Attributes["class"] = col[(counter++) % 4];
                l.Text = v.InviteeName + " has accepted your invitation for " + v.EventName + " event.";
                
                div.Controls.Add(l);
                invitationnoti.Controls.Add(div);
            }

            //Task Asign
            var tasknoti = from i in dc.Managements
                      where i.MemberId == int.Parse(Session["UserId"].ToString())
                      orderby i.TaskId descending
                      select new
                      {
                          i.EventHeadId,
                          i.TaskId,
                          headname=(from name in dc.members
                                   where name.UserId==i.EventHeadId
                                   select name.Name).Single(),
                          tname =(from n in dc.Tasks
                                where n.TaskId == i.TaskId 
                                select n.TaskName).Single()
                      };
            foreach (var v in tasknoti)
            {
                    Label l = new Label();
                    HtmlGenericControl div = new HtmlGenericControl("DIV");

                    div.Attributes["class"] = col[(counter++) % 4];
                    l.Text = v.headname + " assigned " + v.tname + " to you.";

                    div.Controls.Add(l);
                    notification.Controls.Add(div);
            }
                    
        }
    }
}