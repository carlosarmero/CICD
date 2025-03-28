using Screens.TestFramework.Core.BrowserUtils;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public abstract class BaseTest : ScreenshotMaker, IDisposable
    {
        private readonly EpamPage epam;
        protected readonly WebDriverService driver;

        public BaseTest()
        {
            driver = new WebDriverService();
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
        // Helper method to convert string log level to Serilog level
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
        public void Dispose()
        {
            driver.Dispose();
        }

    }
}
