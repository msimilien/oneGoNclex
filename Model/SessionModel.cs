namespace oneGoNclex.Model
{
    public class SessionModel
    {
        public string RegistrationID { get; set; }
        public string Email { get; set;  }
        public string FullName { get; set; }

        public SessionModel() { }

        public SessionModel(string registrationID, string email, string fullName)
        {
            RegistrationID = registrationID;
            Email = email;
            FullName = fullName;
        }
    }
}