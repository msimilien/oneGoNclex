using oneGoNclex.DAL;
using oneGoNclex.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oneGoNclex.Services
{
    public class ExamService
    {
        public static (List<ExamQuestion>, List<ExamAnswer>) GetQuestionsByBankId(int bankID)
        {
            var list = ExamData.GetQuestionsByBankId(bankID);
            var listOfQuestions = list.Select(s => new { s.Id, s.Question, s.PictureQuestion}).Distinct()
                                      .Select(s => new ExamQuestion { Question = s.Question, QuestionID = s.Id, PictureQuestion = s.PictureQuestion })
                                      .ToList();
            var listOfAnswers = list.Select(s => new { s.Id, s.Response, s.Asset }).Distinct()
                                    .Select(s => new ExamAnswer { QuestionID = s.Id, Answer = s.Response, Asset = s.Asset  })
                                    .ToList();
            return (listOfQuestions, listOfAnswers);
        }

        public static string GetVideoOrImageContent(string content)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(content))
            {
                var html = new StringBuilder();

                if (content.EndsWith(".mp4"))
                {
                    html.Append("<video width='500' controls>");
                    html.Append($"<source src='{"../" + content}' type='video/mp4'>");
                    html.Append("</video>");
                }
                else
                {
                    html.Append($"<img src='{"../" + content}' />");
                }

                result = html.ToString();
            }

            return result;
        }
    }
}