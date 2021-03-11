using oneGoNclex.Model;
using oneGoNclex.Services;
using System;
using System.Threading.Tasks;

namespace oneGoNclex
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            var model = ExternalLoginService.GetById(int.Parse(Request.QueryString["id"]));
            model.Password = txtPassword.Text;

            UpdateExternalLoginProfile(model);

            Response.Redirect($"/bankquestions/login?email={model.TextMail}");
        }

        #region Methods

        private void UpdateExternalLoginProfile(ExternalLoginViewModel model)
        {
            var result = ExternalLoginService.UpdatePassword(model.TextMail, model.Password);

            if (result)
            {
                Task.Run(() => {
                    SendEmail(model.TextMail);
                });
            }
        }

        private void SendEmail(string email)
        {
            string Subject = "Profile complete with OneGo Nclex Review LLC";
            string Body = $"You are ready to go! Your profile was updated successfully!!!";
            EmailService.SendEmail(new EmailViewModel(email, Subject, Body));
        }

        #endregion
    }
}