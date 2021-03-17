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
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            var student = GetStudenByRegistrationAndEmail(txtRegistrationID.Text, txtEmail.Text);

            if (student == null)
            {
                Console.WriteLine("Student does not exists");
            }

            if (string.IsNullOrEmpty(student.Password))
            {
                Response.Redirect($"/bankquestions/studentaccesspassword?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(txtRegistrationID.Text)}&email={StringCipher.Encrypt(HttpUtility.UrlEncode(txtEmail.Text))}");
            }

            Response.Redirect($"/bankquestions/studentaccesslogin?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(txtRegistrationID.Text)}&email={StringCipher.Encrypt(HttpUtility.UrlEncode(txtEmail.Text))}");
        }

        #region Methods

        private StudentViewModel GetStudenByRegistrationAndEmail(string registrationID, string Email)
        {
            return StudentService.GetStudentByRegistrationAndEmail(registrationID, Email);
        }

        #endregion
    }
}