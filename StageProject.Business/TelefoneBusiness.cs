﻿using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel;
using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    public class TelefoneBusiness : ITelefoneBusiness
    {
        private SqlDatabaseModel db;
        public int Id { get; set; }        
        public EnumTipoTelefone TipoTelefone { get; set; }        
        public string Numero { get; set; }        
        public int IdCliente { get; set; }
        public virtual ClienteBusiness ClienteBusiness { get; set; }

        public TelefoneBusiness (SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;
        }        

        public TelefoneViewModel ModelParse(Telefone telefone)
        {
            TelefoneViewModel tvm = new TelefoneViewModel();
            tvm.Id = telefone.Id;
            tvm.IdCliente = telefone.IdCliente;
            tvm.TipoTelefone = telefone.TipoTelefone;
            tvm.Numero = telefone.Numero;
            return tvm;
        }

        public Telefone DatabaseModelParse(TelefoneViewModel telefoneModel)
        {
            Telefone telefone = new Telefone();
            telefone.Id = telefoneModel.Id;
            telefone.IdCliente = telefoneModel.IdCliente;
            telefone.TipoTelefone = telefoneModel.TipoTelefone;
            telefone.Numero = telefoneModel.Numero;
            return telefone;
        }

        public List<TelefoneViewModel> GetTelefone(List<Telefone> telefones)
        {
            List<TelefoneViewModel> telefoneModel = new List<TelefoneViewModel>();
            telefones.ForEach(
                (dbtelefone) =>
                {
                    var tvm = ModelParse(dbtelefone);
                    telefoneModel.Add(tvm);
                }
                );
            return telefoneModel;
        }

        public List<TelefoneViewModel> Get()
        {
            var telefone = db.Telefone;
            List<Telefone> telefonesdb = telefone.ToList();
            List<TelefoneViewModel> telefones = new List<TelefoneViewModel>();
            telefonesdb.ForEach(
                (dbtelefone) =>
                {
                    var tvm = ModelParse(dbtelefone);
                    telefones.Add(tvm);
                }
                );
            return telefones;
        }

        public TelefoneViewModel Find(int? id)
        {
            var telefone = db.Telefone.Where(t => t.Id == id).FirstOrDefault();
            var idTelefone = ModelParse(telefone);
            return idTelefone;
        }

        public void CreateNew(TelefoneViewModel telefone)
        {
            var telefoneModel = DatabaseModelParse(telefone);
            db.Telefone.Add(telefoneModel);
            db.SaveChanges();
        }

        public void EditNew(TelefoneViewModel telefone)
        {
            var telefoneModel = DatabaseModelParse(telefone);
            db.Entry(telefoneModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var telefone = db.Telefone.Where(t => t.Id == id).FirstOrDefault();
            db.Telefone.Remove(telefone);
            db.SaveChanges();
        }
    }
}
