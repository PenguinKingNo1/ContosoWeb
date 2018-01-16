using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Models;
using ContosoWeb.Services;

namespace ContosoWeb.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: People
        public ActionResult Index()
        {
            return View(_personService.GetAllPeople());
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(People person)
        {
            try
            {
                // TODO: Add insert logic here
                _personService.AddPerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_personService.GetPersonById(id));
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(People people)
        {
            try
            {
                // TODO: Add update logic here
                _personService.EditPerson(people);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_personService.GetPersonById(id));
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,People people)
        {
            try
            {
                // TODO: Add delete logic here
                _personService.DeletePerson(people);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
