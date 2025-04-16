using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TASk_loc1.Core
{
    public class BrowserFactory
    {
        private readonly WebDriverConfiguration _config;
        public BrowserFactory(WebDriverConfiguration config)
        {
            _config = config;
        }
        public IWebDriver CreateWebDriver()
        {
            IWebDriver driver;

            switch (_config.BrowserType)
            {
                case BrowserType.Chrome:
                    driver = CreateChromeDriver(_config);
                    break;
                case BrowserType.Firefox:
                    driver = CreateFirefoxDriver(_config);
                    break;
                case BrowserType.Edge:
                    driver = CreateEdgeDriver(_config);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser type: {_config.BrowserType}");
            }

            driver.Manage().Timeouts().PageLoad = _config.PageLoadTimeout;
            driver.Manage().Timeouts().ImplicitWait = _config.ImplicitWait;
            driver.Manage().Timeouts().AsynchronousJavaScript = _config.AsynchronousJavascriptTimeout;

            return driver;
        }
        private IWebDriver CreateChromeDriver(WebDriverConfiguration config)
        {
            var chromeOptions = new ChromeOptions();
            if (config.IsHeadless)
            {
                chromeOptions.AddArgument("--headless");
            }
            if (config.DownloadDirectory != null)
            {
                chromeOptions.AddUserProfilePreference("download.default_directory", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), config.DownloadDirectory));
            }
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            return new ChromeDriver(chromeOptions);
        }

        private IWebDriver CreateFirefoxDriver(WebDriverConfiguration config)
        {
            var firefoxOptions = new FirefoxOptions();
            if (config.IsHeadless)
            {
                firefoxOptions.AddArgument("--headless");
            }

            if (config.DownloadDirectory != null)
            {
                firefoxOptions.AddAdditionalOption("download.default_directory", config.DownloadDirectory);
            }

            return new FirefoxDriver(firefoxOptions);
        }

        private IWebDriver CreateEdgeDriver(WebDriverConfiguration config)
        {
            var edgeOptions = new EdgeOptions();
            if (config.IsHeadless)
            {
                edgeOptions.AddArgument("--headless");
            }
            if (config.DownloadDirectory != null)
            {
                edgeOptions.AddUserProfilePreference("download.default_directory", config.DownloadDirectory);
            }

            return new EdgeDriver(edgeOptions);
        }
    }
}