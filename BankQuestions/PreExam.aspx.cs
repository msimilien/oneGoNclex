using System;
using System.Web;

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
            var email = HttpUtility.UrlDecode(Request.QueryString["email"]);
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/exam?registrationid={registrationID}&email={email}" :
                                                              $"/bankquestions/exam?email={email}";


            Response.Redirect(url);
        }
    }
}