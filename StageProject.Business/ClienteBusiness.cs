using StageProject.DataBaseAccess;
using StageProject.Model.Enumeradores;
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
    public class ClienteBusiness : IClienteBusiness
    {
        private SqlDatabaseModel db = new SqlDatabaseModel();
        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public EnumTipoCliente TipoCliente { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int NumeroAddresses { get; set; }
        public int NumeroTelefones { get; set; }

        public EnumEstadoCivil EstadoCivil { get; set; }
        public EnumGenero Genero { get; set; }
        public virtual TelefoneBusiness TelefoneBusiness { get; set; }

        public ClienteBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;
        }

        public ClientViewModel ModelParse(Cliente client)
        {
            ClientViewModel cvm = new ClientViewModel();
            cvm.Id = client.Id;
            cvm.TipoCliente = client.TipoCliente;
            cvm.CodigoCliente = client.CodigoCliente;
            cvm.Nome = client.Nome;
            cvm.Idade = client.Idade;
            cvm.EstadoCivil = client.EstadoCivil;
            cvm.Genero = client.Genero;
            cvm.NumeroAddresses = db.Endereco.Count(t => t.Cliente_Id == client.Id);
            cvm.NumeroTelefones = db.Telefone.Count(t => t.IdCliente == client.Id);
            cvm.TelefoneViewModels = ListTelefone();
            return cvm;
        }

        public List<TelefoneViewModel> ListTelefone()
        {
            TelefoneBusiness telefoneBusiness = new TelefoneBusiness(db);
            List<TelefoneViewModel> ListTelefone = telefoneBusiness.Get();
            return ListTelefone;
        }

        public Cliente DatabaseModelParse(ClientViewModel clientModel)
        {
            Cliente client = new Cliente();
            client.Id = clientModel.Id;
            client.TipoCliente = clientModel.TipoCliente;
            client.CodigoCliente = clientModel.CodigoCliente;
            client.Nome = clientModel.Nome;
            client.Idade = clientModel.Idade;
            client.EstadoCivil = clientModel.EstadoCivil;
            client.Genero = clientModel.Genero;
            return client;
        }

        public List<ClientViewModel> Get()
        {
            var client = db.Cliente.Include(c => c.Telefone);
            List<Cliente> clientsdb = client.ToList();
            List<ClientViewModel> clients = new List<ClientViewModel>();
            clientsdb.ForEach(
                (dbclient) =>
                {
                    var tvm = ModelParse(dbclient);
                    clients.Add(tvm);
                }
                );
            return clients;
        }

        public ClientViewModel Find(int? id)
        {
            var clientId = db.Cliente.Where(t => t.Id == id).FirstOrDefault();
            var idClient = ModelParse(clientId);
            return idClient;
        }

        public void CreateNew(ClientViewModel client)
        {
            var clientModel = DatabaseModelParse(client);
            db.Cliente.Add(clientModel);
            db.SaveChanges();
        }

        public void EditNew(ClientViewModel client)
        {
            var clientModel = DatabaseModelParse(client);
            db.Entry(clientModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var idClient = db.Cliente.Where(t => t.Id == id).FirstOrDefault();
            db.Cliente.Remove(idClient);
            db.SaveChanges();
        }

    }
}
