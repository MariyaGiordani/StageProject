using StageProject.DataBaseAccess;
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
    public class CharacterBusiness : ICharacterBusiness
    {
        private SqlDatabaseModel db;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_color { get; set; }
        public string Skin_color { get; set; }
        public string Eye_color { get; set; }
        public string Birth_year { get; set; }
        public string Genero { get; set; }
        public string Homeworld { get; set; }
        public string AllFilms { get; set; }
        public string TypeSpecies { get; set; }
        public string AllVehicles { get; set; }
        public string AllStarships { get; set; }

        //public List<Film> Films { get; set; }
        //public List<Specie> Species { get; set; }
        //public List<Vehicule> Vehicules { get; set; }
        //public List<Starship> Starships { get; set; }

        public CharacterBusiness (SqlDatabaseModel _dbinstance)
        {
            db = _dbinstance;
        }

        public CharacterViewModel ModelParse(Character character)
        {
            CharacterViewModel cvm = new CharacterViewModel();
            cvm.Id = character.Id;
            cvm.Name = character.Name;
            cvm.Height = character.Height;
            cvm.Mass = character.Mass;
            cvm.Hair_color = character.Hair_color;
            cvm.Skin_color = character.Skin_color;
            cvm.Birth_year= character.Birth_year;
            cvm.Genero = character.Genero;
            cvm.Homeworld = character.Homeworld;
            cvm.AllFilms = character.AllFilms;
            cvm.TypeSpecies = character.TypeSpecies;
            cvm.AllVehicles = character.AllVehicles;
            cvm.AllStarships = character.AllStarships;
            return cvm;
        }

       
        public Character DatabaseModelParse(CharacterViewModel characterModel)
        {
            Character character = new Character();
            character.Id = characterModel.Id;
            character.Name = characterModel.Name;
            character.Height = characterModel.Height;
            character.Mass = characterModel.Mass;
            character.Hair_color = characterModel.Hair_color;
            character.Skin_color = characterModel.Skin_color;
            character.Birth_year = characterModel.Birth_year;
            character.Genero = characterModel.Genero;
            character.Homeworld = characterModel.Homeworld;
            character.AllFilms = characterModel.AllFilms;
            character.TypeSpecies = characterModel.TypeSpecies;
            character.AllVehicles = characterModel.AllVehicles;
            character.AllStarships = characterModel.AllStarships;
            return character;
        }

        public List<CharacterViewModel> Get()
        {
            var character = db.Character;
            List<Character> charactersdb = character.ToList();
            List<CharacterViewModel> characters = new List<CharacterViewModel>();
            charactersdb.ForEach(
                (dbcharacter) =>
                {
                    var cvm = ModelParse(dbcharacter);
                    characters.Add(cvm);
                }
                );
            return characters;
        }

        public CharacterViewModel Find(int? id)
        {
            var character = db.Character.Where(t => t.Id == id).FirstOrDefault();
            var _character = ModelParse(character);
            return _character;
        }

        public void CreateNew(CharacterViewModel character)
        {
            var characterModel = DatabaseModelParse(character);
            db.Character.Add(characterModel);
            db.SaveChanges();
        }

        public void EditNew(CharacterViewModel character)
        {
            var characterModel = DatabaseModelParse(character);
            db.Entry(characterModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExisting(int id)
        {
            var character = db.Character.Where(t => t.Id == id).FirstOrDefault();
            db.Character.Remove(character);
            db.SaveChanges();
        }
    }
}
