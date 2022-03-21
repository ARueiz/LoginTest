using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.ViewModel;
using LoginTest.Models;
using LoginTest.Function;
using System.Text;
using static LoginTest.ViewModel.DoSendMail;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {
        private ExhibitionEntities db = new ExhibitionEntities();
        public ActionResult Index()
        {
            Session["UserRole"] = "Visitor";
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
        public ActionResult userLogin(CLoginViewModel logindata)
        {
            //return Content($"帳號:{logindata.email}\n密碼:{logindata.password}", "text/plain", Encoding.UTF8);

            bool exists = db.users.Any(users => users.email == logindata.email && users.password == logindata.password);
            if (exists)
            {
                //return Content($"帳號:{logindata.email}\n密碼:{logindata.password} 登入成功", "text/plain", Encoding.UTF8);
                Session["UserRole"] = "User";
                return RedirectToAction("index", "users");
            }
            else
            {
                return Content($"帳號:{logindata.email}\n密碼:{logindata.password} 登入失敗", "text/plain", Encoding.UTF8);
            }
            //if (string.IsNullOrEmpty(logindata.email) || string.IsNullOrEmpty(logindata.password))
            //{
            //    return RedirectToAction("index", "Home");
            //}
            //else
            //{
            //    var userData = db.users.Where(user => user.email == logindata.email && user.password == logindata.password);

            //    if (userData != null)
            //    {
            //        Session["UserRole"] = "User";
            //        Session["UserName"] = userData[0].name;
            //        return RedirectToAction("index", "users");
            //    }
            //    else
            //    {
            //        return RedirectToAction("index", "Home");
            //    }
            //}
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

        public ActionResult userRegister()
        {
            return View();
        }

        public ActionResult sendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sendEmail(string email)
        {
            
            
            return View();
        }

        public ActionResult DoSendMail(DoSendMailIn inModel)
        {
            Function.MailSend.sendGmail(inModel.email, inModel.content);

            return Content($"{inModel.email} 你好! {inModel.content}", "text/plain", Encoding.UTF8);
        }
        
    }
}