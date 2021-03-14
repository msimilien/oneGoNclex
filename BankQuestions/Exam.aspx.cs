using oneGoNclex.Model;
using oneGoNclex.Services;
using System;
using System.Collections.Generic;

namespace oneGoNclex
{
    public partial class Exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            scripManager1.RegisterAsyncPostBackControl(btnNext);
            scripManager1.RegisterAsyncPostBackControl(btnPrev);

            if (!Page.IsPostBack)
            {
                Session["listOfQuestions"] = ExamService.GetQuestionsByBankId(2);
                Session["counter"] = 0;

                if ((Session["listOfQuestions"] as List<ExamViewModel>).Count > 0)
                {
                    lblQuestions.Text = (Session["listOfQuestions"] as List<ExamViewModel>)[0].Question;
                    //txtAnswers.InnerText = listOfQuestions[counter].Question;
                }
            }
        }

        protected void timerClock_Tick(object sender, EventArgs e)
        {
            var resultClock = lblTimer.InnerText.Split(':');

            //Seconds
            if (resultClock[2] != "00")
                resultClock[2] = (int.Parse(resultClock[2]) - 1).ToString().PadLeft(2, '0');

            //Seconds affect minutes
            if (resultClock[2] == "00" && resultClock[1] != "00")
            {
                resultClock[2] = "59";
                resultClock[1] = (int.Parse(resultClock[1]) - 1).ToString().PadLeft(2, '0');
            }

            //Minutes affect hours
            if (resultClock[1] == "00" && resultClock[0] != "00")
            {
                resultClock[1] = "59";
                resultClock[0] = (int.Parse(resultClock[1]) - 1).ToString().PadLeft(2, '0');
            }

            lblTimer.InnerText = $"{resultClock[0]}:{resultClock[1]}:{resultClock[2]}";
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var counter = int.Parse(Session["counter"].ToString()) + 1;
            var listQuestions = (Session["listOfQuestions"] as List<ExamViewModel>);
            Session["counter"] = counter;

            if (counter <= (listQuestions.Count - 1))
            {
                lblQuestions.Text = listQuestions[counter].Question;
                //txtAnswers.InnerText = listOfQuestions[counter].Question;

                if (counter == (listQuestions.Count - 1))
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
            var listQuestions = (Session["listOfQuestions"] as List<ExamViewModel>);
            Session["counter"] = counter;

            if (counter >= 0)
            {
                lblQuestions.Text = listQuestions[counter].Question;
                //txtAnswers.InnerText = listOfQuestions[counter].Question;

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