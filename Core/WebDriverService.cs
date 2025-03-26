using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Support.UI;
using Screens.TestFramework.Core.BrowserUtils;
using Serilog;
//using Serilog.Sinks.Console;
using TASk_loc1.Core;

namespace TASk_loc1.Tests
{
	public class WebDriverService : ScreenshotMaker
    {
		protected IWebDriver driver;
		protected WebDriverWait wait ;
		protected string downloadDirectory;
        protected string logDirectory;

        protected string logDirectoryfile;

        public WebDriverService(bool headless = true)
		{
			downloadDirectory = Path.Combine(
                Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                "Downloads");
            logDirectory = Path.Combine(
                   Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                   "Core/Logs/log-.txt");

            logDirectoryfile = Path.Combine(
                   Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                   "Core/");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(logDirectoryfile)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Read minimum log level from configuration (defaults to Debug if not set)
            string minLogLevel = configuration["Logging:LogLevel:Default"] ?? "Debug";

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(GetLogLevel(minLogLevel))
            //.WriteTo.Console()
            .WriteTo.File(logDirectory)
            .CreateLogger();
            driver = BrowserFactory.CreateWebDriver("chrome", downloadDirectory, headless);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		}
        // Helper method to convert string log level to Serilog level
        private static Serilog.Events.LogEventLevel GetLogLevel(string level)
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