using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace EO1
{
    
    public class ShowImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                Int32 empno;
                if (context.Request.QueryString["id"] != null)
                    empno = Convert.ToInt32(Encryption_Decryption.security.passwordDecrypt(context.Request.QueryString["id"]));
                else
                    throw new ArgumentException("No parameter specified");

                context.Response.ContentType = "image/jpeg";
                Stream strm = ShowEmpImage(empno);
                byte[] buffer = new byte[4096];
                int byteSeq = strm.Read(buffer, 0, 4096);

                while (byteSeq > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, byteSeq);
                    byteSeq = strm.Read(buffer, 0, 4096);
                }
            }
            catch
            {
                return;
            }
        }
       
        public Stream ShowEmpImage(int empno)
        {

            string conn = ConfigurationManager.ConnectionStrings["EODBConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            string sql = "SELECT DisplayPic FROM member WHERE UserId = @ID";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", empno);
            connection.Open();
            object img = cmd.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])img);
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}