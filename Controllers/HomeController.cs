using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;
using Where2Study.Controllers;

namespace Where2Study.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            SiteLanguages.GetAllLanguages();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Continent con)
        {
            return View();
        }
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeLanguage(string lang)
        {
            SiteLanguages.GetAllLanguages();
            new SiteLanguages().SetLanguage(lang);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

       
    }


    /*{
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var dataContext = new w2sDBDataContext();
            var continents = from m in dataContext.kontinent_teksts
                             where m.id_jezik == 4
                             select m;
            return View(continents);
        }

    }*/
}
