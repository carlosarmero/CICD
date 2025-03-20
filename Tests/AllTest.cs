using TASk_loc1.PageObjects;
using Xunit;
using Serilog;
using OpenQA.Selenium;

namespace TASk_loc1.Tests
{
    public class AllTest : BaseTest, IDisposable
    {
        private readonly CareerPage epamCareers;
        private readonly CareerResults epamResults;
        private readonly LastResultPage last;
        private readonly GlobalResults globalResults;
        private readonly AboutPage about;
        private readonly InsightsPage insights;
        private readonly Article article;

        private bool _testFailed;
        public AllTest(): base() 
        {
            epamCareers = new CareerPage(driver, wait);
            epamResults = new CareerResults(driver, wait);
            last = new LastResultPage(driver, wait);
            globalResults = new GlobalResults(driver, wait);
            about = new AboutPage(driver, wait);
            insights = new InsightsPage(driver, wait);
            article = new Article(driver, wait);
            _testFailed = false;
        }

        [Theory]
        [InlineData("c#")]
        [InlineData("html")]
        public void CareersTest(string lang)
        {
            try
            {
            Log.Information("Starting Career test");
            InitializeBrowser();
            OpenCareersPage();
            epamCareers.SearchDetails(lang);
            epamResults.ClickLast();
            Assert.Contains(lang, last.GetPageText());
            }
            catch (Exception ex)
            {
                _testFailed = true;
                Log.Error(ex, $"Error durante la prueba con {lang}", ex.Message);
                throw;
            }
        }

        [Theory]
        [InlineData("BLOCKCHAIN")]
        [InlineData("Cloud")]
        [InlineData("Automation")]
        public void SearchTest(string word)
        {
            try
            {
                Log.Information("Starting Global search test");
                InitializeBrowser();
                PerformGlobalSearch(word);
                Assert.True(globalResults.AreAllResultsContainingTerm(word),
                        $"Not all links contain the search term '{word}'");
            }
            catch (Exception ex)
            {
                _testFailed = true;
                Log.Error(ex, $"Error durante la prueba con {word}", ex.Message);
                throw;
            }
        }

        [Theory]
        [InlineData("EPAM_Corporate_Overview_Q4FY-2024")]
        public void DownloadTest(string filename)
        {
            try
            {
                Log.Information("Starting Download pdf test");
                InitializeBrowser();
                OpenAboutPage();
                about.ScrollToGlance();
                about.ClickDownload();
                about.ScrollToTeam();
                string[] downloadedFiles = Directory.GetFiles(downloadDirectory);
                bool fileContainsString = downloadedFiles.Any(file => Path.GetFileName(file).Contains(filename, StringComparison.OrdinalIgnoreCase));
                Assert.True(fileContainsString, $"No file in the directory contains the string '{filename}' in its name.");
            }
            catch (Exception ex)
            {
                _testFailed = true;
                Log.Error(ex, $"Error durante la prueba con {filename}", ex.Message);
                throw;
            }
        }

        [Fact]
        public void CarouselTest()
        {
            try
            {
                Log.Information("Starting Carousel test");
                InitializeBrowser();
                OpenInsightsPage();
                insights.ClickArrow();
                string articleTitle = insights.GetArticleTitle();
                insights.ReadMore();
                string articlePageTitle = article.GetTitleText();
                Assert.Equal(articleTitle, articlePageTitle);
            }
            catch (Exception ex)
            {
                _testFailed = true;
                Log.Error(ex, $"Error durante la prueba de carrusel", ex.Message);
                throw;
            }
        }
        public void Dispose()
        {
            if (_testFailed) { TakeBrowserScreenshot(driver as ITakesScreenshot);}
            driver.Quit();
            driver.Dispose();
        }
    }
}