using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TASk_loc1.Core;

namespace TASk_loc1.Tests
{
	public class WebDriverService : IDisposable
	{
		protected IWebDriver driver;
		protected WebDriverWait wait ;
		protected string downloadDirectory;

		public WebDriverService(bool headless = false)
		{
			downloadDirectory = Path.Combine(
                Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                "Downloads");
            driver = BrowserFactory.CreateWebDriver("chrome", downloadDirectory, headless);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		}
		public void Dispose()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}