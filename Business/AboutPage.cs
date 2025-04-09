using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.Business
{
    class AboutPage
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


        public IWebElement Team => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'text-ui-23')]/p/span")));
        public IWebElement Social => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'footer-links')]/div/h2")));

        public void ScrollToGlance()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", GlanceSection);
        }

        public void ClickDownload()
        {
            DownloadButton.Click();
        }


        public void ScrollToTeam()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", Team);
        }

        public void ScrollToSocial()
        {
            Actions actions = new Actions(driver);
            actions.ScrollByAmount(0, 1000).Perform();
        }
    }
}