using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TASk_loc1.Core
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateWebDriver(WebDriverConfiguration config)
        {
            IWebDriver driver;

            switch (config.BrowserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    if (config.IsHeadless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    if (config.DownloadDirectory != null)
                    {
                        chromeOptions.AddUserProfilePreference("download.default_directory", config.DownloadDirectory);
                    }
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    if (config.IsHeadless)
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    if (config.DownloadDirectory != null)
                    {
                        firefoxOptions.AddAdditionalOption("download.default_directory", config.DownloadDirectory);
                    }
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case BrowserType.Edge:
                    var edgeOptions = new EdgeOptions();
                    if (config.IsHeadless)
                    {
                        edgeOptions.AddArgument("--headless");
                    }
                    if (config.DownloadDirectory != null)
                    {
                        edgeOptions.AddUserProfilePreference("download.default_directory", config.DownloadDirectory);
                    }
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser type: {config.BrowserType}");
            }

            // Use the timeouts defined in the configuration
            driver.Manage().Timeouts().PageLoad = config.PageLoadTimeout;
            driver.Manage().Timeouts().ImplicitWait = config.ImplicitWait;
            driver.Manage().Timeouts().AsynchronousJavaScript = config.AsynchronousJavascriptTimeout;

            return driver;
        }
    }
}