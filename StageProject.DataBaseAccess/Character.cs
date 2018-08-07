using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.DataBaseAccess
{
    [Table("Character")]
    public class Character
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Character()
        //{

        //}

        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        
        public string Height { get; set; }

        
        public string Mass { get; set; }

        
        public string Hair_color { get; set; }

        
        public string Skin_color { get; set; }

       
        public string Eye_color { get; set; }
        
        
        public string Birth_year { get; set; }

        
        public string Gender { get; set; }

       
        public string Homeworld { get; set; }


        //public List<Film> Films { get; set; }
        //public List<Specie> Species { get; set; }
        //public List<Vehicule> Vehicules { get; set; }
        //public List<Starship> Starships { get; set; }
    }
}
