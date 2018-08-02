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
    public class EnderecosController : Controller
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        private readonly IEnderecoBusiness _addressBusiness;

        public EnderecosController(IEnderecoBusiness addressBusiness)
        {
            _addressBusiness = addressBusiness;
        }

        // GET: Enderecos
        public ActionResult Index()
        {
            List<AddressViewModel> addresses = _addressBusiness.Get();
            return View(addresses);
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressViewModel address = _addressBusiness.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
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
        public ActionResult Create([Bind(Include = "Id,Cliente_Id,IDEndereco,TipoLogradouro,NomeLogradouro,Complemento,CEP,Bairro,Cidade")] AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
                _addressBusiness.CreateNew(address);
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente", address.Cliente_Id);
            return View(address);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressViewModel address = _addressBusiness.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente", address.Cliente_Id);
            return View(address);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cliente_Id,IDEndereco,TipoLogradouro,NomeLogradouro,Complemento,CEP,Bairro,Cidade")] AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
                _addressBusiness.EditNew(address);
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id", "CodigoCliente", address.Cliente_Id);
            return View(address);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressViewModel address = _addressBusiness.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _addressBusiness.DeleteExisting(id);
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
