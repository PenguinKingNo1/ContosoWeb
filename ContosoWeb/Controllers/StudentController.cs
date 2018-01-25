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
        public StudentController(IStudentService studentService, IPersonService personService)
        {
            _studentService = studentService;
            _personService = personService;
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
                student.EnrollmentDate = DateTime.Now;
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
    }
}
