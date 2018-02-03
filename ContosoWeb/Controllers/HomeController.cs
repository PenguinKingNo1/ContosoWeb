using ContosoWeb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var personInfo = System.Web.HttpContext.Current.User as ContosoWebPrincipal;
            if(personInfo == null)
                return View("Index", "~/Views/Shared/_Layout.cshtml");
            ViewBag.UserName = personInfo.FirstName;
            return View("Index", "~/Views/Shared/_LoginLayout.cshtml");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}