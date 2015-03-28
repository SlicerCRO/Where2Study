using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class UniversityController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /University/

        public ActionResult Index()
        {
           // Response.Write("<h1>Universities: </h1>");
            var university = repository.FindAllUniversit().ToList();

            return View("index", university);
        }

        //
        // GET: /University/Details/2

        public ActionResult Details(int id)
        {

            sveuciliste university = repository.Get_sveuciliste(id);

            /*if (universityy == null)
                return View("NotFound");
            else*/
            return View(university);
        }

        //
        // GET: /University/Create

        public ActionResult Create()
        {
            sveuciliste university = new sveuciliste();

            return View(university);
        }

        //
        // POST: /University/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(sveuciliste university)//FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(university);
                    repository.Add(university);
                    repository.Save();
                    return RedirectToAction("Details", new { id = university.id });
                }
                catch
                {
                    // ModelState.AddRuleViolations(university.GetRuleViolations());
                }
            }
            return View(university);
        }

        //
        // GET: /University/Edit/5

        public ActionResult Edit(int id)
        {
            sveuciliste university = repository.Get_sveuciliste(id);

            return View(university);
        }

        //
        // POST: /University/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            sveuciliste university = repository.Get_sveuciliste(id);

            /*country.naziv = Request.Form["tekst"];
            country.id_drzava = int.Parse(Request.Form["id_drzava"]);
            country.id_jezik = int.Parse(Request.Form["id_jezik"]);*/

            try
            {
                UpdateModel(university);
                repository.Save();
                return RedirectToAction("Details", new { id = university.id });
            }
            catch
            {
                //ModelState.AddRuleViolations(country.GetRuleViolations());
                return View(university);
            }
        }

        //
        // GET: /University/Delete/5

        public ActionResult Delete(int id)
        {
            sveuciliste university = repository.Get_sveuciliste(id);

            if (university == null)
                return View("NotFound");
            else
                return View(university);
        }

        //
        // POST: /University/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            sveuciliste university = repository.Get_sveuciliste(id);
            if (university == null)
                return View("NotFound");
            repository.Delete(university);
            repository.Save();
            {
                return View("Deleted");
            }
        }
    }
}
