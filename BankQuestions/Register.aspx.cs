using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddPreRegister();
            SendEmailForConfirmation();
            Response.Redirect("/responsecontact.html");
        }

        #region Methods

        private void AddPreRegister()
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

            PreRegisterService.Add(new Model.PreRegisterViewModel
            (
                FsName,
                TexLast,
                midle,
                SocialSecurity,
                Address,
                State,
                City,
                ZipCode,
                TextPhone,
                TextResidenceCountry,
                TextEmergencyMail,
                TextMail,
                TextEmergencyName,
                TextEmergencyPhone,
                gedSchool,
                gender,
                lpn,
                bdate,
                null
            ));
        }

        private void SendEmailForConfirmation()
        {
            int lasRegisterMade = PreRegisterService.LastAdded();
            string Subject = "OneGo Nclex Review LLC - Preregister";
            string Body = $"Please use this <a href='{Request.Url.OriginalString.Replace(Request.Url.LocalPath, "") + "/bankquestions/payment"}?id={lasRegisterMade}'>link</a> to recover.";
            EmailService.SendEmail(new Model.EmailViewModel(txtEmail.Text, Subject, Body));
        }

        #endregion
    }
}