using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oneGoNclex
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("mail.onegonclexreview.com",8889); //mail.onegonclexreview.com smtp.live.com
            smtp.Credentials = new System.Net.NetworkCredential("info@onegonclexreview.com", "lexo543*");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage("info@onegonclexreview.com", "info@onegonclexreview.com");
            mail.Subject = "Your contact with OneGo Nclex Review LLC";
            mail.Body = txtdesciption.Text + "---- Mail from:  "+ txtmail.Text;
            //mail.Bcc.Add("info@onegonclexreview.com");
            try
            {
                smtp.Send(mail);
                Response.Redirect("ResponseContact.html");

            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.Message.ToString());
            }

        }

        protected void btnSent2_Click(object sender, EventArgs e)
        {

        }
    }
}