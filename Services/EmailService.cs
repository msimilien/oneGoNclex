using oneGoNclex.Model;
using System.Configuration;
using System.Net.Mail;

namespace oneGoNclex.Services
{
    public class EmailService
    {
        public static bool SendEmail(EmailViewModel emailViewModel)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["host"], int.Parse(ConfigurationManager.AppSettings["port"]))
                {
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                }; //mail.onegonclexreview.com smtp.live.com
                MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["username"], emailViewModel.EmailTo)
                {
                    Subject = emailViewModel.Subject,
                    Body = emailViewModel.Body
                };
                mail.IsBodyHtml = true;

                smtp.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}