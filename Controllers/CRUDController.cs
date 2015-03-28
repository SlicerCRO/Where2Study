using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Where2Study.Models;

namespace Where2Study.Controllers
{
    public class CRUDController : BaseController
    {
        [Authorize]
        //
        // GET: /CRUD/

        public ActionResult Index()
        {
            return View();
        }

        public class CountryController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /Country/

            public ActionResult Index()
            {
                // Response.Write("<h1>Countries: </h1>");
                var country = repository.FindAllCountries().ToList();

                return View("~/Views/CRUD/Countr/index.cshtml", country);
            }

            //
            // GET: /Country/Details/2

            public ActionResult Details(int id)
            {

                drzava_tekst country = repository.Get_drzava_tekst(id);

                /*if (country == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", country);
            }

            //
            // GET: /Country/Create

            public ActionResult Create()
            {
                drzava_tekst country = new drzava_tekst();

                return View("CRUD/", country);
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

                return View("CRUD/", country);
            }

            //
            // POST: /Country/Edit/5

            [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
            public ActionResult Edit(int id, FormCollection formvalues)
            {
                drzava_tekst country = repository.Get_drzava_tekst(id);

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
                    return View("CRUD/", country);
                }
            }

            //
            // GET: /Country/Delete/5

            public ActionResult Delete(int id)
            {
                drzava_tekst country = repository.Get_drzava_tekst(id);

                if (country == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", country);
            }

            //
            // POST: /Country/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                drzava_tekst country = repository.Get_drzava_tekst(id);
                if (country == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(country);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class CityController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /City/

            public ActionResult Index()
            {
                //Response.Write("<h1>Cities: </h1>");
                var city = repository.FindAllCities().ToList();

                return View("CRUD/", "index", city);
            }

            //
            // GET: /City/Details/2

            public ActionResult Details(int id)
            {

                grad_tekst city = repository.Get_grad_tekst(id);

                /*if (city == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", city);
            }

            //
            // GET: /City/Create

            public ActionResult Create()
            {
                grad_tekst city = new grad_tekst();

                return View("CRUD/", city);
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
                return View("CRUD/", city);
            }

            //
            // GET: /City/Edit/5

            public ActionResult Edit(int id)
            {
                grad_tekst city = repository.Get_grad_tekst(id);

                return View("CRUD/", city);
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
                    return View("CRUD/", city);
                }
            }

            //
            // GET: /City/Delete/5

            public ActionResult Delete(int id)
            {
                grad_tekst city = repository.Get_grad_tekst(id);

                if (city == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", city);
            }

            //
            // POST: /City/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                grad_tekst city = repository.Get_grad_tekst(id);
                if (city == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(city);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class FacultyController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /Faculty/

            public ActionResult Index()
            {
                // Response.Write("<h1>Faculties: </h1>");
                var faculty = repository.FindAllFacult().ToList();

                return View("CRUD/", "index", faculty);
            }

            //
            // GET: /Faculty/Details/2

            public ActionResult Details(int id)
            {

                fakultet faculty = repository.Get_fakultet(id);

                /*if (facultyy == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", faculty);
            }

            //
            // GET: /Faculty/Create

            public ActionResult Create()
            {
                fakultet faculty = new fakultet();

                return View("CRUD/", faculty);
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
                return View("CRUD/", faculty);
            }

            //
            // GET: /Faculty/Edit/5

            public ActionResult Edit(int id)
            {
                fakultet faculty = repository.Get_fakultet(id);

                return View("CRUD/", faculty);
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
                    return View("CRUD/", faculty);
                }
            }

            //
            // GET: /Faculty/Delete/5

            public ActionResult Delete(int id)
            {
                fakultet faculty = repository.Get_fakultet(id);

                if (faculty == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", faculty);
            }

            //
            // POST: /Faculty/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                fakultet faculty = repository.Get_fakultet(id);
                if (faculty == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(faculty);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class FacultyTextController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /Faculty/

            public ActionResult Index()
            {

                //Response.Write("<h1>Faculties: </h1>");
                var faculty = repository.FindAllFaculties().ToList();

                return View("CRUD/", "index", faculty);
            }

            //
            // GET: /FacultyText/Details/2

            public ActionResult Details(int id)
            {

                fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

                /*if (facultyy == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", faculty);
            }

            //
            // GET: /FacultyText/Create

            public ActionResult Create()
            {
                fakultet_tekst faculty = new fakultet_tekst();

                return View("CRUD/", faculty);
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
                return View("CRUD/", faculty);
            }

            //
            // GET: /FacultyText/Edit/5

            public ActionResult Edit(int id)
            {
                fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

                return View("CRUD/", faculty);
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
                    return View("CRUD/", faculty);
                }
            }

            //
            // GET: /FacultyText/Delete/5

            public ActionResult Delete(int id)
            {
                fakultet_tekst faculty = repository.Get_fakultet_tekst(id);

                if (faculty == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", faculty);
            }

            //
            // POST: /FacultyText/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                fakultet_tekst faculty = repository.Get_fakultet_tekst(id);
                if (faculty == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(faculty);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class SpecializationController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /Specialization/

            public ActionResult Index()
            {
                //Response.Write("<h1>Specializations: </h1>");
                var specialization = repository.FindAllSpecializat().ToList();

                return View("CRUD/", "index", specialization);
            }

            //
            // GET: /Specialization/Details/2

            public ActionResult Details(int id)
            {

                smjer specialization = repository.Get_smjer(id);

                /*if (specializationy == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", specialization);
            }

            //
            // GET: /Specialization/Create

            public ActionResult Create()
            {
                smjer specialization = new smjer();

                return View("CRUD/", specialization);
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
                return View("CRUD/", specialization);
            }

            //
            // GET: /Specialization/Edit/5

            public ActionResult Edit(int id)
            {
                smjer specialization = repository.Get_smjer(id);

                return View("CRUD/", specialization);
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
                    return View("CRUD/", specialization);
                }
            }

            //
            // GET: /Specialization/Delete/5

            public ActionResult Delete(int id)
            {
                smjer specialization = repository.Get_smjer(id);

                if (specialization == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", specialization);
            }

            //
            // POST: /Specialization/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                smjer specialization = repository.Get_smjer(id);
                if (specialization == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(specialization);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class SpecializationTextController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /SpecializationText/

            public ActionResult Index()
            {
                // Response.Write("<h1>Specializations: </h1>");
                var specialization = repository.FindAllSpecializations().ToList();

                return View("CRUD/", "index", specialization);
            }

            //
            // GET: /SpecializationText/Details/2

            public ActionResult Details(int id)
            {

                smjer_tekst specialization = repository.Get_smjer_tekst(id);

                /*if (specialization == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", specialization);
            }

            //
            // GET: /SpecializationText/Create

            public ActionResult Create()
            {
                smjer_tekst specialization = new smjer_tekst();

                return View("CRUD/", specialization);
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
                return View("CRUD/", specialization);
            }

            //
            // GET: /SpecializationText/Edit/5

            public ActionResult Edit(int id)
            {
                smjer_tekst specialization = repository.Get_smjer_tekst(id);

                return View("CRUD/", specialization);
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
                    return View("CRUD/", specialization);
                }
            }

            //
            // GET: /SpecializationText/Delete/5

            public ActionResult Delete(int id)
            {
                smjer_tekst specialization = repository.Get_smjer_tekst(id);

                if (specialization == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", specialization);
            }

            //
            // POST: /SpecializationText/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                smjer_tekst specialization = repository.Get_smjer_tekst(id);
                if (specialization == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(specialization);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class DegreeSpecializationController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /DegreeSpecialization/

            public ActionResult Index()
            {
                //Response.Write("<h1>Degrees of Specializations: </h1>");
                var degreeSpecialization = repository.FindAllDegreeSpec().ToList();

                return View("CRUD/", "index", degreeSpecialization);
            }

            //
            // GET: /DegreeSpecialization/Details/2

            public ActionResult Details(int id)
            {

                stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

                /*if (degreeSpecializationy == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", degreeSpecialization);
            }

            //
            // GET: /DegreeSpecialization/Create

            public ActionResult Create()
            {
                stupanj_smjer degreeSpecialization = new stupanj_smjer();

                return View("CRUD/", degreeSpecialization);
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
                return View("CRUD/", degreeSpecialization);
            }

            //
            // GET: /DegreeSpecialization/Edit/5

            public ActionResult Edit(int id)
            {
                stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

                return View("CRUD/", degreeSpecialization);
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
                    return View("CRUD/", degreeSpecialization);
                }
            }

            //
            // GET: /DegreeSpecialization/Delete/5

            public ActionResult Delete(int id)
            {
                stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);

                if (degreeSpecialization == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", degreeSpecialization);
            }

            //
            // POST: /DegreeSpecialization/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                stupanj_smjer degreeSpecialization = repository.Get_stupanj_smjer(id);
                if (degreeSpecialization == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(degreeSpecialization);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class UniversityController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /University/

            public ActionResult Index()
            {
                // Response.Write("<h1>Universities: </h1>");
                var university = repository.FindAllUniversit().ToList();

                return View("CRUD/", "index", university);
            }

            //
            // GET: /University/Details/2

            public ActionResult Details(int id)
            {

                sveuciliste university = repository.Get_sveuciliste(id);

                /*if (universityy == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", university);
            }

            //
            // GET: /University/Create

            public ActionResult Create()
            {
                sveuciliste university = new sveuciliste();

                return View("CRUD/", university);
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
                return View("CRUD/", university);
            }

            //
            // GET: /University/Edit/5

            public ActionResult Edit(int id)
            {
                sveuciliste university = repository.Get_sveuciliste(id);

                return View("CRUD/", university);
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
                    return View("CRUD/", university);
                }
            }

            //
            // GET: /University/Delete/5

            public ActionResult Delete(int id)
            {
                sveuciliste university = repository.Get_sveuciliste(id);

                if (university == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", university);
            }

            //
            // POST: /University/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                sveuciliste university = repository.Get_sveuciliste(id);
                if (university == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(university);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }

        public class UniversityTextController : BaseController
        {
            w2sRepository repository = new w2sRepository();

            //
            // GET: /University/

            public ActionResult Index()
            {
                // Response.Write("<h1>Universities: </h1>");
                var university = repository.FindAllUniversities().ToList();

                return View("CRUD/", "index", university);
            }

            //
            // GET: /UniversityText/Details/2

            public ActionResult Details(int id)
            {

                sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

                /*if (universityy == null)
                    return View("CRUD/", "NotFound");
                else*/
                return View("CRUD/", university);
            }

            //
            // GET: /UniversityText/Create

            public ActionResult Create()
            {
                sveuciliste_tekst university = new sveuciliste_tekst();

                return View("CRUD/", university);
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
                return View("CRUD/", university);
            }

            //
            // GET: /UniversityText/Edit/5

            public ActionResult Edit(int id)
            {
                sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

                return View("CRUD/", university);
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
                    return View("CRUD/", university);
                }
            }

            //
            // GET: /UniversityText/Delete/5

            public ActionResult Delete(int id)
            {
                sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);

                if (university == null)
                    return View("CRUD/", "NotFound");
                else
                    return View("CRUD/", university);
            }

            //
            // POST: /UniversityText/Delete/5

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete(int id, FormCollection collection)
            {
                sveuciliste_tekst university = repository.Get_sveuciliste_tekst(id);
                if (university == null)
                    return View("CRUD/", "NotFound");
                repository.Delete(university);
                repository.Save();
                {
                    return View("CRUD/", "Deleted");
                }
            }
        }
    }
}
