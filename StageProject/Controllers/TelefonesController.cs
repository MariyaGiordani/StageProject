using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StageProject.DataBaseAccess;

namespace StageProject.Controllers
{
    public class TelefonesController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();

        public TelefonesController (SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;
        }

        // GET: Telefones
        public ActionResult Index()
        {
            var telefone = db.Telefone.Include(t => t.Cliente);
            IEnumerable<Telefone>telefones = telefone.ToList();
            return View(telefones);
        }

        // GET: Telefones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // GET: Telefones/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "CodigoCliente");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoTelefone,Numero,IdCliente")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Telefone.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "CodigoCliente", telefone.IdCliente);
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "CodigoCliente", telefone.IdCliente);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoTelefone,Numero,IdCliente")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "CodigoCliente", telefone.IdCliente);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefone telefone = db.Telefone.Find(id);
            db.Telefone.Remove(telefone);
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
