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

        private w2sDataContext db = new w2sDataContext();

        //
        // Query Methods

        public static List<kontinent_tekst> AllContinents = new List<kontinent_tekst> { };

        public static void GetAllContinents() 
        {
            AllContinents.Clear();
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var currentLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var continents = from c in db.kontinent_teksts
                             from j in db.jeziks
                             where j.kratica == currentLanguage && c.id_jezik == j.id
                             select c;
            foreach (var i in continents) AllContinents.Add(i);
        }

        public IQueryable<drzava_tekst> FindAllCountries()
        {
            return db.drzava_teksts;
        }

        public static List<drzava_tekst> AllCountries = new List<drzava_tekst> { };

        public static void GetAllCountries(string continent)
        {
            AllCountries.Clear();
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
            foreach (var i in countries) AllCountries.Add(i);
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

        public static List<grad_tekst> AllCities = new List<grad_tekst> { };

        public static void GetAllCities(string country)
        {
            AllCities.Clear();
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var currentLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            var cities = from g in db.grads
                         from gt in db.grad_teksts
                         from d in db.drzavas
                         from dt in db.drzava_teksts
                         from j in db.jeziks
                         where dt.naziv == country && j.kratica == currentLanguage && gt.id_jezik == j.id && g.id_drzava == d.id && dt.id_drzava == d.id && g.id == gt.id_grad
                         select gt;
            foreach (var i in cities) AllCities.Add(i);
        }


        public grad_tekst Get_grad_tekst(int id)
        {
            return db.grad_teksts.SingleOrDefault(d => d.id == id);
        }


        public void Add(grad_tekst city)
        {
            /*var d = from dt in db.grad_teksts
                    select new City()
                    {
                        tekst = gt.naziv,
                        id_drzava = gt.id_grad,
                        id_jezik = dt.id_jezik
                    };*/
            var v = false;
            foreach (var item in db.grad_teksts)
            {
                if (item.naziv == city.naziv) v = true;
            };
            if (v == false)
            {
                db.grad_teksts.InsertOnSubmit(city);
            }
        }

        public void Delete(grad_tekst city)
        {
            db.grad_teksts.DeleteOnSubmit(city);
            //db.grads.DeleteOnSubmit(city);
        }

        public IQueryable<fakultet> FindAllFacult()
        {
            return db.fakultets;
        }

        public fakultet Get_fakultet(int id)
        {
            return db.fakultets.SingleOrDefault(d => d.id == id);
        }


        public void Add(fakultet faculty)
        {
            /*var d = from dt in db.fakultet
                    select new Faculty()
                    {
                        
                    };*/
            var v = false;
            foreach (var item in db.fakultets)
            {
                if (item.adresa_fakulteta == faculty.adresa_fakulteta) v = true;
            };
            if (v == false)
            {
                db.fakultets.InsertOnSubmit(faculty);
            }
        }

        public void Delete(fakultet faculty)
        {
            db.fakultets.DeleteOnSubmit(faculty);
        }

        public IQueryable<fakultet_tekst> FindAllFaculties()
        {
            return db.fakultet_teksts;
        }

        public static List<Faculty> AllFaculties = new List<Faculty> { };

        public static void GetAllFaculties(string city)
        {
            AllFaculties.Clear();
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var faculties = (from ft in db.fakultet_teksts
                     from f in db.fakultets
                     from gt in db.grad_teksts
                     from g in db.grads
                     from dt in db.drzava_teksts
                     from d in db.drzavas
                     from kt in db.kontinent_teksts
                     from j in db.jeziks
                     where gt.naziv == city && j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
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
                     });
            foreach (var i in faculties) AllFaculties.Add(i);
        }

        public fakultet_tekst Get_fakultet_tekst(int id)
        {
            return db.fakultet_teksts.SingleOrDefault(d => d.id == id);
        }


        public void Add(fakultet_tekst faculty)
        {
            /*var d = from dt in db.drzava_teksts
                    select new Country()
                    {
                        tekst = dt.naziv,
                        id_drzava = dt.id_drzava,
                        id_jezik = dt.id_jezik
                    };*/
            var v = false;
            foreach (var item in db.fakultet_teksts)
            {
                if (item.naziv == faculty.naziv) v = true;
            };
            if (v == false)
            {
                db.fakultet_teksts.InsertOnSubmit(faculty);
            }
        }

        public void Delete(fakultet_tekst faculty)
        {
            db.fakultet_teksts.DeleteOnSubmit(faculty);
        }

        public IQueryable<sveuciliste> FindAllUniversit()
        {
            return db.sveucilistes;
        }

        public sveuciliste Get_sveuciliste(int id)
        {
            return db.sveucilistes.SingleOrDefault(d => d.id == id);
        }


        public void Add(sveuciliste university)
        {
            /*var d = from dt in db.sveuciliste
                    select new University()
                    {
                        
                    };*/
            var v = false;
            foreach (var item in db.sveucilistes)
            {
                if (item.adresa_sveucilista == university.adresa_sveucilista) v = true;
            };
            if (v == false)
            {
                db.sveucilistes.InsertOnSubmit(university);
            }
        }

        public void Delete(sveuciliste university)
        {
            db.sveucilistes.DeleteOnSubmit(university);
        }

        public IQueryable<sveuciliste_tekst> FindAllUniversities()
        {
            return db.sveuciliste_teksts;
        }

        public sveuciliste_tekst Get_sveuciliste_tekst(int id)
        {
            return db.sveuciliste_teksts.SingleOrDefault(d => d.id == id);
        }


        public void Add(sveuciliste_tekst university)
        {
            /*var d = from dt in db.sveuciliste
                    select new University()
                    {
                        
                    };*/
            var v = false;
            foreach (var item in db.sveuciliste_teksts)
            {
                if (item.naziv == university.naziv) v = true;
            };
            if (v == false)
            {
                db.sveuciliste_teksts.InsertOnSubmit(university);
            }
        }

        public void Delete(sveuciliste_tekst university)
        {
            db.sveuciliste_teksts.DeleteOnSubmit(university);
        }

        public IQueryable<stupanj_smjer> FindAllDegreeSpec()
        {
            return db.stupanj_smjers;
        }

        public static List<stupanj_tekst> AllDegrees = new List<stupanj_tekst> { };

        public static void GetAllDegrees()
        {
            AllDegrees.Clear();
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var degrees = from j in db.jeziks
                          from s in db.stupanjs
                          from st in db.stupanj_teksts
                          where j.kratica == currentLanguage && st.id_stupanj == s.id && st.id_jezik == j.id
                          select st;
            foreach (var i in degrees) AllDegrees.Add(i);

           }


        public static List<DegreeSpecialization> AllDegreeSpec = new List<DegreeSpecialization> { };

        public static void GetAllDegreeSpec(string faculty, int? degree)
        {
            AllDegreeSpec.Clear();
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            var currentLanguage = cultureInfo.TwoLetterISOLanguageName;
            var specializations = (from ft in db.fakultet_teksts
                                   from f in db.fakultets
                                   from j in db.jeziks
                                   from s in db.stupanjs
                                   from st in db.stupanj_teksts
                                   from sm in db.smjers
                                   from smt in db.smjer_teksts
                                   from stsm in db.stupanj_smjers
                                   where ft.naziv == faculty && s.id==degree && j.kratica == currentLanguage && ft.id_fakultet == f.id && sm.id_fakultet == f.id && stsm.id_stupanj == s.id && stsm.id_smjer == sm.id && sm.id == smt.id_smjer && st.id_stupanj == s.id && st.id_jezik == j.id && smt.id_jezik == j.id
                                   select new Where2Study.Models.DegreeSpecialization()
                                   {
                                       Id = s.id,
                                       Degree = st.naziv,
                                       Specialization = smt.tekst,
                                       Duration = s.trajanje,
                                   });
            foreach (var i in specializations) AllDegreeSpec.Add(i);
        }
       

        public stupanj_smjer Get_stupanj_smjer(int id)
        {
            return db.stupanj_smjers.SingleOrDefault(d => d.id == id);
        }


        public void Add(stupanj_smjer degree)
        {
            /*var d = from ss in db.stupanj_smjer
                    select new DegreeSpec()
                    {
                        
                    };*/
      
                db.stupanj_smjers.InsertOnSubmit(degree);
           
        }

        public void Delete(stupanj_smjer degree)
        {
            db.stupanj_smjers.DeleteOnSubmit(degree);
        }

        public IQueryable<smjer> FindAllSpecializat()
        {
            return db.smjers;
        }

        public smjer Get_smjer(int id)
        {
            return db.smjers.SingleOrDefault(d => d.id == id);
        }


        public void Add(smjer specialization)
        {
            /*var d = from dt in db.smjer
                    select new Specialization()
                    {
                        
                    };*/
            db.smjers.InsertOnSubmit(specialization);    
        }

        public void Delete(smjer specialization)
        {
            db.smjers.DeleteOnSubmit(specialization);
        }

        public IQueryable<smjer_tekst> FindAllSpecializations()
        {
            return db.smjer_teksts;
        }

        public smjer_tekst Get_smjer_tekst(int id)
        {
            return db.smjer_teksts.SingleOrDefault(d => d.id == id);
        }


        public void Add(smjer_tekst specialization)
        {
            /*var d = from dt in db.smjer
                    select new Specialization()
                    {
                        
                    };*/
            var v = false;
            foreach (var item in db.smjer_teksts)
            {
                if (item.tekst == specialization.tekst) v = true;
            };
            if (v == false)
            {
                db.smjer_teksts.InsertOnSubmit(specialization);
            }
        }

        public void Delete(smjer_tekst specialization)
        {
            db.smjer_teksts.DeleteOnSubmit(specialization);
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

        /*public Faculty GetFaculty(int id)
        {
            return db.fakultet_teksts.SingleOrDefault(d => d.id_fakultet == id);
        }

        
        // Insert/Delete Methods

        public void Add(Faculty faculty)
        {
            db.fakultet_teksts.InsertOnSubmit(faculty);
        }

        public void Delete(Faculty faculty)
        {
            db.fakultet_teksts.DeleteOnSubmit(faculty);
            db.fakultets.DeleteOnSubmit(faculty);
        }*/

        //
        // Persistence
        public object RandomDetails(string city, string faculty)
        {
            SiteLanguages.GetAllLanguages();
            var db = new w2sDataContext();
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
                    where gt.naziv == city && ft.naziv == faculty && j.kratica == currentLanguage && ft.id_fakultet == f.id && f.id_grad == g.id && g.id_drzava == d.id && d.id_kontinent == kt.id_kontinent && gt.id_grad == g.id && dt.id_drzava == d.id && ft.id_jezik == j.id && gt.id_jezik == j.id && dt.id_jezik == j.id && kt.id_jezik == j.id
                    select new Faculty()
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
