using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Where2Study
{
    public class BaseController : Controller

{
    // Here I have created this for execute each time any controller (inherit this) load
    protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
    {
        string lang = null;
        HttpCookie langCookie = Request.Cookies["_culture"];
        if (langCookie != null)
        {
            lang = langCookie.Value;
        }
        else
        {
            var userLanguage = Request.UserLanguages;
            var userLang = userLanguage != null ? userLanguage[0] : "";
            if (userLang != "")
            {
                lang = userLang;
            }
            else
            {
                lang = SiteLanguages.GetDefaultLanguage();
            }
        }

        new SiteLanguages().SetLanguage(lang);

        return base.BeginExecuteCore(callback, state);
    }
}
}

    /*{
        protected override void ExecuteCore()
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages[0]; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe


            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            base.ExecuteCore();
        }

    }
}*/