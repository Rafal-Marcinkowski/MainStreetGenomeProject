using GalaSoft.MvvmLight.Command;
using Library.GetDataFromHtml;
using System.Windows.Input;
using System.IO;
using HtmlAgilityPack;
using DataAccess.Data;
using GalaSoft.MvvmLight;
using Forge.OpenAI.Interfaces.Services;
using ValidationComponent.DataMaintenance;
using System.Windows.Controls;

namespace MainStreetGenomeProject.MVVM.ViewModels;
public class MainViewModel : ObservableObject
{
    private readonly IOpenAIService openAI;
    private readonly ICompanyData companyData;
    private readonly IThreadData threadData;
    private readonly ICommentData commentData;
    public MainViewModel(IOpenAIService openAI, ICompanyData companyData, IThreadData threadData, ICommentData commentData)
    {
        this.openAI = openAI;
        this.companyData = companyData;
        this.threadData = threadData;
        this.commentData = commentData;
    }

    private UserControl currentControl;
    public UserControl CurrentControl
    {
        get => currentControl; 
        set
        {
            if (currentControl != value)
            {
                currentControl = value;
                RaisePropertyChanged();
            }
        }
    }

    public ICommand StartCommand =>
        new RelayCommand(async () =>
        {
            await new ClearDatabase(companyData, threadData, commentData).DeleteObsoleteThreadsAndComments();
            while (true)
            {
                string htmltext = await DownloadPageSource.DownloadHtmlAsync(1);
                File.WriteAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\GlownaStronaHtml", htmltext);
                HtmlNodeCollection htmlNodes = await GetRelevantNodes.GetMainPageNodes(htmltext);
                await new ProcessHtmlNodes(companyData, threadData, commentData).Start(htmlNodes);
                await Task.Delay(15000);
            }
        });
}

//private async Task GetMostRetardedInvestor()
//{
//    var comments = await commentData.GetAllCommentsAsync();
//    var groups = comments.GroupBy(x => x.IPAddress).OrderByDescending(q => q.Count());
//    MessageBox.Show(groups.First().Key);
//}

//private async Task DeleteInvalidThreadsAndComments()
//{
//    var threads = await threadData.GetAllThreadsAsync();
//    var errorThreads = threads.Where(q => q.IPAddress == "1.1.1.1");
//    foreach (var thread in errorThreads)
//    {
//        var comments = await commentData.GetAllCommentsForThreadAsync(thread.ID);
//        if (comments != null)
//        {
//            foreach (var comment in comments)
//            {
//                await commentData.DeleteCommentAsync(comment.ID);
//            }
//        }
//        await threadData.DeleteThreadAsync(thread.ID);
//    }
//}

//private async void ilekomentarzyzdzisiajiwatkow()
//{
//    var threads = await threadData.GetAllThreadsAsync();
//    threads = threads.Where(q => q.DateTime == DateTime.Today);
//    var comments = await commentData.GetAllCommentsAsync();
//    comments = comments.Where(q => q.DateTime == DateTime.Today);
//    MessageBox.Show($"Threads from today: {threads.Count()}, comments from today: {comments.Count()}");
//}

//private async void Ile()
//{
//    var threads = await threadData.GetAllThreadsAsync();
//    MessageBox.Show(threads.Max(q => q.Author.Length).ToString());
//}

//private async void k()
//{
//    var companies = await companyData.GetAllCompaniesAsync();
//    MessageBox.Show($"distinct companies: {companies.DistinctBy(q => q.CompanyName).Count().ToString()}");
//    var threads = await threadData.GetAllThreadsAsync();
//    MessageBox.Show($"distinct threads: {threads.DistinctBy(q => q.ThreadName).Count().ToString()}");
//    var comments = await commentData.GetAllCommentsAsync();
//    MessageBox.Show($"distinct comments: {comments.DistinctBy(q => q.CommentText, StringComparer.OrdinalIgnoreCase).Count().ToString()}");
//}