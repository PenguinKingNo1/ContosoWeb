using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Models;
using ContosoWeb.Services;

namespace ContosoWeb.Controllers
{
    public class InstructorCourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IInstructorService _instructorService;
        public InstructorCourseController(ICourseService courseService, IInstructorService instructorService)
        {
            _courseService = courseService;
            _instructorService = instructorService;
        }
        // GET: InstructorCourse
        public ActionResult Index()
        {            
            return View();
        }

        // GET: InstructorCourse
        public ActionResult Allocate()
        {
            var courseList = _courseService.GetAllCourses();
            var instructorList = _instructorService.GetAllInstructors();
            ViewBag.CourseId = courseList.Select(c => new SelectListItem() { Text = c.Title, Value = c.Id.ToString()});
            ViewBag.InstructorId = instructorList.Select(i => new SelectListItem() { Text = i.FirstName+" "+i.LastName, Value = i.Id.ToString() });
            return View();
        }
        // POST
        [HttpPost]
        public ActionResult Allocate(string CourseId, string InstructorId)
        {
            _instructorService.AddMoreCourses(Convert.ToInt32(InstructorId), Convert.ToInt32(CourseId));
            return RedirectToAction("../Instructor/Index");
        }

        // GET: InstructorCourse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InstructorCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorCourse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorCourse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstructorCourse/Edit/5
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

        // GET: InstructorCourse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorCourse/Delete/5
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
