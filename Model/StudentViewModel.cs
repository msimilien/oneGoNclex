namespace oneGoNclex.Model
{
    public class StudentViewModel
    {
        public StudentViewModel() { }

        public StudentViewModel(string registrationID,
                                string firstName,
                                string middleName,
                                string lastName,
                                string dateOfBirth,
                                string adress,
                                string socialSecurity,
                                string phoneNumber,
                                string emergencyPhone,
                                string registrationDate,
                                string email,
                                string emergencyMail,
                                string emergencyName,
                                string residenceCountry,
                                string gender,
                                string highSchool_GED,
                                string actif,
                                string group,
                                string lPNDiploma,
                                string password)
        {
            RegistrationID = registrationID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Adress = adress;
            SocialSecurity = socialSecurity;
            PhoneNumber = phoneNumber;
            EmergencyPhone = emergencyPhone;
            RegistrationDate = registrationDate;
            Email = email;
            EmergencyMail = emergencyMail;
            EmergencyName = emergencyName;
            ResidenceCountry = residenceCountry;
            Gender = gender;
            HighSchool_GED = highSchool_GED;
            Actif = actif;
            Group = group;
            LPNDiploma = lPNDiploma;
            Password = password;
        }

        public string RegistrationID { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string DateOfBirth { get; }
        public string Adress { get; }
        public string SocialSecurity { get; }
        public string PhoneNumber { get; }
        public string EmergencyPhone { get; }
        public string RegistrationDate { get; }
        public string Email { get; }
        public string EmergencyMail { get; }
        public string EmergencyName { get; }
        public string ResidenceCountry { get; }
        public string Gender { get; }
        public string HighSchool_GED { get; }
        public string Actif { get; }
        public string Group { get; }
        public string LPNDiploma { get; }
        public string Password { get; set; }
    }

    public class SearchStudentViewModel
    {
        public SearchStudentViewModel(string registrationID, string email)
        {
            RegistrationID = registrationID;
            Email = email;
        }

        public string RegistrationID { get; }
        public string Email { get; }
    }
}