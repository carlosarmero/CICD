using TASk_loc1.PageObjects;
using Xunit;

namespace TASk_loc1.Tests
{
    public class AllTest : WebDriverService
    {
        private readonly EpamPage epam;
        private readonly CareerPage epamCareers;
        private readonly CareerResults epamResults;
        private readonly LastResultPage last;
        private readonly GlobalResults globalResults;
        private readonly AboutPage about;
        private readonly InsightsPage insights;
        private readonly Article article;

        public AllTest()
        {
            epam = new EpamPage(driver, wait);
            epamCareers = new CareerPage(driver, wait);
            epamResults = new CareerResults(driver, wait);
            last = new LastResultPage(driver, wait);
            globalResults = new GlobalResults(driver, wait);
            about = new AboutPage(driver, wait);
            insights = new InsightsPage(driver, wait);
            article = new Article(driver, wait);
        }

        [Theory]
        [InlineData("c#")]
        [InlineData("html")]
        public void CareersTest(string lang)
        {
            epam.GoWeb();
            epam.AcceptCookies();
            epam.OpenCareers();
            epamCareers.SearchDetails(lang);
            epamResults.ClickLast();
            Assert.Contains(lang, last.GetPageText());
        }

        [Theory]
        [InlineData("BLOCKCHAIN")]
        [InlineData("Cloud")]
        [InlineData("Automation")]
        public void SearchTest(string word)
        {
            epam.GoWeb();
            epam.AcceptCookies();
            epam.GlobalSearchInfo(word);
            Assert.True(globalResults.AreAllResultsContainingTerm(word),
                    $"Not all links contain the search term '{word}'");
        }

        [Theory]
        [InlineData("EPAM_Corporate_Overview_Q4FY-2024")]
        public void DownloadTest(string filename)
        {
            epam.GoWeb();
            epam.AcceptCookies();
            epam.OpenAbout();
            about.ScrollToGlance();
            about.ClickDownload();
            about.ScrollToTeam();
            string[] downloadedFiles = Directory.GetFiles(downloadDirectory);
            bool fileContainsString = downloadedFiles.Any(file => Path.GetFileName(file).Contains(filename, StringComparison.OrdinalIgnoreCase));
            Assert.True(fileContainsString, $"No file in the directory contains the string '{filename}' in its name.");
        }

        [Fact]
        public void CarouselTest()
        {
            epam.GoWeb();
            epam.AcceptCookies();
            epam.OpenInsights();
            insights.ClickArrow();
            string articleTitle = insights.GetArticleTitle();
            insights.ReadMore();
            string articlePageTitle = article.GetTitleText();
            Assert.Equal(articleTitle, articlePageTitle);
        }
    }
}