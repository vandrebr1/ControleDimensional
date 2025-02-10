using System.Data;
using Common.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;
using Repository.Migrations.Service;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.RepositoryService;
using Service.RepositoryService.Interfaces;

namespace Service
{
    public static class ServiceExtensions
    {

        public static void AddRepositories(this IServiceCollection services, bool isProductionDB)
        {
            string connectionString = DatabaseConfig.GetConnectionString(isProductionDB);

            services.AddTransient<IDbConnection>(provider =>
            {
                return new SqliteConnection(connectionString);
            });

            services.AddSingleton<IPadraoRepository, PadraoRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<IBaseRepositoryService<User>, UserRepoService>();
            services.AddSingleton<IBaseRepositoryService<Padrao>, PadraoRepoService>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<UserRepoService>();
            services.AddSingleton<PadraoRepoService>();
        }

        private static void RunMigrations(string _connectionString)
        {
            SQLitePCL.Batteries.Init();
            MigrationRunner.RunMigrations(_connectionString);
        }
    }
}
