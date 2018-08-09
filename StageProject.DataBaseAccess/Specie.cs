using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.DataBaseAccess
{
    [Table("Specie")]
    public class Specie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColor { get; set; }
        public string AverageLifespan { get; set; }
        public string Homeworld { get; set; }
        public string Language { get; set; }


        //[Display(Name = "Filmes")]
        //public string AllFilms { get; set; }

        //[Display(Name = "Personagens")]
        //public string AllCharacter { get; set; }

        //public List<Character> Characters { get; set; }

        //public List<Film> Films { get; set; }
    }
}
