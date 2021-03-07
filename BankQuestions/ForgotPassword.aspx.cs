using oneGoNclex.Services;
using System;
using System.Web.UI;

namespace oneGoNclex
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            SendEmailForConfirmation();
            Response.Redirect("ResponseContact.html");
        }

        #region Methods

        private void SendEmailForConfirmation()
        {
            string Subject = "Recover password with OneGo Nclex Review LLC";
            string Body = $"Please use this <a href='{Request.Url.OriginalString.Replace(Request.Url.LocalPath, "") + "/bankquestions/recoverpassword"}'>link</a> to recover.";
            EmailService.SendEmail(new Model.EmailViewModel(txtEmail.Text, Subject, Body));
        }

        #endregion
    }
}