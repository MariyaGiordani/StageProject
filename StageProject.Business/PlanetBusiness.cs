using StageProject.Business.Helper;
using StageProject.DataBaseAccess;
using StageProject.Model;
using StageProject.Model.ViewModel.StarWars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    public class PlanetBusiness : IPlanetBusiness
    {
        private SqlDatabaseModel db;
        public string Name { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        //public string Residents { get; set; }

        public List<Film> Films { get; set; }

        public PlanetBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;

        }

        public List<PlanetViewModel> ConnectionJson()
        {
            JSONHelper jh = new JSONHelper();
            string url = "https://swapi.co/api/planets/?page=1";
            List<PlanetViewModel> planets = new List<PlanetViewModel>();
            while (url != null)
            {
                string jsonString = jh.GetJSONString(url);
                var result = jh.GetObjectFromJSONString<PagedResultModel<PlanetViewModel>>(jsonString);
                planets.AddRange(result.results);
                url = result.next;
            }
            return planets;
        }

        public List<PlanetViewModel> GetJsonToSQL()
        {
            List<PlanetViewModel> planets = ConnectionJson();
            planets.ForEach(
                (dbplanet) =>
                {
                    var planetModel = DatabaseModelParse(dbplanet);
                    db.Planet.Add(planetModel);
                    db.SaveChanges();
                }
                );
            return planets;
        }

        public PlanetViewModel ModelParse(Planet planet)
        {
            PlanetViewModel pvm = new PlanetViewModel();
            pvm.Id = planet.Id;
            pvm.Name = planet.Name;
            pvm.RotationPeriod = planet.RotationPeriod;
            pvm.OrbitalPeriod = planet.OrbitalPeriod;
            pvm.Diameter = planet.Diameter;
            pvm.Climate = planet.Climate;
            pvm.Gravity = planet.Gravity;
            pvm.Terrain = planet.Terrain;
            pvm.SurfaceWater = planet.SurfaceWater;
            pvm.Population = planet.Population;
            return pvm;
        }


        public Planet DatabaseModelParse(PlanetViewModel planetModel)
        {
            Planet planet = new Planet();
            planet.Id = planetModel.Id;
            planet.Name = planetModel.Name;
            planet.RotationPeriod = planetModel.RotationPeriod;
            planet.OrbitalPeriod = planetModel.OrbitalPeriod;
            planet.Diameter = planetModel.Diameter;
            planet.Climate = planetModel.Climate;
            planet.Gravity = planetModel.Gravity;
            planet.Terrain = planetModel.Terrain;
            planet.SurfaceWater = planetModel.SurfaceWater;
            planet.Population = planetModel.Population;
            return planet;
        }

        public List<PlanetViewModel> Get()
        {
            List<PlanetViewModel> planets;
            if (db.Planet.Count() > 0)
            {
                planets = new List<PlanetViewModel>();
            }
            else
            {
                planets = GetJsonToSQL();
            }
            var planet = db.Planet;
            List<Planet> planetsdb = planet.ToList();
            planetsdb.ForEach(
                (dbplanet) =>
                {
                    var pvm = ModelParse(dbplanet);
                    planets.Add(pvm);
                }
                );
            return planets;
        }

        public PlanetViewModel Find(int? id)
        {
            var planet = db.Planet.Where(t => t.Id == id).FirstOrDefault();
            var _planet = ModelParse(planet);
            return _planet;
        }

        public void CreateNew(PlanetViewModel planet)
        {
            var planetModel = DatabaseModelParse(planet);
            db.Planet.Add(planetModel);
            db.SaveChanges();
        }

        public void EditNew(PlanetViewModel planet)
        {
            var planetModel = DatabaseModelParse(planet);
            db.Entry(planetModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var planet = db.Planet.Where(t => t.Id == id).FirstOrDefault();
            db.Planet.Remove(planet);
            db.SaveChanges();
        }
    }
}
