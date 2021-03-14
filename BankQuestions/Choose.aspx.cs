using System;

namespace oneGoNclex
{
    public partial class Choose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/studentaccess?bankid=" + Request.QueryString["bankid"]);
        }

        protected void btnExternal_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bankquestions/login?bankid=" + Request.QueryString["bankid"]);
        }
    }
}