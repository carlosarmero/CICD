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
                    driver = CreateChromeDriver(config);
                    break;
                    case BrowserType.Firefox:
                    driver = CreateFirefoxDriver(config);
                    break;
                    case BrowserType.Edge:
                    driver = CreateEdgeDriver(config);
                    break;

                    default:
                        throw new ArgumentException($"Unsupported browser type: {config.BrowserType}");
                }

                driver.Manage().Timeouts().PageLoad = config.PageLoadTimeout;
                driver.Manage().Timeouts().ImplicitWait = config.ImplicitWait;
                driver.Manage().Timeouts().AsynchronousJavaScript = config.AsynchronousJavascriptTimeout;

                return driver;
            }
        private static IWebDriver CreateChromeDriver(WebDriverConfiguration config)
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

            return new ChromeDriver(chromeOptions);
        }

        private static IWebDriver CreateFirefoxDriver(WebDriverConfiguration config)
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

        private static IWebDriver CreateEdgeDriver(WebDriverConfiguration config)
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