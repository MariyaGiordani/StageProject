namespace StageProject.DataBaseAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlDataBaseModel : DbContext
    {
        public SqlDataBaseModel()
            : base("name=SqlDataBaseModel")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.CodigoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CodigoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.IDEndereco)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.NomeLogradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .IsUnicode(false);
        }
    }
}
