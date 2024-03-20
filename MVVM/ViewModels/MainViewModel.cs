using GalaSoft.MvvmLight.Command;
using Library.GetDataFromHtml;
using System.Windows.Input;
using System.IO;
using DataAccess.Models;
using HtmlAgilityPack;
using DataAccess.Data;
using ValidationComponent.CompanyValidation;
using ValidationComponent.ThreadValidation;
using DataAccess.DBAccess;
using System.Windows;

namespace MainStreetGenomeProject.MVVM.ViewModels;
public class MainViewModel : BaseViewModel
{
    private readonly ICompanyData companyData = new CompanyData(new SQLDataAccess(App.Configuration));
    private readonly IThreadData threadData = new ThreadData(new SQLDataAccess(App.Configuration));
    private readonly ICommentData commentData = new CommentData(new SQLDataAccess(App.Configuration));
    public ICommand StartCommand =>
        new RelayCommand(async () =>
        {
            while (true)
            {
                string htmltext = await DownloadPageSource.DownloadHtmlAsync(1);
                File.WriteAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\GlownaStronaHtml", htmltext);
                HtmlNodeCollection htmlNodes = await GetRelevantNodes.GetMainPageNodes(htmltext);
                await new ProcessHtmlNodes(companyData, threadData, commentData).Start(htmlNodes);
                await Task.Delay(10000);
            }
            //var comments = await commentData.GetAllCommentsAsync();
            //MessageBox.Show($"distinct comments: {comments.DistinctBy(q => q.CommentText).Count().ToString()}");
            //var threads = await threadData.GetAllThreadsAsync();
            //MessageBox.Show(threads.DistinctBy(q => q.ThreadName).Count().ToString());
        });
}
