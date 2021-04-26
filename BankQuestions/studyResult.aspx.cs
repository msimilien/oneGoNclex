using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oneGoNclex.BankQuestions
{
    public partial class studyResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRetake_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/bankquestions/preexam?bankid={Request.QueryString["bankid"]}&registrationid={Request.QueryString["registrationid"]}&email={Request.QueryString["email"]}");
        }

        protected void btnKckToBank_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/Banks.aspx");
        }
    }
}