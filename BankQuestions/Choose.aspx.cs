using oneGoNclex.Extension;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class Choose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionBase.IsValidSession())
            {
                var cookieStudentData = SessionBase.GetDataFromSession();

                if (PaymentService.CheckSubscriptionAvailableByRegistrationID(cookieStudentData.RegistrationID))
                    Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(cookieStudentData.RegistrationID)}&email={StringCipher.Encrypt(cookieStudentData.Email)}");
                else
                    Response.Redirect($"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(cookieStudentData.RegistrationID)}&email={StringCipher.Encrypt(cookieStudentData.Email)}");
            }

            btnExternal.Enabled = false;
        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/studentaccess?bankid=" + Request.QueryString["bankid"]);
        }

        protected void btnExternal_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/login?bankid=" + Request.QueryString["bankid"]);
        }
    }
}