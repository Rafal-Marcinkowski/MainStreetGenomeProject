using System.Windows;
using MainStreetGenomeProject.MVVM;

namespace MainStreetGenomeProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ViewModelManager viewModelManager = new(App.ServiceProvider);
        DataContext = viewModelManager.MainViewModelInstance;
    }
}