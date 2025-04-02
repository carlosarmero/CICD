using Microsoft.Extensions.Configuration;
using Screens.TestFramework.Core.BrowserUtils;
using Serilog;
using TASk_loc1.Core;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public abstract class BaseTest : ScreenshotMaker
    {
        private readonly EpamPage epam;
        protected readonly WebDriverService driver;
        private readonly string filesDirectory;
        private readonly WebDriverConfiguration webDriverConfig;
        public BaseTest()
        {
            //filesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            filesDirectory = Path.Combine(
                    Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                    "Core/Files/");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .SetBasePath(filesDirectory)
                .Build();

            webDriverConfig = new WebDriverConfiguration();
            configuration.GetSection("WebDriverConfiguration").Bind(webDriverConfig);

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

            driver = new WebDriverService(webDriverConfig);
            epam = new EpamPage(driver.GetWebDriver(), driver.GetWebDriverWait());
        }

        protected void InitializeBrowser()
        {
            epam.GoWeb();
            epam.AcceptCookies();
        }

        protected void OpenCareersPage() => epam.OpenCareers();
        protected void OpenAboutPage() => epam.OpenAbout();
        protected void OpenInsightsPage() => epam.OpenInsights();
        protected void PerformGlobalSearch(string searchTerm) => epam.GlobalSearchInfo(searchTerm);

        public string GetFilePath()
        {
            return this.filesDirectory;
        }
    }
}
