using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1
{
    public class CareerTest
    {
        private readonly EpamPage epam;
        private readonly Career epamCareers;
        private readonly Results epamResults;
        private readonly LastPage lasts;
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
                epamCareers.ClickRemote();
                epamCareers.Search();
                epamResults.ClickLast();
                Assert.Contains(lang, "c# es lo q buscasmos en todo este texto, q debehtml ser la pagina escnaeada");
            }
            finally
            {
                epamResults.Dispose();
            }

        }

    }
}