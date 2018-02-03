using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoWeb.Models;
using ContosoWeb.Services;
using ContosoWeb.ViewModels;
using Newtonsoft.Json;
using System.Web.Security;
using ContosoWeb.Infrastructure;

namespace ContosoWeb.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IInstructorService _instructorService;
        private readonly IStudentService _studentService;
        public PeopleController(IPersonService personService, IInstructorService instructorService, IStudentService studentService)
        {
            _personService = personService;
            _instructorService = instructorService;
            _studentService = studentService;
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
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = AuthorizeRole.Instructor, Value = AuthorizeRole.InstructorId.ToString()},
                new SelectListItem(){Text = AuthorizeRole.Student, Value = AuthorizeRole.StudentId.ToString()}
            };
            ViewBag.RoleId = roleList;
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(People person,string RoleId)
        {
            try
            {
                person.CreatedDate = DateTime.Now;
                _personService.AddPerson(person); 
                if (RoleId == AuthorizeRole.InstructorId.ToString())
                {
                    _instructorService.AddInstructor(new Instructor() { Id = person.Id});
                    _personService.AddRole(person.Id, AuthorizeRole.InstructorId);
                    return RedirectToAction("PersonalHome", "Instructor");
                }
                else if(RoleId == AuthorizeRole.StudentId.ToString())
                {
                    _studentService.AddStudent(new Student() { Id = person.Id});
                    _personService.AddRole(person.Id, AuthorizeRole.StudentId);
                    return RedirectToAction("PersonalHome","Student");
                }
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

        // GET: 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var person = _personService.GetValidPerson(loginViewModel.Username, loginViewModel.Password);

                    if (person != null)
                    {
                        var personRoles = person.Roles.Select(r => r.RoleName).ToArray();
                        var serializeModel = new ContosoPrincipleModel
                        {
                            PersonId = person.Id,
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            Roles = personRoles
                        };

                        var userData = JsonConvert.SerializeObject(serializeModel);
                        // using System.Web.Security
                        var authTicket = new FormsAuthenticationTicket(1, person.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                        // no algorithm to choose from
                        var encTicket = FormsAuthentication.Encrypt(authTicket);
                        //
                        var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        // GET: 
        public ActionResult SignUp()
        {
            return RedirectToAction("Create");
        }
    }
}
