using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Data;
using ContosoWeb.Models;
using ContosoWeb.Services;

namespace ContosoWeb.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private List<Department> depList;
        public CourseController(ICourseService service)
        {
            _service = service;
            depList = new DepartmentService(new DepartmentRepository(new ContosoDbContext())).GetAllDepartment().ToList();
        }
        // GET: Course
        public ActionResult Index()
        {
            return View(_service.GetAllCourses());
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = depList.Select(dep => new SelectListItem(){Text=dep.Name, Value=dep.Id.ToString()});
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                // TODO: Add insert logic here
                _service.AddCourse(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DepartmentId = depList.Select(dep => new SelectListItem() { Text = dep.Name, Value = dep.Id.ToString() });
            return View(_service.GetCourseById(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                // TODO: Add update logic here
                _service.EditCourse(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.GetCourseById(id));
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(Course course)
        {
            try
            {
                // TODO: Add delete logic here
                _service.DeleteCourse(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
