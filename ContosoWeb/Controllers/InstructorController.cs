﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Models;
using ContosoWeb.Services;

namespace ContosoWeb.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _service;
        private readonly IPersonService _personService;
        public InstructorController(IInstructorService service, IPersonService personService)
        {
            _service = service;
            _personService = personService;
        }
        // GET: Instructor
        public ActionResult Index()
        {
            var list = _service.GetAllInstructors();
            return View(list);
        }

        public ActionResult EagerIndex()
        {
            var list = _service.EagerGetAll();
            return View(list);
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                // TODO: Add insert logic here   
                _personService.AddPerson(instructor);
                _service.AddInstructor(instructor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
