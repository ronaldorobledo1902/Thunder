using GerenciadorMaterial.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorMaterial.Infra.Contexto
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            
            this.Database.EnsureCreated();
        }

        public DbSet<Material> Materials { get; set; }
    }
}
