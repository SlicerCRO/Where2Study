using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Where2Study.Models
{
    public class w2sRepository : Controller
    {
        //
        // GET: /w2sRepository/

        private w2sDBDataContext db = new w2sDBDataContext();

        //
        // Query Methods

        public IQueryable<kontinent_tekst> FindAllContinents()
        {
            return db.kontinent_teksts;
        }

        public IQueryable<drzava_tekst> FindAllCountries()
        {
            return db.drzava_teksts;
        }

        public drzava_tekst Get_drzava_tekst(int id)
        {
            return db.drzava_teksts.SingleOrDefault(d => d.id==id);
        }


        public void Add(drzava_tekst country)
        {
            /*var d = from dt in db.drzava_teksts
                    select new Country()
                    {
                        tekst = dt.naziv,
                        id_drzava = dt.id_drzava,
                        id_jezik = dt.id_jezik
                    };*/
            var v = false;
            foreach (var item in db.drzava_teksts)
            {
                if (item.naziv==country.naziv) v = true;
            };
            if (v==false) 
            {
                db.drzava_teksts.InsertOnSubmit(country);
            }
        }

        public void Delete(drzava_tekst country)
        {
           db.drzava_teksts.DeleteOnSubmit(country);
            //db.drzavas.DeleteOnSubmit(country);
        }
        

        public IQueryable<grad_tekst> FindAllCities()
        {
            return db.grad_teksts;
        }

        public IQueryable<fakultet_tekst> FindAllUniversities()
        {
            return db.fakultet_teksts;
        }

        public string ChooseLanguage(int lang)
        {

            var language = "";

            lang = 3;
            switch (lang)
            {
                case 3: language = "en"; break;
                case 4: language = "hr"; break;
                default: language = "en"; break;
            }
            return language;
        }

        /*public University GetUniversity(int id)
        {
            return db.fakultet_teksts.SingleOrDefault(d => d.id_fakultet == id);
        }

        
        // Insert/Delete Methods

        public void Add(University university)
        {
            db.fakultet_teksts.InsertOnSubmit(university);
        }

        public void Delete(University university)
        {
            db.fakultet_teksts.DeleteOnSubmit(university);
            db.fakultets.DeleteOnSubmit(university);
        }*/

        //
        // Persistence
        public object Details(string city, string university)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDBDataContext();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var u = from ft in db.fakultet_teksts
                    from f in db.fakultets
                    from gt in db.grad_teksts
                    from g in db.grads
                    from dt in db.drzava_teksts
                    from d in db.drzavas
                    from kt in db.kontinent_teksts
                    from j in db.jeziks
                    where gt.naziv == city && ft.naziv == university && j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
                    select new University()
                    {
                        Continent = kt.tekst,
                        Country = dt.naziv,
                        City = gt.naziv,
                        Address = f.adresa_fakulteta,
                        Phone = f.broj_telefona,
                        Title = ft.naziv,
                        Description = ft.opis,
                        Photo = f.slika,
                        WebSite = f.web
                    };
            return View(u);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
