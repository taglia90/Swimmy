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

            //OpenAuth.AuthenticationClients.AddFacebook(
            //    appId: "ID app Facebook personale",
            //    appSecret: "segreto app Facebook personale");

            //OpenAuth.AuthenticationClients.AddMicrosoft(
            //    clientId: "ID client account Microsoft personale",
            //    clientSecret: "segreto client account Microsoft personale");

            //OpenAuth.AuthenticationClients.AddGoogle();
        }
    }
}