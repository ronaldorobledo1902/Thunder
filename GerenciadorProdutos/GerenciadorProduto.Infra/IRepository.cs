using GerenciadorMaterial.Domain;
using System.Linq.Expressions;

namespace GerenciadorMaterial.Infra
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity );

        Task<TEntity?> GetSingleOrDefaultAsync(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync();

        Task DeleteAsync(TEntity entity);
    }
}
