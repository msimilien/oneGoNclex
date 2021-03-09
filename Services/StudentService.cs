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
	                                    ,[Password]
                                    from Student
                                    where RegistrationID = '@RegistrationID'
                                    and Email = '@Email'",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@RegistrationID", registrationID);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new StudentViewModel(registrationID,
                                                    reader.GetString(0),
                                                    reader.GetString(1),
                                                    reader.GetString(2),
                                                    reader.GetString(3),
                                                    reader.GetString(4),
                                                    reader.GetString(5),
                                                    reader.GetString(6),
                                                    reader.GetString(7),
                                                    reader.GetString(8),
                                                    reader.GetString(9),
                                                    reader.GetString(10),
                                                    reader.GetString(11),
                                                    reader.GetString(12),
                                                    reader.GetString(13),
                                                    reader.GetString(14),
                                                    reader.GetString(15),
                                                    reader.GetString(16),
                                                    reader.GetString(17),
                                                    reader.GetString(18));
                    }
                }

                reader.Close();

                return null;
            }
            catch
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
                    CommandText = @"update Student 
	                                    set [Password] = @Password
                                    where RegistrationID = '@RegistrationID'
                                    and Email = '@Email'",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@RegistrationID", registrationID);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", newPassword);

                conn.Open();
                var result = (int)cmd.ExecuteScalar();

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
                                    where RegistrationID = '@RegistrationID'
                                    and Email = '@Email'",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@RegistrationID", registrationID);
                cmd.Parameters.AddWithValue("@Email", email);

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