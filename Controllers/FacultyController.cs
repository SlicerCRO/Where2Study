using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class FacultyController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /Faculty/

        public ActionResult Index()
        {
           // Response.Write("<h1>Faculties: </h1>");
            var faculty = repository.FindAllFacult().ToList();

            return View("index", faculty);
        }

        //
        // GET: /Faculty/Details/2

        public ActionResult Details(int id)
        {

            fakultet faculty = repository.Get_fakultet(id);

            /*if (facultyy == null)
                return View("NotFound");
            else*/
            return View(faculty);
        }

        //
        // GET: /Faculty/Create

        public ActionResult Create()
        {
            fakultet faculty = new fakultet();

            return View(faculty);
        }

        //
        // POST: /Faculty/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(fakultet faculty)//FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(faculty);
                    repository.Add(faculty);
                    repository.Save();
                    return RedirectToAction("Details", new { id = faculty.id });
                }
                catch
                {
                   // ModelState.AddRuleViolations(faculty.GetRuleViolations());
                }
            }
            return View(faculty);
        }

        //
        // GET: /Faculty/Edit/5

        public ActionResult Edit(int id)
        {
            fakultet faculty = repository.Get_fakultet(id);

            return View(faculty);
        }

        //
        // POST: /Faculty/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            fakultet faculty = repository.Get_fakultet(id);

            /*country.naziv = Request.Form["tekst"];
            country.id_drzava = int.Parse(Request.Form["id_drzava"]);
            country.id_jezik = int.Parse(Request.Form["id_jezik"]);*/

            try
            {
                UpdateModel(faculty);
                repository.Save();
                return RedirectToAction("Details", new { id = faculty.id });
            }
            catch
            {
                //ModelState.AddRuleViolations(country.GetRuleViolations());
                return View(faculty);
            }
        }

        //
        // GET: /Faculty/Delete/5

        public ActionResult Delete(int id)
        {
            fakultet faculty = repository.Get_fakultet(id);

            if (faculty == null)
                return View("NotFound");
            else
                return View(faculty);
        }

        //
        // POST: /Faculty/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            fakultet faculty = repository.Get_fakultet(id);
            if (faculty == null)
                return View("NotFound");
            repository.Delete(faculty);
            repository.Save();
            {
                return View("Deleted");
            }
        }
    }
}
