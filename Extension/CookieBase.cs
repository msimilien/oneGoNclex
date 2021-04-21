using oneGoNclex.Model;
using oneGoNclex.Security;
using System;
using System.Web;
using System.Web.Script.Serialization;

namespace oneGoNclex.Extension
{
    public static class CookieBase
    {
        public static void AddCookieBase(CookieModel model)
        {
            var cookie = new HttpCookie("userData")
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddDays(30),
                Value = StringCipher.Encrypt(new JavaScriptSerializer().Serialize(model))
            };
            HttpContext.Current.Request.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static CookieModel GetDataFromCookie()
        {
            if (IsValidCookie())
            {
                var serialzer = new JavaScriptSerializer();
                var cookieData = StringCipher.Decrypt(HttpContext.Current.Request.Cookies["userData"].Value);
                return serialzer.Deserialize<CookieModel>(cookieData);
            }
            return null;
        }

        public static bool IsValidCookie()
        {
            var cookie = HttpContext.Current.Request.Cookies["userData"];
            return cookie != null && !string.IsNullOrEmpty(cookie.Value);
        }

        public static void ClearCookie()
        {
            if (HttpContext.Current.Request.Cookies["userData"] != null)
                HttpContext.Current.Response.Cookies["userData"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}