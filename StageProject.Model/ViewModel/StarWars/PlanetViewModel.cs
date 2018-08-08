using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    public class PlanetViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Período de Rotação")]
        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }

        [Display(Name = "Período Orbital")]
        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }

        [Display(Name = " Diâmetro")]
        [JsonProperty("diameter")]
        public string Diameter { get; set; }

        [Display(Name = "Clima")]
        [JsonProperty("climate")]
        public string Climate { get; set; }

        [Display(Name = "Gravidade")]
        [JsonProperty("gravity")]
        public string Gravity { get; set; }

        [Display(Name = "Terreno")]
        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        [Display(Name = "Superfície com Água")]
        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }

        [Display(Name = "População")]
        [JsonProperty("population")]
        public string Population { get; set; }

        //[Display(Name = "Residentes")]
        //public string Residents { get; set; }

        //[Display(Name = "Filmes")]
        //public string AllFilms { get; set; }

        //public List<FilmViewModel> Films { get; set; }
    }
}
