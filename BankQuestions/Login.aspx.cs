using oneGoNclex.Extension;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionBase.IsValidSession())
                loginAction.Attributes.CssStyle["display"] = "block";

            if (!btnToChoose.HRef.Contains("?bankid="))
                btnToChoose.HRef += $"?bankid={Request.QueryString["bankid"]}";

            if (!btnToExternal.HRef.Contains("?bankid="))
                btnToExternal.HRef += $"?tag=external&bankid={Request.QueryString["bankid"]}";

            if (!btnToRegister.HRef.Contains("?bankid="))
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