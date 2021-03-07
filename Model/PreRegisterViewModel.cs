namespace oneGoNclex.Model
{
    public class PreRegisterViewModel
    {
        public PreRegisterViewModel() { }

        public PreRegisterViewModel(string fsName,
                                    string texLast,
                                    string midle,
                                    string socialSecurity,
                                    string address,
                                    string textState,
                                    string textCity,
                                    string zip,
                                    string textPhone,
                                    string textResidenceCountry,
                                    string textEmergencyMail,
                                    string textMail,
                                    string textEmergencyName,
                                    string textEmergencyPhone,
                                    string gedSchool,
                                    string gender,
                                    string lpn,
                                    string bdate,
                                    string password)
        {
            FsName = fsName;
            TexLast = texLast;
            Midle = midle;
            SocialSecurity = socialSecurity;
            Address = address;
            TextState = textState;
            TextCity = textCity;
            Zip = zip;
            TextPhone = textPhone;
            TextResidenceCountry = textResidenceCountry;
            TextEmergencyMail = textEmergencyMail;
            TextMail = textMail;
            TextEmergencyName = textEmergencyName;
            TextEmergencyPhone = textEmergencyPhone;
            GedSchool = gedSchool;
            Gender = gender;
            Lpn = lpn;
            Bdate = bdate;
            Password = password;
        }

        public string FsName { get; }
        public string TexLast { get; }
        public string Midle { get; }
        public string SocialSecurity { get; }
        public string Address { get; }
        public string TextState { get; }
        public string TextCity { get; }
        public string Zip { get; }
        public string TextPhone { get; }
        public string TextResidenceCountry { get; }
        public string TextEmergencyMail { get; }
        public string TextMail { get; }
        public string TextEmergencyName { get; }
        public string TextEmergencyPhone { get; }
        public string GedSchool { get; }
        public string Gender { get; }
        public string Lpn { get; }
        public string Bdate { get; }
        public string Password { get; set; }
    }
}