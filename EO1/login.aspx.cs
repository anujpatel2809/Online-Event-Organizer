using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace EO1.css.login
{

    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
            DataClasses1DataContext dc = new DataClasses1DataContext();
            Label l = new Label();
            try
            {
                var q = (from m in dc.members
                         where m.Email == email.Text && m.Password == pass.Text
                         select m).Single();
                
                
                    Session["UserId"] = q.UserId;
                    Session["Uname"] = q.Name;
                    Session["email"] = q.Email;
                    Session["VerifyStatus"] = q.Verifystatus;
                
            Response.Redirect("~/verifyemail.aspx");
           
               

            }
            catch(Exception ex)
            {
               
                Label1.Text = "Invalid Username or Password"; 
                
            }
           
        }
    }
}