using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;

namespace EO1
{
    public class RemainderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            String sub = "Pending Task Remainder";
            String msg;
            try
            {
                var send = (from t in dc.Tasks
                            join m in dc.Managements on t.TaskId equals m.TaskId
                            join mem in dc.members on m.MemberId equals mem.UserId
                            join e in dc.Events on m.EventId equals e.EventId
                            where t.Deadline == (System.DateTime.Today.AddDays(+1)) && t.TStatus != 4
                            select new
                            {
                                mem.Email,
                                e.EName,
                                t.TaskName,
                            }).ToList();

                foreach (var v in send)
                {
                    msg = "you have one task "+v.TaskName+" pending of event "+v.EName+" to be completed by tomorrow.<br>"+
                        "For Complete your task please <a href=\"http://localhost:50820/home.aspx\">login</a>";
                    Mail.MailSend.SendMail(v.Email, sub, msg);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}