using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Swimmy;

namespace Swimmy
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Codice eseguito all'avvio dell'applicazione
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Codice eseguito all'arresto dell'applicazione

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Codice eseguito in caso di errore non gestito

        }
    }
}
