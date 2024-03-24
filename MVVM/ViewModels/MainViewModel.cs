using GalaSoft.MvvmLight.Command;
using Library.GetDataFromHtml;
using System.Windows.Input;
using System.IO;
using HtmlAgilityPack;
using DataAccess.Data;
using DataAccess.DBAccess;
using GalaSoft.MvvmLight;
using System.Windows;

namespace MainStreetGenomeProject.MVVM.ViewModels;
public class MainViewModel : ObservableObject
{
    private readonly ICompanyData companyData = new CompanyData(new SQLDataAccess(App.Configuration));
    private readonly IThreadData threadData = new ThreadData(new SQLDataAccess(App.Configuration));
    private readonly ICommentData commentData = new CommentData(new SQLDataAccess(App.Configuration));
    public ICommand StartCommand =>
        new RelayCommand(async () =>
        {
            while (true)
            {
                string htmltext = await DownloadPageSource.DownloadHtmlAsync(2);
                File.WriteAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\GlownaStronaHtml", htmltext);
                HtmlNodeCollection htmlNodes = await GetRelevantNodes.GetMainPageNodes(htmltext);
                await new ProcessHtmlNodes(companyData, threadData, commentData).Start(htmlNodes);
                await Task.Delay(15000);
            }
            //var threads = await threadData.GetAllThreadsAsync();
            //MessageBox.Show(threads.DistinctBy(q => q.Hyperlink).Count().ToString());
            //var comments = await commentData.GetAllCommentsAsync();
            //MessageBox.Show($"distinct comments: {comments.DistinctBy(q => q.CommentText, StringComparer.OrdinalIgnoreCase).Count().ToString()}");
        });
}

