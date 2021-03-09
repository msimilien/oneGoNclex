using oneGoNclex.Model;
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

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var email = HttpUtility.UrlDecode(Request.QueryString["email"]);
            var password = txtPassword.Text;

            if (StudentService.UpdateStudentPassword(registrationID, email, password))
            {
                Task.Run(() => {
                    SendEmailForConfirmation(email);
                });

                Response.Redirect($"/bankquestions/studentaccesslogin?registrationid={registrationID}&email={email}");
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