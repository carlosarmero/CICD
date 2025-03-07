using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class GlobalResults : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public GlobalResults(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IList<IWebElement> Results => wait.Until(d => d.FindElements(By.ClassName("search-results__description")));
        public bool AreAllResultsContainingTerm(string searchTerm)
        {
            return Results.All(link => link.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        public void Dispose()
        {
            driver.Quit();
        }

    }
}
