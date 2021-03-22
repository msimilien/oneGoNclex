using oneGoNclex.Model;
using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace oneGoNclex
{
    public partial class Exam : System.Web.UI.Page
    {
        List<string> listOfCorrectQuestions;
        List<string> listOfQuestions;
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

                Session["listOfQuestions"] = serviceResponse.Item1.Take(10).ToList();
                Session["listOfAnswers"] = serviceResponse.Item2;
                Session["counter"] = 0;

                listOfCorrectQuestions = new List<string>();
                listOfQuestions = new List<string>();
                Session["responseCorrectQuestions"] = listOfCorrectQuestions;
                Session["responseQuestions"] = listOfQuestions;

                var questions = (List<ExamQuestion>)Session["listOfQuestions"];
                var itemExam = questions.FirstOrDefault();

                if (itemExam is null)
                {
                    var url = "/bankquestions/choose?bankid=" + StringCipher.Decrypt(Request.QueryString["bankid"]);
                    Response.Redirect(url);
                }

                var answers = ((List<ExamAnswer>)Session["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblQuestionsAmount.InnerText = $"1 of {questions.Count()}";

                Answers.Items.Clear();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer('{answer.QuestionID}',{answer.Asset.ToString().ToLower()},{i})");
                    Answers.Items.Add(item);
                }

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
                var responseQuestions = (List<string>)Session["responseQuestions"];

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";

                Answers.Items.Clear();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer('{answer.QuestionID}',{answer.Asset.ToString().ToLower()},{i})");

                    if (responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString())) != null)
                    {
                        var response = responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString()));
                        item.Selected = response.Split('|')[1] == i.ToString();
                    }

                    Answers.Items.Add(item);
                }

                if (counter == (questions.Count - 1))
                {
                    btnNext.Attributes.Add("disabled", "true");
                    btnNext.Visible = false;
                    btnFinish.Visible = true;
                }
                else
                {
                    btnNext.Attributes.Remove("disabled");
                    btnNext.Visible = true;
                    btnFinish.Visible = false;
                }

                btnPrev.Attributes.Remove("disabled");

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
                var responseQuestions = (List<string>)Session["responseQuestions"];

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";

                Answers.Items.Clear();
                updAnswers.Update();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer('{answer.QuestionID}',{answer.Asset.ToString().ToLower()},{i})");

                    if (responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString())) != null)
                    {
                        var response = responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString()));
                        item.Selected = response.Split('|')[1] == i.ToString();
                    }

                    Answers.Items.Add(item);
                }

                btnNext.Attributes.Remove("disabled");
                btnNext.Visible = true;
                btnFinish.Visible = false;

                if (counter == 0)
                    btnPrev.Attributes.Add("disabled", "true");
                else
                    btnPrev.Attributes.Remove("disabled");

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

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            var questions = (List<ExamQuestion>)Session["listOfQuestions"];
            var totalQuestions = questions.Count;
            var responseQuestions = (List<string>)Session["responseCorrectQuestions"];
            var totalExam = ((responseQuestions.Count * 100) / totalQuestions);

            //TODO 1: Almacenar el valor en la base de datos
            //TODO 2: Cambiarlo de pantalla a una que de como una intro + el resultado del examen
        }

        protected void txtQuestionsAnswered_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuestionsAnswered.Text))
                return;

            var questionID = txtQuestionsAnswered.Text.Split('|')[0];
            var isCorrect = txtQuestionsAnswered.Text.Split('|')[1];
            var answerIndex = txtQuestionsAnswered.Text.Split('|')[2];
            var responseCorrectQuestions = (List<string>)Session["responseCorrectQuestions"];
            var correctQuestion = responseCorrectQuestions.FirstOrDefault(x => x == questionID);

            if (correctQuestion == null && isCorrect == "1")
                responseCorrectQuestions.Add(questionID);

            if (correctQuestion != null && isCorrect == "0")
                responseCorrectQuestions.Remove(questionID);

            Session["responseCorrectQuestions"] = responseCorrectQuestions;

            var responseQuestions = (List<string>)Session["responseQuestions"];
            var question = responseQuestions.FirstOrDefault(x => x.Contains(questionID));

            if (question != null)
            {
                responseQuestions.Remove(question);
                responseQuestions.Add(questionID + "|" + answerIndex);
            }
            else
                responseQuestions.Add(questionID + "|" + answerIndex);

            Session["responseQuestions"] = responseQuestions;
        }
    }
}