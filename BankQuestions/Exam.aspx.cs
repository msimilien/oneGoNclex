using oneGoNclex.Model;
using oneGoNclex.Services;
using System;
using System.Collections.Generic;

namespace oneGoNclex
{
    public partial class Exam : System.Web.UI.Page
    {
        private int counter = 0;
        private List<ExamViewModel> listOfQuestions;

        protected void Page_Load(object sender, EventArgs e)
        {
            listOfQuestions = ExamService.GetQuestionsByBankId(2);

            if (listOfQuestions.Count > 0)
            {
                txtQuestionArea.InnerText = listOfQuestions[counter].Question;
                txtAnswers.InnerText = listOfQuestions[counter].Question;
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
            counter++;
            if (listOfQuestions[counter] != null)
            {
                txtQuestionArea.InnerText = listOfQuestions[counter].Question;
                txtAnswers.InnerText = listOfQuestions[counter].Question;
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            counter--;
            if (listOfQuestions[counter] != null)
            {
                txtQuestionArea.InnerText = listOfQuestions[counter].Question;
                txtAnswers.InnerText = listOfQuestions[counter].Question;
            }
        }
    }
}