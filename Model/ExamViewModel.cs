using System;

namespace oneGoNclex.Model
{
    public class ExamViewModel
    {
        public ExamViewModel() { }

        public ExamViewModel(Guid id,
                             string question,
                             string questionType,
                             string pictureQuestion,
                             string subject,
                             string response,
                             bool asset,
                             string explanation)
        {
            Id = id;
            Question = question;
            QuestionType = questionType;
            PictureQuestion = pictureQuestion;
            Subject = subject;
            Response = response;
            Asset = asset;
            Explanation = explanation;
        }

        public Guid Id { get; }
        public string Question { get; }
        public string QuestionType { get; }
        public string PictureQuestion { get; }
        public string Subject { get; }
        public string Response { get; }
        public bool Asset { get; }
        public string Explanation { get; }
    }

    [Serializable]
    public class ExamQuestion
    {
        public Guid QuestionID { get; set; }
        public string Question { get; set; }
        public string PictureQuestion { get; set; }
    }

    [Serializable]
    public class ExamAnswer
    {
        public Guid QuestionID { get; set; }
        public string Answer { get; set; }
        public bool Asset { get; set; }
    }

    [Serializable]
    public class ExamAnswerExplanation
    {
        public Guid QuestionID { get; set; }
        public string Explanation { get; set; }
    }
}