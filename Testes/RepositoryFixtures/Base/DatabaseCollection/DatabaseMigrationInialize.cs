using Repository.Configuration;
using Repository.Migrations.Service;

namespace Testes.RepositoryFixtures.Base.DatabaseCollection
{
    public class DatabaseMigrationInialize
    {
        public DatabaseMigrationInialize()
        {
            string connectionString = DatabaseConfig.GetConnectionString(false);

            SQLitePCL.Batteries.Init();
            MigrationRunner.RunMigrations(connectionString);
        }
    }
}
