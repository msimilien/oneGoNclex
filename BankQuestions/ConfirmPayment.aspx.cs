using oneGoNclex.DAL;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
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
            var bank = Request.QueryString["bankid"];

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

            if (!string.IsNullOrEmpty(cost) || !string.IsNullOrEmpty(bank))
            {
                lblCost.Text = StringCipher.Decrypt(cost);
                lblBank.Text = BankData.GetById(int.Parse(StringCipher.Decrypt(bank)))?.Name;
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
            PaymentService.InsertPayment(new Model.PaymentViewModel(registrationID,
                                                                    email,
                                                                    int.Parse(bank), 
                                                                    txtID.Text, 
                                                                    txtDate.Text, 
                                                                    cost));
        }
    }
}