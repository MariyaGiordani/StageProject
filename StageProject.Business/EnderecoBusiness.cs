using StageProject.DataBaseAccess;
using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageProject.Model;
using StageProject.Model.ViewModel;
using System.Data.Entity;

namespace StageProject.Business
{
    public class EnderecoBusiness : IEnderecoBusiness
    {
        private SqlDatabaseModel db;
        public int Id { get; set; }
        public string IDEndereco { get; set; }
        public EnumTipoLogradouro TipoLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public virtual ClienteBusiness Cliente { get; set; }

        public EnderecoBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;
        }

        public AddressViewModel ModelParse(Endereco address)
        {
            AddressViewModel avm = new AddressViewModel();
            avm.Id = address.Id;
            avm.Cliente_Id = address.Cliente_Id;
            avm.IDEndereco = address.IDEndereco;
            avm.TipoLogradouro = address.TipoLogradouro;
            avm.NomeLogradouro = address.NomeLogradouro;
            avm.Complemento = address.Complemento;
            avm.CEP = address.CEP;
            avm.Bairro = address.Bairro;
            avm.Cidade = address.Cidade;
            return avm;
        }

        public Endereco DatabaseModelParse(AddressViewModel addressModel)
        {
            Endereco address= new Endereco();
            address.Id = addressModel.Id;
            address.Cliente_Id = addressModel.Cliente_Id;
            address.IDEndereco = addressModel.IDEndereco;
            address.TipoLogradouro = addressModel.TipoLogradouro;
            address.NomeLogradouro = addressModel.NomeLogradouro;
            address.Complemento = addressModel.Complemento;
            address.CEP = addressModel.CEP;
            address.Bairro = addressModel.Bairro;
            address.Cidade = addressModel.Cidade;
            return address;
        }

        public List<AddressViewModel> GetAddress(List<Endereco> addresses)
        {
            List<AddressViewModel> addressesModel = new List<AddressViewModel>();
            addresses.ForEach(
                (dbaddress) =>
                {
                    var avm = ModelParse(dbaddress);
                    addressesModel.Add(avm);
                }
                );
            return addressesModel;
        }

        public List<AddressViewModel> Get()
        {
            var address = db.Endereco;
            List<Endereco> adddressesdb = address.ToList();
            List<AddressViewModel> addresses = new List<AddressViewModel>();
            adddressesdb.ForEach(
                (dbaddress) =>
                {
                    var avm = ModelParse(dbaddress);
                    addresses.Add(avm);
                }
                );
            return addresses;
        }

        public AddressViewModel Find(int? id)
        {
            var address = db.Endereco.Where(t => t.Id == id).FirstOrDefault();
            var _address = ModelParse(address);
            return _address;
        }

        public void CreateNew(AddressViewModel address)
        {
            var addressModel = DatabaseModelParse(address);
            db.Endereco.Add(addressModel);
            db.SaveChanges();
        }

        public void EditNew(AddressViewModel address)
        {
            var addressModel = DatabaseModelParse(address);
            db.Entry(addressModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var address = db.Endereco.Where(t => t.Id == id).FirstOrDefault();
            db.Endereco.Remove(address);
            db.SaveChanges();
        }
    }
}
