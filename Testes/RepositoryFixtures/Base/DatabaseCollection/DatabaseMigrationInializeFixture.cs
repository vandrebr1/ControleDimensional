using Repository.Configuration;
using Repository.Migrations.Service;

namespace Testes.RepositoryFixtures.Base.DatabaseCollection
{
    public class DatabaseMigrationInializeFixture
    {
        public DatabaseMigrationInializeFixture()
        {
            string connectionString = DatabaseConfig.GetConnectionString(false);

            SQLitePCL.Batteries.Init();
            MigrationRunner.RunMigrations(connectionString);
        }
    }
}
