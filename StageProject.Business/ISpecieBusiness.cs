using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Business
{
    public interface ISpecieBusiness
    {
        List<SpecieViewModel> ConnectionJson();
        void CreateNew(SpecieViewModel specie);
        Specie DatabaseModelParse(SpecieViewModel specieModel);
        void EditNew(SpecieViewModel specie);
        SpecieViewModel Find(int? id);
        List<SpecieViewModel> Get();
        List<SpecieViewModel> GetJsonToSQL();
        SpecieViewModel ModelParse(Specie specie);
        void DeleteExisting(int id);
    }
}