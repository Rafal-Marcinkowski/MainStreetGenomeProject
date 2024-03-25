using GalaSoft.MvvmLight.Command;
using Library.GetDataFromHtml;
using Library.OpenAI;
using System.Windows.Input;
using System.IO;
using HtmlAgilityPack;
using DataAccess.Data;
using DataAccess.DBAccess;
using GalaSoft.MvvmLight;
using System.Windows;
using Forge.OpenAI.Interfaces.Services;
using Forge.OpenAI.Models.ChatCompletions;
using Forge.OpenAI.Models.Common;

namespace MainStreetGenomeProject.MVVM.ViewModels;
public class MainViewModel : ObservableObject
{
    private readonly IOpenAIService openAI;
    public MainViewModel(IOpenAIService openAI)
    {
        this.openAI = openAI;
    }
    private readonly ICompanyData companyData = new CompanyData(new SQLDataAccess(App.Configuration));
    private readonly IThreadData threadData = new ThreadData(new SQLDataAccess(App.Configuration));
    private readonly ICommentData commentData = new CommentData(new SQLDataAccess(App.Configuration));

    public ICommand StartCommand =>
        new RelayCommand(async () =>
        {
            //while (true)
            //{
            //    string htmltext = await DownloadPageSource.DownloadHtmlAsync(1);
            //    File.WriteAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\GlownaStronaHtml", htmltext);
            //    HtmlNodeCollection htmlNodes = await GetRelevantNodes.GetMainPageNodes(htmltext);
            //    await new ProcessHtmlNodes(companyData, threadData, commentData).Start(htmlNodes);
            //    await Task.Delay(15000);
            //}
            //k();
            //await Chat.ChatWithNonStreamingModeAsync(openAI);/
            //IleSlowWKomentarzach();
            ilekomentarzyzdzisiajiwatkow();
        });

    private async void ilekomentarzyzdzisiajiwatkow()
    {
        var threads = await threadData.GetAllThreadsAsync();
        threads=threads.Where(q=>q.DateTime == DateTime.Today);
        var comments = await commentData.GetAllCommentsAsync();
        comments = comments.Where(q => q.DateTime == DateTime.Today);
        MessageBox.Show($"Threads from today: {threads.Count()}, comments from today: {comments.Count()}");
    }

    private async void IleSlowWKomentarzach()
    {
        var comments = await commentData.GetAllCommentsAsync();
        int nr = 0;
        foreach (var comment in comments)
        {
            var nrOfWords = comment.CommentText.Split(' ');
            nr += nrOfWords.Count();
        }
        MessageBox.Show(comments.Count().ToString());
        MessageBox.Show(nr.ToString());
    }

    private async void k()
    {
        var threads = await threadData.GetAllThreadsAsync();
        MessageBox.Show(threads.DistinctBy(q => q.Hyperlink).Count().ToString());
        var comments = await commentData.GetAllCommentsAsync();
        MessageBox.Show($"distinct comments: {comments.DistinctBy(q => q.CommentText, StringComparer.OrdinalIgnoreCase).Count().ToString()}");
    }

}

