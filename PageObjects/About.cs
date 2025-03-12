using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class About : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public About(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement Glance => wait.Until(d => d.FindElement(By.XPath("//p[contains(@class, 'scaling-of-text-wrapper')]/span/span")));
        public IWebElement DownButton => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'button')]/a/span/span")));

        public void ScrollGlance()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", Glance);
        }

        public void ClickDown()
        {
            DownButton.Click();
            Thread.Sleep(1200);
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}