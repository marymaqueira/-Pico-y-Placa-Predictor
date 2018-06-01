using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PredictorProject.Models;
using PredictorProject.Services;

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
        public ActionResult Create([Bind(Include = "id,plate,dateToCheck,timeToCheck")] PlateNumberModel plateNumber)
        {
            var plate = plateNumber;
            if (ModelState.IsValid)
            {
                //Validate Informacion
                var plateNumberService = new PlateNumberService();
                var lastDigitPlate = plateNumber.plate[plateNumber.plate.Length - 1];
                var dayWeek = plateNumber.dateToCheck.ToString("ddd");
                DateTime convertHour = MergeHourToday(plateNumber.timeToCheck);


                var result = plateNumberService.getResult(lastDigitPlate, dayWeek, convertHour);

                ViewBag.alert = result;

                return View(plateNumber);
               
            }
            return RedirectToAction("Index");

        }


        public DateTime MergeHourToday(DateTime timePredictor)
        {
            return DateTime.Today.AddHours(timePredictor.Hour).AddMinutes(timePredictor.Minute).AddSeconds(timePredictor.Second);

        }
    }
}
