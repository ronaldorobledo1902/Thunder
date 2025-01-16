using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using GerenciadorMaterial.Domain;
using Dapper.Contrib.Extensions;

namespace GerenciadorMaterial.Infra.Repositorio
{
    public class DapperSqlServerRepository<TContext, TEntity> : IRepository<TEntity> where TContext : DbContext where TEntity : class, IEntity
    {
        protected readonly TContext Context;

        public DapperSqlServerRepository(TContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            using IDbConnection connection = await GetConnectionAsync();
            await connection.InsertAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            using IDbConnection connection = await GetConnectionAsync();
            await connection.InsertAsync(entities);
        }

        public async Task UpdateAsync(TEntity entity )
        {
            using IDbConnection connection = await GetConnectionAsync();
            await connection.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using IDbConnection connection = await GetConnectionAsync();
            await connection.DeleteAsync(entity);
        }

        public async Task<TEntity?> GetSingleOrDefaultAsync(TEntity entity)
        {
            using IDbConnection connection = await GetConnectionAsync();
            return (await connection.GetAsync<TEntity>(entity.Id));
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate )
        {
            throw new NotSupportedException("AnyAsync not supported in Dapper");
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using IDbConnection connection = await GetConnectionAsync();
            return (await connection.GetAllAsync<TEntity>()).ToList();
        }

        public async Task<IDbConnection> GetConnectionAsync()
        {
            DbConnection connection = Context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            return connection;
        }
    }
}
