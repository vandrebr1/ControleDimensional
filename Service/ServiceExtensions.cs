using System.Data;
using Common.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Repository.Configuration;
using Repository.Migrations.Service;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.RepositoryService;
using Service.RepositoryService.Base;

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
            services.AddSingleton<IEquipmentRepository, EquipmentRepository>();
            services.AddSingleton<IEquipmentPadraoRepository, EquipmentPadraoRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBaseRepoService<User>, UserRepoService>();
            services.AddSingleton<IBaseRepoService<Padrao>, PadraoRepoService>();
            services.AddSingleton<IBaseRepoService<Equipment>, EquipmentRepoService>();
            services.AddSingleton<IBaseRepoService<EquipmentPadrao>, EquipmentPadraoRepoService>();

            //REMOVE 
            //services.AddSingleton<UserRepoService>();
            //services.AddSingleton<PadraoRepoService>();
            //services.AddSingleton<EquipmentRepoService>();
        }
    }
}
