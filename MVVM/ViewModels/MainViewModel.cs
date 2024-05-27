using DataAccess.Data;
using Forge.OpenAI.Interfaces.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HtmlAgilityPack;
using Library.GetDataFromHtml;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using ValidationComponent.DataMaintenance;

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

//private async Task GetMostActiveInvestor()
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