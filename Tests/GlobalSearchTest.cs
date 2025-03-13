using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public class GlobalSearchTest : IDisposable
    {
        private readonly EpamPage page;
        private readonly GlobalResults globalResults;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public GlobalSearchTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            page = new EpamPage(driver, wait);
            globalResults = new GlobalResults(driver, wait);
        }

        [Theory]
        [InlineData("BLOCKCHAIN")]
        [InlineData("Cloud")]
        [InlineData("Automation")]
        public void SearchTest(string word)
        {
            page.GoWeb();
            page.AcceptCookies();
            page.GlobalSearchInfo(word);
            Assert.True(globalResults.AreAllResultsContainingTerm(word),
                    $"Not all links contain the search term '{word}'");           
        }
        public void Dispose()
        {
            globalResults.Dispose();
        }
    }
}
