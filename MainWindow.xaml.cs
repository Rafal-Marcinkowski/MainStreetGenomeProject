using HtmlAgilityPack;
using MainStreetGenomeProject.MVVM.ViewModels;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        string htmltext = await Library.DownloadDataFromForum.DownloadMainPage.DownloadHtmlAsync(1);
        File.WriteAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\GlownaStronaHtml", htmltext);
        await Library.DownloadDataFromForum.DownloadMainPage.GetRelevantNodes(htmltext);
    }

}