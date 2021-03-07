using oneGoNclex.Model;
using oneGoNclex.Services;
using System;

namespace oneGoNclex
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            var model = PreRegisterService.GetById(int.Parse(Request.QueryString["id"]));
            model.Password = txtPassword.Text;
            AddStudent(model);
        }

        #region Methods

        private void AddStudent(PreRegisterViewModel model)
        {
            StudentService.Add(model);
        }

        #endregion
    }
}