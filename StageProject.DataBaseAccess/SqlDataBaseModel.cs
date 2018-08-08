namespace StageProject.DataBaseAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlDatabaseModel : DbContext, ISqlDatabaseModel
    {
        public SqlDatabaseModel()
            : base("name=SqlDatabaseModel")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.CodigoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Endereco)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Telefone)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Telefone>()
                .Property(e => e.Numero)
                .IsUnicode(false);
        }

        //public System.Data.Entity.DbSet<StageProject.DataBaseAccess.Film> Films { get; set; }

        //public System.Data.Entity.DbSet<StageProject.DataBaseAccess.Character> Characters { get; set; }
    }
}
