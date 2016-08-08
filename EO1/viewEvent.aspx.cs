using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int counter = 1;
            String url;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            try
            {

                var q = from m in dc.Events
                        where m.UserId.ToString() == Session["UserId"].ToString()
                        select new
                        {
                            m.EName,
                            m.SDate,
                            m.Edate,
                            m.EventId
                        };
                foreach (var v in q.ToList())
                {
                   
                    TableRow r = new TableRow();
                    TableCell no = new TableCell();
                    TableCell c1 = new TableCell();
                    TableCell c2= new TableCell();
                    TableCell c3 = new TableCell();
                    HyperLink l = new HyperLink();
                   
                   
                    no.Text = counter.ToString();
                    counter++;

                    c2.Text = v.SDate.ToString("dd/MM/yyyy");
                    c3.Text = v.Edate.ToString("dd/MM/yyyy");
                   if (Request.QueryString["m"] == "true")
                   {
                        url = "modifyEvent.aspx?e=" + Encryption_Decryption.security.passwordEncrypt(v.EventId.ToString());
                        l.NavigateUrl = url;
                        l.Text = v.EName;
                        c1.Controls.Add(l);
                        r.Cells.Add(no);
                        
                        r.Cells.Add(c1);
                        r.Cells.Add(c2);
                        r.Cells.Add(c3);
                        eventTable.Rows.Add(r);
                    }
                    else
                    {
                        TableCell cl = new TableCell();
                        url = "viewdetails.aspx?e=" + Encryption_Decryption.security.passwordEncrypt(v.EventId.ToString());
                        l.NavigateUrl = url;
                        l.Text = "more";
                        c1.Text = v.EName;
                        r.Cells.Add(no);
                        r.Cells.Add(c1);
                        r.Cells.Add(c2);
                        r.Cells.Add(c3);
                        cl.Controls.Add(l);
                        r.Cells.Add(cl);
                        eventTable.Rows.Add(r);
                    }
                   
                    
                }
            }
            catch
            {
                Label l = new Label();
                l.Text = "Something Went Wrong Please Try Again Later...";
                message.Attributes["class"] = "alert alert-danger";
                message.Controls.Add(l);
            }

        }
       
    }
}