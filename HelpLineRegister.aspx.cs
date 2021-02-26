using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oneGoNclex
{
    public partial class HelpLineRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            addRegister();
            Response.Redirect("ResponseContact.html");
        }
        private void addRegister()
        {
            string gedSchool = null, gender = null, lpn = null;
            string FsName = Request.Form["TextFname"];
            string TexLast = Request.Form["TexLast"];
            string midle = Request.Form["TextMdleName"];
            string SocialSecurity = Request.Form["TxtSocialSecurity"];
            string Address = Request.Form["TextAddress"];
            string TextState = Request.Form["TextState"];
            string TextCity = Request.Form["TextCity"];
            string Zip = Request.Form["Zip"];
            string TextPhone = Request.Form["TextPhone"];
            string TextResidenceCountry = Request.Form["TextResidenceCountry"];
            string TextMail = Request.Form["TextMail"];
            string TextEmergencyMail = Request.Form["TextEmergencyMail"];
            string TextEmergencyName = Request.Form["TextEmergencyName"];
            string TextEmergencyPhone = Request.Form["TextEmergencyPhone"];
            
            gender = Request.Form["SelectGender"].ToString();
            lpn = Request.Form["CheckboxLPN"];
            gedSchool = Request.Form["CheckboxHighSchool"];
            string bdate = Request.Form["TextBirthDate"];
            if (string.IsNullOrEmpty(lpn))
            {
                lpn = "no";
            }
            else
            {
                lpn = "yes";
            }
            if (string.IsNullOrEmpty(gedSchool))
            {
                gedSchool = "no";
            }
            else
            {
                gedSchool = "yes";
            }

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"insert into preregister (
                                
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
                                @lpn)";
            cmd.Connection = conn;


            
            cmd.Parameters.AddWithValue("@FirstName", FsName);
            cmd.Parameters.AddWithValue("@MiddleName", midle ?? null);
            cmd.Parameters.AddWithValue("@LastName", TexLast);
            cmd.Parameters.AddWithValue("@DateOfBirth", bdate);
            cmd.Parameters.AddWithValue("@Adress", Address + " ;" + TextCity + " ;" + Zip);
            cmd.Parameters.AddWithValue("@SocialSecurity", SocialSecurity);
            cmd.Parameters.AddWithValue("@PhoneNumber", TextPhone);
            cmd.Parameters.AddWithValue("@EmergencyPhone", TextEmergencyPhone ?? null);
            cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Email", TextMail);
            cmd.Parameters.AddWithValue("@EmergencyMail", TextEmergencyMail ?? null);
            cmd.Parameters.AddWithValue("@EmergencyName", TextEmergencyName ?? null);
            cmd.Parameters.AddWithValue("@ResidenceCountry", TextResidenceCountry);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@HighSchoolGED", gedSchool);
            cmd.Parameters.AddWithValue("@lpn", lpn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                // call send mail method
                
               
                
            }
            catch (Exception ex)
            {
                //lblMessage.Text = lblMessage.Text + " ;" + ex.Message.ToString();
            }
        }
    }
}