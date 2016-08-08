using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class signup : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                string q = (from m in dc.members
                            where m.Email == temail.Text
                            select m.Email).Single();
               
                

                status.Text = "Account with this Email address is already registered.";

            }
            catch (InvalidOperationException i)
            {
                // Label1.Text = "not user";


                try
                {
                    member f = dc.members.Single(p => p.UserId == 10000006);
                    member mem = new member();
                    mem.Name = tname.Text;
                    mem.Password = tpass.Text;
                    mem.Email = temail.Text;
                    mem.PhoneNo = tphone.Text;
                    mem.Country = country.SelectedValue.ToString();
                    mem.DisplayPic = f.DisplayPic;
                    dc.members.InsertOnSubmit(mem);
                    dc.SubmitChanges();
                    Label1.Text = "Registration Successfull";
                    var memberid = (from m in dc.members
                                    where m.Email == temail.Text
                                    select m.UserId).Single();

                    string sub = "Verify Email";
                    string msg = "Click On below link to Verify Email.<br/>" +
                        "<a href=\"http://localhost:50820/validatemail.aspx?id=" + Encryption_Decryption.security.passwordEncrypt(memberid.ToString()) + "&key=" +
                    Encryption_Decryption.security.passwordEncrypt(temail.ToString()) + "\">Click here</a>";

                    Mail.MailSend.SendMail(temail.Text, sub, msg);

                   
                    tname.Text = "";
                    temail.Text = "";
                    tpass.Text = "";
                    tcpass.Text = "";
                    tphone.Text = "";
                }
                catch (Exception ex)
                {

                }
               
              
            }
        }

       
    }
}