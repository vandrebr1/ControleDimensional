using System.IO;
using Repository.Configuration;
using Repository.Migrations.Service;

namespace UI
{
    public static class DatabaseMigrationInialize
    {

        public static void Run()
        {
            string connectionString = DatabaseConfig.GetConnectionString(true);
            MigrationRunner.RunMigrations(connectionString);
        }
    }
}
