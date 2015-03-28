using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class SpecializationTextController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /SpecializationText/

        public ActionResult Index()
        {
           // Response.Write("<h1>Specializations: </h1>");
            var specialization = repository.FindAllSpecializations().ToList();

            return View("index", specialization);
        }

        //
        // GET: /SpecializationText/Details/2

        public ActionResult Details(int id)
        {

            smjer_tekst specialization = repository.Get_smjer_tekst(id);

            /*if (specialization == null)
                return View("NotFound");
            else*/
            return View(specialization);
        }

        //
        // GET: /SpecializationText/Create

        public ActionResult Create()
        {
            smjer_tekst specialization = new smjer_tekst();

            return View(specialization);
        }

        //
        // POST: /SpecializationText/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(smjer_tekst specialization)//FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(specialization);
                    repository.Add(specialization);
                    repository.Save();
                    return RedirectToAction("Details", new { id = specialization.id });
                }
                catch
                {
                    ModelState.AddRuleViolations(specialization.GetRuleViolations());
                }
            }
            return View(specialization);
        }

        //
        // GET: /SpecializationText/Edit/5

        public ActionResult Edit(int id)
        {
            smjer_tekst specialization = repository.Get_smjer_tekst(id);

            return View(specialization);
        }

        //
        // POST: /SpecializationText/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            smjer_tekst specialization = repository.Get_smjer_tekst(id);

            /*specialization.tekst = Request.Form["tekst"];
            specialization.id_fakultet = int.Parse(Request.Form["id_fakultet"]);*/

            try
            {
                UpdateModel(specialization);
                repository.Save();
                return RedirectToAction("Details", new { id = specialization.id });
            }
            catch
            {
                ModelState.AddRuleViolations(specialization.GetRuleViolations());
                return View(specialization);
            }
        }

        //
        // GET: /SpecializationText/Delete/5

        public ActionResult Delete(int id)
        {
            smjer_tekst specialization = repository.Get_smjer_tekst(id);

            if (specialization == null)
                return View("NotFound");
            else
                return View(specialization);
        }

        //
        // POST: /SpecializationText/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            smjer_tekst specialization = repository.Get_smjer_tekst(id);
            if (specialization == null)
                return View("NotFound");
            repository.Delete(specialization);
            repository.Save();
            {
                return View("Deleted");
            }
        }
    }
}
