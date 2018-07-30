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
using StageProject.Model.ViewModel;

namespace StageProject.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly ITelefoneBusiness _telefoneBusiness;

        public TelefonesController (ITelefoneBusiness telefoneBusiness)
        {
            _telefoneBusiness = telefoneBusiness;
        }

        // GET: Telefones
        public ActionResult Index()
        {
            List<TelefoneViewModel> telefones = _telefoneBusiness.Get();
            return View(telefones);
        }

        // GET: Telefones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefoneViewModel telefone = _telefoneBusiness.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,TipoTelefone,Numero,IdCliente")] TelefoneViewModel telefone)
        {
            if (ModelState.IsValid)
            {
                _telefoneBusiness.CreateNew(telefone);
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
            TelefoneViewModel telefone = _telefoneBusiness.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,TipoTelefone,Numero,IdCliente")] TelefoneViewModel telefone)
        {
            if (ModelState.IsValid)
            {
                _telefoneBusiness.EditNew(telefone);
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
            TelefoneViewModel telefone = _telefoneBusiness.Find(id);
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
            _telefoneBusiness.DeleteExisting(id);
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


        private SqlDatabaseModel db = new SqlDatabaseModel();
    }
}
