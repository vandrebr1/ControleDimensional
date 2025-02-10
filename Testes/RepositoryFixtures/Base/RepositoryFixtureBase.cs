using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Service;


namespace Testes.RepositoryFixtures.Base
{
    public abstract class RepositoryFixtureBase : IDisposable
    {
        protected readonly ServiceProvider _serviceProvider;
        protected readonly IDbConnection _connection;

        public RepositoryFixtureBase()
        {
            var services = new ServiceCollection();

            services.AddRepositories(false);

            RegisterRepositories(services);

            _serviceProvider = services.BuildServiceProvider();
            _connection = _serviceProvider.GetRequiredService<IDbConnection>();
        }

        protected abstract void RegisterRepositories(IServiceCollection services);

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _serviceProvider.Dispose();
        }
    }
}
