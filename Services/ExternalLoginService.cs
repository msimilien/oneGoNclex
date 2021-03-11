using oneGoNclex.Model;
using System;
using System.Data.SqlClient;

namespace oneGoNclex.Services
{
    public class ExternalLoginService
    {
        public static int LastAdded()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"select top 1 id from [dbo].[PreregisterExternal] order by id desc",
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();
                var result = -1;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }
                }

                reader.Close();

                return result;
            }
            catch
            {
                return -1;
            }
        }

        public static ExternalLoginViewModel GetById(int preregisterId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"SELECT [FirstName]
                                          ,[LastName]
                                          ,[PhoneNumber]
                                          ,[Email]
                                    FROM [dbo].[PreregisterExternal]
                                    WHERE [id] = @id",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@id", preregisterId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                ExternalLoginViewModel model = null;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new ExternalLoginViewModel(
                                reader.GetString(0), //fsName
                                reader.GetString(1), //texLast
                                reader.GetString(2), //textPhone
                                reader.GetString(3), //textMail
                                null //password
                            );
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();

                return model;
            }
            catch
            {
                return null;
            }
        }

        public static int Add(ExternalLoginViewModel entity)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"insert into [ExternalLogin] (
                                FirstName,
                                LastName,
                                PhoneNumber,
                                Email,
                                RegistrationDate)
                                values(
                                @FirstName,
                                @LastName,
                                @PhoneNumber,
                                @Email,
                                @RegistrationDate)",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@FirstName", entity.FsName);
                cmd.Parameters.AddWithValue("@LastName", entity.TexLast);
                cmd.Parameters.AddWithValue("@PhoneNumber", entity.TextPhone);
                cmd.Parameters.AddWithValue("@Email", entity.TextMail);
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();

                return LastAdded();
            }
            catch
            {
                return -1;
            }
        }

        public static bool UpdatePassword(string email, string newPassword)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"update [ExternalLogin] set [Password] = '" + newPassword
                                    + "' where Email = '" + email + "'",
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

        public static bool ValidateExternalWithEmailAndPassword(string email, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"SELECT [id]
                                    FROM [dbo].[ExternalLogin]
                                    WHERE [Email] = '" + email + "' and [Password]='" + password + "'",
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0) > 0;
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