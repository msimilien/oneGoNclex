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
        List<string> listOfQuestions;

        protected void Page_Load(object sender, EventArgs e)
        {
            scripManager1.RegisterAsyncPostBackControl(btnNext);
            scripManager1.RegisterAsyncPostBackControl(btnPrev);

            if (!Page.IsPostBack)
            {
                var bankId = int.Parse(StringCipher.Decrypt(Request.QueryString["bankid"]));
                var serviceResponse = ExamService.GetQuestionsByBankId(bankId);

                ViewState["listOfQuestions"] = serviceResponse.listOfQuestions;
                ViewState["listOfAnswers"] = serviceResponse.listOfAnswers;
                ViewState["listOfAnswersExplanation"] = serviceResponse.listOfExplanations;
                ViewState["counter"] = 0;

                listOfQuestions = new List<string>();
                ViewState["responseQuestions"] = listOfQuestions;

                var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];
                var itemExam = questions.FirstOrDefault();

                if (itemExam is null)
                {
                    var registrationID = Request.QueryString["registrationid"];
                    var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/choose?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                                      $"/bankquestions/choose?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";

                    Response.Redirect(url);
                }

                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID).OrderBy(o => o.Answer);
                var explanation = ((List<ExamAnswerExplanation>)ViewState["listOfAnswersExplanation"]).FirstOrDefault(x => x.QuestionID == itemExam.QuestionID);

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblAnswerExplanation.InnerHtml = explanation?.Explanation;
                lblQuestionsAmount.InnerText = $"1 of {questions.Count()}";
                txtNumberQuestion.Attributes.Add("max", questions.Count().ToString());

                Answers.Items.Clear();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({i},{answer.Asset.ToString().ToLower()},'{answer.QuestionID}')");
                    Answers.Items.Add(item);
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(ViewState["counter"].ToString()) + 1;
            ViewState["counter"] = counter;

            var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];

            if (counter <= (questions.Count - 1))
            {
                var itemExam = questions.ElementAt(counter);
                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID).OrderBy(o => o.Answer);
                var explanation = ((List<ExamAnswerExplanation>)ViewState["listOfAnswersExplanation"]).FirstOrDefault(x => x.QuestionID == itemExam.QuestionID);
                var responseQuestions = (List<string>)ViewState["responseQuestions"];

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblAnswerExplanation.InnerHtml = explanation?.Explanation;
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";
                txtNumberQuestion.Text = (counter + 1).ToString();
                lblAnswerExplanation.Style.Add("display", "none");

                Answers.Items.Clear();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({i},{answer.Asset.ToString().ToLower()},'{answer.QuestionID}')");

                    if (responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString())) != null)
                    {
                        var response = responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString()));
                        item.Selected = response.Split('|')[1] == i.ToString();
                    }

                    Answers.Items.Add(item);
                }

                if (counter >= (questions.Count - 1))
                {
                    btnNext.Attributes.Add("disabled", "true");
                    btnNext.Visible = false;
                    btnFinish.Style["display"] = "block";
                }
                else
                {
                    btnNext.Attributes.Remove("disabled");
                    btnNext.Visible = true;
                    btnFinish.Style["display"] = "none";
                }

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
                counter = int.Parse(ViewState["counter"].ToString()) - 1;
                ViewState["counter"] = counter;
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(ViewState["counter"].ToString()) - 1;
            ViewState["counter"] = counter;

            var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];

            if (counter >= 0)
            {
                var itemExam = questions.ElementAt(counter);
                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID).OrderBy(o => o.Answer);
                var explanation = ((List<ExamAnswerExplanation>)ViewState["listOfAnswersExplanation"]).FirstOrDefault(x => x.QuestionID == itemExam.QuestionID);
                var responseQuestions = (List<string>)ViewState["responseQuestions"];

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblAnswerExplanation.InnerHtml = explanation?.Explanation;
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";
                txtNumberQuestion.Text = (counter + 1).ToString();
                lblAnswerExplanation.Style.Add("display", "none");

                Answers.Items.Clear();
                updAnswers.Update();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({i},{answer.Asset.ToString().ToLower()},'{answer.QuestionID}')");

                    if (responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString())) != null)
                    {
                        var response = responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString()));
                        item.Selected = response.Split('|')[1] == i.ToString();
                    }

                    Answers.Items.Add(item);
                }

                btnNext.Attributes.Remove("disabled");
                btnNext.Visible = true;
                btnFinish.Style["display"] = "none";

                if (counter <= 0)
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
                counter = int.Parse(ViewState["counter"].ToString()) + 1;
                ViewState["counter"] = counter;
            }
        }

        protected void btnShowResponse_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(ViewState["counter"].ToString());
            var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];
            var itemExam = questions.ElementAt(counter);
            var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID).ToList();
            var correctAnswer = answers.FindIndex(x => x.Asset);
            var explanation = ((List<ExamAnswerExplanation>)ViewState["listOfAnswersExplanation"]).FirstOrDefault(x => x.QuestionID == itemExam.QuestionID);

            lblAnswerExplanation.InnerHtml = explanation?.Explanation;
            lblAnswerExplanation.Style.Add("display", "block");

            Answers.Items.Clear();
            updAnswers.Update();

            for (int i = 0; i < answers.Count(); i++)
            {
                var answer = answers.ElementAt(i);
                var item = new ListItem(answer.Answer);
                item.Attributes.Add("onclick", $"checkAnswer({i},{answer.Asset.ToString().ToLower()},'{answer.QuestionID}')");
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

        protected void txtQuestionsAnswered_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuestionsAnswered.Text))
                return;

            var questionID = txtQuestionsAnswered.Text.Split('|')[0];
            var isCorrect = txtQuestionsAnswered.Text.Split('|')[1];
            var answerIndex = txtQuestionsAnswered.Text.Split('|')[2];
            var responseQuestions = (List<string>)ViewState["responseQuestions"];
            var question = responseQuestions.FirstOrDefault(x => x.Contains(questionID));

            if (question != null)
            {
                responseQuestions.Remove(question);
                responseQuestions.Add(questionID + "|" + answerIndex);
            }
            else
                responseQuestions.Add(questionID + "|" + answerIndex);

            ViewState["responseQuestions"] = responseQuestions;
        }

        protected void goToQuestion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumberQuestion.Text))
                return;

            var counter = int.Parse(txtNumberQuestion.Text) - 1;
            ViewState["counter"] = counter;

            var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];

            if (counter <= (questions.Count - 1))
            {
                var itemExam = questions.ElementAt(counter);
                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID).OrderBy(o => o.Answer);
                var explanation = ((List<ExamAnswerExplanation>)ViewState["listOfAnswersExplanation"]).FirstOrDefault(x => x.QuestionID == itemExam.QuestionID);
                var responseQuestions = (List<string>)ViewState["responseQuestions"];

                lblQuestions.Text = itemExam.Question;
                divContentVideoImage.InnerHtml = ExamService.GetVideoOrImageContent(itemExam.PictureQuestion);
                lblAnswerExplanation.InnerHtml = explanation?.Explanation;
                lblQuestionsAmount.InnerText = $"{(counter + 1)} of {questions.Count()}";
                lblAnswerExplanation.Style.Add("display", "none");

                Answers.Items.Clear();

                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers.ElementAt(i);
                    var item = new ListItem(answer.Answer);
                    item.Attributes.Add("onclick", $"checkAnswer({i},{answer.Asset.ToString().ToLower()},'{answer.QuestionID}')");

                    if (responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString())) != null)
                    {
                        var response = responseQuestions.FirstOrDefault(x => x.Contains(answer.QuestionID.ToString()));
                        item.Selected = response.Split('|')[1] == i.ToString();
                    }

                    Answers.Items.Add(item);
                }

                if (counter >= (questions.Count - 1))
                {
                    btnNext.Attributes.Add("disabled", "true");
                    btnNext.Visible = false;
                    btnFinish.Style["display"] = "block";
                }
                else
                {
                    btnNext.Attributes.Remove("disabled");
                    btnNext.Visible = true;
                    btnFinish.Style["display"] = "none";
                }

                btnPrev.Attributes.Remove("disabled");

                lblCorrect.Style.Add("display", "none");
                lblIncorrect.Style.Add("display", "none");

                updPanelMessage.Update();
                updPanelQuestion.Update();
                updPanelQuestions.Update();
                updAnswers.Update();
                updButtons.Update();
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/banks");
        }
    }
}