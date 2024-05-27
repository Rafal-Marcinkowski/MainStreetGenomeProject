using MainStreetGenomeProject.MVVM;
using System.Windows;

namespace MainStreetGenomeProject;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ViewModelManager viewModelManager = new(App.ServiceProvider);
        DataContext = viewModelManager.MainViewModelInstance;
    }
}