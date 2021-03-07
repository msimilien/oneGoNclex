namespace oneGoNclex.Model
{
    public class EmailViewModel
    {
        public EmailViewModel(string emailTo, string subject, string body)
        {
            EmailTo = emailTo;
            Subject = subject;
            Body = body;
        }

        public string EmailTo { get; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}