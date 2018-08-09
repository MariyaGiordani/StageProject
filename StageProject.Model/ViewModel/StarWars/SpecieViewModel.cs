using Newtonsoft.Json;
using StageProject.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    public class SpecieViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Classificação")]
        [JsonProperty("classification")]
        public string Classification { get; set; }

        [Display(Name = "Designação")]
        [JsonProperty("designation")]
        public string Designation { get; set; }

        [Display(Name = "Altura Média")]
        [JsonProperty("average_height")]
        public string AverageHeight { get; set; }

        [Display(Name = "Core da Pele")]
        [JsonProperty("skin_colors")]
        public string SkinColors { get; set; }

        [Display(Name = "Cor do Cabelo")]
        [JsonProperty("hair_colors")]
        public string HairColors { get; set; }

        [Display(Name = "Cor do Olhos")]
        [JsonProperty("eye_colors")]
        public string EyeColor { get; set; }

        [Display(Name = "Vida Média")]
        [JsonProperty("average_lifespan")]
        public string AverageLifespan { get; set; }

        [Display(Name = "Mundo Natal")]
        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [Display(Name = "language")]
        [JsonProperty("language")]
        public string Language { get; set; }

        //[Display(Name = "Filmes")]
        //public string AllFilms { get; set; }

        //[Display(Name = "Personagens")]
        //public string AllCharacter { get; set; }

        //public List<CharacterViewModel> Characters { get; set; }

        //public List<FilmViewModel> Films { get; set; }
    }
}
