using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.Business
{
    class Article
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public Article(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement Title => wait.Until(d => d.FindElement(By.XPath("//p[contains(@class, 'scaling-of-text-wrapper')]")));
        public string GetTitleText()
        {
            return Title.Text.ToLower();
        }
    }
}
