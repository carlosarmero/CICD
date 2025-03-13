using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public class CareerTest
    {
        private readonly EpamPage epam;
        private readonly CareerPage epamCareers;
        private readonly CareerResults epamResults;
        private readonly LastResultPage last;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CareerTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            epam = new EpamPage(driver, wait);
            epamCareers = new CareerPage(driver, wait);
            epamResults = new CareerResults(driver, wait);
            last = new LastResultPage(driver, wait);
        }


        [Theory]
        [InlineData("c#")]
        [InlineData("html")]
        public void TestCareers(string lang)
        {
            try
            {
                epam.GoWeb();
                epam.AcceptCookies();
                epam.OpenCareers();
                epamCareers.EnterSearchTerm(lang);
                epamCareers.Locations();
                epamCareers.AllLocation();
                epamCareers.ClickRemote();
                epamCareers.Search();
                epamResults.ClickLast();
                Assert.Contains(lang, last.GetPageText());
            }
            finally
            {
                last.Dispose();
            }

        }

    }
}