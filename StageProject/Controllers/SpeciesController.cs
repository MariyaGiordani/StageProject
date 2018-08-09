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
    public class SpeciesController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        private readonly ISpecieBusiness _specieBusiness;

        public SpeciesController(ISpecieBusiness specieBusiness)
        {
            _specieBusiness = specieBusiness;
        }

        // GET: Species
        public ActionResult Index()
        {
            List<SpecieViewModel> specie = _specieBusiness.Get();
            return View(specie);
        }

        // GET: Species/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecieViewModel specie = _specieBusiness.Find(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }

        // GET: Species/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Classification,Designation,AverageHeight,SkinColors,HairColors,EyeColor,AverageLifespan,Homeworld,Language")] SpecieViewModel specie)
        {
            if (ModelState.IsValid)
            {
                _specieBusiness.CreateNew(specie);
                return RedirectToAction("Index");
            }

            return View(specie);
        }

        // GET: Species/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecieViewModel specie = _specieBusiness.Find(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Classification,Designation,AverageHeight,SkinColors,HairColors,EyeColor,AverageLifespan,Homeworld,Language")] SpecieViewModel specie)
        {
            if (ModelState.IsValid)
            {
                _specieBusiness.EditNew(specie);
                return RedirectToAction("Index");
            }
            return View(specie);
        }

        // GET: Species/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecieViewModel specie = _specieBusiness.Find(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _specieBusiness.DeleteExisting(id);
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
