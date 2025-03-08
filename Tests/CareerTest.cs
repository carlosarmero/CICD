using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public class CareerTest
    {
        private readonly EpamPage epam;
        private readonly Career epamCareers;
        private readonly Results epamResults;
        private readonly LastPage last;
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
            epamCareers = new Career(driver, wait);
            epamResults = new Results(driver, wait);
            last = new LastPage(driver, wait);
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
                epamCareers.AllLocations();
                epamCareers.AllLocation();
                epamCareers.ClickRemote();
                epamCareers.Search();
                epamResults.ClickLast();
                Assert.Contains(lang, last.PageText());
            }
            finally
            {
                last.Dispose();
            }

        }

    }
}