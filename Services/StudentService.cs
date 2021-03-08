using oneGoNclex.Model;
using System;
using System.Data.SqlClient;

namespace oneGoNclex.Services
{
    public class StudentService
    {
        public static bool Add(ExternalLoginViewModel entityToTransform)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"INSERT INTO [dbo].[ExternalLogin]
                               ([FirstName]
                               ,[LastName]
                               ,[PhoneNumber]
                               ,[RegistrationDate]
                               ,[Email]
                               ,[Password])
                                values(
                                @FirstName,
                                @LastName,
                                @PhoneNumber,
                                @RegistrationDate,
                                @Email,
                                @password)",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@FirstName", entityToTransform.FsName);
                cmd.Parameters.AddWithValue("@LastName", entityToTransform.TexLast);
                cmd.Parameters.AddWithValue("@PhoneNumber", entityToTransform.TextPhone);
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Email", entityToTransform.TextMail);
                cmd.Parameters.AddWithValue("@password", entityToTransform.Password);

                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}