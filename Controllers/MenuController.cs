using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;
using Where2Study.Controllers;
using System.Threading;

namespace Where2Study.Controllers
{
    public class MenuController : BaseController
    {
        //w2sRepository browseDB = new w2sRepository();
        //
        // GET: /Menu/
        //public Models.w2sDBDataContext db;

        public ActionResult Index()
        {
            //var continents = w2sRepository.FindAllContinents();


            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var currentLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var continents = from c in db.kontinent_teksts
                             from j in db.jeziks
                             where j.kratica == currentLanguage && c.id_jezik==j.id
                             select c;
                          
            /*var continents = new List<Continent>
            {
                new Continent {Title="Europe"},
                new Continent {Title="Asia"},
                new Continent {Title="Africa"},
                new Continent {Title="North America"},
                new Continent {Title="South America"},
                new Continent {Title="Australia & Oceania"}
            };*/

            return View(continents);
        }

        //
        // GET: /Menu/Continents?continent=""
        public ActionResult Countries(string continent)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext(); 
            var currentLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var countries = from d in db.drzavas
                            from dt in db.drzava_teksts
                            from k in db.kontinents
                            from kt in db.kontinent_teksts
                            from j in db.jeziks
                            where kt.tekst == continent && j.kratica == currentLanguage && dt.id_jezik == j.id && d.id_kontinent == k.id && kt.id_kontinent == k.id && d.id == dt.id_drzava
                            select dt;
                            /*new Country()
                            {
                                tekst = dt.tekst,
                                id_drzava = d.id,
                                id_jezik = j.id
                            };*/
           // var cont = new Continent { Title = continent };
            return View(countries);
        }

        // GET: /Menu/Countries?country=""
        public ActionResult Cities(string country)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var currentLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var cities = from g in db.grads
                         from gt in db.grad_teksts
                         from d in db.drzavas
                         from dt in db.drzava_teksts
                         from j in db.jeziks
                         where dt.naziv==country && j.kratica == currentLanguage && gt.id_jezik == j.id && g.id_drzava==d.id && dt.id_drzava==d.id && g.id==gt.id_grad
                         select gt;
            // var cont = new Continent { Title = continent };
            return View(cities);
        }


        // GET: /Menu/Cities?city=""
        public ActionResult Faculties(string city)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var u = (from ft in db.fakultet_teksts
                    from f in db.fakultets
                    from gt in db.grad_teksts
                    from g in db.grads
                    from dt in db.drzava_teksts
                    from d in db.drzavas
                    from kt in db.kontinent_teksts
                    from j in db.jeziks
                    where gt.naziv==city && j.kratica == currentLanguage && ft.id_fakultet==f.id && f.id_grad==g.id && g.id_drzava==d.id && d.id_kontinent==kt.id_kontinent && gt.id_grad==g.id && dt.id_drzava==d.id && ft.id_jezik==j.id && gt.id_jezik==j.id && dt.id_jezik==j.id && kt.id_jezik==j.id
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

                    }).ToList();
            return View(u);
        }


        //
        // GET: /Menu/Details/*
        public ActionResult Details(string city, string faculty)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
                                     Faculty fac = new Faculty();

            var u = from ft in db.fakultet_teksts
                    from f in db.fakultets
                    from gt in db.grad_teksts
                    from g in db.grads
                    from dt in db.drzava_teksts
                    from d in db.drzavas
                    from kt in db.kontinent_teksts
                    from sv in db.sveucilistes
                    from svt in db.sveuciliste_teksts
                    from j in db.jeziks
                    /*from s in db.stupanjs
                    from st in db.stupanj_teksts
                    from sm in db.smjers
                    from smt in db.smjer_teksts
                    from stsm in db.stupanj_smjers*/
                    where gt.naziv==city && ft.naziv==faculty && j.kratica == currentLanguage && ft.id_fakultet==f.id && f.id_grad==g.id && g.id_drzava==d.id && d.id_kontinent==kt.id_kontinent && gt.id_grad==g.id && dt.id_drzava==d.id && ft.id_jezik==j.id && gt.id_jezik==j.id && dt.id_jezik==j.id && kt.id_jezik==j.id
                    select new Faculty()
                    {
                        Continent = kt.tekst,
                        Country = dt.naziv,
                        City = gt.naziv,
                        Address = f.adresa_fakulteta,
                        Phone = f.broj_telefona,
                        University = svt.naziv,
                        Title = ft.naziv,
                        Description = ft.opis,
                        WebSite = f.web,
                        Photo = f.slika,
                        Specializations = DegSpecDetails(f.id) 
                    };
            foreach (var item in u)
            {
                fac.Continent=item.Continent;
                fac.Country = item.Country;
                fac.City = item.City;
                fac.Address = item.Address;
                fac.Phone = item.Phone;
                fac.University = item.University;
                fac.Title = item.Title;
                fac.Description = item.Description;
                fac.WebSite = item.WebSite;
                fac.Photo = item.Photo;
                fac.Specializations = item.Specializations;
            }

            //return View(new DegreeSpecialization() { partialModel = DegSpecDetails(city, faculty).ToList() });
            return View(fac);
        }

        /*private void SearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            this.Frame.Navigate(typeof(SearchResultsPageExample), args.QueryText);
        }*/

        public ActionResult Search(string q)
        {
            SiteLanguages.GetAllLanguages();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            
            var db = new w2sDataContext();

            var searchList = from ft in db.fakultet_teksts
                             where ft.naziv.Contains("gfgdf")
                             select new Faculty();
            if (!String.IsNullOrEmpty(q))
            {
                searchList = from ft in db.fakultet_teksts
                             from f in db.fakultets
                             from gt in db.grad_teksts
                             from g in db.grads
                             from dt in db.drzava_teksts
                             from d in db.drzavas
                             from kt in db.kontinent_teksts
                             from j in db.jeziks
                             where ft.naziv.Contains(q) && j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
                             select new Faculty()
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
            };
            return View(searchList);
        }

        public List<Where2Study.Models.DegreeSpecialization> DegSpecDetails(int? id_faculty)
        {
            var db = new Where2Study.Models.w2sDataContext();
            var currentLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var u = (from ft in db.fakultet_teksts
                     from f in db.fakultets
                     from j in db.jeziks
                     from s in db.stupanjs
                     from st in db.stupanj_teksts
                     from sm in db.smjers
                     from smt in db.smjer_teksts
                     from stsm in db.stupanj_smjers
                     where f.id == id_faculty && j.kratica == currentLanguage && ft.id_fakultet == f.id && sm.id_fakultet == f.id && stsm.id_stupanj==s.id && stsm.id_smjer == sm.id && sm.id == smt.id_smjer && st.id_stupanj==s.id && st.id_jezik == j.id && smt.id_jezik==j.id
                     select new Where2Study.Models.DegreeSpecialization()
                     {
                         Id = s.id,
                         Degree = st.naziv,
                         Specialization = smt.tekst,
                         Duration = s.trajanje,
                     }).ToList();
            return u;
        }

        public ActionResult DegSpecDetails(string city, string faculty)
        {
            var db = new Where2Study.Models.w2sDataContext();
            var currentLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var u = (from ft in db.fakultet_teksts
                     from f in db.fakultets
                     from j in db.jeziks
                     from s in db.stupanjs
                     from st in db.stupanj_teksts
                     from sm in db.smjers
                     from smt in db.smjer_teksts
                     from stsm in db.stupanj_smjers
                     where ft.naziv == faculty && j.kratica == currentLanguage && ft.id_fakultet == f.id && sm.id_fakultet == f.id && stsm.id_stupanj == s.id && stsm.id_smjer == sm.id && sm.id == smt.id_smjer && st.id_stupanj == s.id && st.id_jezik == j.id && smt.id_jezik == j.id
                     select new Where2Study.Models.DegreeSpecialization()
                     {
                         Id = s.id,
                         Degree = st.naziv,
                         Specialization = smt.tekst,
                         Duration = s.trajanje,
                     }).ToList();
            return View(u);
        }
    }
}
