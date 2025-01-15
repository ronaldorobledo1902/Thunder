using GerenciadorMaterial.Domain;
using GerenciadorMaterial.Infra.Contexto;
using GerenciadorMaterial.Infra.Repositorio.Interface;

namespace GerenciadorMaterial.Infra.Repositorio
{
    public class MaterialRepositorio : DapperSqlServerRepository<SqlServerContext, Material>, IMaterialRepositorio
    {
        public MaterialRepositorio(SqlServerContext context) : base(context)
        {
        }
    }
}
