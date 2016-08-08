using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class validatemail : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Encryption_Decryption.security.passwordDecrypt(Request.QueryString["id"].ToString()));
            string key = Encryption_Decryption.security.passwordDecrypt(Request.QueryString["key"].ToString());

            try
            {
                var v = (from m in dc.members
                         where m.UserId == id 
                         select m).Single();
                if (v.Email == key)
                {
                    member m = dc.members.Single(p => p.UserId == id);
                    m.Verifystatus = 1;
                    dc.SubmitChanges();
                    Label l = new Label();
                    l.Text = "Email is Verified.";
                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "~/login.aspx";
                    link.Text = "For Login click Here";
                    panel.Controls.Add(l);
                    panel.Controls.Add(link);
                }
               
            }
            catch (Exception ex)
            {
                Response.Redirect("~/error.aspx");
            }
        }
    }
}