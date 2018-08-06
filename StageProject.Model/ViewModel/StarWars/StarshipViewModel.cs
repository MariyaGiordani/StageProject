using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    class StarshipViewModel
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Fabricante")]
        public string Manufacturer { get; set; }

        [Display(Name = "Custo em Créditos")]
        public string CostInCredits { get; set; }

        [Display(Name = "Comprimento")]
        public string Length { get; set; }

        [Display(Name = "Max Velocidade Atmosférica")]
        public string MaxAtmospheringSpeed { get; set; }

        [Display(Name = "Tripulação")]
        public string Crew { get; set; }

        [Display(Name = "Passageiros")]
        public string Passengers { get; set; }

        [Display(Name = "Capacidade de Carga")]
        public string CargoCapacity { get; set; }

        [Display(Name = "Consumíveis")]
        public string Consumables { get; set; }

        [Display(Name = "Avaliação de Hyperdrive")]
        public string HyperdriveRating { get; set; }

        [Display(Name = "MGLT")]
        public string MGLT { get; set; }

        [Display(Name = "Classe de Nave Estelar")]
        public string StarshipClass { get; set; }

        [Display(Name = "Pilots")]
        public string Pilot { get; set; }

        [Display(Name = "Filmes")]
        public string AllFilms { get; set; }

        public List<FilmViewModel> Films { get; set; }
    }
}
