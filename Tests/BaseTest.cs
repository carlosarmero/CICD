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
                webDriverConfig = new WebDriverConfiguration();
                filesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                
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
            }/*
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
            }*/

        }
    }
