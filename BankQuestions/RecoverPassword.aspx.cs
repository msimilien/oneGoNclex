using oneGoNclex.Services;
using System;
using System.Threading.Tasks;
using System.Web;

namespace oneGoNclex
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var email = HttpUtility.UrlDecode(Request.QueryString["email"]);

            var result = !string.IsNullOrEmpty(registrationID) ? StudentService.UpdateStudentPassword(registrationID, email, txtPassword.Text) :
                                                                ExternalLoginService.UpdatePassword(email, txtPassword.Text);

            if (result)
            {
                Task.Run(() => {
                    SendEmail(email);
                });
            }

            if(!string.IsNullOrEmpty(registrationID))
                Response.Redirect($"/bankquestions/studentaccesslogin?registrationid={registrationID}&email={email}");
            else
                Response.Redirect($"/bankquestions/login?email={email}");
        }

        private void SendEmail(string email)
        {
            string Subject = "Password updated with OneGo Nclex Review LLC";
            string Body = $"Your password was updated successfully!!!";
            EmailService.SendEmail(new Model.EmailViewModel(email, Subject, Body));
        }
    }
}