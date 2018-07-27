using System.Data.Entity;

namespace StageProject.DataBaseAccess
{
    public interface ISqlDatabaseModel
    {
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Endereco> Endereco { get; set; }
        DbSet<Telefone> Telefone { get; set; }
    }
}