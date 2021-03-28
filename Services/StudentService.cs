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

        public static StudentViewModel GetStudentByRegistrationAndEmail(string registrationID, string email)
        {
            string _actif = "yes";
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"select 
	                                    FirstName
	                                    ,MiddleName
	                                    ,LastName
	                                    ,DateOfBirth
	                                    ,Adress
	                                    ,SocialSecurity
	                                    ,PhoneNumber
	                                    ,EmergencyPhone
	                                    ,RegistrationDate
	                                    ,Email
	                                    ,EmergencyMail
	                                    ,EmergencyName
	                                    ,ResidenceCountry
	                                    ,Gender
	                                    ,[HighSchool/GED]
	                                    ,Actif
	                                    ,[Group]
	                                    ,LPNDiploma
	                                    ,ISNULL([Password], '') as [Password]
                                    from Student
                                    where RegistrationID = '" + registrationID + "'and Email = '" + email  + "'and Actif = '"+_actif+"'",
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new StudentViewModel(registrationID,
                                                    reader.GetString(0).Trim(),
                                                    reader.GetString(1).Trim(),
                                                    reader.GetString(2).Trim(),
                                                    reader.GetDateTime(3).ToString("yyyy-MM-dd").Trim(),
                                                    reader.GetString(4).Trim(),
                                                    reader.GetString(5).Trim(),
                                                    reader.GetString(6).Trim(),
                                                    reader.GetString(7).Trim(),
                                                    reader.GetDateTime(8).ToString("yyyy-MM-dd").Trim(),
                                                    reader.GetString(9).Trim(),
                                                    reader.GetString(10).Trim(),
                                                    reader.GetString(11).Trim(),
                                                    reader.GetString(12).Trim(),
                                                    reader.GetString(13).Trim(),
                                                    reader.GetString(14).Trim(),
                                                    reader.GetString(15).Trim(),
                                                    reader.GetString(16).Trim(),
                                                    reader.GetString(17).Trim(),
                                                    reader.GetString(18).Trim());
                    }
                }

                reader.Close();

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool UpdateStudentPassword(string registrationID, string email, string newPassword)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"update Student set [Password] = '" + newPassword
                                    + "' where RegistrationID = '" + registrationID
                                    + "' and Email = '" + email + "'",
                    Connection = conn
                };

                conn.Open();
                var result = cmd.ExecuteNonQuery();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool CompareStudenPassword(string registrationID, string email, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"select [Password]
                                    from Student
                                    where RegistrationID = '" + registrationID 
                                    + "' and Email = '" + email + "'",
                                    
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return password == reader.GetString(0);
                    }
                }

                reader.Close();

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}