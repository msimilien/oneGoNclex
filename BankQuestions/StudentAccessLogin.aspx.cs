using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Web;

namespace oneGoNclex
{
    public partial class StudentAccessLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!btnToBack.HRef.Contains("?bankid="))
                btnToBack.HRef += $"?bankid={Request.QueryString["bankid"]}";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);
            var email = HttpUtility.UrlDecode(StringCipher.Decrypt(Request.QueryString["email"]));

            if (StudentService.CompareStudenPassword(registrationID, email, txtPassword.Text))
            {
                //TODO: Chequear si pago el servicio del examen
                //Si pago, a la pagina de examn
                //No pago, a la pagina de payment
                Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}");
            }
            else
            {
                txtErrorLogin.Text = "Username, Registration ID or Password are invalid.";
            }
        }
    }
}