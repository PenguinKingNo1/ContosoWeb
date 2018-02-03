using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Data;
using ContosoWeb.Models;
using ContosoWeb.Services;
using ContosoWeb.Infrastructure;

namespace ContosoWeb.Controllers
{
    [RoleAuthorize(AuthorizeRole.Administrator,AuthorizeRole.Student)]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IPersonService _personService;
        private readonly ICourseService _courseService;
        public StudentController(IStudentService studentService, IPersonService personService, ICourseService courseService)
        {
            _studentService = studentService;
            _personService = personService;
            _courseService = courseService;
        }
        // GET: Student
        public ActionResult Index()
        {
            return View(_studentService.GetAllStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                student.CreatedDate = DateTime.Now;
                _personService.AddPerson(student);                
                _studentService.AddStudent(student);
                _personService.AddRole(student.Id, AuthorizeRole.StudentId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_studentService.GetStudentById(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                student.UpdatedDate = DateTime.Now;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_studentService.GetStudentById(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                _studentService.DeleteStudent(_studentService.GetStudentById(student.Id));
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        [RoleAuthorize(AuthorizeRole.Student)]
        public ActionResult PersonalHome()
        {
            try
            {
                var studentInfo = System.Web.HttpContext.Current.User as ContosoWebPrincipal;
                var studentId = studentInfo.PersonId;
                return View(_studentService.GetEnrolledCourses(studentId));
            }
            catch
            {
                return View();
            }
        }

        [RoleAuthorize(AuthorizeRole.Instructor,AuthorizeRole.Administrator)]
        public ActionResult StudentCourse()
        {
            try
            {
                var studentList = _studentService.GetAllStudents();
                return View(studentList);
            }
            catch
            {
                return View();
            }
        }
    }
}
