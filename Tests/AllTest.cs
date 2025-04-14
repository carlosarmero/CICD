using OpenQA.Selenium;
using Screens.TestFramework.Core.BrowserUtils;
using Serilog;
using TASk_loc1.Business.POM;

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
        public AllTest() : base()
        {
            epamCareers = new CareerPage(driver.GetWebDriver(), driver.GetWebDriverWait());
            epamResults = new CareerResults(driver.GetWebDriver(), driver.GetWebDriverWait());
            last = new LastResultPage(driver.GetWebDriver(), driver.GetWebDriverWait());
            globalResults = new GlobalResults(driver.GetWebDriver(), driver.GetWebDriverWait());
            about = new AboutPage(driver.GetWebDriver(), driver.GetWebDriverWait());
            insights = new InsightsPage(driver.GetWebDriver(), driver.GetWebDriverWait());
            article = new Article(driver.GetWebDriver(), driver.GetWebDriverWait());
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
                Log.Error(ex, $"Error during test with {lang}", ex.Message);
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
                Log.Error(ex, $"Error during test with {word}", ex.Message);
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
                string[] downloadedFiles = Directory.GetFiles(GetFilePath());
                bool fileContainsString = downloadedFiles.Any(file => Path.GetFileName(file).Contains(filename, StringComparison.OrdinalIgnoreCase));
                Assert.True(fileContainsString, $"No file in the directory contains the string '{filename}' in its name.");
            }
            catch (Exception ex)
            {
                _testFailed = true;
                Log.Error(ex, $"Error during test with {filename}", ex.Message);
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
                Log.Error(ex, $"Error during carousel test", ex.Message);
                throw;
            }
        }
        public void Dispose()
        {
            var pdfFiles = Directory.GetFiles(GetFilePath(), "*.pdf");

            foreach (var file in pdfFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error deleting file {file}: {ex.Message}");
                }
            }
            if (_testFailed) { ScreenshotMaker.TakeBrowserScreenshot(driver.GetWebDriver() as ITakesScreenshot, driver.Getconfig()); }
            driver.Dispose();
        }
    }
}