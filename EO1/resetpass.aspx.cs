using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class resetpass : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
       
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
             id = int.Parse(Encryption_Decryption.security.passwordDecrypt(Request.QueryString["id"].ToString()));
            int key = int.Parse(Encryption_Decryption.security.passwordDecrypt(Request.QueryString["key"].ToString()));
            try
            {
                var v = (from c in dc.ForgotPasses
                         where c.UserId == id
                         select c.Pass).Single();

                if (key != v)
                {
                    Response.Redirect("~/error.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/error.aspx");
            }

        }

       protected void Button1_Click(object sender, EventArgs e)
        {
            Label l = new Label();
            try
            {
                member m = dc.members.Single(mem => mem.UserId == id);
                m.Password = pass.Text;
                dc.SubmitChanges();

                ForgotPass p = dc.ForgotPasses.Single(fp => fp.UserId == id);
                dc.ForgotPasses.DeleteOnSubmit(p);
                dc.SubmitChanges();

                Response.Redirect("~/home.aspx");
            }
            catch (Exception ex)
            {
                l.Text = "Password is not change.";
                panel.Controls.Add(l);
            }

         }
    }
}