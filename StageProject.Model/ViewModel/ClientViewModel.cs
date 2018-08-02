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

        [Display(Name = "Código do Cliente")]
        public string CodigoCliente { get; set; }

        [Display(Name = "Tipo do Cliente")]
        public EnumTipoCliente TipoCliente { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Idade")]
        [Range(1, 100)]
        public int Idade { get; set; }

        [Display(Name = "Estado Civil")]
        public EnumEstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Genero")]
        public EnumGenero Genero { get; set; }

        [Display(Name = "Endereços")]
        public int NumeroAddresses { get; set; }

        [Display(Name = "Telefones")]
        public int NumeroTelefones { get; set; }

        public List<TelefoneViewModel> TelefonesViewModels { get; set; }
        public List<AddressViewModel> AddressesViewModels { get; set; }
    }
}
