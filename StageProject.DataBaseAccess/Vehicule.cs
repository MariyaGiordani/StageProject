using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.Model
{
    [Table("Vehicule")]
    public class Vehicule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string VehicleClass { get; set; }

        //[Display(Name = "Pilots")]
        //public string Pilot { get; set; }

        //[Display(Name = "Filmes")]
        //public string AllFilms { get; set; }

        //public List<Film> Films { get; set; }
    }
}
