using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Service;
using UI.Usuario;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            DatabaseMigrationInialize.Run();

            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDI(isProductionDB: true);

            RegisterViews(services);

            services.AddSingleton<MainWindow>();
        }

        private void RegisterViews(IServiceCollection services)
        {
            services.AddTransient<UserViewModel>();
            services.AddTransient<UserControlUsuario>();
        }
    }
}