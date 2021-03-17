using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Threading.Tasks;

namespace oneGoNclex
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var pregisterId = AddPreRegister();

            Task.Run(() => {
                SendEmailForConfirmation(pregisterId);
            });

            Response.Redirect("/responsecontact.html");
        }

        #region Methods

        private int AddPreRegister()
        {
            string FsName = txtFirstname.Text;
            string TexLast = txtLastname.Text;
            string TextPhone = txtPhonenumber.Text;
            string TextMail = txtEmail.Text;

            return ExternalLoginService.Add(new ExternalLoginViewModel
            (
                FsName,
                TexLast,
                TextPhone,
                TextMail,
                null
            ));
        }

        private void SendEmailForConfirmation(int pregisterId)
        {
            string Subject = "OneGo Nclex Review LLC - Preregister";
            string Body = $"Please use this <a href='{Request.Url.OriginalString.Replace(Request.Url.PathAndQuery, "") + "/bankquestions/payment"}?bankid={Request.QueryString["bankid"]}&id={StringCipher.Encrypt(pregisterId.ToString())}'>link</a> to confirm your email.";
            EmailService.SendEmail(new EmailViewModel(txtEmail.Text, Subject, Body));
        }

        #endregion
    }
}