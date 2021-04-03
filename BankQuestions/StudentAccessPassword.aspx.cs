using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Threading.Tasks;
using System.Web;

namespace oneGoNclex
{
    public partial class StudentAccessPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!btnToBack.HRef.Contains("?bankid="))
                btnToBack.HRef += $"?bankid={Request.QueryString["bankid"]}";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);
            var email = HttpUtility.UrlDecode(StringCipher.Decrypt(Request.QueryString["email"]));
            var password = txtPassword.Text;

            if (StudentService.UpdateStudentPassword(registrationID, email, password))
            {
                Task.Run(() => {
                    SendEmailForConfirmation(email);
                });

                Response.Redirect($"/bankquestions/studentaccesslogin?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}");
            }
            else
            {
                Console.WriteLine("Unexpected error when trying to update password for student.");
            }
        }

        #region Methods

        private void SendEmailForConfirmation(string email)
        {
            string Subject = "OneGo Nclex Review LLC - Preregister";
            string Body = $"Your password was successfully updated!!";
            EmailService.SendEmail(new EmailViewModel(email, Subject, Body));
        }

        #endregion
    }
}