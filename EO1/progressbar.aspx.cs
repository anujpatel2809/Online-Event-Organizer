using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        String[] color = { "progress-bar", "progress-bar progress-bar-danger progress-bar-striped active",
                             "progress-bar progress-bar-info progress-bar-striped active",
                             "progress-bar progress-bar-warning progress-bar-striped active",
                              "progress-bar progress-bar-success progress-bar-striped active"};
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var ev = (from eventid in dc.Managements
                     where eventid.EventHeadId == int.Parse(Session["UserId"].ToString())
                     orderby eventid.EventId ascending
                     select eventid.EventId).Distinct();
            
                int counter = 1;
                foreach (var v in ev.ToList())
                {
                    counter = 1;
                    var eventname = (from eve in dc.Events
                                     where eve.EventId == v
                                     select eve.EName).Single();
                    var tasklist = (from task in dc.Managements
                                    where task.EventId == v && task.EventHeadId == int.Parse(Session["UserId"].ToString())
                                    select new
                                    {
                                        tasks = from t in dc.Tasks
                                                where t.TaskId == task.TaskId
                                                select t
                                    }).ToList();
                    HtmlGenericControl mpanel = new HtmlGenericControl("DIV");
                    mpanel.Attributes["class"] = "panel panel-primary";
                    HtmlGenericControl phading = new HtmlGenericControl("DIV");
                    phading.Attributes["class"] = "panel-heading";
                    HtmlGenericControl div3 = new HtmlGenericControl("DIV");
                    div3.Attributes["class"] = "table-responsive";
                    Label tname = new Label();
                    tname.Text = eventname;
                    phading.Controls.Add(tname);

                    Table table = new Table();
                    table.Attributes.Add("class", "table table-hover");
                    TableHeaderRow hr = new TableHeaderRow();
                    TableHeaderCell hno = new TableHeaderCell();
                    hno.Text = "#";
                    TableHeaderCell htname = new TableHeaderCell();
                    htname.Text = "Task";
                    TableHeaderCell progress = new TableHeaderCell();
                    progress.Text = "Progress";

                    hr.Controls.Add(hno);
                    hr.Controls.Add(htname);
                    hr.Controls.Add(progress);
                    table.Rows.Add(hr);

                    foreach (var list in tasklist)
                    {
                        TableRow r = new TableRow();
                        TableCell no = new TableCell();
                        TableCell taskname = new TableCell();
                        TableCell pro = new TableCell();

                        no.Text = (counter++).ToString();
                        r.Attributes["CssClass"] = "list-group-item-success";
                        taskname.Text = list.tasks.ToList()[0].TaskName;

                        HtmlGenericControl pdiv = new HtmlGenericControl("DIV");
                        pdiv.Attributes["class"] = "progress";
                        HtmlGenericControl ptype = new HtmlGenericControl("DIV");
                        ptype.Attributes["class"] = color[list.tasks.ToList()[0].TStatus];
                        ptype.Attributes["role"] = "progressbar";
                        ptype.Attributes["aria-valuenow"] = (list.tasks.ToList()[0].TStatus * 25).ToString();
                        ptype.Attributes["aria-valuemin"] = "0";
                        ptype.Attributes["aria-valuemax"] = "100";
                        ptype.Attributes["style"] = "width:" + (list.tasks.ToList()[0].TStatus * 25).ToString() + "%";
                        Label plable = new Label();
                        plable.Text = (list.tasks.ToList()[0].TStatus * 25).ToString() + "%";

                        ptype.Controls.Add(plable);
                        pdiv.Controls.Add(ptype);
                        pro.Controls.Add(pdiv);

                        r.Cells.Add(no);
                        r.Cells.Add(taskname);
                        r.Cells.Add(pro);
                        table.Rows.Add(r);

                    }

                    div3.Controls.Add(table);
                    mpanel.Controls.Add(phading);
                    mpanel.Controls.Add(div3);
                    divpanel.Controls.Add(mpanel);
                }
           
        }
    }
}