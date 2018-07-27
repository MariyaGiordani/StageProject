using StageProject.DataBaseAccess;
using StageProject.DataBaseAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    public class EnderecoBusiness
    {
        [Display(Name = "Id")]
        [Range(1, 99999)]
        public int Id { get; set; }

        [Display(Name = "Address Id")]
        public string IDEndereco { get; set; }

        [Display(Name = "Public area")]
        public EnumTipoLogradouro TipoLogradouro { get; set; }

        [Display(Name = "Name")]
        public string NomeLogradouro { get; set; }

        [Display(Name = "Complement")]
        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Neighborhood")]
        public string Bairro { get; set; }

        [Display(Name = "City")]
        public string Cidade { get; set; }

        public virtual ClienteBusiness Cliente { get; set; }

        public EnderecoBusiness enderecoBusiness = new EnderecoBusiness();
        public Endereco address = new Endereco();

        public void ConnectionAddress()
        {
            enderecoBusiness.Id = address.Id;
            enderecoBusiness.IDEndereco = address.IDEndereco;
            enderecoBusiness.TipoLogradouro = address.TipoLogradouro;
            enderecoBusiness.NomeLogradouro = address.NomeLogradouro;
            enderecoBusiness.Complemento = address.Complemento;
            enderecoBusiness.CEP = address.CEP;
            enderecoBusiness.Bairro = address.Bairro;
            enderecoBusiness.Cidade = address.Cidade;
        }
    }
}
