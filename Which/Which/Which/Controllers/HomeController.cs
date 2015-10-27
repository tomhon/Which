using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Which.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Which()
        {
            ViewBag.Message = "This is the Which View";


            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a prototype application for Which TE owns which account?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return View();
        }
    }
}