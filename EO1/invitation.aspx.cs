using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EO1
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        DataClasses1DataContext dc;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            dc = new DataClasses1DataContext();
            try
            {

                var invi = dc.Invitations.Where(p => p.MemberMailId == Session["email"].ToString() && p.status == 0);
                foreach (var v in invi)
                {
                    v.status = 1;
                }

                dc.SubmitChanges();

                String[] col = { "alert alert-success", "alert alert-info", "alert alert-warning", "alert alert-danger" };

                var q = from i in dc.Invitations
                        where i.MemberMailId == Session["email"].ToString() && (i.status == 1 || i.status == 0)
                        select new
                        {
                            i.EventId,
                            i.EventHeadId,
                            EventName = (from name in dc.Events
                                         where name.EventId == i.EventId
                                         select name.EName).Single(),
                            InviterName = (from name in dc.members
                                           where name.UserId == i.EventHeadId
                                           select name.Name).Single()
                        };
                int counter = 0;
                int j = 0;
                if (q == null)
                {
                    Label l = new Label();
                    l.Text="No Invitation";
                    invpanel.Controls.Add(l);
                }
                foreach (var v in q.ToList())
                {
                    Label l = new Label();
                    HtmlGenericControl div = new HtmlGenericControl("DIV");
                    div.ID = "DivInvitation" + j.ToString();
                    div.Attributes["class"] = col[(counter++) % 4];
                    l.Text = v.InviterName + " invites you to join " + v.EventName + " event.";
                    Button b = new Button();
                    b.ID = "Invitation" + j.ToString();
                    j++;
                    b.Text = "Accept";
                    b.CssClass = "btn btn-success rightbutton";
                    b.CommandArgument = v.EventId + "$" + v.EventHeadId;

                   
                    b.Attributes["onclick"] = "invite_click";
                    b.Attributes["runat"] = "server";

                    b.Command += invite_click;
                    div.Controls.Add(l);
                    div.Controls.Add(b);
                    invpanel.Controls.Add(div);
                }
            }
            catch (Exception ex)
            {
                Label l = new Label();
                l.Text = "Something Went Wrong...";
                message.Controls.Add(l);
            }
        }
       protected void  invite_click(object sender, CommandEventArgs e)
        {
            string[] id=e.CommandArgument.ToString().Split('$');
            Invitation invitation = dc.Invitations.Single(p => p.EventId == int.Parse(id[0]) && p.EventHeadId == int.Parse(id[1]) && p.MemberMailId==Session["email"].ToString());
            invitation.status = 20;
            var seqcounter = (from i in dc.Invitations
                              select i.SequenceNo).Max();
            invitation.SequenceNo = ++seqcounter;
            
            dc.SubmitChanges();
            ((Button)sender).Enabled = false;
           ((Button)sender).Text = ((char)0x2705).ToString()+" Accepted";
          
        }
    }
}