using oneGoNclex.Model;
using System;
using System.Data.SqlClient;

namespace oneGoNclex.Services
{
    public class StudentService
    {
        public static bool Add(PreRegisterViewModel entityToTransform)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"INSERT INTO [dbo].[Student]
                               ([RegistrationID]
                               ,[FirstName]
                               ,[MiddleName]
                               ,[LastName]
                               ,[DateOfBirth]
                               ,[Adress]
                               ,[SocialSecurity]
                               ,[PhoneNumber]
                               ,[EmergencyPhone]
                               ,[RegistrationDate]
                               ,[Email]
                               ,[EmergencyMail]
                               ,[EmergencyName]
                               ,[ResidenceCountry]
                               ,[Gender]
                               ,[HighSchool/GED]
                               ,[LPNDiploma]
                               ,[Password])
                                values(
                                @RegistrationID,
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
                                @lpn,
                                @password)",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@RegistrationID", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@FirstName", entityToTransform.FsName);
                cmd.Parameters.AddWithValue("@MiddleName", entityToTransform.Midle ?? null);
                cmd.Parameters.AddWithValue("@LastName", entityToTransform.TexLast);
                cmd.Parameters.AddWithValue("@DateOfBirth", entityToTransform.Bdate);
                cmd.Parameters.AddWithValue("@Adress", entityToTransform.Address + " ;" + entityToTransform.TextCity + " ;" + entityToTransform.TextState + " ;" + entityToTransform.Zip);
                cmd.Parameters.AddWithValue("@SocialSecurity", entityToTransform.SocialSecurity);
                cmd.Parameters.AddWithValue("@PhoneNumber", entityToTransform.TextPhone);
                cmd.Parameters.AddWithValue("@EmergencyPhone", entityToTransform.TextEmergencyPhone ?? null);
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Email", entityToTransform.TextMail);
                cmd.Parameters.AddWithValue("@EmergencyMail", entityToTransform.TextEmergencyMail ?? null);
                cmd.Parameters.AddWithValue("@EmergencyName", entityToTransform.TextEmergencyName ?? null);
                cmd.Parameters.AddWithValue("@ResidenceCountry", entityToTransform.TextResidenceCountry);
                cmd.Parameters.AddWithValue("@Gender", entityToTransform.Gender);
                cmd.Parameters.AddWithValue("@HighSchoolGED", entityToTransform.GedSchool);
                cmd.Parameters.AddWithValue("@lpn", entityToTransform.Lpn);
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