namespace oneGoNclex.Model
{
    public class ExternalLoginViewModel
    {
        public ExternalLoginViewModel() { }

        public ExternalLoginViewModel(string fsName,
                                    string texLast,
                                    string textPhone,
                                    string textMail,
                                    string password)
        {
            FsName = fsName;
            TexLast = texLast;
            TextPhone = textPhone;
            TextMail = textMail;
            Password = password;
        }

        public string FsName { get; }
        public string TexLast { get; }
        public string TextPhone { get; }
        public string TextMail { get; }
        public string Password { get; set; }
    }
}