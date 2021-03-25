using oneGoNclex.Model;
using System;
using System.Drawing;

namespace oneGoNclex
{
    public partial class ExamResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var qualification = ((ExamResultViewModel)Session["examResult"]).Qualification;
            lblResult.Text = qualification.ToString() + "%";

            if (qualification >= 70)
                lblResult.ForeColor = Color.Green;
            else
                lblResult.ForeColor = Color.Red;

            lblResult.Font.Size = 24;

            Session.Remove("examResult");
        }
    }
}