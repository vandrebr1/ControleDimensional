using Microsoft.Extensions.Configuration;

namespace Repository.Configuration
{
    public static class DatabaseConfig
    {
        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        public static string GetConnectionString(bool isProductionDB)
        {
            if (isProductionDB)
                return GetConfiguration().GetConnectionString("ControleDimensionalDb");
            else
                return GetConfiguration().GetConnectionString("ControleDimensionalDbFixture");

        }
    }
}
