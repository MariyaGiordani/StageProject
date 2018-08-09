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
    public class StarshipsController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        private readonly IStarshipBusiness _starshipBusiness;

        public StarshipsController(IStarshipBusiness starshipBusiness)
        {
            _starshipBusiness = starshipBusiness;
        }

        // GET: Starships
        public ActionResult Index()
        {
            List<StarshipViewModel> starship = _starshipBusiness.Get();
            return View(starship);
        }

        // GET: Starships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarshipViewModel starship = _starshipBusiness.Find(id);
            if (starship == null)
            {
                return HttpNotFound();
            }
            return View(starship);
        }

        // GET: Starships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Starships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Model,Manufacturer,CostInCredits,Length,MaxAtmospheringSpeed,Crew,Passengers,CargoCapacity,Consumables,HyperdriveRating,MGLT,StarshipClass")] StarshipViewModel starship)
        {
            if (ModelState.IsValid)
            {
                _starshipBusiness.CreateNew(starship);
                return RedirectToAction("Index");
            }

            return View(starship);
        }

        // GET: Starships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarshipViewModel starship = _starshipBusiness.Find(id);
            if (starship == null)
            {
                return HttpNotFound();
            }
            return View(starship);
        }

        // POST: Starships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Model,Manufacturer,CostInCredits,Length,MaxAtmospheringSpeed,Crew,Passengers,CargoCapacity,Consumables,HyperdriveRating,MGLT,StarshipClass")] StarshipViewModel starship)
        {
            if (ModelState.IsValid)
            {
                _starshipBusiness.EditNew(starship);
                return RedirectToAction("Index");
            }
            return View(starship);
        }

        // GET: Starships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Starship starship = db.Starship.Find(id);
            if (starship == null)
            {
                return HttpNotFound();
            }
            return View(starship);
        }

        // POST: Starships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StarshipViewModel character = _starshipBusiness.Find(id);
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
