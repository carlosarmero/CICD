using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task
{
    class LastPage : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LastPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement body => wait.Until(d => d.FindElement(By.TagName("body")));
        public string PageText()
        {
            return body.Text.ToLower();
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
