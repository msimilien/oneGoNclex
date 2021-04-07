using oneGoNclex.Security;
using oneGoNclex.Services;
using System;
using System.Text;

namespace oneGoNclex
{
    public partial class Banks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var html = new StringBuilder();
            var bankListData = BankService.GetBanks();

            foreach (var bank in bankListData)
            {
                var url = "/bankquestions/choose?bankid=" + StringCipher.Encrypt(bank.BankId.ToString());

                html.Append("<div class='col-sm-6'>");
                html.Append($"<img src='{"../" + bank.imageBank}' style='width: 100%; height: 150px' class='rounded'>");
                html.Append("<div class='container'>");
                html.Append("<br />");
                html.Append("<h4 class='font-weight-bold'>" + bank.Name + "</h4>");
                html.Append("<br />");
                html.Append("<div class='border-bottom-0' style='height:200px;overflow-y:auto;margin-bottom:10px;'> " + bank.Description +"</div>");
                html.Append("<p class='text-center'>");
                html.Append("<a class='btn btn-outline-success' href='" + url + "'>");
                html.Append("Open Questions");
                html.Append("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-binoculars-fill' viewBox='0 0 16 16'>");
                html.Append("<path d='M4.5 1A1.5 1.5 0 0 0 3 2.5V3h4v-.5A1.5 1.5 0 0 0 5.5 1h-1zM7 4v1h2V4h4v.882a.5.5 0 0 0 .276.447l.895.447A1.5 1.5 0 0 1 15 7.118V13H9v-1.5a.5.5 0 0 1 .146-.354l.854-.853V9.5a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5v.793l.854.853A.5.5 0 0 1 7 11.5V13H1V7.118a1.5 1.5 0 0 1 .83-1.342l.894-.447A.5.5 0 0 0 3 4.882V4h4zM1 14v.5A1.5 1.5 0 0 0 2.5 16h3A1.5 1.5 0 0 0 7 14.5V14H1zm8 0v.5a1.5 1.5 0 0 0 1.5 1.5h3a1.5 1.5 0 0 0 1.5-1.5V14H9zm4-11H9v-.5A1.5 1.5 0 0 1 10.5 1h1A1.5 1.5 0 0 1 13 2.5V3z' />");
                html.Append("</svg>");
                html.Append("</a>");
                html.Append("</p>");
                html.Append("</div>");
                html.Append("</div>");
            }

            bankList.InnerHtml = html.ToString();
        }
    }
}