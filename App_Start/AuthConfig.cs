using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Where2Study.Models;

namespace Where2Study
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            /*OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "",
                clientSecret: "");*/

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "ByJ67fuHChilR15yQsaCtMsox",
                consumerSecret: "PrPv9FnCeqHC1CtGgOuPuCdlfmtrfRazoJXx3N1A0pW4lcdBMj");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "349228458607862",
                appSecret: "46b7d199e54be0c1c10a54168525cc1f");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
