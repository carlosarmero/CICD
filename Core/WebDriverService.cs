using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.Core;

namespace TASk_loc1.Tests
{
    public class WebDriverService : IDisposable
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected WebDriverConfiguration _config;
        public WebDriverService(WebDriverConfiguration config)
        {
            _config = config;
            _driver = BrowserFactory.CreateWebDriver(_config);
            _wait = new WebDriverWait(_driver, _config.ExplicitWait);
        }
        public IWebDriver GetWebDriver() => _driver;
        public WebDriverWait GetWebDriverWait() => _wait;

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}