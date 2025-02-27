using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
