using StageProject.Business.Helper;
using StageProject.DataBaseAccess;
using StageProject.Model;
using StageProject.Model.Model;
using StageProject.Model.ViewModel.StarWars;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    class VehiculeBusiness
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
        public string VehicleClass { get; set; }

        public VehiculeBusiness(SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;

        }

        //public List<VehiculeViewModel> ConnectionJson()
        //{
        //    JSONHelper jh = new JSONHelper();
        //    string url = "https://swapi.co/api/vehicles/?page=1";
        //    List<VehiculeViewModel> vehicules = new List<VehiculeViewModel>();
        //    while (url != null)
        //    {
        //        string jsonString = jh.GetJSONString(url);
        //        var result = jh.GetObjectFromJSONString<PagedResultModel<VehiculeViewModel>>(jsonString);
        //        vehicules.AddRange(result.results);
        //        url = result.next;
        //    }
        //    return vehicules;
        //}

        //public List<VehiculeViewModel> GetJsonToSQL()
        //{
        //    List<VehiculeViewModel> vehicules = ConnectionJson();
        //    vehicules.ForEach(
        //        (dbvehicule) =>
        //        {
        //            var vehiculeModel = DatabaseModelParse(dbvehicule);
        //            db.Starship.Add(vehiculeModel);
        //            db.SaveChanges();
        //        }
        //        );
        //    return vehicules;
        //}

        //public VehiculeViewModel ModelParse(Vehicule vehicule)
        //{
        //    VehiculeViewModel vvm = new VehiculeViewModel();
        //    vvm.Id = vehicule.Id;
        //    vvm.Name = vehicule.Name;
        //    vvm.Model = vehicule.Model;
        //    vvm.Manufacturer = vehicule.Manufacturer;
        //    vvm.CostInCredits = vehicule.CostInCredits;
        //    vvm.Length = vehicule.Length;
        //    vvm.MaxAtmospheringSpeed = vehicule.MaxAtmospheringSpeed;
        //    vvm.Crew = vehicule.Crew;
        //    vvm.Passengers = vehicule.Passengers;
        //    vvm.CargoCapacity = vehicule.CargoCapacity;
        //    vvm.VehicleClass = vehicule.VehicleClass;
        //    return vvm;
        //}


        //public Vehicule DatabaseModelParse(VehiculeViewModel vehiculeModel)
        //{
        //    Vehicule vehicule = new Vehicule();
        //    vehicule.Id = vehiculeModel.Id;
        //    vehicule.Name = vehiculeModel.Name;
        //    vehicule.Model = vehiculeModel.Model;
        //    vehicule.Manufacturer = vehiculeModel.Manufacturer;
        //    vehicule.CostInCredits = vehiculeModel.CostInCredits;
        //    vehicule.Length = vehiculeModel.Length;
        //    vehicule.MaxAtmospheringSpeed = vehiculeModel.MaxAtmospheringSpeed;
        //    vehicule.Crew = vehiculeModel.Crew;
        //    vehicule.Passengers = vehiculeModel.Passengers;
        //    vehicule.CargoCapacity = vehiculeModel.CargoCapacity;
        //    vehicule.VehicleClass = vehiculeModel.VehicleClass;
        //    return vehicule;
        //}

        //public List<VehiculeViewModel> Get()
        //{
        //    List<VehiculeViewModel> vehicules;
        //    if (db.Vehicule.Count() > 0)
        //    {
        //        vehicules = new List<VehiculeViewModel>();
        //    }
        //    else
        //    {
        //        vehicules = GetJsonToSQL();
        //    }
        //    var vehicule = db.Vehicule;
        //    List<Vehicule> vehiculesdb = vehicule.ToList();
        //    vehiculesdb.ForEach(
        //        (dbvehicule) =>
        //        {
        //            var stvm = ModelParse(dbvehicule);
        //            vehicules.Add(stvm);
        //        }
        //        );
        //    return vehicules;
        //}

        //public VehiculeViewModel Find(int? id)
        //{
        //    var vehicule = db.Vehicule.Where(t => t.Id == id).FirstOrDefault();
        //    var _vehicule = ModelParse(vehicule);
        //    return _vehicule;
        //}

        //public void CreateNew(VehiculeViewModel vehicule)
        //{
        //    var vehiculeModel = DatabaseModelParse(vehicule);
        //    db.Vehicule.Add(vehiculeModel);
        //    db.SaveChanges();
        //}

        //public void EditNew(VehiculeViewModel vehicule)
        //{
        //    var vehiculeModel = DatabaseModelParse(vehicule);
        //    db.Entry(vehiculeModel).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        //public void DeleteExisting(int id)
        //{
        //    var vehicule = db.Vehicule.Where(t => t.Id == id).FirstOrDefault();
        //    db.Vehicule.Remove(vehicule);
        //    db.SaveChanges();
        //}
    }
}
