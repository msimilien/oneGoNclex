using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace oneGoNclex
{
    public partial class ForgotPassword : Page
    {
        private string _from;

        protected void Page_Load(object sender, EventArgs e)
        {
            _from = Request.QueryString["tag"];

            if (_from == "student")
            {
                pnRegistration.Visible = true;
                btnBack.HRef = $"/bankquestions/studentaccesslogin?tag=student&bankid={Request.QueryString["bankid"]}";
            }
            else
            {
                pnRegistration.Visible = false;
                btnBack.HRef = $"/bankquestions/login?tag=external&bankid={Request.QueryString["bankid"]}";
            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            var urlToSend = Request.Url.OriginalString.Replace(Request.Url.PathAndQuery, "") + "/bankquestions/recoverpassword";

            if (_from == "student")
                urlToSend += $"?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(txtRegistrationID.Text)}&email={StringCipher.Encrypt(txtEmail.Text)}";
            else
                urlToSend += $"?bankid={Request.QueryString["bankid"]}&email={StringCipher.Encrypt(txtEmail.Text)}";

            Task.Run(() => {
                SendEmailForConfirmation(urlToSend);
            });

            Response.Redirect("/responsecontact.html");
        }

        #region Methods

        private void SendEmailForConfirmation(string url)
        {
            string Subject = "Recover password with OneGo Nclex Review LLC";
            string Body = $"Please use this <a href='{url}'>link</a> to recover.";
            EmailService.SendEmail(new Model.EmailViewModel(txtEmail.Text, Subject, Body));
        }

        #endregion
    }
}