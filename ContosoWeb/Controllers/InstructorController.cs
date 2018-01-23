using System;
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
        private readonly IRoleService _roleService;
        public InstructorController(IInstructorService service, IPersonService personService, IRoleService roleService)
        {
            _service = service;
            _personService = personService;
            _roleService = roleService;
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
                // TODO: Add insert logic here   /
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
            var roleList = _roleService.GetAllRoles();
            ViewBag.RoleId = roleList.Select(r => new SelectListItem() { Text = r.RoleName, Value = r.Id.ToString() });
            return View(_service.GetInstructorById(id));
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            try
            {
                // TODO: Add update logic here
                _personService.EditPerson(instructor);
                _service.EditInstructor(instructor);
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
            return View(_service.GetInstructorById(id));
        }

        // POST: Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(Instructor instructor)
        {
            try
            {
                // TODO: Add delete logic here
                _personService.DeletePerson(_personService.GetPersonById(instructor.Id));
                _service.DeleteInstructor(instructor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
