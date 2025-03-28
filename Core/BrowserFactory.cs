using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TASk_loc1.Core
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateWebDriver(string browserType, string downloadDirectory, bool headless = true)
        {
            IWebDriver driver;

            switch (browserType.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    if (downloadDirectory != null)
                    {
                        chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    }
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless)
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    if (downloadDirectory != null)
                    {
                        firefoxOptions.AddAdditionalOption("download.default_directory", downloadDirectory);
                    }

                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (headless)
                    {
                        edgeOptions.AddArgument("--headless");
                    }
                    if (downloadDirectory != null)
                    {
                        edgeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    }
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser type: {browserType}");
            }

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);

            return driver;
        }
    }
}