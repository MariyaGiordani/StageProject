using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel;
using System.Collections.Generic;

namespace StageProject.Business
{
    public interface IClienteBusiness
    {
        ClientViewModel ModelParse(Cliente client);
        Cliente DatabaseModelParse(ClientViewModel telefoneBusiness);
        List<ClientViewModel> Get();
        ClientViewModel Find(int? id);
        void CreateNew(ClientViewModel client);
        void EditNew(ClientViewModel client);
        void DeleteExisting(int id);
    }
}