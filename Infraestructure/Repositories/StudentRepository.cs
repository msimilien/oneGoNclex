using oneGoNclex.Infraestructure;
using oneGoNclex.Model;
using System;
using System.Linq;

namespace oneGoNclex.DAL
{
    public class StudentData
    {
        public StudentViewModel GetStudentByRegistrationIdAndEmail(SearchStudentViewModel model)
        {
            using (var db = new NCLEXREVIEWEntities())
            {
                var student = db.Students.FirstOrDefault(x => x.Email == model.Email && x.RegistrationID == model.RegistrationID);

                if (student == null)
                    throw new Exception("No student was found.");

                return new StudentViewModel(student.RegistrationID,
                    student.FirstName,
                    student.MiddleName,
                    student.LastName,
                    student.DateOfBirth.ToString("MM-dd-YYYY"),
                    student.Adress,
                    student.SocialSecurity,
                    student.PhoneNumber,
                    student.EmergencyPhone,
                    student.RegistrationDate.ToString("MM-dd-YYYY"),
                    student.Email,
                    student.EmergencyMail,
                    student.EmergencyName,
                    student.ResidenceCountry,
                    student.Gender,
                    student.HighSchool_GED,
                    student.Actif,
                    student.Group,
                    student.LPNDiploma,
                    student.Password);
            }
        }
    }
}