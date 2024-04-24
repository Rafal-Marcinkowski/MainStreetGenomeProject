using DataAccess.Data;
using DataAccess.DBAccess;
using Forge.OpenAI;
using MainStreetGenomeProject.MVVM;
using MainStreetGenomeProject.MVVM.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using ValidationComponent.DataMaintenance;

namespace MainStreetGenomeProject;

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
        services.AddSingleton(provider => Configuration);
        services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
        services.AddSingleton<ICompanyData, CompanyData>();
        services.AddSingleton<IThreadData, ThreadData>();
        services.AddSingleton<ICommentData, CommentData>();
        services.AddSingleton<ViewModelManager>();
    }
}
