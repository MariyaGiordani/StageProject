using StageProject.DataBaseAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.DataBaseAccess
{
    [Table("Film")]
    public class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }


        //public List<Character> Characters { get; set; }
        //public List<Planet> Planets { get; set; }
        //public List<Starship> Starships { get; set; }
        //public List<Specie> Species { get; set; }
        //public List<Vehicule> Vehicules { get; set; }
    }
}
