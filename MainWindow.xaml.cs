using MainStreetGenomeProject.MVVM.ViewModels;
using System.IO;
using System.Windows;

namespace MainStreetGenomeProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainViewModel viewModel = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}