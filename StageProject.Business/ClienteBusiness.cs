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
        private SqlDatabaseModel db;
        private ITelefoneBusiness tb;
        private IEnderecoBusiness eb;
        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public EnumTipoCliente TipoCliente { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int NumeroAddresses { get; set; }
        public int NumeroTelefones { get; set; }

        public EnumEstadoCivil EstadoCivil { get; set; }
        public EnumGenero Genero { get; set; }

        public ClienteBusiness(SqlDatabaseModel _dbinstance, ITelefoneBusiness telefoneBusiness, IEnderecoBusiness enderecoBusiness)
        {
            db = _dbinstance;
            tb = telefoneBusiness;
            eb = enderecoBusiness;
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
            List<Telefone> telefones = db.Telefone.Where(t => t.IdCliente == client.Id).ToList();
            cvm.TelefonesViewModels = ListTelefone(telefones);
            List<Endereco> addresses = db.Endereco.Where(t => t.Cliente_Id == client.Id).ToList();
            cvm.AddressesViewModels = ListAddress(addresses);
            return cvm;
        }

        public List<TelefoneViewModel> ListTelefone(List<Telefone> telefones)
        {
            List<TelefoneViewModel> ListTelefone = tb.GetTelefone(telefones);
            return ListTelefone;
        }

        public List<AddressViewModel> ListAddress(List<Endereco> addresses)
        {
            List<AddressViewModel> ListAddress = eb.GetAddress(addresses);
            return ListAddress;
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
            var client = db.Cliente;
            List<Cliente> clientsdb = client.ToList();
            List<ClientViewModel> clients = new List<ClientViewModel>();
            clientsdb.ForEach(
                (dbclient) =>
                {
                    var cvm = ModelParse(dbclient);
                    clients.Add(cvm);
                }
                );
            return clients;
        }

        public ClientViewModel Find(int? id)
        {
            var client = db.Cliente.Where(t => t.Id == id).FirstOrDefault();
            var _client = ModelParse(client);
            return _client;
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
            var client = db.Cliente.Where(t => t.Id == id).FirstOrDefault();
            db.Cliente.Remove(client);
            db.SaveChanges();
        }

    }
}
