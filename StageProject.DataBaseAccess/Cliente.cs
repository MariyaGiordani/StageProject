namespace StageProject.DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string CodigoCliente { get; set; }

        public int TipoCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int EstadoCivil { get; set; }

        public int Genero { get; set; }
    }
}
