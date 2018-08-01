using StageProject.Model.Enumeradores;
using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel
{
    /// <summary>
    /// Classe de bind para a view cshtml
    /// </summary>
    public class ClientViewModel 
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Client Code")]
        public string CodigoCliente { get; set; }

        [Display(Name = "Type of client")]
        public EnumTipoCliente TipoCliente { get; set; }

        [Display(Name = "Name")]
        public string Nome { get; set; }

        [Display(Name = "Age")]
        [Range(1, 100)]
        public int Idade { get; set; }

        [Display(Name = "Marital Status")]
        public EnumEstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Gender")]
        public EnumGenero Genero { get; set; }

        [Display(Name = "Addresses")]
        public int NumeroAddresses { get; set; }

        [Display(Name = "Telephones")]
        public int NumeroTelefones { get; set; }

        public List<TelefoneViewModel> TelefoneViewModels { get; set; }
    }
}
