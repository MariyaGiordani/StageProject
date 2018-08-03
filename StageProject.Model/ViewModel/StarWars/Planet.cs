using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel.StarWars
{
    class PlanetViewModel
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Período de Rotação")]
        public string RotationPeriod { get; set; }

        [Display(Name = "Período Orbital")]
        public string OrbitalPeriod { get; set; }

        [Display(Name = " Diâmetro")]
        public string Diameter { get; set; }

        [Display(Name = "Clima")]
        public string Climate { get; set; }

        [Display(Name = "Gravidade")]
        public string Gravity { get; set; }

        [Display(Name = "Terreno")]
        public string Terrain { get; set; }

        [Display(Name = "Superfície com Água")]
        public string SurfaceWater { get; set; }

        [Display(Name = "População")]
        public string Population { get; set; }

        [Display(Name = "Residentes")]
        public string Residents { get; set; }

        [Display(Name = "Filmes")]
        public string AllFilms { get; set; }

        public List<FilmViewModel> Films { get; set; }
    }
}
