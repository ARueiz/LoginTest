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
    [AuthorizeFilter(UserRole.Host)]
    public class hostsController : Controller
    {
        private ExhibitionEntities db = new ExhibitionEntities();

        // GET: hosts
        public ActionResult Index()
        {
            ViewBag.sessionUserRole = Session["UserRole"];
            return View(db.hosts.ToList());
        }

        // GET: hosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            host host = db.hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // GET: hosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hosts/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HID,admin,name,phone,email,link,password,image,verify")] host host)
        {
            if (ModelState.IsValid)
            {
                db.hosts.Add(host);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(host);
        }

        // GET: hosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            host host = db.hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: hosts/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HID,admin,name,phone,email,link,password,image,verify")] host host)
        {
            if (ModelState.IsValid)
            {
                db.Entry(host).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(host);
        }

        // GET: hosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            host host = db.hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            host host = db.hosts.Find(id);
            db.hosts.Remove(host);
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
