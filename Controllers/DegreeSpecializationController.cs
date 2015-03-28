using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class DegreeSpecializationController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /DegreeSpecialization/

        public ActionResult Index()
        {
            //Response.Write("<h1>Degrees of Specializations: </h1>");
            var degreeSpecialization = repository.FindAllDegreeSpec().ToList();

            return View("index", degreeSpecialization);
        }

        //
        // GET: /DegreeSpecialization/Details/2

        public ActionResult Details(int id)
        {

            stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

            /*if (degreeSpecializationy == null)
                return View("NotFound");
            else*/
            return View(degreeSpecialization);
        }

        //
        // GET: /DegreeSpecialization/Create

        public ActionResult Create()
        {
            stupanj_smjer degreeSpecialization = new stupanj_smjer();

            return View(degreeSpecialization);
        }

        //
        // POST: /DegreeSpecialization/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(stupanj_smjer degreeSpecialization)//FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(degreeSpecialization);
                    repository.Add(degreeSpecialization);
                    repository.Save();
                    return RedirectToAction("Details", new { id = degreeSpecialization.id });
                }
                catch
                {
                    // ModelState.AddRuleViolations(degreeSpecialization.GetRuleViolations());
                }
            }
            return View(degreeSpecialization);
        }

        //
        // GET: /DegreeSpecialization/Edit/5

        public ActionResult Edit(int id)
        {
            stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

            return View(degreeSpecialization);
        }

        //
        // POST: /DegreeSpecialization/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

            /*degreeSpecialization.tekst = Request.Form["tekst"];
            degreeSpecialization.id_fakultet = int.Parse(Request.Form["id_fakultet"]);*/

            try
            {
                UpdateModel(degreeSpecialization);
                repository.Save();
                return RedirectToAction("Details", new { id = degreeSpecialization.id });
            }
            catch
            {
                //ModelState.AddRuleViolations(country.GetRuleViolations());
                return View(degreeSpecialization);
            }
        }

        //
        // GET: /DegreeSpecialization/Delete/5

        public ActionResult Delete(int id)
        {
            stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

            if (degreeSpecialization == null)
                return View("NotFound");
            else
                return View(degreeSpecialization);
        }

        //
        // POST: /DegreeSpecialization/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);
            if (degreeSpecialization == null)
                return View("NotFound");
            repository.Delete(degreeSpecialization);
            repository.Save();
            {
                return View("Deleted");
            }
        }
    }
}
