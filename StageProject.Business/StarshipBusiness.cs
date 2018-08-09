using StageProject.Business.Helper;
using StageProject.DataBaseAccess;
using StageProject.Model;
using StageProject.Model.ViewModel.StarWars;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    public class StarshipBusiness : IStarshipBusiness
    {
        private SqlDatabaseModel db;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string HyperdriveRating { get; set; }
        public string MGLT { get; set; }
        public string StarshipClass { get; set; }

        public StarshipBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;

        }

        public List<StarshipViewModel> ConnectionJson()
        {
            JSONHelper jh = new JSONHelper();
            string url = "https://swapi.co/api/starships/?page=1";
            List<StarshipViewModel> starships = new List<StarshipViewModel>();
            while (url != null)
            {
                string jsonString = jh.GetJSONString(url);
                var result = jh.GetObjectFromJSONString<PagedResultModel<StarshipViewModel>>(jsonString);
                starships.AddRange(result.results);
                url = result.next;
            }
            return starships;
        }

        public List<StarshipViewModel> GetJsonToSQL()
        {
            List<StarshipViewModel> starships = ConnectionJson();
            starships.ForEach(
                (dbstarship) =>
                {
                    var starshipModel = DatabaseModelParse(dbstarship);
                    db.Starship.Add(starshipModel);
                    db.SaveChanges();
                }
                );
            return starships;
        }

        public StarshipViewModel ModelParse(Starship starship)
        {
            StarshipViewModel stvm = new StarshipViewModel();
            stvm.Id = starship.Id;
            stvm.Name = starship.Name;
            stvm.Model = starship.Model;
            stvm.Manufacturer = starship.Manufacturer;
            stvm.CostInCredits = starship.CostInCredits;
            stvm.Length = starship.Length;
            stvm.MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed;
            stvm.Crew = starship.Crew;
            stvm.Passengers = starship.Passengers;
            stvm.CargoCapacity = starship.CargoCapacity;
            stvm.Consumables = starship.Consumables;
            stvm.HyperdriveRating = starship.HyperdriveRating;
            stvm.MGLT = starship.MGLT;
            stvm.StarshipClass = starship.StarshipClass;
            return stvm;
        }


        public Starship DatabaseModelParse(StarshipViewModel starshipModel)
        {
            Starship starship = new Starship();
            starship.Id = starshipModel.Id;
            starship.Name = starshipModel.Name;
            starship.Model = starshipModel.Model;
            starship.Manufacturer = starshipModel.Manufacturer;
            starship.CostInCredits = starshipModel.CostInCredits;
            starship.Length = starshipModel.Length;
            starship.MaxAtmospheringSpeed = starshipModel.MaxAtmospheringSpeed;
            starship.Crew = starshipModel.Crew;
            starship.Passengers = starshipModel.Passengers;
            starship.CargoCapacity = starshipModel.CargoCapacity;
            starship.Consumables = starshipModel.Consumables;
            starship.HyperdriveRating = starshipModel.HyperdriveRating;
            starship.MGLT = starshipModel.MGLT;
            starship.StarshipClass = starshipModel.StarshipClass;
            return starship;
        }

        public List<StarshipViewModel> Get()
        {
            List<StarshipViewModel> starships;
            if (db.Starship.Count() > 0)
            {
                starships = new List<StarshipViewModel>();
            }
            else
            {
                starships = GetJsonToSQL();
            }
            var starship = db.Starship;
            List<Starship> starshipsdb = starship.ToList();
            starshipsdb.ForEach(
                (dbstarship) =>
                {
                    var stvm = ModelParse(dbstarship);
                    starships.Add(stvm);
                }
                );
            return starships;
        }

        public StarshipViewModel Find(int? id)
        {
            var starship = db.Starship.Where(t => t.Id == id).FirstOrDefault();
            var _starship = ModelParse(starship);
            return _starship;
        }

        public void CreateNew(StarshipViewModel starship)
        {
            var starshipModel = DatabaseModelParse(starship);
            db.Starship.Add(starshipModel);
            db.SaveChanges();
        }

        public void EditNew(StarshipViewModel starship)
        {
            var starshipModel = DatabaseModelParse(starship);
            db.Entry(starshipModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var starship = db.Starship.Where(t => t.Id == id).FirstOrDefault();
            db.Starship.Remove(starship);
            db.SaveChanges();
        }
    }
}
