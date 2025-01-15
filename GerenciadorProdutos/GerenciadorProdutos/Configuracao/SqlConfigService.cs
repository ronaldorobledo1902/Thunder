using GerenciadorMaterial.Api.Service;
using GerenciadorMaterial.Infra.Contexto;
using GerenciadorMaterial.Infra.Repositorio;
using GerenciadorMaterial.Infra.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace GerenciadorMaterial.Api.Configuracao
{
    public static class SqlConfigService
    {
        public static IServiceCollection AddSqlServerContext<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
        {
            //SqlServerSettings settings = configuration.GetSection(SqlServerSettings.SessionName).Get<SqlServerSettings>();
            //ArgumentNullException.ThrowIfNull(settings, "settings");
            //return services.AddEntityFrameworkSqlServer().AddDbContextPool<TContext>(delegate (IServiceProvider serviceProvider, DbContextOptionsBuilder optionsBuilder)
            //{
            //    optionsBuilder.UseSqlServer(settings.ConnectionString, SetSqlServerOptions<TContext>(settings));
            //    optionsBuilder.UseInternalServiceProvider(serviceProvider);
            //}, settings.MaxPoolSize).AddSingleton(settings);
            return services.AddDbContext<SqlServerContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        }

        private static Action<SqlServerDbContextOptionsBuilder> SetSqlServerOptions<TContext>(SqlServerSettings settings) where TContext : DbContext
        {
            SqlServerSettings settings2 = settings;
            TimeSpan maxRetryDelayInSeconds = TimeSpan.FromSeconds(settings2.Retry.MaxRetryDelayInSeconds);
            return delegate (SqlServerDbContextOptionsBuilder sql)
            {
                if (settings2.Retry.Enabled)
                {
                    sql.EnableRetryOnFailure(settings2.Retry.MaxCount, maxRetryDelayInSeconds, settings2.Retry.ErrorNumbersToAdd);
                }

                if (settings2.Timeout.Enabled)
                {
                    sql.CommandTimeout(settings2.Timeout.ValueInSeconds);
                }

                if (settings2.MaxBatchSize > 0)
                {
                    sql.MaxBatchSize(settings2.MaxBatchSize);
                }

                sql.UseCompatibilityLevel(settings2.CompatibilityLevel);
                sql.MigrationsAssembly(typeof(TContext).Namespace);
            };
        }


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IMaterialRepositorio, MaterialRepositorio>();
            return services;
        }
    }
}
