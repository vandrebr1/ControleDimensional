using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Migrations.Service
{
    public static class MigrationRunner
    {
        public static void RunMigrations(string connectionString)
        {
            var serviceProvider = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSQLite()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(CreateUsuarioTableMigration).Assembly).For.Migrations()
                    .ScanIn(typeof(CreatePadraoTableMigration).Assembly).For.Migrations()
                    )
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }
    }
}
