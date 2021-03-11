using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            if (ExternalLoginService.ValidateExternalWithEmailAndPassword(txtUsername.Text, txtPassword.Text))
            {
                Response.Redirect($"/bankquestions/preexam?email={txtUsername.Text}");
            }
            else
                txtErrorLogin.Text = "Username or password invalid";
        }
    }
}