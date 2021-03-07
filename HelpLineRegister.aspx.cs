using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class HelpLineRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            addRegister();
            Response.Redirect("ResponseContact.html");
        }

        private void addRegister()
        {
            string gedSchool = null, gender = null, lpn = null;
            string FsName = Request.Form["TextFname"];
            string TexLast = Request.Form["TexLast"];
            string midle = Request.Form["TextMdleName"];
            string SocialSecurity = Request.Form["TxtSocialSecurity"];
            string Address = Request.Form["TextAddress"];
            string TextState = Request.Form["TextState"];
            string TextCity = Request.Form["TextCity"];
            string Zip = Request.Form["Zip"];
            string TextPhone = Request.Form["TextPhone"];
            string TextResidenceCountry = Request.Form["TextResidenceCountry"];
            string TextMail = Request.Form["TextMail"];
            string TextEmergencyMail = Request.Form["TextEmergencyMail"];
            string TextEmergencyName = Request.Form["TextEmergencyName"];
            string TextEmergencyPhone = Request.Form["TextEmergencyPhone"];
            
            gender = Request.Form["SelectGender"].ToString();
            lpn = Request.Form["CheckboxLPN"];
            gedSchool = Request.Form["CheckboxHighSchool"];
            string bdate = Request.Form["TextBirthDate"];
            lpn = string.IsNullOrEmpty(lpn) ? "no" : "yes";
            gedSchool = string.IsNullOrEmpty(lpn) ? "no" : "yes";

            PreRegisterService.Add(new Model.PreRegisterViewModel
            (
                FsName,
                TexLast,
                midle,
                SocialSecurity,
                Address,
                TextState,
                TextCity,
                Zip,
                TextPhone,
                TextResidenceCountry,
                TextEmergencyMail,
                TextMail,
                TextEmergencyName,
                TextEmergencyPhone,
                gedSchool,
                gender,
                lpn,
                bdate,
                null
            ));
        }
    }
}