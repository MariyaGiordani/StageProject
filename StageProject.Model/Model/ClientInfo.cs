using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.Model
{
    class ClientInfo
    {
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

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birth_year { get; set; }
    }
}
