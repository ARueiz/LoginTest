using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.ViewModel;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.sessionUserRole = Session["UserRole"];
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult userLogin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult userLogin(CLoginViewModel vmodel)
        {
            Session.Clear();
            Session["UserRole"] = "User";

            return RedirectToAction("index", "users");
        }

        public ActionResult ExhibitorLogin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ExhibitorLogin(CLoginViewModel vmodel)
        {
            ViewBag.Message = "Your contact page.";

            Session["UserRole"] = "Exhibitor";

            return RedirectToAction("index", "exhibitors");
        }

        public ActionResult hostLogin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult hostLogin(CLoginViewModel vmodel)
        {
            ViewBag.Message = "Your contact page.";

            Session["UserRole"] = "Host";

            return RedirectToAction("index","hosts");
        }

        public ActionResult Logout(CLoginViewModel vmodel)
        {
            Session.Clear();

            return RedirectToAction("index");
        }
    }
}