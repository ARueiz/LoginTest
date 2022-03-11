using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;
using LoginTest.Filters;

namespace LoginTest.Controllers
{
    [AuthorizeFilter(UserRole.Exhibitor)]
    public class exhibitorsController : Controller
    {
        private ExhibitionEntities db = new ExhibitionEntities();

        // GET: exhibitors
        public ActionResult Index()
        {
            ViewBag.sessionUserRole = Session["UserRole"];
            return View(db.exhibitors.ToList());
        }

        // GET: exhibitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exhibitor exhibitor = db.exhibitors.Find(id);
            if (exhibitor == null)
            {
                return HttpNotFound();
            }
            return View(exhibitor);
        }

        // GET: exhibitors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: exhibitors/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EID,admin,name,phone,email,link,password,image,verify")] exhibitor exhibitor)
        {
            if (ModelState.IsValid)
            {
                db.exhibitors.Add(exhibitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhibitor);
        }

        // GET: exhibitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exhibitor exhibitor = db.exhibitors.Find(id);
            if (exhibitor == null)
            {
                return HttpNotFound();
            }
            return View(exhibitor);
        }

        // POST: exhibitors/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EID,admin,name,phone,email,link,password,image,verify")] exhibitor exhibitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhibitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exhibitor);
        }

        // GET: exhibitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exhibitor exhibitor = db.exhibitors.Find(id);
            if (exhibitor == null)
            {
                return HttpNotFound();
            }
            return View(exhibitor);
        }

        // POST: exhibitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exhibitor exhibitor = db.exhibitors.Find(id);
            db.exhibitors.Remove(exhibitor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
