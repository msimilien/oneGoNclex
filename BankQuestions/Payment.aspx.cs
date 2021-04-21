using oneGoNclex.Security;
using System;

namespace oneGoNclex
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/confirmpayment?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/confirmpayment?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";


            url += "&cost=" + StringCipher.Encrypt(txtCost.Text);
            url += "&isPremium=" + StringCipher.Encrypt(txtIsPremium.Text);
            url += "&days=" + StringCipher.Encrypt(txtDays.Text);

            Response.Redirect(url);
        }
    }
}