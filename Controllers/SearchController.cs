using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index(string search)
        {
            SiteLanguages.GetAllLanguages();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;

            var db = new w2sDBDataContext();
            var searchList = from ft in db.fakultet_teksts
                             from f in db.fakultets
                             from gt in db.grad_teksts
                             from g in db.grads
                             from dt in db.drzava_teksts
                             from d in db.drzavas
                             from kt in db.kontinent_teksts
                             from j in db.jeziks
                             where ft.naziv.Contains("Odjel za") && j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
                             select new University()
                             {
                                 Continent = kt.tekst,
                                 Country = dt.naziv,
                                 City = gt.naziv,
                                 Address = f.adresa_fakulteta,
                                 Phone = f.broj_telefona,
                                 Title = ft.naziv,
                                 Description = ft.opis,
                                 WebSite = f.web
                             };
            return View(searchList);
        }

        //
        // GET: /Search/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
