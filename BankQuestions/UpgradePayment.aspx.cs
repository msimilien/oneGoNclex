using oneGoNclex.Extension;
using oneGoNclex.Services;
using System;
using System.Linq;
using System.Web;

namespace oneGoNclex
{
    public partial class UpgradePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CookieBase.IsValidCookie() || Request.QueryString["bankid"] == null)
                {
                    var url = "/banks";
                    Response.Redirect(url);
                }

                var cookieData = CookieBase.GetDataFromCookie();
                var registrationID = cookieData.RegistrationID;
                var email = HttpUtility.UrlDecode(cookieData.Email);
                var fullName = cookieData.FullName;

                var data = PaymentService.GetAllPaymentsByRegistrationId(registrationID);

                if (data.First().EndDate <= DateTime.Now)
                    btnRenew.Visible = true;
                else
                {
                    btnRenew.Visible = false;
                    btnPremiumContainer.Attributes["class"] = "col-12";
                }

                tblPayments.DataSource = data;
                tblPayments.DataBind();

                lblRegistration.Text = registrationID;
                lblEmail.Text = email;
                lblFullname.Text = fullName;
                lblPremium.Text = data.First().SubscriptionType;
                lblEndDate.Text = data.First().EndDateFormat;
            }
        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";

            Response.Redirect(url);
        }

        protected void btnUpgradePremium_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";


            url += "&onlyPremium=1";

            Response.Redirect(url);
        }
    }
}