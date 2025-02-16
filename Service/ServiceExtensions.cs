using System.Data;
using System.Data.SQLite;
using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;
using Repository.Repositories;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;
using Service.RepositoryService;
using Service.RepositoryService.Base;

namespace Service
{
    public static class ServiceExtensions
    {

        public static void RegisterDI(this IServiceCollection services, bool isProductionDB)
        {
            string connectionString = DatabaseConfig.GetConnectionString(isProductionDB);

            services.AddTransient<IDbConnection>(provider =>
            {
                return new SQLiteConnection(connectionString);
            });

            services.AddRepositories();
            services.AddServices();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<User>, UserRepository>();
            services.AddSingleton<IRepository<Padrao>, PadraoRepository>();
            services.AddSingleton<IRepository<Equipment>, EquipmentRepository>();
            services.AddSingleton<IRepository<EquipmentPadrao>, EquipmentPadraoRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBaseRepoService<User>, UserRepoService>();
            services.AddSingleton<IBaseRepoService<Padrao>, PadraoRepoService>();
            services.AddSingleton<IBaseRepoService<Equipment>, EquipmentRepoService>();
            services.AddSingleton<IBaseRepoService<EquipmentPadrao>, EquipmentPadraoRepoService>();
        }
    }
}
