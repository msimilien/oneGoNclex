using oneGoNclex.Security;
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
                var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);
                var email = HttpUtility.UrlDecode(StringCipher.Decrypt(Request.QueryString["email"]));
                var data = PaymentService.GetAllPaymentsByRegistrationId(registrationID);
                var student = StudentService.GetStudentByRegistrationAndEmail(registrationID, email);
                tblPayments.DataSource = data;
                tblPayments.DataBind();

                lblRegistration.Text = registrationID;
                lblEmail.Text = email;
                lblFullname.Text = string.IsNullOrEmpty(student?.MiddleName) ? 
                                        $"{student?.FirstName} {student?.LastName}" :
                                        $"{student?.FirstName} {student?.MiddleName} {student?.LastName}";
                lblPremium.Text = data.First().SubscriptionType;
                lblEndDate.Text = data.First().EndDate;
            }
        }
    }
}