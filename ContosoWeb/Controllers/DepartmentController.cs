using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Models;
using ContosoWeb.Services;

namespace ContosoWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        private readonly IInstructorService _instructorService;
        public DepartmentController(IDepartmentService service, IInstructorService instructorService)
        {
            _service = service;
            _instructorService = instructorService;
        }
        // GET: Department
        public ActionResult Index()
        {
            return View(_service.GetAllDepartment());
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            ViewBag.InstructorId = _instructorService.GetAllInstructors().Select
                (inst => new SelectListItem() { Text = inst.FirstName + inst.LastName, Value = inst.Id.ToString() });
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                // TODO: Add insert logic here
                _service.AddDepartment(department);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.InstructorId = _instructorService.GetAllInstructors().Select
            (inst => new SelectListItem() { Text = inst.FirstName + inst.LastName, Value = inst.Id.ToString()});
            return View(_service.GetDepartmentById(id));
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(Department dep)
        {
            try
            {
                // TODO: Add update logic here
                _service.EditDepartment(dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.GetDepartmentById(id));
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(Course course)
        {
            try
            {
                // TODO: Add delete logic here
                _service.DeleteDepartment(_service.GetDepartmentById(course.Id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
