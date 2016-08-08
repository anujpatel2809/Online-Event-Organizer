using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        String[] color = { "list-group-item-success", "list-group-item-danger", "list-group-item-info", "list-group-item-warning" };
        String[] taskstatus = { "Not Started", "Just Started", "Half Complete", "Almost Complete", "Complete" };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                var q = (from task in dc.Managements
                         where task.MemberId == int.Parse(Session["UserId"].ToString())
                         orderby task.EventId ascending
                         select task.EventId).Distinct();

               
                int counter = 1;
                foreach (var v in q.ToList())
                {
                    counter = 1;
                    var eventname = (from eve in dc.Events
                                     where eve.EventId == v
                                     select eve.EName).Single();
                    var tasklist = (from task in dc.Managements
                                    where task.EventId == v && task.MemberId == int.Parse(Session["UserId"].ToString())
                                    select new
                                    {
                                        tasks = from t in dc.Tasks
                                                where t.TaskId == task.TaskId
                                                select t
                                    }).ToList();
                    HtmlGenericControl div1 = new HtmlGenericControl("DIV");
                    div1.Attributes["class"] = "panel panel-primary";
                    HtmlGenericControl div2 = new HtmlGenericControl("DIV");
                    div2.Attributes["class"] = "panel-heading";
                    HtmlGenericControl div3 = new HtmlGenericControl("DIV");
                    div3.Attributes["class"] = "table-responsive";
                    Label tname = new Label();
                    tname.Text = eventname;
                    div2.Controls.Add(tname);

                    Table table = new Table();
                    table.Attributes.Add("class", "table table-striped table-bordered table-hover");
                    TableHeaderRow hr = new TableHeaderRow();
                    TableHeaderCell hno = new TableHeaderCell();
                    hno.Text = "#";
                    TableHeaderCell htname = new TableHeaderCell();
                    htname.Text = "Task";
                    TableHeaderCell hdeadline = new TableHeaderCell();
                    hdeadline.Text = "Deadline";
                    TableHeaderCell status = new TableHeaderCell();
                    status.Text = "Your Status";
                    TableHeaderCell more = new TableHeaderCell();
                    more.Text = " ";
                    hr.Controls.Add(hno);
                    hr.Controls.Add(htname);
                    hr.Controls.Add(hdeadline);
                    hr.Controls.Add(status);
                    hr.Controls.Add(more);
                    table.Rows.Add(hr);



                    foreach (var list in tasklist)
                    {


                        TableRow r = new TableRow();
                        TableCell no = new TableCell();
                        TableCell taskname = new TableCell();
                        TableCell deadline = new TableCell();
                        TableCell tstatus = new TableCell();
                        TableCell morel = new TableCell();

                        r.Attributes["CssClass"] = "list-group-item-success";// color[counter % 4];
                        no.Text = (counter++).ToString();

                        taskname.Text = list.tasks.ToList()[0].TaskName;
                        deadline.Text = list.tasks.ToList()[0].Deadline.ToString("dd/MM/yyyy");

                        tstatus.Text = taskstatus[list.tasks.ToList()[0].TStatus];


                        HyperLink link = new HyperLink();
                        link.NavigateUrl = "~/taskdetails.aspx?i=" + Encryption_Decryption.security.passwordEncrypt(list.tasks.ToList()[0].TaskId.ToString());
                        link.Text = "Details";
                        morel.Controls.Add(link);
                        r.Cells.Add(no);
                        r.Cells.Add(taskname);
                        r.Cells.Add(deadline);
                        r.Cells.Add(tstatus);
                        r.Cells.Add(morel);
                        table.Rows.Add(r);

                    }
                    div3.Controls.Add(table);
                    div1.Controls.Add(div2);
                    div1.Controls.Add(div3);
                    divpanel.Controls.Add(div1);

                }

                if (counter == 1)
                {
                    Label l = new Label();
                    l.Text = "Currently,you do not have any Task to do";
                    message.Attributes["class"] = "alert alert-success";
                    message.Controls.Add(l);
                }
            }
            catch (Exception ex)
            {

            }
        }
        

      
    }
}