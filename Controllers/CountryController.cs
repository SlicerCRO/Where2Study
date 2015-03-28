using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class CountryController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /Country/

        public ActionResult Index()
        {
           // Response.Write("<h1>Countries: </h1>");
            var country = repository.FindAllCountries().ToList();

            return View("index", country);
        }

        //
        // GET: /Country/Details/2

        public ActionResult Details(int id)
        {

            drzava_tekst country = repository.Get_drzava_tekst(id);

            /*if (country == null)
                return View("NotFound");
            else*/
                return View(country);
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            drzava_tekst country = new drzava_tekst();

            return View(country);
        } 

        //
        // POST: /Country/Create

        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult Create(drzava_tekst country)//FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(country);
                    repository.Add(country);
                    repository.Save();
                    return RedirectToAction("Details", new { id = country.id });
                }
                catch
                {
                   ModelState.AddRuleViolations(country.GetRuleViolations());
                }
            }
            return View(country);              
        }
        
        //
        // GET: /Country/Edit/5
 
        public ActionResult Edit(int id)
        {
            drzava_tekst country = repository.Get_drzava_tekst(id);

            return View(country);
        }

        //
        // POST: /Country/Edit/5

        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            drzava_tekst country=repository.Get_drzava_tekst(id);

            /*country.naziv = Request.Form["tekst"];
            country.id_drzava = int.Parse(Request.Form["id_drzava"]);
            country.id_jezik = int.Parse(Request.Form["id_jezik"]);*/

            try
            {
                UpdateModel(country);
                repository.Save();
                return RedirectToAction("Details", new { id = country.id });
            }
            catch
            {
                ModelState.AddRuleViolations(country.GetRuleViolations());
                return View(country);
            }
        }

        //
        // GET: /Country/Delete/5
 
        public ActionResult Delete(int id)
        {
            drzava_tekst country = repository.Get_drzava_tekst(id);

            if (country == null)
                return View("NotFound");
            else
                return View(country);
        }

        //
        // POST: /Country/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            drzava_tekst country = repository.Get_drzava_tekst(id);
            if (country == null)
                return View("NotFound");
            repository.Delete(country);
            repository.Save();
            {
                return View("Deleted");
            }
        }
    }
}
