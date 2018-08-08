using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Business
{
    public interface IPlanetBusiness
    {
        List<PlanetViewModel> ConnectionJson();
        void CreateNew(PlanetViewModel planet);
        Planet DatabaseModelParse(PlanetViewModel planetModel);
        void DeleteExisting(int id);
        void EditNew(PlanetViewModel planet);
        PlanetViewModel Find(int? id);
        List<PlanetViewModel> Get();
        List<PlanetViewModel> GetJsonToSQL();
        PlanetViewModel ModelParse(Planet planet);
    }
}