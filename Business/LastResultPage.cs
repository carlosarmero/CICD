using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class LastResultPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LastResultPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement body => wait.Until(d => d.FindElement(By.TagName("body")));
        public string GetPageText()
        {
            return body.Text.ToLower();
        }
    }
}
