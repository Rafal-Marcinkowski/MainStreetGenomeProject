using Forge.OpenAI;
using Forge.OpenAI.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace MainStreetGenomeProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Configuration = new ConfigurationBuilder()
                .SetBasePath("D:\\Visual Studio 2022\\Visual Studio Projects\\Visual Studio Projects\\MainStreetGenomeProject")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddForgeOpenAI(options =>
            {
                options.AuthenticationInfo = Configuration["ApiKey"]!;
            });
        }
    }
}
