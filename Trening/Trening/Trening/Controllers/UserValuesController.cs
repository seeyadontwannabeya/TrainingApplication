using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trening.Models;


namespace Trening.Controllers
{
    public class UserValuesController : Controller
    {
        private TreningEntities db = new TreningEntities();

        // GET: UserValues
        //public ActionResult Index()
        //{
        //    var userValues = db.UserValues.Include(u => u.Login).Include(u => u.Login);
        //    return View(userValues.ToList());
        //}

        // GET: UserValues/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserValues userValues = db.UserValues.Find(id);
        //    if (userValues == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userValues);
        //}

        // GET: UserValues/Create
        public ActionResult Create()
        {
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Email");
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Email");
            return View();
        }

        // POST: UserValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Date,Height,Age,Weight,Activityfactor,Trainingexperience,KcalResult,Kcalplusminus,LoginID")] UserValues userValues)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UserValues.Add(userValues);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.LoginID = new SelectList(db.Login, "ID", "Email", userValues.LoginID);
        //    ViewBag.LoginID = new SelectList(db.Login, "ID", "Email", userValues.LoginID);
        //    return View(userValues);
        //}

        // GET: UserValues/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserValues userValues = db.UserValues.Find(id);
        //    if (userValues == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.LoginID = new SelectList(db.Login, "ID", "Email", userValues.LoginID);
        //    ViewBag.LoginID = new SelectList(db.Login, "ID", "Email", userValues.LoginID);
        //    return View(userValues);
        //}

        // POST: UserValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Date,Height,Age,Weight,Activityfactor,Trainingexperience,KcalResult,Kcalplusminus,LoginID")] UserValues userValues)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userValues).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.LoginID = new SelectList(db.Login, "ID", "Email", userValues.LoginID);
        //    ViewBag.LoginID = new SelectList(db.Login, "ID", "Email", userValues.LoginID);
        //    return View(userValues);
        //}

        // GET: UserValues/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserValues userValues = db.UserValues.Find(id);
        //    if (userValues == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userValues);
        //}

        // POST: UserValues/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UserValues userValues = db.UserValues.Find(id);
        //    db.UserValues.Remove(userValues);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
