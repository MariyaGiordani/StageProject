namespace StageProject.DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefone")]
    public partial class Telefone
    {
        public int Id { get; set; }

        public int TipoTelefone { get; set; }

        [Required]
        [StringLength(50)]
        public string Numero { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
