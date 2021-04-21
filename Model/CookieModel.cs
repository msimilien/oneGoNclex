namespace oneGoNclex.Model
{
    public class CookieModel
    {
        public string RegistrationID { get; set; }
        public string Email { get; set;  }
        public string FullName { get; set; }

        public CookieModel() { }

        public CookieModel(string registrationID, string email, string fullName)
        {
            RegistrationID = registrationID;
            Email = email;
            FullName = fullName;
        }
    }
}