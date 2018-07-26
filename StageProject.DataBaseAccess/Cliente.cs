namespace StageProject.DataBaseAccess
{
    using StageProject.DataBaseAccess.Enum;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Endereco = new HashSet<Endereco>();
            Telefone = new HashSet<Telefone>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string CodigoCliente { get; set; }
        
        public EnumTipoCliente TipoCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        public int Idade { get; set; }
        
        public EnumEstadoCivil EstadoCivil { get; set; }

        public EnumGenero Genero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Endereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
