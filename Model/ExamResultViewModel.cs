namespace oneGoNclex.Model
{
    public class ExamResultViewModel
    {
        public ExamResultViewModel() { }

        public ExamResultViewModel(string studentID, int bankID, int point, float qualification)
        {
            StudentID = studentID;
            BankID = bankID;
            Point = point;
            Qualification = qualification;
        }
        public ExamResultViewModel(string studentID, int bankID, int point, float qualification,int pass, int fail)
        {
            StudentID = studentID;
            BankID = bankID;
            Point = point;
            Qualification = qualification;
            totalPass = pass;
            totalFail = fail;
        }

        public string StudentID { get; set; }
        public int BankID { get; set; }
        public int Point { get; set; }
        public float Qualification { get; set; }
        public int totalPass { get; set; }
        public int totalFail { get; set; }
    }
}