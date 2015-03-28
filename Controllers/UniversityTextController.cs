using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class UniversityTextController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /University/

        public ActionResult Index()
        {
           // Response.Write("<h1>Universities: </h1>");
            var university = repository.FindAllUniversities().ToList();

            return View("index", university);
        }

        //
        // GET: /UniversityText/Details/2

        public ActionResult Details(int id)
        {

            sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

            /*if (universityy == null)
                return View("NotFound");
            else*/
            return View(university);
        }

        //
        // GET: /UniversityText/Create

        public ActionResult Create()
        {
            sveuciliste_tekst university = new sveuciliste_tekst();

            return View(university);
        }

        //
        // POST: /UniversityText/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(sveuciliste_tekst university)//FormCollection collection)
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
                    ModelState.AddRuleViolations(university.GetRuleViolations());
                }
            }
            return View(university);
        }

        //
        // GET: /UniversityText/Edit/5

        public ActionResult Edit(int id)
        {
            sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

            return View(university);
        }

        //
        // POST: /University/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

            /*university.naziv = Request.Form["tekst"];
            university.id_sveuciliste = int.Parse(Request.Form["id_sveuciliste"]);
            university.id_jezik = int.Parse(Request.Form["id_jezik"]);*/

            try
            {
                UpdateModel(university);
                repository.Save();
                return RedirectToAction("Details", new { id = university.id });
            }
            catch
            {
                ModelState.AddRuleViolations(university.GetRuleViolations());
                return View(university);
            }
        }

        //
        // GET: /UniversityText/Delete/5

        public ActionResult Delete(int id)
        {
            sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

            if (university == null)
                return View("NotFound");
            else
                return View(university);
        }

        //
        // POST: /UniversityText/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);
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
