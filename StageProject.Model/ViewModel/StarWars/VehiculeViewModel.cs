using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    public class VehiculeViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Modelo")]
        [JsonProperty("model")]
        public string Model { get; set; }

        [Display(Name = "Fabricante")]
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Custo em Créditos")]
        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; }

        [Display(Name = "Comprimento")]
        [JsonProperty("length")]
        public string Length { get; set; }

        [Display(Name = "Max Velocidade Atmosférica")]
        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        [Display(Name = "Tripulação")]
        [JsonProperty("crew")]
        public string Crew { get; set; }

        [Display(Name = "Passageiros")]
        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        [Display(Name = "Capacidade de Carga")]
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }

        [Display(Name = "Consumíveis")]
        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        [Display(Name = "Classe de Veículo")]
        [JsonProperty("vehicle_class")]
        public string VehicleClass { get; set; }

        //[Display(Name = "Pilots")]
        //public string Pilot { get; set; }

        //[Display(Name = "Filmes")]
        //public string AllFilms { get; set; }

        //public List<FilmViewModel> Films { get; set; }
    }
}
