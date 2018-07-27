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
    public class EnderecosController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();

        public EnderecosController(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;
        }

        // GET: Enderecos
        public ActionResult Index()
        {
            var endereco = db.Endereco.Include(e => e.Cliente);
            return View(endereco.ToList());
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente");
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cliente_Id,IDEndereco,TipoLogradouro,NomeLogradouro,Complemento,CEP,Bairro,Cidade")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente", endereco.Cliente_Id);
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente", endereco.Cliente_Id);
            return View(endereco);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cliente_Id,IDEndereco,TipoLogradouro,NomeLogradouro,Complemento,CEP,Bairro,Cidade")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente", endereco.Cliente_Id);
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            db.Endereco.Remove(endereco);
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
