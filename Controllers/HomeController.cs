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
            var db = new w2sDataContext();
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var u = from ft in db.fakultet_teksts
                    from f in db.fakultets
                    from gt in db.grad_teksts
                    from g in db.grads
                    from dt in db.drzava_teksts
                    from d in db.drzavas
                    from kt in db.kontinent_teksts
                    from j in db.jeziks
                    /*from s in db.stupanjs
                    from st in db.stupanj_teksts
                    from sm in db.smjers
                    from smt in db.smjer_teksts
                    from stsm in db.stupanj_smjers*/
                    where j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
                    select new Faculty()
                    {
                        Continent = kt.tekst,
                        Country = dt.naziv,
                        City = gt.naziv,
                        Address = f.adresa_fakulteta,
                        Phone = f.broj_telefona,
                        Title = ft.naziv,
                        Description = ft.opis,
                        WebSite = f.web,
                        Photo = f.slika

                    };
            return View(u);
        }


        [HttpPost]
        public ActionResult Index(Faculty fak)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var u = from ft in db.fakultet_teksts
                    from f in db.fakultets
                    from gt in db.grad_teksts
                    from g in db.grads
                    from dt in db.drzava_teksts
                    from d in db.drzavas
                    from kt in db.kontinent_teksts
                    from j in db.jeziks
                    /*from s in db.stupanjs
                    from st in db.stupanj_teksts
                    from sm in db.smjers
                    from smt in db.smjer_teksts
                    from stsm in db.stupanj_smjers*/
                    where j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
                    select new Faculty()
                    {
                        Continent = kt.tekst,
                        Country = dt.naziv,
                        City = gt.naziv,
                        Address = f.adresa_fakulteta,
                        Phone = f.broj_telefona,
                        Title = ft.naziv,
                        Description = ft.opis,
                        WebSite = f.web,
                        Photo = f.slika

                    };
            //return View(new DegreeSpecialization() { partialModel = DegSpecDetails(city, faculty).ToList() });
            return View(u);
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
            var dataContext = new w2sDataContext();
            var continents = from m in dataContext.kontinent_teksts
                             where m.id_jezik == 4
                             select m;
            return View(continents);
        }

    }*/
}
