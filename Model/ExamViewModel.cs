using System;

namespace oneGoNclex.Model
{
    public class ExamViewModel
    {
        public ExamViewModel() { }

        public ExamViewModel(Guid id, string question, string pictureQuestion, string videoQuestion)
        {
            Id = id;
            Question = question;
            PictureQuestion = pictureQuestion;
            VideoQuestion = videoQuestion;
        }

        public Guid Id { get; }
        public string Question { get; }
        public string PictureQuestion { get; }
        public string VideoQuestion { get; }
    }
}