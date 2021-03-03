using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oneGoNclex
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("mail.onegonclexreview.com", 8889)
            {
                Credentials = new System.Net.NetworkCredential("info@onegonclexreview.com", "lexo543*"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            }; //mail.onegonclexreview.com smtp.live.com
            MailMessage mail = new MailMessage("info@onegonclexreview.com", txtEmail.Text)
            {
                Subject = "Recover password with OneGo Nclex Review LLC",
                Body =  $"Please use this <a href='{Request.Url.OriginalString.Replace(Request.Url.LocalPath, "") + "/bankquestions/recoverpassword"}'>link</a> to recover "
            };
            mail.IsBodyHtml = true;
            try
            {
                smtp.Send(mail);
                Response.Redirect("ResponseContact.html");

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message.ToString());
            }

        }
    }
}