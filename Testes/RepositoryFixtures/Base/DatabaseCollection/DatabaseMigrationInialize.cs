using Repository.Configuration;
using Repository.Migrations.Service;

namespace Testes.RepositoryFixtures.Base.DatabaseCollection
{
    public class DatabaseMigrationInialize : IDisposable
    {
        private readonly string _databasePath;

        public DatabaseMigrationInialize()
        {
            string connectionString = DatabaseConfig.GetConnectionString(false);
            _databasePath = GetDatabasePathFromConnectionString(connectionString);

            MigrationRunner.RunMigrations(connectionString);
        }

        public void Dispose()
        {
            // Limpa o banco de dados SQLite excluindo o arquivo
            if (File.Exists(_databasePath))
            {
                File.Delete(_databasePath);
                Console.WriteLine("Database deleted");
            }
        }

        private string GetDatabasePathFromConnectionString(string connectionString)
        {
            // Extrai o caminho do arquivo do SQLite da connection string
            // Exemplo de connection string: "Data Source=test.db"
            var parts = connectionString.Split(';');
            foreach (var part in parts)
            {
                if (part.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
                {
                    return part.Substring("Data Source=".Length);
                }
            }
            throw new InvalidOperationException("Database file not found in connection string.");
        }
    }
}
