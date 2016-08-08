using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EO1
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        Label l = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               List<member> v=new List<member>() ;
               v = (from d in dc.members
                    where d.UserId == int.Parse(Session["UserId"].ToString())
                    select d).ToList();
                if (!IsPostBack)
                {
                     
                    name.Text = v.ToList()[0].Name;
                    phone.Text = v.ToList()[0].PhoneNo;
                }
                if (v.ToList()[0].DisplayPic == null)
                {
                    dp.ImageUrl = dp.ImageUrl = "~/Image/demoUpload.jpg";
                }
                else
                {
                    dp.ImageUrl = "~/ShowImage.ashx?id=" + Encryption_Decryption.security.passwordEncrypt(Session["UserId"].ToString());

                }
            }
            catch (Exception ex)
            {
                
                l.Text = "Something Went Wrong Please Try Again Later...";
                message.Attributes["class"] = "alert alert-danger";
                message.Controls.Add(l);
            }
        }
        protected void saveImage()
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            
            member m = dc.members.Single(p => p.UserId == int.Parse(Session["UserId"].ToString()));
            m.DisplayPic = imgByte;
            dc.SubmitChanges();
        }
        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {
                saveImage();
                dp.ImageUrl = "~/ShowImage.ashx?id=" + Encryption_Decryption.security.passwordEncrypt(Session["UserId"].ToString());
            }
            catch (Exception ex)
            {
                
                l.Text = "Something Went Wrong Please Try Again Later...";
                message.Attributes["class"] = "alert alert-danger";
                message.Controls.Add(l);
            }
          
        }

        protected void remove_Click(object sender, EventArgs e)
        {
            member f = dc.members.Single(p => p.UserId == 10000006);
            member m = dc.members.Single(p => p.UserId == int.Parse(Session["UserId"].ToString()));
            m.DisplayPic = f.DisplayPic;
            dc.SubmitChanges();
         
            
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {

                member m = dc.members.Single(p => p.UserId == int.Parse(Session["UserId"].ToString()));
                m.Name = name.Text;
                m.PhoneNo = phone.Text;
                m.Country = country.SelectedValue;
              
                dc.SubmitChanges();
               
                l.Text = "Profile Updated";
                message.Attributes["class"] = "alert alert-success";
                message.Controls.Add(l);
            }
            catch (Exception ex)
            {
                
                l.Text =  "Something Went Wrong Please Try Again Later...";
                message.Attributes["class"] = "alert alert-danger";
                message.Controls.Add(l);
            }
        }
    }
}