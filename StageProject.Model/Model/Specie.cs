﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.Model
{
    class Specie
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Classificação")]
        public string Classification { get; set; }

        [Display(Name = "Designação")]
        public string Designation { get; set; }

        [Display(Name = "Altura Média")]
        public string AverageHeight { get; set; }

        [Display(Name = "Core de Pele")]
        public string SkinColors { get; set; }

        [Display(Name = "Cor do Cabelo")]
        public string HairColors { get; set; }

        [Display(Name = "Cor do Olhos")]
        public string EyeColor { get; set; }

        [Display(Name = "Vida Média")]
        public string AverageLifespan { get; set; }

        [Display(Name = "Mundo Natal")]
        public string Homeworld { get; set; }

        [Display(Name = "Lingua")]
        public string Language { get; set; }

        //[Display(Name = "Filmes")]
        //public string AllFilms { get; set; }

        //[Display(Name = "Personagens")]
        //public string AllCharacter { get; set; }

        public List<Character> Characters { get; set; }

        public List<Film> Films { get; set; }
    }
}
