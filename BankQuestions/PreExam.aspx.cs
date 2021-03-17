using oneGoNclex.Security;
using System;

namespace oneGoNclex
{
    public partial class PreExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void startExam_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/exam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/exam?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";


            Response.Redirect(url);
        }
    }
}