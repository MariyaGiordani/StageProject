using StageProject.Business.Helper;
using StageProject.DataBaseAccess;
using StageProject.Model;
using StageProject.Model.ViewModel.StarWars;
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
    public class FilmBusiness : IFilmBusiness
    {
        private SqlDatabaseModel db;
        public int Id { get; set; }
        public string Title { get; set; }
        public string EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        //public string AllCharacter { get; set; }
        //public string Homeworld { get; set; }

        public FilmBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;

        }

        public List<FilmViewModel> ConnectionJson()
        {
            JSONHelper jh = new JSONHelper();
            string url = "https://swapi.co/api/films/";
            List<FilmViewModel> films = new List<FilmViewModel>();
            string jsonString = jh.GetJSONString(url);
            var result = jh.GetObjectFromJSONString<PagedResultModel<FilmViewModel>>(jsonString);
            films.AddRange(result.results);
            return films;
        }

        public List<FilmViewModel> GetJsonToSQL()
        {
            List<FilmViewModel> films = ConnectionJson();
            films.ForEach(
                (dbfilm) =>
                {
                    var filmModel = DatabaseModelParse(dbfilm);
                    db.Film.Add(filmModel);
                    db.SaveChanges();
                }
                );
            return films;
        }

        public FilmViewModel ModelParse(Film film)
        {
            FilmViewModel fvm = new FilmViewModel();
            fvm.Id = film.Id;
            fvm.Title = film.Title;
            fvm.EpisodeId = film.EpisodeId;
            fvm.OpeningCrawl = film.OpeningCrawl;
            fvm.Director = film.Director;
            fvm.Producer = film.Producer;
            fvm.ReleaseDate = film.ReleaseDate;
            return fvm;
        }


        public Film DatabaseModelParse(FilmViewModel filmModel)
        {
            Film film = new Film();
            film.Id = filmModel.Id;
            film.Title = filmModel.Title;
            film.EpisodeId = filmModel.EpisodeId;
            film.OpeningCrawl = filmModel.OpeningCrawl;
            film.Director = filmModel.Director;
            film.Producer = filmModel.Producer;
            film.ReleaseDate = filmModel.ReleaseDate;
            return film;
        }

        public List<FilmViewModel> Get()
        {
            List<FilmViewModel> films;
            if (db.Film.Count() > 0)
            {
                films = new List<FilmViewModel>();
            }
            else
            {
                films = GetJsonToSQL();
            }
            var film = db.Film;
            List<Film> filmsdb = film.ToList();
            filmsdb.ForEach(
                (dbfilm) =>
                {
                    var fvm = ModelParse(dbfilm);
                    films.Add(fvm);
                }
                );
            return films;
        }

        public FilmViewModel Find(int? id)
        {
            var film = db.Film.Where(t => t.Id == id).FirstOrDefault();
            var _film = ModelParse(film);
            return _film;
        }

        public void CreateNew(FilmViewModel film)
        {
            var filmModel = DatabaseModelParse(film);
            db.Film.Add(filmModel);
            db.SaveChanges();
        }

        public void EditNew(FilmViewModel film)
        {
            var filmModel = DatabaseModelParse(film);
            db.Entry(filmModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var film = db.Film.Where(t => t.Id == id).FirstOrDefault();
            db.Film.Remove(film);
            db.SaveChanges();
        }
    }
}
