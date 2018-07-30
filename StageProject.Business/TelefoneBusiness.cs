using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel;
using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    public class TelefoneBusiness : ITelefoneBusiness
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        public int Id { get; set; }        
        public EnumTipoTelefone TipoTelefone { get; set; }        
        public string Numero { get; set; }        
        public int IdCliente { get; set; }
        public virtual ClienteBusiness Cliente { get; set; }

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

        public Telefone DatabaseModelParse(TelefoneViewModel telefoneBusiness)
        {
            Telefone telefone = new Telefone();
            telefone.IdCliente = telefoneBusiness.IdCliente;
            telefone.TipoTelefone = telefoneBusiness.TipoTelefone;
            telefone.Numero = telefoneBusiness.Numero;
            return telefone;
        }

        public List<TelefoneViewModel> Get()
        {
            //var telefone = db.Telefone.Include(t => t.Cliente);
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
            var telefoneId = db.Telefone.Where(t => t.Id == id).FirstOrDefault();
            var idTelefone = ModelParse(telefoneId);
            return idTelefone;
        }

        public TelefoneViewModel CreateNew(Telefone telefone)
        {
            var telefoneModel = ModelParse(telefone);
            List<TelefoneViewModel> telefones = new List<TelefoneViewModel>();
            telefones.Add(telefoneModel);
            return telefoneModel;
        }
    }
}
