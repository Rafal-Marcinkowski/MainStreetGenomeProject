using GalaSoft.MvvmLight.Command;
using Library.DownloadDataFromForum;
using Library.GetDataFromHtml;
using System.Windows.Input;
using System.IO;
using DataAccess.Models;
using HtmlAgilityPack;
using DataAccess.Data;
using ValidationComponent.CompanyValidation;
using ValidationComponent.ThreadValidation;
using DataAccess.DBAccess;

namespace MainStreetGenomeProject.MVVM.ViewModels;
public class MainViewModel : BaseViewModel
{
    private readonly ICompanyData companyData = new CompanyData(new SQLDataAccess(App.Configuration));
    private readonly IThreadData threadData = new ThreadData(new SQLDataAccess(App.Configuration));
    public ICommand StartCommand =>
        new RelayCommand(async () =>
        {
            string htmltext = await DownloadMainPage.DownloadHtmlAsync(1);
            File.WriteAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\GlownaStronaHtml", htmltext);
            HtmlNodeCollection htmlNodes = await GetRelevantNodes.GetMainPageNodes(htmltext);
            await new ProcessHtmlNodes(companyData,threadData).Start(htmlNodes);
            foreach (var thread in htmlNodes)
            {
                var companyName = thread.SelectSingleNode(".//td[@class='threadGroup']").InnerText.Trim();
                var threadLink = thread.SelectSingleNode(".//td[@class='threadTitle']/a").Attributes["href"].Value;
                var threadTitleText = thread.SelectSingleNode(".//td[@class='threadTitle']/a").InnerText.Trim();
                var threadAuthor = thread.SelectSingleNode(".//td[@class='threadAuthor textNowrap']").InnerText.Trim();
                var threadCommentsCount = thread.SelectSingleNode(".//td[@class='threadCount textAlignCenter textNowrap']/span").InnerText.Trim();
                var threadCreateDate = thread.SelectSingleNode(".//td[@class='createDate textAlignCenter textNowrap']").InnerText.Trim();
                if (threadAuthor == "Puls Biznesu")
                {
                    continue;
                }
                if (!await new CompanyExists(companyData).Exists(companyName) && !string.IsNullOrEmpty(companyName))
                {
                    await companyData.InsertCompanyAsync(companyName, null);
                }
                var companies = await companyData.GetAllCompaniesAsync();
                var company = companies.FirstOrDefault(q => q.CompanyName.Equals(companyName));
                if (!await new ThreadExists(threadData).Exists(threadTitleText) && !string.IsNullOrEmpty(threadTitleText))
                {
                    await threadData.InsertThreadAsync(company.ID, threadTitleText, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm")), Byte.Parse(threadCommentsCount), null, threadAuthor, threadLink);
                }
            }
        });

}










//string s = string.Join('|', threadGroup, threadTitleLink, threadTitleText, threadAuthor, threadCount, threadCreateDate);
//File.AppendAllText("C:\\Users\\rafal\\Desktop\\Pogromcy\\MainStreetGenomeProject\\nodesText.txt", s);