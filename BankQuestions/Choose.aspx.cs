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
                loginAction.Attributes.CssStyle["display"] = "block";

                var cookieStudentData = SessionBase.GetDataFromSession();
                var checkPayment = PaymentService.CheckSubscriptionAvailableByRegistrationID(cookieStudentData.RegistrationID);
                var checkPremium = StringCipher.Decrypt(Request.QueryString["ispremium"]);
                
                if (checkPayment != null)
                {
                    if(checkPremium == "True" && !checkPayment.IsBankPremium)
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please upgrade your subscribtion to access to a premium bank');window.location.href='/banks';", true);
                    else
                        Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(cookieStudentData.RegistrationID)}&email={StringCipher.Encrypt(cookieStudentData.Email)}");
                }
                else
                    Response.Redirect($"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&registrationid={StringCipher.Encrypt(cookieStudentData.RegistrationID)}&email={StringCipher.Encrypt(cookieStudentData.Email)}");
            }

            btnExternal.Enabled = false;
        }
        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/studentaccess?bankid=" + Request.QueryString["bankid"]+ "&ispremium="+Request.QueryString["ispremium"]);
        }
        protected void btnExternal_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/login?bankid=" + Request.QueryString["bankid"] + "&ispremium=" + Request.QueryString["ispremium"]);
        }
    }
}