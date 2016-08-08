using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        String[] color = { "list-group-item-success", "list-group-item-danger", "list-group-item-info", "list-group-item-warning" };
        String[] taskstatus = {"Not Started","Just Started", "Half Complete","Almost Complete","Complete" };
        protected void Page_Load(object sender, EventArgs e)
        {
            var q = from task in dc.Managements
                    where task.EventHeadId == int.Parse(Session["UserId"].ToString())
                    select new
                    {
                        eventname = from ename in dc.Events
                                    where ename.EventId == task.EventId
                                    select ename.EName,
                        membername=from memname in dc.members
                                   where memname.UserId==task.MemberId
                                   select memname.Name,
                        taskdetails = from t in dc.Tasks
                                      where t.TaskId == task.TaskId
                                      select t
                    };
            int counter = 1;
            foreach (var v in q.ToList())
            {
                TableRow r = new TableRow();
                TableCell no = new TableCell();
                TableCell ename = new TableCell();
                TableCell tname = new TableCell();
                TableCell mname = new TableCell();
                TableCell deadline = new TableCell();
                TableCell status = new TableCell();

                r.Attributes["CssClass"] = "list-group-item-success";// color[counter % 4];
                no.Text = (counter++).ToString();
                ename.Text = v.eventname.ToList()[0].ToString();
                tname.Text = v.taskdetails.ToList()[0].TaskName;
                mname.Text = v.membername.ToList()[0].ToString();
                deadline.Text = v.taskdetails.ToList()[0].Deadline.ToString("dd/MM/yyyy");
                status.Text = taskstatus[v.taskdetails.ToList()[0].TStatus];

                r.Cells.Add(no);
                r.Cells.Add(ename);
                r.Cells.Add(tname);
                r.Cells.Add(mname);
                r.Cells.Add(deadline);
                r.Cells.Add(status);
                taskTable.Rows.Add(r);
            }
        }
    }
}