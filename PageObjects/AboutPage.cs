using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class AboutPage : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public AboutPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement GlanceSection => wait.Until(d => d.FindElement(By.XPath("//p[contains(@class, 'scaling-of-text-wrapper')]/span/span")));
        public IWebElement DownloadButton => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'button')]/a/span/span")));

        public void ScrollToGlance()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", GlanceSection);
        }

        public void ClickDownload()
        {
            DownloadButton.Click();
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}