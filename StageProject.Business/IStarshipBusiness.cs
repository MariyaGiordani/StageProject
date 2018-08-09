using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Business
{
    public interface IStarshipBusiness
    {
        List<StarshipViewModel> ConnectionJson();
        void CreateNew(StarshipViewModel starship);
        Starship DatabaseModelParse(StarshipViewModel starshipModel);
        void DeleteExisting(int id);
        void EditNew(StarshipViewModel starship);
        StarshipViewModel Find(int? id);
        List<StarshipViewModel> Get();
        List<StarshipViewModel> GetJsonToSQL();
        StarshipViewModel ModelParse(Starship starship);
    }
}