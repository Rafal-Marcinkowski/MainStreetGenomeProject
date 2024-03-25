using MainStreetGenomeProject.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;
using Forge.OpenAI;
using Forge.OpenAI.Interfaces.Services;

namespace MainStreetGenomeProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var openAiService = App.ServiceProvider.GetService<IOpenAIService>();
        DataContext = new MainViewModel(openAiService);
    }
}