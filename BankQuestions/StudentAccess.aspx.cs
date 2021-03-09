using oneGoNclex.Model;
using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class StudentAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Response.Redirect($"/bankquestions/studentaccesspassword?registrationid={txtRegistrationID.Text}&email={txtEmail.Text}");
            }

            Response.Redirect($"/bankquestions/studentaccesslogin?registrationid={txtRegistrationID.Text}&email={txtEmail.Text}");
        }

        #region Methods

        private StudentViewModel GetStudenByRegistrationAndEmail(string registrationID, string Email)
        {
            return StudentService.GetStudentByRegistrationAndEmail(registrationID, Email);
        }

        #endregion
    }
}