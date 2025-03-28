using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class InsightsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public InsightsPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement Arrow => wait.Until(d => d.FindElement(By.XPath("//button[contains(@class, 'slider__right-arrow slider-navigation-arrow')]")));
        public IWebElement ArticleTitle => wait.Until(d => d.FindElement(By.XPath("//span[contains(@class, 'rte-text-gradient gradient-text')]")));
        public IWebElement ReadMoreButton => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'single-slide-ui')]/div/div/a")));

        public void ClickArrow()
        {
            Arrow.Click();
            Arrow.Click();
        }
        public string GetArticleTitle()
        {
            return ArticleTitle.Text.ToLower();
        }
        public void ReadMore()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", ReadMoreButton);
        }
    }
}