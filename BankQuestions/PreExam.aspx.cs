using oneGoNclex.Extension;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class PreExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionBase.IsValidSession())
                loginAction.Attributes.CssStyle["display"] = "block";

            if (!Page.IsPostBack)
            {
                var bankId = int.Parse(StringCipher.Decrypt(Request.QueryString["bankid"]));
                var serviceResponse = ExamService.GetQuestionsByBankId(bankId);

                lblTotalQuestions.Text = serviceResponse.listOfQuestions.Count.ToString();

                var hour = 0;
                var seconds = 0;
                var total = serviceResponse.listOfQuestions.Count;

                while (total > 60)
                {
                    hour++;
                    total -= 60;
                }

                int minute = total;

                lblTimeLimit.Text = $"{hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}";
            }
        }

        protected void startExam_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/exam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/exam?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";


            Response.Redirect(url);
        }

        protected void btnStudyExam_Click(object sender, EventArgs e)
        {
            var registrationID = Request.QueryString["registrationid"];
            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/studyexam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/studyexam?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";


            Response.Redirect(url);
        }
    }
}