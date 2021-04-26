using oneGoNclex.Extension;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace oneGoNclex
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs E)
        {
            SessionBase.ClearSession();
        }

        void Session_End(object sender, EventArgs E)
        {
            SessionBase.ClearSession();
        }
    }
}