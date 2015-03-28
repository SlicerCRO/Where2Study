using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class FacultyTextController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /Faculty/

        public ActionResult Index()
        {

            //Response.Write("<h1>Faculties: </h1>");
            var faculty = repository.FindAllFaculties().ToList();

            return View("index", faculty);
        }

        //
        // GET: /FacultyText/Details/2

        public ActionResult Details(int id)
        {

            fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

            /*if (facultyy == null)
                return View("NotFound");
            else*/
            return View(faculty);
        }

        //
        // GET: /FacultyText/Create

        public ActionResult Create()
        {
            fakultet_tekst faculty = new fakultet_tekst();

            return View(faculty);
        }

        //
        // POST: /FacultyText/Create

        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult Create(fakultet_tekst faculty)//FormCollection collection)
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
                     ModelState.AddRuleViolations(faculty.GetRuleViolations());
                }
            }
            return View(faculty);
        }

        //
        // GET: /FacultyText/Edit/5

        public ActionResult Edit(int id)
        {
            fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

            return View(faculty);
        }

        //
        // POST: /Faculty/Edit/5

        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

            /*faculty.naziv = Request.Form["tekst"];
            faculty.id_fakultet = int.Parse(Request.Form["id_fakultet"]);
            faculty.id_jezik = int.Parse(Request.Form["id_jezik"]);*/

            try
            {
                UpdateModel(faculty);
                repository.Save();
                return RedirectToAction("Details", new { id = faculty.id });
            }
            catch
            {
                ModelState.AddRuleViolations(faculty.GetRuleViolations());
                return View(faculty);
            }
        }

        //
        // GET: /FacultyText/Delete/5

        public ActionResult Delete(int id)
        {
            fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

            if (faculty == null)
                return View("NotFound");
            else
                return View(faculty);
        }

        //
        // POST: /FacultyText/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            fakultet_tekst faculty = repository.Get_fakultet_tekst(id);
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
