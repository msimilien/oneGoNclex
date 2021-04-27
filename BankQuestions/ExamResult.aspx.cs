using oneGoNclex.Extension;
using oneGoNclex.Model;
using oneGoNclex.Security;
using System;
using System.Drawing;

namespace oneGoNclex
{
    public partial class ExamResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionBase.IsValidSession())
                loginAction.Attributes.CssStyle["display"] = "block";

            if (!Page.IsPostBack)
            {
                var qualification = ((ExamResultViewModel)Session["examResult"]).Qualification;
                var pass = ((ExamResultViewModel)Session["examResult"]).totalPass;
                var fail = ((ExamResultViewModel)Session["examResult"]).totalFail;
                LblPass.Text = pass.ToString();
                lblFail.Text = fail.ToString();
                lblResult.Text = qualification.ToString() + "%";

                if (qualification >= 70)
                    lblResult.ForeColor = Color.Green;
                else
                    lblResult.ForeColor = Color.Red;

                lblResult.Font.Size = 24;
                lblFail.Font.Size = 24;
                LblPass.Font.Size = 24;
                lblFail.ForeColor = Color.Red;
                LblPass.ForeColor = Color.Green;

                Session.Remove("examResult");
            }
         
        }

        protected void btnKckToBank_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Banks.aspx");
        }

        protected void btnRetake_Click(object sender, EventArgs e)
        {
            var registrationID = StringCipher.Decrypt(Request.QueryString["registrationid"]);
            if(!string.IsNullOrEmpty(registrationID))
                Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}");


        }
    }
}