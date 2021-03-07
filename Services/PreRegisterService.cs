using oneGoNclex.Model;
using System;
using System.Data.SqlClient;

namespace oneGoNclex.Services
{
    public class PreRegisterService
    {
        public static int LastAdded()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"select top 1 id from [dbo].[Preregister] order by id desc",
                    Connection = conn
                };

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
        }

        public static PreRegisterViewModel GetById(int preregisterId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"SELECT [FirstName]
                                          ,[MiddleName]
                                          ,[LastName]
                                          ,[DateOfBirth]
                                          ,[Adress]
                                          ,[SocialSecurity]
                                          ,[PhoneNumber]
                                          ,[EmergencyPhone]
                                          ,[Email]
                                          ,[EmergencyMail]
                                          ,[EmergencyName]
                                          ,[ResidenceCountry]
                                          ,[Gender]
                                          ,[HighSchool/GED]
                                          ,[LPNDiploma]
                                    FROM [dbo].[Preregister]
                                    WHERE [id] = @id",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@id", preregisterId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                PreRegisterViewModel model = null;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new PreRegisterViewModel(
                                reader.GetString(0), //fsName
                                reader.GetString(2), //texLast
                                reader.GetString(1), //midle
                                reader.GetString(5), //socialSecurity
                                reader.GetString(4).Split(';')[0], //address
                                reader.GetString(4).Split(';')[2], //textState
                                reader.GetString(4).Split(';')[1], //textCity
                                reader.GetString(4).Split(';')[3], //zip
                                reader.GetString(6), //textPhone
                                reader.GetString(11), //textResidenceCountry
                                reader.GetString(9), //textEmergencyMail
                                reader.GetString(8), //textMail
                                reader.GetString(10), //textEmergencyName
                                reader.GetString(7), //textEmergencyPhone
                                reader.GetString(13), //gedSchool
                                reader.GetString(12), //gender
                                reader.GetString(14), //lpn
                                reader.GetDateTime(3).ToString("yyyy-MM-dd"), //bdate
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
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool Add(PreRegisterViewModel entity)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"insert into preregister (
                                
                                FirstName,
                                MiddleName,
                                LastName,
                                DateOfBirth,
                                Adress,
                                SocialSecurity,
                                PhoneNumber,
                                EmergencyPhone,
                                RegistrationDate,
                                Email,
                                EmergencyMail,
                                EmergencyName,
                                ResidenceCountry,
                                Gender,
                                [HighSchool/GED],
                                LPNDiploma
                                )
                                values(
                               
                                @FirstName,
                                @MiddleName,
                                @LastName,
                                @DateOfBirth,
                                @Adress,
                                @SocialSecurity,
                                @PhoneNumber,
                                @EmergencyPhone,
                                @RegistrationDate,
                                @Email,
                                @EmergencyMail,
                                @EmergencyName,
                                @ResidenceCountry,
                                @Gender,
                                @HighSchoolGED,
                                @lpn)",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@FirstName", entity.FsName);
                cmd.Parameters.AddWithValue("@MiddleName", entity.Midle ?? null);
                cmd.Parameters.AddWithValue("@LastName", entity.TexLast);
                cmd.Parameters.AddWithValue("@DateOfBirth", entity.Bdate);
                cmd.Parameters.AddWithValue("@Adress", entity.Address + " ;" + entity.TextCity + " ;" + entity.TextState + " ;" + entity.Zip);
                cmd.Parameters.AddWithValue("@SocialSecurity", entity.SocialSecurity);
                cmd.Parameters.AddWithValue("@PhoneNumber", entity.TextPhone);
                cmd.Parameters.AddWithValue("@EmergencyPhone", entity.TextEmergencyPhone ?? null);
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Email", entity.TextMail);
                cmd.Parameters.AddWithValue("@EmergencyMail", entity.TextEmergencyMail ?? null);
                cmd.Parameters.AddWithValue("@EmergencyName", entity.TextEmergencyName ?? null);
                cmd.Parameters.AddWithValue("@ResidenceCountry", entity.TextResidenceCountry);
                cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                cmd.Parameters.AddWithValue("@HighSchoolGED", entity.GedSchool);
                cmd.Parameters.AddWithValue("@lpn", entity.Lpn);

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