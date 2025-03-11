using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public class DownTest
    {
        private readonly EpamPage epam;
        private readonly About about;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly string _downloadDirectory;

        public string[] downloadedFiles;

        public DownTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            epam = new EpamPage(driver, wait);
            about = new About(driver, wait);

            _downloadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
        }


        [Theory]
        [InlineData("EPAM_Corporate_Overview_Q4FY-2024")]
        public void TestCareers(string filename)
        {
            try
            {
                epam.GoWeb();
                epam.AcceptCookies();
                epam.OpenAbout();
                about.ScrollGlance();
                about.ClickDown();
                Thread.Sleep(3000);

               // Assert.Contains(filename, Path.GetFileName(downloadedFile)););
            }
            finally
            {
                epam.Dispose();
            }

        }

    }
}