using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class CityController : BaseController
    {
        w2sRepository repository = new w2sRepository();
        [Authorize]
        //
        // GET: /City/

        public ActionResult Index()
        {
            //Response.Write("<h1>Cities: </h1>");
            var city = repository.FindAllCities().ToList();

            return View("index", city);
        }

        //
        // GET: /City/Details/2

        public ActionResult Details(int id)
        {

            grad_tekst city = repository.Get_grad_tekst(id);

            /*if (city == null)
                return View("NotFound");
            else*/
            return View(city);
        }

        //
        // GET: /City/Create

        public ActionResult Create()
        {
            grad_tekst city = new grad_tekst();

            return View(city);
        }

        //
        // POST: /City/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(grad_tekst city)//FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(city);
                    repository.Add(city);
                    repository.Save();
                    return RedirectToAction("Details", new { id = city.id });
                }
                catch
                {
                    ModelState.AddRuleViolations(city.GetRuleViolations());
                }
            }
            return View(city);
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id)
        {
            grad_tekst city = repository.Get_grad_tekst(id);

            return View(city);
        }

        //
        // POST: /City/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formvalues)
        {
            grad_tekst city = repository.Get_grad_tekst(id);

            /*city.naziv = Request.Form["tekst"];
            city.id_grad = int.Parse(Request.Form["id_grad"]);
            city.id_jezik = int.Parse(Request.Form["id_jezik"]);*/

            try
            {
                UpdateModel(city);
                repository.Save();
                return RedirectToAction("Details", new { id = city.id });
            }
            catch
            {
                ModelState.AddRuleViolations(city.GetRuleViolations());
                return View(city);
            }
        }

        //
        // GET: /City/Delete/5

        public ActionResult Delete(int id)
        {
            grad_tekst city = repository.Get_grad_tekst(id);

            if (city == null)
                return View("NotFound");
            else
                return View(city);
        }

        //
        // POST: /City/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            grad_tekst city = repository.Get_grad_tekst(id);
            if (city == null)
                return View("NotFound");
            repository.Delete(city);
            repository.Save();
            {
                return View("Deleted");
            }
        }
    }
}
