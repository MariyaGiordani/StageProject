using StageProject.StageProject.Model.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace StageProject.Model.ViewModel
{
    /// <summary>
    /// Classe de bind para a view cshtml
    /// </summary>
    public class TelefoneViewModel
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
        //public virtual ClienteBusiness Cliente { get; set; }
    }
}
