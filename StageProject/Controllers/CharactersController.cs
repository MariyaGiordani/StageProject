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
    public class CharactersController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        private readonly ICharacterBusiness _characterBusiness;

        public CharactersController(ICharacterBusiness characterBusiness)
        {
            _characterBusiness = characterBusiness;
        }

        // GET: Characters
        public ActionResult Index()
        {
            List<CharacterViewModel> character = _characterBusiness.Get();
            //List<CharacterViewModel> character = _characterBusiness.ConnectionJson();
            return View(character);
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterViewModel character = _characterBusiness.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Height,Mass,Hair_color,Skin_color,Eye_color,Birth_year,Genero,Homeworld,AllFilms,TypeSpecies,AllVehicles,AllStarships")] CharacterViewModel character)
        {
            if (ModelState.IsValid)
            {
                _characterBusiness.CreateNew(character);
                return RedirectToAction("Index");
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterViewModel character = _characterBusiness.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Height,Mass,Hair_color,Skin_color,Eye_color,Birth_year,Genero,Homeworld,AllFilms,TypeSpecies,AllVehicles,AllStarships")] CharacterViewModel character)
        {
            if (ModelState.IsValid)
            {
                _characterBusiness.EditNew(character);
                return RedirectToAction("Index");
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterViewModel character = _characterBusiness.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _characterBusiness.DeleteExisting(id);
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
