using oneGoNclex.Model;
using System;
using System.Data.SqlClient;

namespace oneGoNclex.DAL
{
    public class PreregisterData
    {
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