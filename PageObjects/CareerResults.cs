using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class CareerResults : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CareerResults(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IList<IWebElement> Items => wait.Until(d => d.FindElements(By.ClassName("search-result__item-controls")));
        public void ClickLast()
        {
            Items.Last().Click();
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
