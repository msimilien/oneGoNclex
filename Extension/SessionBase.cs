using oneGoNclex.Model;
using oneGoNclex.Security;
using System;
using System.Web;
using System.Web.Script.Serialization;

namespace oneGoNclex.Extension
{
    public static class SessionBase
    {
        public static void AddSessionBase(SessionModel model)
        {
            HttpContext.Current.Session.Add("userData", StringCipher.Encrypt(new JavaScriptSerializer().Serialize(model)));
        }

        public static SessionModel GetDataFromSession()
        {
            if (IsValidSession())
            {
                var serialzer = new JavaScriptSerializer();
                var sessionData = StringCipher.Decrypt(HttpContext.Current.Session["userData"].ToString());
                return serialzer.Deserialize<SessionModel>(sessionData);
            }
            return null;
        }

        public static bool IsValidSession()
        {
            var session = HttpContext.Current.Session["userData"]?.ToString();
            return session != null && !string.IsNullOrEmpty(session);
        }

        public static void ClearSession()
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Session["userData"] != null)
                HttpContext.Current.Session.Remove("userData");
        }
    }
}