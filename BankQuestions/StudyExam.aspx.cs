using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace oneGoNclex
{
    public partial class StudyExam : System.Web.UI.Page
    {
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
                lblQuestionsAmount.InnerText = $"1 of {questions.Count()}";

                Answers.Items.Clear();

                foreach (var answer in answers)
                {
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({0},{answer.Asset.ToString().ToLower()})");
                    Answers.Items.Add(item);
                }
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
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";

                Answers.Items.Clear();

                foreach (var answer in answers)
                {
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({counter},{answer.Asset.ToString().ToLower()})");
                    Answers.Items.Add(item);
                }

                if (counter == (questions.Count - 1))
                    btnNext.Attributes.Add("disabled", "true");
                else
                    btnNext.Attributes.Remove("disabled");

                btnPrev.Attributes.Remove("disabled");

                lblCorrect.Style.Add("display", "none");
                lblIncorrect.Style.Add("display", "none");

                updPanelMessage.Update();
                updPanelQuestion.Update();
                updPanelQuestions.Update();
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
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";

                Answers.Items.Clear();
                updAnswers.Update();

                foreach (var answer in answers)
                {
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({counter},{answer.Asset.ToString().ToLower()})");
                    Answers.Items.Add(item);
                }

                btnNext.Attributes.Remove("disabled");
                if (counter == 0)
                    btnPrev.Attributes.Add("disabled", "true");
                else
                    btnPrev.Attributes.Remove("disabled");

                lblCorrect.Style.Add("display", "none");
                lblIncorrect.Style.Add("display", "none");

                updPanelMessage.Update();
                updPanelQuestion.Update();
                updPanelQuestions.Update();
                updAnswers.Update();
                updButtons.Update();
            }
            else
            {
                counter = int.Parse(Session["counter"].ToString()) + 1;
                Session["counter"] = counter;
            }
        }

        protected void btnShowResponse_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(Session["counter"].ToString());
            var questions = (List<ExamQuestion>)Session["listOfQuestions"];
            var itemExam = questions.ElementAt(counter);
            var answers = ((List<ExamAnswer>)Session["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID).ToList();
            var correctAnswer = answers.FindIndex(x => x.Asset);

            Answers.Items.Clear();
            updAnswers.Update();

            foreach (var answer in answers)
            {
                var item = new ListItem(answer.Answer);
                item.Attributes.Add("onclick", $"checkAnswer({counter},{answer.Asset.ToString().ToLower()})");
                item.Selected = answer.Asset;
                Answers.Items.Add(item);
            }

            lblCorrect.Style.Add("display", "block");
            lblIncorrect.Style.Add("display", "none");
            updPanelMessage.Update();

            if (counter == 0)
                btnPrev.Attributes.Add("disabled", "true");
            else
                btnPrev.Attributes.Remove("disabled");

            updAnswers.Update();
            updButtons.Update();
        }
    }
}