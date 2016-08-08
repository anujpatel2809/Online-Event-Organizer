using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                  Calendar1.SelectedDate = DateTime.Now;
               
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
            edate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar2.SelectedDate = Calendar1.SelectedDate;
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

        protected void CreateEveB_Click(object sender, EventArgs e)
        {
            
            Label l = new Label();
        
            try
            {

                var name = (from ed in dc.Events
                            where ed.UserId == int.Parse(Session["UserId"].ToString()) && ed.EName == event_name.Text
                            select ed.UserId).ToList();

                int i = name.ToList()[0];
                
                    message.Attributes["class"] = "alert alert-danger";
                    l.Text = "Event Already Exsists "; //ex1.ToString();
                    message.Controls.Add(l);
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                try
                {

                    Event eve = new Event();
                    eve.UserId = int.Parse(Session["UserId"].ToString());
                    eve.EName = event_name.Text;
                    eve.SDate = Calendar1.SelectedDate;
                    eve.Edate = Calendar2.SelectedDate;
                    eve.Venue = venue.Text;
                    eve.Description = description.Text;
                    dc.Events.InsertOnSubmit(eve);
                    dc.SubmitChanges();

                    message.Attributes["class"] = "alert alert-success";

                    l.Text = "Event Created";

                    message.Controls.Add(l);
                    var q = (from ev in dc.Events
                            where ev.UserId == int.Parse(Session["UserId"].ToString()) && ev.EName == event_name.Text
                            select ev.EventId).First();

                    Response.Redirect("~/viewdetails.aspx?e=" + Encryption_Decryption.security.passwordEncrypt(q.ToString()));
                }
                catch (Exception ex1)
                {
                    message.Attributes["class"] = "alert alert-danger";
                    l.Text = "Something Went Wrong..."; //ex1.ToString();
                    message.Controls.Add(l);
                }
                
            }
            catch (Exception ex)
            {
                message.Attributes["class"] = "alert alert-danger";
                l.Text = "Something Went Wrong..."; //ex1.ToString();
                message.Controls.Add(l);
            }
             
            }
        }
    }

