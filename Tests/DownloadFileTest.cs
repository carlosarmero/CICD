using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public class DownloadFileTest
    {
        private readonly EpamPage epam;
        private readonly AboutPage about;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly string _downloadDirectory;

        public DownloadFileTest()
        {
            _downloadDirectory = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName, "Downloads");
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", _downloadDirectory);
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            epam = new EpamPage(driver, wait);
            about = new AboutPage(driver, wait);
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
                about.ScrollToGlance();
                about.ClickDownload();
                string[] downloadedFiles = Directory.GetFiles(_downloadDirectory);
                bool fileContainsString = downloadedFiles.Any(file => Path.GetFileName(file).Contains(filename, StringComparison.OrdinalIgnoreCase));
                Assert.True(fileContainsString, $"No file in the directory contains the string '{filename}' in its name.");
            }
            finally
            {
                epam.Dispose();
            }

        }

    }
}