using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String eid = Encryption_Decryption.security.passwordDecrypt(Request.QueryString["e"]);
            DataClasses1DataContext dc = new DataClasses1DataContext();
            try
            {
                var q = from edetails in dc.Events
                        where edetails.EventId == int.Parse(eid)
                        select edetails;
                foreach (var v in q)
                {
                    event_name.Text = v.EName;
                    sdate.Text = v.SDate.ToString("dd/MM/yyyy");
                    edate.Text = v.Edate.ToString("dd/MM/yyyy");
                    venue.Text = v.Venue;
                    description.Text = v.Description;
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
    }
}