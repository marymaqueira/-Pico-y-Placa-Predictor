using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PredictorProject.Models;

namespace PredictorProject.Controllers
{
    public class PlateNumbersController : Controller
    {
        private PlateNumberContext db = new PlateNumberContext();

        // GET: PlateNumbers
        public ActionResult Index()
        {
            return View(db.PlateNumbers.ToList());
        }

        // GET: PlateNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlateNumberModel plateNumber = db.PlateNumbers.Find(id);
            if (plateNumber == null)
            {
                return HttpNotFound();
            }
            return View(plateNumber);
        }

        // GET: PlateNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlateNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] PlateNumberModel plateNumber)
        {
            if (ModelState.IsValid)
            {
                db.PlateNumbers.Add(plateNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plateNumber);
        }

        // GET: PlateNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlateNumberModel plateNumber = db.PlateNumbers.Find(id);
            if (plateNumber == null)
            {
                return HttpNotFound();
            }
            return View(plateNumber);
        }

        // POST: PlateNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] PlateNumberModel plateNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plateNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plateNumber);
        }

        // GET: PlateNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlateNumberModel plateNumber = db.PlateNumbers.Find(id);
            if (plateNumber == null)
            {
                return HttpNotFound();
            }
            return View(plateNumber);
        }

        // POST: PlateNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlateNumberModel plateNumber = db.PlateNumbers.Find(id);
            db.PlateNumbers.Remove(plateNumber);
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
