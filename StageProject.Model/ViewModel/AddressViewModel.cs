using StageProject.StageProject.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model.ViewModel
{
    public class AddressViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ID do Endereço")]
        public string IDEndereco { get; set; }

        [Display(Name = "Tipo do Logradouro")]
        public EnumTipoLogradouro TipoLogradouro { get; set; }

        [Display(Name = "Nome do Logradouro")]
        public string NomeLogradouro { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "ID do Cliente")]
        public int? Cliente_Id { get; set; }
    }
}
