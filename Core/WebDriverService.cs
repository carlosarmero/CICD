using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

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

            var options = new ChromeOptions();
			options.AddUserProfilePreference("download.default_directory", downloadDirectory);

			if (headless)
			{
				options.AddArgument("--headless");
			}

			driver = new ChromeDriver(options);
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		}
		public void Dispose()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}