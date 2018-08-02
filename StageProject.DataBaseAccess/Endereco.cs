namespace StageProject.DataBaseAccess
{
    using StageProject.Model.Enumeradores;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Endereco")]
    public partial class Endereco 
    {
        public int Id { get; set; }

        public int? Cliente_Id { get; set; }

        [Required]
        [StringLength(500)]
        public string IDEndereco { get; set; }
        
        public StageProject.Model.Enumeradores.EnumTipoLogradouro TipoLogradouro { get; set; }

        [Required]
        public string NomeLogradouro { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
