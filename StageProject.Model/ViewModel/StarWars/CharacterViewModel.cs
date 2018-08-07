using Newtonsoft.Json;
using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    public class CharacterViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Altura")]
        [JsonProperty("height")]
        public string Height { get; set; }

        [Display(Name = "Massa")]
        [JsonProperty("mass")]
        public string Mass { get; set; }

        [Display(Name = "Cor do Cabelo")]
        [JsonProperty("hair_color")]
        public string Hair_color { get; set; }

        [Display(Name = "Cor do Pele")]
        [JsonProperty("skin_color")]
        public string Skin_color { get; set; }

        [Display(Name = "Cor do Olhos")]
        [JsonProperty("eye_color")]
        public string Eye_color { get; set; }
        
        [Display(Name = "Data de nascimento")]
        [JsonProperty("birth_year")]
        public string Birth_year { get; set; }

        [Display(Name = "Genero")]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Display(Name = "Mundo Natal")]
        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }
        

        //public List<FilmViewModel> Films { get; set; }
        //public List<SpecieViewModel> Species { get; set; }
        //public List<VehiculeViewModel> Vehicules { get; set; }
        //public List<StarshipViewModel> Starships { get; set; }
    }
}
