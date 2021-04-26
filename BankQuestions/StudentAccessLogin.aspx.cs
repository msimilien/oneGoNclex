using oneGoNclex.Extension;
using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Web;
using System.Web.Script.Serialization;

namespace oneGoNclex
{
    public partial class StudentAccessLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!btnToBack.HRef.Contains("?bankid="))
                btnToBack.HRef += $"?bankid={Request.QueryString["bankid"]}";

            if (!btnForgotPassword.HRef.Contains("?bankid="))
                btnForgotPassword.HRef += $"?tag=student&bankid={Request.QueryString["bankid"]}";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);
            var email = HttpUtility.UrlDecode(StringCipher.Decrypt(Request.QueryString["email"]));
            var student = StudentService.GetStudentByRegistrationAndEmail(registrationID, email);
            var fullName = !string.IsNullOrEmpty(student.MiddleName) ? $"{student.FirstName} {student.MiddleName} {student.LastName}" :
                                                                       $"{student.FirstName} {student.LastName}";
            CookieBase.AddCookieBase(new CookieModel(registrationID, email, fullName));

            if (StudentService.CompareStudenPassword(registrationID, email, txtPassword.Text))
            {
                var checkPayment = PaymentService.CheckSubscriptionAvailableByRegistrationID(registrationID);
                var checkpremium = StringCipher.Decrypt(Request.QueryString["ispremium"]);
                if (checkPayment != null)
                {
                    if (checkpremium == "True" && !checkPayment.IsBankPremium)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please upgrade your subscribtion to access to a premium bank');window.location.href='/Banks.aspx';", true);
                    }
                    else
                    {
                        Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}");
                    }
                   
                }

                else
                {
                    Response.Redirect($"/bankquestions/payment?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}");
                }
                    
            }
            else
                txtErrorLogin.Text = "Username, Registration ID or Password are invalid.";
        }
    }
}