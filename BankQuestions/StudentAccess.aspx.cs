using oneGoNclex.Extension;
using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Web;

namespace oneGoNclex
{
    public partial class StudentAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnToChoose.HRef += $"?bankid={Request.QueryString["bankid"]}";
            txtErrorMsg.Visible = false;
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            var student = GetStudenByRegistrationAndEmail(txtRegistrationID.Text, txtEmail.Text);

            if (student == null)
            {
                txtErrorMsg.Text = "Registration ID or email ar invalid";
                txtErrorMsg.Visible = true;
                return;
            }
            else
                txtErrorMsg.Visible = false;

            if (string.IsNullOrEmpty(student.Password))
            {
                Response.Redirect($"/bankquestions/studentaccesspassword?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(txtRegistrationID.Text)}&email={StringCipher.Encrypt(HttpUtility.UrlEncode(txtEmail.Text))}");
            }

            Response.Redirect($"/bankquestions/studentaccesslogin?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(txtRegistrationID.Text)}&email={StringCipher.Encrypt(HttpUtility.UrlEncode(txtEmail.Text))}&ispremium={StringCipher.Decrypt(Request.QueryString["ispremium"])}");
        }

        #region Methods

        private StudentViewModel GetStudenByRegistrationAndEmail(string registrationID, string Email)
        {
            return StudentService.GetStudentByRegistrationAndEmail(registrationID, Email);
        }

        #endregion
    }
}