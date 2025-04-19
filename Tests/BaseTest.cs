using Microsoft.Extensions.Configuration;
using Serilog;
using TASk_loc1.Business.POM;
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
            var potentialPaths = new[]
           {
               // Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "core", "files"),
                Directory.GetCurrentDirectory(),
                "/home/runner/work/CICD/CICD/core/files" // GitHub Actions default
            };

            settingsDirectory = potentialPaths.FirstOrDefault(Directory.Exists);

            if (settingsDirectory == null)
            {
                Console.WriteLine("❌ ERROR: Could not locate 'core/files' directory. Checked paths:");
                foreach (var path in potentialPaths)
                    Console.WriteLine($" - {path}");

                throw new DirectoryNotFoundException("Could not find the 'core/files' directory.");
            }

            Console.WriteLine($"✅ Found settings directory at: {settingsDirectory}");

            string configPath = Path.Combine(settingsDirectory, "appsettings.json");
            if (!File.Exists(configPath))
            {
                Console.WriteLine($"❌ appsettings.json not found at: {configPath}");
                throw new FileNotFoundException("appsettings.json is missing in core/files directory.");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(settingsDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
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
