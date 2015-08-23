using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Swimmy
{
    internal static class AuthConfig
    {
        public static void RegisterOpenAuth()
        {
            // Visitare http://go.microsoft.com/fwlink/?LinkId=252803 per informazioni dettagliate sulla configurazione di questa applicazione ASP.NET
            // per il supporto dell'accesso tramite servizi esterni.

            //OpenAuth.AuthenticationClients.AddTwitter(
            //    consumerKey: "codice utente Twitter personale",
            //    consumerSecret: "segreto utente Twitter personale");

            OpenAuth.AuthenticationClients.AddFacebook(
                appId: "1625471347674242",
                appSecret: "1230c9cd19c09d39c6ffb873f3b39886");

            //OpenAuth.AuthenticationClients.AddMicrosoft(
            //    clientId: "ID client account Microsoft personale",
            //    clientSecret: "segreto client account Microsoft personale");

            //OpenAuth.AuthenticationClients.AddGoogle();
        }
    }
}