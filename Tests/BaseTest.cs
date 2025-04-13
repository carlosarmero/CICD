using Microsoft.Extensions.Configuration;
using Serilog;
using TASk_loc1.Business;
using TASk_loc1.Core;

namespace TASk_loc1.Tests
{
    public abstract class BaseTest
    {
        private readonly EpamPage epam;
        protected readonly WebDriverService driver;
        private readonly string settingsDirectory;
        private readonly string downloadDirectory;
        public BaseTest()
        {
            settingsDirectory = settingsDirectory = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "core", "files");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(settingsDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            downloadDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), configuration.GetSection("WebDriverConfiguration").Get<WebDriverConfiguration>().DownloadDirectory);

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

            driver = new WebDriverService(configuration.GetSection("WebDriverConfiguration").Get<WebDriverConfiguration>());
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
            return this.downloadDirectory;
        }
    }
}
