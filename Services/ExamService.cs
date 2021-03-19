using oneGoNclex.DAL;
using oneGoNclex.Model;
using System.Collections.Generic;
using System.Linq;

namespace oneGoNclex.Services
{
    public class ExamService
    {
        public static (List<ExamQuestion>, List<ExamAnswer>) GetQuestionsByBankId(int bankID)
        {
            var list = ExamData.GetQuestionsByBankId(bankID);
            var listOfQuestions = list.Select(s => new { s.Id, s.Question}).Distinct()
                                      .Select(s => new ExamQuestion { Question = s.Question, QuestionID = s.Id })
                                      .ToList();
            var listOfAnswers = list.Select(s => new { s.Id, s.Response, s.Asset }).Distinct()
                                    .Select(s => new ExamAnswer { QuestionID = s.Id, Answer = s.Response, Asset = s.Asset  })
                                    .ToList();
            return (listOfQuestions, listOfAnswers);
        }
    }
}