using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Support.UI;
using Screens.TestFramework.Core.BrowserUtils;
using Serilog;
using TASk_loc1.Core;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TASk_loc1.Tests
{
	public class WebDriverService : IDisposable
    {
		protected IWebDriver _driver;
		protected WebDriverWait _wait ;
        public WebDriverService(string downloadDirectory = null, bool headless = true)
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