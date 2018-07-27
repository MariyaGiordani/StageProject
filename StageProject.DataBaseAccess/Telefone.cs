namespace StageProject.DataBaseAccess
{
    using StageProject.Model.Enumeradores;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefone")]
    public partial class Telefone
    {
        /// <summary>
        /// identificador unico do telefone
        /// </summary>
        public int Id { get; set; }

        public EnumTipoTelefone TipoTelefone { get; set; }

        [Required]
        [StringLength(50)]
        public string Numero { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
