using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Business
{
    public interface IVehiculeBusiness
    {
        List<VehiculeViewModel> ConnectionJson();
        void CreateNew(VehiculeViewModel vehicule);
        Vehicule DatabaseModelParse(VehiculeViewModel vehiculeModel);
        void DeleteExisting(int id);
        void EditNew(VehiculeViewModel vehicule);
        VehiculeViewModel Find(int? id);
        List<VehiculeViewModel> Get();
        List<VehiculeViewModel> GetJsonToSQL();
        VehiculeViewModel ModelParse(Vehicule vehicule);
    }
}