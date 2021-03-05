using System;
using System.Data.SqlClient;

namespace oneGoNclex
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string FsName = txtFirstname.Text;
            string TexLast = txtLastname.Text;
            string midle = txtMiddlename.Text;
            string SocialSecurity = txtSocialSecurity.Text;
            string Address = txtAddress.Text;
            string City = txtCity.Text;
            string State = txtState.Text;
            string ZipCode = txtZip.Text;
            string TextPhone = txtPhonenumber.Text;
            string TextResidenceCountry = txtResidenceCountry.Text;
            string TextMail = txtEmail.Text;
            string TextEmergencyMail = txtEmergencyEmail.Text;
            string TextEmergencyName = txtEmergencyName.Text;
            string TextEmergencyPhone = txtEmergencyPhone.Text;
            string bdate = txtDateOfBirth.Text;
            string gender = rdbGender.SelectedValue;
            string lpn = chkLPN.Checked ? "yes" : "no";
            string gedSchool = chkHighSchool.Checked ? "yes" : "no";

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

            cmd.Parameters.AddWithValue("@FirstName", FsName);
            cmd.Parameters.AddWithValue("@MiddleName", midle ?? null);
            cmd.Parameters.AddWithValue("@LastName", TexLast);
            cmd.Parameters.AddWithValue("@DateOfBirth", bdate);
            cmd.Parameters.AddWithValue("@Adress", Address + " ;" + City + " ;" + State + " ;" + ZipCode);
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

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}