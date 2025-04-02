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
            filesDirectory = Path.Combine(
                   Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                   "Core/Files/");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(filesDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            webDriverConfig = new WebDriverConfiguration();
            configuration.GetSection("WebDriverConfiguration").Bind(webDriverConfig);

            string minLogLevel = configuration["Logging:LogLevel:Default"] ?? "Debug";

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(GetLogLevel(minLogLevel))
            .WriteTo.File(Path.Combine(filesDirectory, "Logs.txt"))
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
        public static Serilog.Events.LogEventLevel GetLogLevel(string level)
        {
            return level.ToLower() switch
            {
                "debug" => Serilog.Events.LogEventLevel.Debug,
                "information" => Serilog.Events.LogEventLevel.Information,
                "warning" => Serilog.Events.LogEventLevel.Warning,
                "error" => Serilog.Events.LogEventLevel.Error,
                "fatal" => Serilog.Events.LogEventLevel.Fatal,
                _ => Serilog.Events.LogEventLevel.Debug,
            };
        }

    }
}
