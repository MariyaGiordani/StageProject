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
    public class SpecieBusiness : ISpecieBusiness
    {
        private SqlDatabaseModel db;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColor { get; set; }
        public string AverageLifespan { get; set; }
        public string Homeworld { get; set; }
        public string Language { get; set; }

        public SpecieBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;

        }


        public List<SpecieViewModel> ConnectionJson()
        {
            JSONHelper jh = new JSONHelper();
            string url = "https://swapi.co/api/species/?page=1";
            List<SpecieViewModel> species = new List<SpecieViewModel>();
            while (url != null)
            {
                string jsonString = jh.GetJSONString(url);
                var result = jh.GetObjectFromJSONString<PagedResultModel<SpecieViewModel>>(jsonString);
                species.AddRange(result.results);
                url = result.next;
            }
            return species;
        }

        public List<SpecieViewModel> GetJsonToSQL()
        {
            List<SpecieViewModel> species = ConnectionJson();
            species.ForEach(
                (dbspecie) =>
                {
                    var specieModel = DatabaseModelParse(dbspecie);
                    db.Specie.Add(specieModel);
                    db.SaveChanges();
                }
                );
            return species;
        }

        public SpecieViewModel ModelParse(Specie specie)
        {
            SpecieViewModel svm = new SpecieViewModel();
            svm.Id = specie.Id;
            svm.Name = specie.Name;
            svm.Classification = specie.Classification;
            svm.Designation = specie.Designation;
            svm.AverageHeight = specie.AverageHeight;
            svm.SkinColors = specie.SkinColors;
            svm.HairColors = specie.HairColors;
            svm.EyeColor = specie.EyeColor;
            svm.AverageLifespan = specie.AverageLifespan;
            svm.Homeworld = specie.Homeworld;
            svm.Language = specie.Language;
            return svm;
        }


        public Specie DatabaseModelParse(SpecieViewModel specieModel)
        {
            Specie specie = new Specie();
            specie.Id = specieModel.Id;
            specie.Name = specieModel.Name;
            specie.Classification = specieModel.Classification;
            specie.Designation = specieModel.Designation;
            specie.AverageHeight = specieModel.AverageHeight;
            specie.SkinColors = specieModel.SkinColors;
            specie.HairColors = specieModel.HairColors;
            specie.EyeColor = specieModel.EyeColor;
            specie.AverageLifespan = specieModel.AverageLifespan;
            specie.Homeworld = specieModel.Homeworld;
            specie.Language = specieModel.Language;
            return specie;
        }

        public List<SpecieViewModel> Get()
        {
            List<SpecieViewModel> species;
            if (db.Specie.Count() > 0)
            {
                species = new List<SpecieViewModel>();
            }
            else
            {
                species = GetJsonToSQL();
            }
            var specie = db.Specie;
            List<Specie> speciesdb = specie.ToList();
            speciesdb.ForEach(
                (dbspecie) =>
                {
                    var svm = ModelParse(dbspecie);
                    species.Add(svm);
                }
                );
            return species;
        }

        public SpecieViewModel Find(int? id)
        {
            var specie = db.Specie.Where(t => t.Id == id).FirstOrDefault();
            var _specie = ModelParse(specie);
            return _specie;
        }

        public void CreateNew(SpecieViewModel specie)
        {
            var specieModel = DatabaseModelParse(specie);
            db.Specie.Add(specieModel);
            db.SaveChanges();
        }

        public void EditNew(SpecieViewModel specie)
        {
            var specieModel = DatabaseModelParse(specie);
            db.Entry(specieModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var specie = db.Specie.Where(t => t.Id == id).FirstOrDefault();
            db.Specie.Remove(specie);
            db.SaveChanges();
        }
    }
}
