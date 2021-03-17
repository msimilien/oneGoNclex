using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oneGoNclex
{
    public partial class Exam : System.Web.UI.Page
    {
        const string maxValueMinute = "59";
        const string minValueMinute = "00";

        protected void Page_Load(object sender, EventArgs e)
        {
            scripManager1.RegisterAsyncPostBackControl(btnNext);
            scripManager1.RegisterAsyncPostBackControl(btnPrev);

            if (!Page.IsPostBack)
            {
                var bankId = int.Parse(StringCipher.Decrypt(Request.QueryString["bankid"]));
                var serviceResponse = ExamService.GetQuestionsByBankId(bankId);

                Session["listOfQuestions"] = serviceResponse.Item1;
                Session["listOfAnswers"] = serviceResponse.Item2;
                Session["counter"] = 0;

                var questions = (List<ExamQuestion>)Session["listOfQuestions"];
                var itemExam = questions.First();
                var answers = ((List<ExamAnswer>)Session["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);

                lblQuestions.Text = itemExam.Question;

                Answers.Items.Clear();

                foreach (var answer in answers)
                    Answers.Items.Add(new System.Web.UI.WebControls.ListItem(answer.Answer));

                var hour = 0;
                var minute = 0;
                var seconds = 0;
                var total = questions.Count;

                while (total > 60)
                {
                    hour++;
                    total -= 60;
                }

                minute = total;

                lblTimer.InnerText = $"{hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}";
                timerClock.Enabled = true;
            }
        }

        protected void timerClock_Tick(object sender, EventArgs e)
        {
            var resultClock = lblTimer.InnerText.Split(':');

            //Seconds
            if (resultClock[2] != minValueMinute)
            {
                resultClock[2] = (int.Parse(resultClock[2]) - 1).ToString().PadLeft(2, '0');
                lblTimer.InnerText = $"{resultClock[0]}:{resultClock[1]}:{resultClock[2]}";
                return;
            }

            //Seconds affect minutes
            if (resultClock[2] == minValueMinute && resultClock[1] != minValueMinute)
            {
                resultClock[2] = maxValueMinute;
                resultClock[1] = (int.Parse(resultClock[1]) - 1).ToString().PadLeft(2, '0');
                lblTimer.InnerText = $"{resultClock[0]}:{resultClock[1]}:{resultClock[2]}";
                return;
            }

            //Minutes affect hours
            if (resultClock[2] == minValueMinute &&
                resultClock[1] == minValueMinute &&
                resultClock[0] != minValueMinute)
            {
                resultClock[2] = maxValueMinute;
                resultClock[1] = maxValueMinute;
                resultClock[0] = (int.Parse(resultClock[0]) - 1).ToString().PadLeft(2, '0');
                lblTimer.InnerText = $"{resultClock[0]}:{resultClock[1]}:{resultClock[2]}";
                return;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(Session["counter"].ToString()) + 1;
            Session["counter"] = counter;

            var questions = (List<ExamQuestion>)Session["listOfQuestions"];

            if (counter <= (questions.Count - 1))
            {
                var itemExam = questions.ElementAt(counter);
                var answers = ((List<ExamAnswer>)Session["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);

                lblQuestions.Text = itemExam.Question;

                Answers.Items.Clear();

                foreach (var answer in answers)
                    Answers.Items.Add(new System.Web.UI.WebControls.ListItem(answer.Answer));

                if (counter == (questions.Count - 1))
                    btnNext.Attributes.Add("disabled", "true");
                else
                    btnNext.Attributes.Remove("disabled");

                btnPrev.Attributes.Remove("disabled");

                updPanelQuestion.Update();
                updAnswers.Update();
                updButtons.Update();
            }
            else
            {
                counter = int.Parse(Session["counter"].ToString()) - 1;
                Session["counter"] = counter;
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(Session["counter"].ToString()) - 1;
            Session["counter"] = counter;

            var questions = (List<ExamQuestion>)Session["listOfQuestions"];

            if (counter >= 0)
            {
                var itemExam = questions.ElementAt(counter);
                var answers = ((List<ExamAnswer>)Session["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);

                lblQuestions.Text = itemExam.Question;

                Answers.Items.Clear();
                updAnswers.Update();

                foreach (var answer in answers)
                    Answers.Items.Add(new System.Web.UI.WebControls.ListItem(answer.Answer));

                btnNext.Attributes.Remove("disabled");
                if (counter == 0)
                    btnPrev.Attributes.Add("disabled", "true");
                else
                    btnPrev.Attributes.Remove("disabled");

                updPanelQuestion.Update();
                updAnswers.Update();
                updButtons.Update();
            }
            else
            {
                counter = int.Parse(Session["counter"].ToString()) + 1;
                Session["counter"] = counter;
            }
        }
    }
}