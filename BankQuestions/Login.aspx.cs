using oneGoNclex.Security;
using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnToChoose.HRef += $"?bankid={Request.QueryString["bankid"]}";
            btnToExternal.HRef += $"?bankid={Request.QueryString["bankid"]}";
            btnToRegister.HRef += $"?bankid={Request.QueryString["bankid"]}";
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            if (ExternalLoginService.ValidateExternalWithEmailAndPassword(txtUsername.Text, txtPassword.Text))
            {
                Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&email={StringCipher.Encrypt(txtUsername.Text)}");
            }
            else
                txtErrorLogin.Text = "Username or password invalid";
        }
    }
}