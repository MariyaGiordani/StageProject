using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel;

namespace StageProject.Business
{
    public interface IEnderecoBusiness
    {
        void CreateNew(AddressViewModel address);
        Endereco DatabaseModelParse(AddressViewModel addressModel);
        void DeleteExisting(int id);
        void EditNew(AddressViewModel address);
        AddressViewModel Find(int? id);
        List<AddressViewModel> Get();
        List<AddressViewModel> GetAddress(List<Endereco> addresses);
        AddressViewModel ModelParse(Endereco address);
    }
}