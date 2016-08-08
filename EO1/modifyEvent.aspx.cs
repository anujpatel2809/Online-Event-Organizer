using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        
        Label l = new Label();
        String eid;
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            eid = Encryption_Decryption.security.passwordDecrypt(Request.QueryString["e"]);
            if (!IsPostBack)
            {
               
                try
                {
                    var q = from edetails in dc.Events
                            where edetails.EventId == int.Parse(eid)
                            select edetails;
                    foreach (var v in q)
                    {
                        event_name.Text = v.EName;
                        sdate.Text = v.SDate.ToString("dd/MM/yyyy");
                        Calendar1.SelectedDate = v.SDate;
                        edate.Text = v.Edate.ToString("dd/MM/yyyy");
                        Calendar2.SelectedDate = v.Edate;
                        venue.Text = v.Venue;
                        description.Text = v.Description;
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
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < System.DateTime.Today)
            {
                e.Day.IsSelectable = false;
                
                e.Cell.ForeColor = Color.Gray;
            }
        }
        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < Calendar1.SelectedDate)
            {
                e.Day.IsSelectable = false;
               
                e.Cell.ForeColor = Color.Gray;
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
            sdate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            if (Calendar1.SelectedDate > Calendar2.SelectedDate)
            {
                edate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
                Calendar2.SelectedDate = Calendar1.SelectedDate;
            }
            Calendar1.Visible = false;
         }


        protected void sdate_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == false)
            {

                Calendar1.Visible = true;
                Calendar2.Visible = false;

            }
            else
            {
               Calendar1.Visible = false;
            }
        }

        protected void edate_Click(object sender, EventArgs e)
        {
            if (Calendar2.Visible == false)
            {

                Calendar2.Visible = true;
                Calendar1.Visible = false;

            }
            else
            {
               Calendar2.Visible = false;
            }
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
           
            edate.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");

            
            Calendar2.Visible = false;
        }

        protected void ModifyEveB_Click(object sender, EventArgs e)
        {
            
            try
            {
                Event eve = dc.Events.Single(ev => ev.EventId == int.Parse(eid));
                eve.EName = event_name.Text;
                eve.SDate = Calendar1.SelectedDate;
                eve.Edate = Calendar2.SelectedDate;
                eve.Venue = venue.Text;
                eve.Description = description.Text;
              
                dc.SubmitChanges();
                
               
                message.Attributes["class"] = "alert alert-success";
               
                l.Text = "Event Updated";

                message.Controls.Add(l);
                Response.Redirect("~/viewdetails.aspx?e=" + Encryption_Decryption.security.passwordEncrypt(eid));



            }
            catch (Exception ex1)
            {
                message.Attributes["class"] = "alert alert-danger";
                l.Text = ex1.ToString();
                message.Controls.Add(l);
            }
          
        }
    }
}