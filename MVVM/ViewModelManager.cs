using DataAccess.Data;
using Forge.OpenAI.Interfaces.Services;
using MainStreetGenomeProject.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MainStreetGenomeProject.MVVM;
internal class ViewModelManager
{
    private readonly IServiceProvider serviceProvider;

    public ViewModelManager(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        MainViewModelInstance = new(serviceProvider.GetService<IOpenAIService>(),
        serviceProvider.GetService<ICompanyData>(),
        serviceProvider.GetService<IThreadData>(),
        serviceProvider.GetService<ICommentData>());
    }

    public MainViewModel MainViewModelInstance;
}
