using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Models;
using ContosoWeb.Services;
using ContosoWeb.Infrastructure;

namespace ContosoWeb.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly IDepartmentService _departmentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        public CourseController(ICourseService service, IDepartmentService departmentService, 
            IEnrollmentService enrollmentService, IStudentService studentService, ICourseService courseService)
        {
            _service = service;
            _departmentService = departmentService;
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }
        // GET: Course
        public ActionResult Index()
        {
            //int x = 1;
            //int y = 0;
            //int z = x / y;
            return View(_service.GetAllCourses());
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetCourseById(id));
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var depList = _departmentService.GetAllDepartment();
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
            var depList = _departmentService.GetAllDepartment();
            ViewBag.DepartmentId = depList.Select(dep => new SelectListItem() { Text = dep.Name, Value = dep.Id.ToString() });
            return View(_service.GetCourseById(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
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
                _service.DeleteCourse(_service.GetCourseById(course.Id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [RoleAuthorize(AuthorizeRole.Student)]
        public ActionResult Enroll(string id)
        {
            try
            {
                var student = System.Web.HttpContext.Current.User as ContosoWebPrincipal;
                var enrollment = new Enrollment();
                enrollment.CourseId = Convert.ToInt32(id);
                enrollment.StudentId = 1;
                //enrollment.Student = _studentService.GetStudentById(1);
                //enrollment.Course = _courseService.GetCourseById(Convert.ToInt32(id));
                //enrollment.CreatedDate = DateTime.Now;
                _enrollmentService.AddEnrollment(enrollment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
