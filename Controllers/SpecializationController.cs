using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class SpecializationController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /Specialization/

        public ActionResult Index()
        {
            //Response.Write("<h1>Specializations: </h1>");
            var specialization = repository.FindAllSpecializat().ToList();

            return View("index", specialization);
        }

        //
        // GET: /Specialization/Details/2

        public ActionResult Details(int id)
        {

            smjer specialization = repository.Get_smjer(id);

            /*if (specializationy == null)
                return View("NotFound");
            else*/
            return View(specialization);
        }

        //
        // GET: /Specialization/Create

        public ActionResult Create()
        {
            smjer specialization = new smjer();

            return View(specialization);
        }

        //
        // POST: /Specialization/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(smjer specialization)//FormCollection collection)
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
                    // ModelState.AddRuleViolations(specialization.GetRuleViolations());
                }
            }
            return View(specialization);
        }

        //
        // GET: /Specialization/Edit/5

        public ActionResult Edit(int id)
        {
            smjer specialization = repository.Get_smjer(id);

            return View(specialization);
        }

        //
        // POST: /Specialization/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            smjer specialization = repository.Get_smjer(id);

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
                //ModelState.AddRuleViolations(country.GetRuleViolations());
                return View(specialization);
            }
        }

        //
        // GET: /Specialization/Delete/5

        public ActionResult Delete(int id)
        {
            smjer specialization = repository.Get_smjer(id);

            if (specialization == null)
                return View("NotFound");
            else
                return View(specialization);
        }

        //
        // POST: /Specialization/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            smjer specialization = repository.Get_smjer(id);
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
