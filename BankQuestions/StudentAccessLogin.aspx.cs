using oneGoNclex.Services;
using System;
using System.Web;

namespace oneGoNclex
{
    public partial class StudentAccessLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var email = HttpUtility.UrlDecode(Request.QueryString["email"]);

            if (StudentService.CompareStudenPassword(registrationID, email, txtPassword.Text))
            {
                //TODO: Chequear si pago el servicio del examen
                //Si pago, a la pagina de examn
                //No pago, a la pagina de payment
                Response.Redirect($"/bankquestions/preexam?registrationid={registrationID}&email={email}");
            }
        }
    }
}