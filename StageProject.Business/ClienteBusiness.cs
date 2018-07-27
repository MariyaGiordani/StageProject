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
    public class ClienteBusiness
    {
        [Display(Name = "Id")]
        [Range(1, 99999)]
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

        public Cliente client = new Cliente();
        public ClienteBusiness clienteBusiness = new ClienteBusiness();
        public void ConnectionClient()
        {
            clienteBusiness.Id = client.Id;
            clienteBusiness.TipoCliente = client.TipoCliente;
            clienteBusiness.CodigoCliente = client.CodigoCliente;
            clienteBusiness.Nome = client.Nome;
            clienteBusiness.Idade = client.Idade;
            clienteBusiness.EstadoCivil = client.EstadoCivil;
            clienteBusiness.Genero = client.Genero;
        }
    }
}
