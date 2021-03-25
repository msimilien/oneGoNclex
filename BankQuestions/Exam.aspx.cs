﻿using oneGoNclex.Model;
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

                ViewState["listOfQuestions"] = serviceResponse.Item1;
                ViewState["listOfAnswers"] = serviceResponse.Item2;
                ViewState["counter"] = 0;

                listOfCorrectQuestions = new List<string>();
                listOfQuestions = new List<string>();
                ViewState["responseCorrectQuestions"] = listOfCorrectQuestions;
                ViewState["responseQuestions"] = listOfQuestions;

                var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];
                var itemExam = questions.FirstOrDefault();

                if (itemExam is null)
                {
                    var url = "/bankquestions/choose?bankid=" + StringCipher.Decrypt(Request.QueryString["bankid"]);
                    Response.Redirect(url);
                }

                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);

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
            var counter = int.Parse(ViewState["counter"].ToString()) + 1;
            ViewState["counter"] = counter;

            var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];

            if (counter <= (questions.Count - 1))
            {
                var itemExam = questions.ElementAt(counter);
                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);
                var responseQuestions = (List<string>)ViewState["responseQuestions"];

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
                var answers = ((List<ExamAnswer>)ViewState["listOfAnswers"]).Where(x => x.QuestionID == itemExam.QuestionID);
                var responseQuestions = (List<string>)ViewState["responseQuestions"];

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
                counter = int.Parse(ViewState["counter"].ToString()) + 1;
                ViewState["counter"] = counter;
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            var questions = (List<ExamQuestion>)ViewState["listOfQuestions"];
            var totalQuestions = questions.Count;
            var responseQuestions = (List<string>)ViewState["responseCorrectQuestions"];
            var totalExam = ((responseQuestions.Count * 100) / totalQuestions);
            var bankId = int.Parse(StringCipher.Decrypt(Request.QueryString["bankid"]));
            var email = StringCipher.Decrypt(Request.QueryString["email"]);
            var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);

            int externalLoginID = 0;
            if (string.IsNullOrEmpty(registrationID))
                externalLoginID = ExternalLoginService.GetIdByEmail(email);

            var model = new ExamResultViewModel
            {
                BankID = bankId,
                Qualification = totalExam,
                Point = totalQuestions,
                StudentID = string.IsNullOrEmpty(registrationID) ? externalLoginID.ToString() : registrationID
            };

            ExamService.RegisterExamResult(model);

            Session["examResult"] = model;

            var url = !string.IsNullOrEmpty(registrationID) ? $"/bankquestions/examresult?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}" :
                                                              $"/bankquestions/examresult?bankid={Request.QueryString["bankid"]}&email={Request.QueryString["email"]}";

            Response.Redirect(url);
        }

        protected void txtQuestionsAnswered_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuestionsAnswered.Text))
                return;

            var questionID = txtQuestionsAnswered.Text.Split('|')[0];
            var isCorrect = txtQuestionsAnswered.Text.Split('|')[1];
            var answerIndex = txtQuestionsAnswered.Text.Split('|')[2];
            var responseCorrectQuestions = (List<string>)ViewState["responseCorrectQuestions"];
            var correctQuestion = responseCorrectQuestions.FirstOrDefault(x => x == questionID);

            if (correctQuestion == null && isCorrect == "1")
                responseCorrectQuestions.Add(questionID);

            if (correctQuestion != null && isCorrect == "0")
                responseCorrectQuestions.Remove(questionID);

            ViewState["responseCorrectQuestions"] = responseCorrectQuestions;

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
    }
}