using System.Collections.Generic;
using StageProject.DataBaseAccess;
using StageProject.Model.ViewModel.StarWars;

namespace StageProject.Business
{
    public interface IFilmBusiness
    {
        List<FilmViewModel> ConnectionJson();
        void CreateNew(FilmViewModel film);
        Film DatabaseModelParse(FilmViewModel filmModel);
        void DeleteExisting(int id);
        FilmViewModel Find(int? id);
        void EditNew(FilmViewModel film);
        List<FilmViewModel> Get();
        List<FilmViewModel> GetJsonToSQL();
        FilmViewModel ModelParse(Film film);
    }
}