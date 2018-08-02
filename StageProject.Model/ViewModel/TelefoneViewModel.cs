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
        public int Id { get; set; }

        [Display(Name = "Tipo de Telefone")]
        public EnumTipoTelefone TipoTelefone { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "ID do Cliente")]
        public int IdCliente { get; set; }
    }
}
