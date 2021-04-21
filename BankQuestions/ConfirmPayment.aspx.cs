using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Threading.Tasks;
using System.Web;

namespace oneGoNclex
{
    public partial class ConfirmPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var email = Request.QueryString["email"];
            var cost = Request.QueryString["cost"];
            var isPremium = Request.QueryString["isPremium"];
            var days = StringCipher.Decrypt(Request.QueryString["days"]);
            var daysCount = PaymentService.GetDaysBySubscriptionName(days);
            var endDate = DateTime.Now.AddDays(daysCount);

            if (!string.IsNullOrEmpty(registrationID))
                lblRegistration.Text = StringCipher.Decrypt(registrationID);
            else
            {
                lblRegistration.Visible = false;
                lblRegistrationContainer.Visible = false;
                lblRegistrationTitle.Visible = false;
                lblRegistrationTitleContainer.Visible = false;
            }

            if (!string.IsNullOrEmpty(email))
                lblEmail.Text = HttpUtility.UrlDecode(StringCipher.Decrypt(email));
            else
                Response.Redirect(BackToPaymentSelectionUrl());

            if (!string.IsNullOrEmpty(cost))
            {
                lblCost.Text = StringCipher.Decrypt(cost);
                lblPremium.Text = bool.Parse(StringCipher.Decrypt(isPremium)) ? "Yes" : "No";
                lblEndDate.Text = endDate.ToString("MM-dd-yyyy");
            }
            else
                Response.Redirect(BackToPaymentSelectionUrl());
        }

        protected void btnBackToPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect(BackToPaymentSelectionUrl());
        }

        private string BackToPaymentSelectionUrl()
        {
            var registrationID = Request.QueryString["registrationid"];
            return !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                           $"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);
            var email = HttpUtility.UrlDecode(StringCipher.Decrypt(Request.QueryString["email"]));
            var cost = StringCipher.Decrypt(Request.QueryString["cost"]);
            var bank = StringCipher.Decrypt(Request.QueryString["bankid"]);
            var isPremium = bool.Parse(StringCipher.Decrypt(Request.QueryString["isPremium"]));
            var days = StringCipher.Decrypt(Request.QueryString["days"]);
            var daysCount = PaymentService.GetDaysBySubscriptionName(days);
            var endDate = DateTime.Now.AddDays(daysCount);

            Task.Run(() => {
                PaymentService.UpsertPayment(new Model.PaymentViewModel(registrationID,
                                                                    email,
                                                                    int.Parse(bank),
                                                                    txtID.Text,
                                                                    txtDate.Text, 
                                                                    cost,
                                                                    isPremium,
                                                                    daysCount,
                                                                    endDate));
            });

            Task.Run(() => {
                string Subject = "OneGo Nclex Review LLC - Payment subscription";
                string Body = "This is a resume of your successfull transaction:<br /><br />";
                Body += $"<b>Registration ID:</b> {registrationID}<br />";
                Body += $"<b>Email:</b> {email}<br />";
                Body += $"<b>Cost:</b> {cost}<br />";
                Body += $"<b>Premium:</b> {(isPremium ? "Yes" : "No")}<br />";
                Body += $"<b>Transaction ID:</b> {txtID.Text}<br />";
                Body += $"<b>Create date:</b> {DateTime.Parse(txtDate.Text):MM-dd-yyyy}<br />";
                Body += $"<b>End date:</b> {endDate}<br />";
                EmailService.SendEmail(new Model.EmailViewModel(email, Subject, Body));
            });

            Response.Redirect("/banks");
        }
    }
}