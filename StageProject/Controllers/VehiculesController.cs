using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StageProject.Business;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Controllers
{
    public class VehiculesController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        private readonly IVehiculeBusiness _vehiculeBusiness;

        public VehiculesController(IVehiculeBusiness vehiculeBusiness)
        {
            _vehiculeBusiness = vehiculeBusiness;
        }

        // GET: Vehicules
        public ActionResult Index()
        {
            List<VehiculeViewModel> vehicules = _vehiculeBusiness.Get();
            return View(vehicules);
        }

        // GET: Vehicules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculeViewModel vehicule = _vehiculeBusiness.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // GET: Vehicules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Model,Manufacturer,CostInCredits,Length,MaxAtmospheringSpeed,Crew,Passengers,CargoCapacity,Consumables,VehicleClass")] VehiculeViewModel vehicule)
        {
            if (ModelState.IsValid)
            {
                _vehiculeBusiness.CreateNew(vehicule);
                return RedirectToAction("Index");
            }

            return View(vehicule);
        }

        // GET: Vehicules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculeViewModel vehicule = _vehiculeBusiness.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Model,Manufacturer,CostInCredits,Length,MaxAtmospheringSpeed,Crew,Passengers,CargoCapacity,Consumables,VehicleClass")] VehiculeViewModel vehicule)
        {
            if (ModelState.IsValid)
            {
                _vehiculeBusiness.EditNew(vehicule);
                return RedirectToAction("Index");
            }
            return View(vehicule);
        }

        // GET: Vehicules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculeViewModel vehicule = _vehiculeBusiness.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _vehiculeBusiness.DeleteExisting(id);
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
