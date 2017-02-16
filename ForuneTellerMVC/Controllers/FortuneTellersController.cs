using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ForuneTellerMVC.Models;

namespace ForuneTellerMVC.Controllers
{
    public class FortuneTellersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: FortuneTellers
        public ActionResult Index()
        {
            return View(db.FortuneTellers.ToList());
        }

        // GET: FortuneTellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FortuneTeller fortuneTeller = db.FortuneTellers.Find(id);
            if (fortuneTeller == null)
            {
                return HttpNotFound();
            }
            if (fortuneTeller.Age==0)
            
            {
                ViewBag.Age = "5 years";
            }
           if (fortuneTeller.BirthMonth==12)
            {
                ViewBag.BirthMonth = "Greece";
            }
            return View(fortuneTeller);
        }

        // GET: FortuneTellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FortuneTellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberofSiblings")] FortuneTeller fortuneTeller)
        {
            if (ModelState.IsValid)
            {
                db.FortuneTellers.Add(fortuneTeller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fortuneTeller);
        }

        // GET: FortuneTellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FortuneTeller fortuneTeller = db.FortuneTellers.Find(id);
            if (fortuneTeller == null)
            {
                return HttpNotFound();
            }
            return View(fortuneTeller);
        }

        // POST: FortuneTellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberofSiblings")] FortuneTeller fortuneTeller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fortuneTeller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fortuneTeller);
        }

        // GET: FortuneTellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FortuneTeller fortuneTeller = db.FortuneTellers.Find(id);
            if (fortuneTeller == null)
            {
                return HttpNotFound();
            }
            return View(fortuneTeller);
        }

        // POST: FortuneTellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FortuneTeller fortuneTeller = db.FortuneTellers.Find(id);
            db.FortuneTellers.Remove(fortuneTeller);
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
