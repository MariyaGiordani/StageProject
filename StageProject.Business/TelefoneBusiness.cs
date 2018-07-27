using StageProject.DataBaseAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business
{
    public class TelefoneBusiness
    {
        [Display(Name = "Id")]
        [Range(1, 99999)]
        public int Id { get; set; }

        [Display(Name = "Telefone type")]
        public EnumTipoTelefone TipoTelefone { get; set; }

        [Display(Name = "Number")]
        public string Numero { get; set; }

        [Display(Name = "Client Id")]
        public int IdCliente { get; set; }
        public virtual ClienteBusiness Cliente { get; set; }

        

        public void ConnectionTelefone()
        {
            telefoneBusiness.IdCliente = telefone.IdCliente;
            telefoneBusiness.TipoTelefone = telefone.TipoTelefone;
            telefoneBusiness.Numero = telefone.Numero;
        }
    }
}
