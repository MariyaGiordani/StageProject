using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    public class CharacterViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Altura")]
        public string Height { get; set; }

        [Display(Name = "Massa")]
        public string Mass { get; set; }

        [Display(Name = "Cor do Cabelo")]
        public string Hair_color { get; set; }

        [Display(Name = "Cor do Pele")]
        public string Skin_color { get; set; }

        [Display(Name = "Cor do Olhos")]
        public string Eye_color { get; set; }
        
        [Display(Name = "Data de nascimento")]
        public string Birth_year { get; set; }

        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Display(Name = "Mundo Natal")]
        public string Homeworld { get; set; }

        [Display(Name = "Filmes")]
        public string AllFilms { get; set; }

        [Display(Name = "Espécie")]
        public string TypeSpecies { get; set; }

        [Display(Name = "Veículos")]
        public string AllVehicles { get; set; }

        [Display(Name = "Naves Estelares")]
        public string AllStarships { get; set; }

        //public List<FilmViewModel> Films { get; set; }
        //public List<SpecieViewModel> Species { get; set; }
        //public List<VehiculeViewModel> Vehicules { get; set; }
        //public List<StarshipViewModel> Starships { get; set; }
    }
}
