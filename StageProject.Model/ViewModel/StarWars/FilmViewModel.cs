using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    class FilmViewModel
    {
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Display(Name = "Id do Episódio")]
        public string EpisodeId { get; set; }

        [Display(Name = "Abrindo o Rastreamento")]
        public string OpeningCrawl { get; set; }

        [Display(Name = "Diretor")]
        public string Director { get; set; }

        [Display(Name = "Produtor")]
        public string Producer { get; set; }

        [Display(Name = "Data de Lançamento ")]
        public string ReleaseDate { get; set; }

        [Display(Name = "Personagens")]
        public string AllCharacter { get; set; }

        [Display(Name = "Planetas")]
        public string Homeworld { get; set; }

        [Display(Name = "Naves Estelares")]
        public string AllStarships { get; set; }

        [Display(Name = "Veículos")]
        public string AllVehicles { get; set; }

        [Display(Name = "Espécie")]
        public string TypeSpecies { get; set; }

        public List<CharacterViewModel> Characters { get; set; }
        public List<PlanetViewModel> Planets { get; set; }
        public List<StarshipViewModel> Starships { get; set; }
        public List<SpecieViewModel> Species { get; set; }
        public List<VehiculeViewModel> Vehicules { get; set; }
    }
}
