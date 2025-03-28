using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.Core;

namespace TASk_loc1.Tests
{
    public class WebDriverService : IDisposable
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        public WebDriverService(string downloadDirectory = null, bool headless = false)
        {
            _driver = BrowserFactory.CreateWebDriver("chrome", downloadDirectory, headless);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
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