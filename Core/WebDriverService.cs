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
        protected BrowserFactory _browserFactory;
        public WebDriverService(WebDriverConfiguration config)
        {
            _config = config;
            _browserFactory = new BrowserFactory(_config);
            _driver = _browserFactory.CreateWebDriver();
            _wait = new WebDriverWait(_driver, _config.ExplicitWait);
        }
        public IWebDriver GetWebDriver() => _driver;
        public WebDriverWait GetWebDriverWait() => _wait;
        public WebDriverConfiguration Getconfig() => _config;

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}